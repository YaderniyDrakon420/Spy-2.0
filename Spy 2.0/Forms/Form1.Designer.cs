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
        private Button btnOpenTextInput;

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
            btnOpenTextInput = new Button();
            label1 = new Label();
            SuspendLayout();
            // 
            // txtPath
            // 
            txtPath.Location = new Point(153, 12);
            txtPath.Name = "txtPath";
            txtPath.Size = new Size(1089, 27);
            txtPath.TabIndex = 0;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.LimeGreen;
            btnSave.Font = new Font("Segoe UI Symbol", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSave.Location = new Point(433, 490);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(452, 91);
            btnSave.TabIndex = 1;
            btnSave.Text = "Зберегти";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // chkStatistics
            // 
            chkStatistics.Location = new Point(910, 540);
            chkStatistics.Name = "chkStatistics";
            chkStatistics.Size = new Size(114, 25);
            chkStatistics.TabIndex = 2;
            chkStatistics.Text = "Статистика";
            // 
            // chkModeration
            // 
            chkModeration.Location = new Point(910, 490);
            chkModeration.Name = "chkModeration";
            chkModeration.Size = new Size(122, 34);
            chkModeration.TabIndex = 3;
            chkModeration.Text = "Модерацiя";
            // 
            // ForbiddenWords
            // 
            ForbiddenWords.BackColor = SystemColors.GradientActiveCaption;
            ForbiddenWords.Location = new Point(213, 45);
            ForbiddenWords.Name = "ForbiddenWords";
            ForbiddenWords.Size = new Size(327, 244);
            ForbiddenWords.TabIndex = 4;
            // 
            // txtNewWord
            // 
            txtNewWord.Location = new Point(210, 335);
            txtNewWord.Name = "txtNewWord";
            txtNewWord.Size = new Size(203, 27);
            txtNewWord.TabIndex = 5;
            // 
            // btnAddWord
            // 
            btnAddWord.Location = new Point(432, 315);
            btnAddWord.Name = "btnAddWord";
            btnAddWord.Size = new Size(105, 63);
            btnAddWord.TabIndex = 6;
            btnAddWord.Text = "Додати слово";
            // 
            // btnRemoveWord
            // 
            btnRemoveWord.BackColor = Color.Firebrick;
            btnRemoveWord.Font = new Font("Segoe UI Symbol", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRemoveWord.Location = new Point(210, 394);
            btnRemoveWord.Name = "btnRemoveWord";
            btnRemoveWord.Size = new Size(327, 61);
            btnRemoveWord.TabIndex = 7;
            btnRemoveWord.Text = "Видалити обране слово";
            btnRemoveWord.UseVisualStyleBackColor = false;
            // 
            // ForbiddenPrograms
            // 
            ForbiddenPrograms.BackColor = SystemColors.GradientActiveCaption;
            ForbiddenPrograms.Location = new Point(722, 45);
            ForbiddenPrograms.Name = "ForbiddenPrograms";
            ForbiddenPrograms.Size = new Size(327, 244);
            ForbiddenPrograms.TabIndex = 8;
            // 
            // txtNewProgram
            // 
            txtNewProgram.Location = new Point(722, 335);
            txtNewProgram.Name = "txtNewProgram";
            txtNewProgram.Size = new Size(163, 27);
            txtNewProgram.TabIndex = 9;
            // 
            // btnAddProgram
            // 
            btnAddProgram.Location = new Point(910, 315);
            btnAddProgram.Name = "btnAddProgram";
            btnAddProgram.Size = new Size(139, 60);
            btnAddProgram.TabIndex = 10;
            btnAddProgram.Text = "Додати програму";
            // 
            // btnRemoveProgram
            // 
            btnRemoveProgram.BackColor = Color.Firebrick;
            btnRemoveProgram.Font = new Font("Segoe UI Symbol", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnRemoveProgram.Location = new Point(722, 394);
            btnRemoveProgram.Name = "btnRemoveProgram";
            btnRemoveProgram.Size = new Size(327, 65);
            btnRemoveProgram.TabIndex = 11;
            btnRemoveProgram.Text = "Видалити обрану програму";
            btnRemoveProgram.UseVisualStyleBackColor = false;
            // 
            // btnViewLog
            // 
            btnViewLog.Location = new Point(26, 60);
            btnViewLog.Name = "btnViewLog";
            btnViewLog.Size = new Size(178, 50);
            btnViewLog.TabIndex = 12;
            btnViewLog.Text = "Перегляд звiту";
            // 
            // btnViewProcesses
            // 
            btnViewProcesses.Location = new Point(1055, 45);
            btnViewProcesses.Name = "btnViewProcesses";
            btnViewProcesses.Size = new Size(200, 50);
            btnViewProcesses.TabIndex = 13;
            btnViewProcesses.Text = "Перегляд запущених програм";
            // 
            // btnViewJson
            // 
            btnViewJson.BackColor = Color.Coral;
            btnViewJson.Font = new Font("Segoe UI Symbol", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnViewJson.Location = new Point(1058, 515);
            btnViewJson.Name = "btnViewJson";
            btnViewJson.Size = new Size(200, 50);
            btnViewJson.TabIndex = 14;
            btnViewJson.Text = "Перегляд settings.json";
            btnViewJson.UseVisualStyleBackColor = false;
            // 
            // btnRefreshLog
            // 
            btnRefreshLog.Location = new Point(26, 213);
            btnRefreshLog.Name = "btnRefreshLog";
            btnRefreshLog.Size = new Size(176, 48);
            btnRefreshLog.TabIndex = 15;
            btnRefreshLog.Text = "Оновити звiт";
            // 
            // btnClearLog
            // 
            btnClearLog.Location = new Point(26, 137);
            btnClearLog.Name = "btnClearLog";
            btnClearLog.Size = new Size(176, 50);
            btnClearLog.TabIndex = 16;
            btnClearLog.Text = "Очистити звiт";
            // 
            // btnOpenTextInput
            // 
            btnOpenTextInput.BackColor = SystemColors.MenuHighlight;
            btnOpenTextInput.Font = new Font("Segoe UI Symbol", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnOpenTextInput.Location = new Point(213, 461);
            btnOpenTextInput.Name = "btnOpenTextInput";
            btnOpenTextInput.Size = new Size(200, 80);
            btnOpenTextInput.TabIndex = 17;
            btnOpenTextInput.Text = "Перевiрка заборонених слiв";
            btnOpenTextInput.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(73, 15);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 18;
            label1.Text = "Шлях ";
            // 
            // Form1
            // 
            ClientSize = new Size(1270, 678);
            Controls.Add(label1);
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
            Controls.Add(btnViewJson);
            Controls.Add(btnRefreshLog);
            Controls.Add(btnClearLog);
            Controls.Add(btnOpenTextInput);
            Name = "Form1";
            Text = "Spy_2._0";
            ResumeLayout(false);
            PerformLayout();
        }
        private Label label1;
    }
}
