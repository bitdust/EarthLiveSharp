namespace EarthLiveSharp
{
    partial class settingsForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(settingsForm));
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.button3 = new System.Windows.Forms.Button();
            this.version_number = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.autostart = new System.Windows.Forms.CheckBox();
            this.interval = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButton_Orgin = new System.Windows.Forms.RadioButton();
            this.radioButton_CDN = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.cloud_name = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.image_size = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.interval)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(63, 224);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(111, 15);
            this.linkLabel1.TabIndex = 7;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "check upgrade";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(200, 212);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 29);
            this.button3.TabIndex = 6;
            this.button3.Text = "Apply";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // version_number
            // 
            this.version_number.AutoSize = true;
            this.version_number.Location = new System.Drawing.Point(13, 224);
            this.version_number.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.version_number.Name = "version_number";
            this.version_number.Size = new System.Drawing.Size(39, 15);
            this.version_number.TabIndex = 12;
            this.version_number.Text = "v0.0";
            this.version_number.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(308, 212);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 29);
            this.button1.TabIndex = 14;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // autostart
            // 
            this.autostart.AutoSize = true;
            this.autostart.Location = new System.Drawing.Point(220, 81);
            this.autostart.Margin = new System.Windows.Forms.Padding(4);
            this.autostart.Name = "autostart";
            this.autostart.Size = new System.Drawing.Size(18, 17);
            this.autostart.TabIndex = 5;
            this.autostart.UseVisualStyleBackColor = true;
            // 
            // interval
            // 
            this.interval.Location = new System.Drawing.Point(220, 47);
            this.interval.Margin = new System.Windows.Forms.Padding(4);
            this.interval.Maximum = new decimal(new int[] {
            120,
            0,
            0,
            0});
            this.interval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.interval.Name = "interval";
            this.interval.ReadOnly = true;
            this.interval.Size = new System.Drawing.Size(131, 25);
            this.interval.TabIndex = 2;
            this.interval.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(133, 80);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Autostart";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 49);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(207, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Update Interval (minutes)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(109, 110);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Image Source";
            // 
            // radioButton_Orgin
            // 
            this.radioButton_Orgin.AutoSize = true;
            this.radioButton_Orgin.Location = new System.Drawing.Point(220, 107);
            this.radioButton_Orgin.Name = "radioButton_Orgin";
            this.radioButton_Orgin.Size = new System.Drawing.Size(68, 19);
            this.radioButton_Orgin.TabIndex = 8;
            this.radioButton_Orgin.TabStop = true;
            this.radioButton_Orgin.Text = "Orgin";
            this.radioButton_Orgin.UseVisualStyleBackColor = true;
            this.radioButton_Orgin.CheckedChanged += new System.EventHandler(this.radioButton_Orgin_CheckedChanged);
            // 
            // radioButton_CDN
            // 
            this.radioButton_CDN.AutoSize = true;
            this.radioButton_CDN.Location = new System.Drawing.Point(220, 132);
            this.radioButton_CDN.Name = "radioButton_CDN";
            this.radioButton_CDN.Size = new System.Drawing.Size(172, 19);
            this.radioButton_CDN.TabIndex = 8;
            this.radioButton_CDN.TabStop = true;
            this.radioButton_CDN.Text = "CDN (recommended!)";
            this.radioButton_CDN.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(125, 158);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "Cloud Name";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label4.Visible = false;
            // 
            // cloud_name
            // 
            this.cloud_name.Location = new System.Drawing.Point(220, 155);
            this.cloud_name.Name = "cloud_name";
            this.cloud_name.Size = new System.Drawing.Size(131, 25);
            this.cloud_name.TabIndex = 10;
            this.cloud_name.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.image_size);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cloud_name);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.radioButton_CDN);
            this.panel1.Controls.Add(this.radioButton_Orgin);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.interval);
            this.panel1.Controls.Add(this.autostart);
            this.panel1.Location = new System.Drawing.Point(16, 15);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(391, 189);
            this.panel1.TabIndex = 11;
            this.panel1.Tag = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(53, 12);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(159, 15);
            this.label5.TabIndex = 12;
            this.label5.Text = "Image Size (pixels)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // image_size
            // 
            this.image_size.FormattingEnabled = true;
            this.image_size.Items.AddRange(new object[] {
            "550*550",
            "1100*1100",
            "2200*2200",
            "4400*4400",
            "8800*8800"});
            this.image_size.Location = new System.Drawing.Point(219, 9);
            this.image_size.Name = "image_size";
            this.image_size.Size = new System.Drawing.Size(132, 23);
            this.image_size.TabIndex = 13;
            // 
            // settingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 250);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.version_number);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "settingsForm";
            this.ShowInTaskbar = false;
            this.Text = "settings";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.settingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.interval)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label version_number;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox autostart;
        private System.Windows.Forms.NumericUpDown interval;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButton_Orgin;
        private System.Windows.Forms.RadioButton radioButton_CDN;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox cloud_name;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox image_size;
    }
}

