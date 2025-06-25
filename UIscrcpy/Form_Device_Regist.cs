using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UIscrcpy
{
    public partial class Form_Device_Regist : Form
    {
        private Form_Waiting_Command connect_Device = new Form_Waiting_Command("Reg");

        public int page_no = 1;
        public Device_Info device_info = new Device_Info();
        private Command command = new Command();

        public Form_Device_Regist(int Page_No)
        {
            InitializeComponent();
            this.Icon = new Icon(".\\Resources\\Icon\\Plus.ico");

            this.Text = Lng.ini["Main", "登録"];
            page_no = Page_No;
        }

        private void Form_Device_Regist_Load(object sender, EventArgs e)
        {
            try
            {
                string Image_Path = Lng.Language_Path + Setting.Main.Language + "\\Image\\";
                PictureBox1.Image = System.Drawing.Image.FromFile(Image_Path + "Regist11.png");
                PictureBox2.Image = System.Drawing.Image.FromFile(Image_Path + "Regist12.png");
                PictureBox3.Image = System.Drawing.Image.FromFile(Image_Path + "Regist13.png");

                PictureBox5.Image = System.Drawing.Image.FromFile(Image_Path + "Regist21.png");
                PictureBox6.Image = System.Drawing.Image.FromFile(Image_Path + "Regist22.png");
                PictureBox7.Image = System.Drawing.Image.FromFile(Image_Path + "Regist23.png");
                PictureBox8.Image = System.Drawing.Image.FromFile(Image_Path + "Regist24.png");
            }
            catch
            {
            }

            switch (page_no)
            {
                case 1:
                    Start_Page1();
                    break;
                case 2:
                    Start_Page2();
                    break;
                case 9:
                    Start_Page9();
                    break;
            }
        }

        private void Start_Page1()
        {
            page_no = 1;
            panel1.Visible = true;
            panel2.Visible = false;
            panel9.Visible = false;

            Button_Cancel.Visible = true;
            Button_Cancel.Text = Lng.ini["Main", "取り消し"];
            Button_Back.Visible = false;
            Button_Start_Exit.Visible = true;
            Button_Start_Exit.Text = Lng.ini["Main", "次へ"];

            Label_Page1_Title.Text = Lng.ini["Main", "以下の手順に従って開始して下さい。"];
            Label_Page1_Picture_Info.Text = Lng.ini["Main", "※左クリックで画像を拡大"];
            Label_Page1_Announce.Text = Lng.ini["Main", "準備が出来たら「次へ」をクリックしてください。"];

            string text;
            text = Lng.ini["Main", "①端末を開発者モードにします。"];
            text = text + "\r\n";
            text = text + Lng.ini["Main", "端末の機種によって設定場所は違いますが、「端末情報」や「デバイス情報」の中にある「ビルド番号」や「シリアル番号」などの項目を7回以上タップすると「開発者モードに切り替わりました」と表示され、メニューのどこかに「開発者オプション」が追加表示されます。"];

            Label_Message1.Text = text;
        }
        private void Start_Page2()
        {
            page_no = 2;
            panel1.Visible = false;
            panel2.Visible = true;
            panel9.Visible = false;

            Button_Cancel.Visible = true;
            Button_Cancel.Text = Lng.ini["Main", "取り消し"];
            Button_Back.Visible = true;
            Button_Back.Text = Lng.ini["Main", "戻る"];
            Button_Start_Exit.Visible = true;
            Button_Start_Exit.Text = Lng.ini["Main", "次へ"];

            Label_Page2_Title.Text = Lng.ini["Main", "以下の手順に従って開始して下さい。"];
            Label_Page2_Picture_Info.Text = Lng.ini["Main", "※左クリックで画像を拡大"];
            Label_Page2_Announce.Text = Lng.ini["Main", "準備が出来たら「次へ」をクリックしてください。"];

            string text;
            text = Lng.ini["Main", "②メニューの「開発者オプション」から「USBデバッグ」をONにします。尚、Wifi接続する場合は「ワイヤレスデバッグ」もONにします。"];
            text = text + "\r\n\r\n";
            text = text + Lng.ini["Main", "③端末をPCにUSB接続します。"];
            text = text + "\r\n";
            text = text + Lng.ini["Main", "接続時に「USBデバッグを許可しますか？」又は「ワイヤレスデバッグを許可しますか？」のダイヤログが表示された場合、チェックして「許可」をタップしてください。"];
            text = text + "\r\n\r\n";
            text = text + Lng.ini["Main", "④ワイヤレスデバック」をタップすると、「IPアドレスとポート」が表示されています。後で必要になるのでメモをしておいて下さい。"];
            Label_Message2.Text = text;
        }

        private void Start_Page9()
        {
            page_no = 9;
            panel1.Visible = false;
            panel2.Visible = false;
            panel9.Visible = true;

            Button_Cancel.Visible = true;
            Button_Cancel.Text = Lng.ini["Main", "取り消し"];
            Button_Back.Visible = true;
            Button_Back.Text = Lng.ini["Main", "戻る"];
            Button_Start_Exit.Visible = true;
            Button_Start_Exit.Text = Lng.ini["Main", "次へ"];

            Label_Page9_Title.Text = Lng.ini["Main", "端末のＩＰアドレスを確認して下さい。"];
            Label_Page9_Announce1.Text = Lng.ini["Main", "よろしければ「次へ」をクリックして下さい。"];
            Label_Page9_Announce2.Text = Lng.ini["Main", "※良く分からない場合は、そのまま「次へ」をクリックして下さい。"];

            string text;
            text = Lng.ini["Main", "「設定」→「ネットワークとインターネット」→「WiFi」→ 接続しているネットワーク名をタップすると、詳細情報が表示され、その中にIPアドレスが記載されています。"];
            text = text + "\r\n";
            text = text + Lng.ini["Main", "【例】192.168.1.28 などの部分です。"];
            text = text + "\r\n";
            text = text + "\r\n";
            text = text + Lng.ini["Main", "※端末の機種によって操作方法が異なる場合があります。詳しくは端末の説明書をご覧ください。"];
            Label_Message9.Text = text;

            TextBox_Adress1.Text = "192";
            TextBox_Adress2.Text = "168";
            TextBox_Adress3.Text = "";
            TextBox_Adress4.Text = "";

            // ＩＰアドレスを取得する
            string IP_Adress = command.IP_Adress_Info();
            if (IP_Adress != "")
            {
                Match mh;
                string Patturn = @"(?<Adr1>\d+)\.(?<Adr2>\d+)\.(?<Adr3>\d+)\.(?<Adr4>\d+)";
                mh = Regex.Match(IP_Adress, @Patturn, RegexOptions.None);
                TextBox_Adress3.Text = mh.Groups["Adr3"].Value;
                TextBox_Adress4.Text = mh.Groups["Adr4"].Value;
            }
        }

        private void Button_Start_Exit_Click(object sender, EventArgs e)
        {
            Form_Device_Disp Form_device_Disp = new Form_Device_Disp();
            MBox mbox;
            string Msg = "";
            switch (page_no)
            {
                case 1:
                    Start_Page2();
                    break;
                // USB接続確認
                case 2:
                    if (!UIsrcpy.Command_File_Check())
                    {
                        // 接続エラー
                        Connect_Error();
                        return;
                    }

                    Form_Handle(false);
                    // 端末情報を取得
                    device_info = command.Device_Info();
                    if (device_info.Model_Name == "")
                    {
                        // 接続エラー
                        Connect_Error();
                        break;
                    }
                    Form_Handle(true);

                    if (UIsrcpy.Device_List_Check(device_info.Model_Name) >= 0)
                    {
                        // エラーメッセージを表示する
                        Msg = Lng.ini["Msg", "この端末は既に登録されています。"];
                        mbox = new MBox(Lng.ini["Msg", "メッセージ"], "WARNING", Msg, "OK", "OK");
                        mbox.ShowDialog();
                        this.Close();
                        break;
                    }

                    Msg = Lng.ini["Msg", "このデバイスをWiFi接続しますか？"];
                    mbox = new MBox(Lng.ini["Msg", "確認"], "QUESTION", Msg, "YesNo", "Yes");
                    mbox.ShowDialog();
                    if (mbox.Result == "No")
                    {
                        Form_device_Disp.device_Info = device_info;
                        Form_device_Disp.ShowDialog();
                        this.Close();
                        break;
                    }
                    Start_Page9();
                    break;
                // ＩＰアドレスの入力と確認
                case 9:
                    if (!IP_Adress_Check())
                    {
                        // エラーメッセージを表示する
                        Msg = Lng.ini["Msg", "ＩＰアドレスが入力されていません。"];
                        mbox = new MBox(Lng.ini["Msg", "メッセージ"], "WARNING", Msg, "OK", "OK");
                        mbox.ShowDialog();
                        break;
                    }

                    string IP_Adress =
                        TextBox_Adress1.Text + "." +
                        TextBox_Adress2.Text + "." +
                        TextBox_Adress3.Text + "." +
                        TextBox_Adress4.Text;

                    if (!UIsrcpy.Command_File_Check())
                    {
                        // 接続エラー
                        Connect_Error();
                        return;
                    }

                    Form_Handle(false);
                    // WiFi接続コマンドを送信してみて、接続出来ているか確認する
                    bool Result = command.WiFi_Connect(IP_Adress);
                    command.WiFi_Disconnect();
                    if (Result)
                    {
                        Form_Handle(true);
                        device_info.IP_Adress = IP_Adress;
                        Form_device_Disp.device_Info = device_info;
                        Form_device_Disp.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        // 接続エラー
                        Connect_Error();
                        Start_Page2();
                    }
                    break;
            }
        }

        private bool IP_Adress_Check()
        {
            if (TextBox_Adress1.Text == "") { return false; }
            if (TextBox_Adress2.Text == "") { return false; }
            if (TextBox_Adress3.Text == "") { return false; }
            if (TextBox_Adress4.Text == "") { return false; }
            return true;
        }

        private void Connect_Error()
        {
            MBox mbox;
            string Msg = "";

            // エラーメッセージを表示する
            Msg = Lng.ini["Msg", "接続できませんでした。"];
            mbox = new MBox(Lng.ini["Msg", "メッセージ"], "WARNING", Msg, "OK", "OK");
            mbox.ShowDialog();
            Form_Handle(true);
        }

        // フォームの表示／非表示制御
        private void Form_Handle(bool isopen)
        {
            Action action = () =>
            {
                
                if (isopen)
                {
                    connect_Device.Close();
                    Show();
                    Activate();
                    Focus();
                }
                else
                {
                    Hide();
                    connect_Device.Show();
                }
            };
            Invoke(action);
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Button_Back_Click(object sender, EventArgs e)
        {
            switch (page_no)
            {
                case 1:
                    break;
                case 2:
                    Start_Page1();
                    break;
                case 9:
                    Start_Page1();
                    break;
            }
        }

        // 指定の文字、又はバックスペース以外の場合はfalseを返す
        // 例:pattern = @"^[a-zA-Z0-9]$";        // 正規表現
        static public bool Keychr_chk(char KeyChar, string pattern)
        {
            if (KeyChar == (char)Keys.Back || KeyChar == (char)Keys.Delete)
            {
                return true;  // DEL、又はバックスペースは常に許可
            }

            if (Regex.IsMatch(KeyChar.ToString(), pattern))
            {
                return true;
            }
            return false;
        }

        private void TextBox_Adress_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Keychr_chk(e.KeyChar, @"^[0-9]$"))
            {
                e.Handled = true;
            }
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            Form_Picture form_Picture = new Form_Picture();
            form_Picture.bitmap = (Bitmap)PictureBox1.Image;
            form_Picture.ShowDialog();
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            Form_Picture form_Picture = new Form_Picture();
            form_Picture.bitmap = (Bitmap)PictureBox2.Image;
            form_Picture.ShowDialog();
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            Form_Picture form_Picture = new Form_Picture();
            form_Picture.bitmap = (Bitmap)PictureBox3.Image;
            form_Picture.ShowDialog();
        }

        private void PictureBox5_Click(object sender, EventArgs e)
        {
            Form_Picture form_Picture = new Form_Picture();
            form_Picture.bitmap = (Bitmap)PictureBox5.Image;
            form_Picture.ShowDialog();
        }

        private void PictureBox6_Click(object sender, EventArgs e)
        {
            Form_Picture form_Picture = new Form_Picture();
            form_Picture.bitmap = (Bitmap)PictureBox6.Image;
            form_Picture.ShowDialog();
        }

        private void PictureBox7_Click(object sender, EventArgs e)
        {
            Form_Picture form_Picture = new Form_Picture();
            form_Picture.bitmap = (Bitmap)PictureBox7.Image;
            form_Picture.ShowDialog();
        }

        private void PictureBox8_Click(object sender, EventArgs e)
        {
            Form_Picture form_Picture = new Form_Picture();
            form_Picture.bitmap = (Bitmap)PictureBox8.Image;
            form_Picture.ShowDialog();
        }
    }


}
