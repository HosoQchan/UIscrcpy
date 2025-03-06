using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using static UIscrcpy.UIsrcpy;

namespace UIscrcpy
{
    // メイン
    [XmlRoot("Main")]
    public class Main
    {
        [XmlElement("Language")]
        public string Language { get; set; } = "en";
        [XmlElement("scrcpy_path")]
        public string Scrcpy_Path { get; set; } = "";
        [XmlElement("MODkey")]
        public string Scrcpy_MODkey { get; set; } = "lalt";

        [XmlElement("preset_select_no")]
        public int preset_select_no { get; set; } = 0;
        [XmlElement("Rec_Start")]
        public bool Rec_Start { get; set; } = false;
        [XmlElement("Rec_path")]
        public string Rec_path { get; set; } = "";
        [XmlElement("Screenshot_path")]
        public string Screenshot_path { get; set; } = "";

        [XmlElement("preset_list")]
        public List<preset_item> preset_list { get; set; } = new List<preset_item>();
        [XmlElement("Device_List")]
        public List<Device_Info> Device_List { get; set; } = new List<Device_Info>();
        [XmlElement("select_Device_Info")]
        public Device_Info select_Device_Info { get; set; } = new Device_Info();
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
        public string video_buffer { get; set; } = "default";
        public string audio_bps { get; set; } = "default";
        public string audio_buffer { get; set; } = "default";

        public bool Disable_Sleep { set; get; } = false;
        public bool Tap_Display { set; get; } = false;
    }

    public class Device_Info
    {
        [XmlElement("Serial")]
        public string Serial { get; set; } = "";
        [XmlElement("Product_Name")]
        public string Product_Name { get; set; } = "";
        [XmlElement("Model_Name")]
        public string Model_Name { get; set; } = "";
        [XmlElement("IP_Adress")]
        public string IP_Adress { get; set; } = "";

        [XmlElement("Controller")]
        public Controller_item Controller { get; set; } = new Controller_item();
        [XmlElement("Scrcpy")]
        public Scrcpy_item Scrcpy { get; set; } = new Scrcpy_item();

        [XmlElement("App_Start")]
        public bool App_Start { get; set; } = false;
        [XmlElement("App_Start_Info")]
        public App_Info App_Start_Info { get; set; } = new App_Info();
        [XmlElement("App_List")]
        public List<App_Info> App_List { get; set; } = new List<App_Info>();
    }

    public class Controller_item
    {
        [XmlElement("PointX")]
        public int PointX { get; set; } = 0;
        [XmlElement("PointY")]
        public int PointY { get; set; } = 0;
        [XmlElement("Width")]
        public int Width { get; set; } = 57;
        [XmlElement("Height")]
        public int Height { get; set; } = 345;
    }

    public class Scrcpy_item
    {
        [XmlElement("PointX")]
        public int PointX { get; set; } = 0;
        [XmlElement("PointY")]
        public int PointY { get; set; } = 0;
        [XmlElement("Width")]
        public int Width { get; set; } = 0;
        [XmlElement("Height")]
        public int Height { get; set; } = 0;
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

    public class Setting
    {
        XmlSerializer Serializer_Main = new XmlSerializer(typeof(Main));

        // クラス化した設定値を、どのクラスからも読み書き出来るようにする
        static public Main Main = new Main();

        // アプリケーションのフォルダ
        static public string App_Path;

        // 録画保存用フォルダ
        static public string Rec_Path;

        // アプリアイコン保存用フォルダ
        static public string App_Icon_Path;

        // メインの設定ファイル名
        static public string Setting_Main_FileName;

        // プリセット名
        public static Dictionary<string, int> preset = new Dictionary<string, int>()
        {
             {"default" ,0},
             {"light"   ,1},
             {"medium"  ,2},
             {"high"    ,3},
        };
        // ショートカットキー
        public static Dictionary<string, int> modkey = new Dictionary<string, int>()
        {
             {"lctrl",0},
             {"rctrl",1},
             {"lalt",2},
             {"ralt",3},
             {"lsuper",4},
             {"rsuper",55}
        };

