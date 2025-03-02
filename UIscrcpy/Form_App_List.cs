using Microsoft.VisualBasic.ApplicationServices;
using System.Drawing;

namespace UIscrcpy
{
    public partial class Form_App_List : Form
    {
        private bool Form_Loard = false;
        private bool Decision = false;
        public App_Info App_Info = new App_Info();

        public Form_App_List()
        {
            InitializeComponent();
        }

        private void Form_App_List_Load(object sender, EventArgs e)
        {
            this.Owner.Hide();

            Form_Loard = false;
            Device_Connection Form_Device_Connection1 = new Device_Connection();
            Form_Device_Connection1.Mode = 3;
            Form_Device_Connection1.ShowDialog();
            if (Form_Device_Connection1.Error)
            {
                this.Close();
            }
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
                File_Name = Setting.App_Data_Path + "\\App_Picture\\" + File_Name;
                if (File.Exists(File_Name))
                {
                    img = Image.FromFile(File_Name);
                }
                else
                {
                    img = Image.FromFile("C:\\Users\\hosoq\\source\\repos\\UIscrcpy\\UIscrcpy\\icon\\android_Icon.png");
                }
                ImageList_Picture.Images.Add(img);
                ListView_App_List.Items.Add(Setting.Main.select_Device_Info.App_List[i].Name, i);
                //画像を破棄
                if (img != null)
                {
                    img.Dispose();
                }
            }
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
            DialogResult result = MessageBox.Show("アプリのアイコンをGllgle Playストアからダウンロードします。\r\nダウンロードにはインターネットへの接続と処理時間がかかります。\r\nよろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                Device_Connection Form_Device_Connection1 = new Device_Connection();
                Form_Device_Connection1.Mode = 4;
                Form_Device_Connection1.ShowDialog();

                ListView_App_List_Init();
            }
        }

        private void ListView_App_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            if (Form_Loard)
            {
                int Index = ListView_App_List.SelectedItems[0].Index;
                Select_App = Setting.Device_Info.App_List[Index].Name;
            }
            */
        }
    }
}
