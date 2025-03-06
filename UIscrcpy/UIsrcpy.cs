using Microsoft.WindowsAPICodePack.Dialogs;
using MS.WindowsAPICodePack.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Resources;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using UIscrcpy.Properties;
using static Microsoft.WindowsAPICodePack.Shell.PropertySystem.SystemProperties.System;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace UIscrcpy
{
    public partial class UIsrcpy : Form
    {
        private const string Ver_File_URL = "https://github.com/HosoQchan/UIscrcpy";
        static public string This_Version = "";
        static public string GitHub_Version = "";
        static public string DatetimeFormat = "yyyyMMddHHmmss";
        static public Process Process_Scrcpy = new Process();

        private Command command = new Command();
        private Scrcpy_Option scrcpy_option = new Scrcpy_Option();

        private bool Form_Loard = false;
        private string Scrcpy_Folder = "";

        static public bool Connect_USB = false;
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        private bool USB_Connect_Flag = false;

        public class Info
        {
            // プログラム名
            public const string Name = "UIsrcpy";
            // プログラム名とバージョン番号
            public static readonly string NameVersion = $"{Name} v{Program.Version}";
        }

        public UIsrcpy()
        {
            InitializeComponent();

            This_Version = This_Ver();
            GitHub_Version = GitHub_Ver(Ver_File_URL);

            this.Icon = new Icon(".\\Resources\\Icon\\UIscrcpy.ico");
            Button_WIFI_Start.BackgroundImage = System.Drawing.Image.FromFile(".\\Resources\\Image\\WiFi.png");
            Button_USB_Start.BackgroundImage = System.Drawing.Image.FromFile(".\\Resources\\Image\\USB.png");

            Setting setting = new Setting();
            setting.Setting_Main_Load();

            Lng.Language_Init();
            Language_List_Init();
            Language_Display_Refresh();

            // ＵＳＢの接続・切断監視用タイマー
            timer.Interval = 1000;      // 1s
        }

        private void Language_Display_Refresh()
        {
            Label_Language.Text = Lng.ini["Main", "言語"];
            Label_Scrcpy_Folder_Info.Text = Lng.ini["Main", "scrcpyのフォルダを選択して下さい。"];
            Label_Folder.Text = Lng.ini["Main", "フォルダ"];
            Label_Rec_Info.Text = Lng.ini["Main", "スクリーンショット及び録画の保存用フォルダを選択して下さい。"];
            Label_Rec_Folder_Info.Text = Lng.ini["Main", "フォルダ"];
            Label_Preset.Text = Lng.ini["Main", "プリセット"];
            Label_Terminal_Info.Text = Lng.ini["Main", "最初に端末の【登録】を行って下さい。"];
            Label_Terminal.Text = Lng.ini["Main", "接続する端末"];
            Label_Start.Text = "";

            GBox_Shortcut.Text = Lng.ini["Main", "ショートカットキー[option]"];
            GBox_Rec.Text = Lng.ini["Main", "保存用フォルダ"];
            GBox_Setting.Text = Lng.ini["Main", "設定"];
            GBox_Terminal.Text = Lng.ini["Main", "接続"];

            CheckB_App_Start.Text = Lng.ini["Main", "アプリを起動"];
            CheckB_Rec.Text = Lng.ini["Main", "録画"];

            Button_Scrcpy_FolderSel.Text = Lng.ini["Main", "選択"];
            Button_Rec_FolderOpen.Text = Lng.ini["Main", "開く"];
            Button_Rec_FolderSel.Text = Lng.ini["Main", "選択"];
            Button_PresetEdit.Text = Lng.ini["Main", "編集"];
            Button_Device_List.Text = Lng.ini["Main", "登録/削除"];
            Button_App_List.Text = Lng.ini["Main", "選択"];
            Button_Close.Text = Lng.ini["Main", "終了"];

            Label_Start_Button();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Form_Waiting_Command connect_Device = new Form_Waiting_Command("UIscrcpy");
            connect_Device.Show();

            Setting_Init();
            Sound_Ctrl.Initialize();

            connect_Device.Dispose();

            this.Shown += new EventHandler(Form_Shown);
            Form_Loard = true;
        }
       
        //Formが表示されたら発生するイベント
        private void Form_Shown(object sender, EventArgs e)
        {
            USB_Connect_Flag = true;

            timer.Stop();
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        // ＵＳＢの接続・切断制御用タイマー
        private void Timer_Tick(System.Object sender,EventArgs e)
        {
            if ((USB_Connect_Flag) && (this.ContainsFocus))
            {
                USB_Connect_Flag = false;
                // ＵＳＢの接続・切断制御
                USB_Connect_Check();
            }
        }

        // ＵＳＢの接続・切断イベント
        enum WINDOW_MESSAGES : uint
        {
            WM_DEVICECHANGE = 0x0219,
        }
        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            switch ((WINDOW_MESSAGES)m.Msg)
            {
                case WINDOW_MESSAGES.WM_DEVICECHANGE:
                    if ((this.ContainsFocus) && (Form_Loard))
                    {
                        USB_Connect_Flag = true;
                    }
                    break;
            }
            base.WndProc(ref m);
        }

        // ＵＳＢの接続・切断制御
        private void USB_Connect_Check()
        {
            Device_Info device_info = new Device_Info();
            device_info = command.Device_Info();
            if (device_info.Model_Name != "")
            {
                int List_No = Device_List_Check(device_info.Model_Name);
                // USB接続されている端末が、登録リストに存在する場合は、その端末を選択する
                Form_Loard = false;
                if (List_No >= 0)
                {
                    Setting.Main.select_Device_Info = Setting.Main.Device_List[List_No];
                    Cbox_Device.Text = Setting.Main.select_Device_Info.Model_Name;
                    Cbox_Device.SelectedIndex = ComBox_Index_Get(Cbox_Device);

                    // ＵＳＢ・ＷｉＦｉボタンの有効／無効制御
                    USB_WiFi_Button_Handle();

                    TextBox_App_Name.Text = Setting.Main.select_Device_Info.App_Start_Info.Name;
                    CheckB_App_Start.Checked = Setting.Main.select_Device_Info.App_Start;
                    Select_App_Change();
                }
                // USB接続されている端末が、登録リストに存在しない場合は、登録処理に移行する
                else
                {
                    string Msg = Lng.ini["Msg", "新しい端末が検出されました。登録しますか？"];
                    MBox mbox = new MBox(Lng.ini["Msg", "確認"], "QUESTION", Msg, "YesNo", "No");
                    mbox.ShowDialog();
                    if (mbox.Result == "Yes")
                    {

                        Msg = Lng.ini["Msg", "このデバイスをWiFi接続しますか？"];
                        mbox = new MBox(Lng.ini["Msg", "確認"], "QUESTION", Msg, "YesNo", "Yes");
                        mbox.ShowDialog();
                        if (mbox.Result == "No")
                        {
                            Form_Device_Disp Form_device_Disp = new Form_Device_Disp();
                            Form_device_Disp.device_Info = device_info;
                            Form_device_Disp.ShowDialog();
                        }
                        else
                        {
                            Form_Device_Regist form_device_regist = new Form_Device_Regist(9);
                            form_device_regist.device_info = device_info;
                            form_device_regist.ShowDialog();
                        }
                        Form_Device_List form_device_list = new Form_Device_List();
                        form_device_list.ShowDialog(this);
                        Device_List_Init();
                    }
                }
                Form_Loard = true;
            }
            else
            {
                Button_USB_Start.Visible = false;
                Label_Start_Button();
            }
        }

        // 表示の初期化
        private void Setting_Init()
        {
            string key;
            for (int i = 0; i < Setting.preset.Count; i++)
            {
                key = Setting.preset.FirstOrDefault(kvp => kvp.Value == i).Key;
                Cbox_preset.Items.Add(key);
            }

            Cbox_MODkey.Items.Clear();
            foreach (KeyValuePair<string, int> kvp in Setting.modkey)
            {
                Cbox_MODkey.Items.Add(kvp.Key);
            }

            TextBox_Scrcpy_Folder.Text = Setting.Main.Scrcpy_Path;
            Cbox_preset.SelectedIndex = Setting.Main.preset_select_no;

            Cbox_MODkey.Text = Setting.Main.Scrcpy_MODkey;
            Cbox_MODkey.SelectedIndex = UIsrcpy.ComBox_Index_Get(Cbox_MODkey);

            TextBox_Rec_Folder.Text = Setting.Main.Rec_path;
            CheckB_Rec.Checked = Setting.Main.Rec_Start;
            Device_List_Init();
        }

        // 表示の初期化(端末一覧)
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

        // 表示の初期化(言語設定)
        private void Language_List_Init()
        {
            CBox_Language.Items.Clear();
            string Name = "";
            if (Lng.Dirs != null)
            {
                foreach (string Files in Lng.Dirs)
                {
                    Name = Path.GetFileNameWithoutExtension(Files);
                    CBox_Language.Items.Add(Name);
                }
            }
            CBox_Language.Text = Setting.Main.Language;
            CBox_Language.SelectedIndex = ComBox_Index_Get(CBox_Language);

            Lng.Language_Load(Setting.Main.Language);
        }

        // 端末の選択が変更された時の処理
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
            // ＵＳＢ・ＷｉＦｉボタンの有効／無効制御
            USB_WiFi_Button_Handle();

            TextBox_App_Name.Text = Setting.Main.select_Device_Info.App_Start_Info.Name;
            CheckB_App_Start.Checked = Setting.Main.select_Device_Info.App_Start;
            Select_App_Change();
            Form_Loard = true;
        }

        // アプリの選択が変更された時の処理
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

        // ＵＳＢ・ＷｉＦｉボタンの有効／無効制御
        private void USB_WiFi_Button_Handle()
        {
            if (Cbox_Device.Text != "")
            {
                // 選択されている端末と、USB接続されている端末が同じ場合
                if (Cbox_Device.Text == command.Device_Info().Model_Name)
                {
                    Button_USB_Start.Visible = true;
                }
                // 選択されている端末と、USB接続されている端末が異なる場合
                else
                {
                    Button_USB_Start.Visible = false;
                }

                // 選択されている端末のＩＰアドレスが存在する場合
                if (Setting.Main.select_Device_Info.IP_Adress == "")
                {
                    Button_WIFI_Start.Visible = false;
                }
                // 選択されている端末のＩＰアドレスが存在しない場合
                else
                {
                    Button_WIFI_Start.Visible = true;
                }
            }
            else
            {
                Button_USB_Start.Visible = false;
                Button_WIFI_Start.Visible = false;
            }
            Label_Start_Button();
        }

        // ＵＳＢ・ＷｉＦｉボタンのどちらかが有効な場合、ボタンの隣に"開始"文字を表示する
        private void Label_Start_Button()
        {
            if ((Button_USB_Start.Visible == false) && (Button_WIFI_Start.Visible == false))
            {
                Label_Start.Text = "";
            }
            else
            {
                Label_Start.Text = Lng.ini["Main", "開始"];
            }
        }

        private void Button_Scrcpy_FolderSel_Click(object sender, EventArgs e)
        {
            //初期フォルダ名を設定する場合はここにセットする
            string dir = TextBox_Scrcpy_Folder.Text;

            //フォルダ参照ダイアログを開く、キャンセルの場合は関数から抜ける
            if (GetDirNameFromCommonOpenFileDialog(ref dir) == false) return;

            //取得したフォルダ名をテキストボックスにセットする
            TextBox_Scrcpy_Folder.Text = dir;
            Setting.Main.Scrcpy_Path = TextBox_Scrcpy_Folder.Text;
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
                string Msg = TextBox_Rec_Folder.Text + "\r\n" + Lng.ini["Msg", "フォルダが見つかりません。"];
                MBox mbox = new MBox(Lng.ini["Msg", "メッセージ"], "WARNING", Msg, "OK", "OK");
                mbox.ShowDialog();
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
                dlg.Title = Lng.ini["Msg", "フォルダを選択してください。"];
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
            Form_Edit_Preset Form = new Form_Edit_Preset();
            Form.ShowDialog(this);
            Form.Dispose();
        }

        private void Button_App_List_Click(object sender, EventArgs e)
        {
            if (Setting.Main.select_Device_Info.Model_Name == "")
            {
                // エラーメッセージを表示する

                string Msg = Lng.ini["Msg", "端末が選択されていません。"];
                MBox mbox = new MBox(Lng.ini["Msg", "メッセージ"], "WARNING", Msg, "OK", "OK");
                mbox.ShowDialog();
                //                MessageBox.Show(Lng.ini["Msg", "端末が選択されていません。"], Lng.ini["Msg", "メッセージ"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                Scrcpy_Start(false);
            }
        }

        private void Button_USB_Start_Click(object sender, EventArgs e)
        {
            if (op_Start_Rec_Check())
            {
                Scrcpy_Start(true);
            }
        }

        /// <summary>
        /// Scrcpyの起動
        /// </summary>
        /// <param name="USB"></param>
        public void Scrcpy_Start(bool USB)
        {
            Form_Handle(false);
            Form_Waiting_Command Connect_Disp;
            if (USB)
            {
                Connect_Disp = new Form_Waiting_Command("USB");
            }
            else
            {
                Connect_Disp = new Form_Waiting_Command("WiFi");
            }
            Connect_Disp.Show();

            Device_Info device_Info = new Device_Info();
            Match mh;
            string Command = Setting.Main.Scrcpy_Path + "\\scrcpy.exe";
            string Option = " --serial=";
            string Serial = "";
            // USB接続の場合
            if (USB)
            {
                // 端末情報を取得
                Serial = command.Device_Info().Serial;
                if (Serial != Setting.Main.select_Device_Info.Serial)
                {
                    // 接続エラー
                    Connect_Disp.Dispose();
                    Scrcpy_Error();
                    return;
                }
                Option = Option + Setting.Main.select_Device_Info.Serial;
            }
            // WiFi接続の場合
            else
            {
                Serial = Setting.Main.select_Device_Info.IP_Adress;
                if (!command.WiFi_Connect(Serial))
                {
                    // 接続エラー
                    Connect_Disp.Dispose();
                    Scrcpy_Error();
                    return;
                }
                Option = Option + Serial;
            }

            Option = Option + scrcpy_option.Option();

            ProcessStartInfo si = new ProcessStartInfo();
            // バッチファイルを起動する人は、cmd.exeさんなので
            si.FileName = "cmd.exe";

            // コマンド処理実行後、コマンドウィンドウ終わるようにする。
            si.Arguments = "/c ";

            // コマンドラインを指定
            if (Option != "")
            {
                Command = Command + Option;
            }
            si.Arguments = si.Arguments + Command;

            // エンコード指定
            si.StandardOutputEncoding = System.Text.Encoding.UTF8;

            // ウィンドウ表示を完全に消す
            si.CreateNoWindow = true;
            si.RedirectStandardError = true;
            si.RedirectStandardOutput = true;
            si.UseShellExecute = false;

            Process_Scrcpy = Process.Start(si);
            Process_Scrcpy.EnableRaisingEvents = true;

            var tempOutput = "";
            Process_Scrcpy.ErrorDataReceived += (ss, ee) =>
            {
                if (!string.IsNullOrWhiteSpace(ee.Data))
                {
                    Debug.WriteLine(ee.Data);
                    if (!ee.Data.Contains("ERROR"))
                    {
                        return;
                    }
                    if ((ee.Data.Contains("[server] ERROR")))
                    {
                        return;
                    }
                    if ((ee.Data.Contains("adb reverse")))
                    {
                        return;
                    }
                    // 接続エラー
                    Connect_Disp.Dispose();
                    Scrcpy_Error();
                }
            };
            Process_Scrcpy.OutputDataReceived += (ss, ee) =>
            {
                if (!string.IsNullOrWhiteSpace(ee.Data))
                {
                    tempOutput = ee.Data;
                    if (tempOutput.Contains("INFO: Device:"))
                    {
                        Connect_Disp.Dispose();

                        // 接続完了
                        Controll_Form_Handle(true);

                        // scrcpyウィンドウの動きを監視する
                        if (USB)
                        {
                            Connect_USB = true;
                        }
                        else
                        {
                            Connect_USB = false;
                            
                        }
                        MoveListener.StartListening();
                        return;
                    }
                }
            };

            // タスク(scrcpy)の終了
            void exitHandle()
            {
                MoveListener.StopListening();
                Controll_Form_Handle(false);

                // WiFi切断コマンドを送信する
                command.WiFi_Disconnect();

                if (CheckB_Rec.Checked)
                {
                    string Msg = Lng.ini["Msg", "録画は以下のフォルダに保存されました。"];
                    Msg = Msg + "\r\n" + Setting.Rec_Path;
                    MBox mbox = new MBox(Lng.ini["Msg", "メッセージ"], "INFORMATION", Msg, "OK", "OK");
                    mbox.ShowDialog();
                }
                return;
            }

            Process_Scrcpy.Exited += (ss, ee) => exitHandle();
            Process_Scrcpy.BeginErrorReadLine();
            Process_Scrcpy.BeginOutputReadLine();
        }

        private void Scrcpy_Error()
        {
            MoveListener.StopListening();
            Controll_Form_Handle(false);

            // エラーメッセージを表示する
            string Msg = Lng.ini["Msg", "接続できませんでした。"];
            MBox mbox = new MBox(Lng.ini["Msg", "メッセージ"], "WARNING", Msg, "OK", "OK");
            mbox.ShowDialog();
            return;
        }

        // コントローラの表示／非表示制御
        private void Controll_Form_Handle(bool isopen)
        {
            Action action = () =>
            {
                if (isopen)
                {
                    Form_Handle(false);
                    Controller._Controller = new Controller();
                    Controller.ControllerPtr = Controller._Controller.Handle;
                    Controller._Controller.Show();
                }
                else
                {
                    Form_Handle(true);
                    Controller._Controller?.Dispose();
                }
            };
            Invoke(action);
        }
        // フォームの表示／非表示制御
        private void Form_Handle(bool isopen)
        {
            Action action = () =>
            {
                if (isopen)
                {
                    Show();
                    Activate();
                    Focus();
                }
                else
                {
                    Hide();
                }
            };
            Invoke(action);
        }

        private bool op_Start_Rec_Check()
        {
            if (Setting.Main.select_Device_Info.Model_Name == "")
            {
                // エラーメッセージを表示する

                string Msg = Lng.ini["Msg", "端末が選択されていません。"];
                MBox mbox = new MBox(Lng.ini["Msg", "メッセージ"], "WARNING", Msg, "OK", "OK");
                mbox.ShowDialog();
                //                MessageBox.Show(Lng.ini["Msg", "端末が選択されていません。"], Lng.ini["Msg", "メッセージ"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (!Command_File_Check())
            {
                return false;
            }
            if (Setting.Main.Rec_Start)
            {
                if (!Directory.Exists(TextBox_Rec_Folder.Text))
                {
                    string Msg = TextBox_Rec_Folder.Text + "\r\n" + Lng.ini["Msg", "フォルダが見つかりません。"];
                    MBox mbox = new MBox(Lng.ini["Msg", "メッセージ"], "WARNING", Msg, "OK", "OK");
                    mbox.ShowDialog();
                    //                    MessageBox.Show(TextBox_Rec_Folder.Text + "\r\n" + Lng.ini["Msg", "フォルダが見つかりません。"], Lng.ini["Msg", "メッセージ"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
            }
            return true;
        }

        // Scrcpy関連のファイルが存在するかの確認
        static public bool Command_File_Check()
        {
            if (!Directory.Exists(Setting.Main.Scrcpy_Path))
            {
                string Msg = Setting.Main.Scrcpy_Path + "\r\n" + Lng.ini["Msg", "フォルダが見つかりません。"];
                MBox mbox = new MBox(Lng.ini["Msg", "メッセージ"], "WARNING", Msg, "OK", "OK");
                mbox.ShowDialog();
                //                MessageBox.Show(Setting.Main.Scrcpy.Path + "\r\n" + Lng.ini["Msg", "フォルダが見つかりません。"], Lng.ini["Msg", "メッセージ"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (!File.Exists(Setting.Main.Scrcpy_Path + "\\adb.exe"))
            {
                string Msg = Setting.Main.Scrcpy_Path + "\\adb.exe" + "\r\n" + Lng.ini["Msg", "ファイルが見つかりません。"];
                MBox mbox = new MBox(Lng.ini["Msg", "メッセージ"], "WARNING", Msg, "OK", "OK");
                mbox.ShowDialog();
                //                MessageBox.Show(Setting.Main.Scrcpy.Path + "\\adb.exe" + "\r\n" + Lng.ini["Msg", "ファイルが見つかりません。"], Lng.ini["Msg", "メッセージ"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (!File.Exists(Setting.Main.Scrcpy_Path + "\\scrcpy.exe"))
            {
                string Msg = Setting.Main.Scrcpy_Path + "\\scrcpy.exe" + "\r\n" + Lng.ini["Msg", "ファイルが見つかりません。"];
                MBox mbox = new MBox(Lng.ini["Msg", "メッセージ"], "WARNING", Msg, "OK", "OK");
                mbox.ShowDialog();
                //                MessageBox.Show(Setting.Main.Scrcpy.Path + "\\scrcpy.exe" + "\r\n" + Lng.ini["Msg", "ファイルが見つかりません。"], Lng.ini["Msg", "メッセージ"], MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        private void Button_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button_Device_List_Click(object sender, EventArgs e)
        {
            Form_Device_List Form = new Form_Device_List();
            Form.ShowDialog(this);
            if (Form.Edit_Flag)
            {
                Device_List_Init();
            }
        }

        private void UIsrcpy_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void Cbox_MODkey_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Form_Loard)
            {
                Setting.Main.Scrcpy_MODkey = Cbox_MODkey.Text;
            }
        }

        private void CBox_Language_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Form_Loard)
            {
                if (Setting.Main.Language != CBox_Language.Text)
                {
                    Setting.Main.Language = CBox_Language.Text;
                    Lng.Language_Load(Setting.Main.Language);
                    Language_Display_Refresh();
                }
            }
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

        private string GitHub_Ver(string Ver_File_URL)
        {
            string Text = "";
            try
            {

            }
            catch (Exception e)
            {
                // URLのファイルが見つからない等のエラーが発生
                Debug.WriteLine("URLが見つかりません。");
                return "";
            }

            Match mh;
            mh = Regex.Match(Text, @"v(?<Ver_No>.*?)", RegexOptions.None);
            if (mh.Success)
            {
                return mh.Groups["Ver_No"].Value;
            }
            else
            {
                return "";
            }
            return Text;
        }

        private void Button_About_Click(object sender, EventArgs e)
        {
            Form_Version form_Version = new Form_Version();
            form_Version.ShowDialog();
        }

        // プログラム終了時の処理
        private void UIsrcpy_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Directory.Exists(TextBox_Scrcpy_Folder.Text))
            {
                Setting.Main.Scrcpy_Path = TextBox_Scrcpy_Folder.Text;
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

            Shell.ADB_Kill();
            if (Shell.ShellProcess != null)
            {
                Shell.ShellProcess.Kill();
            }

            Setting setting = new Setting();
            setting.Main_save();
        }
    }
}