        public void Setting_Main_Load()
        {
            DirectoryInfo info;
            // ローカルのApplication Dataフォルダのパスを取得
            string Path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            // アプリケーションのフォルダ
            App_Path = System.AppDomain.CurrentDomain.BaseDirectory;

            // scrcpy用のフォルダを作成
            Scrcpy_Copy();

            // 録画保存用フォルダを作成
            info = Directory.CreateDirectory(App_Path + "Capture");
            Rec_Path = info.FullName + "\\";

            // アプリアイコン保存用フォルダを作成
            info = Directory.CreateDirectory(App_Path + "App_Icon");
            App_Icon_Path = info.FullName + "\\";

            Setting_Main_FileName = App_Path + "UIscrcpy.xml";
            if (File.Exists(Setting_Main_FileName))
            {
                Main_load();        // 設定を読み込む
            }
            else
            {
                Main_init();        // 設定の初期化
            }
        }
        private void Main_init()
        {
            Setting.Main.Scrcpy_Path = App_Path + "scrcpy";
            Setting.Main.Device_List.Clear();

            Setting.Main.Rec_path = Rec_Path;

            string DesktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            Setting.Main.Screenshot_path = Path.Combine(DesktopPath, "UIscrcpy Screenshots");

            // プリセットの初期化
            Setting.Main.preset_list.Clear();
            string Preset_Name;
            for (int i = 0; i < preset.Count; i++)
            {
                preset_item preset_Item = new preset_item();
                Preset_Name = preset.FirstOrDefault(kvp => kvp.Value == i).Key;
                preset_Item = Form_Edit_Preset.Preset_Init(Preset_Name);
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
        private void Main_load()
        {
            try
            {
                using (FileStream load_Data = new FileStream(Setting_Main_FileName, FileMode.Open))
                {
                    Main = (Main)Serializer_Main.Deserialize(load_Data);
                }
            }
            // 設定ファイルの読み込みに失敗したら、設定を初期化する
            catch
            {
                Main_init();        // 設定の初期化
            }
        }

        // ScrcpyをUiscrcpyフォルダ下にコピーする
        private void Scrcpy_Copy()
        {
            if (!Directory.Exists(App_Path + "scrcpy"))
            {
                // scrcpy用のフォルダを作成
                DirectoryInfo info;
                info = Directory.CreateDirectory(App_Path + "scrcpy");

                CopyDirectory(".\\scrcpy", App_Path);
            }
        }
        /// <summary>
        /// ディレクトリをコピーする
        /// </summary>
        /// <param name="sourceDirName">コピーするディレクトリ</param>
        /// <param name="destDirName">コピー先のディレクトリ</param>
        public static void CopyDirectory(
            string sourceDirName, string destDirName)
        {
            //コピー先のディレクトリがないときは作る
            if (!System.IO.Directory.Exists(destDirName))
            {
                System.IO.Directory.CreateDirectory(destDirName);
                //属性もコピー
                System.IO.File.SetAttributes(destDirName,
                    System.IO.File.GetAttributes(sourceDirName));
            }

            //コピー先のディレクトリ名の末尾に"\"をつける
            if (destDirName[destDirName.Length - 1] !=
                    System.IO.Path.DirectorySeparatorChar)
                destDirName = destDirName + System.IO.Path.DirectorySeparatorChar;

            //コピー元のディレクトリにあるファイルをコピー
            string[] files = System.IO.Directory.GetFiles(sourceDirName);
            foreach (string file in files)
                System.IO.File.Copy(file,
                    destDirName + System.IO.Path.GetFileName(file), true);

            //コピー元のディレクトリにあるディレクトリについて、再帰的に呼び出す
            string[] dirs = System.IO.Directory.GetDirectories(sourceDirName);
            foreach (string dir in dirs)
                CopyDirectory(dir, destDirName + System.IO.Path.GetFileName(dir));
        }
    }
}
