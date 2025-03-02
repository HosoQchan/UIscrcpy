using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace UIscrcpy
{
    // メイン
    [XmlRoot("Main")]
    public class Main
    {
        [XmlElement("scrcpy_path")]
        public string scrcpy_path { get; set; } = "";
        [XmlElement("Device_List")]
        public List<Device_Info> Device_List { get; set; } = new List<Device_Info>();
        [XmlElement("select_Device_Info")]
        public Device_Info select_Device_Info { get; set; } = new Device_Info();
        [XmlElement("preset_list")]
        public List<preset_item> preset_list { get; set; } = new List<preset_item>();
        [XmlElement("preset_select_no")]
        public int preset_select_no { get; set; } = 0;
        [XmlElement("Rec_Start")]
        public bool Rec_Start { get; set; } = false;
        [XmlElement("Rec_path")]
        public string Rec_path { get; set; } = "";
    }

    public class Device_Info
    {
        [XmlElement("Id_No")]
        public string Serial { get; set; } = "";
        [XmlElement("Product_Name")]
        public string Product_Name { get; set; } = "";
        [XmlElement("Model_Name")]
        public string Model_Name { get; set; } = "";
        [XmlElement("IP_Adress")]
        public string IP_Adress { get; set; } = "";
        [XmlElement("App_Start")]
        public bool App_Start { get; set; } = false;
        [XmlElement("App_Start_Info")]
        public App_Info App_Start_Info { get; set; } = new App_Info();
        [XmlElement("App_List")]
        public List<App_Info> App_List { get; set; } = new List<App_Info>();
    }
    public class App_Info
    {
        [XmlElement("Name")]
        public string Name { get; set; } = "";
        [XmlElement("Package")]
        public string Package { get; set; } = "";
        [XmlElement("Path")]
        public string Path { get; set; } = "";
    }

    public class preset_item
    {
        public string preset_Name { get; set; } = "default";
        public bool windows_full_screen { get; set; } = false;
        public bool windows_borderless { set; get; } = false;
        public bool windows_Disable_Screensaver { set; get; } = false;

        public string video_size { get; set; } = "default";
        public string video_bps { get; set; } = "default";
        public string video_fps { get; set; } = "default";
        public string video_buffer {  get; set; } = "default";
        public string audio_bps { get; set; } = "default";
        public string audio_buffer { get; set; } = "default";

        public bool Disable_Sleep { set; get; } = false;
        public bool Tap_Display { set; get; } = false;
    }

    public class Setting
    {
        XmlSerializer Serializer_Main = new XmlSerializer(typeof(Main));

        // クラス化した設定値を、どのクラスからも読み書き出来るようにする
        static public Main Main = new Main();
//        public Device_Info Device_Info = new Device_Info();

        // アプリケーションのフォルダ
        static public string App_Path;

        // アプリケーションの設定保存用フォルダ
        static public string App_Data_Path;

        // 録画保存用フォルダ
        static public string Rec_Path;

        // デバイスごとの保存用フォルダ
        static public string Device_Path;

        // bat用フォルダ
        static public string bat_Path;

        // メインの設定ファイル名
        static public string Setting_Main_FileName;
        static public bool Setting_Main_Read = false;     // メインの設定読み込み済フラグ

        /*
        // プリセット用のbatファイル名
        static string p_default_fileName = "priset_default.bat";
        static string p_light_fileName = "priset_light.bat";
        static string p_medium_fileName = "priset_medium.bat";
        static string p_high_fileName = "priset_high.bat";
        static string p_custom_fileName = "priset_custom.bat";
        */

        // プリセット名
        public static Dictionary<string, int> preset = new Dictionary<string, int>()
        {
             {"default" ,0},
             {"light"   ,1},
             {"medium"  ,2},
             {"high"    ,3},
             {"custom"  ,4}
        };

        public void Setting_Main_Create()
        {
            if (!Setting_Main_Read)
            {
                DirectoryInfo info;
                // ローカルのApplication Dataフォルダのパスを取得
                string Path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

                // アプリケーションのフォルダ
                App_Path = System.AppDomain.CurrentDomain.BaseDirectory;

                // scrcpy用のフォルダを作成
                info = Directory.CreateDirectory(App_Path + "scrcpy");

                // アプリケーションの設定保存用フォルダ
                info = Directory.CreateDirectory(Path + "\\UIscrcpy");
                App_Data_Path = info.FullName + "\\";
                Setting_Main_FileName = App_Data_Path + "Setting.xml";

                // 録画保存用フォルダを作成
                info = Directory.CreateDirectory(App_Data_Path + "Capture");
                Rec_Path = info.FullName;

                // Deviceごとの保存用フォルダを作成
                info = Directory.CreateDirectory(App_Data_Path + "Device");
                Device_Path = info.FullName + "\\";

                // アプリアイコン保存用フォルダを作成
                info = Directory.CreateDirectory(App_Data_Path + "App_Picture");

                // bat用のフォルダを作成
                info = Directory.CreateDirectory(App_Data_Path + "bat");
                bat_Path = info.FullName + "\\";

                if (File.Exists(Setting_Main_FileName))
                {
                    Main_load();        // 設定を読み込む
                }
                else
                {
                    Main_init();        // 設定の初期化
                }
            }
            Setting_Main_Read = true;
        }
        public void Main_init()
        {
            Setting.Main.scrcpy_path = App_Path + "scrcpy";
            Setting.Main.Device_List.Clear();

            Setting.Main.Rec_path = App_Data_Path + "Capture";
            // プリセットの初期化
            Setting.Main.preset_list.Clear();
            string Preset_Name;
            for (int i = 0; i < preset.Count; i++)
            {
                preset_item preset_Item = new preset_item();
                Preset_Name = preset.FirstOrDefault(kvp => kvp.Value == i).Key;
                preset_Item = Edit_Preset.Preset_Init(Preset_Name);
                Setting.Main.preset_list.Add(preset_Item);
            }
        }
        public void Main_save()
        {
            FileStream save_data = new FileStream(Setting_Main_FileName, FileMode.Create);
            StreamWriter writer = new StreamWriter(save_data, Encoding.UTF8);
            Serializer_Main.Serialize(writer, Main);
            writer.Flush();
            writer.Close();
        }
        public void Main_load()
        {
            FileStream load_Data = new FileStream(Setting_Main_FileName, FileMode.Open);
            Main = (Main)Serializer_Main.Deserialize(load_Data);
            load_Data.Close();
        }

        static public bool Command_File_Check()
        {
            if (!Directory.Exists(Setting.Main.scrcpy_path))
            {
                MessageBox.Show("[scrcpy]のフォルダが見つかりません。", "メッセージ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (!File.Exists(Setting.Main.scrcpy_path + "\\adb.exe"))
            {
                MessageBox.Show("[adb.exe]のファイルが見つかりません。", "メッセージ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (!File.Exists(Setting.Main.scrcpy_path + "\\scrcpy.exe"))
            {
                MessageBox.Show("[scrcpy.exe]のファイルが見つかりません。", "メッセージ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            return true;
        }

        
    }
}
