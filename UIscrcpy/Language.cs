using IFiles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static UIscrcpy.UIsrcpy;

namespace UIscrcpy
{
    internal class Lng
    {
        // 言語のフォルダ
        static public string Language_Path;

        public List<string> Name = new List<string>();
        //        static public string[] Files = null;
        static public string[] Dirs = null;
        static public IniFile ini = new IniFile();

        static public void Language_Init()
        {
            DirectoryInfo info;
            // 言語用フォルダを作成
            info = Directory.CreateDirectory(Setting.App_Path + "Language");
            Language_Path = info.FullName + "\\";

            Dirs = System.IO.Directory.GetDirectories(Language_Path);
            if (Dirs.Length < 1)
            {
                // 日本語
                info = Directory.CreateDirectory(Language_Path + "jp");
                foreach (string Name in Lng_Main_en.Keys)
                {
                    ini["Main", Name] = Name;
                }
                foreach (string Name in Lng_Msg_en.Keys)
                {
                    ini["Msg", Name] = Name;
                }
                ini.Save(info.FullName + "\\" + "Dictionary.txt");

                info = Directory.CreateDirectory(Language_Path + "jp\\Image");
                CopyFiles(".\\Resources\\Image\\Device_Regist\\jp", Language_Path + "jp\\Image", true);

                // 英語
                info = Directory.CreateDirectory(Language_Path + "en");
                foreach (string Name in Lng_Main_en.Keys)
                {
                    ini["Main", Name] = Lng_Main_en[Name];
                }
                foreach (string Name in Lng_Msg_en.Keys)
                {
                    ini["Msg", Name] = Lng_Msg_en[Name];
                }
                ini.Save(info.FullName + "\\" + "Dictionary.txt");

                info = Directory.CreateDirectory(Language_Path + "en\\Image");
                CopyFiles(".\\Resources\\Image\\Device_Regist\\en", Language_Path + "en\\Image", true);
            }
            Dirs = ["jp", "en"];
        }

        static public void Language_Load(string Lng_Name)
        {
            string FileName = Language_Path + Lng_Name + "\\Dictionary.txt";
            ini = new IniFile(FileName);
        }

        // 指定のディレクトリ内のファイルを別のディレクトリにコピーする
        static public void CopyFiles(string sourceDirectory, string destinationDirectory, bool overwrite = false)
        {
            // コピー元ディレクトリが存在しない場合は例外をスロー
            if (!Directory.Exists(sourceDirectory))
            {
                return;
            }

            // コピー先ディレクトリが存在しない場合は作成
            if (!Directory.Exists(destinationDirectory))
            {
                Directory.CreateDirectory(destinationDirectory);
            }

            // コピー元ディレクトリ内のファイルを取得
            string[] files = Directory.GetFiles(sourceDirectory);

            foreach (string file in files)
            {
                // ファイル名を取得
                string fileName = Path.GetFileName(file);
                // コピー先のファイルパスを生成
                string destinationFile = Path.Combine(destinationDirectory, fileName);

                try
                {
                    // ファイルをコピー
                    File.Copy(file, destinationFile, overwrite);
                }
                catch (IOException e)
                {
                    // 必要に応じて例外処理を追加
                }
            }
        }

