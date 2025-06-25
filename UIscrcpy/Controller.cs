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
        /// �R���g���[���[�{�^����������
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
        /// �E�B���h�E�̃T�C�Y�ƈʒu��������
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

            // �R���g���[���̃T�C�Y���ύX���ꂽ���̃C�x���g
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

            // �R���g���[���̈ʒu�ƃT�C�Y�̕ύX�����ꂽ��̃C�x���g
            ResizeEnd += (sender, e) =>
            {
                if (Controller.ControllerPtr != IntPtr.Zero)
                {
                    // WinAPI���g�p���ăR���g���[���[�̈ʒu���X�V����
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
                        string Msg = Lng.ini["Msg", "�摜�͈ȉ��̃t�H���_�ɕۑ�����܂����B"];
                        Msg = Msg + "\r\n" + Setting.Rec_Path;
                        MBox mbox = new MBox(Lng.ini["Msg", "���b�Z�[�W"], "INFORMATION", Msg, "OK", "OK");
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
                // fm2�����݂��Ȃ��A�܂��͔j������Ă��邩���m�F�B
                if (Form_Shortcut_Key == null || Form_Shortcut_Key.IsDisposed)
                {

                    Form_Shortcut_Key = new Form_Shortcut_Key();
                    Form_Shortcut_Key.Show(this);
                }
                else
                {
                    // fm2���k��������Ă���ꍇ�ɂ́A�ʏ펞�̑傫���ɖ߂��܂��B
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
        /// �R���g���[���[�̃{�^�����Ə���
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
            {"btnHelp",Lng.ini["Main", "�V���[�g�J�b�g�̈ꗗ"]},
            {"btnHome",Lng.ini["Main", "�z�[��"]},
            {"btnBack",Lng.ini["Main", "�߂�"]},
            {"btnMenu",Lng.ini["Main", "���j���["]},
            {"btnScreenshot",Lng.ini["Main", "�X�N���[���V���b�g"]},
            {"btnVolumeUp",Lng.ini["Main", "���ʁ{"]},
            {"btnVolumeDown",Lng.ini["Main", "���ʁ|"]},
            {"btnMute",Lng.ini["Main", "����"]},
            {"btnPower",Lng.ini["Main", "�d��"]},
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
            {"Home",3},               // �z�[��
            {"Back",4},               // �߂�
            {"Call",5},               // �d�b
            {"HangUp",6},             // �d�b��؂�
            {"VolumeUp",24},          // ���ʁ{
            {"VolumeDown",25},        // ���ʁ|
            {"Power",26},             // �d��
            {"TakePicture",27},       // �ʐ^���B��i�J�����A�v���ŎB�e����K�v������܂��j
            {"Browser",64},           // �u���E�U���J��
            {"Menu",82},              // ���j���[
            {"Pause",85},             // �Đ�/�ꎞ��~
            {"Stop",86},              // ��~
            {"Next",87},              // ���̋�
            {"Previous",88},          // �O�̋�
            // xxxx = 122,            // ���X�g�̐擪�Ɉړ�
            // xxxx = 123,            // ���X�g�̖����Ɉړ�
            // xxxx = 126,            // �Đ����ĊJ
            // xxxx = 127,            // �Đ����ꎞ��~
            {"Mute",164},             // �~���[�g
            // xxxx = 176,            // �V�X�e���ݒ�
            // xxxx = 187,            // �A�v���̐؂�ւ�
            // xxxx = 207,            // �A����
            // xxxx = 208,            // �J�����_�[
            // xxxx = 209,            // �~���[�W�b�N�v���C���[
            // xxxx = 210,            // �d��
            // xxxx = 220,            // ��ʂ̖��邳�|
            // xxxx = 221,            // ��ʂ̖��邳�{
            // xxxx = 223,            // �V�X�e�����x�~
            // xxxx = 224,            // ��ʂ𖾂邭����
            // xxxx = 231,            // �����K�C�h
            // xxxx = 276,            // �E�F�C�N���b�N���Ȃ��ꍇ�A�V�X�e�����X���[�v��Ԃɂ���
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

                // ���O�Ńn���h�����擾����
                IntPtr hwnd = MoveListener.FindWindow(null, Setting.Main.select_Device_Info.Model_Name);
                if (hwnd != IntPtr.Zero)
                {
                    // WinAPI���g�p����Scrcpy�̈ʒu���X�V����
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
