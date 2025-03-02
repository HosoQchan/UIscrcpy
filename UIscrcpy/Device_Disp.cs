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
    public partial class Device_Disp : Form
    {
        public Device_Info device_Info = new Device_Info();

        public Device_Disp()
        {
            InitializeComponent();
        }

        private void Device_Disp_Load(object sender, EventArgs e)
        {
            Label_ID.Text = device_Info.Serial;
            Label_Product.Text = device_Info.Product_Name;
            Label_Model.Text = device_Info.Model_Name;
            Label_IP_Adress.Text = device_Info.IP_Adress;
            Setting.Main.Device_List.Add(device_Info);

            DirectoryInfo info;
            info = Directory.CreateDirectory(Setting.Device_Path + device_Info.Model_Name);
        }

        private void Button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
