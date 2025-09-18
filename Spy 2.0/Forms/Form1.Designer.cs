using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Spy_2._0.Forms
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Метод, необходимый для поддержки конструктора форм.
        /// Не редактировать содержимое этого метода вручную.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new Container();
            this.txtPath = new TextBox();
            this.btnSave = new Button();
            this.chkStatistics = new CheckBox();
            this.chkModeration = new CheckBox();
            this.ForbiddenWords = new ListBox();
            this.txtNewWord = new TextBox();
            this.btnAddWord = new Button();
            this.btnRemoveWord = new Button();
            this.ForbiddenPrograms = new ListBox();
            this.txtNewProgram = new TextBox();
            this.btnAddProgram = new Button();
            this.btnRemoveProgram = new Button();
            this.txtLog = new TextBox();

            this.SuspendLayout();

            // txtPath
            this.txtPath.Location = new Point(12, 12);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new Size(560, 23);
            this.txtPath.TabIndex = 0;

            // btnSave
            this.btnSave.Location = new Point(578, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new Size(94, 26);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new EventHandler(this.btnSave_Click);

            // chkStatistics
            this.chkStatistics.AutoSize = true;
            this.chkStatistics.Location = new Point(12, 44);
            this.chkStatistics.Name = "chkStatistics";
            this.chkStatistics.Size = new Size(84, 19);
            this.chkStatistics.TabIndex = 2;
            this.chkStatistics.Text = "Статистика";
            this.chkStatistics.UseVisualStyleBackColor = true;

            // chkModeration
            this.chkModeration.AutoSize = true;
            this.chkModeration.Location = new Point(110, 44);
            this.chkModeration.Name = "chkModeration";
            this.chkModeration.Size = new Size(87, 19);
            this.chkModeration.TabIndex = 3;
            this.chkModeration.Text = "Модерация";
            this.chkModeration.UseVisualStyleBackColor = true;

            // ForbiddenWords
            this.ForbiddenWords.FormattingEnabled = true;
            this.ForbiddenWords.ItemHeight = 15;
            this.ForbiddenWords.Location = new Point(12, 80);
            this.ForbiddenWords.Name = "ForbiddenWords";
            this.ForbiddenWords.Size = new Size(300, 124);
            this.ForbiddenWords.TabIndex = 4;

            // txtNewWord
            this.txtNewWord.Location = new Point(12, 210);
            this.txtNewWord.Name = "txtNewWord";
            this.txtNewWord.Size = new Size(220, 23);
            this.txtNewWord.TabIndex = 5;

            // btnAddWord
            this.btnAddWord.Location = new Point(238, 208);
            this.btnAddWord.Name = "btnAddWord";
            this.btnAddWord.Size = new Size(74, 26);
            this.btnAddWord.TabIndex = 6;
            this.btnAddWord.Text = "Добавить";
            this.btnAddWord.UseVisualStyleBackColor = true;
            this.btnAddWord.Click += new EventHandler(this.btnAddWord_Click);

            // btnRemoveWord
            this.btnRemoveWord.Location = new Point(12, 240);
            this.btnRemoveWord.Name = "btnRemoveWord";
            this.btnRemoveWord.Size = new Size(300, 26);
            this.btnRemoveWord.TabIndex = 7;
            this.btnRemoveWord.Text = "Удалить выбранное слово";
            this.btnRemoveWord.UseVisualStyleBackColor = true;
            this.btnRemoveWord.Click += new EventHandler(this.btnRemoveWord_Click);

            // ForbiddenPrograms
            this.ForbiddenPrograms.FormattingEnabled = true;
            this.ForbiddenPrograms.ItemHeight = 15;
            this.ForbiddenPrograms.Location = new Point(328, 80);
            this.ForbiddenPrograms.Name = "ForbiddenPrograms";
            this.ForbiddenPrograms.Size = new Size(344, 124);
            this.ForbiddenPrograms.TabIndex = 8;

            // txtNewProgram
            this.txtNewProgram.Location = new Point(328, 210);
            this.txtNewProgram.Name = "txtNewProgram";
            this.txtNewProgram.Size = new Size(220, 23);
            this.txtNewProgram.TabIndex = 9;

            // btnAddProgram
            this.btnAddProgram.Location = new Point(554, 208);
            this.btnAddProgram.Name = "btnAddProgram";
            this.btnAddProgram.Size = new Size(118, 26);
            this.btnAddProgram.TabIndex = 10;
            this.btnAddProgram.Text = "Добавить программу";
            this.btnAddProgram.UseVisualStyleBackColor = true;
            this.btnAddProgram.Click += new EventHandler(this.btnAddProgram_Click);

            // btnRemoveProgram
            this.btnRemoveProgram.Location = new Point(328, 240);
            this.btnRemoveProgram.Name = "btnRemoveProgram";
            this.btnRemoveProgram.Size = new Size(344, 26);
            this.btnRemoveProgram.TabIndex = 11;
            this.btnRemoveProgram.Text = "Удалить выбранную программу";
            this.btnRemoveProgram.UseVisualStyleBackColor = true;
            this.btnRemoveProgram.Click += new EventHandler(this.btnRemoveProgram_Click);

            // txtLog
            this.txtLog.Location = new Point(12, 280);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = ScrollBars.Vertical;
            this.txtLog.Size = new Size(660, 150);
            this.txtLog.TabIndex = 12;

            // Form1
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(684, 441);
            this.Controls.Add(this.txtLog);
            this.Controls.Add(this.btnRemoveProgram);
            this.Controls.Add(this.btnAddProgram);
            this.Controls.Add(this.txtNewProgram);
            this.Controls.Add(this.ForbiddenPrograms);
            this.Controls.Add(this.btnRemoveWord);
            this.Controls.Add(this.btnAddWord);
            this.Controls.Add(this.txtNewWord);
            this.Controls.Add(this.ForbiddenWords);
            this.Controls.Add(this.chkModeration);
            this.Controls.Add(this.chkStatistics);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtPath);
            this.Name = "Form1";
            this.Text = "Spy_2._0";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        // Fields (controls)
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
        private TextBox txtLog;
    }
}
