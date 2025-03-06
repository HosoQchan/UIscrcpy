using MS.WindowsAPICodePack.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UIscrcpy
{
    public class Command
    {
        private Shell shell = new Shell();
        public Device_Info deviceinfo = new Device_Info();

        /// <summary>
        /// TCP/IP接続コマンドを送信する
        /// </summary>
        /// <returns></returns>
        public void TCPIP_Connect()
        {

            shell.Async_Comand("ADB_Tcpip", "\\adb.exe", " tcpip 5555");
        }

        /// <summary>
        /// WiFi接続コマンドを送信する
        /// </summary>
        /// <returns>
        /// Error : false
        /// </returns>
        public bool WiFi_Connect(string IP_Adress)
        {
            // TCP / IP接続コマンドを送信する
            TCPIP_Connect();

            Match mh;
            shell.Async_Comand("ADB_Connect", "\\adb.exe", " connect " + IP_Adress + ":5555");
            mh = Regex.Match(shell.Output_Results, @"connected to.*", RegexOptions.None);
            if (mh.Success)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// WiFi切断コマンドを送信する
        /// </summary>
        /// <returns></returns>
        public void WiFi_Disconnect()
        {
            shell.Async_Comand("ADB_Disconnect", "\\adb.exe", " disconnect");
        }

        /// <summary>
        /// 端末情報を取得
        /// </summary>
        /// <returns>
        /// Serial = USB > Serial
        /// Serial = Wifi > Serial = ""
        /// Product_Name = 製品名
        /// Model_Name = 機種名
        /// 
        /// Error : Serial = ""
        /// </returns>
        public Device_Info Device_Info()
        {
            deviceinfo = new Device_Info();
            Match mh;
            shell.Async_Comand("ADB_Devices_List", "\\adb.exe", " devices -l");
            mh = Regex.Match(shell.Output_Results, @"\r\n(?<Dname>.+)device product:(?<Product>.*)model:(?<Model>.*)device:.*transport_id:(?<ID>.+)", RegexOptions.None);
            if (mh.Success)
            {
                // 端末情報のSerialが、IPアドレス以外か確認する
                string Serial = mh.Groups["Dname"].Value.Trim();
                if (Serial_Check(Serial))
                {
                    deviceinfo.Serial = Serial;
                    deviceinfo.Product_Name = mh.Groups["Product"].Value.Trim();
                    deviceinfo.Model_Name = mh.Groups["Model"].Value.Trim();
                }
            }
            return deviceinfo;
        }
        /// <summary>
        /// 端末情報のSerialが、IPアドレス以外か確認する
        /// </summary>
        /// <returns></returns>
        private bool Serial_Check(string Serial)
        {
            Match mh;
            mh = Regex.Match(Serial, @"(?<Adress>\d+\.\d+\.\d+\.\d+)", RegexOptions.None);
            if (mh.Success)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// ＩＰアドレスを取得する
        /// </summary>
        /// <returns>
        /// IP Adress
        /// Error = ""
        /// </returns>
        public string IP_Adress_Info()
        {
            // TCP / IP接続コマンドを送信する
            TCPIP_Connect();

            // TCP / IP接続コマンドを送信後、直ぐにＩＰアドレス取得コマンドを送信してしまうと、
            // うまく処理してくれなかったので、1sのWaitを設けた
            Thread.Sleep(2000);

            Match mh;
            shell.Async_Comand("ADB_IP_Address", "\\adb.exe", " shell ip addr show wlan0");
            mh = Regex.Match(shell.Output_Results, @"inet (?<Adress>\d+\.\d+\.\d+\.\d+)", RegexOptions.None);
            if (mh.Success)
            {
                return mh.Groups["Adress"].Value;
            }
            return "";
        }

        /// <summary>
        /// キーコマンドを送信する
        /// </summary>
        /// <returns>
        /// Error : false
        /// </returns>
        public bool KeyCode(string Keycode)
        {
            string Option = "";
            if (UIsrcpy.Connect_USB)
            {
                Option = " -d  shell input keyevent " + Keycode;
            }
            else
            {
                Option = " -e  shell input keyevent " + Keycode;
            }

            shell.Async_Comand("ADB_keyevent", "\\adb.exe", Option);
            if (shell.Async_Error == "error")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// スクリーンショットコマンドを実行する
        /// </summary>
        /// <returns>
        /// Error : false
        /// </returns>
        public bool Screenshot()
        {
            if (!Directory.Exists(Setting.Rec_Path))
            {
                MessageBox.Show(Setting.Rec_Path + "\r\n" + Lng.ini["Msg", "フォルダが見つかりません。"], Lng.ini["Msg", "メッセージ"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            string fileName = Setting.Rec_Path + DateTime.Now.ToString(UIsrcpy.DatetimeFormat) + ".png";
            string Option = "";
            if (UIsrcpy.Connect_USB)
            {
                Option = " -d exec-out screencap -p > " + fileName;
            }
            else
            {
                Option = " -e exec-out screencap -p > " + fileName;
            }

            shell.Async_Comand("ADB_Screenshot", "\\adb.exe", Option);
            if (shell.Async_Error == "error")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        
        /// <summary>
        /// アプリ一覧を取得する
        /// </summary>
        /// <returns></returns>
        public void Application()
        {
            deviceinfo.App_List.Clear();

            // 端末情報を取得
            string Serial = Device_Info().Serial;

            // 現在選択されている端末が、USB接続されていない場合は、Wifi接続で試みる
            if (Serial != Setting.Main.select_Device_Info.Serial)
            {
                if (!WiFi_Connect(Setting.Main.select_Device_Info.IP_Adress))
                {
                    // エラーメッセージを表示する
                    string Msg = Lng.ini["Msg", "接続できませんでした。"];
                    MBox mbox = new MBox(Lng.ini["Msg", "メッセージ"], "WARNING", Msg, "OK", "OK");
                    mbox.ShowDialog();
                    deviceinfo.App_List = null;
                    return;
                }
                else
                {
                    Serial = Setting.Main.select_Device_Info.IP_Adress + ":5555";
                }
            }
          
            Match mh;
            // アプリ一覧を取得
            shell.Async_Comand("scrcpy_App_List", "\\scrcpy.exe", " --serial=" + Serial + " --list-app");
            mh = Regex.Match(shell.Error_Results, @"java.lang.AssertionError:.+", RegexOptions.None);
            if (mh.Success)
            {
                // エラーメッセージを表示する
                string Msg = Lng.ini["Msg", "アプリの取得に失敗しました。\"scrcpy\"のフォルダを、\"UIscrcpy\"のフォルダ内とは別の場所に移動して実行してみてください。"];
                MBox mbox = new MBox(Lng.ini["Msg", "メッセージ"], "WARNING", Msg, "OK", "OK");
                mbox.ShowDialog();
                deviceinfo.App_List = null;
                return;
            }
            foreach (var line in (shell.Output_Results).AsSpan().EnumerateLines())
            {
                mh = Regex.Match(line.ToString(), @"\s(-|\*)\s(?<App_Name>.+)\s+(?<Package>.+)", RegexOptions.None);
                if (mh.Success)
                {
                    App_Info app_Info = new App_Info();
                    app_Info.Name = mh.Groups["App_Name"].Value.Trim();
                    app_Info.Package = mh.Groups["Package"].Value.Trim();
                    deviceinfo.App_List.Add(app_Info);
                }
            }
            // WiFi切断コマンドを送信する
            WiFi_Disconnect();
            return;
        }
    }
}
