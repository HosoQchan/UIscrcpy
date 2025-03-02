namespace UIscrcpy
{
    partial class Device_Manager
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
            label1 = new Label();
            ListView_Device = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            Button_Exit = new Button();
            Button_Del = new Button();
            Button_Add = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Top;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(133, 25);
            label1.TabIndex = 0;
            label1.Text = "登録済みの端末";
            // 
            // ListView_Device
            // 
            ListView_Device.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2, columnHeader3, columnHeader4 });
            ListView_Device.Dock = DockStyle.Fill;
            ListView_Device.FullRowSelect = true;
            ListView_Device.Location = new Point(0, 25);
            ListView_Device.Name = "ListView_Device";
            ListView_Device.Size = new Size(726, 319);
            ListView_Device.TabIndex = 1;
            ListView_Device.UseCompatibleStateImageBehavior = false;
            ListView_Device.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "ID";
            columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Product";
            columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Model";
            columnHeader3.Width = 200;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "IP Adress";
            columnHeader4.Width = 200;
            // 
            // Button_Exit
            // 
            Button_Exit.Dock = DockStyle.Bottom;
            Button_Exit.Location = new Point(0, 310);
            Button_Exit.Name = "Button_Exit";
            Button_Exit.Size = new Size(726, 34);
            Button_Exit.TabIndex = 13;
            Button_Exit.Text = "閉じる";
            Button_Exit.UseVisualStyleBackColor = true;
            Button_Exit.Click += Button_Exit_Click;
            // 
            // Button_Del
            // 
            Button_Del.Dock = DockStyle.Bottom;
            Button_Del.Location = new Point(0, 276);
            Button_Del.Name = "Button_Del";
            Button_Del.Size = new Size(726, 34);
            Button_Del.TabIndex = 14;
            Button_Del.Text = "削除";
            Button_Del.UseVisualStyleBackColor = true;
            Button_Del.Click += Button_Del_Click;
            // 
            // Button_Add
            // 
            Button_Add.Dock = DockStyle.Bottom;
            Button_Add.Location = new Point(0, 242);
            Button_Add.Name = "Button_Add";
            Button_Add.Size = new Size(726, 34);
            Button_Add.TabIndex = 15;
            Button_Add.Text = "新規登録";
            Button_Add.UseVisualStyleBackColor = true;
            Button_Add.Click += Button_Add_Click;
            // 
            // Device_Manager
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(726, 344);
            Controls.Add(Button_Add);
            Controls.Add(Button_Del);
            Controls.Add(Button_Exit);
            Controls.Add(ListView_Device);
            Controls.Add(label1);
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(748, 400);
            Name = "Device_Manager";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "端末の登録と削除";
            FormClosed += Device_Manager_FormClosed;
            Load += Device_Manager_Load;
            SizeChanged += Device_Manager_SizeChanged;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ListView ListView_Device;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private Button Button_Exit;
        private Button Button_Del;
        private Button Button_Add;
    }
}