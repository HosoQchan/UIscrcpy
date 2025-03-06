using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace UIscrcpy
{
    public partial class Form_Device_List : Form
    {
        int Max_Size_x;
        public int Device_Count = 0;
        public bool Edit_Flag = false;

        public Form_Device_List()
        {
            InitializeComponent();
            this.Icon = new Icon(".\\Resources\\Icon\\Plus_Minus.ico");

            Language_Display_Refresh();
            Max_Size_x = this.Width;
        }

        private void Language_Display_Refresh()
        {
            this.Text = Lng.ini["Main", "端末の登録/削除"];
            Label_Info.Text = Lng.ini["Main", "登録済みの端末"];

            Button_Add.Text = Lng.ini["Main", "登録"];
            Button_Del.Text = Lng.ini["Main", "削除"];
            Button_Exit.Text = Lng.ini["Main", "閉じる"];
        }

        private void Button_Add_Click(object sender, EventArgs e)
        {
            int Device_count = ListView_Device.Items.Count;
            Form_Device_Regist Form = new Form_Device_Regist(1);
            Form.ShowDialog();
            List_Display();
        }

        private void Form_Device_List_SizeChanged(object sender, EventArgs e)
        {
            //フォームの幅がMax_Size_xより大きくならないようにする
            if (Max_Size_x < this.Width)
            {
                this.Width = Max_Size_x;
            }
        }

        private void Form_Device_List_Load(object sender, EventArgs e)
        {
            Device_Count = Setting.Main.Device_List.Count;
            this.Owner.Hide();

            List_Display();
        }
        private void Form_Device_List_Closed(object sender, FormClosedEventArgs e)
        {
            if (Device_Count != Setting.Main.Device_List.Count)
            {
                Edit_Flag = true;
            }
            this.Owner.Show();
        }

        private void List_Display()
        {
            string Id_No;
            string Product_Name;
            string Model_Name;
            string IP_Adress;

            ListView_Device.Items.Clear();
            for (int i = 0; i < Setting.Main.Device_List.Count; ++i)
            {
                Id_No = Setting.Main.Device_List[i].Serial;
                Product_Name = Setting.Main.Device_List[i].Product_Name;
                Model_Name = Setting.Main.Device_List[i].Model_Name;
                IP_Adress = Setting.Main.Device_List[i].IP_Adress;
                ListView_Device.Items.Add(new ListViewItem(new string[] { Id_No, Product_Name, Model_Name, IP_Adress }));
            }
        }

        private void Button_Del_Click(object sender, EventArgs e)
        {
            string Msg = "";
            MBox mbox;
            // 選択項目があるかどうかを確認する
            if (ListView_Device.SelectedItems.Count == 0)
            {
                Msg = Lng.ini["Msg", "端末が選択されていません。"];
                mbox = new MBox(Lng.ini["Msg", "メッセージ"], "WARNING", Msg, "OK", "OK");
                mbox.ShowDialog();
                return;
            }

            Msg = Lng.ini["Msg", "選択された端末をリストから削除します。よろしいですか？"];
            mbox = new MBox(Lng.ini["Msg", "確認"], "QUESTION", Msg, "YesNo", "No");
            mbox.ShowDialog();
            if (mbox.Result == "Yes")
            {
                Setting.Main.Device_List.RemoveAt(ListView_Device.SelectedItems[0].Index);
                List_Display();
                Edit_Flag = true;
            }
        }

        private void Button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
