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
using static UIscrcpy.Controller;

namespace UIscrcpy
{

    public class Shell
    {
        public static string ScreenshotSavePath = "";

        public string Process_Name = "";
        public string Async_Output = "";
        public string Async_Error = "";
        public string Output_Results = "";
        public string Error_Results = "";

        public static Process Process = null;
        public static Process ShellProcess = null;

        public void Async_Comand(string Name, string Command, string Option)
        {
            Process_Name = Name;
            Command = Setting.Main.Scrcpy_Path + Command;

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
            using (Process = new Process())
            using (var ctoken = new CancellationTokenSource())
            {
                Process.EnableRaisingEvents = true;
                Process.StartInfo = si;

                // コールバックの設定
                Process.Exited += (sender, ev) =>
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
                Process.Start();

                Task.WaitAll(
                    Task.Run(() =>
                    {
                        while (true)
                        {
                            string Output = Process.StandardOutput.ReadLine();
                            if (Output == null)
                            {
                                break;
                            }
                            Output_Results = Output_Results + Output + "\r\n";
                            Proc_StandardOutput(Process_Name, Output);
                        }
                        while (true)
                        {
                            string Error = Process.StandardError.ReadLine();
                            if (Error == null)
                            {
                                break;
                            }
                            Error_Results = Error_Results + Error + "\r\n";
                            Proc_StandardError(Process_Name, Error);
                        }
                    }),
                    Task.Run(() =>
                    {
                        ctoken.Token.WaitHandle.WaitOne();
                        Process.WaitForExit();
                    })
                );
            }
        }

        private void Proc_StandardOutput(string Process_Name,string Data)
        {
            Debug.WriteLine(Data);
        }

        private void Proc_StandardError(string Process_Name, string Data)
        {
            Match mh;
            if (!string.IsNullOrWhiteSpace(Data))
            {
                switch (Process_Name)
                {
                    case "ADB_Screenshot":
                    case "ADB_keyevent":
                        Async_Error = "error";
                        break;
                }
                Debug.WriteLine("-------->" + Process_Name);
                Debug.WriteLine(Data);
            }
        }

        // 実行中のコマンドプロセスを閉じる
        static public void ADB_Kill()
        {
            try
            {
                // ADBのプロセス名（adb.exe）を特定します
                Process[] processes = Process.GetProcessesByName("adb");

                // 該当するプロセスが存在する場合、終了させます
                if (processes.Length > 0)
                {
                    foreach (Process process in processes)
                    {
                        process.Kill(); // プロセスを強制終了
                        process.WaitForExit(); // 終了待ち
                    }
                    Debug.WriteLine("ADB processes killed."); // 終了確認メッセージ
                }
                else
                {
                    Debug.WriteLine("ADB process not found."); // プロセスが存在しない場合
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"An error occurred: {ex.Message}"); // 例外発生時の処理
            }
        }
    }
}