        static public Dictionary<string, string> Lng_Main_en = new Dictionary<string, string>()
        {
            {"言語","Language"},
            {"確定","Ok"},
            {"はい","Yes"},
            {"いいえ","No"},
            {"次へ","Next"},
            {"戻る","Back"},
            {"取り消し","Cancel"},
            {"中止","Cancel"},
            {"再試行","Retry"},
            {"無視","Ignore"},
            {"選択","Select"},
            {"開く","Open"},
            {"編集","Edit"},
            {"設定","Setting"},
            {"閉じる","Close"},
            {"登録/削除","Register/Delete"},
            {"登録","Registration"},
            {"削除","Delete"},
            {"接続","Connection"},
            {"開始","Start"},
            {"終了","Close"},
            {"録画","Recording"},
            {"保存用フォルダ","Storage Folder"},
            {"プリセット","Preset"},
            {"scrcpyのフォルダを選択して下さい。","Select the scrcpy folder."},
            {"スクリーンショット及び録画の保存用フォルダを選択して下さい。","Select a folder for saving screenshots and recordings."},
            {"フォルダ","Folder"},
            {"ショートカットキー[option]","Shortcut key[MOD]"},
            {"最初に端末の【登録】を行って下さい。","First, please register your device."},
            {"接続する端末","Connecting device"},
            {"アプリを起動","Launch the app"},

            {"オプション","Option"},
            {"映像","Video"},
            {"音声","Audio"},
            {"ビデオサイズ(最大)","Video Size(Max)"},
            {"フレームレート(最大)","Frame Rate(Max)"},
            {"ビットレート","Bitrate"},
            {"ビデオバッファ","Video Buffer"},
            {"オーディオバッファ","Audio Buffer"},
            {"フルスクリーン表示","Full Screen"},
            {"窓枠を非表示(ボーダレス)にする","Hide window frames(borderless)"},
            {"スクリーンセーバを無効化","Disable screen saver"},
            {"タップを表示する","Show Tap"},
            {"端末のスリープを無効化","Disable device sleep"},

            {"端末の登録/削除","Register/removing devices"},
            {"登録済みの端末","Registered devices"},

            {"画像","Image"},
            {"※左クリックで画像を拡大","* Click the left mouse button to enlarge the image"},
            {"以下の手順に従って開始して下さい。","Follow these steps to get started."},
            {"①端末を開発者モードにします。","(1) Set the device to developer mode."},
            {"端末の機種によって設定場所は違いますが、「端末情報」や「デバイス情報」の中にある「ビルド番号」や「シリアル番号」などの項目を7回以上タップすると「開発者モードに切り替わりました」と表示され、メニューのどこかに「開発者オプション」が追加表示されます。","The setting location differs depending on the device model, but if you tap items such as \"build number\" or \"serial number\" in \"device information\" or \"device information\" at least seven times, \"Switched to developer mode\" will be displayed and \"Developer options\" will be additionally displayed somewhere on the menu."},
            {"②メニューの「開発者オプション」から「USBデバッグ」をONにします。尚、Wifi接続する場合は「ワイヤレスデバッグ」もONにします。","(2) Go to \"Developer Options\" in the menu and turn on \"USB Debugging\". If you use Wifi connection, turn on \"Wireless Debugging\" as well."},
            {"③端末をPCにUSB接続します。","(3) Connect the device to a PC via USB."},
            {"接続時に「USBデバッグを許可しますか？」又は「ワイヤレスデバッグを許可しますか？」のダイヤログが表示された場合、チェックして「許可」をタップしてください。","When connecting, the question \"Do you want to allow USB debugging? or \"Do you allow wireless debugging? dialog box appears, check the box and \"Allow\"the connection."},
            {"④ワイヤレスデバック」をタップすると、「IPアドレスとポート」が表示されています。後で必要になるのでメモをしておいて下さい。","(4) Tap \"Wireless Debugging\" and you will see \"IP Address and Port\". Please make a note of them as you will need them later."},
            {"準備が出来たら「次へ」をクリックしてください。","When you are ready, click \"Next\"."},
            {"端末のＩＰアドレスを確認して下さい。","Check the IP address of the device."},
            {"よろしければ「次へ」をクリックして下さい。","If correct, click \"Next\"."},
            {"※良く分からない場合は、そのまま「次へ」をクリックして下さい。","* If you are unsure, click \"Next\" as is."},
            {"「設定」→「ネットワークとインターネット」→「WiFi」→ 接続しているネットワーク名をタップすると、詳細情報が表示され、その中にIPアドレスが記載されています。","Tap \"Settings\" > \"Network and Internet\" > \"WiFi\" > the name of the network you are connected to, and you will see detailed information, which includes the IP address."},
            {"【例】192.168.1.28 などの部分です。","Example: 192.168.1.28, etc."},
            {"※端末の機種によって操作方法が異なる場合があります。詳しくは端末の説明書をご覧ください。","* Operation methods may differ depending on the handset model. Please refer to the handset manual for details."},

            {"アプリ","Apps"},
            {"端末と同じ状態に更新する","Update to the same state as the device"},
            {"アイコンをダウンロード","Download Icons"},

            {"ショートカットの一覧","List of shortcuts"},
            {"ホーム","Home"},
            {"メニュー","Menu"},
            {"スクリーンショット","Screenshot"},
            {"音量＋","Volume +"},
            {"音量－","Volume -"},
            {"消音","Mute"},
            {"電源","Power"},
        };

        static public Dictionary<string, string> Lng_Msg_en = new Dictionary<string, string>()
        {
            {"メッセージ","Message"},
            {"確認","Confirmation"},
            {"起動中","Starting up"},
            {"接続中","Connecting"},
            {"アプリを取得中。暫くお待ちください","Getting the app now. Please wait a moment"},
            {"アイコンを取得中。暫くお待ちください","Icons are being acquired. Please wait a moment"},
            {"アプリのアイコンをGoogle Playストアからダウンロードします。ダウンロードにはインターネットへの接続と処理時間がかかります。続行しますか？","Download the app icon from the Google Play Store.The download will require an internet connection and processing time.Would you like to continue?"},
            {"ファイルが見つかりません。","File not found."},
            {"フォルダが見つかりません。","Folder not found."},
            {"フォルダを選択してください。","Please select a folder."},
            {"端末が選択されていません。","No device is selected."},
            {"接続できませんでした。","Could not connect."},
            {"登録が完了しました。","Registration is complete."},
            {"この端末は既に登録されています。","This device is already registered."},
            {"このデバイスをWiFi接続しますか？","Do you want to connect this device to WiFi?"},
            {"選択された端末をリストから削除します。よろしいですか？","Remove the selected device from the list.Are you sure?"},
            {"ＩＰアドレスが入力されていません。","IP address is not entered."},
            {"画像は以下のフォルダに保存されました。","The images were saved in the following folders."},
            {"録画は以下のフォルダに保存されました。","The recordings were saved in the following folders."},

            {"開発環境","Development"},
            {"このソフトウェアは","This software is"},
            {"お使いのバージョンは最新です。","Your version is the latest."},
            {"最新バージョンはこちらからDLできます。","The latest version can be downloaded here."},
            {"が公開されています。","is available to the public."},
            {"リンクが開けませんでした。","I could not open the link."},
            {"新しい端末が検出されました。登録しますか？","New device detected. Would you like to register?"},
            {"アプリの取得に失敗しました。\"scrcpy\"のフォルダを、\"UIscrcpy\"のフォルダ内とは別の場所に移動して実行してみてください。","Failed to retrieve the application. Try moving the \"scrcpy\" folder to a different location than in the \"UIscrcpy\" folder and running it."},
        };

    }
}
