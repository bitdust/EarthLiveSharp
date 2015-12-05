using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EarthLiveSharp
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("iexplore.exe", "http://himawari8.nict.go.jp/");
        }

        private void button_settings_Click(object sender, EventArgs e)
        {
            settings f1 = new settings();
            f1.ShowDialog();
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(scraper.GetLatestAdress());
            //scraper.InitFolder();
            if (Cfg.source_select == "cdn")
            {
                scraper.pic_url = Cfg.cdn_addr;
            }
            else
            {
                scraper.pic_url = Cfg.orgin_addr;
            }
            button_start.Enabled = false;
            button_stop.Enabled = true;
            button_settings.Enabled = false;
            scraper.InitFolder();
            timer1.Interval = Cfg.interval * 1000 * 60;
            timer1.Start();
            scraper.UpdateImage();
            //pictureBox1.ImageLocation = @".\images\1.png";
        }

        private void button_stop_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            button_start.Enabled = true;
            button_stop.Enabled = false;
            button_settings.Enabled = true;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            scraper.UpdateImage();
        }

        private void Form2_Deactivate(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                this.Hide();
                notifyIcon1.ShowBalloonTip(1000, "", "EarthLive# is running", ToolTipIcon.Warning);
            }
        }
        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.ShowInTaskbar = true;
            this.WindowState = FormWindowState.Normal;
            this.BringToFront();
        }
    }
}
