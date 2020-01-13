using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private CancellationTokenSource _cancelSource;
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
            startService.Click += new EventHandler(this.StartService_Click);
            stopService.Click += new EventHandler(this.stopService_Click);
            settingsMenu.Click += new EventHandler(this.settingsMenu_Click);
            quitService.Click += new EventHandler(this.quitService_Click);

            contextMenuSetter();
        }

        private async void StartService_Click(object sender, EventArgs e)
        {
            Scrap_wrapper.ResetState();
            button_start.Enabled = false;
            button_stop.Enabled = true;
            button_settings.Enabled = false;
            timer1.Interval = Cfg.interval * 1000 * 60;
            timer1.Start();
            runningLabel.Text = "    Running";
            runningLabel.ForeColor = Color.DarkGreen;
            _cancelSource = new CancellationTokenSource();
            if (!serviceRunning)
            {
                serviceRunning = true;
                await StartLogic(_cancelSource);
                contextMenuSetter();
            }
            else
            {
                MessageBox.Show("Service already running");
            }
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

        private async void button_start_Click(object sender, EventArgs e)
        {
            Scrap_wrapper.ResetState();
            button_start.Enabled = false;
            button_stop.Enabled = true;
            button_settings.Enabled = false;
            timer1.Interval = Cfg.interval * 1000 * 60;
            timer1.Start();
            runningLabel.Text = "    Running";
            runningLabel.ForeColor = Color.DarkGreen;
            _cancelSource = new CancellationTokenSource();
            if (!serviceRunning)
            {
                serviceRunning = true;
                await StartLogic(_cancelSource);
                contextMenuSetter();
            }
            else
            {
                MessageBox.Show("Service already running");
            }

        }

        private void button_stop_Click(object sender, EventArgs e)
        {
            stopLogic();
        }
        private async void timer1_Tick(object sender, EventArgs e)
        {
            _cancelSource = new CancellationTokenSource();
            await Task.Run(async () =>
            {
                await Task.Delay(TimeSpan.FromSeconds(10)); // wait 10 secs for Internet reconnection after system resume.
                Scrap_wrapper.UpdateImage(_cancelSource);
            }, _cancelSource.Token);
            if (Cfg.setwallpaper)
                Wallpaper.Set(Cfg.image_folder+"\\wallpaper.bmp");
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
                _cancelSource.Cancel();
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
        private async Task StartLogic(CancellationTokenSource _cancelSource)
        {
            await Scrap_wrapper.UpdateImage(_cancelSource);
            Wallpaper.SetDefaultStyle();
            if (Cfg.setwallpaper)
                Wallpaper.Set(Cfg.image_folder + "\\wallpaper.bmp");
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

        private void timer2_Tick(object sender, EventArgs e)
        {
            Scrap_wrapper.CleanCDN();
        }

    }
}
