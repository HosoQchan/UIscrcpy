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
    public partial class Form_Shortcut_Key : Form
    {
        public Form_Shortcut_Key()
        {
            InitializeComponent();
            this.Text = Lng.ini["Main", "ショートカットキー[option]"] + " = " + Setting.Main.Scrcpy_MODkey;
        }

        private void Form_Shortcut_Key_Load(object sender, EventArgs e)
        {
            try
            {
                string Image_Path = Lng.Language_Path + Setting.Main.Language + "\\Image\\";
                pictureBox1.Image = System.Drawing.Image.FromFile(Image_Path + "shortcut_key.png");
            }
            catch
            {
            }
        }
    }
}
