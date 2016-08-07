using System;
using System.Windows.Forms;

namespace EarthLiveSharp
{
    public partial class settingsForm : Form
    {
        public settingsForm()
        {
            InitializeComponent();
            Cfg.Load();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Cfg.interval = (int)(interval.Value);
            Cfg.autostart = autostart.Checked;
            if (radioButton_CDN.Checked)
            {
                Cfg.source_selection = 1;
                Cfg.cloud_name = cloud_name.Text;
                Cfg.image_source = "http://res.cloudinary.com/" + Cfg.cloud_name + "/image/fetch/http://himawari8-dl.nict.go.jp/himawari8/img/D531106";
            }
            else
            {
                Cfg.source_selection = 0;
                Cfg.image_source = "http://himawari8-dl.nict.go.jp/himawari8/img/D531106";
            }
            switch (image_size.SelectedIndex)
            {
                case 0: Cfg.size = 1; break;
                case 1: Cfg.size = 2; break;
                case 3: Cfg.size = 4; break;
                case 4: Cfg.size = 8; break;
                case 5: Cfg.size = 16; break;
                default: Cfg.size = 1; break;
            }
            Cfg.Save();
            Autostart.Set(Cfg.autostart);
        }

        private void button_select_folder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.Desktop;
            folderBrowserDialog1.SelectedPath = Cfg.image_folder;
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                Cfg.image_folder = folderBrowserDialog1.SelectedPath;
            };
            folderBrowserDialog1.Dispose();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("iexplore.exe", "https://github.com/bitdust/EarthLiveSharp/releases");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("iexplore.exe", "https://github.com/bitdust/EarthLiveSharp/issues/2");
        }

        private void settingsForm_Load(object sender, EventArgs e)
        {
            Cfg.Load();
            version_number.Text = Cfg.version;
            cloud_name.Text = Cfg.cloud_name;
            autostart.Checked = Cfg.autostart;
            interval.Value = Cfg.interval;
            if (Cfg.source_selection == 1)
            {
                radioButton_CDN.Checked = true;
                label4.Visible = true;
                cloud_name.Visible = true;
            }
            else
            {
                radioButton_Orgin.Checked = true;
                label4.Visible = false;
                cloud_name.Visible = false;
            }

            switch (Cfg.size)
            {
                case 1: image_size.SelectedIndex = 0; break;
                case 2: image_size.SelectedIndex = 1; break;
                case 4: image_size.SelectedIndex = 2; break;
                case 8: image_size.SelectedIndex = 3; break;
                case 16: image_size.SelectedIndex = 4; break;
                default: image_size.SelectedIndex = 0; break;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cfg.interval = (int)(interval.Value);
            Cfg.autostart = autostart.Checked;     
            if (radioButton_CDN.Checked)
            {
                Cfg.source_selection = 1;
                Cfg.cloud_name = cloud_name.Text;
                Cfg.image_source = "http://res.cloudinary.com/"+ Cfg.cloud_name + "/image/fetch/http://himawari8-dl.nict.go.jp/himawari8/img/D531106";
            }
            else
            {
                Cfg.source_selection = 0;
                Cfg.image_source = "http://himawari8-dl.nict.go.jp/himawari8/img/D531106";
            }
            switch (image_size.SelectedIndex)
            {
                case 0: Cfg.size = 1; break;
                case 1: Cfg.size = 2; break;
                case 3: Cfg.size = 4; break;
                case 4: Cfg.size = 8; break;
                case 5: Cfg.size = 16; break;
                default: Cfg.size = 1; break;
            }
            Cfg.Save();
            Autostart.Set(Cfg.autostart);
            this.Close();
        }

        private void radioButton_Orgin_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton_CDN.Checked)
            {
                label4.Visible = true;
                cloud_name.Visible = true;
            }
            else
            {
                label4.Visible = false;
                cloud_name.Visible = false;
            }
        }
    }
}
