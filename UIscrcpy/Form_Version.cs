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
        private const string New_Version_Link = "https://github.com/HosoQchan/UIscrcpy/releases";
        private const string GitHub_Link = "https://github.com/HosoQchan/UIscrcpy";

        public Form_Version()
        {
            InitializeComponent();
        }

        private void Form_Version_Load(object sender, EventArgs e)
        {
            Icon icon = new Icon(".\\icon\\UIscrcpy.ico");
            PictureBox_Icon.Image = icon.ToBitmap();

            Label_Now_Ver.Text = UIsrcpy.This_Version;
            if (UIsrcpy.GitHub_Version == "")
            {
                Label_Git_Ver.Text = "不明";
            }
            else
            {
                Label_Git_Ver.Text = UIsrcpy.GitHub_Version;
            }
            Label_NewVer.Text = UIsrcpy.GitHub_Version;

            if ((UIsrcpy.GitHub_Version != "") && (UIsrcpy.This_Version != UIsrcpy.GitHub_Version))
            {
                Panel_Now_Version.Visible = false;

                Panel_New_Version.Visible = true;
                Panel_UpDate_New.Visible = true;
                Panel_UpDate_NG.Visible = false;
            }
            else
            {
                if (UIsrcpy.GitHub_Version == "")
                {
                    Panel_Now_Version.Visible = false;

                    Panel_New_Version.Visible = true;
                    Panel_UpDate_New.Visible = false;
                    Panel_UpDate_NG.Visible = true;
                }
                else
                {
                    Panel_Now_Version.Visible = true;

                    Panel_New_Version.Visible = false;
                    Panel_UpDate_New.Visible = false;
                    Panel_UpDate_NG.Visible = false;
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
            Link_Display(New_Version_Link);
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
                MessageBox.Show("リンクが開けませんでした。", "メッセージ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show("リンクが開けませんでした。", "メッセージ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void Button_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
