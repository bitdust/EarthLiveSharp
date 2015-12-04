using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Diagnostics;

namespace EarthLiveSharp
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (File.Exists(@"trace.log"))
            {
                File.Delete(@"trace.log");
            }
            Trace.Listeners.Add(new TextWriterTraceListener("trace.log"));
            Trace.AutoFlush = true;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
    public class scraper
    {
        public static string latest_address = "";
        public static string saved_address = "";
        private static string image_folder = @".\images\";
        private static int image_cnt = 0;
        private static int max_number = 5;
        public static string GetLatestAddress()
        {
            string json_url = "http://himawari8.nict.go.jpp/img/D531106/latest.json";
            string pic_url = "http://himawari8-dl.nict.go.jp/himawari8/img/D531106/1d/550/";
            HttpWebRequest request = WebRequest.Create(json_url) as HttpWebRequest;
            try 
            {
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                StreamReader reader = new StreamReader(response.GetResponseStream());
                String date = reader.ReadToEnd().Substring(9,19);           
                String date_formated = date.Replace("-", "/").Replace(" ", "/").Replace(":", "");
                latest_address = pic_url + date_formated + "_0_0.png";
                Trace.WriteLine("[get latest address] " + date);
                response.Dispose();
            }
            catch(Exception e)
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
            String image_path = image_folder + image_cnt.ToString() + ".png";
            if(File.Exists(image_path))
            {
                File.Delete(image_path + image_cnt.ToString() + ".png");
            }
            WebClient client = new WebClient();
            try
            {
                client.DownloadFile(latest_address, image_path);
                Trace.WriteLine("[save image]" + latest_address + " to " + image_path);
            }
            catch(Exception e)
            {
                Trace.WriteLine(e.Message);
            }
            finally
            {
                client.Dispose();
            }
            if (image_cnt+1 < max_number)
            {
                image_cnt = image_cnt + 1;
            }
            else
            {
                image_cnt = 0;
            }
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
                Directory.CreateDirectory(image_folder);
            }
            GetLatestAddress();
            SaveImage();
            File.Copy(image_folder + (image_cnt-1).ToString() + ".png", image_folder + image_cnt.ToString() + ".png",true);
            image_cnt = image_cnt + 1;
            saved_address = latest_address;
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
                saved_address = latest_address;
            }
        }
    }
}
