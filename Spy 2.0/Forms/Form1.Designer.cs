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
            SuspendLayout();
            // 
            // txtPath
            // 
            txtPath.Location = new Point(12, 12);
            txtPath.Name = "txtPath";
            txtPath.Size = new Size(560, 27);
            txtPath.TabIndex = 0;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(578, 10);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(183, 50);
            btnSave.TabIndex = 1;
            btnSave.Text = "Сохранить";
            btnSave.Click += btnSave_Click;
            // 
            // chkStatistics
            // 
            chkStatistics.Location = new Point(31, 44);
            chkStatistics.Name = "chkStatistics";
            chkStatistics.Size = new Size(140, 51);
            chkStatistics.TabIndex = 2;
            chkStatistics.Text = "Статистика";
            // 
            // chkModeration
            // 
            chkModeration.Location = new Point(224, 45);
            chkModeration.Name = "chkModeration";
            chkModeration.Size = new Size(141, 50);
            chkModeration.TabIndex = 3;
            chkModeration.Text = "Модерация";
            // 
            // ForbiddenWords
            // 
            ForbiddenWords.Location = new Point(31, 166);
            ForbiddenWords.Name = "ForbiddenWords";
            ForbiddenWords.Size = new Size(281, 244);
            ForbiddenWords.TabIndex = 4;
            // 
            // txtNewWord
            // 
            txtNewWord.Location = new Point(31, 425);
            txtNewWord.Name = "txtNewWord";
            txtNewWord.Size = new Size(220, 27);
            txtNewWord.TabIndex = 5;
            // 
            // btnAddWord
            // 
            btnAddWord.Location = new Point(257, 425);
            btnAddWord.Name = "btnAddWord";
            btnAddWord.Size = new Size(74, 26);
            btnAddWord.TabIndex = 6;
            btnAddWord.Text = "Добавить";
            btnAddWord.Click += btnAddWord_Click;
            // 
            // btnRemoveWord
            // 
            btnRemoveWord.Location = new Point(31, 472);
            btnRemoveWord.Name = "btnRemoveWord";
            btnRemoveWord.Size = new Size(300, 26);
            btnRemoveWord.TabIndex = 7;
            btnRemoveWord.Text = "Удалить выбранное слово";
            btnRemoveWord.Click += btnRemoveWord_Click;
            // 
            // ForbiddenPrograms
            // 
            ForbiddenPrograms.Location = new Point(368, 166);
            ForbiddenPrograms.Name = "ForbiddenPrograms";
            ForbiddenPrograms.Size = new Size(304, 244);
            ForbiddenPrograms.TabIndex = 8;
            // 
            // txtNewProgram
            // 
            txtNewProgram.Location = new Point(368, 424);
            txtNewProgram.Name = "txtNewProgram";
            txtNewProgram.Size = new Size(220, 27);
            txtNewProgram.TabIndex = 9;
            // 
            // btnAddProgram
            // 
            btnAddProgram.Location = new Point(594, 424);
            btnAddProgram.Name = "btnAddProgram";
            btnAddProgram.Size = new Size(118, 26);
            btnAddProgram.TabIndex = 10;
            btnAddProgram.Text = "Добавить программу";
            btnAddProgram.Click += btnAddProgram_Click;
            // 
            // btnRemoveProgram
            // 
            btnRemoveProgram.Location = new Point(368, 472);
            btnRemoveProgram.Name = "btnRemoveProgram";
            btnRemoveProgram.Size = new Size(344, 26);
            btnRemoveProgram.TabIndex = 11;
            btnRemoveProgram.Text = "Удалить выбранную программу";
            btnRemoveProgram.Click += btnRemoveProgram_Click;
            // 
            // btnViewLog
            // 
            btnViewLog.Location = new Point(749, 345);
            btnViewLog.Name = "btnViewLog";
            btnViewLog.Size = new Size(367, 65);
            btnViewLog.TabIndex = 12;
            btnViewLog.Text = "Просмотр log.txt";
            btnViewLog.Click += btnViewLog_Click;
            // 
            // btnViewProcesses
            // 
            btnViewProcesses.Location = new Point(749, 166);
            btnViewProcesses.Name = "btnViewProcesses";
            btnViewProcesses.Size = new Size(367, 66);
            btnViewProcesses.TabIndex = 13;
            btnViewProcesses.Text = "Просмотр process_log.txt";
            btnViewProcesses.Click += btnViewProcesses_Click;
            // 
            // Form1
            // 
            ClientSize = new Size(1150, 563);
            Controls.Add(txtPath);
            Controls.Add(btnSave);
            Controls.Add(chkStatistics);
            Controls.Add(chkModeration);
            Controls.Add(ForbiddenWords);
            Controls.Add(txtNewWord);
            Controls.Add(btnAddWord);
            Controls.Add(btnRemoveWord);
            Controls.Add(ForbiddenPrograms);
            Controls.Add(txtNewProgram);
            Controls.Add(btnAddProgram);
            Controls.Add(btnRemoveProgram);
            Controls.Add(btnViewLog);
            Controls.Add(btnViewProcesses);
            Name = "Form1";
            Text = "Spy_2._0";
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
