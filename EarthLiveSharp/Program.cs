using System;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Diagnostics;
using Microsoft.Win32;
using System.Drawing;

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
            scraper.size = Cfg.size;
            scraper.image_folder = Cfg.image_folder;
            scraper.image_source = Cfg.image_source;
            // scraper.image_source = "http://himawari8-dl.nict.go.jp/himawari8/img/D531106";
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new mainForm());
        }
    }
    public static class scraper
    {
        public static int size = 1;
        public static string image_folder = "";
        public static string pic_url = "";  // TODO delete
        public static string image_source = "";
        private static string imageID = "";
        private static string last_imageID = "0";
        private static string json_url = "http://himawari8.nict.go.jp/img/D531106/latest.json";

        private static string GetImageID()
        {
            HttpWebRequest request = WebRequest.Create(json_url) as HttpWebRequest;
            try 
            {
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                StreamReader reader = new StreamReader(response.GetResponseStream());
                string date = reader.ReadToEnd();
                if (date.Length > 30)
                {
                    imageID = date.Substring(9,19).Replace("-", "/").Replace(" ", "/").Replace(":", "");
                    Trace.WriteLine("[get latest ImageID] " + imageID);
                }
                else
                {
                    Trace.WriteLine("[json data is too short]"); // do nothing
                }
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
            return imageID;
        }

        private static void SaveImage()
        {
            WebClient client = new WebClient();
            try
            {
                for (int ii = 0; ii < size; ii++)
                {
                    for (int jj = 0; jj < size; jj++)
                    {
                        string url = string.Format("{0}/{1}d/550/{2}_{3}_{4}.png", image_source, size, imageID, ii, jj);
                        string image_path = string.Format("{0}\\{1}{2}_{3}.png", image_folder, imageID.Replace("/",""), ii, jj); // remove the '/' in imageID
                        client.DownloadFile(url, image_path);
                    }
                }
                Trace.WriteLine("[save image] " + imageID);
                last_imageID = imageID;
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message + " " + imageID);
            }
            finally
            {
                client.Dispose();
            }
        }

        private static void JoinImage()
        {
            // join & convert the images to wallpaper.bmp
            Bitmap bitmap = new Bitmap(550 * size, 550 * size);
            Image[,] tile = new Image[size, size];
            Graphics g = Graphics.FromImage(bitmap);
            for (int ii = 0; ii < size; ii++)
            {
                for (int jj = 0; jj < size; jj++)
                {
                    tile[ii,jj] = Image.FromFile(string.Format("{0}\\{1}{2}_{3}.png", image_folder, imageID.Replace("/", ""), ii, jj));
                    g.DrawImage(tile[ii, jj], 550 * ii, 550 * jj);
                }
            }
            g.Save();
            g.Dispose();
            bitmap.Save(string.Format("{0}\\wallpaper.bmp", image_folder));
        }

        private static void InitFolder()
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
            InitFolder();
            GetImageID();
            if (imageID.Equals(last_imageID))
            {
                return;
            }
            else
            {
                SaveImage();
                JoinImage();
                return;
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
