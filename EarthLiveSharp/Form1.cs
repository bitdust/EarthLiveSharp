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
            label5.Text = Cfg.version;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Cfg.source_select = comboBox1.Text;
            Cfg.interval = (int)(numericUpDown1.Value);
            Cfg.max_number = (int)(numericUpDown2.Value);
            Cfg.autostart = checkBox1.Checked;
            Cfg.commit();
        }
    }
}
