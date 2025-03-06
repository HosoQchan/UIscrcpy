using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Runtime.Intrinsics.X86;
using System.Windows.Forms;
using static System.Runtime.CompilerServices.RuntimeHelpers;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UIscrcpy
{
    public partial class Controller : Form
    {
        static public Controller _Controller = null;
        static public IntPtr ControllerPtr = IntPtr.Zero;

        private Form_Shortcut_Key Form_Shortcut_Key = null;
        private Command command = new Command();

        private readonly int Bottun_Size = 32;
        static public Size Now_Size = new Size();

        private Size Default_Size = new Size(60, 370);
        private Point Move_Point;
        private System.Windows.Forms.ToolTip myToolTip = new System.Windows.Forms.ToolTip();

        public Controller()
        {
            InitializeComponent();
            this.Icon = new Icon(".\\Resources\\Icon\\Pcm.ico");
            string DesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            InitButton();
            InitFormSizeAndLocation();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// コントローラーボタンを初期化
        /// </summary>
        void InitButton()
        {
            foreach (var btnName in ControllerButton)
            {
                PictureBox pictureBox = new PictureBox();
                System.Drawing.Image img = System.Drawing.Image.FromFile(Button_Image[btnName]);
                pictureBox.Name = btnName;
                pictureBox.Image = img;
                pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox.Size = new Size(Bottun_Size, Bottun_Size);

                System.Windows.Forms.ToolTip _ToolTip = new System.Windows.Forms.ToolTip();
                _ToolTip.AutomaticDelay = 0;
                _ToolTip.IsBalloon = true;
                _ToolTip.ShowAlways = true;
                _ToolTip.Active = true;
                _ToolTip.SetToolTip(pictureBox, Button_Tip[btnName]);

                pictureBox.Click += PictureBox_Click;

                flowLayoutPanel.Controls.Add(pictureBox);
            }
        }

        /// <summary>
        /// ウィンドウのサイズと位置を初期化
        /// </summary>
        void InitFormSizeAndLocation()
        {
            if (Setting.Main.select_Device_Info.Controller.Width >= Default_Size.Width && Setting.Main.select_Device_Info.Controller.Height >= Default_Size.Width)
            {
                Width = Setting.Main.select_Device_Info.Controller.Width;
                Height = Setting.Main.select_Device_Info.Controller.Height;
            }
            else
            {
                this.Size = Default_Size;
            }

            if (Setting.Main.select_Device_Info.Controller.PointX + Setting.Main.select_Device_Info.Controller.PointY > 0)
            {
                StartPosition = FormStartPosition.Manual;
                Location = new Point((Setting.Main.select_Device_Info.Controller.PointX - Default_Size.Width), Setting.Main.select_Device_Info.Controller.PointY);
            }
            else
            {
                StartPosition = FormStartPosition.CenterScreen;
            }
            Now_Size = this.Size;

            // コントローラのサイズが変更された時のイベント
            SizeChanged += (sender, e) =>
            {
                if (this.Size.Width < Default_Size.Width)
                {
                    Width = Default_Size.Width;
                }
                if (this.Size.Height < Default_Size.Width)
                {
                    Height = Default_Size.Width;
                }
                Setting.Main.select_Device_Info.Controller.Width = Width;
                Setting.Main.select_Device_Info.Controller.Height = Height;
                Now_Size = this.Size;
            };

            // コントローラの位置とサイズの変更がされた後のイベント
            ResizeEnd += (sender, e) =>
            {
                if (Controller.ControllerPtr != IntPtr.Zero)
                {
                    // WinAPIを使用してコントローラーの位置を更新する
                    int Point_x = Setting.Main.select_Device_Info.Scrcpy.PointX - (Controller.Now_Size.Width);
                    int Point_y = Setting.Main.select_Device_Info.Scrcpy.PointY;
                    Setting.Main.select_Device_Info.Controller.PointX = Point_x;
                    Setting.Main.select_Device_Info.Controller.PointY = Point_y;
                    MoveListener.SetWindowPos(Controller.ControllerPtr, IntPtr.Zero, Point_x, Point_y, 0, 0, MoveListener.SWP_NOSIZE | MoveListener.SWP_NOZORDER | MoveListener.SWP_NOACTIVATE);
                }
            };
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            PictureBox pictureBox = (PictureBox)sender;
            Shell Shell = new Shell();
            string Option = "";
            switch (pictureBox.Name)
            {
                case "btnHelp":
                    Shortcut_Key_Show();
                    break;
                case "btnScreenshot":
                    Sound_Ctrl.Play(Sound_Ctrl.Click);
                    if (command.Screenshot())
                    {
                        string Msg = Lng.ini["Msg", "画像は以下のフォルダに保存されました。"];
                        Msg = Msg + "\r\n" + Setting.Rec_Path;
                        MBox mbox = new MBox(Lng.ini["Msg", "メッセージ"], "INFORMATION", Msg, "OK", "OK");
                        mbox.ShowDialog();
                    }
                    break;
                default:
                    Sound_Ctrl.Play(Sound_Ctrl.Click);
                    string KeyCode = Button_KeyCode[pictureBox.Name.Remove(0, 3)].ToString();
                    command.KeyCode("input keyevent " + KeyCode);
                    break;
            }
        }

        private void Shortcut_Key_Show()
        {
            try
            {
                // fm2が存在しない、または破棄されているかを確認。
                if (Form_Shortcut_Key == null || Form_Shortcut_Key.IsDisposed)
                {

                    Form_Shortcut_Key = new Form_Shortcut_Key();
                    Form_Shortcut_Key.Show(this);
                }
                else
                {
                    // fm2が縮小化されている場合には、通常時の大きさに戻します。
                    if (Form_Shortcut_Key.WindowState == FormWindowState.Minimized)
                    {
                        Form_Shortcut_Key.WindowState = FormWindowState.Normal;
                    };
                    Form_Shortcut_Key.Activate();
                }
            }
            catch (Exception ex)
            {
                //                MessageBox.Show(ex.ToString());
            }
            finally
            {

            }
        }

        /// <summary>
        /// コントローラーのボタン名と順番
        /// </summary>
        private List<string> ControllerButton
        {
            get
            {
                return new List<string>()
                {
                    "btnHelp",
                    "btnPower",
                    "btnScreenshot",
                    "btnHome",
                    "btnBack",
                    "btnMenu",
                    "btnVolumeUp",
                    "btnVolumeDown",
                    "btnMute",
                    //"btnBrowser",
                };
            }
        }
        private Dictionary<string, string> Button_Tip = new Dictionary<string, string>()
        {
            {"btnHelp",Lng.ini["Main", "ショートカットの一覧"]},
            {"btnHome",Lng.ini["Main", "ホーム"]},
            {"btnBack",Lng.ini["Main", "戻る"]},
            {"btnMenu",Lng.ini["Main", "メニュー"]},
            {"btnScreenshot",Lng.ini["Main", "スクリーンショット"]},
            {"btnVolumeUp",Lng.ini["Main", "音量＋"]},
            {"btnVolumeDown",Lng.ini["Main", "音量－"]},
            {"btnMute",Lng.ini["Main", "消音"]},
            {"btnPower",Lng.ini["Main", "電源"]},
            //"btnBrowser",
        };
        private Dictionary<string, string> Button_Image = new Dictionary<string, string>()
        {
            {"btnHelp",".\\Resources\\Image\\Controller\\Help.png"},
            {"btnHome",".\\Resources\\Image\\Controller\\Home.png"},
            {"btnBack",".\\Resources\\Image\\Controller\\Back.png"},
            {"btnMenu",".\\Resources\\Image\\Controller\\Menu.png"},
            {"btnScreenshot",".\\Resources\\Image\\Controller\\Camera.png"},
            {"btnVolumeUp",".\\Resources\\Image\\Controller\\Vol_High.png"},
            {"btnVolumeDown",".\\Resources\\Image\\Controller\\Vol_Medium.png"},
            {"btnMute",".\\Resources\\Image\\Controller\\Vol_Off.png"},
            {"btnPower",".\\Resources\\Image\\Controller\\Power.png"},
            //"btnBrowser",
        };
        private Dictionary<string, int> Button_KeyCode = new Dictionary<string, int>()
        {
            {"Home",3},               // ホーム
            {"Back",4},               // 戻る
            {"Call",5},               // 電話
            {"HangUp",6},             // 電話を切る
            {"VolumeUp",24},          // 音量＋
            {"VolumeDown",25},        // 音量－
            {"Power",26},             // 電源
            {"TakePicture",27},       // 写真を撮る（カメラアプリで撮影する必要があります）
            {"Browser",64},           // ブラウザを開く
            {"Menu",82},              // メニュー
            {"Pause",85},             // 再生/一時停止
            {"Stop",86},              // 停止
            {"Next",87},              // 次の曲
            {"Previous",88},          // 前の曲
            // xxxx = 122,            // リストの先頭に移動
            // xxxx = 123,            // リストの末尾に移動
            // xxxx = 126,            // 再生を再開
            // xxxx = 127,            // 再生を一時停止
            {"Mute",164},             // ミュート
            // xxxx = 176,            // システム設定
            // xxxx = 187,            // アプリの切り替え
            // xxxx = 207,            // 連絡先
            // xxxx = 208,            // カレンダー
            // xxxx = 209,            // ミュージックプレイヤー
            // xxxx = 210,            // 電卓
            // xxxx = 220,            // 画面の明るさ－
            // xxxx = 221,            // 画面の明るさ＋
            // xxxx = 223,            // システムを休止
            // xxxx = 224,            // 画面を明るくする
            // xxxx = 231,            // 音声ガイド
            // xxxx = 276,            // ウェイクロックがない場合、システムをスリープ状態にする
        };

        private void flowLayoutPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Move_Point = e.Location;
            }
        }

        private void flowLayoutPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int xDiff = e.Location.X - Move_Point.X;
                int yDiff = e.Location.Y - Move_Point.Y;

                // 名前でハンドルを取得する
                IntPtr hwnd = MoveListener.FindWindow(null, Setting.Main.select_Device_Info.Model_Name);
                if (hwnd != IntPtr.Zero)
                {
                    // WinAPIを使用してScrcpyの位置を更新する
                    int Point_x = Setting.Main.select_Device_Info.Scrcpy.PointX + xDiff;
                    int Point_y = Setting.Main.select_Device_Info.Scrcpy.PointY + yDiff;
                    Setting.Main.select_Device_Info.Scrcpy.PointX = Point_x;
                    Setting.Main.select_Device_Info.Scrcpy.PointY = Point_y;
                    MoveListener.SetWindowPos(hwnd, IntPtr.Zero, Point_x, Point_y, 0, 0, MoveListener.SWP_NOSIZE | MoveListener.SWP_NOZORDER | MoveListener.SWP_NOACTIVATE);
                }
            }
        }

        private void flowLayoutPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Move_Point = Point.Empty;
            }
        }
    }
}
