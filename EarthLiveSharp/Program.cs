using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;

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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
    public class scraper
    {
        public static string latest_address = "";
        public static string GetLatestAddress()
        {
            string json_url = "http://himawari8.nict.go.jp/img/D531106/latest.json";
            string pic_url = "http://himawari8-dl.nict.go.jp/himawari8/img/D531106/1d/550/";
            HttpWebRequest request = WebRequest.Create(json_url) as HttpWebRequest;
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                String date = reader.ReadToEnd().Substring(9,19);
                String date_formated = date.Replace("-", "/").Replace(" ", "/").Replace(":", "");
                scraper.latest_address = pic_url + date_formated + "_0_0.png";
                return scraper.latest_address;
            }
        }

        public static void SaveImage()
        {
            WebClient client = new WebClient();
            client.DownloadFile(scraper.latest_address, "1.png"); 
        }
    }
}
