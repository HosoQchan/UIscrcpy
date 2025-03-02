namespace UIscrcpy
{
    partial class Device_Connection
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
            Label_Message = new Label();
            SuspendLayout();
            // 
            // Label_Message
            // 
            Label_Message.AutoSize = true;
            Label_Message.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 128);
            Label_Message.Location = new Point(40, 9);
            Label_Message.Name = "Label_Message";
            Label_Message.Size = new Size(269, 32);
            Label_Message.TabIndex = 0;
            Label_Message.Text = "・・・しばらくお待ちください。";
            // 
            // Device_Connection
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(567, 52);
            ControlBox = false;
            Controls.Add(Label_Message);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Device_Connection";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "端末";
            Load += Device_Connection_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Label_Message;
    }
}