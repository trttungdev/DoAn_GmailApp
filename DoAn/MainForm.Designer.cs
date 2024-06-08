namespace DoAn
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            panel1 = new Panel();
            profile = new Button();
            SoanThu = new Button();
            bin = new Button();
            draft = new Button();
            send = new Button();
            star = new Button();
            receive = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            searchBox = new TextBox();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(246, 248, 252);
            panel1.Controls.Add(profile);
            panel1.Controls.Add(SoanThu);
            panel1.Controls.Add(bin);
            panel1.Controls.Add(draft);
            panel1.Controls.Add(send);
            panel1.Controls.Add(star);
            panel1.Controls.Add(receive);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(274, 768);
            panel1.TabIndex = 1;
            // 
            // profile
            // 
            profile.BackColor = Color.FromArgb(246, 248, 252);
            profile.FlatAppearance.BorderSize = 0;
            profile.FlatStyle = FlatStyle.Flat;
            profile.Image = (Image)resources.GetObject("profile.Image");
            profile.ImageAlign = ContentAlignment.MiddleLeft;
            profile.Location = new Point(0, 716);
            profile.Name = "profile";
            profile.Size = new Size(274, 52);
            profile.TabIndex = 14;
            profile.Text = "Thông tin";
            profile.UseVisualStyleBackColor = false;
            profile.Click += button1_Click;
            // 
            // SoanThu
            // 
            SoanThu.BackColor = Color.FromArgb(194, 231, 255);
            SoanThu.Image = (Image)resources.GetObject("SoanThu.Image");
            SoanThu.ImageAlign = ContentAlignment.MiddleLeft;
            SoanThu.Location = new Point(12, 12);
            SoanThu.Name = "SoanThu";
            SoanThu.Size = new Size(164, 70);
            SoanThu.TabIndex = 1;
            SoanThu.Text = "Soạn thư";
            SoanThu.UseVisualStyleBackColor = false;
            SoanThu.Click += SoanThu_Click;
            // 
            // bin
            // 
            bin.BackColor = Color.FromArgb(246, 248, 252);
            bin.FlatAppearance.BorderSize = 0;
            bin.FlatStyle = FlatStyle.Flat;
            bin.Image = (Image)resources.GetObject("bin.Image");
            bin.ImageAlign = ContentAlignment.MiddleLeft;
            bin.Location = new Point(0, 312);
            bin.Name = "bin";
            bin.Size = new Size(274, 52);
            bin.TabIndex = 13;
            bin.Text = "Thùng rác";
            bin.UseVisualStyleBackColor = false;
            bin.Click += bin_Click;
            // 
            // draft
            // 
            draft.BackColor = Color.FromArgb(246, 248, 252);
            draft.FlatAppearance.BorderSize = 0;
            draft.FlatStyle = FlatStyle.Flat;
            draft.Image = (Image)resources.GetObject("draft.Image");
            draft.ImageAlign = ContentAlignment.MiddleLeft;
            draft.Location = new Point(0, 260);
            draft.Name = "draft";
            draft.Size = new Size(274, 52);
            draft.TabIndex = 12;
            draft.Text = "Thư nháp";
            draft.UseVisualStyleBackColor = false;
            draft.Click += draft_Click;
            // 
            // send
            // 
            send.BackColor = Color.FromArgb(246, 248, 252);
            send.FlatAppearance.BorderSize = 0;
            send.FlatStyle = FlatStyle.Flat;
            send.Image = (Image)resources.GetObject("send.Image");
            send.ImageAlign = ContentAlignment.MiddleLeft;
            send.Location = new Point(0, 208);
            send.Name = "send";
            send.Size = new Size(274, 52);
            send.TabIndex = 11;
            send.Text = "Đã gửi";
            send.UseVisualStyleBackColor = false;
            send.Click += send_Click;
            // 
            // star
            // 
            star.BackColor = Color.FromArgb(246, 248, 252);
            star.FlatAppearance.BorderSize = 0;
            star.FlatStyle = FlatStyle.Flat;
            star.Image = (Image)resources.GetObject("star.Image");
            star.ImageAlign = ContentAlignment.MiddleLeft;
            star.Location = new Point(0, 156);
            star.Name = "star";
            star.Size = new Size(274, 52);
            star.TabIndex = 9;
            star.Text = "Có gắn dấu sao";
            star.UseVisualStyleBackColor = false;
            star.Click += star_Click;
            // 
            // receive
            // 
            receive.BackColor = Color.FromArgb(246, 248, 252);
            receive.FlatAppearance.BorderSize = 0;
            receive.FlatStyle = FlatStyle.Flat;
            receive.Image = (Image)resources.GetObject("receive.Image");
            receive.ImageAlign = ContentAlignment.MiddleLeft;
            receive.Location = new Point(0, 103);
            receive.Name = "receive";
            receive.Size = new Size(274, 52);
            receive.TabIndex = 0;
            receive.Text = "Hộp thư đến";
            receive.UseVisualStyleBackColor = false;
            receive.Click += receive_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.BackColor = Color.White;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(274, 62);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1237, 706);
            flowLayoutPanel1.TabIndex = 2;
            flowLayoutPanel1.WrapContents = false;
            // 
            // searchBox
            // 
            searchBox.Location = new Point(609, 12);
            searchBox.Multiline = true;
            searchBox.Name = "searchBox";
            searchBox.Size = new Size(454, 41);
            searchBox.TabIndex = 3;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(1069, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(55, 41);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 4;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(14F, 29F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(1511, 768);
            Controls.Add(pictureBox1);
            Controls.Add(searchBox);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(panel1);
            Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainForm";
            Load += MainForm_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel1;
        private Button receive;
        private Button SoanThu;
        private Button draft;
        private Button send;
        private Button star;
        private Button bin;
        private FlowLayoutPanel flowLayoutPanel1;
        private Button profile;
        public TextBox searchBox;
        public PictureBox pictureBox1;
    }
}