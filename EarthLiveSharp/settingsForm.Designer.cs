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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButton_Orgin = new System.Windows.Forms.RadioButton();
            this.radioButton_CDN = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.cloud_name = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.setwallpaper = new System.Windows.Forms.CheckBox();
            this.satellite = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.Save_Texture = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.image_zoom = new System.Windows.Forms.NumericUpDown();
            this.image_size = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.api_key = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.api_secret = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.Directory_Display = new System.Windows.Forms.Label();
            this.Selected_Directory = new System.Windows.Forms.Button();
            this.Save_Max_Count = new System.Windows.Forms.NumericUpDown();
            this.SaveMaxCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.interval)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.image_zoom)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Save_Max_Count)).BeginInit();
            this.SuspendLayout();
            // 
            // linkLabel1
            // 
            resources.ApplyResources(this.linkLabel1, "linkLabel1");
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.TabStop = true;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // button3
            // 
            resources.ApplyResources(this.button3, "button3");
            this.button3.Name = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // version_number
            // 
            resources.ApplyResources(this.version_number, "version_number");
            this.version_number.Name = "version_number";
            // 
            // button1
            // 
            resources.ApplyResources(this.button1, "button1");
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // autostart
            // 
            resources.ApplyResources(this.autostart, "autostart");
            this.autostart.Name = "autostart";
            this.autostart.UseVisualStyleBackColor = true;
            // 
            // interval
            // 
            resources.ApplyResources(this.interval, "interval");
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
            this.interval.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // radioButton_Orgin
            // 
            resources.ApplyResources(this.radioButton_Orgin, "radioButton_Orgin");
            this.radioButton_Orgin.Name = "radioButton_Orgin";
            this.radioButton_Orgin.TabStop = true;
            this.radioButton_Orgin.UseVisualStyleBackColor = true;
            this.radioButton_Orgin.CheckedChanged += new System.EventHandler(this.radioButton_Orgin_CheckedChanged);
            // 
            // radioButton_CDN
            // 
            resources.ApplyResources(this.radioButton_CDN, "radioButton_CDN");
            this.radioButton_CDN.Name = "radioButton_CDN";
            this.radioButton_CDN.TabStop = true;
            this.radioButton_CDN.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // cloud_name
            // 
            resources.ApplyResources(this.cloud_name, "cloud_name");
            this.cloud_name.Name = "cloud_name";
            // 
            // panel1
            // 
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.setwallpaper);
            this.panel1.Controls.Add(this.satellite);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.Save_Texture);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.image_zoom);
            this.panel1.Controls.Add(this.image_size);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.radioButton_CDN);
            this.panel1.Controls.Add(this.radioButton_Orgin);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.interval);
            this.panel1.Controls.Add(this.autostart);
            this.panel1.Name = "panel1";
            this.panel1.Tag = "";
            // 
            // setwallpaper
            // 
            resources.ApplyResources(this.setwallpaper, "setwallpaper");
            this.setwallpaper.Name = "setwallpaper";
            this.setwallpaper.UseVisualStyleBackColor = true;
            // 
            // satellite
            // 
            resources.ApplyResources(this.satellite, "satellite");
            this.satellite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.satellite.FormattingEnabled = true;
            this.satellite.Items.AddRange(new object[] {
            resources.GetString("satellite.Items"),
            resources.GetString("satellite.Items1")});
            this.satellite.Name = "satellite";
            this.satellite.SelectedIndexChanged += new System.EventHandler(this.satellite_SelectedIndexChanged);
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // Save_Texture
            // 
            resources.ApplyResources(this.Save_Texture, "Save_Texture");
            this.Save_Texture.Name = "Save_Texture";
            this.Save_Texture.UseVisualStyleBackColor = true;
            this.Save_Texture.CheckedChanged += new System.EventHandler(this.Save_Texture_CheckedChanged);
            // 
            // checkBox1
            // 
            resources.ApplyResources(this.checkBox1, "checkBox1");
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // image_zoom
            // 
            resources.ApplyResources(this.image_zoom, "image_zoom");
            this.image_zoom.Minimum = new decimal(new int[] {
            51,
            0,
            0,
            0});
            this.image_zoom.Name = "image_zoom";
            this.image_zoom.ReadOnly = true;
            this.image_zoom.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // image_size
            // 
            resources.ApplyResources(this.image_size, "image_size");
            this.image_size.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.image_size.FormattingEnabled = true;
            this.image_size.Items.AddRange(new object[] {
            resources.GetString("image_size.Items"),
            resources.GetString("image_size.Items1"),
            resources.GetString("image_size.Items2"),
            resources.GetString("image_size.Items3"),
            resources.GetString("image_size.Items4")});
            this.image_size.Name = "image_size";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // api_key
            // 
            resources.ApplyResources(this.api_key, "api_key");
            this.api_key.Name = "api_key";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // api_secret
            // 
            resources.ApplyResources(this.api_secret, "api_secret");
            this.api_secret.Name = "api_secret";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.linkLabel2);
            this.panel2.Controls.Add(this.api_secret);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.api_key);
            this.panel2.Controls.Add(this.cloud_name);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Name = "panel2";
            // 
            // linkLabel2
            // 
            resources.ApplyResources(this.linkLabel2, "linkLabel2");
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.TabStop = true;
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // panel3
            // 
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Controls.Add(this.Selected_Directory);
            this.panel3.Controls.Add(this.Save_Max_Count);
            this.panel3.Controls.Add(this.SaveMaxCount);
            this.panel3.Name = "panel3";
            // 
            // panel4
            // 
            resources.ApplyResources(this.panel4, "panel4");
            this.panel4.Controls.Add(this.Directory_Display);
            this.panel4.Name = "panel4";
            // 
            // Directory_Display
            // 
            resources.ApplyResources(this.Directory_Display, "Directory_Display");
            this.Directory_Display.Name = "Directory_Display";
            // 
            // Selected_Directory
            // 
            resources.ApplyResources(this.Selected_Directory, "Selected_Directory");
            this.Selected_Directory.Name = "Selected_Directory";
            this.Selected_Directory.UseVisualStyleBackColor = true;
            this.Selected_Directory.Click += new System.EventHandler(this.Selected_Directory_Click);
            // 
            // Save_Max_Count
            // 
            resources.ApplyResources(this.Save_Max_Count, "Save_Max_Count");
            this.Save_Max_Count.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.Save_Max_Count.Name = "Save_Max_Count";
            // 
            // SaveMaxCount
            // 
            resources.ApplyResources(this.SaveMaxCount, "SaveMaxCount");
            this.SaveMaxCount.Name = "SaveMaxCount";
            // 
            // settingsForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.version_number);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "settingsForm";
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.settingsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.interval)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.image_zoom)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Save_Max_Count)).EndInit();
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButton_Orgin;
        private System.Windows.Forms.RadioButton radioButton_CDN;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox cloud_name;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox image_size;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown image_zoom;
        private System.Windows.Forms.TextBox api_key;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox api_secret;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox satellite;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label SaveMaxCount;
        private System.Windows.Forms.CheckBox Save_Texture;
        private System.Windows.Forms.Label Directory_Display;
        private System.Windows.Forms.NumericUpDown Save_Max_Count;
        private System.Windows.Forms.Button Selected_Directory;
        private System.Windows.Forms.CheckBox setwallpaper;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.LinkLabel linkLabel2;
    }
}

