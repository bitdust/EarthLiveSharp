using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace EarthLiveSharp
{
    public partial class mainForm : Form
    {
        bool serviceRunning = false;
        MenuItem startService = new MenuItem("Start Service");
        MenuItem stopService = new MenuItem("Stop Service");
        MenuItem settingsMenu = new MenuItem("Settings");
        MenuItem quitService = new MenuItem("Quit");
        ContextMenu trayMenu = new ContextMenu();

        System.Timers.Timer timer1 = new System.Timers.Timer(); // timer to update image
        System.Timers.Timer timer2 = new System.Timers.Timer(); // timer to clean CDN cach

        public mainForm()
        {
            InitializeComponent();
            createContextMenu();
            notifyIcon1.ContextMenu = trayMenu;
            InitializeTimers();
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
        private void InitializeTimers()
        {
            timer1.Elapsed += new System.Timers.ElapsedEventHandler(timer1_Tick);
            timer1.AutoReset = true;
            timer1.Enabled = false;
            timer2.Elapsed += new System.Timers.ElapsedEventHandler(timer2_Tick);
            timer2.AutoReset = true;
            timer2.Interval = 3600000;
            timer2.Enabled = true;
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
                Application.Exit();
            }

        }


        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://himawari8.nict.go.jp/");
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
            timer1.Enabled = false; // simple way to prevent timer conflict, but it works.
            try
            {
                timer1.Interval = Cfg.interval * 1000 * 60; // set the interval
                System.Threading.Thread.Sleep(3000); // wait 3 secs for Internet reconnection after system resume.
                Scrap_wrapper.UpdateImage();
                if (Cfg.setwallpaper)
                    Wallpaper.Set(Cfg.image_folder + "\\wallpaper.bmp");
            }
            finally
            {
                timer1.Enabled = true;
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

        //All logic pertaining to stopping the service
        private void stopLogic()
        {
            if (serviceRunning)
            {
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
            Scrap_wrapper.ResetState();
            if (!serviceRunning)
            {
                button_start.Enabled = false;
                button_stop.Enabled = true;
                button_settings.Enabled = false;
                timer1.Interval = 5000; // trick to trigger timer immediately.
                timer1.Start();
                serviceRunning = true;
                runningLabel.Text = "    Running";
                runningLabel.ForeColor = Color.DarkGreen;
            }
            else
            {
                MessageBox.Show("Service already running");
            }
            contextMenuSetter();
        }

        //checks if service running and changes context menu based on result.
        private void contextMenuSetter()
        {
            if (serviceRunning)
            {
                startService.Enabled = false;
                settingsMenu.Enabled = false;
                stopService.Enabled = true;
            }

            if (!serviceRunning)
            {
                stopService.Enabled = false;
                settingsMenu.Enabled = true;
                startService.Enabled = true;
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (Cfg.source_selection != 0)
                Scrap_wrapper.CleanCDN();
        }

    }
}
