namespace UIscrcpy
{
    partial class MBox
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
            panel1 = new Panel();
            Button3 = new Button();
            Button2 = new Button();
            Button1 = new Button();
            panel2 = new Panel();
            PictureBox = new PictureBox();
            Label_Message = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PictureBox).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(Button3);
            panel1.Controls.Add(Button2);
            panel1.Controls.Add(Button1);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 130);
            panel1.MinimumSize = new Size(0, 34);
            panel1.Name = "panel1";
            panel1.Size = new Size(448, 34);
            panel1.TabIndex = 0;
            // 
            // Button3
            // 
            Button3.BackColor = SystemColors.Highlight;
            Button3.Dock = DockStyle.Right;
            Button3.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            Button3.ForeColor = SystemColors.HighlightText;
            Button3.Location = new Point(19, 0);
            Button3.Margin = new Padding(10);
            Button3.Name = "Button3";
            Button3.Size = new Size(143, 34);
            Button3.TabIndex = 2;
            Button3.Text = "button3";
            Button3.UseVisualStyleBackColor = false;
            Button3.Click += Button3_Click;
            // 
            // Button2
            // 
            Button2.BackColor = SystemColors.Highlight;
            Button2.Dock = DockStyle.Right;
            Button2.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            Button2.ForeColor = SystemColors.HighlightText;
            Button2.Location = new Point(162, 0);
            Button2.Margin = new Padding(10);
            Button2.Name = "Button2";
            Button2.Size = new Size(143, 34);
            Button2.TabIndex = 1;
            Button2.Text = "button2";
            Button2.UseVisualStyleBackColor = false;
            Button2.Click += Button2_Click;
            // 
            // Button1
            // 
            Button1.BackColor = SystemColors.Highlight;
            Button1.Dock = DockStyle.Right;
            Button1.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            Button1.ForeColor = SystemColors.HighlightText;
            Button1.Location = new Point(305, 0);
            Button1.Margin = new Padding(10);
            Button1.Name = "Button1";
            Button1.Size = new Size(143, 34);
            Button1.TabIndex = 0;
            Button1.Text = "button1";
            Button1.UseVisualStyleBackColor = false;
            Button1.Click += Button1_Click;
            // 
            // panel2
            // 
            panel2.Controls.Add(PictureBox);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 0);
            panel2.MaximumSize = new Size(128, 128);
            panel2.MinimumSize = new Size(128, 128);
            panel2.Name = "panel2";
            panel2.Size = new Size(128, 128);
            panel2.TabIndex = 1;
            // 
            // PictureBox
            // 
            PictureBox.Location = new Point(28, 25);
            PictureBox.MinimumSize = new Size(80, 80);
            PictureBox.Name = "PictureBox";
            PictureBox.Size = new Size(80, 80);
            PictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            PictureBox.TabIndex = 0;
            PictureBox.TabStop = false;
            // 
            // Label_Message
            // 
            Label_Message.Dock = DockStyle.Fill;
            Label_Message.Location = new Point(128, 0);
            Label_Message.Name = "Label_Message";
            Label_Message.Size = new Size(320, 130);
            Label_Message.TabIndex = 2;
            Label_Message.Text = "label1";
            // 
            // MBox
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(448, 164);
            ControlBox = false;
            Controls.Add(Label_Message);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            MaximizeBox = false;
            MaximumSize = new Size(470, 220);
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            MinimumSize = new Size(470, 220);
            Name = "MBox";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MessageBox";
            Load += MessageBox_Load;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)PictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button Button3;
        private Button Button2;
        private Button Button1;
        private Panel panel2;
        private PictureBox PictureBox;
        private Label Label_Message;
    }
}