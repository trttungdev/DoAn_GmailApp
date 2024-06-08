namespace DoAn
{
    partial class RegForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegForm));
            password = new TextBox();
            username = new TextBox();
            checkBox1 = new CheckBox();
            label4 = new Label();
            label3 = new Label();
            button2 = new Button();
            button1 = new Button();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            textBox1 = new TextBox();
            label2 = new Label();
            email = new TextBox();
            label5 = new Label();
            phone = new TextBox();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // password
            // 
            password.Location = new Point(279, 403);
            password.Multiline = true;
            password.Name = "password";
            password.PasswordChar = '*';
            password.Size = new Size(428, 40);
            password.TabIndex = 28;
            // 
            // username
            // 
            username.Location = new Point(279, 237);
            username.Multiline = true;
            username.Name = "username";
            username.Size = new Size(428, 40);
            username.TabIndex = 26;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(279, 546);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(125, 22);
            checkBox1.TabIndex = 24;
            checkBox1.Text = "Hiện mật khẩu";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(279, 375);
            label4.Name = "label4";
            label4.Size = new Size(219, 25);
            label4.TabIndex = 23;
            label4.Text = "Nhập mật khẩu của bạn";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(279, 209);
            label3.Name = "label3";
            label3.Size = new Size(149, 25);
            label3.TabIndex = 22;
            label3.Text = "Tên người dùng";
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(8, 102, 255);
            button2.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Bold, GraphicsUnit.Point);
            button2.ForeColor = Color.White;
            button2.Location = new Point(580, 587);
            button2.Name = "button2";
            button2.Size = new Size(127, 47);
            button2.TabIndex = 21;
            button2.Text = "Xác nhận";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            button1.ForeColor = Color.FromArgb(8, 102, 255);
            button1.Location = new Point(279, 588);
            button1.Name = "button1";
            button1.Size = new Size(179, 45);
            button1.TabIndex = 20;
            button1.Text = "Quay lại đăng nhập";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 13.8F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(368, 98);
            label1.Name = "label1";
            label1.Size = new Size(264, 29);
            label1.TabIndex = 18;
            label1.Text = "Tạo tài khoản Google";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(434, 25);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(128, 69);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 17;
            pictureBox1.TabStop = false;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(279, 493);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.PasswordChar = '*';
            textBox1.Size = new Size(428, 40);
            textBox1.TabIndex = 29;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(279, 465);
            label2.Name = "label2";
            label2.Size = new Size(243, 25);
            label2.TabIndex = 28;
            label2.Text = "Nhập lại mật khẩu của bạn";
            // 
            // email
            // 
            email.Location = new Point(279, 156);
            email.Multiline = true;
            email.Name = "email";
            email.Size = new Size(428, 40);
            email.TabIndex = 25;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(279, 128);
            label5.Name = "label5";
            label5.Size = new Size(223, 25);
            label5.TabIndex = 30;
            label5.Text = "Email hoặc số điện thoại";
            // 
            // phone
            // 
            phone.Location = new Point(279, 318);
            phone.Multiline = true;
            phone.Name = "phone";
            phone.Size = new Size(428, 40);
            phone.TabIndex = 27;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(279, 290);
            label6.Name = "label6";
            label6.Size = new Size(126, 25);
            label6.TabIndex = 32;
            label6.Text = "Số điện thoại";
            // 
            // RegForm
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1000, 685);
            Controls.Add(phone);
            Controls.Add(label6);
            Controls.Add(email);
            Controls.Add(label5);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(password);
            Controls.Add(username);
            Controls.Add(checkBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Name = "RegForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "RegForm";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox password;
        private TextBox username;
        private CheckBox checkBox1;
        private Label label4;
        private Label label3;
        private Button button2;
        private Button button1;
        private Label label1;
        private PictureBox pictureBox1;
        private TextBox textBox1;
        private Label label2;
        private TextBox email;
        private Label label5;
        private TextBox phone;
        private Label label6;
    }
}