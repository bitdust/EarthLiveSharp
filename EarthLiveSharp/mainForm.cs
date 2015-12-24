using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace EarthLiveSharp
{
    // It's a terrible mistake to mix the UI and business logic together.
    public partial class mainForm : Form
    {
        bool serviceRunning = false;
        MenuItem startService = new MenuItem("Start Service");
        MenuItem stopService = new MenuItem("Stop Service");
        MenuItem settingsMenu = new MenuItem("Settings");
        MenuItem quitService = new MenuItem("Quit");
        ContextMenu trayMenu = new ContextMenu();

        public mainForm()
        {
            InitializeComponent();
            createContextMenu();
            notifyIcon1.ContextMenu = trayMenu;
        }
        private void createContextMenu()
        {
            this.trayMenu.MenuItems.Add(startService);
            this.trayMenu.MenuItems.Add(stopService);
            this.trayMenu.MenuItems.Add(settingsMenu);
            this.trayMenu.MenuItems.Add(quitService);
            startService.Click += new EventHandler(this.startService_Click);
            stopService.Click += new EventHandler(this.stopService_Click);
            settingsMenu.Click += new EventHandler(this.settingsMenu_Click);
            quitService.Click += new EventHandler(this.quitService_Click);

            contextMenuSetter();
        }

        private void startService_Click(object sender, EventArgs e)
        {
            startLogic();
        }
        private void stopService_Click(object sender, EventArgs e)
        {
            stopLogic();
        }
        private void settingsMenu_Click(object sender, EventArgs e)
        {
            settingsForm f1 = new settingsForm();
            f1.ShowDialog();
        }
        private void quitService_Click(object sender, EventArgs e)
        {
            var confirmIfQuitting = MessageBox.Show("Are you sure you want to quit?","Stopping Service", MessageBoxButtons.YesNo);
            if (confirmIfQuitting == DialogResult.Yes)
            {
                stopLogic();
                System.Windows.Forms.Application.Exit();
            }

        }


        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("iexplore.exe", "http://himawari8.nict.go.jp/");
        }

        private void button_settings_Click(object sender, EventArgs e)
        {
            settingsForm f1 = new settingsForm();
            f1.ShowDialog();
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            startLogic();
        }

        private void button_stop_Click(object sender, EventArgs e)
        {
            stopLogic();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            Random rd = new Random();
            int selector = rd.Next(1, 5);
            switch (selector)
            {
                case 1: scraper.pic_url = Cfg.cdn1_addr; break;
                case 2: scraper.pic_url = Cfg.cdn2_addr; break;
                case 3: scraper.pic_url = Cfg.cdn3_addr; break;
                case 4: scraper.pic_url = Cfg.cdn4_addr; break;
                default: scraper.pic_url = Cfg.cdn1_addr; break;
            }
            scraper.UpdateImage();
            if (Cfg.display_mode == 0)
            {
                // Wallpaper.SetDefaultStyle();
                if (scraper.saved_path.Length > 0)
                {
                    Wallpaper.Set(scraper.saved_path);
                }             
            }
            else if (Cfg.display_mode == 1)
            {
                if (scraper.saved_path.Length > 0)
                {
                    Wallpaper.Set(scraper.saved_path);
                }
            }
            else if (Cfg.display_mode == 2)
            {
                //
            }
        }

        private void Form2_Deactivate(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                this.Hide();
                if (!Cfg.autostart)
                {
                    notifyIcon1.ShowBalloonTip(1000, "", "EarthLive# is running", ToolTipIcon.Warning);
                }
            }
        }


        

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.ShowInTaskbar = true;
            this.WindowState = FormWindowState.Normal;
            this.BringToFront();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            button_stop.Enabled = false;
            if (Cfg.autostart)
            {
                button_start.PerformClick();
                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("iexplore.exe", "https://github.com/bitdust/EarthLiveSharp/issues/3");
        }

        //All logic pertaining to stopping the service
        private void stopLogic()
        {
            if (serviceRunning)
            {
                //notifyIcon1.ShowBalloonTip(200, "", "EarthLive# Service Stopped", ToolTipIcon.Warning);
                timer1.Stop();
                button_start.Enabled = true;
                button_stop.Enabled = false;
                button_settings.Enabled = true;
                runningLabel.Text = "Not Running";
                runningLabel.ForeColor = Color.DarkRed;
                serviceRunning = false;
            }
            else if (!serviceRunning) MessageBox.Show("Service is not currently running");
            contextMenuSetter();
        }

        //All logic pertaining to starting the service
        private void startLogic()
        {
            if (!serviceRunning)
            {
                //notifyIcon1.ShowBalloonTip(200, "", "EarthLive# Service Started", ToolTipIcon.Warning);
                Cfg.Load();
                if (Cfg.source_select == "cdn")
                {
                    Random rd = new Random();
                    int selector = rd.Next(1, 5);
                    switch (selector)
                    {
                        case 1: scraper.pic_url = Cfg.cdn1_addr; break;
                        case 2: scraper.pic_url = Cfg.cdn2_addr; break;
                        case 3: scraper.pic_url = Cfg.cdn3_addr; break;
                        case 4: scraper.pic_url = Cfg.cdn4_addr; break;
                        default: scraper.pic_url = Cfg.cdn1_addr; break;
                    }
                }
                else
                {
                    scraper.pic_url = Cfg.origin_addr;
                }
                //scraper.image_folder = Cfg.image_folder;
                scraper.image_folder = Application.StartupPath + @"\images";
                scraper.max_number = Cfg.max_number;
                button_start.Enabled = false;
                button_stop.Enabled = true;
                button_settings.Enabled = false;
                scraper.InitFolder();
                scraper.UpdateImage();
                timer1.Interval = Cfg.interval * 1000 * 60;
                timer1.Start();

                switch (Cfg.display_mode)
                {
                    case 0:
                        Wallpaper.SetDefaultStyle();
                        if (scraper.saved_path.Length > 0) Wallpaper.Set(scraper.saved_path);
                        break;
                    case 1:
                        if (scraper.saved_path.Length > 0) Wallpaper.Set(scraper.saved_path);
                        break;
                    case 2:
                        break;
                    default:
                        break;
                };
                serviceRunning = true;
                runningLabel.Text = "    Running";
                runningLabel.ForeColor = Color.DarkGreen;

            }
            else if (serviceRunning) MessageBox.Show("Service already running");
            contextMenuSetter();
        }

        //checks if service running and changes context menu based on result.
        private void contextMenuSetter()
        {
            if (serviceRunning)
            {
                startService.Enabled = false;
                stopService.Enabled = true;
            }

            if (!serviceRunning)
            {
                stopService.Enabled = false;
                startService.Enabled = true;
            }
        }

    }
}
