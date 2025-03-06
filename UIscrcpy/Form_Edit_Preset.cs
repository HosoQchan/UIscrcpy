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
    public partial class Form_Edit_Preset : Form
    {
        private bool Form_Loard = false;

        public Form_Edit_Preset()
        {
            InitializeComponent();
            Language_Display_Refresh();
            this.Icon = new Icon(".\\Resources\\Icon\\Setting.ico");

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

        private void Language_Display_Refresh()
        {
            this.Text = Lng.ini["Main", "設定"];
            Button_Cancel.Text = Lng.ini["Main", "取り消し"];
            Button_Decision.Text = Lng.ini["Main", "確定"];

            Label_Preset.Text = Lng.ini["Main", "プリセット"];
            Label_Video_size.Text = Lng.ini["Main", "ビデオサイズ(最大)"];
            Label_Video_bps.Text = Lng.ini["Main", "ビットレート"];
            Label_Video_fps.Text = Lng.ini["Main", "フレームレート(最大)"];
            Label_Video_buffer.Text = Lng.ini["Main", "ビデオバッファ"];
            Label_Audio_bps.Text = Lng.ini["Main", "ビットレート"];
            Label_Audio_buffer.Text = Lng.ini["Main", "オーディオバッファ"];

            CheckB_full_screen.Text = Lng.ini["Main", "フルスクリーン表示"];
            CheckB_window_borderless.Text = Lng.ini["Main", "窓枠を非表示(ボーダレス)にする"];
            CheckB_Disable_Screensaver.Text = Lng.ini["Main", "スクリーンセーバを無効化"];
            CheckB_Tap_Disp.Text = Lng.ini["Main", "タップを表示する"];
            CheckB_Disable_Sleep.Text = Lng.ini["Main", "端末のスリープを無効化"];

            GBox_Option.Text = Lng.ini["Main", "オプション"];
            GBox_Picture.Text = Lng.ini["Main", "映像"];
            GBox_Audio.Text = Lng.ini["Main", "音声"];
        }

        private void Form_Edit_Preset_Load(object sender, EventArgs e)
        {
            Preset_Setting_Load(Setting.Main.preset_select_no);
            TextBox_Preset_Name.Text = Setting.Main.preset_list[Setting.Main.preset_select_no].preset_Name;
            Form_Loard = true;
        }
        private void Form_Edit_Preset_Closed(object sender, FormClosedEventArgs e)
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
            preset_item = Setting.Main.preset_list[Preset_No];

            preset_item.preset_Name = TextBox_Preset_Name.Text;
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
            }
            return preset_Item;
        }

        static public preset_item Preset_default_Init()
        {
            preset_item preset_Item = new preset_item();
            preset_Item.preset_Name = "default";
            return preset_Item;
        }
        static public preset_item Preset_light_Init()
        {
            preset_item preset_Item = new preset_item();
            preset_Item.preset_Name = "light";

            preset_Item.video_size = "800";
            preset_Item.video_fps = "40";
            preset_Item.audio_bps = "64K";
            return preset_Item;
        }
        static public preset_item Preset_medium_Init()
        {
            preset_item preset_Item = new preset_item();
            preset_Item.preset_Name = "medium";

            preset_Item.video_size = "1024";
            preset_Item.video_fps = "60";
            preset_Item.audio_bps = "128K";
            return preset_Item;
        }
        static public preset_item Preset_high_Init()
        {
            preset_item preset_Item = new preset_item();
            preset_Item.preset_Name = "high";

            preset_Item.video_fps = "120";
            preset_Item.audio_bps = "320K";
            return preset_Item;
        }
    }
}
