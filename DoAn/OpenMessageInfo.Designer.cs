namespace DoAn
{
    partial class OpenMessageInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OpenMessageInfo));
            pictureBox1 = new PictureBox();
            date = new Label();
            button1 = new Button();
            button4 = new Button();
            context = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            name = new Label();
            addr = new Label();
            flowLayoutPanel2 = new FlowLayoutPanel();
            label1 = new Label();
            line = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            flowLayoutPanel1.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(3, 25);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(58, 53);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 19;
            pictureBox1.TabStop = false;
            // 
            // date
            // 
            date.AutoSize = true;
            date.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            date.ForeColor = Color.Gray;
            date.Location = new Point(931, 27);
            date.Name = "date";
            date.Size = new Size(291, 32);
            date.TabIndex = 20;
            date.Text = "20:20,01 thg 07, 2023";
            date.TextAlign = ContentAlignment.MiddleLeft;
            date.Click += date_Click;
            // 
            // button1
            // 
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Image = Properties.Resources.star;
            button1.Location = new Point(1117, 21);
            button1.Name = "button1";
            button1.Size = new Size(30, 29);
            button1.TabIndex = 21;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button4
            // 
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Image = (Image)resources.GetObject("button4.Image");
            button4.Location = new Point(1153, 21);
            button4.Name = "button4";
            button4.Size = new Size(30, 29);
            button4.TabIndex = 22;
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // context
            // 
            context.AutoSize = true;
            context.Location = new Point(3, 0);
            context.Name = "context";
            context.Size = new Size(125, 32);
            context.TabIndex = 24;
            context.Text = "NoiDung";
            context.Click += context_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Controls.Add(name);
            flowLayoutPanel1.Controls.Add(addr);
            flowLayoutPanel1.Location = new Point(80, 25);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(779, 25);
            flowLayoutPanel1.TabIndex = 25;
            flowLayoutPanel1.WrapContents = false;
            // 
            // name
            // 
            name.AutoSize = true;
            name.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            name.Location = new Point(3, 0);
            name.Name = "name";
            name.Size = new Size(62, 33);
            name.TabIndex = 1;
            name.Text = "asd";
            name.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // addr
            // 
            addr.AutoSize = true;
            addr.Font = new Font("Microsoft Sans Serif", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            addr.ForeColor = Color.Gray;
            addr.Location = new Point(71, 0);
            addr.Name = "addr";
            addr.Size = new Size(109, 33);
            addr.TabIndex = 4;
            addr.Text = "asdasd";
            addr.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanel2
            // 
            flowLayoutPanel2.Controls.Add(context);
            flowLayoutPanel2.Controls.Add(label1);
            flowLayoutPanel2.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel2.Location = new Point(83, 57);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            flowLayoutPanel2.Size = new Size(1081, 125);
            flowLayoutPanel2.TabIndex = 26;
            flowLayoutPanel2.WrapContents = false;
            flowLayoutPanel2.Paint += flowLayoutPanel2_Paint;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(3, 32);
            label1.Name = "label1";
            label1.Size = new Size(60, 32);
            label1.TabIndex = 25;
            label1.Text = "asd";
            label1.Visible = false;
            label1.Click += label1_Click_1;
            // 
            // line
            // 
            line.BorderStyle = BorderStyle.Fixed3D;
            line.Location = new Point(0, 100);
            line.Name = "line";
            line.Size = new Size(1214, 2);
            line.TabIndex = 48;
            // 
            // OpenMessageInfo
            // 
            AutoScaleDimensions = new SizeF(16F, 31F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackColor = Color.White;
            Controls.Add(line);
            Controls.Add(flowLayoutPanel2);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(button4);
            Controls.Add(button1);
            Controls.Add(date);
            Controls.Add(pictureBox1);
            Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            Margin = new Padding(4, 3, 4, 3);
            Name = "OpenMessageInfo";
            Size = new Size(1225, 425);
            Load += OpenMessageInfo_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private PictureBox pictureBox1;
        private Label date;
        private Button button1;
        private Button button4;
        private Label name;
        private Label context;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label Title;
        private Label addr;
        private FlowLayoutPanel flowLayoutPanel2;
        private Label line;
        private Label label1;
    }
}
