namespace DoAn
{
    partial class message
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(message));
            button1 = new Button();
            Title = new Label();
            button2 = new Button();
            button4 = new Button();
            date = new Label();
            name = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            NoiDung = new Label();
            flowLayoutPanel2 = new FlowLayoutPanel();
            number = new Label();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // button1
            // 
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Image = Properties.Resources.star;
            button1.Location = new Point(12, 10);
            button1.Name = "button1";
            button1.Size = new Size(30, 29);
            button1.TabIndex = 0;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Title
            // 
            Title.AutoSize = true;
            Title.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            Title.Location = new Point(3, 0);
            Title.Name = "Title";
            Title.Size = new Size(39, 22);
            Title.TabIndex = 1;
            Title.Text = "asd";
            Title.TextAlign = ContentAlignment.MiddleCenter;
            Title.Click += NoiDung_Click;
            // 
            // button2
            // 
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Image = Properties.Resources.unseen;
            button2.Location = new Point(1157, 11);
            button2.Name = "button2";
            button2.Size = new Size(30, 29);
            button2.TabIndex = 2;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button4
            // 
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Image = (Image)resources.GetObject("button4.Image");
            button4.Location = new Point(1192, 10);
            button4.Name = "button4";
            button4.Size = new Size(30, 29);
            button4.TabIndex = 4;
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // date
            // 
            date.AutoSize = true;
            date.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            date.Location = new Point(1025, 13);
            date.Name = "date";
            date.Size = new Size(65, 22);
            date.TabIndex = 5;
            date.Text = "24th12";
            date.TextAlign = ContentAlignment.MiddleRight;
            date.Click += date_Click;
            // 
            // name
            // 
            name.AutoSize = true;
            name.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            name.ForeColor = SystemColors.ControlText;
            name.Location = new Point(3, 0);
            name.Name = "name";
            name.Size = new Size(87, 22);
            name.TabIndex = 6;
            name.Text = "Thư nháp";
            name.Click += name_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(Title);
            flowLayoutPanel1.Controls.Add(NoiDung);
            flowLayoutPanel1.Location = new Point(226, 13);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(779, 31);
            flowLayoutPanel1.TabIndex = 7;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.Click += flowLayoutPanel1_Click;
            // 
            // NoiDung
            // 
            NoiDung.AutoSize = true;
            NoiDung.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            NoiDung.ForeColor = Color.Gray;
            NoiDung.Location = new Point(48, 0);
            NoiDung.Name = "NoiDung";
            NoiDung.Size = new Size(68, 22);
            NoiDung.TabIndex = 4;
            NoiDung.Text = "asdasd";
            NoiDung.TextAlign = ContentAlignment.MiddleLeft;
            NoiDung.Click += NoiDung_Click_1;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(name);
            flowLayoutPanel2.Controls.Add(number);
            flowLayoutPanel2.Location = new Point(48, 13);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(172, 27);
            flowLayoutPanel2.TabIndex = 8;
            flowLayoutPanel2.WrapContents = false;
            flowLayoutPanel2.Click += flowLayoutPanel2_Click;
            // 
            // number
            // 
            number.AutoSize = true;
            number.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            number.ForeColor = Color.Gray;
            number.Location = new Point(96, 0);
            number.Name = "number";
            number.Size = new Size(18, 20);
            number.TabIndex = 7;
            number.Text = "5";
            number.Visible = false;
            number.Click += number_Click;
            // 
            // message
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(242, 246, 252);
            Controls.Add(flowLayoutPanel2);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(date);
            Controls.Add(button4);
            Controls.Add(button2);
            Controls.Add(button1);
            Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "message";
            Size = new Size(1237, 49);
            Load += message_Load;
            Click += message_Click;
            MouseClick += message_MouseClick;
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        public Button button1;
        private Label Title;
        private Button button2;
        private Button button4;
        private Label date;
        public Label name;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label NoiDung;
        private FlowLayoutPanel flowLayoutPanel2;
        public Label number;
    }
}
