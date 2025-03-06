using Microsoft.VisualBasic.ApplicationServices;
using System.Drawing;
using UIscrcpy.URL;

namespace UIscrcpy
{
    public partial class Form_App_List : Form
    {
        public App_Info App_Info = new App_Info();

        private bool Form_Loard = false;
        private bool Decision = false;
        private Command command = new Command();

        public Form_App_List()
        {
            InitializeComponent();
            Language_Display_Refresh();
        }

        private void Language_Display_Refresh()
        {
            this.Text = Lng.ini["Main", "アプリ"];
            Button_Get_App.Text = Lng.ini["Main", "端末と同じ状態に更新する"];
            Button_Get_Icon.Text = Lng.ini["Main", "アイコンをダウンロード"];
            Button_Cancel.Text = Lng.ini["Main", "取り消し"];
            Button_Decision.Text = Lng.ini["Main", "確定"];
        }

        private void Form_App_List_Load(object sender, EventArgs e)
        {
            this.Owner.Hide();

            Form_Loard = false;

            ListView_App_List_Init();
            Form_Loard = true;
        }

        private void Form_App_List_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Decision)
            {
                int Index = ListView_App_List.SelectedItems[0].Index;
                App_Info = Setting.Main.select_Device_Info.App_List[Index];
            }
            this.Owner.Show();
        }

        private void ListView_App_List_Init()
        {
            ListView_App_List.Clear();
            ImageList_Picture.Images.Clear();

            for (int i = 0; i < Setting.Main.select_Device_Info.App_List.Count; ++i)
            {
                App_Info app_Info = new App_Info();
                app_Info = Setting.Main.select_Device_Info.App_List[i];

                Image img = null;
                // アイコンファイルが存在するか確認する
                string File_Name = app_Info.Package + ".png";
                File_Name = Setting.App_Icon_Path + File_Name;
                if (File.Exists(File_Name))
                {
                    img = Image.FromFile(File_Name);
                }
                else
                {
                    img = Image.FromFile(".\\Resources\\Image\\android.png");
                }
                ImageList_Picture.Images.Add(img);
                ListView_App_List.Items.Add(Setting.Main.select_Device_Info.App_List[i].Name, i);

                if (App_Info.Name == Setting.Main.select_Device_Info.App_List[i].Name)
                {
                    ListView_App_List.Items[i].Selected = true;
                }

                //画像を破棄
                if (img != null)
                {
                    img.Dispose();
                }
            }
            ListView_App_List.Select();
        }

        private void Button_Get_App_Click(object sender, EventArgs e)
        {
            Hide();
            Form_Waiting_Command Connect_device_Icon = new Form_Waiting_Command("App");
            Connect_device_Icon.Show();

            command.Application();
            if (command.deviceinfo.App_List != null)
            {
                Setting.Main.select_Device_Info.App_List = command.deviceinfo.App_List;
                ListView_App_List_Init();
            }
            Connect_device_Icon.Close();
            Show();
            Activate();
            Focus();
        }

        private void Button_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button_Decision_Click(object sender, EventArgs e)
        {
            Decision = true;
            this.Close();
        }

        private void Button_Get_Icon_Click(object sender, EventArgs e)
        {
            string Msg = Lng.ini["Msg", "アプリのアイコンをGoogle Playストアからダウンロードします。ダウンロードにはインターネットへの接続と処理時間がかかります。続行しますか？"];
            MBox mbox = new MBox(Lng.ini["Msg", "確認"], "QUESTION", Msg, "YesNo", "No");
            mbox.ShowDialog();
            if (mbox.Result == "Yes")
            {
                Hide();
                Form_Waiting_Command Connect_device_Icon = new Form_Waiting_Command("Icon");
                Connect_device_Icon.Show();

                Get_App_Icon();

                Connect_device_Icon.Close();
                Show();
                Activate();
                Focus();

                ListView_App_List_Init();
            }
        }
        // アイコンを取得する
        private void Get_App_Icon()
        {
            string File_Name = "";
            for (int i = 0; i < Setting.Main.select_Device_Info.App_List.Count; ++i)
            {
                File_Name = Setting.Main.select_Device_Info.App_List[i].Package + ".png";
                File_Name = Setting.App_Icon_Path + File_Name;
                //                if (!File.Exists(File_Name))
                //                {
                App_Icon app_Icon_Generator = new App_Icon();
                string url = app_Icon_Generator.Icon_Url_Search(Setting.Main.select_Device_Info.App_List[i].Package);
                if (url != "")
                {
                    app_Icon_Generator.Icon_DounLoad(Setting.Main.select_Device_Info.App_List[i].Package, url);
                }
                //                }
            }
        }

        private void ListView_App_List_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
