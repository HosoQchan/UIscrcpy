namespace UIscrcpy
{
    partial class Form_Device_List
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
            Label_Info = new Label();
            ListView_Device = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            Button_Exit = new Button();
            Button_Del = new Button();
            Button_Add = new Button();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // Label_Info
            // 
            Label_Info.AutoSize = true;
            Label_Info.Dock = DockStyle.Top;
            Label_Info.Location = new Point(0, 0);
            Label_Info.Name = "Label_Info";
            Label_Info.Size = new Size(133, 25);
            Label_Info.TabIndex = 0;
            Label_Info.Text = "登録済みの端末";
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
            Button_Exit.BackColor = SystemColors.Highlight;
            Button_Exit.Dock = DockStyle.Right;
            Button_Exit.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            Button_Exit.ForeColor = SystemColors.HighlightText;
            Button_Exit.Location = new Point(592, 0);
            Button_Exit.Margin = new Padding(10);
            Button_Exit.MinimumSize = new Size(134, 34);
            Button_Exit.Name = "Button_Exit";
            Button_Exit.Size = new Size(134, 34);
            Button_Exit.TabIndex = 13;
            Button_Exit.Text = "閉じる";
            Button_Exit.UseVisualStyleBackColor = false;
            Button_Exit.Click += Button_Exit_Click;
            // 
            // Button_Del
            // 
            Button_Del.BackColor = SystemColors.Highlight;
            Button_Del.Dock = DockStyle.Left;
            Button_Del.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            Button_Del.ForeColor = SystemColors.HighlightText;
            Button_Del.Location = new Point(134, 0);
            Button_Del.Margin = new Padding(10);
            Button_Del.MinimumSize = new Size(134, 34);
            Button_Del.Name = "Button_Del";
            Button_Del.Size = new Size(134, 34);
            Button_Del.TabIndex = 14;
            Button_Del.Text = "削除";
            Button_Del.UseVisualStyleBackColor = false;
            Button_Del.Click += Button_Del_Click;
            // 
            // Button_Add
            // 
            Button_Add.BackColor = SystemColors.Highlight;
            Button_Add.Dock = DockStyle.Left;
            Button_Add.Font = new Font("Yu Gothic UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 128);
            Button_Add.ForeColor = SystemColors.HighlightText;
            Button_Add.Location = new Point(0, 0);
            Button_Add.Margin = new Padding(10);
            Button_Add.MinimumSize = new Size(134, 34);
            Button_Add.Name = "Button_Add";
            Button_Add.Size = new Size(134, 34);
            Button_Add.TabIndex = 15;
            Button_Add.Text = "新規登録";
            Button_Add.UseVisualStyleBackColor = false;
            Button_Add.Click += Button_Add_Click;
            // 
            // panel1
            // 
            panel1.Controls.Add(Button_Del);
            panel1.Controls.Add(Button_Add);
            panel1.Controls.Add(Button_Exit);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 310);
            panel1.Name = "panel1";
            panel1.Size = new Size(726, 34);
            panel1.TabIndex = 16;
            // 
            // Form_Device_List
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(726, 344);
            Controls.Add(panel1);
            Controls.Add(ListView_Device);
            Controls.Add(Label_Info);
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(748, 400);
            Name = "Form_Device_List";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "端末の登録/削除";
            FormClosed += Form_Device_List_Closed;
            Load += Form_Device_List_Load;
            SizeChanged += Form_Device_List_SizeChanged;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Label_Info;
        private ListView ListView_Device;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private Button Button_Exit;
        private Button Button_Del;
        private Button Button_Add;
        private Panel panel1;
    }
}