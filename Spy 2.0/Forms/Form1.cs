using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Windows.Forms;
using Spy_2._0.Hooks;
using Spy_2._0.Models;

namespace Spy_2._0.Forms
{
    public partial class Form1 : Form
    {
        private AppSettings _settings;
        private ManagementEventWatcher _processStartWatcher;
        private KeyboardHook _keyboardHook;

        private Form _currentLogForm;
        private TextBox _currentLogTextBox;

        public Form1()
        {
            InitializeComponent();
            LoadSettings();
            StartProcessWatcher();
            StartKeyboardHook();

            btnSave.Click += btnSave_Click;
            btnViewLog.Click += btnViewLog_Click;
            btnViewProcesses.Click += btnViewProcesses_Click;
            btnViewJson.Click += btnViewJson_Click;
            btnRefreshLog.Click += btnRefreshLog_Click;
            btnClearLog.Click += btnClearLog_Click;
            btnOpenTextInput.Click += btnOpenTextInput_Click;

            btnAddWord.Click += btnAddWord_Click;
            btnRemoveWord.Click += btnRemoveWord_Click;
            btnAddProgram.Click += btnAddProgram_Click;
            btnRemoveProgram.Click += btnRemoveProgram_Click;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _settings.ReportsPath = txtPath.Text.Trim();
            _settings.Statistics = chkStatistics.Checked;
            _settings.Moderation = chkModeration.Checked;
            _settings.ForbiddenWords = ForbiddenWords.Items.Cast<string>().ToList();
            _settings.ForbiddenPrograms = ForbiddenPrograms.Items.Cast<string>().ToList();
            _settings.Save();
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

        private void btnViewLog_Click(object sender, EventArgs e) => ShowFile("log.txt", "Log клавиш");
        private void btnViewProcesses_Click(object sender, EventArgs e) => ShowFile("process_log.txt", "Log процессов");
        private void btnViewJson_Click(object sender, EventArgs e)
        {
            string filePath = Path.Combine(Application.StartupPath, "settings.json");
            if (!File.Exists(filePath)) { MessageBox.Show("Файл settings.json не найден!"); return; }
            string json = File.ReadAllText(filePath);
            Form jsonForm = new Form { Text = "settings.json", Size = new System.Drawing.Size(600, 400) };
            TextBox box = new TextBox { Multiline = true, ReadOnly = true, ScrollBars = ScrollBars.Vertical, Dock = DockStyle.Fill, Text = json };
            jsonForm.Controls.Add(box);
            jsonForm.Show();
        }

        private void btnRefreshLog_Click(object sender, EventArgs e) => ShowFile("log.txt", "Log клавиш");
        private void btnClearLog_Click(object sender, EventArgs e)
        {
            string logFile = Path.Combine(_settings.ReportsPath, "log.txt");
            if (File.Exists(logFile)) File.WriteAllText(logFile, string.Empty);
            if (_currentLogForm != null && !_currentLogForm.IsDisposed) _currentLogTextBox.Clear();
        }

        private void btnOpenTextInput_Click(object sender, EventArgs e)
        {
            Form inputForm = new Form { Text = "Проверка запрещенных слов", Size = new System.Drawing.Size(400, 150) };
            TextBox box = new TextBox { Dock = DockStyle.Fill };
            Button btnCheck = new Button { Text = "Проверить", Dock = DockStyle.Bottom };
            btnCheck.Click += (s, ev) =>
            {
                string input = box.Text.Trim();
                if (_settings.ForbiddenWords.Any(f => string.Equals(f, input, StringComparison.OrdinalIgnoreCase)))
                    MessageBox.Show($"Ошибка! Слово '{input}' запрещено!", "Ошибка");
                else
                    MessageBox.Show("Слово разрешено.", "OK");
            };
            inputForm.Controls.Add(box);
            inputForm.Controls.Add(btnCheck);
            inputForm.Show();
        }

        private void ShowFile(string fileName, string title)
        {
            string path = _settings.ReportsPath;
            if (string.IsNullOrWhiteSpace(path)) path = Path.Combine(Application.StartupPath, "Reports");
            string filePath = Path.Combine(path, fileName);
            if (!File.Exists(filePath)) { MessageBox.Show("Файл не найден: " + filePath); return; }
            string[] lines = File.ReadAllLines(filePath);

            if (_currentLogForm != null && !_currentLogForm.IsDisposed)
            {
                _currentLogTextBox.Clear();
                foreach (string line in lines) _currentLogTextBox.AppendText(line + Environment.NewLine);
                return;
            }

            _currentLogForm = new Form { Text = title, Size = new System.Drawing.Size(600, 400) };
            _currentLogTextBox = new TextBox { Multiline = true, ReadOnly = true, ScrollBars = ScrollBars.Vertical, Dock = DockStyle.Fill };
            foreach (string line in lines) _currentLogTextBox.AppendText(line + Environment.NewLine);
            _currentLogForm.Controls.Add(_currentLogTextBox);
            _currentLogForm.Show();
        }

        private void LoadSettings()
        {
            _settings = AppSettings.Load();
            txtPath.Text = _settings.ReportsPath;
            chkStatistics.Checked = _settings.Statistics;
            chkModeration.Checked = _settings.Moderation;
            ForbiddenWords.Items.Clear();
            foreach (var word in _settings.ForbiddenWords) ForbiddenWords.Items.Add(word);
            ForbiddenPrograms.Items.Clear();
            foreach (var prog in _settings.ForbiddenPrograms) ForbiddenPrograms.Items.Add(prog);
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
            catch (Exception ex) { MessageBox.Show("Ошибка ProcessWatcher: " + ex.Message); }
        }

        private void ProcessStarted(object sender, EventArrivedEventArgs e)
        {
            string processNameFull = e.NewEvent.Properties["ProcessName"].Value.ToString();
            string processName = Path.GetFileNameWithoutExtension(processNameFull);
            DateTime startTime = DateTime.Now;

            if (!Directory.Exists(_settings.ReportsPath)) Directory.CreateDirectory(_settings.ReportsPath);

            string filePath = Path.Combine(_settings.ReportsPath, "process_log.txt");
            string logLine = $"{startTime:yyyy-MM-dd HH:mm:ss} - {processNameFull}";

            if (_settings.Moderation && _settings.ForbiddenPrograms.Any(f => string.Equals(f, processName, StringComparison.OrdinalIgnoreCase)))
            {
                try
                {
                    foreach (var proc in Process.GetProcessesByName(processName)) proc.Kill();
                    logLine = $"{startTime:yyyy-MM-dd HH:mm:ss} - BLOCKED {processNameFull}";
                }
                catch (Exception ex) { logLine = $"{startTime:yyyy-MM-dd HH:mm:ss} - ERROR closing {processNameFull}: {ex.Message}"; }
            }

            File.AppendAllText(filePath, logLine + Environment.NewLine, Encoding.UTF8);
        }

        private void StartKeyboardHook()
        {
            _keyboardHook = new KeyboardHook();
            _keyboardHook.KeyPressed += key => _settings.LogKey(key);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _processStartWatcher?.Stop();
            _processStartWatcher?.Dispose();
            base.OnFormClosing(e);
        }

        
    }
}
