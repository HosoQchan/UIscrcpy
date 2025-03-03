using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using UIscrcpy.URL;
using static Microsoft.WindowsAPICodePack.Shell.PropertySystem.SystemProperties.System;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UIscrcpy
{
    public partial class Device_Connection : Form
    {
        public bool Error = false;
        public int Mode = 0;
        public string Serial = "";

        public Device_Info device_Info = new Device_Info();
            
        public Device_Connection()
        {
            InitializeComponent();
        }

        private void Device_Connection_Load(object sender, EventArgs e)
        {
            switch (Mode)
            {
                // ＩＰアドレスの取得
                case 0:
                    Label_Message.Text = "接続を確認しています・・・しばらくお待ちください。";
                    break;
                // Wifi接続
                case 1:
                    Label_Message.Text = "Wifi接続中です・・・しばらくお待ちください。";
                    break;
                // scrcpy接続の準備
                case 2:
                    Label_Message.Text = "接続中です・・・";
                    break;
                // アプリの取得
                case 3:
                    Label_Message.Text = "アプリを取得中です・・・しばらくお待ちください。";
                    break;
                // アプリアイコンの取得
                case 4:
                    Label_Message.Text = "アイコンを取得中です・・・しばらくお待ちください。";
                    break;
            }

            this.Shown += new EventHandler(Form_Shown);
        }

        //Formが表示されたら発生するイベント
        private void Form_Shown(object sender, EventArgs e)
        {
            // コントロールが完全に表示される前に処理を始めてしまうので、
            // 処理の前にFormの再描画を行う。
            this.Refresh();

            Match mh;
            Shell Shell = new Shell();
            switch (Mode)
            {
                // ＩＰアドレスの取得
                case 0:
                    // デバイスを切断
                    Shell.Async_Comand("ADB_Disconnect","\\adb.exe", " disconnect");

                    // デバイスを表示
                    Shell.Async_Comand("ADB_Devices_List","\\adb.exe", " devices -l");
                    Debug.WriteLine("デバイスを表示 --start");
                    Debug.WriteLine(Shell.Output_Results);
                    Debug.WriteLine("デバイスを表示 --end");
                    mh = Regex.Match(Shell.Output_Results, @"\r\n(?<Id>.+)device product:(?<Product>.*)model:(?<Model>.*)device:.*", RegexOptions.None);
                    if (!mh.Success)
                    {
                        // エラーメッセージを表示する
                        MessageBox.Show("接続を認識できませんでした。もう一度試してみてください。", "メッセージ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        Error = true;
                        this.Close();
                        return;
                    }

                    device_Info.Serial = mh.Groups["Id"].Value.Trim();
                    device_Info.Product_Name = mh.Groups["Product"].Value.Trim();
                    device_Info.Model_Name = mh.Groups["Model"].Value.Trim();
                    device_Info.IP_Adress = "";

                    // TCPIP接続に切り替える
                    Shell.Async_Comand("ADB_Tcpip","\\adb.exe", " tcpip 5555");

                    // IPアドレスを取得
                    Thread.Sleep(2000);
                    Shell.Async_Comand("ADB_IP_Address", "\\adb.exe", " shell ip addr show wlan0");
                    Debug.WriteLine("------- ip adress -------");
                    device_Info.IP_Adress = Shell.Async_Output;
                    Debug.WriteLine(device_Info.IP_Adress);
                    Debug.WriteLine("------- ip adress -------");
                    this.Close();
                    break;

                // Wifi接続
                case 1:
                    if (!ADB_Connect())
                    {
                        // エラーメッセージを表示する
                        MessageBox.Show("接続を認識できませんでした。もう一度試してみてください。", "メッセージ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        Error = true;
                        this.Close();
                        return;
                    }
                    this.Close();
                    break;

                // scrcpy接続の準備
                case 2:
                    if (Serial == "USB")
                    {
                        // デバイスを表示
                        Shell.Async_Comand("ADB_Devices_List", "\\adb.exe", " devices -l");
                        mh = Regex.Match(Shell.Output_Results, @"\r\n(?<Id>.+)device product:(?<Product>.*)model:(?<Model>.*)device:.*", RegexOptions.None);
                        if (mh.Success)
                        {
                            string id = mh.Groups["Id"].Value.Trim();
                            if (id != device_Info.Serial)
                            {
                                Error = true;
                                this.Close();
                                return;
                            }
                        }
                        else
                        {
                            Error = true;
                            this.Close();
                            return;
                        }
                    }
                    else
                    {

                        if (!ADB_Connect())
                        {
                            Error = true;
                            this.Close();
                            return;
                        }
                    }
                    this.Close();
                    break;

                // アプリの取得
                case 3:
                    Serial = "";

                    // デバイスを表示
                    Shell.Async_Comand("ADB_Devices_List","\\adb.exe", " devices -l");
                    mh = Regex.Match(Shell.Output_Results, @"\r\n(?<Id>.+)device product:(?<Product>.*)model:(?<Model>.*)device:.*", RegexOptions.None);
                    if (mh.Success)
                    {
                        string id = mh.Groups["Id"].Value.Trim();
                        if (id == device_Info.Serial)
                        {
                            Serial = device_Info.Serial;
                        }
                    }
                    if (Serial == "")
                    {
                        if (!ADB_Connect())
                        {
                            // エラーメッセージを表示する
                            MessageBox.Show("接続を認識できませんでした。もう一度試してみてください。", "メッセージ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            Error = true;
                            this.Close();
                            return;
                        }
                        Serial = device_Info.IP_Adress + ":5555";
                    }

                    Shell.Async_Comand("scrcpy_App_List","\\scrcpy.exe", " --serial=" + Serial + " --list-app");
                    GET_App_List(Shell.Output_Results);
                    this.Close();
                    break;

                // アプリアイコンの取得
                case 4:
                    string File_Name = "";
                    for (int i = 0; i < device_Info.App_List.Count; ++i)
                    {
                        File_Name = device_Info.App_List[i].Package + ".png";
                        File_Name = Setting.App_Data_Path + "App_Picture\\" + File_Name;
                        if (!File.Exists(File_Name))
                        {
                            App_Icon_Generator app_Icon_Generator = new App_Icon_Generator();
                            string url = app_Icon_Generator.Icon_Url_Search(device_Info.App_List[i].Package);
                            if (url != "")
                            {
                                app_Icon_Generator.Icon_DounLoad(device_Info.App_List[i].Package, url);
                            }
                        }
                    }
                    this.Close();
                    break;
            }
        }

        private bool ADB_Connect()
        {
            Match mh;
            Shell Shell = new Shell();

            // TCPIP接続に切り替える
            Shell.Async_Comand("ADB_Tcpip", "\\adb.exe", " tcpip 5555");

//            // デバイスを切断
//            Shell.Async_Comand("ADB_Disconnect", "\\adb.exe", " disconnect");

            // デバイスを接続
            Shell.Async_Comand("ADB_Connect", "\\adb.exe", " connect " + device_Info.IP_Adress + ":5555");
            mh = Regex.Match(Shell.Output_Results, @"connected to.*", RegexOptions.None);
            if (!mh.Success)
            {
                return false;
            }
            return true;
        }

        private void GET_App_List(string Data)
        {
            device_Info.App_List.Clear();
            Match mh;
            foreach (var line in Data.AsSpan().EnumerateLines())
            {
                mh = Regex.Match(line.ToString(), @"\s(-|\*)\s(?<App_Name>.+)\s+(?<Package>.+)", RegexOptions.None);
                if (mh.Success)
                {
                    App_Info app_Info = new App_Info();
                    app_Info.Name = mh.Groups["App_Name"].Value.Trim();
                    app_Info.Package = mh.Groups["Package"].Value.Trim();
                    device_Info.App_List.Add(app_Info);
                }
            }
        }

        private string scrcpy_Option()
        {
            string option = " --keyboard=sdk --gamepad=uhid";

            option = option +
                        op_full_screen() +
                        op_window_borderless() +
                        op_Disable_Screensaver() +

                        op_video_size() +
                        op_video_bps() +
                        op_video_fps() +
                        op_video_buffer() +
                        op_audio_bps() +
                        op_audio_buffer() +

                        op_Disable_Sleep() +
                        op_Tap_Display() +

                        op_Start_App() +
                        op_Start_Rec();
            return option;
        }

        private string op_full_screen()
        {
            bool full_screen = Setting.Main.preset_list[Setting.Main.preset_select_no].windows_full_screen;
            string option = "";
            if (full_screen == true)
            {
                option = " --fullscreen";
            }
            return option;
        }
        private string op_window_borderless()
        {
            bool window_borderless = Setting.Main.preset_list[Setting.Main.preset_select_no].windows_borderless;
            string option = "";
            if (window_borderless == true)
            {
                option = " --window-borderless";
            }
            return option;
        }
        private string op_Disable_Screensaver()
        {
            bool Disable_Screensaver = Setting.Main.preset_list[Setting.Main.preset_select_no].windows_Disable_Screensaver;
            string option = "";
            if (Disable_Screensaver == true)
            {
                option = " --disable-screensaver";
            }
            return option;
        }
        private string op_video_size()
        {
            string video_size = Setting.Main.preset_list[Setting.Main.preset_select_no].video_size;
            string option = "";
            if (video_size != "default")
            {
                option = " --max-size=" + video_size;
            }
            return option;
        }
        private string op_video_bps()
        {
            string video_bps = Setting.Main.preset_list[Setting.Main.preset_select_no].video_bps;
            string option = "";
            if (video_bps != "default")
            {
                option = " --video-bit-rate=" + video_bps;
            }
            return option;
        }
        private string op_video_fps()
        {
            string video_fps = Setting.Main.preset_list[Setting.Main.preset_select_no].video_fps;
            string option = "";
            if (video_fps != "default")
            {
                option = " --max-fps=" + video_fps;
            }
            return option;
        }
        private string op_video_buffer()
        {
            string video_buffer = Setting.Main.preset_list[Setting.Main.preset_select_no].video_buffer;
            string option = "";
            if (video_buffer != "default")
            {
                option = " --video-buffer=" + video_buffer;
            }
            return option;
        }
        private string op_audio_bps()
        {
            string audio_bps = Setting.Main.preset_list[Setting.Main.preset_select_no].audio_bps;
            string option = "";
            if (audio_bps != "default")
            {
                option = " --audio-bit-rate=" + audio_bps;
            }
            return option;
        }
        private string op_audio_buffer()
        {
            string audio_buffer = Setting.Main.preset_list[Setting.Main.preset_select_no].audio_buffer;
            string option = "";
            if (audio_buffer != "default")
            {
                option = " --audio-buffer=" + audio_buffer;
            }
            return option;
        }
        private string op_Disable_Sleep()
        {
            bool Disable_Sleep = Setting.Main.preset_list[Setting.Main.preset_select_no].Disable_Sleep;
            string option = "";
            if (Disable_Sleep == true)
            {
                option = " --stay-awake";
            }
            return option;
        }
        private string op_Tap_Display()
        {
            bool Tap_Display = Setting.Main.preset_list[Setting.Main.preset_select_no].Tap_Display;
            string option = "";
            if (Tap_Display == true)
            {
                option = " --show-touches";
            }
            return option;
        }
        private string op_Start_App()
        {
            bool Start_App = Setting.Main.select_Device_Info.App_Start;
            string option = "";
            if (Start_App == true)
            {
                option = " --start-app=" + Setting.Main.select_Device_Info.App_Start_Info.Package;
            }
            return option;
        }
        private string op_Start_Rec()
        {
            bool Start_Rec = Setting.Main.Rec_Start;
            string option = "";
            if (Start_Rec == true)
            {
                DateTime dt = DateTime.Now;
                string File_Name = dt.ToString($"{dt:yyyyMMddHHmmss}");
                option = @" --record=""" + Setting.Main.Rec_path + "\\" + Setting.Main.select_Device_Info.Model_Name + "_" + File_Name + @".mp4""";
                Debug.WriteLine(option);
            }
            return option;
        }
    }
}
