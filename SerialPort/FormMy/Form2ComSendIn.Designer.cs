namespace SerialPortC
{
    partial class Form2ComSendIn
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tBoxDataIN = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbDataINLength = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblDataOutLength = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnClearData = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tBoxDataOut = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tStComBox_appendOrOverwriteText = new System.Windows.Forms.ToolStripComboBox();
            this.tStComboBox_writeLineOweriteText = new System.Windows.Forms.ToolStripComboBox();
            this.saveMySQLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showDataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.voltAmpetrToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.закрытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comPortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.splitContainer1);
            this.groupBox1.Controls.Add(this.menuStrip1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(436, 326);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(332, 19);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(98, 17);
            this.checkBox1.TabIndex = 11;
            this.checkBox1.Text = "симулятор ЗУ";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(2, 39);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tBoxDataIN);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(432, 285);
            this.splitContainer1.SplitterDistance = 162;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 10;
            // 
            // tBoxDataIN
            // 
            this.tBoxDataIN.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.tBoxDataIN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tBoxDataIN.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tBoxDataIN.ForeColor = System.Drawing.Color.Lime;
            this.tBoxDataIN.Location = new System.Drawing.Point(0, 0);
            this.tBoxDataIN.Margin = new System.Windows.Forms.Padding(2);
            this.tBoxDataIN.Multiline = true;
            this.tBoxDataIN.Name = "tBoxDataIN";
            this.tBoxDataIN.ReadOnly = true;
            this.tBoxDataIN.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tBoxDataIN.Size = new System.Drawing.Size(432, 162);
            this.tBoxDataIN.TabIndex = 9;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.lbDataINLength);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.lblDataOutLength);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.btnSend);
            this.groupBox3.Controls.Add(this.btnClearData);
            this.groupBox3.Location = new System.Drawing.Point(6, 81);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(422, 37);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            // 
            // lbDataINLength
            // 
            this.lbDataINLength.AutoSize = true;
            this.lbDataINLength.Location = new System.Drawing.Point(228, 16);
            this.lbDataINLength.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbDataINLength.Name = "lbDataINLength";
            this.lbDataINLength.Size = new System.Drawing.Size(19, 13);
            this.lbDataINLength.TabIndex = 12;
            this.lbDataINLength.Text = "00";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(206, 16);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "IN:";
            // 
            // lblDataOutLength
            // 
            this.lblDataOutLength.AutoSize = true;
            this.lblDataOutLength.Location = new System.Drawing.Point(177, 16);
            this.lblDataOutLength.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDataOutLength.Name = "lblDataOutLength";
            this.lblDataOutLength.Size = new System.Drawing.Size(19, 13);
            this.lblDataOutLength.TabIndex = 10;
            this.lblDataOutLength.Text = "00";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 16);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(166, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Колличество символов    OUT: ";
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(253, 0);
            this.btnSend.Margin = new System.Windows.Forms.Padding(2);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(84, 46);
            this.btnSend.TabIndex = 6;
            this.btnSend.Text = "Отправить";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnClearData
            // 
            this.btnClearData.Location = new System.Drawing.Point(341, 0);
            this.btnClearData.Margin = new System.Windows.Forms.Padding(2);
            this.btnClearData.Name = "btnClearData";
            this.btnClearData.Size = new System.Drawing.Size(81, 46);
            this.btnClearData.TabIndex = 7;
            this.btnClearData.Text = "Очистить";
            this.btnClearData.UseVisualStyleBackColor = true;
            this.btnClearData.Click += new System.EventHandler(this.btnClearData_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tBoxDataOut);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(432, 60);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Отправить";
            // 
            // tBoxDataOut
            // 
            this.tBoxDataOut.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.tBoxDataOut.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tBoxDataOut.Font = new System.Drawing.Font("Calibri", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tBoxDataOut.ForeColor = System.Drawing.Color.Aquamarine;
            this.tBoxDataOut.Location = new System.Drawing.Point(2, 15);
            this.tBoxDataOut.Margin = new System.Windows.Forms.Padding(2);
            this.tBoxDataOut.Multiline = true;
            this.tBoxDataOut.Name = "tBoxDataOut";
            this.tBoxDataOut.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tBoxDataOut.Size = new System.Drawing.Size(428, 43);
            this.tBoxDataOut.TabIndex = 5;
            this.tBoxDataOut.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tBoxDataOut_KeyUp);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.настройкиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(2, 15);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(432, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.сохранитьToolStripMenuItem,
            this.saveMySQLToolStripMenuItem,
            this.voltAmpetrToolStripMenuItem,
            this.toolStripSeparator1,
            this.закрытьToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Checked = true;
            this.сохранитьToolStripMenuItem.CheckOnClick = true;
            this.сохранитьToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.сохранитьToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tStComBox_appendOrOverwriteText,
            this.tStComboBox_writeLineOweriteText});
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.сохранитьToolStripMenuItem.Text = "Сохранить";
            // 
            // tStComBox_appendOrOverwriteText
            // 
            this.tStComBox_appendOrOverwriteText.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tStComBox_appendOrOverwriteText.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.tStComBox_appendOrOverwriteText.Items.AddRange(new object[] {
            "Append Text",
            "Overwrite Text"});
            this.tStComBox_appendOrOverwriteText.Name = "tStComBox_appendOrOverwriteText";
            this.tStComBox_appendOrOverwriteText.Size = new System.Drawing.Size(121, 23);
            // 
            // tStComboBox_writeLineOweriteText
            // 
            this.tStComboBox_writeLineOweriteText.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tStComboBox_writeLineOweriteText.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.tStComboBox_writeLineOweriteText.Items.AddRange(new object[] {
            "WriteLine",
            "Write"});
            this.tStComboBox_writeLineOweriteText.Name = "tStComboBox_writeLineOweriteText";
            this.tStComboBox_writeLineOweriteText.Size = new System.Drawing.Size(121, 23);
            // 
            // saveMySQLToolStripMenuItem
            // 
            this.saveMySQLToolStripMenuItem.Checked = true;
            this.saveMySQLToolStripMenuItem.CheckOnClick = true;
            this.saveMySQLToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.saveMySQLToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showDataToolStripMenuItem});
            this.saveMySQLToolStripMenuItem.Name = "saveMySQLToolStripMenuItem";
            this.saveMySQLToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.saveMySQLToolStripMenuItem.Text = "Save MySQL";
            // 
            // showDataToolStripMenuItem
            // 
            this.showDataToolStripMenuItem.Name = "showDataToolStripMenuItem";
            this.showDataToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.showDataToolStripMenuItem.Text = "Show Data";
            this.showDataToolStripMenuItem.Click += new System.EventHandler(this.showDataToolStripMenuItem_Click);
            // 
            // voltAmpetrToolStripMenuItem
            // 
            this.voltAmpetrToolStripMenuItem.Name = "voltAmpetrToolStripMenuItem";
            this.voltAmpetrToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.voltAmpetrToolStripMenuItem.Text = "VoltAmpetr";
            this.voltAmpetrToolStripMenuItem.Click += new System.EventHandler(this.voltAmpetrToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(136, 6);
            // 
            // закрытьToolStripMenuItem
            // 
            this.закрытьToolStripMenuItem.Name = "закрытьToolStripMenuItem";
            this.закрытьToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.закрытьToolStripMenuItem.Text = "Закрыть";
            this.закрытьToolStripMenuItem.Click += new System.EventHandler(this.закрытьToolStripMenuItem_Click);
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.comPortToolStripMenuItem});
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            // 
            // comPortToolStripMenuItem
            // 
            this.comPortToolStripMenuItem.Name = "comPortToolStripMenuItem";
            this.comPortToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.comPortToolStripMenuItem.Text = "ComPort";
            this.comPortToolStripMenuItem.Click += new System.EventHandler(this.comPortToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form2ComSendIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(436, 326);
            this.Controls.Add(this.groupBox1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(79, 48);
            this.Name = "Form2ComSendIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Терминал";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem закрытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comPortToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox tBoxDataIN;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tBoxDataOut;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnClearData;
        private System.Windows.Forms.Label lbDataINLength;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblDataOutLength;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox tStComBox_appendOrOverwriteText;
        private System.Windows.Forms.ToolStripComboBox tStComboBox_writeLineOweriteText;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem showDataToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem saveMySQLToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.ToolStripMenuItem voltAmpetrToolStripMenuItem;
        private System.Windows.Forms.Timer timer1;
    }
}