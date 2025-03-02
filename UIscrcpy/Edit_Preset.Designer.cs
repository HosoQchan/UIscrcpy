namespace UIscrcpy
{
    partial class Edit_Preset
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
            Button_Decision = new Button();
            Button_Cancel = new Button();
            groupBox4 = new GroupBox();
            label6 = new Label();
            label5 = new Label();
            Cbox_audio_buffer = new ComboBox();
            Cbox_audio_bps = new ComboBox();
            groupBox6 = new GroupBox();
            label7 = new Label();
            Cbox_video_buffer = new ComboBox();
            label8 = new Label();
            Cbox_video_fps = new ComboBox();
            label9 = new Label();
            Cbox_video_bps = new ComboBox();
            label10 = new Label();
            Cbox_video_size = new ComboBox();
            CheckB_Disable_Sleep = new CheckBox();
            CheckB_Disable_Screensaver = new CheckBox();
            CheckB_window_borderless = new CheckBox();
            CheckB_full_screen = new CheckBox();
            label14 = new Label();
            CheckB_Tap_Disp = new CheckBox();
            groupBox1 = new GroupBox();
            groupBox2 = new GroupBox();
            TextBox_Preset_Name = new TextBox();
            groupBox4.SuspendLayout();
            groupBox6.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // Button_Decision
            // 
            Button_Decision.Dock = DockStyle.Bottom;
            Button_Decision.Location = new Point(0, 476);
            Button_Decision.Name = "Button_Decision";
            Button_Decision.Size = new Size(729, 34);
            Button_Decision.TabIndex = 6;
            Button_Decision.Text = "決定";
            Button_Decision.UseVisualStyleBackColor = true;
            Button_Decision.Click += Button_Decision_Click;
            // 
            // Button_Cancel
            // 
            Button_Cancel.Dock = DockStyle.Bottom;
            Button_Cancel.Location = new Point(0, 442);
            Button_Cancel.Name = "Button_Cancel";
            Button_Cancel.Size = new Size(729, 34);
            Button_Cancel.TabIndex = 7;
            Button_Cancel.Text = "キャンセル";
            Button_Cancel.UseVisualStyleBackColor = true;
            Button_Cancel.Click += Button_Cancel_Click;
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(label6);
            groupBox4.Controls.Add(label5);
            groupBox4.Controls.Add(Cbox_audio_buffer);
            groupBox4.Controls.Add(Cbox_audio_bps);
            groupBox4.Location = new Point(384, 197);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(340, 124);
            groupBox4.TabIndex = 7;
            groupBox4.TabStop = false;
            groupBox4.Text = "音声";
            // 
            // label6
            // 
            label6.Location = new Point(6, 69);
            label6.Name = "label6";
            label6.Size = new Size(109, 33);
            label6.TabIndex = 8;
            label6.Text = "バッファ";
            label6.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            label5.Location = new Point(27, 30);
            label5.Name = "label5";
            label5.Size = new Size(88, 33);
            label5.TabIndex = 6;
            label5.Text = "ビットレート";
            label5.TextAlign = ContentAlignment.MiddleRight;
            // 
            // Cbox_audio_buffer
            // 
            Cbox_audio_buffer.DropDownStyle = ComboBoxStyle.DropDownList;
            Cbox_audio_buffer.FormattingEnabled = true;
            Cbox_audio_buffer.Location = new Point(121, 69);
            Cbox_audio_buffer.Name = "Cbox_audio_buffer";
            Cbox_audio_buffer.Size = new Size(143, 33);
            Cbox_audio_buffer.TabIndex = 9;
            // 
            // Cbox_audio_bps
            // 
            Cbox_audio_bps.DropDownStyle = ComboBoxStyle.DropDownList;
            Cbox_audio_bps.FormattingEnabled = true;
            Cbox_audio_bps.Location = new Point(121, 30);
            Cbox_audio_bps.Name = "Cbox_audio_bps";
            Cbox_audio_bps.Size = new Size(143, 33);
            Cbox_audio_bps.TabIndex = 7;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(label7);
            groupBox6.Controls.Add(Cbox_video_buffer);
            groupBox6.Controls.Add(label8);
            groupBox6.Controls.Add(Cbox_video_fps);
            groupBox6.Controls.Add(label9);
            groupBox6.Controls.Add(Cbox_video_bps);
            groupBox6.Controls.Add(label10);
            groupBox6.Controls.Add(Cbox_video_size);
            groupBox6.Location = new Point(24, 197);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(354, 244);
            groupBox6.TabIndex = 6;
            groupBox6.TabStop = false;
            groupBox6.Text = "映像";
            // 
            // label7
            // 
            label7.Location = new Point(46, 146);
            label7.Name = "label7";
            label7.Size = new Size(109, 33);
            label7.TabIndex = 6;
            label7.Text = "バッファ";
            label7.TextAlign = ContentAlignment.MiddleRight;
            // 
            // Cbox_video_buffer
            // 
            Cbox_video_buffer.DropDownStyle = ComboBoxStyle.DropDownList;
            Cbox_video_buffer.FormattingEnabled = true;
            Cbox_video_buffer.Location = new Point(161, 146);
            Cbox_video_buffer.Name = "Cbox_video_buffer";
            Cbox_video_buffer.Size = new Size(143, 33);
            Cbox_video_buffer.TabIndex = 7;
            // 
            // label8
            // 
            label8.Location = new Point(6, 107);
            label8.Name = "label8";
            label8.Size = new Size(149, 33);
            label8.TabIndex = 4;
            label8.Text = "最大フレームレート";
            label8.TextAlign = ContentAlignment.MiddleRight;
            // 
            // Cbox_video_fps
            // 
            Cbox_video_fps.DropDownStyle = ComboBoxStyle.DropDownList;
            Cbox_video_fps.FormattingEnabled = true;
            Cbox_video_fps.Location = new Point(161, 107);
            Cbox_video_fps.Name = "Cbox_video_fps";
            Cbox_video_fps.Size = new Size(143, 33);
            Cbox_video_fps.TabIndex = 5;
            // 
            // label9
            // 
            label9.Location = new Point(67, 68);
            label9.Name = "label9";
            label9.Size = new Size(88, 33);
            label9.TabIndex = 0;
            label9.Text = "ビットレート";
            label9.TextAlign = ContentAlignment.MiddleRight;
            // 
            // Cbox_video_bps
            // 
            Cbox_video_bps.DropDownStyle = ComboBoxStyle.DropDownList;
            Cbox_video_bps.FormattingEnabled = true;
            Cbox_video_bps.Location = new Point(161, 68);
            Cbox_video_bps.Name = "Cbox_video_bps";
            Cbox_video_bps.Size = new Size(143, 33);
            Cbox_video_bps.TabIndex = 1;
            // 
            // label10
            // 
            label10.Location = new Point(20, 30);
            label10.Name = "label10";
            label10.Size = new Size(135, 33);
            label10.TabIndex = 2;
            label10.Text = "最大サイズ";
            label10.TextAlign = ContentAlignment.MiddleRight;
            // 
            // Cbox_video_size
            // 
            Cbox_video_size.DropDownStyle = ComboBoxStyle.DropDownList;
            Cbox_video_size.FormattingEnabled = true;
            Cbox_video_size.ItemHeight = 25;
            Cbox_video_size.Location = new Point(161, 30);
            Cbox_video_size.Name = "Cbox_video_size";
            Cbox_video_size.Size = new Size(143, 33);
            Cbox_video_size.TabIndex = 3;
            // 
            // CheckB_Disable_Sleep
            // 
            CheckB_Disable_Sleep.AutoSize = true;
            CheckB_Disable_Sleep.Location = new Point(18, 69);
            CheckB_Disable_Sleep.Name = "CheckB_Disable_Sleep";
            CheckB_Disable_Sleep.Size = new Size(301, 29);
            CheckB_Disable_Sleep.TabIndex = 11;
            CheckB_Disable_Sleep.Text = "実行中、端末のスリープを無効にする";
            CheckB_Disable_Sleep.UseVisualStyleBackColor = true;
            // 
            // CheckB_Disable_Screensaver
            // 
            CheckB_Disable_Screensaver.AutoSize = true;
            CheckB_Disable_Screensaver.Location = new Point(6, 100);
            CheckB_Disable_Screensaver.Name = "CheckB_Disable_Screensaver";
            CheckB_Disable_Screensaver.Size = new Size(341, 29);
            CheckB_Disable_Screensaver.TabIndex = 10;
            CheckB_Disable_Screensaver.Text = "実行中、PCのスクリーンセーバを無効にする";
            CheckB_Disable_Screensaver.UseVisualStyleBackColor = true;
            // 
            // CheckB_window_borderless
            // 
            CheckB_window_borderless.AutoSize = true;
            CheckB_window_borderless.Location = new Point(6, 65);
            CheckB_window_borderless.Name = "CheckB_window_borderless";
            CheckB_window_borderless.Size = new Size(262, 29);
            CheckB_window_borderless.TabIndex = 9;
            CheckB_window_borderless.Text = "窓枠を非表示(ボーダレス)にする";
            CheckB_window_borderless.UseVisualStyleBackColor = true;
            // 
            // CheckB_full_screen
            // 
            CheckB_full_screen.AutoSize = true;
            CheckB_full_screen.Location = new Point(6, 30);
            CheckB_full_screen.Name = "CheckB_full_screen";
            CheckB_full_screen.Size = new Size(166, 29);
            CheckB_full_screen.TabIndex = 8;
            CheckB_full_screen.Text = "フルスクリーン表示";
            CheckB_full_screen.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            label14.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            label14.Location = new Point(12, 12);
            label14.Name = "label14";
            label14.Size = new Size(90, 34);
            label14.TabIndex = 1;
            label14.Text = "プリセット";
            label14.TextAlign = ContentAlignment.MiddleRight;
            // 
            // CheckB_Tap_Disp
            // 
            CheckB_Tap_Disp.AutoSize = true;
            CheckB_Tap_Disp.Location = new Point(18, 30);
            CheckB_Tap_Disp.Name = "CheckB_Tap_Disp";
            CheckB_Tap_Disp.Size = new Size(157, 29);
            CheckB_Tap_Disp.TabIndex = 12;
            CheckB_Tap_Disp.Text = "タップを表示する";
            CheckB_Tap_Disp.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(CheckB_Tap_Disp);
            groupBox1.Controls.Add(CheckB_Disable_Sleep);
            groupBox1.Location = new Point(384, 327);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(340, 114);
            groupBox1.TabIndex = 8;
            groupBox1.TabStop = false;
            groupBox1.Text = "オプション";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(CheckB_Disable_Screensaver);
            groupBox2.Controls.Add(CheckB_full_screen);
            groupBox2.Controls.Add(CheckB_window_borderless);
            groupBox2.Location = new Point(24, 49);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(354, 142);
            groupBox2.TabIndex = 9;
            groupBox2.TabStop = false;
            groupBox2.Text = "Windows";
            // 
            // TextBox_Preset_Name
            // 
            TextBox_Preset_Name.Location = new Point(108, 12);
            TextBox_Preset_Name.Name = "TextBox_Preset_Name";
            TextBox_Preset_Name.ReadOnly = true;
            TextBox_Preset_Name.Size = new Size(270, 31);
            TextBox_Preset_Name.TabIndex = 19;
            // 
            // Edit_Preset
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(729, 510);
            Controls.Add(TextBox_Preset_Name);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(groupBox4);
            Controls.Add(groupBox6);
            Controls.Add(Button_Cancel);
            Controls.Add(label14);
            Controls.Add(Button_Decision);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Edit_Preset";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "設定";
            FormClosed += Edit_Preset_FormClosed;
            Load += Edit_Preset_Load;
            groupBox4.ResumeLayout(false);
            groupBox6.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button Button_Decision;
        private Button Button_Cancel;
        private GroupBox groupBox4;
        private Label label6;
        private Label label5;
        private ComboBox Cbox_audio_buffer;
        private ComboBox Cbox_audio_bps;
        private GroupBox groupBox6;
        private CheckBox CheckB_window_borderless;
        private CheckBox CheckB_full_screen;
        private Label label7;
        private ComboBox Cbox_video_buffer;
        private Label label8;
        private ComboBox Cbox_video_fps;
        private Label label9;
        private ComboBox Cbox_video_bps;
        private Label label10;
        private ComboBox Cbox_video_size;
        private Label label14;
        private CheckBox CheckB_Disable_Screensaver;
        private CheckBox CheckB_Disable_Sleep;
        private CheckBox CheckB_Tap_Disp;
        private GroupBox groupBox2;
        private GroupBox groupBox1;
        private TextBox TextBox_Preset_Name;
    }
}