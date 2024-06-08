namespace DoAn
{
    partial class TraLoi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TraLoi));
            pictureBox1 = new PictureBox();
            label14 = new Label();
            label20 = new Label();
            label1 = new Label();
            label2 = new Label();
            context = new TextBox();
            SoanThu = new Button();
            label3 = new Label();
            emailTo = new TextBox();
            pictureBox2 = new PictureBox();
            button4 = new Button();
            CloseButton = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(12, 13);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(58, 53);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 20;
            pictureBox1.TabStop = false;
            // 
            // label14
            // 
            label14.BorderStyle = BorderStyle.Fixed3D;
            label14.Location = new Point(103, 13);
            label14.Name = "label14";
            label14.Size = new Size(10, 251);
            label14.TabIndex = 38;
            // 
            // label20
            // 
            label20.BorderStyle = BorderStyle.Fixed3D;
            label20.Location = new Point(103, 264);
            label20.Name = "label20";
            label20.Size = new Size(982, 2);
            label20.TabIndex = 47;
            // 
            // label1
            // 
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.Location = new Point(103, 13);
            label1.Name = "label1";
            label1.Size = new Size(982, 2);
            label1.TabIndex = 48;
            // 
            // label2
            // 
            label2.BorderStyle = BorderStyle.Fixed3D;
            label2.Location = new Point(1075, 13);
            label2.Name = "label2";
            label2.Size = new Size(2, 251);
            label2.TabIndex = 49;
            // 
            // context
            // 
            context.BackColor = Color.White;
            context.BorderStyle = BorderStyle.None;
            context.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            context.Location = new Point(119, 57);
            context.Multiline = true;
            context.Name = "context";
            context.Size = new Size(950, 39);
            context.TabIndex = 51;
            context.TextChanged += context_TextChanged;
            // 
            // SoanThu
            // 
            SoanThu.BackColor = Color.FromArgb(11, 87, 208);
            SoanThu.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            SoanThu.ForeColor = Color.White;
            SoanThu.ImageAlign = ContentAlignment.MiddleLeft;
            SoanThu.Location = new Point(103, 289);
            SoanThu.Name = "SoanThu";
            SoanThu.Size = new Size(82, 42);
            SoanThu.TabIndex = 52;
            SoanThu.Text = "Gửi";
            SoanThu.UseVisualStyleBackColor = false;
            SoanThu.Click += SoanThu_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(119, 24);
            label3.Name = "label3";
            label3.Size = new Size(39, 20);
            label3.TabIndex = 53;
            label3.Text = "Đến";
            // 
            // emailTo
            // 
            emailTo.BackColor = Color.White;
            emailTo.BorderStyle = BorderStyle.None;
            emailTo.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            emailTo.Location = new Point(164, 24);
            emailTo.Multiline = true;
            emailTo.Name = "emailTo";
            emailTo.Size = new Size(488, 27);
            emailTo.TabIndex = 54;
            emailTo.Text = "asdasdasd";
            // 
            // pictureBox2
            // 
            pictureBox2.Location = new Point(119, 102);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(158, 159);
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.TabIndex = 55;
            pictureBox2.TabStop = false;
            // 
            // button4
            // 
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Image = (Image)resources.GetObject("button4.Image");
            button4.Location = new Point(211, 296);
            button4.Name = "button4";
            button4.Size = new Size(30, 29);
            button4.TabIndex = 56;
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // CloseButton
            // 
            CloseButton.FlatAppearance.BorderSize = 0;
            CloseButton.FlatStyle = FlatStyle.Flat;
            CloseButton.Image = (Image)resources.GetObject("CloseButton.Image");
            CloseButton.Location = new Point(1035, 18);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(34, 26);
            CloseButton.TabIndex = 57;
            CloseButton.UseVisualStyleBackColor = true;
            CloseButton.Click += CloseButton_Click;
            // 
            // TraLoi
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(CloseButton);
            Controls.Add(button4);
            Controls.Add(pictureBox2);
            Controls.Add(emailTo);
            Controls.Add(label3);
            Controls.Add(SoanThu);
            Controls.Add(context);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(label20);
            Controls.Add(label14);
            Controls.Add(pictureBox1);
            Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            Name = "TraLoi";
            Size = new Size(1172, 345);
            Load += TraLoi_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label14;
        private Label label20;
        private Label label1;
        private Label label2;
        private TextBox context;
        private Button SoanThu;
        private Label label3;
        private TextBox emailTo;
        private PictureBox pictureBox2;
        private Button button4;
        private Button CloseButton;
    }
}
