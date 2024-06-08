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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DoAn
{
    public partial class account : UserControl
    {
        string input;
        string path;
        public account(string input)
        {
            InitializeComponent();
            this.input = input;
        }
        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source = C:\\Users\\Admin\\source\\repos\\DoAn\\DoAn\\bin\\Debug\\db_gmail.accdb");


        private void account_Load(object sender, EventArgs e)
        {
            LoadUserData();
        }
        private void LoadUserData()
        {
            conn.Open();
            OleDbCommand cmd = new OleDbCommand("SELECT * From tbl_users WHERE email = @email", conn);
            cmd.Parameters.AddWithValue("@email", input);
            OleDbDataReader reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                phone.Text = reader["phone"].ToString();
                name.Text = reader["username"].ToString();
                email.Text = reader["email"].ToString();
                string img = reader.GetString("avt");
                pictureBox1.Image = Image.FromFile(img);
            }

            conn.Close(); // Đóng kết nối sau khi hoàn thành công việc
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            string login = "SELECT * from tbl_users WHERE email = '" + input + "'and password = '" + old_pass.Text + "'";
            OleDbCommand cmd = new OleDbCommand(login, conn);
            OleDbDataReader dr = cmd.ExecuteReader();

            if (dr.Read() == true)
            {
                if (new_pass.Text != con_pass.Text)
                {
                    MessageBox.Show("Không thành công", "Hai mật khẩu không trùng nhau", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    OleDbCommand command = new OleDbCommand(@"UPDATE tbl_users
                                                    SET [password] = @pass
                                                    WHERE email = @CID", conn);

                    command.Parameters.AddWithValue("@pass", new_pass.Text);
                    command.Parameters.AddWithValue("@CID", email.Text);
                    command.ExecuteNonQuery();
                    conn.Close();
                    MessageBox.Show("Thay đổi thành công", "Change success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    old_pass.Text = "";
                    new_pass.Text = "";
                    con_pass.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Không hợp lệ", "Sai mật khẩu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                old_pass.Text = "";
                new_pass.Text = "";
                con_pass.Text = "";
            }
            conn.Close ();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form parent = this.FindForm();
            parent.Close();
            new SignForm().Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
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
                path = selectedImagePath;
            }
            conn.Open();
            if (path != null)
            {
                OleDbCommand command = new OleDbCommand(@"UPDATE tbl_users
                                                    SET  avt = @a
                                                    WHERE email = @CID", conn);

                command.Parameters.AddWithValue("@a", path);
                command.Parameters.AddWithValue("@CID", input);
                command.ExecuteNonQuery();
            }
            conn.Close();
            LoadUserData();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                old_pass.PasswordChar = '\0';
                new_pass.PasswordChar = '\0';
                con_pass.PasswordChar = '\0';
            }
            else
            {
                old_pass.PasswordChar = '*';
                new_pass.PasswordChar = '*';
                con_pass.PasswordChar = '*';
            }
        }
    }
}
