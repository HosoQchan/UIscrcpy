namespace UIscrcpy
{
    partial class Form_Edit_Preset
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
            GBox_Audio = new GroupBox();
            Label_Audio_buffer = new Label();
            Label_Audio_bps = new Label();
            Cbox_audio_buffer = new ComboBox();
            Cbox_audio_bps = new ComboBox();
            GBox_Picture = new GroupBox();
            Label_Video_buffer = new Label();
            Cbox_video_buffer = new ComboBox();
            Label_Video_fps = new Label();
            Cbox_video_fps = new ComboBox();
            Label_Video_bps = new Label();
            Cbox_video_bps = new ComboBox();
            Label_Video_size = new Label();
            Cbox_video_size = new ComboBox();
            CheckB_Disable_Sleep = new CheckBox();
            CheckB_Disable_Screensaver = new CheckBox();
            CheckB_window_borderless = new CheckBox();
            CheckB_full_screen = new CheckBox();
            Label_Preset = new Label();
            CheckB_Tap_Disp = new CheckBox();
            GBox_Option = new GroupBox();
            GBox_Win = new GroupBox();
            TextBox_Preset_Name = new TextBox();
            panel1 = new Panel();
            GBox_Audio.SuspendLayout();
            GBox_Picture.SuspendLayout();
            GBox_Option.SuspendLayout();
            GBox_Win.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // Button_Decision
            // 
            Button_Decision.BackColor = SystemColors.Highlight;
            Button_Decision.Dock = DockStyle.Right;
            Button_Decision.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            Button_Decision.ForeColor = SystemColors.HighlightText;
            Button_Decision.Location = new Point(562, 0);
            Button_Decision.Margin = new Padding(10);
            Button_Decision.MinimumSize = new Size(134, 34);
            Button_Decision.Name = "Button_Decision";
            Button_Decision.Size = new Size(134, 34);
            Button_Decision.TabIndex = 6;
            Button_Decision.Text = "確定";
            Button_Decision.UseVisualStyleBackColor = false;
            Button_Decision.Click += Button_Decision_Click;
            // 
            // Button_Cancel
            // 
            Button_Cancel.BackColor = SystemColors.Highlight;
            Button_Cancel.Dock = DockStyle.Right;
            Button_Cancel.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            Button_Cancel.ForeColor = SystemColors.HighlightText;
            Button_Cancel.Location = new Point(428, 0);
            Button_Cancel.Margin = new Padding(10);
            Button_Cancel.MinimumSize = new Size(134, 34);
            Button_Cancel.Name = "Button_Cancel";
            Button_Cancel.Size = new Size(134, 34);
            Button_Cancel.TabIndex = 7;
            Button_Cancel.Text = "取り消し";
            Button_Cancel.UseVisualStyleBackColor = false;
            Button_Cancel.Click += Button_Cancel_Click;
            // 
            // GBox_Audio
            // 
            GBox_Audio.Controls.Add(Label_Audio_buffer);
            GBox_Audio.Controls.Add(Label_Audio_bps);
            GBox_Audio.Controls.Add(Cbox_audio_buffer);
            GBox_Audio.Controls.Add(Cbox_audio_bps);
            GBox_Audio.Location = new Point(350, 159);
            GBox_Audio.Name = "GBox_Audio";
            GBox_Audio.Size = new Size(340, 109);
            GBox_Audio.TabIndex = 7;
            GBox_Audio.TabStop = false;
            GBox_Audio.Text = "音声";
            // 
            // Label_Audio_buffer
            // 
            Label_Audio_buffer.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            Label_Audio_buffer.Location = new Point(19, 68);
            Label_Audio_buffer.Name = "Label_Audio_buffer";
            Label_Audio_buffer.Size = new Size(166, 33);
            Label_Audio_buffer.TabIndex = 8;
            Label_Audio_buffer.Text = "オーディオバッファ";
            Label_Audio_buffer.TextAlign = ContentAlignment.MiddleRight;
            // 
            // Label_Audio_bps
            // 
            Label_Audio_bps.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            Label_Audio_bps.Location = new Point(19, 29);
            Label_Audio_bps.Name = "Label_Audio_bps";
            Label_Audio_bps.Size = new Size(166, 33);
            Label_Audio_bps.TabIndex = 6;
            Label_Audio_bps.Text = "ビットレート";
            Label_Audio_bps.TextAlign = ContentAlignment.MiddleRight;
            // 
            // Cbox_audio_buffer
            // 
            Cbox_audio_buffer.DropDownStyle = ComboBoxStyle.DropDownList;
            Cbox_audio_buffer.FormattingEnabled = true;
            Cbox_audio_buffer.Location = new Point(191, 68);
            Cbox_audio_buffer.Name = "Cbox_audio_buffer";
            Cbox_audio_buffer.Size = new Size(143, 33);
            Cbox_audio_buffer.TabIndex = 9;
            // 
            // Cbox_audio_bps
            // 
            Cbox_audio_bps.DropDownStyle = ComboBoxStyle.DropDownList;
            Cbox_audio_bps.FormattingEnabled = true;
            Cbox_audio_bps.Location = new Point(191, 29);
            Cbox_audio_bps.Name = "Cbox_audio_bps";
            Cbox_audio_bps.Size = new Size(143, 33);
            Cbox_audio_bps.TabIndex = 7;
            // 
            // GBox_Picture
            // 
            GBox_Picture.Controls.Add(Label_Video_buffer);
            GBox_Picture.Controls.Add(Cbox_video_buffer);
            GBox_Picture.Controls.Add(Label_Video_fps);
            GBox_Picture.Controls.Add(Cbox_video_fps);
            GBox_Picture.Controls.Add(Label_Video_bps);
            GBox_Picture.Controls.Add(Cbox_video_bps);
            GBox_Picture.Controls.Add(Label_Video_size);
            GBox_Picture.Controls.Add(Cbox_video_size);
            GBox_Picture.Location = new Point(12, 159);
            GBox_Picture.Name = "GBox_Picture";
            GBox_Picture.Size = new Size(332, 252);
            GBox_Picture.TabIndex = 6;
            GBox_Picture.TabStop = false;
            GBox_Picture.Text = "映像";
            // 
            // Label_Video_buffer
            // 
            Label_Video_buffer.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            Label_Video_buffer.Location = new Point(6, 146);
            Label_Video_buffer.Name = "Label_Video_buffer";
            Label_Video_buffer.Size = new Size(166, 33);
            Label_Video_buffer.TabIndex = 6;
            Label_Video_buffer.Text = "ビデオバッファ";
            Label_Video_buffer.TextAlign = ContentAlignment.MiddleRight;
            // 
            // Cbox_video_buffer
            // 
            Cbox_video_buffer.DropDownStyle = ComboBoxStyle.DropDownList;
            Cbox_video_buffer.FormattingEnabled = true;
            Cbox_video_buffer.Location = new Point(178, 146);
            Cbox_video_buffer.Name = "Cbox_video_buffer";
            Cbox_video_buffer.Size = new Size(143, 33);
            Cbox_video_buffer.TabIndex = 7;
            // 
            // Label_Video_fps
            // 
            Label_Video_fps.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            Label_Video_fps.Location = new Point(6, 107);
            Label_Video_fps.Name = "Label_Video_fps";
            Label_Video_fps.Size = new Size(166, 33);
            Label_Video_fps.TabIndex = 4;
            Label_Video_fps.Text = "フレームレート(最大)";
            Label_Video_fps.TextAlign = ContentAlignment.MiddleRight;
            // 
            // Cbox_video_fps
            // 
            Cbox_video_fps.DropDownStyle = ComboBoxStyle.DropDownList;
            Cbox_video_fps.FormattingEnabled = true;
            Cbox_video_fps.Location = new Point(178, 107);
            Cbox_video_fps.Name = "Cbox_video_fps";
            Cbox_video_fps.Size = new Size(143, 33);
            Cbox_video_fps.TabIndex = 5;
            // 
            // Label_Video_bps
            // 
            Label_Video_bps.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            Label_Video_bps.Location = new Point(6, 68);
            Label_Video_bps.Name = "Label_Video_bps";
            Label_Video_bps.Size = new Size(166, 33);
            Label_Video_bps.TabIndex = 0;
            Label_Video_bps.Text = "ビットレート";
            Label_Video_bps.TextAlign = ContentAlignment.MiddleRight;
            // 
            // Cbox_video_bps
            // 
            Cbox_video_bps.DropDownStyle = ComboBoxStyle.DropDownList;
            Cbox_video_bps.FormattingEnabled = true;
            Cbox_video_bps.Location = new Point(178, 68);
            Cbox_video_bps.Name = "Cbox_video_bps";
            Cbox_video_bps.Size = new Size(143, 33);
            Cbox_video_bps.TabIndex = 1;
            // 
            // Label_Video_size
            // 
            Label_Video_size.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            Label_Video_size.Location = new Point(6, 30);
            Label_Video_size.Name = "Label_Video_size";
            Label_Video_size.Size = new Size(166, 33);
            Label_Video_size.TabIndex = 2;
            Label_Video_size.Text = "ビデオサイズ(最大)";
            Label_Video_size.TextAlign = ContentAlignment.MiddleRight;
            // 
            // Cbox_video_size
            // 
            Cbox_video_size.DropDownStyle = ComboBoxStyle.DropDownList;
            Cbox_video_size.FormattingEnabled = true;
            Cbox_video_size.ItemHeight = 25;
            Cbox_video_size.Location = new Point(178, 29);
            Cbox_video_size.Name = "Cbox_video_size";
            Cbox_video_size.Size = new Size(143, 33);
            Cbox_video_size.TabIndex = 3;
            // 
            // CheckB_Disable_Sleep
            // 
            CheckB_Disable_Sleep.AutoSize = true;
            CheckB_Disable_Sleep.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            CheckB_Disable_Sleep.ForeColor = SystemColors.Highlight;
            CheckB_Disable_Sleep.Location = new Point(18, 65);
            CheckB_Disable_Sleep.Name = "CheckB_Disable_Sleep";
            CheckB_Disable_Sleep.Size = new Size(210, 29);
            CheckB_Disable_Sleep.TabIndex = 11;
            CheckB_Disable_Sleep.Text = "端末のスリープを無効化";
            CheckB_Disable_Sleep.UseVisualStyleBackColor = true;
            // 
            // CheckB_Disable_Screensaver
            // 
            CheckB_Disable_Screensaver.AutoSize = true;
            CheckB_Disable_Screensaver.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            CheckB_Disable_Screensaver.ForeColor = SystemColors.Highlight;
            CheckB_Disable_Screensaver.Location = new Point(18, 98);
            CheckB_Disable_Screensaver.Name = "CheckB_Disable_Screensaver";
            CheckB_Disable_Screensaver.Size = new Size(215, 29);
            CheckB_Disable_Screensaver.TabIndex = 10;
            CheckB_Disable_Screensaver.Text = "スクリーンセーバを無効化";
            CheckB_Disable_Screensaver.UseVisualStyleBackColor = true;
            // 
            // CheckB_window_borderless
            // 
            CheckB_window_borderless.AutoSize = true;
            CheckB_window_borderless.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            CheckB_window_borderless.ForeColor = SystemColors.Highlight;
            CheckB_window_borderless.Location = new Point(6, 65);
            CheckB_window_borderless.Name = "CheckB_window_borderless";
            CheckB_window_borderless.Size = new Size(265, 29);
            CheckB_window_borderless.TabIndex = 9;
            CheckB_window_borderless.Text = "窓枠を非表示(ボーダレス)にする";
            CheckB_window_borderless.UseVisualStyleBackColor = true;
            // 
            // CheckB_full_screen
            // 
            CheckB_full_screen.AutoSize = true;
            CheckB_full_screen.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            CheckB_full_screen.ForeColor = SystemColors.Highlight;
            CheckB_full_screen.Location = new Point(6, 30);
            CheckB_full_screen.Name = "CheckB_full_screen";
            CheckB_full_screen.Size = new Size(168, 29);
            CheckB_full_screen.TabIndex = 8;
            CheckB_full_screen.Text = "フルスクリーン表示";
            CheckB_full_screen.UseVisualStyleBackColor = true;
            // 
            // Label_Preset
            // 
            Label_Preset.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            Label_Preset.Location = new Point(12, 12);
            Label_Preset.Name = "Label_Preset";
            Label_Preset.Size = new Size(90, 34);
            Label_Preset.TabIndex = 1;
            Label_Preset.Text = "プリセット";
            Label_Preset.TextAlign = ContentAlignment.MiddleRight;
            // 
            // CheckB_Tap_Disp
            // 
            CheckB_Tap_Disp.AutoSize = true;
            CheckB_Tap_Disp.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            CheckB_Tap_Disp.ForeColor = SystemColors.Highlight;
            CheckB_Tap_Disp.Location = new Point(18, 30);
            CheckB_Tap_Disp.Name = "CheckB_Tap_Disp";
            CheckB_Tap_Disp.Size = new Size(158, 29);
            CheckB_Tap_Disp.TabIndex = 12;
            CheckB_Tap_Disp.Text = "タップを表示する";
            CheckB_Tap_Disp.UseVisualStyleBackColor = true;
            // 
            // GBox_Option
            // 
            GBox_Option.Controls.Add(CheckB_Disable_Screensaver);
            GBox_Option.Controls.Add(CheckB_Tap_Disp);
            GBox_Option.Controls.Add(CheckB_Disable_Sleep);
            GBox_Option.Location = new Point(350, 274);
            GBox_Option.Name = "GBox_Option";
            GBox_Option.Size = new Size(340, 137);
            GBox_Option.TabIndex = 8;
            GBox_Option.TabStop = false;
            GBox_Option.Text = "オプション";
            // 
            // GBox_Win
            // 
            GBox_Win.Controls.Add(CheckB_full_screen);
            GBox_Win.Controls.Add(CheckB_window_borderless);
            GBox_Win.Location = new Point(12, 49);
            GBox_Win.Name = "GBox_Win";
            GBox_Win.Size = new Size(332, 104);
            GBox_Win.TabIndex = 9;
            GBox_Win.TabStop = false;
            GBox_Win.Text = "Window";
            // 
            // TextBox_Preset_Name
            // 
            TextBox_Preset_Name.Location = new Point(108, 12);
            TextBox_Preset_Name.Name = "TextBox_Preset_Name";
            TextBox_Preset_Name.ReadOnly = true;
            TextBox_Preset_Name.Size = new Size(248, 31);
            TextBox_Preset_Name.TabIndex = 19;
            // 
            // panel1
            // 
            panel1.Controls.Add(Button_Cancel);
            panel1.Controls.Add(Button_Decision);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 414);
            panel1.Name = "panel1";
            panel1.Size = new Size(696, 34);
            panel1.TabIndex = 20;
            // 
            // Form_Edit_Preset
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(696, 448);
            Controls.Add(panel1);
            Controls.Add(TextBox_Preset_Name);
            Controls.Add(GBox_Win);
            Controls.Add(GBox_Option);
            Controls.Add(GBox_Audio);
            Controls.Add(GBox_Picture);
            Controls.Add(Label_Preset);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form_Edit_Preset";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "設定";
            FormClosed += Form_Edit_Preset_Closed;
            Load += Form_Edit_Preset_Load;
            GBox_Audio.ResumeLayout(false);
            GBox_Picture.ResumeLayout(false);
            GBox_Option.ResumeLayout(false);
            GBox_Option.PerformLayout();
            GBox_Win.ResumeLayout(false);
            GBox_Win.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button Button_Decision;
        private Button Button_Cancel;
        private GroupBox GBox_Audio;
        private Label Label_Audio_buffer;
        private Label Label_Audio_bps;
        private ComboBox Cbox_audio_buffer;
        private ComboBox Cbox_audio_bps;
        private GroupBox GBox_Picture;
        private CheckBox CheckB_window_borderless;
        private CheckBox CheckB_full_screen;
        private Label Label_Video_buffer;
        private ComboBox Cbox_video_buffer;
        private Label Label_Video_fps;
        private ComboBox Cbox_video_fps;
        private Label Label_Video_bps;
        private ComboBox Cbox_video_bps;
        private Label Label_Video_size;
        private ComboBox Cbox_video_size;
        private Label Label_Preset;
        private CheckBox CheckB_Disable_Screensaver;
        private CheckBox CheckB_Disable_Sleep;
        private CheckBox CheckB_Tap_Disp;
        private GroupBox GBox_Win;
        private GroupBox GBox_Option;
        private TextBox TextBox_Preset_Name;
        private Panel panel1;
    }
}