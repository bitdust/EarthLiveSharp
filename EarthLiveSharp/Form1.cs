using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EarthLiveSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Cfg.load();
            if(Cfg.source_select=="orgin")
            {
                comboBox1.SelectedIndex = 0;
            }
            else
            {
                comboBox1.SelectedIndex = 1;
            }
            numericUpDown1.Value = Cfg.interval;
            numericUpDown2.Value = Cfg.max_number;
            checkBox1.Checked = Cfg.autostart;
        }

        private void button1_Click(object sender, EventArgs e)
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
            panel1.Enabled = false;
            button1.Enabled = false;
            button4.Enabled = true;
            scraper.InitFolder();
            timer1.Interval = Cfg.interval * 1000 * 60;
            timer1.Start();
            scraper.UpdateImage();
            //pictureBox1.ImageLocation = @".\images\1.png";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.ShowInTaskbar = true;
            this.WindowState = FormWindowState.Normal;
            this.BringToFront();
        }

        private void Form1_Deactivate(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                this.Hide();
                notifyIcon1.ShowBalloonTip(1000, "", "EarthLive# is running", ToolTipIcon.Warning);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            scraper.UpdateImage();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Cfg.source_select = comboBox1.Text;
            Cfg.interval = (int)(numericUpDown1.Value);
            Cfg.max_number = (int)(numericUpDown2.Value);
            Cfg.autostart = checkBox1.Checked;
            Cfg.commit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            panel1.Enabled = true;
            button1.Enabled = true;
            button4.Enabled = false;
        }

    }
}
