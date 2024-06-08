namespace DoAn
{
    partial class MessForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MessForm));
            panel1 = new Panel();
            CloseButton = new Button();
            label1 = new Label();
            context = new TextBox();
            SoanThu = new Button();
            button1 = new Button();
            To = new ReaLTaiizor.Controls.MaterialMaskedTextBox();
            title = new ReaLTaiizor.Controls.MaterialMaskedTextBox();
            button4 = new Button();
            pictureBox1 = new PictureBox();
            button2 = new Button();
            file = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(242, 246, 252);
            panel1.Controls.Add(CloseButton);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(630, 46);
            panel1.TabIndex = 0;
            // 
            // CloseButton
            // 
            CloseButton.FlatAppearance.BorderSize = 0;
            CloseButton.FlatStyle = FlatStyle.Flat;
            CloseButton.Image = (Image)resources.GetObject("CloseButton.Image");
            CloseButton.Location = new Point(593, 7);
            CloseButton.Name = "CloseButton";
            CloseButton.Size = new Size(34, 26);
            CloseButton.TabIndex = 6;
            CloseButton.UseVisualStyleBackColor = true;
            CloseButton.Click += CloseButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.FromArgb(4, 30, 73);
            label1.Location = new Point(12, 13);
            label1.Name = "label1";
            label1.Size = new Size(69, 20);
            label1.TabIndex = 0;
            label1.Text = "Thư mới";
            // 
            // context
            // 
            context.BackColor = Color.White;
            context.BorderStyle = BorderStyle.None;
            context.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            context.Location = new Point(12, 160);
            context.Multiline = true;
            context.Name = "context";
            context.Size = new Size(606, 51);
            context.TabIndex = 3;
            context.WordWrap = false;
            context.TextChanged += context_TextChanged;
            // 
            // SoanThu
            // 
            SoanThu.BackColor = Color.FromArgb(11, 87, 208);
            SoanThu.Font = new Font("Microsoft Sans Serif", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
            SoanThu.ForeColor = Color.White;
            SoanThu.ImageAlign = ContentAlignment.MiddleLeft;
            SoanThu.Location = new Point(40, 455);
            SoanThu.Name = "SoanThu";
            SoanThu.Size = new Size(82, 42);
            SoanThu.TabIndex = 4;
            SoanThu.Text = "Gửi";
            SoanThu.UseVisualStyleBackColor = false;
            SoanThu.Click += SoanThu_Click;
            // 
            // button1
            // 
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.Location = new Point(593, 463);
            button1.Name = "button1";
            button1.Size = new Size(34, 26);
            button1.TabIndex = 5;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // To
            // 
            To.AllowPromptAsInput = true;
            To.AnimateReadOnly = false;
            To.AsciiOnly = false;
            To.BackgroundImageLayout = ImageLayout.None;
            To.BeepOnError = false;
            To.CutCopyMaskFormat = MaskFormat.IncludeLiterals;
            To.Depth = 0;
            To.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            To.HidePromptOnLeave = false;
            To.HideSelection = true;
            To.Hint = "Đến";
            To.InsertKeyMode = InsertKeyMode.Default;
            To.LeadingIcon = null;
            To.Location = new Point(0, 46);
            To.Mask = "";
            To.MaxLength = 32767;
            To.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            To.Name = "To";
            To.PasswordChar = '\0';
            To.PrefixSuffixText = null;
            To.PromptChar = '_';
            To.ReadOnly = false;
            To.RejectInputOnFirstFailure = false;
            To.ResetOnPrompt = true;
            To.ResetOnSpace = true;
            To.RightToLeft = RightToLeft.No;
            To.SelectedText = "";
            To.SelectionLength = 0;
            To.SelectionStart = 0;
            To.ShortcutsEnabled = true;
            To.Size = new Size(627, 48);
            To.SkipLiterals = true;
            To.TabIndex = 1;
            To.TabStop = false;
            To.TextAlign = HorizontalAlignment.Left;
            To.TextMaskFormat = MaskFormat.IncludeLiterals;
            To.TrailingIcon = null;
            To.UseSystemPasswordChar = false;
            To.ValidatingType = null;
            // 
            // title
            // 
            title.AllowPromptAsInput = true;
            title.AnimateReadOnly = false;
            title.AsciiOnly = false;
            title.BackgroundImageLayout = ImageLayout.None;
            title.BeepOnError = false;
            title.CutCopyMaskFormat = MaskFormat.IncludeLiterals;
            title.Depth = 0;
            title.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Pixel);
            title.HidePromptOnLeave = false;
            title.HideSelection = true;
            title.Hint = "Tiêu đề";
            title.InsertKeyMode = InsertKeyMode.Default;
            title.LeadingIcon = null;
            title.Location = new Point(0, 94);
            title.Mask = "";
            title.MaxLength = 32767;
            title.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.OUT;
            title.Name = "title";
            title.PasswordChar = '\0';
            title.PrefixSuffixText = null;
            title.PromptChar = '_';
            title.ReadOnly = false;
            title.RejectInputOnFirstFailure = false;
            title.ResetOnPrompt = true;
            title.ResetOnSpace = true;
            title.RightToLeft = RightToLeft.No;
            title.SelectedText = "";
            title.SelectionLength = 0;
            title.SelectionStart = 0;
            title.ShortcutsEnabled = true;
            title.Size = new Size(627, 48);
            title.SkipLiterals = true;
            title.TabIndex = 2;
            title.TabStop = false;
            title.TextAlign = HorizontalAlignment.Left;
            title.TextMaskFormat = MaskFormat.IncludeLiterals;
            title.TrailingIcon = null;
            title.UseSystemPasswordChar = false;
            title.ValidatingType = null;
            // 
            // button4
            // 
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Image = (Image)resources.GetObject("button4.Image");
            button4.Location = new Point(142, 459);
            button4.Name = "button4";
            button4.Size = new Size(30, 29);
            button4.TabIndex = 6;
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(12, 221);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(200, 200);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 7;
            pictureBox1.TabStop = false;
            // 
            // button2
            // 
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Image = (Image)resources.GetObject("button2.Image");
            button2.Location = new Point(178, 462);
            button2.Name = "button2";
            button2.Size = new Size(30, 29);
            button2.TabIndex = 8;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // file
            // 
            file.AutoSize = true;
            file.Location = new Point(37, 427);
            file.Name = "file";
            file.Size = new Size(50, 20);
            file.TabIndex = 9;
            file.Text = "label2";
            file.Visible = false;
            // 
            // MessForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(630, 500);
            Controls.Add(file);
            Controls.Add(button2);
            Controls.Add(pictureBox1);
            Controls.Add(button4);
            Controls.Add(title);
            Controls.Add(To);
            Controls.Add(button1);
            Controls.Add(SoanThu);
            Controls.Add(context);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MessForm";
            StartPosition = FormStartPosition.Manual;
            Text = "MessForm";
            Load += MessForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Button CloseButton;
        public TextBox context;
        private Button SoanThu;
        private Button button1;
        public ReaLTaiizor.Controls.MaterialMaskedTextBox To;
        public ReaLTaiizor.Controls.MaterialMaskedTextBox title;
        private Button button4;
        public PictureBox pictureBox1;
        private Button button2;
        private Label file;
    }
}