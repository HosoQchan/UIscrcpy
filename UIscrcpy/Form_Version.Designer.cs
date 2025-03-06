namespace UIscrcpy
{
    partial class Form_Version
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
            label2 = new Label();
            Label_Git_VerNo = new Label();
            PictureBox_Icon = new PictureBox();
            Label_Git_Ver = new Label();
            label4 = new Label();
            Label_Now_Ver = new Label();
            GBox_Ver = new GroupBox();
            GBox_Developer = new GroupBox();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            GBox_Copyright = new GroupBox();
            Label_This_Software = new Label();
            LinkLabel_GitHub = new LinkLabel();
            LinkLabel_License = new LinkLabel();
            label14 = new Label();
            label13 = new Label();
            Panel_UpDate_New = new Panel();
            Label_UpDate_New = new Label();
            Label_NewVer = new Label();
            LinkLabel_New_Version = new LinkLabel();
            Button_Close = new Button();
            Panel_UpDate_Now = new Panel();
            Label_UpDate_Now = new Label();
            groupBox4 = new GroupBox();
            Panel_Update = new Panel();
            Panel_Update_Info = new Panel();
            Label_Update_Info = new Label();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)PictureBox_Icon).BeginInit();
            GBox_Ver.SuspendLayout();
            GBox_Developer.SuspendLayout();
            GBox_Copyright.SuspendLayout();
            Panel_UpDate_New.SuspendLayout();
            Panel_UpDate_Now.SuspendLayout();
            groupBox4.SuspendLayout();
            Panel_Update.SuspendLayout();
            Panel_Update_Info.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Yu Gothic UI", 11F, FontStyle.Bold, GraphicsUnit.Point, 128);
            label2.Location = new Point(82, 39);
            label2.Name = "label2";
            label2.Size = new Size(95, 30);
            label2.TabIndex = 1;
            label2.Text = "UIscrcpy";
            // 
            // Label_Git_VerNo
            // 
            Label_Git_VerNo.AutoSize = true;
            Label_Git_VerNo.ForeColor = Color.Red;
            Label_Git_VerNo.Location = new Point(130, 52);
            Label_Git_VerNo.Name = "Label_Git_VerNo";
            Label_Git_VerNo.Size = new Size(64, 25);
            Label_Git_VerNo.TabIndex = 2;
            Label_Git_VerNo.Text = "0.0.0.0";
            // 
            // PictureBox_Icon
            // 
            PictureBox_Icon.Location = new Point(12, 25);
            PictureBox_Icon.Name = "PictureBox_Icon";
            PictureBox_Icon.Size = new Size(64, 64);
            PictureBox_Icon.SizeMode = PictureBoxSizeMode.Zoom;
            PictureBox_Icon.TabIndex = 3;
            PictureBox_Icon.TabStop = false;
            // 
            // Label_Git_Ver
            // 
            Label_Git_Ver.AutoSize = true;
            Label_Git_Ver.ForeColor = Color.Red;
            Label_Git_Ver.Location = new Point(44, 52);
            Label_Git_Ver.Name = "Label_Git_Ver";
            Label_Git_Ver.Size = new Size(81, 25);
            Label_Git_Ver.TabIndex = 4;
            Label_Git_Ver.Text = "New Ver:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(42, 27);
            label4.Name = "label4";
            label4.Size = new Size(83, 25);
            label4.TabIndex = 5;
            label4.Text = "Now Ver:";
            // 
            // Label_Now_Ver
            // 
            Label_Now_Ver.AutoSize = true;
            Label_Now_Ver.Location = new Point(130, 27);
            Label_Now_Ver.Name = "Label_Now_Ver";
            Label_Now_Ver.Size = new Size(64, 25);
            Label_Now_Ver.TabIndex = 6;
            Label_Now_Ver.Text = "0.0.0.0";
            // 
            // GBox_Ver
            // 
            GBox_Ver.Controls.Add(Label_Git_Ver);
            GBox_Ver.Controls.Add(Label_Now_Ver);
            GBox_Ver.Controls.Add(label4);
            GBox_Ver.Controls.Add(Label_Git_VerNo);
            GBox_Ver.Location = new Point(367, 12);
            GBox_Ver.Name = "GBox_Ver";
            GBox_Ver.Size = new Size(206, 108);
            GBox_Ver.TabIndex = 8;
            GBox_Ver.TabStop = false;
            GBox_Ver.Text = "Version";
            // 
            // GBox_Developer
            // 
            GBox_Developer.Controls.Add(label8);
            GBox_Developer.Controls.Add(label7);
            GBox_Developer.Controls.Add(label6);
            GBox_Developer.Location = new Point(183, 12);
            GBox_Developer.Name = "GBox_Developer";
            GBox_Developer.Size = new Size(178, 108);
            GBox_Developer.TabIndex = 9;
            GBox_Developer.TabStop = false;
            GBox_Developer.Text = "開発環境";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(6, 77);
            label8.Name = "label8";
            label8.Size = new Size(43, 25);
            label8.TabIndex = 11;
            label8.Text = "・C#";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 52);
            label7.Name = "label7";
            label7.Size = new Size(80, 25);
            label7.TabIndex = 10;
            label7.Text = "・.NET8.0";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(5, 27);
            label6.Name = "label6";
            label6.Size = new Size(169, 25);
            label6.TabIndex = 0;
            label6.Text = "・Visual Studio 2022";
            // 
            // GBox_Copyright
            // 
            GBox_Copyright.Controls.Add(Label_This_Software);
            GBox_Copyright.Controls.Add(LinkLabel_GitHub);
            GBox_Copyright.Controls.Add(LinkLabel_License);
            GBox_Copyright.Controls.Add(label14);
            GBox_Copyright.Controls.Add(label13);
            GBox_Copyright.Location = new Point(12, 126);
            GBox_Copyright.Name = "GBox_Copyright";
            GBox_Copyright.Size = new Size(561, 90);
            GBox_Copyright.TabIndex = 10;
            GBox_Copyright.TabStop = false;
            GBox_Copyright.Text = "Copyright";
            // 
            // Label_This_Software
            // 
            Label_This_Software.AutoSize = true;
            Label_This_Software.Location = new Point(6, 52);
            Label_This_Software.Name = "Label_This_Software";
            Label_This_Software.Size = new Size(128, 25);
            Label_This_Software.TabIndex = 4;
            Label_This_Software.Text = "このソフトウェアは";
            // 
            // LinkLabel_GitHub
            // 
            LinkLabel_GitHub.AutoSize = true;
            LinkLabel_GitHub.Location = new Point(140, 52);
            LinkLabel_GitHub.Name = "LinkLabel_GitHub";
            LinkLabel_GitHub.Size = new Size(0, 25);
            LinkLabel_GitHub.TabIndex = 3;
            LinkLabel_GitHub.LinkClicked += LinkLabel_GitHub_LinkClicked;
            // 
            // LinkLabel_License
            // 
            LinkLabel_License.AutoSize = true;
            LinkLabel_License.Location = new Point(140, 52);
            LinkLabel_License.Name = "LinkLabel_License";
            LinkLabel_License.Size = new Size(99, 25);
            LinkLabel_License.TabIndex = 5;
            LinkLabel_License.TabStop = true;
            LinkLabel_License.Text = "MIT license";
            LinkLabel_License.LinkClicked += LinkLabel_License_LinkClicked;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(140, 27);
            label14.Name = "label14";
            label14.Size = new Size(108, 25);
            label14.TabIndex = 1;
            label14.Text = "HHosokawa";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(27, 27);
            label13.Name = "label13";
            label13.Size = new Size(107, 25);
            label13.TabIndex = 0;
            label13.Text = "Copyright©";
            // 
            // Panel_UpDate_New
            // 
            Panel_UpDate_New.Controls.Add(Label_UpDate_New);
            Panel_UpDate_New.Controls.Add(Label_NewVer);
            Panel_UpDate_New.Location = new Point(3, 7);
            Panel_UpDate_New.Name = "Panel_UpDate_New";
            Panel_UpDate_New.Size = new Size(383, 86);
            Panel_UpDate_New.TabIndex = 6;
            // 
            // Label_UpDate_New
            // 
            Label_UpDate_New.AutoSize = true;
            Label_UpDate_New.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            Label_UpDate_New.Location = new Point(73, 31);
            Label_UpDate_New.Name = "Label_UpDate_New";
            Label_UpDate_New.Size = new Size(162, 25);
            Label_UpDate_New.TabIndex = 2;
            Label_UpDate_New.Text = "が公開されています。";
            // 
            // Label_NewVer
            // 
            Label_NewVer.AutoSize = true;
            Label_NewVer.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            Label_NewVer.ForeColor = Color.Red;
            Label_NewVer.Location = new Point(3, 31);
            Label_NewVer.Name = "Label_NewVer";
            Label_NewVer.Size = new Size(64, 25);
            Label_NewVer.TabIndex = 1;
            Label_NewVer.Text = "0.0.0.0";
            // 
            // LinkLabel_New_Version
            // 
            LinkLabel_New_Version.AutoSize = true;
            LinkLabel_New_Version.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            LinkLabel_New_Version.Location = new Point(471, 39);
            LinkLabel_New_Version.Name = "LinkLabel_New_Version";
            LinkLabel_New_Version.Size = new Size(72, 25);
            LinkLabel_New_Version.TabIndex = 4;
            LinkLabel_New_Version.TabStop = true;
            LinkLabel_New_Version.Text = "GitHub";
            LinkLabel_New_Version.LinkClicked += LinkLabel_New_Version_LinkClicked;
            // 
            // Button_Close
            // 
            Button_Close.BackColor = SystemColors.Highlight;
            Button_Close.Dock = DockStyle.Right;
            Button_Close.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            Button_Close.ForeColor = SystemColors.HighlightText;
            Button_Close.Location = new Point(449, 0);
            Button_Close.Margin = new Padding(10);
            Button_Close.Name = "Button_Close";
            Button_Close.Size = new Size(134, 34);
            Button_Close.TabIndex = 12;
            Button_Close.Text = "閉じる";
            Button_Close.UseVisualStyleBackColor = false;
            Button_Close.Click += Button_Close_Click;
            // 
            // Panel_UpDate_Now
            // 
            Panel_UpDate_Now.Controls.Add(Label_UpDate_Now);
            Panel_UpDate_Now.Location = new Point(3, 7);
            Panel_UpDate_Now.Name = "Panel_UpDate_Now";
            Panel_UpDate_Now.Size = new Size(389, 86);
            Panel_UpDate_Now.TabIndex = 13;
            // 
            // Label_UpDate_Now
            // 
            Label_UpDate_Now.AutoSize = true;
            Label_UpDate_Now.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            Label_UpDate_Now.ForeColor = SystemColors.ControlText;
            Label_UpDate_Now.Location = new Point(9, 36);
            Label_UpDate_Now.Name = "Label_UpDate_Now";
            Label_UpDate_Now.Size = new Size(236, 25);
            Label_UpDate_Now.TabIndex = 4;
            Label_UpDate_Now.Text = "お使いのバージョンは最新です。";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(Panel_Update);
            groupBox4.Location = new Point(12, 222);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(561, 132);
            groupBox4.TabIndex = 14;
            groupBox4.TabStop = false;
            groupBox4.Text = "Update";
            // 
            // Panel_Update
            // 
            Panel_Update.Controls.Add(Panel_UpDate_Now);
            Panel_Update.Controls.Add(Panel_Update_Info);
            Panel_Update.Controls.Add(Panel_UpDate_New);
            Panel_Update.Controls.Add(LinkLabel_New_Version);
            Panel_Update.Location = new Point(6, 30);
            Panel_Update.Name = "Panel_Update";
            Panel_Update.Size = new Size(549, 96);
            Panel_Update.TabIndex = 11;
            // 
            // Panel_Update_Info
            // 
            Panel_Update_Info.Controls.Add(Label_Update_Info);
            Panel_Update_Info.Location = new Point(3, 7);
            Panel_Update_Info.Name = "Panel_Update_Info";
            Panel_Update_Info.Size = new Size(401, 86);
            Panel_Update_Info.TabIndex = 0;
            // 
            // Label_Update_Info
            // 
            Label_Update_Info.AutoSize = true;
            Label_Update_Info.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            Label_Update_Info.Location = new Point(8, 32);
            Label_Update_Info.Name = "Label_Update_Info";
            Label_Update_Info.Size = new Size(290, 25);
            Label_Update_Info.TabIndex = 3;
            Label_Update_Info.Text = "最新バージョンはこちらからDLできます。";
            // 
            // panel1
            // 
            panel1.Controls.Add(Button_Close);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 356);
            panel1.MinimumSize = new Size(0, 34);
            panel1.Name = "panel1";
            panel1.Size = new Size(583, 34);
            panel1.TabIndex = 15;
            // 
            // Form_Version
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(583, 390);
            Controls.Add(panel1);
            Controls.Add(groupBox4);
            Controls.Add(GBox_Copyright);
            Controls.Add(GBox_Developer);
            Controls.Add(GBox_Ver);
            Controls.Add(PictureBox_Icon);
            Controls.Add(label2);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form_Version";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "About";
            Load += Form_Version_Load;
            ((System.ComponentModel.ISupportInitialize)PictureBox_Icon).EndInit();
            GBox_Ver.ResumeLayout(false);
            GBox_Ver.PerformLayout();
            GBox_Developer.ResumeLayout(false);
            GBox_Developer.PerformLayout();
            GBox_Copyright.ResumeLayout(false);
            GBox_Copyright.PerformLayout();
            Panel_UpDate_New.ResumeLayout(false);
            Panel_UpDate_New.PerformLayout();
            Panel_UpDate_Now.ResumeLayout(false);
            Panel_UpDate_Now.PerformLayout();
            groupBox4.ResumeLayout(false);
            Panel_Update.ResumeLayout(false);
            Panel_Update.PerformLayout();
            Panel_Update_Info.ResumeLayout(false);
            Panel_Update_Info.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Label Label_Git_VerNo;
        private PictureBox PictureBox_Icon;
        private Label Label_Git_Ver;
        private Label label4;
        private Label Label_Now_Ver;
        private GroupBox GBox_Ver;
        private GroupBox GBox_Developer;
        private Label label8;
        private Label label7;
        private Label label6;
        private GroupBox GBox_Copyright;
        private Label Label_UpDate_New;
        private Label Label_NewVer;
        private LinkLabel LinkLabel_New_Version;
        private Label label14;
        private Label label13;
        private LinkLabel LinkLabel_GitHub;
        private Button Button_Close;
        private LinkLabel LinkLabel_License;
        private Label Label_This_Software;
        private Panel Panel_UpDate_Now;
        private Label Label_UpDate_Now;
        private GroupBox groupBox4;
        private Panel Panel_UpDate_New;
        private Panel panel1;
        private Panel Panel_Update;
        private Label Label_Update_Info;
        private Panel Panel_Update_Info;
    }
}