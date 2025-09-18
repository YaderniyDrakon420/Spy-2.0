using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Spy_2._0.Forms
{
    public partial class Form1 : Form
    {
        private AppSettings _settings;
        private ManagementEventWatcher _processStartWatcher;

        public Form1()
        {
            InitializeComponent();
            LoadSettings();
            StartProcessWatcher();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _settings.ReportsPath = txtPath.Text.Trim();
            _settings.Statistics = chkStatistics.Checked;
            _settings.Moderation = chkModeration.Checked;
            _settings.ForbiddenWords = ForbiddenWords.Items.Cast<string>().ToList();
            _settings.ForbiddenPrograms = ForbiddenPrograms.Items.Cast<string>().ToList();

            string filePath = Path.Combine(Application.StartupPath, "settings.json");
            string json = JsonConvert.SerializeObject(_settings, Formatting.Indented);
            File.WriteAllText(filePath, json);

            MessageBox.Show("Настройки сохранены!");
        }

        private void btnAddWord_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNewWord.Text))
            {
                ForbiddenWords.Items.Add(txtNewWord.Text);
                txtNewWord.Clear();
            }
        }

        private void btnRemoveWord_Click(object sender, EventArgs e)
        {
            if (ForbiddenWords.SelectedItem != null)
                ForbiddenWords.Items.Remove(ForbiddenWords.SelectedItem);
        }

        private void btnAddProgram_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNewProgram.Text))
            {
                ForbiddenPrograms.Items.Add(txtNewProgram.Text);
                txtNewProgram.Clear();
            }
        }

        private void btnRemoveProgram_Click(object sender, EventArgs e)
        {
            if (ForbiddenPrograms.SelectedItem != null)
                ForbiddenPrograms.Items.Remove(ForbiddenPrograms.SelectedItem);
        }

        private void btnViewLog_Click(object sender, EventArgs e)
        {
            string path = _settings.ReportsPath;
            if (string.IsNullOrWhiteSpace(path))
                path = Path.Combine(Application.StartupPath, "Reports");

            string filePath = Path.Combine(path, "log.txt");
            ShowFileInForm(filePath, "Лог нажатий клавиш");
        }

        private void btnViewProcesses_Click(object sender, EventArgs e)
        {
            string path = _settings.ReportsPath;
            if (string.IsNullOrWhiteSpace(path))
                path = Path.Combine(Application.StartupPath, "Reports");

            string filePath = Path.Combine(path, "process_log.txt");
            ShowFileInForm(filePath, "Лог запущенных программ");
        }

        private void ShowFileInForm(string filePath, string title)
        {
            if (!File.Exists(filePath))
            {
                MessageBox.Show("Файл пуст или не найден: " + filePath);
                return;
            }

            string[] lines = File.ReadAllLines(filePath);

            Form logForm = new Form
            {
                Text = title,
                Size = new System.Drawing.Size(600, 400)
            };

            TextBox box = new TextBox
            {
                Multiline = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Vertical,
                Dock = DockStyle.Fill
            };

            foreach (string line in lines)
                box.AppendText(line + Environment.NewLine);

            logForm.Controls.Add(box);
            logForm.Show();
        }

        private void LoadSettings()
        {
            string filePath = Path.Combine(Application.StartupPath, "settings.json");
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                _settings = JsonConvert.DeserializeObject<AppSettings>(json);
            }
            else
            {
                _settings = new AppSettings
                {
                    ReportsPath = Path.Combine(Application.StartupPath, "Reports"),
                    ForbiddenWords = new List<string>(),
                    ForbiddenPrograms = new List<string>()
                };
            }

            txtPath.Text = _settings.ReportsPath;
            chkStatistics.Checked = _settings.Statistics;
            chkModeration.Checked = _settings.Moderation;

            ForbiddenWords.Items.Clear();
            foreach (var word in _settings.ForbiddenWords)
                ForbiddenWords.Items.Add(word);

            ForbiddenPrograms.Items.Clear();
            foreach (var prog in _settings.ForbiddenPrograms)
                ForbiddenPrograms.Items.Add(prog);
        }

        private void StartProcessWatcher()
        {
            try
            {
                string query = "SELECT * FROM Win32_ProcessStartTrace";
                _processStartWatcher = new ManagementEventWatcher(new WqlEventQuery(query));
                _processStartWatcher.EventArrived += ProcessStarted;
                _processStartWatcher.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка запуска процесс-ватчера: " + ex.Message);
            }
        }

        private void ProcessStarted(object sender, EventArrivedEventArgs e)
        {
            string processNameFull = e.NewEvent.Properties["ProcessName"].Value.ToString();
            string processName = Path.GetFileNameWithoutExtension(processNameFull);
            DateTime startTime = DateTime.Now;

            string path = _settings.ReportsPath;
            if (string.IsNullOrWhiteSpace(path))
                path = Path.Combine(Application.StartupPath, "Reports");

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            string filePath = Path.Combine(path, "process_log.txt");

            if (_settings.Moderation && _settings.ForbiddenPrograms != null)
            {
                // проверяем без расширения
                bool isForbidden = _settings.ForbiddenPrograms
                    .Any(f => string.Equals(f, processName, StringComparison.OrdinalIgnoreCase));

                if (isForbidden)
                {
                    try
                    {
                        foreach (var proc in Process.GetProcessesByName(processName))
                        {
                            proc.Kill();
                        }
                        string blockLine = $"{startTime:yyyy-MM-dd HH:mm:ss} - BLOCKED {processNameFull}{Environment.NewLine}";
                        File.AppendAllText(filePath, blockLine, Encoding.UTF8);
                        return;
                    }
                    catch (Exception ex)
                    {
                        string errorLine = $"{startTime:yyyy-MM-dd HH:mm:ss} - ERROR closing {processNameFull}: {ex.Message}{Environment.NewLine}";
                        File.AppendAllText(filePath, errorLine, Encoding.UTF8);
                        return;
                    }
                }
            }

            string logLine = $"{startTime:yyyy-MM-dd HH:mm:ss} - {processNameFull}{Environment.NewLine}";
            File.AppendAllText(filePath, logLine, Encoding.UTF8);
        }


        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _processStartWatcher?.Stop();
            _processStartWatcher?.Dispose();
            base.OnFormClosing(e);
        }

        public class AppSettings
        {
            public string ReportsPath { get; set; }
            public bool Statistics { get; set; }
            public bool Moderation { get; set; }
            public List<string> ForbiddenWords { get; set; }
            public List<string> ForbiddenPrograms { get; set; }
        }
    }
}
