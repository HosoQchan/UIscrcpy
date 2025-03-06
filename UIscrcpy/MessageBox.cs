using Microsoft.VisualBasic;
using MS.WindowsAPICodePack.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace UIscrcpy
{
    public partial class MBox : Form
    {
        private string Message = "";
        public string Button = "";
        public string Result = "";

        public MBox(string title, string icon,string msg, string button, string result)
        {
            InitializeComponent();
            Button1.Visible = false;
            Button2.Visible = false;
            Button3.Visible = false;

            Sys_Icon(icon);

            this.Text = title;
            Label_Message.Text = msg;

            Result = result;
            Button = button;
            Set_Bottun();
        }

        private void MessageBox_Load(object sender, EventArgs e)
        {
            Focus();
        }

        private void Set_Bottun()
        {
            switch (Button)
            {
                // 「OK」ボタンのみ。
                case "OK":
                    Button1.Visible = true;        // 表示する
                    Button1.Text = Lng.ini["Main", "確定"];
                    switch (Result)
                    {
                        case "OK":
                            Button1.Focus();
                            break;
                    }
                    break;
                // 「OK」と「キャンセル」ボタン。
                case "OKCancel":
                    Button1.Visible = true;        // 表示する
                    Button1.Text = Lng.ini["Main", "確定"];
                    Button2.Visible = true;        // 表示する
                    Button2.Text = Lng.ini["Main", "取り消し"];
                    switch (Result)
                    {
                        case "OK":
                            Button1.Focus();
                            break;
                        case "Cancel":
                            Button2.Focus();
                            break;
                    }
                    break;
                // 「中止」、「再試行」、「無視」ボタン。
                case "AbortRetryIgnore":
                    Button3.Visible = true;        // 表示する
                    Button3.Text = Lng.ini["Main", "中止"];
                    Button1.Visible = true;        // 表示する
                    Button1.Text = Lng.ini["Main", "再試行"];
                    Button2.Visible = true;        // 表示する
                    Button2.Text = Lng.ini["Main", "無視"];
                    switch (Result)
                    {
                        case "Abort":
                            Button3.Focus();
                            break;
                        case "Retry":
                            Button1.Focus();
                            break;
                        case "Ignore":
                            Button2.Focus();
                            break;
                    }
                    break;
                // 「はい」、「いいえ」、「キャンセル」ボタン。
                case "YesNoCancel":
                    Button3.Visible = true;        // 表示する
                    Button3.Text = Lng.ini["Main", "はい"];
                    Button1.Visible = true;        // 表示する
                    Button1.Text = Lng.ini["Main", "いいえ"];
                    Button2.Visible = true;        // 表示する
                    Button2.Text = Lng.ini["Main", "取り消し"];
                    switch (Result)
                    {
                        case "Yes":
                            Button3.Focus();
                            break;
                        case "No":
                            Button1.Focus();
                            break;
                        case "Cancel":
                            Button2.Focus();
                            break;
                    }
                    break;
                // 「はい」と「いいえ」ボタン。
                case "YesNo":
                    Button1.Visible = true;        // 表示する
                    Button1.Text = Lng.ini["Main", "はい"];
                    Button2.Visible = true;        // 表示する
                    Button2.Text = Lng.ini["Main", "いいえ"];
                    switch (Result)
                    {
                        case "Yes":
                            Button1.Focus();
                            break;
                        case "No":
                            Button2.Focus();
                            break;
                    }
                    break;
                // 「再試行」と「キャンセル」ボタン。
                case "RetryCancel":
                    Button1.Visible = true;        // 表示する
                    Button1.Text = Lng.ini["Main", "再試行"];
                    Button2.Visible = true;        // 表示する
                    Button2.Text = Lng.ini["Main", "取り消し"];
                    switch (Result)
                    {
                        case "Retry":
                            Button1.Focus();
                            break;
                        case "Cancel":
                            Button2.Focus();
                            break;
                    }
                    break;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            switch (Button)
            {
                // 「OK」ボタンのみ。
                case "OK":
                    Result = "OK";
                    break;
                // 「OK」と「キャンセル」ボタン。
                case "OKCancel":
                    Result = "OK";
                    break;
                // 「中止」、「再試行」、「無視」ボタン。
                case "AbortRetryIgnore":
                    Result = "Retry";
                    break;
                // 「はい」、「いいえ」、「キャンセル」ボタン。
                case "YesNoCancel":
                    Result = "No";
                    break;
                // 「はい」と「いいえ」ボタン。
                case "YesNo":
                    Result = "Yes";
                    break;
                // 「再試行」と「キャンセル」ボタン。
                case "RetryCancel":
                    Result = "Retry";
                    break;
            }
            this.Close();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            switch (Button)
            {
                case "OKCancel":
                    Result = "Cancel";
                    break;
                // 「中止」、「再試行」、「無視」ボタン。
                case "AbortRetryIgnore":
                    Result = "Ignore";
                    break;
                // 「はい」、「いいえ」、「キャンセル」ボタン。
                case "YesNoCancel":
                    Result = "Cancel";
                    break;
                // 「はい」と「いいえ」ボタン。
                case "YesNo":
                    Result = "No";
                    break;
                // 「再試行」と「キャンセル」ボタン。
                case "RetryCancel":
                    Result = "Cancel";
                    break;
            }
            this.Close();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            switch (Button)
            {
                // 「中止」、「再試行」、「無視」ボタン。
                case "AbortRetryIgnore":
                    Result = "Abort";
                    break;
                // 「はい」、「いいえ」、「キャンセル」ボタン。
                case "YesNoCancel":
                    Result = "Yes";
                    break;
            }
            this.Close();
        }

        private void Sys_Icon(string Icon_Name)
        {
            switch (Icon_Name)
            {
                case "APPLICATION":
                    PictureBox.Image = SystemIcons.Application.ToBitmap();
                    break;
                case "ASTERISK":
                    PictureBox.Image = SystemIcons.Asterisk.ToBitmap();
                    break;
                case "ERROR":
                    PictureBox.Image = SystemIcons.Error.ToBitmap();
                    // システムエラー
                    System_Sound.Play_SystemSound("SystemHand");
                    break;
                case "EXCLAMATION":
                    PictureBox.Image = SystemIcons.Exclamation.ToBitmap();
                    // メッセージ(警告)
                    System_Sound.Play_SystemSound("SystemExclamation");
                    break;
                case "HAND":
                    PictureBox.Image = SystemIcons.Hand.ToBitmap();
                    // システムエラー
                    System_Sound.Play_SystemSound("SystemHand");
                    break;
                case "INFORMATION":
                    PictureBox.Image = SystemIcons.Information.ToBitmap();
                    // システム通知
                    System_Sound.Play_SystemSound("SystemNotification");
                    break;
                case "QUESTION":
                    PictureBox.Image = SystemIcons.Question.ToBitmap();
                    // システム通知
                    System_Sound.Play_SystemSound("SystemNotification");
                    /*
                    // メッセージ(問い合わせ)
                    System_Sound.Play_SystemSound("SystemQuestion");
                    */
                    break;
                case "WARNING":
                    PictureBox.Image = SystemIcons.Warning.ToBitmap();
                    // メッセージ(警告)
                    System_Sound.Play_SystemSound("SystemExclamation");
                    break;
                case "WINLOGO":
                    PictureBox.Image = SystemIcons.WinLogo.ToBitmap();
                    break;
                default:
                    PictureBox.Image = SystemIcons.Information.ToBitmap();
                    break;
            }
        }   
    }
}
