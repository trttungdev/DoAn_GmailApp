using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using System.Xml.Linq;

namespace DoAn
{
    public partial class RegForm : Form
    {
        public RegForm()
        {
            InitializeComponent();
        }
        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source = C:\\Users\\Admin\\source\\repos\\DoAn\\DoAn\\bin\\Debug\\db_gmail.accdb");
        OleDbCommand cmd = new OleDbCommand();
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                password.PasswordChar = '\0';
                textBox1.PasswordChar = '\0';
            }
            else
            {
                password.PasswordChar = '*';
                textBox1.PasswordChar = '*';
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (email.Text == "" && username.Text == "" && password.Text == "" && textBox1.Text == "" && phone.Text == "")
            {
                MessageBox.Show("Chưa nhập đầy đủ thông tin", "Đăng kí thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (password.Text == textBox1.Text)
            {
                conn.Open();
                string register = "INSERT INTO tbl_users ([email],[password],[username],[phone]) VALUES ('" + email.Text + "','" + password.Text + "','" + username.Text + "', '" + phone.Text + "')"; 
                cmd = new OleDbCommand(register, conn); cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Tài khoản đã được đăng kí thành công", "Đăng kí thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                username.Text = "";
                password.Text = "";
                email.Text = "";
                textBox1.Text = "";
                phone.Text = "";
            }
            else
            {
                MessageBox.Show("Mật khẩu không trùng nhau", "Đăng kí thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                password.Text = "";
                textBox1.Text = "";
                password.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new SignForm().Show();
            this.Hide();
        }
    }
}
