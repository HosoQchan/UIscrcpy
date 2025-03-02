using MS.WindowsAPICodePack.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UIscrcpy
{

    public class Shell
    {
        public string Process_Name = "";
        public string Async_Output = "";
        public string Async_Error = "";
        public string Output_Results = "";
        public string Error_Results = "";

        public void Async_Comand(string Name, string Command, string Option)
        {
            Process_Name = Name;
            Kill_Process(Command.Replace("\\", ""));

            Command = Setting.Main.scrcpy_path + Command;

            var si = new ProcessStartInfo();
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
            using (var proc = new Process())
            using (var ctoken = new CancellationTokenSource())
            {
                proc.EnableRaisingEvents = true;
                proc.StartInfo = si;

                // コールバックの設定
                proc.Exited += (sender, ev) =>
                {
                    Debug.WriteLine($"Prosess_Exited");
                    // プロセスが終了すると呼ばれる
                    ctoken.Cancel();
                };

                // プロセスの開始
                Debug.WriteLine($"Prosess_Start");
                Output_Results = "";
                Error_Results = "";
                Async_Output = "";
                Async_Error = "";
                proc.Start();
                Task.WaitAll(
                    Task.Run(() =>
                    {
                        while (true)
                        {
                            string Output = proc.StandardOutput.ReadLine();
                            if (Output == null)
                            {
                                break;
                            }
                            Output_Results = Output_Results + Output + "\r\n";
                            Proc_StandardOutput(Process_Name,Output);
                        }
                        while (true)
                        {
                            string Error = proc.StandardError.ReadLine();
                            if (Error == null)
                            {
                                break;
                            }
                            Error_Results = Error_Results + Error + "\r\n";
                            Proc_StandardError(Process_Name,Error);
                        }
                    }),
                    Task.Run(() =>
                    {
                        ctoken.Token.WaitHandle.WaitOne();
                        proc.WaitForExit();
                        Debug.WriteLine("----- Output ----");
                        Debug.WriteLine(Output_Results);
                        Debug.WriteLine("----- Output ----");
                        Debug.WriteLine("----- error ----");
                        Debug.WriteLine(Error_Results);
                        Debug.WriteLine("----- error ----");
                    })
                );
            }
        }

        private void Proc_StandardOutput(string Process_Name,string Data)
        {
            Match mh;
            if (!string.IsNullOrWhiteSpace(Data))
            {
                switch (Process_Name)
                {
                    case "ADB_Disconnect":
                        break;
                    case "ADB_Devices_List":
                        break;
                    case "ADB_Tcpip":
                        break;
                    case "ADB_Connect":
                        break;
                    case "ADB_IP_Address":
                        Debug.WriteLine("Data Received -- ADB_IP_Address");
                        Debug.WriteLine(Data);

                        string Patturn = @"inet (?<Adress>\d+\.\d+\.\d+\.\d+)";
                        mh = Regex.Match(Data, @Patturn, RegexOptions.None);
                        if (mh.Success)
                        {
                            Async_Output = mh.Groups["Adress"].Value;
                        }
                        break;
                    case "ADB_List_Package":
                        Debug.WriteLine("Data Received -- ADB_List_Package");
                        Debug.WriteLine(Data);

                        break;
                    case "scrcpy_App_List":
                        Debug.WriteLine("Data Received -- scrcpy_App_List");
                        Debug.WriteLine(Data);

                        break;
                    case "scrcpy_Connect_USB":
                        Debug.WriteLine("Data Received -- scrcpy_Connect_USB");
                        Debug.WriteLine(Data);

                        break;
                    case "scrcpy_Connect_Wifi":
                        Debug.WriteLine("Data Received -- scrcpy_Connect_Wifi");
                        Debug.WriteLine(Data);

                        break;
                }
            }
        }

        private void Proc_StandardError(string Process_Name, string Data)
        {
            Match mh;
            if (!string.IsNullOrWhiteSpace(Data))
            {
                switch (Process_Name)
                {
                    case "ADB_Disconnect":
                        Debug.WriteLine("Error Received -- ADB_Disconnect");
                        Debug.WriteLine(Data);
                        break;
                    case "ADB_Devices_List":
                        Debug.WriteLine("Error Received -- ADB_Devices_List");
                        Debug.WriteLine(Data);
                        break;
                    case "ADB_Tcpip":
                        Debug.WriteLine("Error Received -- ADB_Tcpip");
                        Debug.WriteLine(Data);
                        break;
                    case "ADB_Connect":
                        Debug.WriteLine("Error Received -- ADB_Connect");
                        Debug.WriteLine(Data);
                        break;
                    case "ADB_IP_Address":
                        Debug.WriteLine("Error Received -- ADB_IP_Address");
                        Debug.WriteLine(Data);

                        break;
                    case "ADB_List_Package":
                        Debug.WriteLine("Error Received -- ADB_List_Package");
                        Debug.WriteLine(Data);

                        break;
                    case "scrcpy_App_List":
                        Debug.WriteLine("Error Received -- scrcpy_App_List");
                        Debug.WriteLine(Data);

                        break;
                    case "scrcpy_Connect_USB":
                        Debug.WriteLine("Error Received -- scrcpy_Connect_USB");
                        Debug.WriteLine(Data);

                        string Patturn = @"ERROR: Server connection failed";
                        mh = Regex.Match(Data, @Patturn, RegexOptions.None);
                        if (mh.Success)
                        {
                            // エラーメッセージを表示する
                            MessageBox.Show("接続を認識できませんでした。もう一度試してみてください。", "メッセージ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        break;
                    case "scrcpy_Connect_Wifi":
                        Debug.WriteLine("Error Received -- scrcpy_Connect_Wifi");
                        Debug.WriteLine(Data);

                        break;
                }
            }
        }

        private void Kill_Process(string Process_Name)
        {
            //notepadのプロセスを取得
            System.Diagnostics.Process[] ps =
                System.Diagnostics.Process.GetProcessesByName(Process_Name);

            foreach (System.Diagnostics.Process p in ps)
            {
                //クローズメッセージを送信する
                p.CloseMainWindow();

                //プロセスが終了するまで最大1秒待機する
                p.WaitForExit(1000);
                //プロセスが終了したか確認する
                if (p.HasExited)
                {
                    Debug.WriteLine(Process_Name + "が終了しました。");
                }
                else
                {
                    Debug.WriteLine(Process_Name + "が終了しませんでした。");
                }
            }



        }
    }
}
