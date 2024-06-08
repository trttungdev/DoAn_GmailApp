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
using System.Xml.Linq;

namespace DoAn
{
    public partial class TraLoi : UserControl
    {
        string email;
        string to;
        string title;
        string path;
        OpenMessage uc;
        public TraLoi(string email, string to, string title, OpenMessage uc)
        {
            InitializeComponent();
            this.email = email;
            this.to = to;
            this.title = title;
            this.uc = uc;
        }
        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source = C:\\Users\\Admin\\source\\repos\\DoAn\\DoAn\\bin\\Debug\\db_gmail.accdb");

        private void context_TextChanged(object sender, EventArgs e)
        {

        }

        private void TraLoi_Load(object sender, EventArgs e)
        {
            conn.Open();
            OleDbCommand cmd = new OleDbCommand("SELECT * From tbl_users WHERE email = @email", conn);
            cmd.Parameters.AddWithValue("@email", email);
            OleDbDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                emailTo.Text = to;
                string img = reader.GetString("avt");
                pictureBox1.Image = Image.FromFile(img);
            }
            conn.Close();
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
                path = selectedImagePath;
            }
            pictureBox2.Image = Image.FromFile(path);
        }

        private void SoanThu_Click(object sender, EventArgs e)
        {
            conn.Open();
            string login = "SELECT * from tbl_users WHERE email = '" + emailTo.Text + "'";
            OleDbCommand cmd = new OleDbCommand(login, conn);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read() == true)
            {
                OleDbCommand command1 = new OleDbCommand(@"INSERT INTO tbl_mess ([from],[title],[context],[to],[image]) 
                                                            VALUES 
                                                            (@fr,@title,@context,@t,@img)", conn);
                command1.Parameters.AddWithValue("@fr", email);

                command1.Parameters.AddWithValue("@title", title);



                if (context != null)
                {
                    command1.Parameters.AddWithValue("@context", context.Text);
                }
                else
                {
                    command1.Parameters.AddWithValue("@context", "Null");
                }
                command1.Parameters.AddWithValue("@t", emailTo.Text);
                if (path != null)
                {
                    command1.Parameters.AddWithValue("@img", path);
                }
                else
                {
                    command1.Parameters.AddWithValue("@img", "Null");
                }
                command1.ExecuteNonQuery();
                conn.Close();
                FlowLayoutPanel parentFlowLayoutPanel = this.Parent as FlowLayoutPanel;
                parentFlowLayoutPanel.Controls.Remove(this);
                uc.OpenMessage_Load(sender, e);
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
