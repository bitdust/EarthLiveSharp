﻿using System;
using System.Windows.Forms;
using System.Net;
using System.Net.Cache;  
using System.IO;
using System.Diagnostics;
using Microsoft.Win32;
using System.Drawing;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Threading;
using System.Net.Http;

namespace EarthLiveSharp
{
    static class Program
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
        
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args) 
        {
            if (System.Environment.OSVersion.Version.Major >= 6) { SetProcessDPIAware(); }
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
            if (Cfg.source_selection ==0 & Cfg.cloud_name.Equals("demo"))
            {
                #if DEBUG

                #else
                DialogResult dr = MessageBox.Show("WARNING: it's recommended to get images from CDN. \n 注意：推荐使用CDN方式来抓取图片，以提高稳定性。", "EarthLiveSharp");
                if (dr == DialogResult.OK)
                {
                    Process.Start("https://github.com/bitdust/EarthLiveSharp/issues/32");
                }
                #endif
            }
            Cfg.image_folder = Application.StartupPath + @"\images";
            Cfg.Save();
            Scrap_wrapper.set_scraper();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new mainForm());
        }
    }

    public static class Scrap_wrapper
    {
        public static int SequenceCount = 0;
        private static IScraper scraper;
        public static void set_scraper()
        {
            scraper = new Scraper_himawari8();
            return;
        }
        public static async Task UpdateImage(CancellationTokenSource _cancelSource)
        {
            await scraper.UpdateImage(_cancelSource);
        }

        public static void ResetState()
        {
            scraper.ResetState();
        }

        public static void CleanCDN()
        {
            scraper.CleanCDN();
        }
    }

    interface IScraper
    {
        Task UpdateImage(CancellationTokenSource _cancelSource);
        void CleanCDN();
        void ResetState();
    }
    public class Scraper_himawari8 : IScraper
    {
        private string imageID = "";
        private static string last_imageID = "0";
        private string json_url = "http://himawari8.nict.go.jp/img/D531106/latest.json";

        private async Task<int> GetImageID(CancellationTokenSource _source)
        {
            HttpClient client = new HttpClient();
            try 
            {
                var response = await client.GetAsync(json_url, _source.Token);
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new Exception("[himawari8 connection error]");
                }
                if (!response.Content.Headers.ContentType.MediaType.Contains("application/json"))
                {
                    throw new Exception("[himawari8 no json recieved. your Internet connection is hijacked]");
                }
                string date =await  response.Content.ReadAsStringAsync();
                imageID = date.Substring(9,19).Replace("-", "/").Replace(" ", "/").Replace(":", "");
                Trace.WriteLine("[himawari8 get latest ImageID] " + imageID);
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                return -1;
            }
            return 0;
        }

        private async Task<int> SaveImage(CancellationTokenSource _source)
        {
            WebClient client = new WebClient();
            string image_source = "";
            _source.Token.Register(client.CancelAsync);
            if (Cfg.source_selection == 1)
            {
               image_source = "http://res.cloudinary.com/" + Cfg.cloud_name + "/image/fetch/http://himawari8-dl.nict.go.jp/himawari8/img/D531106";
            }
            else
            {
               image_source = "http://himawari8-dl.nict.go.jp/himawari8/img/D531106";
            }
            try
            {
                for (int ii = 0; ii < Cfg.size; ii++)
                {
                    for (int jj = 0; jj < Cfg.size; jj++)
                    {
                        string url = string.Format("{0}/{1}d/550/{2}_{3}_{4}.png", image_source, Cfg.size, imageID, ii, jj);
                        string image_path = string.Format("{0}\\{1}_{2}.png", Cfg.image_folder, ii, jj); // remove the '/' in imageID
                        await client.DownloadFileTaskAsync(url, image_path);
                    }
                }
                Trace.WriteLine("[save image] " + imageID);
                return 0;
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message + " " + imageID);
                Trace.WriteLine(string.Format("[image_folder]{0} [image_source]{1} [size]{2}",Cfg.image_folder, image_source, Cfg.size));
                return -1;
            }
        }

        private void JoinImage()
        {
            // join & convert the images to wallpaper.bmp
            Bitmap bitmap = new Bitmap(550 * Cfg.size, 550 * Cfg.size);
            Image[,] tile = new Image[Cfg.size, Cfg.size];
            Graphics g = Graphics.FromImage(bitmap);
            for (int ii = 0; ii < Cfg.size; ii++)
            {
                for (int jj = 0; jj < Cfg.size; jj++)
                {
                    tile[ii,jj] = Image.FromFile(string.Format("{0}\\{1}_{2}.png", Cfg.image_folder, ii, jj));
                    g.DrawImage(tile[ii, jj], 550 * ii, 550 * jj);
                    tile[ii, jj].Dispose();
                }
            }
            g.Save();
            g.Dispose();
            if (Cfg.zoom == 100)
            {
                bitmap.Save(string.Format("{0}\\wallpaper.bmp", Cfg.image_folder),System.Drawing.Imaging.ImageFormat.Bmp);
            }
            else if (1 < Cfg.zoom & Cfg.zoom <100)
            {
                int new_size = bitmap.Height * Cfg.zoom /100;
                Bitmap zoom_bitmap = new Bitmap(new_size, new_size);
                Graphics g_2 = Graphics.FromImage(zoom_bitmap);
                g_2.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g_2.DrawImage(bitmap, 0, 0, new_size, new_size);
                g_2.Save();
                g_2.Dispose();
                zoom_bitmap.Save(string.Format("{0}\\wallpaper.bmp", Cfg.image_folder),System.Drawing.Imaging.ImageFormat.Bmp);
                zoom_bitmap.Dispose();
            }
            else
            {
                Trace.WriteLine("[himawari8 zoom error]");
            }

            bitmap.Dispose();

            if (Cfg.saveTexture && Cfg.saveDirectory != "selected Directory")
            {
                if (Scrap_wrapper.SequenceCount >= Cfg.saveMaxCount)
                {
                    Scrap_wrapper.SequenceCount = 0;
                }
                try
                {
                    File.Copy(string.Format("{0}\\wallpaper.bmp", Cfg.image_folder), Cfg.saveDirectory + "\\" + "wallpaper_" + Scrap_wrapper.SequenceCount + ".bmp", true);
                    Scrap_wrapper.SequenceCount++;
                }
                catch (Exception e)
                {
                    Trace.WriteLine("[can't save wallpaper to distDirectory]");
                    Trace.WriteLine(e.Message);
                    return;
                }
            }
        }

        private void InitFolder()
        {
            if(Directory.Exists(Cfg.image_folder))
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
                Trace.WriteLine("[himawari8 create folder]");
                Directory.CreateDirectory(Cfg.image_folder);
            }
        }
        public async Task UpdateImage(CancellationTokenSource _source)
        {
            InitFolder();
            if (await GetImageID(_source) == -1)
            {
                return;
            }
            if (imageID.Equals(last_imageID))
            {
                return;
            }
            if (await SaveImage(_source) == 0)
            {
               JoinImage();
            }
            last_imageID = imageID;
            return;
        }
        public void CleanCDN()
        {
            Cfg.Load();
            if (Cfg.api_key.Length == 0) return;
            if (Cfg.api_secret.Length == 0) return;
            try
            {
                HttpWebRequest request = WebRequest.Create("https://api.cloudinary.com/v1_1/" + Cfg.cloud_name + "/resources/image/fetch?prefix=http://himawari8-dl") as HttpWebRequest;
                request.Method = "DELETE";
                request.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);
                string svcCredentials = Convert.ToBase64String(System.Text.Encoding.ASCII.GetBytes(Cfg.api_key + ":" + Cfg.api_secret));
                request.Headers.Add("Authorization", "Basic " + svcCredentials);
                HttpWebResponse response = null;
                StreamReader reader = null;
                string result = null;
                for (int i = 0; i < 3;i++ ) // max 3 request each hour.
                {
                    response = request.GetResponse() as HttpWebResponse;
                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        throw new Exception("[himawari8 clean CND cache connection error]");
                    }
                    if (!response.ContentType.Contains("application/json"))
                    {
                        throw new Exception("[himawari8 clean CND cache no json recieved. your Internet connection is hijacked]");
                    }
                    reader = new StreamReader(response.GetResponseStream());
                    result = reader.ReadToEnd();
                    if (result.Contains("\"error\""))
                    {
                        throw new Exception("[himawari8 clean CND cache request error]\n" + result);
                    }
                    if (result.Contains("\"partial\":false"))
                    {
                        Trace.WriteLine("[himawari8 clean CDN cache done]");
                        break; // end of Clean CDN
                    }
                    else
                    {
                        Trace.WriteLine("[himawari8 more images to delete]");
                    }
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine("[himawari8 error when delete CDN cache]");
                Trace.WriteLine(e.Message);
                return;
            }
        }
        public void ResetState()
        {
            last_imageID = "0";
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
