using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using System.Timers;
using UIscrcpy;
using Timer = System.Timers.Timer;

namespace UIscrcpy
{
    public class MoveListener
    {
        #region WindowsAPi
        public delegate void WinEventDelegate(IntPtr hWinEventHook, uint eventType, IntPtr hwnd, int idObject, int idChild, uint dwEventThread, uint dwmsEventTime);

        private const uint EVENT_OBJECT_LOCATIONCHANGE = 0x800B;
        private const uint WINEVENT_OUTOFCONTEXT = 0;
        private static IntPtr hWinEventHook = IntPtr.Zero;

        [DllImport("user32.dll")]
        private static extern bool GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(IntPtr hWnd, out RECT lpRect);

        [DllImport("user32.dll")]
        private static extern IntPtr SetWinEventHook(uint eventMin, uint eventMax, IntPtr hmodWinEventProc, WinEventDelegate lpfnWinEventProc, uint idProcess, uint idThread, uint dwFlags);

        [DllImport("user32.dll")]
        private static extern bool UnhookWinEvent(IntPtr hWinEventHook);

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        private static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool ShowWindow(IntPtr hWnd, ShowWindowCommands nCmdShow);

        public static string GetWindowTitle(IntPtr hWnd)
        {
            const int nChars = 256;
            StringBuilder sb = new StringBuilder(nChars);
            GetWindowText(hWnd, sb, nChars);
            return sb.ToString();
        }

        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetWindowPlacement(IntPtr hWnd, ref WINDOWPLACEMENT lpwndpl);

        // ウィンドウ状態の構造
        [Serializable]
        [StructLayout(LayoutKind.Sequential)]
        struct WINDOWPLACEMENT
        {
            public int length;
            public int flags;
            public ShowWindowCommands showCmd;
            public POINT ptMinPosition;
            public POINT ptMaxPosition;
            public RECT rcNormalPosition;
        }

        // ウィンドウを表示するコマンドを定義
        enum ShowWindowCommands : int
        {
            SW_HIDE = 0,                    // ウィンドウを非表示
            SW_SHOWNORMAL = 1,              // 通常の表示
            // SW_NORMAL = 1,               // SW_SHOWNORMALと同じ
            SW_SHOWMINIMIZED = 2,           // ウィンドウを最小化
            SW_SHOWMAXIMIZED = 3,           // ウィンドウを最大化
            // SW_MAXIMIZE = 3,             // SW_SHOWMAXIMIZEDと同じ
            SW_SHOWNOACTIVATE = 4,          // ウィンドウをアクティブな状態で表示するが、アクティブにしない
            SW_SHOW = 5,                    // 現在のサイズと位置にウィンドウを表示する
            SW_MINIMIZE = 6,                // ウィンドウを最小化
            SW_SHOWMINNOACTIVE = 7,         // ウィンドウを最小化した状態で表示するが、アクティブにしない
            SW_SHOWNA = 8,                  // 現在の位置に非アクティブ状態のウィンドウを表示する
            SW_RESTORE = 9,                 // ウィンドウのサイズと位置を復元する
            SW_SHOWDEFAULT = 10,            // 作成時のデフォルトのサイズと位置でウィンドウを表示する
            SW_FORCEMINIMIZE = 11           // プログラムが応答していなくても、ウィンドウを最小化
        }

        [Serializable]
        [StructLayout(LayoutKind.Sequential)]
        struct POINT
        {
            public int x;
            public int y;
        }

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static public extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        // ウィンドウの位置とサイズを定義するフラグ
        public const uint SWP_NOSIZE = 0x0001;       // ウィンドウのサイズを変更しない
        public const uint SWP_NOMOVE = 0x0002;       // ウィンドウの位置を変更しない
        public const uint SWP_NOZORDER = 0x0004;     // ウィンドウのZオーダーを変更しない
        public const uint SWP_NOACTIVATE = 0x0010;   // ウィンドウを非アクティブ化

        // 最上位ウィンドウに指定
        static IntPtr HWND_TOPMOST = new IntPtr(-1);
        // 最上位ウィンドウを解除
        static IntPtr HWND_NOTOPMOST = new IntPtr(-2);
        #endregion

        #region フック方式
        /// <summary>
        /// 監視対象のプロセスID
        /// </summary>
        private static RECT lastRect;

