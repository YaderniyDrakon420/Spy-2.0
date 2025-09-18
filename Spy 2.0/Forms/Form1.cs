using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Spy_2._0.Models;
using Spy_2._0.Services;
using Spy_2._0.Hooks;

namespace Spy_2._0.Forms
{
    public partial class Form1 : Form
    {
        private KeyboardHook _keyboardHook;
        private AppSettings _settings;
        private ProcessWatcher _processWatcher;

        public Form1()
        {
            InitializeComponent();

            _settings = SettingsService.Load();
            ApplySettingsToUI();

            _keyboardHook = new KeyboardHook();
            _keyboardHook.KeyPressed += KeyboardHook_KeyPressed;

            _processWatcher = new ProcessWatcher(_settings);
            _processWatcher.Start();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _settings.ReportsPath = txtPath.Text.Trim();
            _settings.Statistics = chkStatistics.Checked;
            _settings.Moderation = chkModeration.Checked;
            _settings.ForbiddenWords = ForbiddenWords.Items.Cast<string>().ToList();
            _settings.ForbiddenPrograms = ForbiddenPrograms.Items.Cast<string>().ToList();

            SettingsService.Save(_settings);
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

        private void ApplySettingsToUI()
        {
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

        private void KeyboardHook_KeyPressed(string key)
        {
            string path = _settings.ReportsPath;
            if (string.IsNullOrWhiteSpace(path))
                path = Path.Combine(Application.StartupPath, "Reports");

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            string filePath = Path.Combine(path, "log.txt");
            File.AppendAllText(filePath, key, Encoding.UTF8);

            if (txtLog.InvokeRequired)
                txtLog.Invoke(new Action(() => txtLog.AppendText(key)));
            else
                txtLog.AppendText(key);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            _processWatcher.Stop();
            base.OnFormClosing(e);
        }
    }
}

