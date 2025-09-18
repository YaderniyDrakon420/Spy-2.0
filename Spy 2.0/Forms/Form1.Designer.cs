using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Spy_2._0.Forms
{
    partial class Form1
    {
        private IContainer components = null;
        private TextBox txtPath;
        private Button btnSave;
        private CheckBox chkStatistics;
        private CheckBox chkModeration;
        private ListBox ForbiddenWords;
        private TextBox txtNewWord;
        private Button btnAddWord;
        private Button btnRemoveWord;
        private ListBox ForbiddenPrograms;
        private TextBox txtNewProgram;
        private Button btnAddProgram;
        private Button btnRemoveProgram;
        private Button btnViewLog;
        private Button btnViewProcesses;
        private Button btnViewJson;
        private Button btnRefreshLog;
        private Button btnClearLog;
        private Button btnRefreshProcessLog;
        private Button btnClearProcessLog;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            txtPath = new TextBox();
            btnSave = new Button();
            chkStatistics = new CheckBox();
            chkModeration = new CheckBox();
            ForbiddenWords = new ListBox();
            txtNewWord = new TextBox();
            btnAddWord = new Button();
            btnRemoveWord = new Button();
            ForbiddenPrograms = new ListBox();
            txtNewProgram = new TextBox();
            btnAddProgram = new Button();
            btnRemoveProgram = new Button();
            btnViewLog = new Button();
            btnViewProcesses = new Button();
            btnViewJson = new Button();
            btnRefreshLog = new Button();
            btnClearLog = new Button();
            btnRefreshProcessLog = new Button();
            btnClearProcessLog = new Button();

            SuspendLayout();

            txtPath.Location = new Point(12, 12);
            txtPath.Size = new Size(560, 27);

            btnSave.Location = new Point(578, 10);
            btnSave.Size = new Size(183, 50);
            btnSave.Text = "Сохранить";
            btnSave.Click += btnSave_Click;

            chkStatistics.Location = new Point(31, 44);
            chkStatistics.Size = new Size(140, 51);
            chkStatistics.Text = "Статистика";

            chkModeration.Location = new Point(224, 45);
            chkModeration.Size = new Size(141, 50);
            chkModeration.Text = "Модерація";

            ForbiddenWords.Location = new Point(31, 166);
            ForbiddenWords.Size = new Size(281, 244);

            txtNewWord.Location = new Point(31, 425);
            txtNewWord.Size = new Size(220, 27);

            btnAddWord.Location = new Point(257, 425);
            btnAddWord.Size = new Size(74, 26);
            btnAddWord.Text = "Добавить";
            btnAddWord.Click += btnAddWord_Click;

            btnRemoveWord.Location = new Point(31, 472);
            btnRemoveWord.Size = new Size(300, 26);
            btnRemoveWord.Text = "Удалить выбранное слово";
            btnRemoveWord.Click += btnRemoveWord_Click;

            ForbiddenPrograms.Location = new Point(368, 166);
            ForbiddenPrograms.Size = new Size(304, 244);

            txtNewProgram.Location = new Point(368, 424);
            txtNewProgram.Size = new Size(220, 27);

            btnAddProgram.Location = new Point(594, 424);
            btnAddProgram.Size = new Size(118, 26);
            btnAddProgram.Text = "Добавить программу";
            btnAddProgram.Click += btnAddProgram_Click;

            btnRemoveProgram.Location = new Point(368, 472);
            btnRemoveProgram.Size = new Size(344, 26);
            btnRemoveProgram.Text = "Удалить выбранную программу";
            btnRemoveProgram.Click += btnRemoveProgram_Click;

            btnViewLog.Location = new Point(749, 345);
            btnViewLog.Size = new Size(367, 65);
            btnViewLog.Text = "Просмотр log.txt";
            btnViewLog.Click += btnViewLog_Click;

            btnViewProcesses.Location = new Point(749, 166);
            btnViewProcesses.Size = new Size(367, 66);
            btnViewProcesses.Text = "Просмотр process_log.txt";
            btnViewProcesses.Click += btnViewProcesses_Click;

            btnViewJson.Location = new Point(749, 250);
            btnViewJson.Size = new Size(367, 66);
            btnViewJson.Text = "Просмотр settings.json";
            btnViewJson.Click += btnViewJson_Click;

            btnRefreshLog.Location = new Point(749, 430);
            btnRefreshLog.Size = new Size(180, 40);
            btnRefreshLog.Text = "Оновити звіт";
            btnRefreshLog.Click += btnRefreshLog_Click;

            btnClearLog.Location = new Point(936, 430);
            btnClearLog.Size = new Size(180, 40);
            btnClearLog.Text = "Очистити звіт";
            btnClearLog.Click += btnClearLog_Click;

            btnRefreshProcessLog.Location = new Point(749, 480);
            btnRefreshProcessLog.Size = new Size(180, 40);
            btnRefreshProcessLog.Text = "Оновити звіт процесів";
            btnRefreshProcessLog.Click += btnRefreshProcessLog_Click;

            btnClearProcessLog.Location = new Point(936, 480);
            btnClearProcessLog.Size = new Size(180, 40);
            btnClearProcessLog.Text = "Очистити звіт процесів";
            btnClearProcessLog.Click += btnClearProcessLog_Click;

            ClientSize = new Size(1150, 563);
            Controls.AddRange(new Control[]
            {
                txtPath, btnSave, chkStatistics, chkModeration, ForbiddenWords, txtNewWord,
                btnAddWord, btnRemoveWord, ForbiddenPrograms, txtNewProgram, btnAddProgram,
                btnRemoveProgram, btnViewLog, btnViewProcesses, btnViewJson,
                btnRefreshLog, btnClearLog, btnRefreshProcessLog, btnClearProcessLog
            });

            Text = "Spy_2._0";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}

