using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIscrcpy
{
    public partial class Form_Version : Form
    {
        private const string License_Link = "https://ja.wikipedia.org/wiki/MIT_License";
        private const string GitHub_Link = "https://github.com/HosoQchan/UIscrcpy";
        private Icon icon = new Icon(".\\Resources\\Icon\\UIscrcpy.ico");

        public Form_Version()
        {
            InitializeComponent();
            this.Icon = icon;

            GBox_Developer.Text = Lng.ini["Msg", "開発環境"];
            Button_Close.Text = Lng.ini["Main", "閉じる"];

            Panel_UpDate_Now.Visible = false;
            Panel_UpDate_New.Visible = false;
            Panel_Update_Info.Visible = false;

            Label_This_Software.Text = Lng.ini["Msg", "このソフトウェアは"];
            Label_Update_Info.Text = Lng.ini["Msg", "最新バージョンはこちらからDLできます。"];
            Label_UpDate_New.Text = Lng.ini["Msg", "が公開されています。"];
            Label_UpDate_Now.Text = Lng.ini["Msg", "お使いのバージョンは最新です。"];
        }

        private void Form_Version_Load(object sender, EventArgs e)
        {
            
            PictureBox_Icon.Image = icon.ToBitmap();

            Label_Now_Ver.Text = UIsrcpy.This_Version;

            Label_Git_Ver.Visible = false;
            Label_Git_VerNo.Visible = false;
            // 現在のverと最新Verが同じ場合
            if (UIsrcpy.This_Version == UIsrcpy.GitHub_Version)
            {


                Panel_UpDate_Now.Visible = true;
                Panel_UpDate_New.Visible = false;
                Panel_Update_Info.Visible = false;
            }
            // 現在のverと最新Verが異なる場合
            else
            {
                if (UIsrcpy.GitHub_Version != "")
                {
                    Label_Git_Ver.Visible = true;
                    Label_Git_VerNo.Text = UIsrcpy.GitHub_Version;
                    Label_NewVer.Text = UIsrcpy.GitHub_Version;

                    Panel_UpDate_Now.Visible = false;
                    Panel_UpDate_New.Visible = true;
                    Panel_Update_Info.Visible = false;
                }
                else
                {
                    Panel_UpDate_Now.Visible = false;
                    Panel_UpDate_New.Visible = false;
                    Panel_Update_Info.Visible = true;
                }
            }
        }
        private void LinkLabel_GitHub_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //リンク先に移動したことにする
            LinkLabel_GitHub.LinkVisited = true;
            Link_Display(GitHub_Link);
        }

        private void LinkLabel_New_Version_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //リンク先に移動したことにする
            LinkLabel_New_Version.LinkVisited = true;
            Link_Display(GitHub_Link);
        }

        private void LinkLabel_License_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //リンク先に移動したことにする
            LinkLabel_License.LinkVisited = true;
            Link_Display(License_Link);
        }

        private void Link_Display(string URL)
        {
            //レジストリキー（HKEY_CURRENT_USER\Software\Microsoft\Windows\Shell\Associations\UrlAssociations\http\UserChoice）
            //を、新規作成されない様に開く
            Microsoft.Win32.RegistryKey regkey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(
                            @"Software\Microsoft\Windows\Shell\Associations\UrlAssociations\http\UserChoice", false);

            //レジストリ"ProgId"の値を読み取り
            string progId = regkey.GetValue("ProgId").ToString();

            //"progID"の書かれているキーを開く
            regkey = Microsoft.Win32.Registry.ClassesRoot.OpenSubKey(
                            string.Format(@"{0}\shell\open\command", progId), false);
            string Browser = regkey.GetValue(null).ToString();
            // commandには"C:\Program Files\Google\Chrome\Application\chrome.exe" --single-argument %1　のように
            //ファイパス以降に不要な文字が入るので　2つめの'”'を探してそれ以降を削除する
            string gomiStr = Browser.Substring(Browser.IndexOf("\"", Browser.IndexOf("\"") + 1) + 1);
            Browser = Browser.Replace(gomiStr, "");

            ProcessStartInfo info = new ProcessStartInfo();
            info.UseShellExecute = true;
            // デフォルトブラウザ
            info.FileName = Browser;
            // URLを加える
            info.Arguments = URL;
            Process p = new Process();
            p.StartInfo = info;

            try
            {
                p.Start();
            }
            catch (System.ComponentModel.Win32Exception noBrowser)
            {
                string Msg = Lng.ini["Msg", "リンクが開けませんでした。"];
                MBox mbox = new MBox(Lng.ini["Msg", "メッセージ"], "WARNING", Msg, "OK", "OK");
                mbox.ShowDialog();
            }
            catch (Exception ex)
            {
                string Msg = Lng.ini["Msg", "リンクが開けませんでした。"];
                MBox mbox = new MBox(Lng.ini["Msg", "メッセージ"], "WARNING", Msg, "OK", "OK");
                mbox.ShowDialog();
            }

        }

        private void Button_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
