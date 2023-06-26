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
            components = new System.ComponentModel.Container();
            label1 = new Label();
            label2 = new Label();
            textBox_accesskey = new TextBox();
            textBox_template = new TextBox();
            checkBox1 = new CheckBox();
            button_selectFile = new Button();
            notifyIcon1 = new NotifyIcon(components);
            textBox_log = new TextBox();
            label3 = new Label();
            button_start = new Button();
            button_stop = new Button();
            numericUpDown_port = new NumericUpDown();
            linkLabel1 = new LinkLabel();
            label_mode = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDown_port).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 47);
            label1.Name = "label1";
            label1.Size = new Size(75, 17);
            label1.TabIndex = 0;
            label1.Text = "Access Key:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 78);
            label2.Name = "label2";
            label2.Size = new Size(88, 17);
            label2.TabIndex = 1;
            label2.Text = "Template File:";
            // 
            // textBox_accesskey
            // 
            textBox_accesskey.Location = new Point(106, 44);
            textBox_accesskey.Name = "textBox_accesskey";
            textBox_accesskey.PasswordChar = '*';
            textBox_accesskey.Size = new Size(343, 23);
            textBox_accesskey.TabIndex = 2;
            textBox_accesskey.Leave += SaveSettings;
            // 
            // textBox_template
            // 
            textBox_template.Location = new Point(106, 75);
            textBox_template.Name = "textBox_template";
            textBox_template.Size = new Size(318, 23);
            textBox_template.TabIndex = 3;
            textBox_template.Leave += SaveSettings;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(455, 49);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(15, 14);
            checkBox1.TabIndex = 4;
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // button_selectFile
            // 
            button_selectFile.Location = new Point(430, 75);
            button_selectFile.Name = "button_selectFile";
            button_selectFile.Size = new Size(40, 23);
            button_selectFile.TabIndex = 5;
            button_selectFile.Text = "...";
            button_selectFile.UseVisualStyleBackColor = true;
            button_selectFile.Click += button_selectFile_Click;
            // 
            // notifyIcon1
            // 
            notifyIcon1.Text = "SnipeIT bPAC Daemon";
            notifyIcon1.MouseClick += notifyIcon1_MouseClick;
            // 
            // textBox_log
            // 
            textBox_log.Location = new Point(12, 116);
            textBox_log.Multiline = true;
            textBox_log.Name = "textBox_log";
            textBox_log.ReadOnly = true;
            textBox_log.ScrollBars = ScrollBars.Vertical;
            textBox_log.Size = new Size(458, 183);
            textBox_log.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 15);
            label3.Name = "label3";
            label3.Size = new Size(76, 17);
            label3.TabIndex = 7;
            label3.Text = "Server Port:";
            // 
            // button_start
            // 
            button_start.Location = new Point(314, 12);
            button_start.Name = "button_start";
            button_start.Size = new Size(75, 23);
            button_start.TabIndex = 9;
            button_start.Text = "Start";
            button_start.UseVisualStyleBackColor = true;
            button_start.Click += button_start_Click;
            // 
            // button_stop
            // 
            button_stop.Enabled = false;
            button_stop.Location = new Point(395, 12);
            button_stop.Name = "button_stop";
            button_stop.Size = new Size(75, 23);
            button_stop.TabIndex = 10;
            button_stop.Text = "Stop";
            button_stop.UseVisualStyleBackColor = true;
            button_stop.Click += button_stop_Click;
            // 
            // numericUpDown_port
            // 
            numericUpDown_port.Location = new Point(106, 12);
            numericUpDown_port.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            numericUpDown_port.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown_port.Name = "numericUpDown_port";
            numericUpDown_port.Size = new Size(202, 23);
            numericUpDown_port.TabIndex = 11;
            numericUpDown_port.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown_port.ValueChanged += SaveSettings;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(235, 302);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(235, 17);
            linkLabel1.TabIndex = 12;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "https://github.com/xWTF/SnipeIT-bPAC";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // label_mode
            // 
            label_mode.AutoSize = true;
            label_mode.Font = new Font("Microsoft YaHei UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label_mode.Location = new Point(12, 302);
            label_mode.Name = "label_mode";
            label_mode.Size = new Size(57, 17);
            label_mode.TabIndex = 13;
            label_mode.Text = "[MODE]";
            // 
            // ServerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(482, 328);
            Controls.Add(label_mode);
            Controls.Add(linkLabel1);
            Controls.Add(numericUpDown_port);
            Controls.Add(button_stop);
            Controls.Add(button_start);
            Controls.Add(label3);
            Controls.Add(textBox_log);
            Controls.Add(button_selectFile);
            Controls.Add(checkBox1);
            Controls.Add(textBox_template);
            Controls.Add(textBox_accesskey);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "ServerForm";
            Text = "Snipe-IT bPAC Daemon";
            Load += ServerForm_Load;
            SizeChanged += ServerForm_SizeChanged;
            VisibleChanged += ServerForm_VisibleChanged;
            ((System.ComponentModel.ISupportInitialize)numericUpDown_port).EndInit();
            ResumeLayout(false);
            PerformLayout();
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
        private Label label_mode;
    }
}