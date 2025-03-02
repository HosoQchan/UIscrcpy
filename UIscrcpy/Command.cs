using MS.WindowsAPICodePack.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace UIscrcpy
{
    public class bat_Create
    {
        string bat_data;


        /*
        public void adb_adress()
        {
            // 接続されているIPアドレスを表示する
            bat_data = Setting.Main.scrcpy_path + "adb.exe shell ip addr show wlan0";
            Encoding enc = Encoding.GetEncoding("UTF-8");
            using (StreamWriter writer = new StreamWriter(Setting.bat_Path + "adb_adress.bat", false, enc))
            {
                writer.WriteLine(bat_data);
            }
        }
        */


    }

    public class Shell
    {
        public string Process_Name = "";
        public string Process_Result = "";

        public string Comand(string process_FileName, string Option)
        {
            string results = "";
            if (!File.Exists(process_FileName))
            {
                return "ファイル[" + process_FileName + "]が見つかりません。";
            }

            // Processオブジェクトを作成
            System.Diagnostics.Process p = new System.Diagnostics.Process();

            // バッチファイルを起動する人は、cmd.exeさんなので
            p.StartInfo.FileName = "cmd.exe";
            // コマンド処理実行後、コマンドウィンドウ終わるようにする。
            p.StartInfo.Arguments = "/c ";

            // コマンドラインを指定
            if (Option != "")
            {
                process_FileName = process_FileName + " " + Option;
            }
            p.StartInfo.Arguments = p.StartInfo.Arguments + process_FileName;

            // エンコード指定
            p.StartInfo.StandardOutputEncoding = System.Text.Encoding.UTF8;

            // ウィンドウを表示しないようにする
            p.StartInfo.CreateNoWindow = true;

            // 出力を読み取れるようにする
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardInput = false;

            // 起動
            p.Start();

            // 出力を読み取る
            results = p.StandardOutput.ReadToEnd();

            // プロセス終了まで待機する
            // WaitForExitはReadToEndの後である必要がある
            // (親プロセス、子プロセスでブロック防止のため)
            p.WaitForExit();
            p.Close();
            return results;
        }

        public void Async_Comand(string Name, string Command, string Option)
        {
            Process_Name = Name;
            Command = Setting.Main.scrcpy_path + Command;

            var si = new ProcessStartInfo();
            // バッチファイルを起動する人は、cmd.exeさんなので
            si.FileName = "cmd.exe";

            // コマンド処理実行後、コマンドウィンドウ終わるようにする。
            si.Arguments = "/c ";

            // コマンドラインを指定
            if (Option != "")
            {
                Command = Command + " " + Option;
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
                            Proc_StandardOutput(Process_Name,Output);
                        }
                        while (true)
                        {
                            string Error = proc.StandardError.ReadLine();
                            if (Error == null)
                            {
                                break;
                            }
                            Proc_StandardError(Process_Name,Error);
                        }
                    }),
                    Task.Run(() =>
                    {
                        ctoken.Token.WaitHandle.WaitOne();
                        proc.WaitForExit();
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
                    case "ADB_IP_Address":
                        Debug.WriteLine("Data Received -- ADB_IP_Address");
                        Debug.WriteLine(Data);

                        string Patturn = @"inet (?<Adress>\d+\.\d+\.\d+\.\d+)";
                        mh = Regex.Match(Data, @Patturn, RegexOptions.None);
                        if (mh.Success)
                        {
                            Process_Result = mh.Groups["Adress"].Value;
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
        /*
        public void Async_Comand(string Name, string Command, string Option)
        {
            Process_Name = Name;
            Command = Setting.Main.scrcpy_path + Command;

            var si = new ProcessStartInfo();
            // バッチファイルを起動する人は、cmd.exeさんなので
            si.FileName = "cmd.exe";

            // コマンド処理実行後、コマンドウィンドウ終わるようにする。
            si.Arguments = "/c ";

            // コマンドラインを指定
            if (Option != "")
            {
                Command = Command + " " + Option;
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

                // イベントハンドラを追加
                proc.OutputDataReceived += p_OutputDataReceived;
                proc.ErrorDataReceived += p_ErrorDataReceived;
                proc.Exited += (sender, ev) =>
                {
                    // プロセスが終了すると呼ばれる
                    ctoken.Cancel();
                };
                // プロセスの開始
                proc.Start();
                // 非同期出力読出し開始
                proc.BeginErrorReadLine();
                proc.BeginOutputReadLine();
                // 終了まで待つ
                ctoken.Token.WaitHandle.WaitOne();
            }
        }

        //OutputDataReceivedイベントハンドラ
        //行が出力されるたびに呼び出される
        private void p_OutputDataReceived(object sender, System.Diagnostics.DataReceivedEventArgs e)
        {
            string result = e.Data;
            //出力された文字列を表示する
            Debug.WriteLine("Data Received -- " + Process_Name + " start");
            Debug.WriteLine(result);
            Debug.WriteLine("Data Received -- " + Process_Name + " end");

            Match mh;
            if (!string.IsNullOrWhiteSpace(result))
            {
                switch (Process_Name)
                {
                    case "ADB_IP_Address":
                        string Patturn = @"inet (?<Adress>\d+\.\d+\.\d+\.\d+)";
                        mh = Regex.Match(result, @Patturn, RegexOptions.None);
                        if (mh.Success)
                        {
                            Process_Result = mh.Groups["Adress"].Value;
                        }
                        break;
                    case "ADB_List_Package":
                        Debug.WriteLine("ADB_List_Package:" + result);
                        break;
                    case "scrcpy_App_List":
                        Debug.WriteLine("scrcpy_App_List:" + result);
                        break;
                    case "scrcpy_Connect_USB":
                        Debug.WriteLine("scrcpy_Connect_USB:" + result);
                        break;
                    case "scrcpy_Connect_Wifi":
                        Debug.WriteLine("scrcpy_Connect_Wifi:" + result);
                        break;
                }
            }

        }
        //ErrorDataReceivedイベントハンドラ
        private void p_ErrorDataReceived(object sender, System.Diagnostics.DataReceivedEventArgs e)
        {
            switch (Process_Name)
            {
                case "ADB_IP_Address":

                    break;
                case "ADB_List_Package":

                    break;
                case "scrcpy_App_List":

                    break;
                case "scrcpy_Connect_USB":

                    break;
                case "scrcpy_Connect_Wifi":

                    break;
            }



            //エラー出力された文字列を表示する
            Debug.WriteLine("Error Received -- " + Process_Name + " start");
            Debug.WriteLine(e.Data);
            Debug.WriteLine("Error Received -- " + Process_Name + " end");
        }
        */
    }
}
