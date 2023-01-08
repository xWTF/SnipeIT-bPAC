namespace SnipeIT_bPAC
{
    partial class ServerForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_accesskey = new System.Windows.Forms.TextBox();
            this.textBox_template = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button_selectFile = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.textBox_log = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button_start = new System.Windows.Forms.Button();
            this.button_stop = new System.Windows.Forms.Button();
            this.numericUpDown_port = new System.Windows.Forms.NumericUpDown();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_port)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Access Key:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Template File:";
            // 
            // textBox_accesskey
            // 
            this.textBox_accesskey.Location = new System.Drawing.Point(106, 44);
            this.textBox_accesskey.Name = "textBox_accesskey";
            this.textBox_accesskey.PasswordChar = '*';
            this.textBox_accesskey.Size = new System.Drawing.Size(343, 23);
            this.textBox_accesskey.TabIndex = 2;
            this.textBox_accesskey.Leave += new System.EventHandler(this.SaveSettings);
            // 
            // textBox_template
            // 
            this.textBox_template.Location = new System.Drawing.Point(106, 75);
            this.textBox_template.Name = "textBox_template";
            this.textBox_template.Size = new System.Drawing.Size(318, 23);
            this.textBox_template.TabIndex = 3;
            this.textBox_template.Leave += new System.EventHandler(this.SaveSettings);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(455, 49);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 4;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button_selectFile
            // 
            this.button_selectFile.Location = new System.Drawing.Point(430, 75);
            this.button_selectFile.Name = "button_selectFile";
            this.button_selectFile.Size = new System.Drawing.Size(40, 23);
            this.button_selectFile.TabIndex = 5;
            this.button_selectFile.Text = "...";
            this.button_selectFile.UseVisualStyleBackColor = true;
            this.button_selectFile.Click += new System.EventHandler(this.button_selectFile_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "SnipeIT bPAC Daemon";
            this.notifyIcon1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseClick);
            // 
            // textBox_log
            // 
            this.textBox_log.Location = new System.Drawing.Point(12, 116);
            this.textBox_log.Multiline = true;
            this.textBox_log.Name = "textBox_log";
            this.textBox_log.ReadOnly = true;
            this.textBox_log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_log.Size = new System.Drawing.Size(458, 183);
            this.textBox_log.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Server Port:";
            // 
            // button_start
            // 
            this.button_start.Location = new System.Drawing.Point(314, 12);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(75, 23);
            this.button_start.TabIndex = 9;
            this.button_start.Text = "Start";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // button_stop
            // 
            this.button_stop.Enabled = false;
            this.button_stop.Location = new System.Drawing.Point(395, 12);
            this.button_stop.Name = "button_stop";
            this.button_stop.Size = new System.Drawing.Size(75, 23);
            this.button_stop.TabIndex = 10;
            this.button_stop.Text = "Stop";
            this.button_stop.UseVisualStyleBackColor = true;
            this.button_stop.Click += new System.EventHandler(this.button_stop_Click);
            // 
            // numericUpDown_port
            // 
            this.numericUpDown_port.Location = new System.Drawing.Point(106, 12);
            this.numericUpDown_port.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDown_port.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_port.Name = "numericUpDown_port";
            this.numericUpDown_port.Size = new System.Drawing.Size(202, 23);
            this.numericUpDown_port.TabIndex = 11;
            this.numericUpDown_port.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_port.ValueChanged += new System.EventHandler(this.SaveSettings);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(235, 302);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(235, 17);
            this.linkLabel1.TabIndex = 12;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "https://github.com/xWTF/SnipeIT-bPAC";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 328);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.numericUpDown_port);
            this.Controls.Add(this.button_stop);
            this.Controls.Add(this.button_start);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_log);
            this.Controls.Add(this.button_selectFile);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.textBox_template);
            this.Controls.Add(this.textBox_accesskey);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ServerForm";
            this.Text = "Snipe-IT bPAC Daemon";
            this.Load += new System.EventHandler(this.ServerForm_Load);
            this.SizeChanged += new System.EventHandler(this.ServerForm_SizeChanged);
            this.VisibleChanged += new System.EventHandler(this.ServerForm_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_port)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBox_accesskey;
        private TextBox textBox_template;
        private CheckBox checkBox1;
        private Button button_selectFile;
        private NotifyIcon notifyIcon1;
        private TextBox textBox_log;
        private Label label3;
        private Button button_start;
        private Button button_stop;
        private NumericUpDown numericUpDown_port;
        private LinkLabel linkLabel1;
    }
}