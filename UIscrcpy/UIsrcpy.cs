using Microsoft.WindowsAPICodePack.Dialogs;
using MS.WindowsAPICodePack.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using static Microsoft.WindowsAPICodePack.Shell.PropertySystem.SystemProperties.System;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace UIscrcpy
{
    public partial class UIsrcpy : Form
    {
        private const string GitHub_csproj_URL = "https://github.com/HosoQchan/UIscrcpy/blob/master/UIscrcpy/UIscrcpy.csproj";
        static public string This_Version = "";
        static public string GitHub_Version = "";

        private Shell Shell = new Shell();
        private bool Form_Loard = false;
        private string Scrcpy_Folder = "";

        public UIsrcpy()
        {
            InitializeComponent();
            this.Icon = new Icon(".\\icon\\UIscrcpy.ico");

            string key;
            for (int i = 0; i < Setting.preset.Count; i++)
            {
                key = Setting.preset.FirstOrDefault(kvp => kvp.Value == i).Key;
                Cbox_preset.Items.Add(key);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            This_Version = This_Ver();
            GitHub_Version = GitHub_Ver(GitHub_csproj_URL);

            Setting setting = new Setting();
            setting.Setting_Main_Create();
            Setting_Init();

            this.Shown += new EventHandler(Form_Shown);
            Form_Loard = true;
        }

        //Formが表示されたら発生するイベント
        private void Form_Shown(object sender, EventArgs e)
        {
            /*
            if ((GitHub_Version == "") || (This_Version != GitHub_Version))
            {
                Form_Version form_Version = new Form_Version();
                form_Version.ShowDialog();
            }
            */
        }

        private void Setting_Init()
        {
            TextBox_Scrcpy_Folder.Text = Setting.Main.scrcpy_path;
            Cbox_preset.SelectedIndex = Setting.Main.preset_select_no;

            TextBox_Rec_Folder.Text = Setting.Main.Rec_path;
            CheckB_Rec.Checked = Setting.Main.Rec_Start;
            Device_List_Init();
        }

        private void Device_List_Init()
        {
            string Model_Name = "";
            string Text_Back = Cbox_Device.Text;
            Cbox_Device.Items.Clear();
            for (int i = 0; i < Setting.Main.Device_List.Count; i++)
            {
                Model_Name = Setting.Main.Device_List[i].Model_Name;
                Cbox_Device.Items.Add(Model_Name);
            }
            Cbox_Device.Text = Setting.Main.select_Device_Info.Model_Name;
            Device_Change();
        }

        private void Device_Change()
        {
            Form_Loard = false;
            int List_No = Device_List_Check(Cbox_Device.Text);
            if (List_No >= 0)
            {
                Setting.Main.select_Device_Info = Setting.Main.Device_List[List_No];
                Cbox_Device.Text = Setting.Main.select_Device_Info.Model_Name;
                Cbox_Device.SelectedIndex = ComBox_Index_Get(Cbox_Device);
            }

            if (Cbox_Device.Text == "")
            {
                Button_App_List.Enabled = false;
                Button_USB_Start.Enabled = false;
                Button_WIFI_Start.Enabled = false;
            }
            else
            {
                Button_App_List.Enabled = true;
                Button_USB_Start.Enabled = true;
                Button_WIFI_Start.Enabled = true;
            }

            TextBox_App_Name.Text = Setting.Main.select_Device_Info.App_Start_Info.Name;
            CheckB_App_Start.Checked = Setting.Main.select_Device_Info.App_Start;
            Select_App_Change();
            Form_Loard = true;
        }

        private void Select_App_Change()
        {
            Form_Loard = false;

            if (TextBox_App_Name.Text == "")
            {
                CheckB_App_Start.Checked = false;
                CheckB_App_Start.Enabled = false;
            }
            else
            {
                CheckB_App_Start.Enabled = true;
            }
            Form_Loard = true;
        }

        private void Button_Scrcpy_FolderSel_Click(object sender, EventArgs e)
        {
            //初期フォルダ名を設定する場合はここにセットする
            string dir = TextBox_Scrcpy_Folder.Text;

            //フォルダ参照ダイアログを開く、キャンセルの場合は関数から抜ける
            if (GetDirNameFromCommonOpenFileDialog(ref dir) == false) return;

            //取得したフォルダ名をテキストボックスにセットする
            TextBox_Scrcpy_Folder.Text = dir;
            Setting.Main.scrcpy_path = TextBox_Scrcpy_Folder.Text;
        }

        private void Button_Rec_FolderSel_Click(object sender, EventArgs e)
        {
            //初期フォルダ名を設定する場合はここにセットする
            string dir = TextBox_Scrcpy_Folder.Text;

            //フォルダ参照ダイアログを開く、キャンセルの場合は関数から抜ける
            if (GetDirNameFromCommonOpenFileDialog(ref dir) == false) return;

            //取得したフォルダ名をテキストボックスにセットする
            TextBox_Rec_Folder.Text = dir;
            Setting.Main.Rec_path = TextBox_Rec_Folder.Text;
        }

        private void Button_Rec_FolderOpen_Click(object sender, EventArgs e)
        {
            if (Directory.Exists(TextBox_Rec_Folder.Text))
            {
                //フォルダを開く
                System.Diagnostics.Process.Start("EXPLORER.EXE", TextBox_Rec_Folder.Text);
            }
            else
            {
                MessageBox.Show("フォルダが見つかりません。\r\n正しいフォルダを選択して下さい。", "メッセージ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// フォルダ参照ダイアログを呼び出してパスを取得する
        /// </summary>
        /// <param name="select_path">初期パス(in)/選択パス(out)</param>
        /// <returns>true/false</returns>
        private bool GetDirNameFromCommonOpenFileDialog(ref string select_path)
        {
            using (var dlg = new CommonOpenFileDialog())
            {
                // フォルダ選択ダイアログ（falseにするとファイル選択ダイアログ）
                dlg.IsFolderPicker = true;
                dlg.Title = "フォルダを選択してください。";
                dlg.DefaultDirectory = select_path;

                if (dlg.ShowDialog() != CommonFileDialogResult.Ok)
                {
                    return false;
                }

                //開く以外を選択された場合はfalseを返す。
                select_path = dlg.FileName;

            }
            return true;
        }

        private void Button_PresetEdit_Click(object sender, EventArgs e)
        {
            Edit_Preset Form = new Edit_Preset();
            Form.ShowDialog(this);
            Form.Dispose();
        }

        private void Button_App_List_Click(object sender, EventArgs e)
        {
            if (Setting.Main.select_Device_Info.Model_Name == "")
            {
                // エラーメッセージを表示する
                MessageBox.Show("端末が選択されていません。", "メッセージ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            Form_App_List form_App_List = new Form_App_List();
            form_App_List.App_Info = Setting.Main.select_Device_Info.App_Start_Info;

            form_App_List.ShowDialog(this);
            if (Setting.Main.select_Device_Info.App_Start_Info.Name != form_App_List.App_Info.Name)
            {
                Setting.Main.select_Device_Info.App_Start_Info = form_App_List.App_Info;
                TextBox_App_Name.Text = Setting.Main.select_Device_Info.App_Start_Info.Name;
                Select_App_Change();
            }
            form_App_List.Dispose();
        }

        private void Button_WIFI_Start_Click(object sender, EventArgs e)
        {
            if (op_Start_Rec_Check())
            {
                Connection_Start("WIFI");
            }
        }

        private void Button_USB_Start_Click(object sender, EventArgs e)
        {
            if (op_Start_Rec_Check())
            {
                Connection_Start("USB");
            }
        }

        private void Connection_Start(string Mode)
        {
            Device_Connection device_Connection = new Device_Connection();
            device_Connection.Mode = 2;
            device_Connection.Serial = Mode;
            device_Connection.device_Info = Setting.Main.select_Device_Info;
            device_Connection.ShowDialog();
            if (device_Connection.Error)
            {
                // エラーメッセージを表示する
                MessageBox.Show("接続を認識できませんでした。", "メッセージ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            string Serial = "";
            if (Mode == "USB")
            {
                Serial = Setting.Main.select_Device_Info.Serial;
            }
            else
            {
                Serial = Setting.Main.select_Device_Info.IP_Adress + ":5555";
            }
            Thread.Sleep(500);
            Shell Shell = new Shell();
            Shell.Async_Comand2("scrcpy_Connect", "\\scrcpy.exe", " --serial=" + Serial + scrcpy_Option());
        }

        private bool op_Start_Rec_Check()
        {
            if (!Setting.Command_File_Check())
            {
                return false;
            }
            if (Setting.Main.Rec_Start)
            {
                if (!Directory.Exists(TextBox_Rec_Folder.Text))
                {
                    MessageBox.Show("録画の保存用フォルダが見つかりません。\r\n正しいフォルダを選択して下さい。", "メッセージ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            return true;
        }

        private void Button_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button_Device_List_Click(object sender, EventArgs e)
        {
            Device_Manager Form = new Device_Manager();
            Form.ShowDialog(this);
            Form.Dispose();
            Device_List_Init();
        }

        private void UIsrcpy_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void UIsrcpy_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Directory.Exists(TextBox_Scrcpy_Folder.Text))
            {
                Setting.Main.scrcpy_path = TextBox_Scrcpy_Folder.Text;
            }
            if (Directory.Exists(TextBox_Rec_Folder.Text))
            {
                Setting.Main.Rec_path = TextBox_Rec_Folder.Text;
            }

            for (int i = 0; i < Setting.Main.Device_List.Count; i++)
            {
                if (Setting.Main.select_Device_Info.Serial == Setting.Main.Device_List[i].Serial)
                {
                    Setting.Main.Device_List[i] = Setting.Main.select_Device_Info;
                    break;
                }
            }

            Setting setting = new Setting();
            setting.Main_save();
        }

        private void Cbox_preset_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Form_Loard)
            {
                Setting.Main.preset_select_no = Cbox_preset.SelectedIndex;
            }
        }

        private void Cbox_Device_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Form_Loard)
            {

                Device_Change();
            }
        }

        private void CheckB_App_Start_CheckedChanged(object sender, EventArgs e)
        {
            if (Form_Loard)
            {
                Setting.Main.select_Device_Info.App_Start = CheckB_App_Start.Checked;
            }
        }

        private void CheckB_Rec_CheckedChanged(object sender, EventArgs e)
        {
            if (Form_Loard)
            {
                Setting.Main.Rec_Start = CheckB_Rec.Checked;
            }
        }

        // 指定されたデバイスがリストに存在するか
        static public int Device_List_Check(string Model_Name)
        {
            int List_No = -1;
            for (int i = 0; i < Setting.Main.Device_List.Count; i++)
            {
                if (Setting.Main.Device_List[i].Model_Name == Model_Name)
                {
                    List_No = i;
                    break;
                }
            }
            return List_No;
        }

        // ComboBoxのTextデータに一致する項目(Index値)を取得する
        static public int ComBox_Index_Get(System.Windows.Forms.ComboBox Cbox)
        {
            int index = -1;
            for (int i = 0; i < Cbox.Items.Count; ++i)
            {
                if (Cbox.Items[i].Equals(Cbox.Text))
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        private string This_Ver()
        {
            var assemblyName = Assembly.GetExecutingAssembly().GetName();
            var n1 = assemblyName.Name;    // "アセンブリ名"
            var v1 = assemblyName.Version; // "1.0.0.0"
            return v1.ToString();
        }

        private string GitHub_Ver(string URL)
        {
            string Text = "";
            /*
            try
            {
                //WebClientを作成
                System.Net.WebClient wc = new System.Net.WebClient();
                //文字コードを指定
                wc.Encoding = System.Text.Encoding.UTF8;
                //データを文字列としてダウンロードする
                Text = wc.DownloadString(URL);
                //後始末
                wc.Dispose();
            }
            catch (Exception e)
            {
                // URLのファイルが見つからない等のエラーが発生
                Debug.WriteLine("URLが見つかりません。");
                return "";
            }

            Match mh;
            mh = Regex.Match(Text, @"<AssemblyVersion>(?<Ver_No>.*?)</AssemblyVersion>", RegexOptions.None);
            if (mh.Success)
            {
                return mh.Groups["Ver_No"].Value;
            }
            else
            {
                return "";
            }
            */
            return Text;
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
                string File_Name = dt.ToString($"{dt:yyyyMMddHHmmssfff}");
                option = @" --record=""" + Setting.Main.Rec_path + "\\" + Setting.Main.select_Device_Info.Model_Name + "_" + File_Name + @".mp4""";
                Debug.WriteLine(option);
            }
            return option;
        }

        private void Button_About_Click(object sender, EventArgs e)
        {
            Form_Version form_Version = new Form_Version();
            form_Version.ShowDialog();
        }
    }
}
