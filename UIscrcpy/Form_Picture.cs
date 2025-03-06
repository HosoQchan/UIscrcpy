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
    public partial class Form_Picture : Form
    {
        public Bitmap bitmap;

        public Form_Picture()
        {
            InitializeComponent();
            this.Text = Lng.ini["Main", "画像"];
        }

        private void PictureBox_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form_Picture_Load(object sender, EventArgs e)
        {
            PictureBox.Image = bitmap;
        }
    }
}
