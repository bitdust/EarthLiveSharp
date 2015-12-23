using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EarthLiveSharp
{
    public partial class settingsForm : Form
    {
        public settingsForm()
        {
            InitializeComponent();
            Cfg.Load();
            if(Cfg.source_select=="origin")
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
            label5.Text = Cfg.version;
            comboBox_DisplayMode.SelectedIndex = Cfg.display_mode;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Cfg.source_select = comboBox1.Text;
            Cfg.interval = (int)(numericUpDown1.Value);
            Cfg.max_number = (int)(numericUpDown2.Value);
            Cfg.autostart = checkBox1.Checked;
            Cfg.display_mode = comboBox_DisplayMode.SelectedIndex;
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
            }
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

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cfg.source_select = comboBox1.Text;
            Cfg.interval = (int)(numericUpDown1.Value);
            Cfg.max_number = (int)(numericUpDown2.Value);
            Cfg.autostart = checkBox1.Checked;
            Cfg.display_mode = comboBox_DisplayMode.SelectedIndex;
            Cfg.Save();
            Autostart.Set(Cfg.autostart);
            this.Close();
        }
    }
}
