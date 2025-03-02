using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UIscrcpy
{
    public partial class Edit_Preset : Form
    {
        private bool Form_Loard = false;

        public Edit_Preset()
        {
            InitializeComponent();

            Cbox_video_size.Items.Add("default");
            Cbox_video_size.Items.Add("640");
            Cbox_video_size.Items.Add("800");
            Cbox_video_size.Items.Add("1024");
            Cbox_video_size.Items.Add("1920");
            Cbox_video_size.Items.Add("2560");
            Cbox_video_size.Items.Add("3840");

            Cbox_video_bps.Items.Add("default");
            Cbox_video_bps.Items.Add("2M");
            Cbox_video_bps.Items.Add("4M");
            Cbox_video_bps.Items.Add("8M");
            Cbox_video_bps.Items.Add("16M");
            Cbox_video_bps.Items.Add("32M");

            Cbox_video_fps.Items.Add("default");
            Cbox_video_fps.Items.Add("20");
            Cbox_video_fps.Items.Add("40");
            Cbox_video_fps.Items.Add("60");
            Cbox_video_fps.Items.Add("80");
            Cbox_video_fps.Items.Add("100");
            Cbox_video_fps.Items.Add("120");

            Cbox_video_buffer.Items.Add("default");
            Cbox_video_buffer.Items.Add("50");
            Cbox_video_buffer.Items.Add("100");
            Cbox_video_buffer.Items.Add("200");
            Cbox_video_buffer.Items.Add("300");

            Cbox_audio_bps.Items.Add("default");
            Cbox_audio_bps.Items.Add("32K");
            Cbox_audio_bps.Items.Add("64K");
            Cbox_audio_bps.Items.Add("128K");
            Cbox_audio_bps.Items.Add("192K");
            Cbox_audio_bps.Items.Add("320K");

            Cbox_audio_buffer.Items.Add("default");
            Cbox_audio_buffer.Items.Add("20");
            Cbox_audio_buffer.Items.Add("40");
            Cbox_audio_buffer.Items.Add("60");
            Cbox_audio_buffer.Items.Add("80");
            Cbox_audio_buffer.Items.Add("100");
            Cbox_audio_buffer.Items.Add("120");
        }

        private void Edit_Preset_Load(object sender, EventArgs e)
        {
            Preset_Setting_Load(Setting.Main.preset_select_no);
            TextBox_Preset_Name.Text = Setting.Main.preset_list[Setting.Main.preset_select_no].preset_Name;
            Form_Loard = true;
        }
        private void Edit_Preset_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Owner.Show();
        }

        private void Preset_Setting_Load(int Preset_No)
        {
            this.Owner.Hide();

            preset_item preset_item = new preset_item();
            preset_item = Setting.Main.preset_list[Preset_No];

            Cbox_video_size.Text = preset_item.video_size;
            Cbox_video_size.SelectedIndex = UIsrcpy.ComBox_Index_Get(Cbox_video_size);

            Cbox_video_bps.Text = preset_item.video_bps;
            Cbox_video_bps.SelectedIndex = UIsrcpy.ComBox_Index_Get(Cbox_video_bps);

            Cbox_video_fps.Text = preset_item.video_fps;
            Cbox_video_fps.SelectedIndex = UIsrcpy.ComBox_Index_Get(Cbox_video_fps);

            Cbox_video_buffer.Text = preset_item.video_buffer;
            Cbox_video_buffer.SelectedIndex = UIsrcpy.ComBox_Index_Get(Cbox_video_buffer);

            Cbox_audio_bps.Text = preset_item.audio_bps;
            Cbox_audio_bps.SelectedIndex = UIsrcpy.ComBox_Index_Get(Cbox_audio_bps);

            Cbox_audio_buffer.Text = preset_item.audio_buffer;
            Cbox_audio_buffer.SelectedIndex = UIsrcpy.ComBox_Index_Get(Cbox_audio_buffer);

            CheckB_full_screen.Checked = preset_item.windows_full_screen;
            CheckB_window_borderless.Checked = preset_item.windows_borderless;
            CheckB_Disable_Screensaver.Checked = preset_item.windows_Disable_Screensaver;

            CheckB_Disable_Sleep.Checked = preset_item.Disable_Sleep;
            CheckB_Tap_Disp.Checked = preset_item.Tap_Display;
        }

        private void Preset_Setting_Save(int Preset_No)
        {
            preset_item preset_item = new preset_item();
            preset_item.windows_full_screen = CheckB_full_screen.Checked;
            preset_item.windows_borderless = CheckB_window_borderless.Checked;
            preset_item.windows_Disable_Screensaver = CheckB_Disable_Screensaver.Checked;

            preset_item.video_size = Cbox_video_size.Text;
            preset_item.video_bps = Cbox_video_bps.Text;
            preset_item.video_fps = Cbox_video_fps.Text;
            preset_item.video_buffer = Cbox_video_buffer.Text;
            preset_item.audio_bps = Cbox_audio_bps.Text;
            preset_item.audio_buffer = Cbox_audio_buffer.Text;

            preset_item.Disable_Sleep = CheckB_Disable_Sleep.Checked;
            preset_item.Tap_Display = CheckB_Tap_Disp.Checked;

            Setting.Main.preset_list[Preset_No] = preset_item;
        }

        private StringBuilder edit_bat()
        {
            StringBuilder w = new StringBuilder();

            // バッチ内で一時的にPATHを通す
            //  set PATH=%PATH%;アプリのパス;

            return w;
        }




        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button_Decision_Click(object sender, EventArgs e)
        {
            Preset_Setting_Save(Setting.Main.preset_select_no);
            this.Close();
        }

        static public preset_item Preset_Init(string Preset_Name)
        {
            preset_item preset_Item = new preset_item();
            switch (Preset_Name)
            {
                case "default":
                    preset_Item = Preset_default_Init();
                    break;
                case "light":
                    preset_Item = Preset_light_Init();
                    break;
                case "medium":
                    preset_Item = Preset_medium_Init();
                    break;
                case "high":
                    preset_Item = Preset_high_Init();
                    break;
                case "custom":
                    preset_Item = Preset_custom_Init();
                    break;
            }
            return preset_Item;
        }

        static public preset_item Preset_default_Init()
        {
            preset_item preset_Item = new preset_item();
            preset_Item.preset_Name = "default";

            preset_Item.windows_full_screen = false;
            preset_Item.windows_borderless = false;
            preset_Item.windows_Disable_Screensaver = false;

            preset_Item.video_size = "default";
            preset_Item.video_bps = "default";
            preset_Item.video_fps = "default";
            preset_Item.video_buffer = "default";
            preset_Item.audio_bps = "default";
            preset_Item.audio_buffer = "default";

            preset_Item.Disable_Sleep = false;
            preset_Item.Tap_Display = false;
            return preset_Item;
        }
        static public preset_item Preset_light_Init()
        {
            preset_item preset_Item = new preset_item();
            preset_Item.preset_Name = "light";

            preset_Item.windows_full_screen = false;
            preset_Item.windows_borderless = false;
            preset_Item.windows_Disable_Screensaver = false;

            preset_Item.video_size = "800";
            preset_Item.video_bps = "default";
            preset_Item.video_fps = "40";
            preset_Item.video_buffer = "default";
            preset_Item.audio_bps = "64K";
            preset_Item.audio_buffer = "default";

            preset_Item.Disable_Sleep = false;
            preset_Item.Tap_Display = false;
            return preset_Item;
        }
        static public preset_item Preset_medium_Init()
        {
            preset_item preset_Item = new preset_item();
            preset_Item.preset_Name = "medium";

            preset_Item.windows_full_screen = false;
            preset_Item.windows_borderless = false;
            preset_Item.windows_Disable_Screensaver = false;

            preset_Item.video_size = "1024";
            preset_Item.video_bps = "default";
            preset_Item.video_fps = "60";
            preset_Item.video_buffer = "default";
            preset_Item.audio_bps = "128K";
            preset_Item.audio_buffer = "default";

            preset_Item.Disable_Sleep = false;
            preset_Item.Tap_Display = false;
            return preset_Item;
        }
        static public preset_item Preset_high_Init()
        {
            preset_item preset_Item = new preset_item();
            preset_Item.preset_Name = "high";

            preset_Item.windows_full_screen = false;
            preset_Item.windows_borderless = false;
            preset_Item.windows_Disable_Screensaver = false;

            preset_Item.video_size = "default";
            preset_Item.video_bps = "default";
            preset_Item.video_fps = "120";
            preset_Item.video_buffer = "default";
            preset_Item.audio_bps = "320K";
            preset_Item.audio_buffer = "default";

            preset_Item.Disable_Sleep = false;
            preset_Item.Tap_Display = false;
            return preset_Item;
        }
        static public preset_item Preset_custom_Init()
        {
            preset_item preset_Item = new preset_item();
            preset_Item.preset_Name = "custom";

            preset_Item.windows_full_screen = false;
            preset_Item.windows_borderless = false;
            preset_Item.windows_Disable_Screensaver = false;

            preset_Item.video_size = "default";
            preset_Item.video_bps = "default";
            preset_Item.video_fps = "default";
            preset_Item.video_buffer = "default";
            preset_Item.audio_bps = "default";
            preset_Item.audio_buffer = "default";

            preset_Item.Disable_Sleep = false;
            preset_Item.Tap_Display = false;
            return preset_Item;
        }
    }

}
