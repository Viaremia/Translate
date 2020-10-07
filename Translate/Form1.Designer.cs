namespace Translate
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBoxLeft = new System.Windows.Forms.RichTextBox();
            this.richTextBoxRight = new System.Windows.Forms.RichTextBox();
            this.button = new System.Windows.Forms.Button();
            this.comboBoxLeft = new System.Windows.Forms.ComboBox();
            this.comboBoxRight = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.errorsFixToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBoxLeft
            // 
            this.richTextBoxLeft.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxLeft.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBoxLeft.Location = new System.Drawing.Point(12, 70);
            this.richTextBoxLeft.Name = "richTextBoxLeft";
            this.richTextBoxLeft.Size = new System.Drawing.Size(425, 331);
            this.richTextBoxLeft.TabIndex = 0;
            this.richTextBoxLeft.Text = "";
            this.richTextBoxLeft.TextChanged += new System.EventHandler(this.LeftText_Chenge);
            // 
            // richTextBoxRight
            // 
            this.richTextBoxRight.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxRight.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.richTextBoxRight.Location = new System.Drawing.Point(448, 70);
            this.richTextBoxRight.Name = "richTextBoxRight";
            this.richTextBoxRight.Size = new System.Drawing.Size(425, 331);
            this.richTextBoxRight.TabIndex = 1;
            this.richTextBoxRight.Text = "";
            // 
            // button
            // 
            this.button.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button.Location = new System.Drawing.Point(12, 407);
            this.button.Name = "button";
            this.button.Size = new System.Drawing.Size(861, 42);
            this.button.TabIndex = 2;
            this.button.Text = "Transale";
            this.button.UseVisualStyleBackColor = false;
            this.button.Click += new System.EventHandler(this.ButtonTrst_Click);
            // 
            // comboBoxLeft
            // 
            this.comboBoxLeft.FormattingEnabled = true;
            this.comboBoxLeft.Items.AddRange(new object[] {
            "English",
            "Russian"});
            this.comboBoxLeft.Location = new System.Drawing.Point(187, 43);
            this.comboBoxLeft.Name = "comboBoxLeft";
            this.comboBoxLeft.Size = new System.Drawing.Size(250, 21);
            this.comboBoxLeft.TabIndex = 3;
            this.comboBoxLeft.Text = "Russian";
            this.comboBoxLeft.SelectedIndexChanged += new System.EventHandler(this.CmbBoxLeft_Change);
            // 
            // comboBoxRight
            // 
            this.comboBoxRight.FormattingEnabled = true;
            this.comboBoxRight.Items.AddRange(new object[] {
            "English",
            "Russian"});
            this.comboBoxRight.Location = new System.Drawing.Point(623, 43);
            this.comboBoxRight.Name = "comboBoxRight";
            this.comboBoxRight.Size = new System.Drawing.Size(250, 21);
            this.comboBoxRight.TabIndex = 4;
            this.comboBoxRight.Text = "English";
            this.comboBoxRight.SelectedIndexChanged += new System.EventHandler(this.CmbBoxRight_Change);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(884, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.errorsFixToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // errorsFixToolStripMenuItem
            // 
            this.errorsFixToolStripMenuItem.Name = "errorsFixToolStripMenuItem";
            this.errorsFixToolStripMenuItem.Size = new System.Drawing.Size(120, 22);
            this.errorsFixToolStripMenuItem.Text = "Errors fix";
            this.errorsFixToolStripMenuItem.Click += new System.EventHandler(this.ErrorsFix_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(884, 461);
            this.Controls.Add(this.comboBoxRight);
            this.Controls.Add(this.comboBoxLeft);
            this.Controls.Add(this.button);
            this.Controls.Add(this.richTextBoxRight);
            this.Controls.Add(this.richTextBoxLeft);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Translate";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormClose);
            this.TextChanged += new System.EventHandler(this.LeftText_Chenge);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxLeft;
        private System.Windows.Forms.RichTextBox richTextBoxRight;
        private System.Windows.Forms.Button button;
        private System.Windows.Forms.ComboBox comboBoxLeft;
        private System.Windows.Forms.ComboBox comboBoxRight;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem errorsFixToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

