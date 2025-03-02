namespace UIscrcpy
{
    partial class Device_Disp
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
            groupBox2 = new GroupBox();
            Label_IP_Adress = new Label();
            label12 = new Label();
            label13 = new Label();
            label15 = new Label();
            Label_Model = new Label();
            label17 = new Label();
            Label_Product = new Label();
            Label_ID = new Label();
            label21 = new Label();
            Button_Exit = new Button();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(Label_IP_Adress);
            groupBox2.Controls.Add(label12);
            groupBox2.Controls.Add(label13);
            groupBox2.Controls.Add(label15);
            groupBox2.Controls.Add(Label_Model);
            groupBox2.Controls.Add(label17);
            groupBox2.Controls.Add(Label_Product);
            groupBox2.Controls.Add(Label_ID);
            groupBox2.Font = new Font("Yu Gothic UI", 11F, FontStyle.Regular, GraphicsUnit.Point, 128);
            groupBox2.Location = new Point(12, 44);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(490, 299);
            groupBox2.TabIndex = 24;
            groupBox2.TabStop = false;
            groupBox2.Text = "端末情報";
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
            // label21
            // 
            label21.AutoSize = true;
            label21.Font = new Font("Yu Gothic UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 128);
            label21.Location = new Point(149, 9);
            label21.Name = "label21";
            label21.Size = new Size(219, 32);
            label21.TabIndex = 23;
            label21.Text = "登録が完了しました。";
            // 
            // Button_Exit
            // 
            Button_Exit.Dock = DockStyle.Bottom;
            Button_Exit.Font = new Font("Yu Gothic UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 128);
            Button_Exit.Location = new Point(0, 346);
            Button_Exit.Name = "Button_Exit";
            Button_Exit.Size = new Size(517, 34);
            Button_Exit.TabIndex = 25;
            Button_Exit.Text = "閉じる";
            Button_Exit.UseVisualStyleBackColor = true;
            Button_Exit.Click += Button_Exit_Click;
            // 
            // Device_Disp
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(517, 380);
            Controls.Add(Button_Exit);
            Controls.Add(groupBox2);
            Controls.Add(label21);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Device_Disp";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "端末の登録";
            Load += Device_Disp_Load;
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox2;
        private Label Label_IP_Adress;
        private Label label12;
        private Label label13;
        private Label label15;
        private Label Label_Model;
        private Label label17;
        private Label Label_Product;
        private Label Label_ID;
        private Label label21;
        private Button Button_Exit;
    }
}