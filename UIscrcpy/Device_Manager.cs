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
    public partial class Device_Manager : Form
    {
        int Max_Size_x;

        public Device_Manager()
        {
            InitializeComponent();
            Max_Size_x = this.Width;
        }

        private void Button_Add_Click(object sender, EventArgs e)
        {
            Start_Connection Form = new Start_Connection();
            Form.ShowDialog();

            List_Display();

        }

        private void Device_Manager_SizeChanged(object sender, EventArgs e)
        {
            //フォームの幅がMax_Size_xより大きくならないようにする
            if (Max_Size_x < this.Width)
            {
                this.Width = Max_Size_x;
            }
        }

        private void Device_Manager_Load(object sender, EventArgs e)
        {
            this.Owner.Hide();

            List_Display();
        }
        private void Device_Manager_FormClosed(object sender, FormClosedEventArgs e)
        {
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
            // 選択項目があるかどうかを確認する
            if (ListView_Device.SelectedItems.Count == 0)
            {
                // 選択項目がないので処理をせず抜ける
                return;
            }
            DialogResult result = MessageBox.Show("選択された端末をリストから削除します。よろしいですか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                string Dir_Name = Setting.Device_Path + Setting.Main.Device_List[ListView_Device.SelectedItems[0].Index].Model_Name;
                Setting.Main.Device_List.RemoveAt(ListView_Device.SelectedItems[0].Index);
                
                List_Display();
                if (Directory.Exists(Dir_Name))
                {
                    Directory.Delete(Dir_Name, true);
                }
            }
        }

        private void Button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
