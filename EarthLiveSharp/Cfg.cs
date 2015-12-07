using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using Microsoft.Win32;
using System.Diagnostics;
using System.Windows.Forms;

namespace EarthLiveSharp
{
    public static class Cfg
    {
        public static string version;
        public static string image_folder;
        public static string origin_addr;
        public static string cdn_addr;
        public static string source_select;
        public static int interval;
        public static int max_number;
        public static bool autostart;
        public static int display_mode; // 0 for only latest default; 1 for only latest customized style; 2 for slideshow

        public static void Load()
        {
            try
            {
                ExeConfigurationFileMap map = new ExeConfigurationFileMap();
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                AppSettingsSection app = config.AppSettings;
                version = app.Settings["version"].Value;
                image_folder = app.Settings["image_folder"].Value;
                origin_addr = app.Settings["origin"].Value;
                cdn_addr = app.Settings["cdn"].Value;
                source_select = app.Settings["source_select"].Value;
                interval = Convert.ToInt32(app.Settings["interval"].Value);
                max_number = Convert.ToInt32(app.Settings["max_number"].Value);
                autostart = Convert.ToBoolean(app.Settings["autostart"].Value);
                display_mode = Convert.ToInt32(app.Settings["display_mode"].Value);
                return;
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                MessageBox.Show("Configure error!");
                throw (e);
            }
        }
        public static void Save()
        {
            ExeConfigurationFileMap map = new ExeConfigurationFileMap();
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            AppSettingsSection app = config.AppSettings;
            //app.Settings["origin"].Value = origin_addr;
            //app.Settings["cdn"].Value = cdn_addr;
            app.Settings["image_folder"].Value = image_folder;
            app.Settings["source_select"].Value = source_select;
            app.Settings["interval"].Value = interval.ToString();
            app.Settings["max_number"].Value = max_number.ToString();
            app.Settings["autostart"].Value = autostart.ToString();
            app.Settings["display_mode"].Value = display_mode.ToString();
            config.Save();
            return;
        }
    }
}
