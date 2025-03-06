using MS.WindowsAPICodePack.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using UIscrcpy.URL;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Image = System.Drawing.Image;

namespace UIscrcpy
{
    public partial class Form_Waiting_Command : Form
    {
        public Device_Info device_info = new Device_Info();
        public bool Result = true;

        private Shell Shell = new Shell();
        private Command command = new Command();

        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
//        private System.Timers.Timer timer = new System.Timers.Timer();
        private int Timer_Step = 0;

        private string msg = "";

        private Image[] Spn_img = new Image[] {
            Image.FromFile(".\\Resources\\Image\\Spinning1.png"),
            Image.FromFile(".\\Resources\\Image\\Spinning2.png"),
            Image.FromFile(".\\Resources\\Image\\Spinning3.png"),
            Image.FromFile(".\\Resources\\Image\\Spinning4.png"),
        };

        public Form_Waiting_Command(string title)
        {
            InitializeComponent();
            //            Button1.Text = Lng.ini["Msg", "中止"];
            Button1.Visible = false;

            this.Text = title;
            switch (this.Text)
            {
                case "App":
                    msg = Lng.ini["Msg", "アプリを取得中。暫くお待ちください"];
                    Label_Message.Text = msg;
                    PictureBox.Image = Image.FromFile(".\\Resources\\Image\\android.png");
                    break;
                case "Icon":
                    msg = Lng.ini["Msg", "アイコンを取得中。暫くお待ちください"];
                    Label_Message.Text = msg;
                    PictureBox.Image = Image.FromFile(".\\Resources\\Image\\Icon.png");
                    break;
                case "UIscrcpy":
                    msg = Lng.ini["Msg", "起動中"];
                    Label_Message.Text = msg;
                    PictureBox.Image = Image.FromFile(".\\Resources\\Icon\\UIscrcpy.ico");
                    break;
                case "USB":
                    msg = Lng.ini["Msg", "接続中"];
                    Label_Message.Text = msg;
                    PictureBox.Image = Image.FromFile(".\\Resources\\Image\\USB.png");
                    break;
                case "WiFi":
                    msg = Lng.ini["Msg", "接続中"];
                    Label_Message.Text = msg;
                    PictureBox.Image = Image.FromFile(".\\Resources\\Image\\WiFi.png");
                    break;
                default:
                    msg = Lng.ini["Msg", "接続中"];
                    Label_Message.Text = msg;
                    PictureBox.Image = Spn_img[Timer_Step];
                    break;
            }
            Label_Message.Text = msg + "...";
            timer.Interval = 250;      // 250ms
            Timer_Step = 0;
            timer.Start();
            timer.Tick += Timer_Tick;
            //                    timer.Elapsed += Timer_Tick;
        }

        private void Form_Waiting_Command_Load(object sender, EventArgs e)
        {
           
        }

        private void Timer_Tick(System.Object sender, EventArgs e)
        {
            if (Timer_Step == 3)
            {
                Timer_Step = 0;
            }
            else
            {
                Timer_Step++;
            }
            switch (Timer_Step)
            {
                case 0:
                    Label_Message.Text = msg;
                    break;
                case 1:
                    Label_Message.Text = msg + ".";
                    break;
                case 2:
                    Label_Message.Text = msg + "..";
                    break;
                case 3:
                    Label_Message.Text = msg + "...";
                    break;
            }
            //Labelを再描画する
            Label_Message.Update();
            PictureBox.Image = Spn_img[Timer_Step];
        }

        // Formが表示されたら発生するイベント
        private void Form_Waiting_Command_Shown(object sender, EventArgs e)
        {
            // コントロールが完全に表示される前に処理を始めてしまうので、
            // 処理の前にFormの再描画を行う。
            this.Refresh();

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Result = false;
            this.Close();
        }

        private void Form_Waiting_Command_Closed(object sender, FormClosedEventArgs e)
        {
            timer.Stop();
        }
    }
}
