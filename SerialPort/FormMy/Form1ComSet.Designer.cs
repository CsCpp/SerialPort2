namespace SerialPortC
{
    partial class Form1ComSet
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
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chBoxWriteLine = new System.Windows.Forms.CheckBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.chBoxRtsEnable = new System.Windows.Forms.CheckBox();
            this.chBoxDtrEnable = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cBoxPARITYBITS = new System.Windows.Forms.ComboBox();
            this.cBoxSTOPBITS = new System.Windows.Forms.ComboBox();
            this.cBoxDATABITS = new System.Windows.Forms.ComboBox();
            this.cBoxBAUDRATE = new System.Windows.Forms.ComboBox();
            this.cBoxCOMPORT = new System.Windows.Forms.ComboBox();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mySQLSETToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cOMОткрытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cOMЗакрытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.очиститьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.инфаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chBoxWriteLine);
            this.groupBox1.Controls.Add(this.btnOpen);
            this.groupBox1.Controls.Add(this.chBoxRtsEnable);
            this.groupBox1.Controls.Add(this.chBoxDtrEnable);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.cBoxPARITYBITS);
            this.groupBox1.Controls.Add(this.cBoxSTOPBITS);
            this.groupBox1.Controls.Add(this.cBoxDATABITS);
            this.groupBox1.Controls.Add(this.cBoxBAUDRATE);
            this.groupBox1.Controls.Add(this.cBoxCOMPORT);
            this.groupBox1.Location = new System.Drawing.Point(10, 37);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(170, 237);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Настройки SerialPorts";
            // 
            // chBoxWriteLine
            // 
            this.chBoxWriteLine.AutoSize = true;
            this.chBoxWriteLine.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chBoxWriteLine.Location = new System.Drawing.Point(100, 154);
            this.chBoxWriteLine.Margin = new System.Windows.Forms.Padding(2);
            this.chBoxWriteLine.Name = "chBoxWriteLine";
            this.chBoxWriteLine.Size = new System.Drawing.Size(72, 17);
            this.chBoxWriteLine.TabIndex = 12;
            this.chBoxWriteLine.Text = "Write Line";
            this.chBoxWriteLine.UseVisualStyleBackColor = true;
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(8, 188);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(2);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(158, 41);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Text = "Открыть";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // chBoxRtsEnable
            // 
            this.chBoxRtsEnable.AutoSize = true;
            this.chBoxRtsEnable.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chBoxRtsEnable.Location = new System.Drawing.Point(51, 154);
            this.chBoxRtsEnable.Margin = new System.Windows.Forms.Padding(2);
            this.chBoxRtsEnable.Name = "chBoxRtsEnable";
            this.chBoxRtsEnable.Size = new System.Drawing.Size(48, 17);
            this.chBoxRtsEnable.TabIndex = 11;
            this.chBoxRtsEnable.Text = "RTS ";
            this.chBoxRtsEnable.UseVisualStyleBackColor = true;
            this.chBoxRtsEnable.CheckedChanged += new System.EventHandler(this.chBoxRtsEnable_CheckedChanged);
            // 
            // chBoxDtrEnable
            // 
            this.chBoxDtrEnable.AutoSize = true;
            this.chBoxDtrEnable.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chBoxDtrEnable.Location = new System.Drawing.Point(6, 154);
            this.chBoxDtrEnable.Margin = new System.Windows.Forms.Padding(2);
            this.chBoxDtrEnable.Name = "chBoxDtrEnable";
            this.chBoxDtrEnable.Size = new System.Drawing.Size(46, 17);
            this.chBoxDtrEnable.TabIndex = 10;
            this.chBoxDtrEnable.Text = "DTR";
            this.chBoxDtrEnable.UseVisualStyleBackColor = true;
            this.chBoxDtrEnable.CheckedChanged += new System.EventHandler(this.chBoxDtrEnable_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 121);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "PARITY BITS";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 97);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "STOP BITS";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 72);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "DATA BITS";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 48);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "BAUD RATE";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "PORT NAME";
            // 
            // cBoxPARITYBITS
            // 
            this.cBoxPARITYBITS.FormattingEnabled = true;
            this.cBoxPARITYBITS.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even"});
            this.cBoxPARITYBITS.Location = new System.Drawing.Point(92, 115);
            this.cBoxPARITYBITS.Margin = new System.Windows.Forms.Padding(2);
            this.cBoxPARITYBITS.Name = "cBoxPARITYBITS";
            this.cBoxPARITYBITS.Size = new System.Drawing.Size(60, 21);
            this.cBoxPARITYBITS.TabIndex = 4;
            this.cBoxPARITYBITS.Text = "None";
            // 
            // cBoxSTOPBITS
            // 
            this.cBoxSTOPBITS.FormattingEnabled = true;
            this.cBoxSTOPBITS.Items.AddRange(new object[] {
            "One",
            "Two"});
            this.cBoxSTOPBITS.Location = new System.Drawing.Point(92, 90);
            this.cBoxSTOPBITS.Margin = new System.Windows.Forms.Padding(2);
            this.cBoxSTOPBITS.Name = "cBoxSTOPBITS";
            this.cBoxSTOPBITS.Size = new System.Drawing.Size(60, 21);
            this.cBoxSTOPBITS.TabIndex = 3;
            this.cBoxSTOPBITS.Text = "One";
            // 
            // cBoxDATABITS
            // 
            this.cBoxDATABITS.FormattingEnabled = true;
            this.cBoxDATABITS.Items.AddRange(new object[] {
            "6",
            "7",
            "8"});
            this.cBoxDATABITS.Location = new System.Drawing.Point(92, 66);
            this.cBoxDATABITS.Margin = new System.Windows.Forms.Padding(2);
            this.cBoxDATABITS.Name = "cBoxDATABITS";
            this.cBoxDATABITS.Size = new System.Drawing.Size(60, 21);
            this.cBoxDATABITS.TabIndex = 2;
            this.cBoxDATABITS.Text = "8";
            // 
            // cBoxBAUDRATE
            // 
            this.cBoxBAUDRATE.AutoCompleteCustomSource.AddRange(new string[] {
            "2400",
            "4800",
            "9600"});
            this.cBoxBAUDRATE.FormattingEnabled = true;
            this.cBoxBAUDRATE.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200",
            "128000"});
            this.cBoxBAUDRATE.Location = new System.Drawing.Point(92, 41);
            this.cBoxBAUDRATE.Margin = new System.Windows.Forms.Padding(2);
            this.cBoxBAUDRATE.Name = "cBoxBAUDRATE";
            this.cBoxBAUDRATE.Size = new System.Drawing.Size(60, 21);
            this.cBoxBAUDRATE.TabIndex = 1;
            this.cBoxBAUDRATE.Text = "9600";
            // 
            // cBoxCOMPORT
            // 
            this.cBoxCOMPORT.FormattingEnabled = true;
            this.cBoxCOMPORT.Location = new System.Drawing.Point(92, 17);
            this.cBoxCOMPORT.Margin = new System.Windows.Forms.Padding(2);
            this.cBoxCOMPORT.Name = "cBoxCOMPORT";
            this.cBoxCOMPORT.Size = new System.Drawing.Size(60, 21);
            this.cBoxCOMPORT.TabIndex = 0;
            this.cBoxCOMPORT.SelectedIndexChanged += new System.EventHandler(this.cBoxCOMPORT_SelectedIndexChanged);
            // 
            // serialPort
            // 
            this.serialPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort_DataReceived);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.настройкиToolStripMenuItem,
            this.инфаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(184, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(109, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // настройкиToolStripMenuItem
            // 
            this.настройкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mySQLSETToolStripMenuItem,
            this.cOMОткрытьToolStripMenuItem,
            this.cOMЗакрытьToolStripMenuItem,
            this.очиститьToolStripMenuItem});
            this.настройкиToolStripMenuItem.Name = "настройкиToolStripMenuItem";
            this.настройкиToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.настройкиToolStripMenuItem.Text = "Настройки";
            // 
            // mySQLSETToolStripMenuItem
            // 
            this.mySQLSETToolStripMenuItem.Name = "mySQLSETToolStripMenuItem";
            this.mySQLSETToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.mySQLSETToolStripMenuItem.Text = "MySQL SET";
            this.mySQLSETToolStripMenuItem.Click += new System.EventHandler(this.mySQLSETToolStripMenuItem_Click);
            // 
            // cOMОткрытьToolStripMenuItem
            // 
            this.cOMОткрытьToolStripMenuItem.Name = "cOMОткрытьToolStripMenuItem";
            this.cOMОткрытьToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cOMОткрытьToolStripMenuItem.Text = "COM открыть";
            this.cOMОткрытьToolStripMenuItem.Click += new System.EventHandler(this.cOMОткрытьToolStripMenuItem_Click);
            // 
            // cOMЗакрытьToolStripMenuItem
            // 
            this.cOMЗакрытьToolStripMenuItem.Name = "cOMЗакрытьToolStripMenuItem";
            this.cOMЗакрытьToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cOMЗакрытьToolStripMenuItem.Text = "COM Закрыть";
            this.cOMЗакрытьToolStripMenuItem.Click += new System.EventHandler(this.cOMЗакрытьToolStripMenuItem_Click);
            // 
            // очиститьToolStripMenuItem
            // 
            this.очиститьToolStripMenuItem.Name = "очиститьToolStripMenuItem";
            this.очиститьToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.очиститьToolStripMenuItem.Text = "Очистить";
            // 
            // инфаToolStripMenuItem
            // 
            this.инфаToolStripMenuItem.Name = "инфаToolStripMenuItem";
            this.инфаToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.инфаToolStripMenuItem.Text = "Инфа";
            // 
            // Form1ComSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(184, 326);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1ComSet";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "COM Port терминал";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cBoxCOMPORT;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cBoxPARITYBITS;
        private System.Windows.Forms.ComboBox cBoxSTOPBITS;
        private System.Windows.Forms.ComboBox cBoxDATABITS;
        private System.Windows.Forms.ComboBox cBoxBAUDRATE;
        private System.Windows.Forms.Button btnOpen;
        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.CheckBox chBoxRtsEnable;
        private System.Windows.Forms.CheckBox chBoxDtrEnable;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cOMОткрытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cOMЗакрытьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem инфаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem очиститьToolStripMenuItem;
        private System.Windows.Forms.CheckBox chBoxWriteLine;
        private System.Windows.Forms.ToolStripMenuItem mySQLSETToolStripMenuItem;
    }
}