        private static void UpdateLocation(IntPtr hwnd)
        {
            GetWindowRect(hwnd, out RECT rect);
            if (lastRect.Left == rect.Left && lastRect.Top == rect.Top)
                return;
            if (rect.Left + rect.Top > 0)
            {
                Setting.Main.select_Device_Info.Scrcpy.PointX = rect.Left + 8;
                Setting.Main.select_Device_Info.Scrcpy.PointY = rect.Top + 31;

                if (Controller.ControllerPtr != IntPtr.Zero)
                {
                    // WinAPIを使用してコントローラーの位置を更新する
                    int Point_x = Setting.Main.select_Device_Info.Scrcpy.PointX - (Controller.Now_Size.Width);
                    int Point_y = Setting.Main.select_Device_Info.Scrcpy.PointY;
                    Setting.Main.select_Device_Info.Controller.PointX = Point_x;
                    Setting.Main.select_Device_Info.Controller.PointY = Point_y;
                    SetWindowPos(Controller.ControllerPtr, IntPtr.Zero, Point_x, Point_y, 0, 0, SWP_NOSIZE | SWP_NOZORDER | SWP_NOACTIVATE);
                }
                lastRect = rect;
            }
        }

        // WINDOWPLACEMENT構造を作成する
        private static WINDOWPLACEMENT placement = new WINDOWPLACEMENT()
        {
            length = Marshal.SizeOf(placement)
        };

        private static void UpdateStatus(IntPtr hwnd)
        {
            if (hwnd == IntPtr.Zero || Controller.ControllerPtr == IntPtr.Zero)
                return;
            if (GetWindowPlacement(hwnd, ref placement))
            {

                switch (placement.showCmd)
                {
                    case ShowWindowCommands.SW_HIDE:
                    case ShowWindowCommands.SW_SHOWMINIMIZED:
                    case ShowWindowCommands.SW_SHOWMAXIMIZED:
                    case ShowWindowCommands.SW_SHOWMINNOACTIVE:
                    case ShowWindowCommands.SW_FORCEMINIMIZE:
                        SetWindowPos(Controller.ControllerPtr, HWND_NOTOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_NOACTIVATE);
                        ShowWindow(Controller.ControllerPtr, ShowWindowCommands.SW_HIDE);
                        break;
                    case ShowWindowCommands.SW_SHOWNORMAL:
                    case ShowWindowCommands.SW_SHOWNOACTIVATE:
                    case ShowWindowCommands.SW_SHOW:
                    case ShowWindowCommands.SW_SHOWNA:
                    case ShowWindowCommands.SW_RESTORE:
                    case ShowWindowCommands.SW_SHOWDEFAULT:
                        SetWindowPos(Controller.ControllerPtr, HWND_TOPMOST, 0, 0, 0, 0, SWP_NOMOVE | SWP_NOSIZE | SWP_NOACTIVATE);
                        ShowWindow(Controller.ControllerPtr, ShowWindowCommands.SW_SHOWNOACTIVATE);
                        break;
                }
            }
        }
        #endregion

        private static Timer timer;

        private static GCHandle handle;

        public static void StartListening()
        {
            // 名前でハンドルを取得する
            IntPtr hwnd = FindWindow(null, Setting.Main.select_Device_Info.Model_Name);

            // 最大20回までリトライ
            int retryTimes = 20;
            while (hwnd == IntPtr.Zero)
            {
                if (retryTimes == 0) break;
                hwnd = FindWindow(null, Setting.Main.select_Device_Info.Model_Name);
                if (hwnd != IntPtr.Zero) break;
                System.Threading.Thread.Sleep(500);
                retryTimes--;
            }
            if (hwnd != IntPtr.Zero)
            {
                timer = new Timer(30);
                timer.Elapsed += (sender, e) =>
                {
                    UpdateLocation(hwnd);
                    UpdateStatus(hwnd);
                };
                timer.Start();
            }
        }
        public static void StopListening()
        {
            if (hWinEventHook != IntPtr.Zero)
            {
                UnhookWinEvent(hWinEventHook);
            }
                
            if (timer != null)
            {
                timer.Stop();
                timer.Dispose();
            }

            if (handle.IsAllocated)
            {
                handle.Free();
            }
        }
    }
}
