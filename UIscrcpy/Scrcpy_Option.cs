using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIscrcpy
{
    internal class Scrcpy_Option
    {
        public string Option()
        {
            string option = " --keyboard=sdk --gamepad=uhid";

            option = option +
                        op_Shortcut() +
                        op_full_screen() +
                        op_window_borderless() +
                        op_Disable_Screensaver() +

                        op_video_size() +
                        op_video_bps() +
                        op_video_fps() +
                        op_video_buffer() +
                        op_audio_bps() +
                        op_audio_buffer() +

                        op_Disable_Sleep() +
                        op_Tap_Display() +

                        op_Start_App() +
                        op_Start_Rec() +

                        op_Title() +
                        op_Size() +
                        op_Point();
            return option;
        }

        private string op_Shortcut()
        {
            string Shortcut = Setting.Main.Scrcpy_MODkey;
            string option = "";
            if (Shortcut != "")
            {
                option = " --shortcut-mod=" + Shortcut;
            }
            return option;
        }
        private string op_full_screen()
        {
            bool full_screen = Setting.Main.preset_list[Setting.Main.preset_select_no].windows_full_screen;
            string option = "";
            if (full_screen == true)
            {
                option = " --fullscreen";
            }
            return option;
        }
        private string op_window_borderless()
        {
            bool window_borderless = Setting.Main.preset_list[Setting.Main.preset_select_no].windows_borderless;
            string option = "";
            if (window_borderless == true)
            {
                option = " --window-borderless";
            }
            return option;
        }
        private string op_Disable_Screensaver()
        {
            bool Disable_Screensaver = Setting.Main.preset_list[Setting.Main.preset_select_no].windows_Disable_Screensaver;
            string option = "";
            if (Disable_Screensaver == true)
            {
                option = " --disable-screensaver";
            }
            return option;
        }
        private string op_video_size()
        {
            string video_size = Setting.Main.preset_list[Setting.Main.preset_select_no].video_size;
            string option = "";
            if (video_size != "default")
            {
                option = " --max-size=" + video_size;
            }
            return option;
        }
        private string op_video_bps()
        {
            string video_bps = Setting.Main.preset_list[Setting.Main.preset_select_no].video_bps;
            string option = "";
            if (video_bps != "default")
            {
                option = " --video-bit-rate=" + video_bps;
            }
            return option;
        }
        private string op_video_fps()
        {
            string video_fps = Setting.Main.preset_list[Setting.Main.preset_select_no].video_fps;
            string option = "";
            if (video_fps != "default")
            {
                option = " --max-fps=" + video_fps;
            }
            return option;
        }
        private string op_video_buffer()
        {
            string video_buffer = Setting.Main.preset_list[Setting.Main.preset_select_no].video_buffer;
            string option = "";
            if (video_buffer != "default")
            {
                option = " --video-buffer=" + video_buffer;
            }
            return option;
        }
        private string op_audio_bps()
        {
            string audio_bps = Setting.Main.preset_list[Setting.Main.preset_select_no].audio_bps;
            string option = "";
            if (audio_bps != "default")
            {
                option = " --audio-bit-rate=" + audio_bps;
            }
            return option;
        }
        private string op_audio_buffer()
        {
            string audio_buffer = Setting.Main.preset_list[Setting.Main.preset_select_no].audio_buffer;
            string option = "";
            if (audio_buffer != "default")
            {
                option = " --audio-buffer=" + audio_buffer;
            }
            return option;
        }
        private string op_Disable_Sleep()
        {
            bool Disable_Sleep = Setting.Main.preset_list[Setting.Main.preset_select_no].Disable_Sleep;
            string option = "";
            if (Disable_Sleep == true)
            {
                option = " --stay-awake";
            }
            return option;
        }
        private string op_Tap_Display()
        {
            bool Tap_Display = Setting.Main.preset_list[Setting.Main.preset_select_no].Tap_Display;
            string option = "";
            if (Tap_Display == true)
            {
                option = " --show-touches";
            }
            return option;
        }
        private string op_Start_App()
        {
            bool Start_App = Setting.Main.select_Device_Info.App_Start;
            string option = "";
            if (Start_App == true)
            {
                option = " --start-app=" + Setting.Main.select_Device_Info.App_Start_Info.Package;
            }
            return option;
        }
        private string op_Start_Rec()
        {
            bool Start_Rec = Setting.Main.Rec_Start;
            string option = "";
            if (Start_Rec == true)
            {
                string File_Name = DateTime.Now.ToString(UIsrcpy.DatetimeFormat);
                option = @" --record=""" + Setting.Main.Rec_path + "\\" + Setting.Main.select_Device_Info.Model_Name + "_" + File_Name + @".mp4""";
                Debug.WriteLine(option);
            }
            return option;
        }
        private string op_Title()
        {
            string option = "";
            option = $" --window-title \"" + Setting.Main.select_Device_Info.Model_Name + $"\"";
            return option;
        }
        private string op_Size()
        {
            int Height = Setting.Main.select_Device_Info.Scrcpy.Height;
            int Width = Setting.Main.select_Device_Info.Scrcpy.Width;
            string option = "";
            if (Height > 0)
            {
                option = option + " --window-height" + Height.ToString();
            }
            if (Width > 0)
            {
                option = option + " --window-width" + Width.ToString();
            }
            return option;
        }
        private string op_Point()
        {
            int PointX = Setting.Main.select_Device_Info.Scrcpy.PointX;
            int PointY = Setting.Main.select_Device_Info.Scrcpy.PointY;
            string option = "";
            if (PointX + PointY > 0)
            {
                option = " --window-x=" + PointX.ToString();
                option = option + " --window-y=" + PointY.ToString();
            }
            return option;
        }
    }
}
