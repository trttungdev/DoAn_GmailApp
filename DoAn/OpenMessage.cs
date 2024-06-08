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

namespace DoAn
{
    public partial class OpenMessage : UserControl
    {
        List<int> danhSachID = new List<int>();
        string email;
        MainForm mainForm;
        public OpenMessage(List<int> danhsachID, string email, MainForm mainForm)
        {
            InitializeComponent();
            this.danhSachID = danhsachID;
            this.email = email;
            this.mainForm = mainForm;
        }
        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source = C:\\Users\\Admin\\source\\repos\\DoAn\\DoAn\\bin\\Debug\\db_gmail.accdb");

        public void OpenMessage_Load(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            danhSachID.Reverse();
            conn.Open();
            OleDbCommand command = new OleDbCommand(@"SELECT * From tbl_mess
                                                WHERE [ID] = @id ", conn);
            command.Parameters.AddWithValue("@id", danhSachID[0]);
            OleDbDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                title.Text = reader["title"].ToString();
            }
            foreach (int ID in danhSachID)
            {
                OpenMessageInfo uc = new OpenMessageInfo(ID);
                flowLayoutPanel1.Controls.Add(uc);
            }
            conn.Close();
            Button dynamicButton = new Button();
            dynamicButton.Text = "Trả lời";
            dynamicButton.Size = new Size(200, 50);
            dynamicButton.BackColor = Color.White;
            dynamicButton.Click += DynamicButton_Click;

            // Thêm Button vào UserControl
            flowLayoutPanel1.Controls.Add(dynamicButton);
        }
        private void DynamicButton_Click(object sender, EventArgs e)
        {

            string to;
            conn.Open();
            foreach (int ID in danhSachID)
            {
                OleDbCommand command = new OleDbCommand(@"SELECT * From tbl_mess
                                                WHERE [ID] = @id ", conn);
                command.Parameters.AddWithValue("@id", ID);
                OleDbDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    if (reader.GetString("from") != email)
                    {
                        to = reader.GetString("from");
                        TraLoi uc1 = new TraLoi(email, to,title.Text,this);
                        flowLayoutPanel1.Controls.Add(uc1);
                        break;
                    }
                    if (reader.GetString("to") != email)
                    {
                        to = reader.GetString("to");
                        TraLoi uc1 = new TraLoi(email, to, title.Text,this);
                        flowLayoutPanel1.Controls.Add(uc1);
                        break;
                    }
                    TraLoi uc = new TraLoi(email, email, title.Text,this);
                    flowLayoutPanel1.Controls.Add(uc);
                }
            }
            conn.Close();



        }

        private void button4_Click(object sender, EventArgs e)
        {
            conn.Open();
            foreach (int ID in danhSachID)
            {
                OleDbCommand command1 = new OleDbCommand(@"UPDATE tbl_mess
                                                        SET bin = 1
                                                     WHERE [ID] = @id", conn);
                command1.Parameters.AddWithValue("@id", ID);
                command1.ExecuteNonQuery();
            }
            mainForm.YourMethod();



        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            conn.Open();
            foreach (int ID in danhSachID)
            {
                OleDbCommand command1 = new OleDbCommand(@"UPDATE tbl_mess
                                                    SET seen = 0
                                                     WHERE [ID] = @id", conn);
                command1.Parameters.AddWithValue("@id", ID);
                command1.ExecuteNonQuery();
            }
            conn.Close();
            mainForm.YourMethod();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mainForm.YourMethod();
        }
    }
}
