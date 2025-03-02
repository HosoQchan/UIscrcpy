namespace UIscrcpy
{
    partial class UIsrcpy
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UIsrcpy));
            Button_WIFI_Start = new Button();
            Button_USB_Start = new Button();
            label12 = new Label();
            label13 = new Label();
            groupBox2 = new GroupBox();
            Button_PresetEdit = new Button();
            label14 = new Label();
            Cbox_preset = new ComboBox();
            groupBox3 = new GroupBox();
            TextBox_App_Name = new TextBox();
            CheckB_App_Start = new CheckBox();
            Button_App_List = new Button();
            Button_Device_List = new Button();
            label5 = new Label();
            Cbox_Device = new ComboBox();
            label1 = new Label();
            groupBox1 = new GroupBox();
            Button_Rec_FolderOpen = new Button();
            Button_Rec_FolderSel = new Button();
            label3 = new Label();
            TextBox_Rec_Folder = new TextBox();
            CheckB_Rec = new CheckBox();
            label4 = new Label();
            Button_Scrcpy_FolderSel = new Button();
            TextBox_Scrcpy_Folder = new TextBox();
            label6 = new Label();
            groupBox4 = new GroupBox();
            Button_Close = new Button();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox4.SuspendLayout();
            SuspendLayout();
            // 
            // Button_WIFI_Start
            // 
            Button_WIFI_Start.BackgroundImage = Properties.Resources.kkrn_icon_wifi_11;
            Button_WIFI_Start.BackgroundImageLayout = ImageLayout.Zoom;
            Button_WIFI_Start.Location = new Point(163, 475);
            Button_WIFI_Start.Name = "Button_WIFI_Start";
            Button_WIFI_Start.Size = new Size(133, 120);
            Button_WIFI_Start.TabIndex = 0;
            Button_WIFI_Start.UseVisualStyleBackColor = true;
            Button_WIFI_Start.Click += Button_WIFI_Start_Click;
            // 
            // Button_USB_Start
            // 
            Button_USB_Start.BackgroundImage = (Image)resources.GetObject("Button_USB_Start.BackgroundImage");
            Button_USB_Start.BackgroundImageLayout = ImageLayout.Zoom;
            Button_USB_Start.Location = new Point(415, 475);
            Button_USB_Start.Name = "Button_USB_Start";
            Button_USB_Start.Size = new Size(133, 120);
            Button_USB_Start.TabIndex = 1;
            Button_USB_Start.UseVisualStyleBackColor = true;
            Button_USB_Start.Click += Button_USB_Start_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold);
            label12.ForeColor = Color.Red;
            label12.Location = new Point(6, 27);
            label12.Name = "label12";
            label12.Size = new Size(370, 25);
            label12.TabIndex = 10;
            label12.Text = "最初に【端末の登録】を行っておく必要があります。";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold);
            label13.ForeColor = Color.Red;
            label13.Location = new Point(8, 27);
            label13.Name = "label13";
            label13.Size = new Size(269, 25);
            label13.TabIndex = 11;
            label13.Text = "scrcpyのフォルダを選択して下さい。";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(Button_PresetEdit);
            groupBox2.Controls.Add(label14);
            groupBox2.Controls.Add(Cbox_preset);
            groupBox2.Location = new Point(12, 112);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(699, 75);
            groupBox2.TabIndex = 15;
            groupBox2.TabStop = false;
            groupBox2.Text = "設定";
            // 
            // Button_PresetEdit
            // 
            Button_PresetEdit.Location = new Point(403, 28);
            Button_PresetEdit.Name = "Button_PresetEdit";
            Button_PresetEdit.Size = new Size(166, 34);
            Button_PresetEdit.TabIndex = 20;
            Button_PresetEdit.Text = "編集";
            Button_PresetEdit.UseVisualStyleBackColor = true;
            Button_PresetEdit.Click += Button_PresetEdit_Click;
            // 
            // label14
            // 
            label14.Location = new Point(54, 30);
            label14.Name = "label14";
            label14.Size = new Size(91, 34);
            label14.TabIndex = 3;
            label14.Text = "プリセット";
            label14.TextAlign = ContentAlignment.MiddleRight;
            // 
            // Cbox_preset
            // 
            Cbox_preset.DropDownStyle = ComboBoxStyle.DropDownList;
            Cbox_preset.FormattingEnabled = true;
            Cbox_preset.Location = new Point(151, 30);
            Cbox_preset.Name = "Cbox_preset";
            Cbox_preset.Size = new Size(246, 33);
            Cbox_preset.TabIndex = 2;
            Cbox_preset.SelectedIndexChanged += Cbox_preset_SelectedIndexChanged;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(TextBox_App_Name);
            groupBox3.Controls.Add(CheckB_App_Start);
            groupBox3.Controls.Add(Button_App_List);
            groupBox3.Controls.Add(Button_Device_List);
            groupBox3.Controls.Add(label12);
            groupBox3.Controls.Add(label5);
            groupBox3.Controls.Add(Cbox_Device);
            groupBox3.Location = new Point(12, 193);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(699, 135);
            groupBox3.TabIndex = 16;
            groupBox3.TabStop = false;
            groupBox3.Text = "端末";
            // 
            // TextBox_App_Name
            // 
            TextBox_App_Name.Location = new Point(151, 93);
            TextBox_App_Name.Name = "TextBox_App_Name";
            TextBox_App_Name.ReadOnly = true;
            TextBox_App_Name.Size = new Size(246, 31);
            TextBox_App_Name.TabIndex = 22;
            // 
            // CheckB_App_Start
            // 
            CheckB_App_Start.AutoSize = true;
            CheckB_App_Start.Location = new Point(17, 95);
            CheckB_App_Start.Name = "CheckB_App_Start";
            CheckB_App_Start.Size = new Size(128, 29);
            CheckB_App_Start.TabIndex = 25;
            CheckB_App_Start.Text = "アプリを起動";
            CheckB_App_Start.UseVisualStyleBackColor = true;
            CheckB_App_Start.CheckedChanged += CheckB_App_Start_CheckedChanged;
            // 
            // Button_App_List
            // 
            Button_App_List.Location = new Point(403, 90);
            Button_App_List.Name = "Button_App_List";
            Button_App_List.Size = new Size(166, 34);
            Button_App_List.TabIndex = 24;
            Button_App_List.Text = "選択";
            Button_App_List.UseVisualStyleBackColor = true;
            Button_App_List.Click += Button_App_List_Click;
            // 
            // Button_Device_List
            // 
            Button_Device_List.Location = new Point(403, 50);
            Button_Device_List.Name = "Button_Device_List";
            Button_Device_List.Size = new Size(166, 34);
            Button_Device_List.TabIndex = 19;
            Button_Device_List.Text = "登録・削除";
            Button_Device_List.UseVisualStyleBackColor = true;
            Button_Device_List.Click += Button_Device_List_Click;
            // 
            // label5
            // 
            label5.Location = new Point(26, 52);
            label5.Name = "label5";
            label5.Size = new Size(119, 34);
            label5.TabIndex = 18;
            label5.Text = "接続する端末";
            label5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // Cbox_Device
            // 
            Cbox_Device.DropDownStyle = ComboBoxStyle.DropDownList;
            Cbox_Device.FormattingEnabled = true;
            Cbox_Device.Location = new Point(151, 52);
            Cbox_Device.Name = "Cbox_Device";
            Cbox_Device.Size = new Size(246, 33);
            Cbox_Device.TabIndex = 17;
            Cbox_Device.SelectedIndexChanged += Cbox_Device_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 128);
            label1.Location = new Point(29, 523);
            label1.Name = "label1";
            label1.Size = new Size(62, 32);
            label1.TabIndex = 26;
            label1.Text = "開始";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(Button_Rec_FolderOpen);
            groupBox1.Controls.Add(Button_Rec_FolderSel);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(TextBox_Rec_Folder);
            groupBox1.Controls.Add(CheckB_Rec);
            groupBox1.Controls.Add(label4);
            groupBox1.Location = new Point(12, 334);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(699, 135);
            groupBox1.TabIndex = 22;
            groupBox1.TabStop = false;
            groupBox1.Text = "録画";
            // 
            // Button_Rec_FolderOpen
            // 
            Button_Rec_FolderOpen.Location = new Point(575, 47);
            Button_Rec_FolderOpen.Name = "Button_Rec_FolderOpen";
            Button_Rec_FolderOpen.Size = new Size(112, 34);
            Button_Rec_FolderOpen.TabIndex = 27;
            Button_Rec_FolderOpen.Text = "開く";
            Button_Rec_FolderOpen.UseVisualStyleBackColor = true;
            Button_Rec_FolderOpen.Click += Button_Rec_FolderOpen_Click;
            // 
            // Button_Rec_FolderSel
            // 
            Button_Rec_FolderSel.Location = new Point(575, 87);
            Button_Rec_FolderSel.Name = "Button_Rec_FolderSel";
            Button_Rec_FolderSel.Size = new Size(112, 34);
            Button_Rec_FolderSel.TabIndex = 26;
            Button_Rec_FolderSel.Text = "選択";
            Button_Rec_FolderSel.UseVisualStyleBackColor = true;
            Button_Rec_FolderSel.Click += Button_Rec_FolderSel_Click;
            // 
            // label3
            // 
            label3.Location = new Point(54, 87);
            label3.Name = "label3";
            label3.Size = new Size(91, 34);
            label3.TabIndex = 24;
            label3.Text = "フォルダ";
            label3.TextAlign = ContentAlignment.MiddleRight;
            // 
            // TextBox_Rec_Folder
            // 
            TextBox_Rec_Folder.Location = new Point(151, 90);
            TextBox_Rec_Folder.Name = "TextBox_Rec_Folder";
            TextBox_Rec_Folder.ReadOnly = true;
            TextBox_Rec_Folder.ScrollBars = ScrollBars.Horizontal;
            TextBox_Rec_Folder.Size = new Size(418, 31);
            TextBox_Rec_Folder.TabIndex = 25;
            TextBox_Rec_Folder.WordWrap = false;
            // 
            // CheckB_Rec
            // 
            CheckB_Rec.AutoSize = true;
            CheckB_Rec.Location = new Point(17, 30);
            CheckB_Rec.Name = "CheckB_Rec";
            CheckB_Rec.Size = new Size(124, 29);
            CheckB_Rec.TabIndex = 0;
            CheckB_Rec.Text = "録画を開始";
            CheckB_Rec.UseVisualStyleBackColor = true;
            CheckB_Rec.CheckedChanged += CheckB_Rec_CheckedChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold);
            label4.ForeColor = Color.Red;
            label4.Location = new Point(8, 62);
            label4.Name = "label4";
            label4.Size = new Size(308, 25);
            label4.TabIndex = 23;
            label4.Text = "録画の保存用フォルダを選択して下さい。";
            // 
            // Button_Scrcpy_FolderSel
            // 
            Button_Scrcpy_FolderSel.Location = new Point(575, 53);
            Button_Scrcpy_FolderSel.Name = "Button_Scrcpy_FolderSel";
            Button_Scrcpy_FolderSel.Size = new Size(112, 34);
            Button_Scrcpy_FolderSel.TabIndex = 19;
            Button_Scrcpy_FolderSel.Text = "選択";
            Button_Scrcpy_FolderSel.UseVisualStyleBackColor = true;
            Button_Scrcpy_FolderSel.Click += Button_Scrcpy_FolderSel_Click;
            // 
            // TextBox_Scrcpy_Folder
            // 
            TextBox_Scrcpy_Folder.Location = new Point(151, 55);
            TextBox_Scrcpy_Folder.Name = "TextBox_Scrcpy_Folder";
            TextBox_Scrcpy_Folder.ReadOnly = true;
            TextBox_Scrcpy_Folder.ScrollBars = ScrollBars.Horizontal;
            TextBox_Scrcpy_Folder.Size = new Size(418, 31);
            TextBox_Scrcpy_Folder.TabIndex = 18;
            TextBox_Scrcpy_Folder.WordWrap = false;
            // 
            // label6
            // 
            label6.Location = new Point(54, 55);
            label6.Name = "label6";
            label6.Size = new Size(91, 34);
            label6.TabIndex = 17;
            label6.Text = "フォルダ";
            label6.TextAlign = ContentAlignment.MiddleRight;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(label6);
            groupBox4.Controls.Add(Button_Scrcpy_FolderSel);
            groupBox4.Controls.Add(TextBox_Scrcpy_Folder);
            groupBox4.Controls.Add(label13);
            groupBox4.Location = new Point(12, 12);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(699, 94);
            groupBox4.TabIndex = 20;
            groupBox4.TabStop = false;
            groupBox4.Text = "Scrcpy";
            // 
            // Button_Close
            // 
            Button_Close.Dock = DockStyle.Bottom;
            Button_Close.Location = new Point(0, 604);
            Button_Close.Name = "Button_Close";
            Button_Close.Size = new Size(723, 34);
            Button_Close.TabIndex = 21;
            Button_Close.Text = "終了";
            Button_Close.UseVisualStyleBackColor = true;
            Button_Close.Click += Button_Close_Click;
            // 
            // UIsrcpy
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(723, 638);
            Controls.Add(label1);
            Controls.Add(Button_Close);
            Controls.Add(groupBox1);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(Button_USB_Start);
            Controls.Add(groupBox2);
            Controls.Add(Button_WIFI_Start);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "UIsrcpy";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "UIscrcpy";
            FormClosing += UIsrcpy_FormClosing;
            FormClosed += UIsrcpy_FormClosed;
            Load += Form1_Load;
            groupBox2.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Button_WIFI_Start;
        private Button Button_USB_Start;
        private Label label12;
        private Label label13;
        private GroupBox groupBox2;
        private Label label14;
        private ComboBox Cbox_preset;
        private GroupBox groupBox3;
        private Label label5;
        private ComboBox Cbox_Device;
        private Button Button_Device_List;
        private Button Button_PresetEdit;
        private Button Button_Scrcpy_FolderSel;
        private TextBox TextBox_Scrcpy_Folder;
        private Label label6;
        private GroupBox groupBox4;
        private Button Button_Close;
        private Button Button_App_List;
        private CheckBox CheckB_App_Start;
        private TextBox TextBox_App_Name;
        private GroupBox groupBox1;
        private CheckBox CheckB_Rec;
        private Label label3;
        private Button Button_Rec_FolderSel;
        private TextBox TextBox_Rec_Folder;
        private Label label4;
        private Label label1;
        private Button Button_Rec_FolderOpen;
    }
}
