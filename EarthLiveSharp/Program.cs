using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Diagnostics;
using System.Configuration;
using Microsoft.Win32;

namespace EarthLiveSharp
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (File.Exists(Application.StartupPath + @"\trace.log"))
            {
                File.Delete(Application.StartupPath + @"\trace.log");
            }
            Trace.Listeners.Add(new TextWriterTraceListener(Application.StartupPath + @"\trace.log"));
            Trace.AutoFlush = true;

            try
            {
                Cfg.Load();
            }
            catch
            {
                return;
            }
            Cfg.image_folder = Application.StartupPath + @"\images";
            Cfg.Save();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new mainForm());
        }
    }
    public static class scraper
    {
        public static string image_folder = "";
        public static int max_number = 5;
        public static string pic_url = "";
        public static string saved_path = "";
        private static int image_cnt = 0;
        private static string latest_address = "";
        private static string saved_address = "";

        private static string json_url = "http://himawari8.nict.go.jp/img/D531106/latest.json";

        public static void Reset()
        {
            image_cnt = 0;
            latest_address = "";
            saved_address = "";
            return;
        }

        public static string GetLatestAddress()
        {
            HttpWebRequest request = WebRequest.Create(json_url) as HttpWebRequest;
            try 
            {
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                StreamReader reader = new StreamReader(response.GetResponseStream());
                String date = reader.ReadToEnd().Substring(9,19);           
                String date_formated = date.Replace("-", "/").Replace(" ", "/").Replace(":", "");
                latest_address = pic_url + date_formated + "_0_0.png";
                Trace.WriteLine("[get latest address] " + date);
                reader.Close();
                response.Close();
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
            }
            finally
            {
                ;
            }
            return latest_address;
        }

        public static void SaveImage()
        {
            String image_path = image_folder+ @"\" + image_cnt.ToString() + ".png";
            //if(File.Exists(image_path))
            //{
            //    File.Delete(image_path + image_cnt.ToString() + ".png");
            //}
            WebClient client = new WebClient();
            try
            {
                client.DownloadFile(latest_address, image_path);
                saved_address = latest_address;
                saved_path = image_path;
                Trace.WriteLine("[save image] " + latest_address + " > " + image_path);
                if (Directory.GetFiles(image_folder, "*.png").Length == 1)
                {
                    File.Copy(image_path, image_folder + @"\" + "1.png", true);
                }
            }
            catch(Exception e)
            {
                Trace.WriteLine(e.Message + "[latest_address] " + latest_address + " [image_path] " + image_path);
            }
            finally
            {
                client.Dispose();
            }
            image_cnt = (image_cnt + 1) % max_number;
        }

        public static void InitFolder()
        {
            if(Directory.Exists(image_folder))
            {
                // delete all images in the image folder.
                //string[] files = Directory.GetFiles(image_folder);
                //foreach (string fn in files)
                //{
                //    File.Delete(fn);
                //}
            }
            else
            {
                Trace.WriteLine("[create folder]");
                Directory.CreateDirectory(image_folder);
            }
        }
        public static void UpdateImage()
        {
            GetLatestAddress();
            if(latest_address.Equals(saved_address))
            {
                return;
            }
            else
            {
                SaveImage();
            }
        }
    }



    public static class Autostart
    {
        static string key = "EarthLiveSharp";
        public static bool Set(bool enabled)
        {
            RegistryKey runKey = null;
            try
            {
                string path = Application.ExecutablePath;
                runKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
                if (enabled)
                {
                    runKey.SetValue(key, path);
                }
                else
                {
                    runKey.SetValue(key, path); // dirty fix: to avoid exception in next line.
                    runKey.DeleteValue(key);
                }
                return true;
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                return false;
            }
            finally
            {
                if(runKey!=null)
                {
                    runKey.Close();
                }
            }
        }
    }
}
