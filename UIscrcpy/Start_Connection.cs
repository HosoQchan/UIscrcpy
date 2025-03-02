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
    public partial class Start_Connection : Form
    {
        private int page_no = 1;
        private Device_Info device_info = new Device_Info();

        //Processオブジェクトを作成
        private System.Diagnostics.Process p = new System.Diagnostics.Process();
        private bool process_running = false;
        private Shell Shell = new Shell();

        public Start_Connection()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Start_Page1();
        }

        private void Start_Page1()
        {
            page_no = 1;
            panel1.Visible = true;
            panel2.Visible = false;
            panel9.Visible = false;

            Button_Cancel.Visible = true;
            Button_Back.Visible = false;
            Button_Start_Exit.Visible = true;
            Button_Start_Exit.Text = "次へ";

            string text;
            text = "①端末を開発者モードにします。";
            text = text + "\r\n";
            text = text + "端末の機種によって設定場所は違いますが、「端末情報」や「デバイス情報」の中にある「ビルド番号」や「シリアル番号」などの項目を7回以上タップすると「開発者モードに切り替わりました」と表示され、メニューのどこかに「開発者オプション」が追加表示されます。";

            Label_Message1.Text = text;
        }
        private void Start_Page2()
        {
            page_no = 2;
            panel1.Visible = false;
            panel2.Visible = true;
            panel9.Visible = false;

            Button_Cancel.Visible = true;
            Button_Back.Visible = true;
            Button_Start_Exit.Visible = true;
            Button_Start_Exit.Text = "次へ";

            string text;
            text = "②メニューの「開発者オプション」から「USBデバッグ」をONにします。尚、Wifi接続する場合は「ワイヤレスデバッグ」もONにします。";
            text = text + "\r\n\r\n";
            text = text + "③端末をPCにUSB接続します。\r\n接続時に「USBデバッグを許可しますか？」又は「ワイヤレスデバッグを許可しますか？」のダイヤログが表示された場合、チェックして「許可」をタップしてください。";
            text = text + "\r\n\r\n";
            text = text + "④ワイヤレスデバック」をタップすると、「IPアドレスとポート」が表示されています。後で必要になるのでメモなどをしておいて下さい。";
            Label_Message2.Text = text;
        }
        private void Start_Page9(Device_Info device_Info)
        {
            page_no = 9;
            panel1.Visible = false;
            panel2.Visible = false;
            panel9.Visible = true;

            Button_Cancel.Visible = true;
            Button_Back.Visible = true;
            Button_Start_Exit.Visible = true;
            Button_Start_Exit.Text = "次へ";

            string text;
            text = "「設定」→「ネットワークとインターネット」→「Wi - Fi」→接続しているネットワーク名をタップすると、詳細情報が表示され、その中にIPアドレスが記載されています。";
            text = text + "\r\n";
            text = text + "【例】192.168.1.28 などの部分です。";
            text = text + "\r\n";
            text = text + "\r\n";
            text = text + "※端末の機種によって操作方法が異なる場合があります。詳しくは端末の説明書をご覧ください。";
            Label_Message9.Text = text;

            Match mh;
            string Patturn = @"(?<Adr1>\d+)\.(?<Adr2>\d+)\.(?<Adr3>\d+)\.(?<Adr4>\d+)";
            mh = Regex.Match(device_info.IP_Adress, @Patturn, RegexOptions.None);
            TextBox_Adress1.Text = "192";
            TextBox_Adress2.Text = "168";
            TextBox_Adress3.Text = mh.Groups["Adr3"].Value;
            TextBox_Adress4.Text = mh.Groups["Adr4"].Value;
        }

        private void Button_Start_Exit_Click(object sender, EventArgs e)
        {
            switch (page_no)
            {
                case 1:
                    Start_Page2();
                    return;
                    break;
                case 2:
                    if (!Setting.Command_File_Check())
                    {
                        return;
                    }
                    Device_Connection Form_Device_Connection1 = new Device_Connection();
                    Form_Device_Connection1.Mode = 0;
                    Form_Device_Connection1.ShowDialog();
                    device_info = Form_Device_Connection1.device_Info;

                    if (Form_Device_Connection1.Error)
                    {
                        return;
                    }
                    if (UIsrcpy.Device_List_Check(device_info.Model_Name) >= 0)
                    {
                        // エラーメッセージを表示する
                        MessageBox.Show("この端末は既に登録されています。", "メッセージ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    DialogResult result = MessageBox.Show("このデバイスをWifi接続しますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
                    if (result == DialogResult.No)
                    {
                        Device_Disp Form_device_Disp = new Device_Disp();
                        Form_device_Disp.device_Info = device_info;
                        Form_device_Disp.ShowDialog();
                        this.Close();
                    }
                    else
                    {
                        Start_Page9(device_info);
                    }
                    break;
                case 9:
                    if (!IP_Adress_Check())
                    {
                        // エラーメッセージを表示する
                        MessageBox.Show("ＩＰアドレスが入力されていません。", "メッセージ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                    Device_Connection Form_Device_Connection2 = new Device_Connection();
                    Form_Device_Connection2.Mode = 1;
                    Form_Device_Connection2.device_Info = device_info;
                    Form_Device_Connection2.device_Info.Serial = device_info.Serial;
                    Form_Device_Connection2.device_Info.Product_Name = device_info.Product_Name;
                    Form_Device_Connection2.device_Info.Model_Name = device_info.Model_Name;
                    Form_Device_Connection2.device_Info.IP_Adress = TextBox_Adress1.Text + "." +
                                                    TextBox_Adress2.Text + "." +
                                                    TextBox_Adress3.Text + "." +
                                                    TextBox_Adress4.Text;
                    Form_Device_Connection2.ShowDialog();
                    device_info = Form_Device_Connection2.device_Info;

                    // デバイスを切断
                    Shell.Async_Comand("ADB_Disconnect","\\adb.exe", " disconnect");
                    if (Form_Device_Connection2.Error)
                    {
                        Start_Page1();
                        return;
                    }

                    Device_Disp Form = new Device_Disp();
                    Form.device_Info = device_info;
                    Form.ShowDialog();
                    this.Close();
                    return;
            }
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

        private bool IP_Adress_Check()
        {
            if (TextBox_Adress1.Text == "") { return false; }
            if (TextBox_Adress2.Text == "") { return false; }
            if (TextBox_Adress3.Text == "") { return false; }
            if (TextBox_Adress4.Text == "") { return false; }
            return true;
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
            form_Picture.bitmap = (Bitmap)PictureBox1.BackgroundImage;
            form_Picture.ShowDialog();
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            Form_Picture form_Picture = new Form_Picture();
            form_Picture.bitmap = (Bitmap)PictureBox2.BackgroundImage;
            form_Picture.ShowDialog();
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            Form_Picture form_Picture = new Form_Picture();
            form_Picture.bitmap = (Bitmap)PictureBox3.BackgroundImage;
            form_Picture.ShowDialog();
        }

        private void PictureBox5_Click(object sender, EventArgs e)
        {
            Form_Picture form_Picture = new Form_Picture();
            form_Picture.bitmap = (Bitmap)PictureBox5.BackgroundImage;
            form_Picture.ShowDialog();
        }

        private void PictureBox6_Click(object sender, EventArgs e)
        {
            Form_Picture form_Picture = new Form_Picture();
            form_Picture.bitmap = (Bitmap)PictureBox6.BackgroundImage;
            form_Picture.ShowDialog();
        }

        private void PictureBox7_Click(object sender, EventArgs e)
        {
            Form_Picture form_Picture = new Form_Picture();
            form_Picture.bitmap = (Bitmap)PictureBox7.BackgroundImage;
            form_Picture.ShowDialog();
        }

        private void PictureBox8_Click(object sender, EventArgs e)
        {
            Form_Picture form_Picture = new Form_Picture();
            form_Picture.bitmap = (Bitmap)PictureBox8.BackgroundImage;
            form_Picture.ShowDialog();
        }

    }


}
