using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace EarthLiveSharp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            label3.Text = Cfg.version;
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("iexplore.exe", "http://himawari8.nict.go.jp/");
        }
    }
}
