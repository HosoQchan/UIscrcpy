namespace UIscrcpy
{
    partial class Form_App_List
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            ListView_App_List = new ListView();
            ImageList_Picture = new ImageList(components);
            Button_Cancel = new Button();
            Button_Decision = new Button();
            Button_Get_Icon = new Button();
            Button_Get_App = new Button();
            panel1 = new Panel();
            panel2 = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // ListView_App_List
            // 
            ListView_App_List.Dock = DockStyle.Fill;
            ListView_App_List.LargeImageList = ImageList_Picture;
            ListView_App_List.Location = new Point(112, 0);
            ListView_App_List.Name = "ListView_App_List";
            ListView_App_List.Size = new Size(566, 510);
            ListView_App_List.TabIndex = 0;
            ListView_App_List.UseCompatibleStateImageBehavior = false;
            ListView_App_List.SelectedIndexChanged += ListView_App_List_SelectedIndexChanged;
            // 
            // ImageList_Picture
            // 
            ImageList_Picture.ColorDepth = ColorDepth.Depth32Bit;
            ImageList_Picture.ImageSize = new Size(64, 64);
            ImageList_Picture.TransparentColor = Color.Transparent;
            // 
            // Button_Cancel
            // 
            Button_Cancel.BackColor = SystemColors.Highlight;
            Button_Cancel.Dock = DockStyle.Right;
            Button_Cancel.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            Button_Cancel.ForeColor = SystemColors.HighlightText;
            Button_Cancel.Location = new Point(410, 0);
            Button_Cancel.Margin = new Padding(10);
            Button_Cancel.MinimumSize = new Size(134, 34);
            Button_Cancel.Name = "Button_Cancel";
            Button_Cancel.Size = new Size(134, 34);
            Button_Cancel.TabIndex = 17;
            Button_Cancel.Text = "キャンセル";
            Button_Cancel.UseVisualStyleBackColor = false;
            Button_Cancel.Click += Button_Cancel_Click;
            // 
            // Button_Decision
            // 
            Button_Decision.BackColor = SystemColors.Highlight;
            Button_Decision.Dock = DockStyle.Right;
            Button_Decision.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            Button_Decision.ForeColor = SystemColors.HighlightText;
            Button_Decision.Location = new Point(544, 0);
            Button_Decision.Margin = new Padding(10);
            Button_Decision.MinimumSize = new Size(134, 34);
            Button_Decision.Name = "Button_Decision";
            Button_Decision.Size = new Size(134, 34);
            Button_Decision.TabIndex = 16;
            Button_Decision.Text = "決定";
            Button_Decision.UseVisualStyleBackColor = false;
            Button_Decision.Click += Button_Decision_Click;
            // 
            // Button_Get_Icon
            // 
            Button_Get_Icon.BackColor = SystemColors.Highlight;
            Button_Get_Icon.Dock = DockStyle.Left;
            Button_Get_Icon.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            Button_Get_Icon.ForeColor = SystemColors.HighlightText;
            Button_Get_Icon.Location = new Point(0, 0);
            Button_Get_Icon.Margin = new Padding(10);
            Button_Get_Icon.Name = "Button_Get_Icon";
            Button_Get_Icon.Size = new Size(180, 34);
            Button_Get_Icon.TabIndex = 18;
            Button_Get_Icon.Text = "アイコンをダウンロード";
            Button_Get_Icon.UseVisualStyleBackColor = false;
            Button_Get_Icon.Click += Button_Get_Icon_Click;
            // 
            // Button_Get_App
            // 
            Button_Get_App.BackColor = SystemColors.Highlight;
            Button_Get_App.Dock = DockStyle.Left;
            Button_Get_App.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            Button_Get_App.ForeColor = SystemColors.HighlightText;
            Button_Get_App.Location = new Point(0, 0);
            Button_Get_App.Name = "Button_Get_App";
            Button_Get_App.Size = new Size(112, 510);
            Button_Get_App.TabIndex = 19;
            Button_Get_App.Text = "端末と同じ最新の状態に更新する";
            Button_Get_App.UseVisualStyleBackColor = false;
            Button_Get_App.Click += Button_Get_App_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(ListView_App_List);
            panel1.Controls.Add(Button_Get_App);
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(678, 544);
            panel1.TabIndex = 20;
            // 
            // panel2
            // 
            panel2.Controls.Add(Button_Cancel);
            panel2.Controls.Add(Button_Get_Icon);
            panel2.Controls.Add(Button_Decision);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 510);
            panel2.Name = "panel2";
            panel2.Size = new Size(678, 34);
            panel2.TabIndex = 20;
            // 
            // Form_App_List
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(678, 544);
            Controls.Add(panel1);
            MinimizeBox = false;
            MinimumSize = new Size(640, 480);
            Name = "Form_App_List";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "アプリ";
            FormClosed += Form_App_List_FormClosed;
            Load += Form_App_List_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private ListView ListView_App_List;
        private Button Button_Cancel;
        private Button Button_Decision;
        private ImageList ImageList_Picture;
        private Button Button_Get_Icon;
        private Button Button_Get_App;
        private Panel panel1;
        private Panel panel2;
    }
}