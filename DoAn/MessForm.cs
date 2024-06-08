using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace DoAn
{
    public partial class MessForm : Form
    {
        string email;
        string img_path;
        string file_path;
        public MessForm(string email)
        {
            InitializeComponent();
            this.email = email;
            this.Location = new Point(1080, 400);
        }
        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source = C:\\Users\\Admin\\source\\repos\\DoAn\\DoAn\\bin\\Debug\\db_gmail.accdb");


        private void CloseButton_Click(object sender, EventArgs e)
        {
            conn.Open();
            string login = "SELECT * from tbl_users WHERE email = '" + To.Text + "'";
            OleDbCommand cmd = new OleDbCommand(login, conn);
            OleDbDataReader dr = cmd.ExecuteReader();
            if ((!string.IsNullOrEmpty(To.Text) && dr.Read()) || !string.IsNullOrEmpty(title.Text) || !string.IsNullOrEmpty(context.Text))
            {
                OleDbCommand command1 = new OleDbCommand(@"INSERT INTO tbl_mess ([from],[title],[context],[to], draft,[image],[document]) 
                                                            VALUES 
                                                            (@fr,@title,@context,@t,1,@img,@dcm)", conn);
                command1.Parameters.AddWithValue("@fr", email);
                //command1.Parameters.AddWithValue("@title", string.IsNullOrEmpty(title.Text) ? DBNull.Value : (object)title.Text);
                //command1.Parameters.AddWithValue("@context", string.IsNullOrEmpty(context.Text) ? DBNull.Value : (object)context.Text);
                if (title.TextLength > 1)
                {
                    command1.Parameters.AddWithValue("@title", title.Text);
                }
                else
                {
                    command1.Parameters.AddWithValue("@title", "không có chủ đề");
                }
                if (context.TextLength > 1)
                {
                    command1.Parameters.AddWithValue("@context", context.Text);
                }
                else
                {
                    command1.Parameters.AddWithValue("@context", "Null");
                }
                command1.Parameters.AddWithValue("@t", To.Text);
                if (img_path != null)
                {
                    command1.Parameters.AddWithValue("@img", img_path);
                }
                else
                {
                    command1.Parameters.AddWithValue("@img", "Null");
                }
                if (file_path != null)
                {
                    command1.Parameters.AddWithValue("@dcm", file_path);
                }
                else
                {
                    command1.Parameters.AddWithValue("@dcm", "Null");
                }
                command1.ExecuteNonQuery();
            }
            conn.Close();
            this.Close();

        }

        private void MessForm_Load(object sender, EventArgs e)
        {

        }

        private void SoanThu_Click(object sender, EventArgs e)
        {
            string[] parts = To.Text.Split(',');
            // Hiển thị các phần trong mảng
            foreach (string part in parts)
            {
                conn.Open();
                string login = "SELECT * from tbl_users WHERE email = '" + part + "'";
                OleDbCommand cmd = new OleDbCommand(login, conn);
                OleDbDataReader dr = cmd.ExecuteReader();
                if (dr.Read() == true)
                {
                    OleDbCommand command1 = new OleDbCommand(@"INSERT INTO tbl_mess ([from],[title],[context],[to],[image],draft,[document]) 
                                                            VALUES 
                                                            (@fr,@title,@context,@t,@img,0,@dcm)", conn);
                    command1.Parameters.AddWithValue("@fr", email);
                    if (title.Text != "")
                    {
                        command1.Parameters.AddWithValue("@title", title.Text);
                    }
                    else
                    {
                        command1.Parameters.AddWithValue("@title", "không có chủ đề");
                    }
                    if (context != null)
                    {
                        command1.Parameters.AddWithValue("@context", context.Text);
                    }
                    else
                    {
                        command1.Parameters.AddWithValue("@context", "Null");
                    }
                    command1.Parameters.AddWithValue("@t", part);
                    if (img_path != null)
                    {
                        command1.Parameters.AddWithValue("@img", img_path);
                    }
                    else
                    {
                        command1.Parameters.AddWithValue("@img", "Null");
                    }
                    if (file_path != null)
                    {
                        command1.Parameters.AddWithValue("@dcm", file_path);
                    }
                    else
                    {
                        command1.Parameters.AddWithValue("@dcm", "Null");
                    }
                    command1.ExecuteNonQuery();
                    conn.Close();

                }
                conn.Close();



            }

            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void context_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.bmp;*.jpg;*.png)|*.bmp;*.jpg;*.png|All files (*.*)|*.*";

            // Hiển thị hộp thoại mở tệp
            DialogResult result = openFileDialog.ShowDialog();

            // Kiểm tra xem người dùng đã chọn một tệp hay không
            if (result == DialogResult.OK)
            {
                // Lấy đường dẫn tệp đã chọn
                string selectedImagePath = openFileDialog.FileName;

                // Đoạn mã tiếp theo ở đây: làm bất cứ điều gì bạn muốn với đường dẫn đã chọn.
                // Ví dụ, bạn có thể hiển thị nó trong một TextBox, gán nó cho một biến, hoặc làm bất kỳ xử lý nào khác.

                // Hiển thị đường dẫn trong một TextBox, ví dụ:
                img_path = selectedImagePath;
            }
            pictureBox1.Image = Image.FromFile(img_path);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "All files (*.*)|*.*";

            // Hiển thị hộp thoại mở tệp
            DialogResult result = openFileDialog.ShowDialog();

            // Kiểm tra xem người dùng đã chọn một tệp hay không
            if (result == DialogResult.OK)
            {
                // Lấy đường dẫn tệp đã chọn
                string selectedImagePath = openFileDialog.FileName;

                // Đoạn mã tiếp theo ở đây: làm bất cứ điều gì bạn muốn với đường dẫn đã chọn.
                // Ví dụ, bạn có thể hiển thị nó trong một TextBox, gán nó cho một biến, hoặc làm bất kỳ xử lý nào khác.

                // Hiển thị đường dẫn trong một TextBox, ví dụ:
                file_path = selectedImagePath;
            }
            file.Visible = true;
            file.Text = file_path;
        }
    }
}
