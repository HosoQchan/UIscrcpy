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
            Button_WIFI_Start = new Button();
            Button_USB_Start = new Button();
            Label_Terminal_Info = new Label();
            GBox_Setting = new GroupBox();
            Button_PresetEdit = new Button();
            Label_Preset = new Label();
            Cbox_preset = new ComboBox();
            GBox_Terminal = new GroupBox();
            TextBox_App_Name = new TextBox();
            CheckB_App_Start = new CheckBox();
            Button_App_List = new Button();
            Label_Start = new Label();
            Button_Device_List = new Button();
            CheckB_Rec = new CheckBox();
            Label_Terminal = new Label();
            Cbox_Device = new ComboBox();
            GBox_Rec = new GroupBox();
            Button_Rec_FolderOpen = new Button();
            Button_Rec_FolderSel = new Button();
            Label_Rec_Folder_Info = new Label();
            TextBox_Rec_Folder = new TextBox();
            Label_Rec_Info = new Label();
            Button_Scrcpy_FolderSel = new Button();
            TextBox_Scrcpy_Folder = new TextBox();
            Label_Folder = new Label();
            groupBox4 = new GroupBox();
            GBox_Shortcut = new GroupBox();
            label2 = new Label();
            Cbox_MODkey = new ComboBox();
            Label_Scrcpy_Folder_Info = new Label();
            Button_Close = new Button();
            Button_About = new Button();
            CBox_Language = new ComboBox();
            Label_Language = new Label();
            panel1 = new Panel();
            GBox_Setting.SuspendLayout();
            GBox_Terminal.SuspendLayout();
            GBox_Rec.SuspendLayout();
            groupBox4.SuspendLayout();
            GBox_Shortcut.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // Button_WIFI_Start
            // 
            Button_WIFI_Start.BackgroundImageLayout = ImageLayout.Zoom;
            Button_WIFI_Start.Location = new Point(188, 166);
            Button_WIFI_Start.Name = "Button_WIFI_Start";
            Button_WIFI_Start.Size = new Size(133, 120);
            Button_WIFI_Start.TabIndex = 0;
            Button_WIFI_Start.UseVisualStyleBackColor = true;
            Button_WIFI_Start.Click += Button_WIFI_Start_Click;
            // 
            // Button_USB_Start
            // 
            Button_USB_Start.BackgroundImageLayout = ImageLayout.Zoom;
            Button_USB_Start.Location = new Point(401, 166);
            Button_USB_Start.Name = "Button_USB_Start";
            Button_USB_Start.Size = new Size(133, 120);
            Button_USB_Start.TabIndex = 1;
            Button_USB_Start.UseVisualStyleBackColor = true;
            Button_USB_Start.Click += Button_USB_Start_Click;
            // 
            // Label_Terminal_Info
            // 
            Label_Terminal_Info.AutoSize = true;
            Label_Terminal_Info.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold);
            Label_Terminal_Info.ForeColor = Color.Red;
            Label_Terminal_Info.Location = new Point(6, 27);
            Label_Terminal_Info.Name = "Label_Terminal_Info";
            Label_Terminal_Info.Size = new Size(282, 25);
            Label_Terminal_Info.TabIndex = 10;
            Label_Terminal_Info.Text = "最初に端末の【登録】を行って下さい。";
            // 
            // GBox_Setting
            // 
            GBox_Setting.Controls.Add(Button_PresetEdit);
            GBox_Setting.Controls.Add(Label_Preset);
            GBox_Setting.Controls.Add(Cbox_preset);
            GBox_Setting.Location = new Point(5, 359);
            GBox_Setting.Name = "GBox_Setting";
            GBox_Setting.Size = new Size(706, 72);
            GBox_Setting.TabIndex = 15;
            GBox_Setting.TabStop = false;
            GBox_Setting.Text = "設定";
            // 
            // Button_PresetEdit
            // 
            Button_PresetEdit.BackColor = SystemColors.Highlight;
            Button_PresetEdit.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            Button_PresetEdit.ForeColor = SystemColors.HighlightText;
            Button_PresetEdit.Location = new Point(401, 25);
            Button_PresetEdit.Name = "Button_PresetEdit";
            Button_PresetEdit.Size = new Size(112, 34);
            Button_PresetEdit.TabIndex = 20;
            Button_PresetEdit.Text = "編集";
            Button_PresetEdit.UseVisualStyleBackColor = false;
            Button_PresetEdit.Click += Button_PresetEdit_Click;
            // 
            // Label_Preset
            // 
            Label_Preset.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            Label_Preset.Location = new Point(91, 27);
            Label_Preset.Name = "Label_Preset";
            Label_Preset.Size = new Size(91, 34);
            Label_Preset.TabIndex = 3;
            Label_Preset.Text = "プリセット";
            Label_Preset.TextAlign = ContentAlignment.MiddleRight;
            // 
            // Cbox_preset
            // 
            Cbox_preset.DropDownStyle = ComboBoxStyle.DropDownList;
            Cbox_preset.FormattingEnabled = true;
            Cbox_preset.Location = new Point(188, 27);
            Cbox_preset.Name = "Cbox_preset";
            Cbox_preset.Size = new Size(197, 33);
            Cbox_preset.TabIndex = 2;
            Cbox_preset.SelectedIndexChanged += Cbox_preset_SelectedIndexChanged;
            // 
            // GBox_Terminal
            // 
            GBox_Terminal.Controls.Add(TextBox_App_Name);
            GBox_Terminal.Controls.Add(CheckB_App_Start);
            GBox_Terminal.Controls.Add(Button_App_List);
            GBox_Terminal.Controls.Add(Label_Start);
            GBox_Terminal.Controls.Add(Button_Device_List);
            GBox_Terminal.Controls.Add(CheckB_Rec);
            GBox_Terminal.Controls.Add(Label_Terminal_Info);
            GBox_Terminal.Controls.Add(Label_Terminal);
            GBox_Terminal.Controls.Add(Cbox_Device);
            GBox_Terminal.Controls.Add(Button_USB_Start);
            GBox_Terminal.Controls.Add(Button_WIFI_Start);
            GBox_Terminal.Location = new Point(5, 437);
            GBox_Terminal.Name = "GBox_Terminal";
            GBox_Terminal.Size = new Size(706, 293);
            GBox_Terminal.TabIndex = 16;
            GBox_Terminal.TabStop = false;
            GBox_Terminal.Text = "接続";
            // 
            // TextBox_App_Name
            // 
            TextBox_App_Name.Location = new Point(188, 93);
            TextBox_App_Name.Name = "TextBox_App_Name";
            TextBox_App_Name.ReadOnly = true;
            TextBox_App_Name.Size = new Size(197, 31);
            TextBox_App_Name.TabIndex = 22;
            // 
            // CheckB_App_Start
            // 
            CheckB_App_Start.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            CheckB_App_Start.ForeColor = SystemColors.Highlight;
            CheckB_App_Start.Location = new Point(17, 95);
            CheckB_App_Start.Name = "CheckB_App_Start";
            CheckB_App_Start.Size = new Size(175, 29);
            CheckB_App_Start.TabIndex = 25;
            CheckB_App_Start.Text = "アプリを起動";
            CheckB_App_Start.UseVisualStyleBackColor = true;
            CheckB_App_Start.CheckedChanged += CheckB_App_Start_CheckedChanged;
            // 
            // Button_App_List
            // 
            Button_App_List.BackColor = SystemColors.Highlight;
            Button_App_List.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            Button_App_List.ForeColor = SystemColors.HighlightText;
            Button_App_List.Location = new Point(401, 89);
            Button_App_List.Name = "Button_App_List";
            Button_App_List.Size = new Size(160, 34);
            Button_App_List.TabIndex = 24;
            Button_App_List.Text = "選択";
            Button_App_List.UseVisualStyleBackColor = false;
            Button_App_List.Click += Button_App_List_Click;
            // 
            // Label_Start
            // 
            Label_Start.AutoSize = true;
            Label_Start.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 128);
            Label_Start.Location = new Point(83, 208);
            Label_Start.Name = "Label_Start";
            Label_Start.Size = new Size(62, 32);
            Label_Start.TabIndex = 26;
            Label_Start.Text = "開始";
            // 
            // Button_Device_List
            // 
            Button_Device_List.BackColor = SystemColors.Highlight;
            Button_Device_List.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            Button_Device_List.ForeColor = SystemColors.HighlightText;
            Button_Device_List.Location = new Point(401, 50);
            Button_Device_List.Name = "Button_Device_List";
            Button_Device_List.Size = new Size(160, 34);
            Button_Device_List.TabIndex = 19;
            Button_Device_List.Text = "登録/削除";
            Button_Device_List.UseVisualStyleBackColor = false;
            Button_Device_List.Click += Button_Device_List_Click;
            // 
            // CheckB_Rec
            // 
            CheckB_Rec.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            CheckB_Rec.ForeColor = SystemColors.Highlight;
            CheckB_Rec.Location = new Point(17, 130);
            CheckB_Rec.Name = "CheckB_Rec";
            CheckB_Rec.Size = new Size(175, 29);
            CheckB_Rec.TabIndex = 0;
            CheckB_Rec.Text = "録画";
            CheckB_Rec.UseVisualStyleBackColor = true;
            CheckB_Rec.CheckedChanged += CheckB_Rec_CheckedChanged;
            // 
            // Label_Terminal
            // 
            Label_Terminal.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            Label_Terminal.Location = new Point(16, 52);
            Label_Terminal.Name = "Label_Terminal";
            Label_Terminal.Size = new Size(166, 34);
            Label_Terminal.TabIndex = 18;
            Label_Terminal.Text = "接続する端末";
            Label_Terminal.TextAlign = ContentAlignment.MiddleRight;
            // 
            // Cbox_Device
            // 
            Cbox_Device.DropDownStyle = ComboBoxStyle.DropDownList;
            Cbox_Device.FormattingEnabled = true;
            Cbox_Device.Location = new Point(188, 52);
            Cbox_Device.Name = "Cbox_Device";
            Cbox_Device.Size = new Size(197, 33);
            Cbox_Device.TabIndex = 17;
            Cbox_Device.SelectedIndexChanged += Cbox_Device_SelectedIndexChanged;
            // 
            // GBox_Rec
            // 
            GBox_Rec.Controls.Add(Button_Rec_FolderOpen);
            GBox_Rec.Controls.Add(Button_Rec_FolderSel);
            GBox_Rec.Controls.Add(Label_Rec_Folder_Info);
            GBox_Rec.Controls.Add(TextBox_Rec_Folder);
            GBox_Rec.Controls.Add(Label_Rec_Info);
            GBox_Rec.Location = new Point(5, 218);
            GBox_Rec.Name = "GBox_Rec";
            GBox_Rec.Size = new Size(706, 135);
            GBox_Rec.TabIndex = 22;
            GBox_Rec.TabStop = false;
            GBox_Rec.Text = "保存用フォルダ";
            // 
            // Button_Rec_FolderOpen
            // 
            Button_Rec_FolderOpen.BackColor = SystemColors.Highlight;
            Button_Rec_FolderOpen.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            Button_Rec_FolderOpen.ForeColor = SystemColors.HighlightText;
            Button_Rec_FolderOpen.Location = new Point(575, 93);
            Button_Rec_FolderOpen.Name = "Button_Rec_FolderOpen";
            Button_Rec_FolderOpen.Size = new Size(112, 34);
            Button_Rec_FolderOpen.TabIndex = 27;
            Button_Rec_FolderOpen.Text = "開く";
            Button_Rec_FolderOpen.UseVisualStyleBackColor = false;
            Button_Rec_FolderOpen.Click += Button_Rec_FolderOpen_Click;
            // 
            // Button_Rec_FolderSel
            // 
            Button_Rec_FolderSel.BackColor = SystemColors.Highlight;
            Button_Rec_FolderSel.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            Button_Rec_FolderSel.ForeColor = SystemColors.HighlightText;
            Button_Rec_FolderSel.Location = new Point(575, 53);
            Button_Rec_FolderSel.Name = "Button_Rec_FolderSel";
            Button_Rec_FolderSel.Size = new Size(112, 34);
            Button_Rec_FolderSel.TabIndex = 26;
            Button_Rec_FolderSel.Text = "選択";
            Button_Rec_FolderSel.UseVisualStyleBackColor = false;
            Button_Rec_FolderSel.Click += Button_Rec_FolderSel_Click;
            // 
            // Label_Rec_Folder_Info
            // 
            Label_Rec_Folder_Info.Font = new Font("Yu Gothic UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            Label_Rec_Folder_Info.Location = new Point(54, 52);
            Label_Rec_Folder_Info.Name = "Label_Rec_Folder_Info";
            Label_Rec_Folder_Info.Size = new Size(91, 34);
            Label_Rec_Folder_Info.TabIndex = 24;
            Label_Rec_Folder_Info.Text = "フォルダ";
            Label_Rec_Folder_Info.TextAlign = ContentAlignment.MiddleRight;
            // 
            // TextBox_Rec_Folder
            // 
            TextBox_Rec_Folder.Location = new Point(151, 55);
            TextBox_Rec_Folder.Name = "TextBox_Rec_Folder";
            TextBox_Rec_Folder.ReadOnly = true;
            TextBox_Rec_Folder.ScrollBars = ScrollBars.Horizontal;
            TextBox_Rec_Folder.Size = new Size(418, 31);
            TextBox_Rec_Folder.TabIndex = 25;
            TextBox_Rec_Folder.WordWrap = false;
            // 
            // Label_Rec_Info
            // 
            Label_Rec_Info.AutoSize = true;
            Label_Rec_Info.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold);
            Label_Rec_Info.ForeColor = Color.Red;
            Label_Rec_Info.Location = new Point(6, 27);
            Label_Rec_Info.Name = "Label_Rec_Info";
            Label_Rec_Info.Size = new Size(378, 25);
            Label_Rec_Info.TabIndex = 23;
            Label_Rec_Info.Text = "画像及び録画の保存用フォルダを選択して下さい。";
            // 
            // Button_Scrcpy_FolderSel
            // 
            Button_Scrcpy_FolderSel.BackColor = SystemColors.Highlight;
            Button_Scrcpy_FolderSel.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            Button_Scrcpy_FolderSel.ForeColor = SystemColors.HighlightText;
            Button_Scrcpy_FolderSel.Location = new Point(575, 52);
            Button_Scrcpy_FolderSel.Name = "Button_Scrcpy_FolderSel";
            Button_Scrcpy_FolderSel.Size = new Size(112, 34);
            Button_Scrcpy_FolderSel.TabIndex = 19;
            Button_Scrcpy_FolderSel.Text = "選択";
            Button_Scrcpy_FolderSel.UseVisualStyleBackColor = false;
            Button_Scrcpy_FolderSel.Click += Button_Scrcpy_FolderSel_Click;
            // 
            // TextBox_Scrcpy_Folder
            // 
            TextBox_Scrcpy_Folder.Location = new Point(151, 54);
            TextBox_Scrcpy_Folder.Name = "TextBox_Scrcpy_Folder";
            TextBox_Scrcpy_Folder.ReadOnly = true;
            TextBox_Scrcpy_Folder.ScrollBars = ScrollBars.Horizontal;
            TextBox_Scrcpy_Folder.Size = new Size(418, 31);
            TextBox_Scrcpy_Folder.TabIndex = 18;
            TextBox_Scrcpy_Folder.WordWrap = false;
            // 
            // Label_Folder
            // 
            Label_Folder.Font = new Font("Yu Gothic UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            Label_Folder.Location = new Point(54, 54);
            Label_Folder.Name = "Label_Folder";
            Label_Folder.Size = new Size(91, 34);
            Label_Folder.TabIndex = 17;
            Label_Folder.Text = "フォルダ";
            Label_Folder.TextAlign = ContentAlignment.MiddleRight;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(GBox_Shortcut);
            groupBox4.Controls.Add(Label_Folder);
            groupBox4.Controls.Add(Button_Scrcpy_FolderSel);
            groupBox4.Controls.Add(TextBox_Scrcpy_Folder);
            groupBox4.Controls.Add(Label_Scrcpy_Folder_Info);
            groupBox4.Location = new Point(5, 42);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(706, 170);
            groupBox4.TabIndex = 20;
            groupBox4.TabStop = false;
            groupBox4.Text = "Scrcpy";
            // 
            // GBox_Shortcut
            // 
            GBox_Shortcut.Controls.Add(label2);
            GBox_Shortcut.Controls.Add(Cbox_MODkey);
            GBox_Shortcut.Location = new Point(482, 92);
            GBox_Shortcut.Name = "GBox_Shortcut";
            GBox_Shortcut.Size = new Size(211, 67);
            GBox_Shortcut.TabIndex = 21;
            GBox_Shortcut.TabStop = false;
            GBox_Shortcut.Text = "ショートカットキー[option]";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.Font = new Font("Yu Gothic UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            label2.Location = new Point(-1, 30);
            label2.Name = "label2";
            label2.Size = new Size(88, 33);
            label2.TabIndex = 7;
            label2.Text = "Key";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // Cbox_MODkey
            // 
            Cbox_MODkey.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            Cbox_MODkey.DropDownStyle = ComboBoxStyle.DropDownList;
            Cbox_MODkey.FormattingEnabled = true;
            Cbox_MODkey.Location = new Point(93, 30);
            Cbox_MODkey.Name = "Cbox_MODkey";
            Cbox_MODkey.Size = new Size(112, 33);
            Cbox_MODkey.TabIndex = 0;
            Cbox_MODkey.SelectedIndexChanged += Cbox_MODkey_SelectedIndexChanged;
            // 
            // Label_Scrcpy_Folder_Info
            // 
            Label_Scrcpy_Folder_Info.AutoSize = true;
            Label_Scrcpy_Folder_Info.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold);
            Label_Scrcpy_Folder_Info.ForeColor = Color.Red;
            Label_Scrcpy_Folder_Info.Location = new Point(8, 27);
            Label_Scrcpy_Folder_Info.Name = "Label_Scrcpy_Folder_Info";
            Label_Scrcpy_Folder_Info.Size = new Size(269, 25);
            Label_Scrcpy_Folder_Info.TabIndex = 11;
            Label_Scrcpy_Folder_Info.Text = "scrcpyのフォルダを選択して下さい。";
            // 
            // Button_Close
            // 
            Button_Close.BackColor = SystemColors.Highlight;
            Button_Close.Dock = DockStyle.Right;
            Button_Close.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            Button_Close.ForeColor = SystemColors.HighlightText;
            Button_Close.Location = new Point(571, 0);
            Button_Close.Margin = new Padding(10);
            Button_Close.Name = "Button_Close";
            Button_Close.Size = new Size(143, 34);
            Button_Close.TabIndex = 21;
            Button_Close.Text = "終了";
            Button_Close.UseVisualStyleBackColor = false;
            Button_Close.Click += Button_Close_Click;
            // 
            // Button_About
            // 
            Button_About.BackColor = SystemColors.Highlight;
            Button_About.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            Button_About.ForeColor = SystemColors.HighlightText;
            Button_About.Location = new Point(580, 2);
            Button_About.Name = "Button_About";
            Button_About.Size = new Size(112, 34);
            Button_About.TabIndex = 27;
            Button_About.Text = "About";
            Button_About.UseVisualStyleBackColor = false;
            Button_About.Click += Button_About_Click;
            // 
            // CBox_Language
            // 
            CBox_Language.DropDownStyle = ComboBoxStyle.DropDownList;
            CBox_Language.FormattingEnabled = true;
            CBox_Language.Location = new Point(462, 3);
            CBox_Language.Name = "CBox_Language";
            CBox_Language.Size = new Size(112, 33);
            CBox_Language.TabIndex = 28;
            CBox_Language.SelectedIndexChanged += CBox_Language_SelectedIndexChanged;
            // 
            // Label_Language
            // 
            Label_Language.Font = new Font("Yu Gothic UI", 9F);
            Label_Language.Location = new Point(365, 3);
            Label_Language.Name = "Label_Language";
            Label_Language.Size = new Size(91, 34);
            Label_Language.TabIndex = 30;
            Label_Language.Text = "言語";
            Label_Language.TextAlign = ContentAlignment.MiddleRight;
            // 
            // panel1
            // 
            panel1.Controls.Add(Button_Close);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 732);
            panel1.MinimumSize = new Size(0, 34);
            panel1.Name = "panel1";
            panel1.Size = new Size(714, 34);
            panel1.TabIndex = 31;
            // 
            // UIsrcpy
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(714, 766);
            Controls.Add(panel1);
            Controls.Add(CBox_Language);
            Controls.Add(Label_Language);
            Controls.Add(Button_About);
            Controls.Add(GBox_Rec);
            Controls.Add(groupBox4);
            Controls.Add(GBox_Terminal);
            Controls.Add(GBox_Setting);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "UIsrcpy";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "UIscrcpy";
            FormClosing += UIsrcpy_FormClosing;
            FormClosed += UIsrcpy_FormClosed;
            Load += Form1_Load;
            GBox_Setting.ResumeLayout(false);
            GBox_Terminal.ResumeLayout(false);
            GBox_Terminal.PerformLayout();
            GBox_Rec.ResumeLayout(false);
            GBox_Rec.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            GBox_Shortcut.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button Button_WIFI_Start;
        private Button Button_USB_Start;
        private Label Label_Terminal_Info;
        private GroupBox GBox_Setting;
        private Label Label_Preset;
        private ComboBox Cbox_preset;
        private GroupBox GBox_Terminal;
        private Label Label_Terminal;
        private ComboBox Cbox_Device;
        private Button Button_Device_List;
        private Button Button_PresetEdit;
        private Button Button_Scrcpy_FolderSel;
        private TextBox TextBox_Scrcpy_Folder;
        private Label Label_Folder;
        private GroupBox groupBox4;
        private Button Button_Close;
        private Button Button_App_List;
        private CheckBox CheckB_App_Start;
        private TextBox TextBox_App_Name;
        private GroupBox GBox_Rec;
        private CheckBox CheckB_Rec;
        private Label Label_Rec_Folder_Info;
        private Button Button_Rec_FolderSel;
        private TextBox TextBox_Rec_Folder;
        private Label Label_Start;
        private Button Button_Rec_FolderOpen;
        private Button Button_About;
        private GroupBox GBox_Shortcut;
        private Label label2;
        private ComboBox Cbox_MODkey;
        private ComboBox CBox_Language;
        private Label Label_Language;
        private Label Label_Rec_Info;
        private Label Label_Scrcpy_Folder_Info;
        private Panel panel1;
    }
}
