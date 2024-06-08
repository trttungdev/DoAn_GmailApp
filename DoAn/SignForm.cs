using Microsoft.VisualBasic.ApplicationServices;
using System.Data.OleDb;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DoAn
{
    public partial class SignForm : Form
    {
        public SignForm()
        {
            InitializeComponent();
        }
        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source = C:\\Users\\Admin\\source\\repos\\DoAn\\DoAn\\bin\\Debug\\db_gmail.accdb");
        OleDbCommand cmd = new OleDbCommand();

        private void button1_Click(object sender, EventArgs e)
        {
            new RegForm().Show();
            this.Hide();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                password.PasswordChar = '\0';
            }
            else
            {
                password.PasswordChar = '*';
            }
        }

        private void SignForm_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.email != string.Empty)
            {
                email.Text = Properties.Settings.Default.email;
                password.Text = Properties.Settings.Default.password;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            string login = "SELECT * from tbl_users WHERE email = '" + email.Text + "'and password = '" + password.Text + "'";
            cmd = new OleDbCommand(login, conn);
            OleDbDataReader dr = cmd.ExecuteReader();

            if (dr.Read() == true)
            {
                string emai = email.Text;
                new MainForm(emai).Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Không hợp lệ", "Login failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                email.Text = "";
                password.Text = "";
            }
            if (checkBox2.Checked == true)
            {
                Properties.Settings.Default.email = email.Text;
                Properties.Settings.Default.password = password.Text;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.email = "";
                Properties.Settings.Default.password = "";
                Properties.Settings.Default.Save();
            }
        }

        
    }
}