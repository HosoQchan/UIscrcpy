namespace UIscrcpy
{
    partial class Form_Device_Disp
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
            GBox_Device_Info = new GroupBox();
            Label_IP_Adress = new Label();
            label12 = new Label();
            label13 = new Label();
            label15 = new Label();
            Label_Model = new Label();
            label17 = new Label();
            Label_Product = new Label();
            Label_ID = new Label();
            Label_RegComp = new Label();
            Button_Exit = new Button();
            panel1 = new Panel();
            GBox_Device_Info.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // GBox_Device_Info
            // 
            GBox_Device_Info.Controls.Add(Label_IP_Adress);
            GBox_Device_Info.Controls.Add(label12);
            GBox_Device_Info.Controls.Add(label13);
            GBox_Device_Info.Controls.Add(label15);
            GBox_Device_Info.Controls.Add(Label_Model);
            GBox_Device_Info.Controls.Add(label17);
            GBox_Device_Info.Controls.Add(Label_Product);
            GBox_Device_Info.Controls.Add(Label_ID);
            GBox_Device_Info.Font = new Font("Yu Gothic UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 128);
            GBox_Device_Info.Location = new Point(12, 44);
            GBox_Device_Info.Name = "GBox_Device_Info";
            GBox_Device_Info.Size = new Size(490, 299);
            GBox_Device_Info.TabIndex = 24;
            GBox_Device_Info.TabStop = false;
            GBox_Device_Info.Text = "登録済みの端末";
            // 
            // Label_IP_Adress
            // 
            Label_IP_Adress.Location = new Point(137, 141);
            Label_IP_Adress.Name = "Label_IP_Adress";
            Label_IP_Adress.Size = new Size(324, 38);
            Label_IP_Adress.TabIndex = 21;
            Label_IP_Adress.Text = "不明";
            Label_IP_Adress.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            label12.Location = new Point(13, 141);
            label12.Name = "label12";
            label12.Size = new Size(118, 38);
            label12.TabIndex = 20;
            label12.Text = "IP Adress:";
            label12.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            label13.Location = new Point(13, 65);
            label13.Name = "label13";
            label13.Size = new Size(118, 38);
            label13.TabIndex = 1;
            label13.Text = "Product:";
            label13.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label15
            // 
            label15.Location = new Point(13, 27);
            label15.Name = "label15";
            label15.Size = new Size(118, 38);
            label15.TabIndex = 0;
            label15.Text = "ID:";
            label15.TextAlign = ContentAlignment.MiddleRight;
            // 
            // Label_Model
            // 
            Label_Model.Location = new Point(137, 103);
            Label_Model.Name = "Label_Model";
            Label_Model.Size = new Size(324, 38);
            Label_Model.TabIndex = 19;
            Label_Model.Text = "不明";
            Label_Model.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // label17
            // 
            label17.Location = new Point(13, 103);
            label17.Name = "label17";
            label17.Size = new Size(118, 38);
            label17.TabIndex = 2;
            label17.Text = "Model:";
            label17.TextAlign = ContentAlignment.MiddleRight;
            // 
            // Label_Product
            // 
            Label_Product.Location = new Point(137, 65);
            Label_Product.Name = "Label_Product";
            Label_Product.Size = new Size(324, 38);
            Label_Product.TabIndex = 18;
            Label_Product.Text = "不明";
            Label_Product.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Label_ID
            // 
            Label_ID.Location = new Point(137, 27);
            Label_ID.Name = "Label_ID";
            Label_ID.Size = new Size(324, 38);
            Label_ID.TabIndex = 17;
            Label_ID.Text = "不明";
            Label_ID.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // Label_RegComp
            // 
            Label_RegComp.AutoSize = true;
            Label_RegComp.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 128);
            Label_RegComp.Location = new Point(149, 9);
            Label_RegComp.Name = "Label_RegComp";
            Label_RegComp.Size = new Size(219, 32);
            Label_RegComp.TabIndex = 23;
            Label_RegComp.Text = "登録が完了しました。";
            // 
            // Button_Exit
            // 
            Button_Exit.BackColor = SystemColors.Highlight;
            Button_Exit.Dock = DockStyle.Right;
            Button_Exit.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            Button_Exit.ForeColor = SystemColors.HighlightText;
            Button_Exit.Location = new Point(383, 0);
            Button_Exit.Margin = new Padding(10);
            Button_Exit.MinimumSize = new Size(134, 34);
            Button_Exit.Name = "Button_Exit";
            Button_Exit.Size = new Size(134, 34);
            Button_Exit.TabIndex = 25;
            Button_Exit.Text = "閉じる";
            Button_Exit.UseVisualStyleBackColor = false;
            Button_Exit.Click += Button_Exit_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(Button_Exit);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 345);
            panel1.Name = "panel1";
            panel1.Size = new Size(517, 34);
            panel1.TabIndex = 26;
            // 
            // Form_Device_Disp
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(517, 379);
            Controls.Add(panel1);
            Controls.Add(GBox_Device_Info);
            Controls.Add(Label_RegComp);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form_Device_Disp";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "登録";
            Load += Form_Device_Disp_Load;
            GBox_Device_Info.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox GBox_Device_Info;
        private Label Label_IP_Adress;
        private Label label12;
        private Label label13;
        private Label label15;
        private Label Label_Model;
        private Label label17;
        private Label Label_Product;
        private Label Label_ID;
        private Label Label_RegComp;
        private Button Button_Exit;
        private Panel panel1;
    }
}