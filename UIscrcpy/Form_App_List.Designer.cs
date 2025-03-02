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
            SuspendLayout();
            // 
            // ListView_App_List
            // 
            ListView_App_List.Dock = DockStyle.Fill;
            ListView_App_List.LargeImageList = ImageList_Picture;
            ListView_App_List.Location = new Point(0, 0);
            ListView_App_List.Name = "ListView_App_List";
            ListView_App_List.Size = new Size(728, 544);
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
            Button_Cancel.Dock = DockStyle.Bottom;
            Button_Cancel.Location = new Point(0, 476);
            Button_Cancel.Name = "Button_Cancel";
            Button_Cancel.Size = new Size(728, 34);
            Button_Cancel.TabIndex = 17;
            Button_Cancel.Text = "キャンセル";
            Button_Cancel.UseVisualStyleBackColor = true;
            Button_Cancel.Click += Button_Cancel_Click;
            // 
            // Button_Decision
            // 
            Button_Decision.Dock = DockStyle.Bottom;
            Button_Decision.Location = new Point(0, 510);
            Button_Decision.Name = "Button_Decision";
            Button_Decision.Size = new Size(728, 34);
            Button_Decision.TabIndex = 16;
            Button_Decision.Text = "決定";
            Button_Decision.UseVisualStyleBackColor = true;
            Button_Decision.Click += Button_Decision_Click;
            // 
            // Button_Get_Icon
            // 
            Button_Get_Icon.Dock = DockStyle.Bottom;
            Button_Get_Icon.Location = new Point(0, 442);
            Button_Get_Icon.Name = "Button_Get_Icon";
            Button_Get_Icon.Size = new Size(728, 34);
            Button_Get_Icon.TabIndex = 18;
            Button_Get_Icon.Text = "アイコンを取得";
            Button_Get_Icon.UseVisualStyleBackColor = true;
            Button_Get_Icon.Click += Button_Get_Icon_Click;
            // 
            // Form_App_List
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(728, 544);
            Controls.Add(Button_Get_Icon);
            Controls.Add(Button_Cancel);
            Controls.Add(Button_Decision);
            Controls.Add(ListView_App_List);
            MinimumSize = new Size(640, 480);
            Name = "Form_App_List";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "アプリの選択";
            FormClosed += Form_App_List_FormClosed;
            Load += Form_App_List_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListView ListView_App_List;
        private Button Button_Cancel;
        private Button Button_Decision;
        private ImageList ImageList_Picture;
        private Button Button_Get_Icon;
    }
}