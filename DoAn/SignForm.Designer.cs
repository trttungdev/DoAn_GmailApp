namespace DoAn
{
    partial class SignForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignForm));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            button1 = new Button();
            button2 = new Button();
            label3 = new Label();
            label4 = new Label();
            checkBox1 = new CheckBox();
            button3 = new Button();
            email = new TextBox();
            password = new TextBox();
            checkBox2 = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(434, 25);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(128, 69);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(434, 104);
            label1.Name = "label1";
            label1.Size = new Size(138, 29);
            label1.TabIndex = 1;
            label1.Text = "Đăng nhập";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(421, 133);
            label2.Name = "label2";
            label2.Size = new Size(162, 25);
            label2.TabIndex = 2;
            label2.Text = "Tiếp tục tới Gmail";
            // 
            // button1
            // 
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            button1.ForeColor = Color.FromArgb(8, 102, 255);
            button1.Location = new Point(279, 466);
            button1.Name = "button1";
            button1.Size = new Size(119, 45);
            button1.TabIndex = 5;
            button1.Text = "Tạo tài khoản";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(8, 102, 255);
            button2.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            button2.ForeColor = Color.White;
            button2.Location = new Point(594, 464);
            button2.Name = "button2";
            button2.Size = new Size(127, 47);
            button2.TabIndex = 6;
            button2.Text = "Tiếp theo";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(279, 243);
            label3.Name = "label3";
            label3.Size = new Size(223, 25);
            label3.TabIndex = 11;
            label3.Text = "Email hoặc số điện thoại";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(279, 331);
            label4.Name = "label4";
            label4.Size = new Size(219, 25);
            label4.TabIndex = 12;
            label4.Text = "Nhập mật khẩu của bạn";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(279, 410);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(125, 22);
            checkBox1.TabIndex = 13;
            checkBox1.Text = "Hiện mật khẩu";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // button3
            // 
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            button3.ForeColor = Color.FromArgb(8, 102, 255);
            button3.Location = new Point(548, 400);
            button3.Name = "button3";
            button3.Size = new Size(173, 45);
            button3.TabIndex = 14;
            button3.Text = "Bạn quên mật khẩu?";
            button3.TextAlign = ContentAlignment.MiddleRight;
            button3.UseVisualStyleBackColor = true;
            // 
            // email
            // 
            email.Location = new Point(279, 271);
            email.Multiline = true;
            email.Name = "email";
            email.Size = new Size(428, 40);
            email.TabIndex = 15;
            // 
            // password
            // 
            password.Location = new Point(279, 359);
            password.Multiline = true;
            password.Name = "password";
            password.PasswordChar = '*';
            password.Size = new Size(428, 40);
            password.TabIndex = 16;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Checked = true;
            checkBox2.CheckState = CheckState.Checked;
            checkBox2.Location = new Point(279, 438);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(154, 22);
            checkBox2.TabIndex = 17;
            checkBox2.Text = "Ghi nhớ đăng nhập";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // SignForm
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1000, 600);
            Controls.Add(checkBox2);
            Controls.Add(password);
            Controls.Add(email);
            Controls.Add(button3);
            Controls.Add(checkBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SignForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += SignForm_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private Button button1;
        private Button button2;
        private Label label3;
        private Label label4;
        private CheckBox checkBox1;
        private Button button3;
        private TextBox email;
        private TextBox password;
        private CheckBox checkBox2;
    }
}