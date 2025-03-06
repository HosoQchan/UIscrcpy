using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIscrcpy
{
    internal class System_Sound
    {
        /*
        Windowsの起動 SystemStart
        Windowsの終了 SystemExit
        Windowsログオフ WindowsLogoff
        Windowsログオン WindowsLogon
        システムエラー SystemHand
        システム通知 SystemNotification
        ツールバーバインドの表示 ShowBand
        デバイスの切断 DeviceDisconnect
        デバイスの接続 DeviceConnect
        デバイスの接続の失敗 DeviceFail
        バッテリー切れアラーム CriticalBatteryAlarm
        バッテリー低下アラーム LowBatteryAlarm
        プログラムエラー AppGPFault
        プログラムの起動 Open
        プログラムの終了 Close
        メッセージ（警告）	SystemExclamation
        メッセージ（情報）	SystemAsterisk
        メッセージ（問い合わせ）	SystemQuestion
        メニューコマンド    MenuCommand
        メニューポップアップ  MenuPopup
        一般の警告音.Default
        印刷完了 PrintComplete
        元に戻す（拡大）	RestoreUp
        元に戻す（縮小）	RestoreDown
        最小化 Minimize
        最大化 Maximize
        新着メールの通知    MailBeep
        選択  CCSelect
        */

        static public void Play_SystemSound(string Sound_Name)
        {
            switch (Sound_Name)
            {
                case "QUESTION":
                case "INFORMATION":
                    //メッセージ（情報）を鳴らす
                    System.Media.SystemSounds.Asterisk.Play();
                    break;
                default:
                    //システムエラーを鳴らす
                    System.Media.SystemSounds.Hand.Play();
                    break;
            }
        }
    }
}
