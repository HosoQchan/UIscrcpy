using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Reflection.Metadata.Ecma335;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace UIscrcpy.URL
{
    public class App_Icon_Generator
    {
        public string Icon_Url_Search(string App_Package_Name)
        {
            string Source = "";
            //URLの取得
            string url = "https://play.google.com/store/apps/details?id=" + App_Package_Name + "&hl=ja";

            WebClient wc = new WebClient();
            try
            {
                wc.Encoding = Encoding.UTF8;
                Source = wc.DownloadString(url);
            }
            catch (WebException exc)
            {
                return "";
            }

            // アイコンファイルの場所を探す
            Match mh;
            mh = Regex.Match(Source, @"""(?<Icon_Adr>https://play-lh.googleusercontent.com/.+?)""", RegexOptions.None);
            if (mh.Success)
            {
                if (mh.Groups["Icon_Adr"].Value != "")
                {
                    return mh.Groups["Icon_Adr"].Value + "=w300";
                }
            }
            return "";
        }

        public void Icon_DounLoad(string App_Package_Name,string url)
        {
            Bitmap Picture = null;
            string File_Name = App_Package_Name + ".png";
            File_Name = Setting.App_Data_Path + "\\App_Picture\\" + File_Name;
            try
            {
                System.Net.WebClient wc = new System.Net.WebClient();
                wc.DownloadFile(url, File_Name);
                wc.Dispose();
//                Picture = new Bitmap(File_Name);
            }
            catch (WebException exc)
            {
            }
        }
    }
}
