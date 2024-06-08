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
    public partial class OpenMessageInfo : UserControl
    {
        int ID;
        string file;
        public OpenMessageInfo(int iD)
        {
            InitializeComponent();
            ID = iD;
        }
        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source = C:\\Users\\Admin\\source\\repos\\DoAn\\DoAn\\bin\\Debug\\db_gmail.accdb");

        private void OpenMessageInfo_Load(object sender, EventArgs e)
        {
            conn.Open();
            OleDbCommand command1 = new OleDbCommand(@"SELECT * From tbl_mess
                                                WHERE [ID] = @id ", conn);
            command1.Parameters.AddWithValue("@id", ID);
            OleDbDataReader reader1 = command1.ExecuteReader();
            if (reader1.Read())
            {
                if (reader1.GetInt16(6) == 1)
                {
                    button1.Image = Properties.Resources.golden_star;
                }
                if (reader1.GetString("context") != "Null")
                {
                    context.Text = reader1.GetString("context");
                }
                else
                {
                    context.Text = "";
                }
                int x = context.Size.Width;
                int y = context.Size.Height;
                flowLayoutPanel2.Size = new Size(1081, y + 15 + 20);
                line.Location = new System.Drawing.Point(0, flowLayoutPanel2.Location.Y + y + 20);
                if (reader1.GetString("image") != "Null")
                {
                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Name = "pictureBox";
                    pictureBox.Size = new System.Drawing.Size(150, 150); // Kích thước của PictureBox
                    pictureBox.Location = new System.Drawing.Point(flowLayoutPanel2.Location.X, flowLayoutPanel2.Location.Y + y + 20); // Vị trí của PictureBox
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage; // Chọn chế độ hiển thị hình ảnh
                    line.Location = new System.Drawing.Point(0, pictureBox.Location.Y + 150 + 15);
                    pictureBox.Image = Image.FromFile(reader1.GetString("image"));
                    this.Controls.Add(pictureBox);
                }
                if (reader1.GetString("document") != "Null")
                {
                    label1.Visible = true;
                    label1.Text = reader1.GetString("document");
                    file = reader1.GetString("document");
                }
                date.Text = reader1.GetDateTime(4).ToString("HH:mm dd 'thg' MM',' yyyy");
                string emailF = reader1.GetString("from");
                addr.Text = emailF;
                OleDbCommand command2 = new OleDbCommand(@"SELECT * From tbl_users
                                                WHERE email = @id ", conn);
                command2.Parameters.AddWithValue("@id", emailF);
                OleDbDataReader reader2 = command2.ExecuteReader();
                if (reader2.Read())
                {
                    name.Text = reader2.GetString("username");
                    string img = reader2.GetString("avt");
                    pictureBox1.Image = Image.FromFile(img);
                }
            }

            conn.Close();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            FlowLayoutPanel parentFlowLayoutPanel = this.Parent as FlowLayoutPanel;
            parentFlowLayoutPanel.Controls.Remove(this);
            conn.Open();
            OleDbCommand command1 = new OleDbCommand(@"SELECT * From tbl_mess
                                                WHERE [ID] = @id ", conn);
            command1.Parameters.AddWithValue("@id", ID);
            OleDbDataReader reader1 = command1.ExecuteReader();
            if (reader1.Read())
            {
                OleDbCommand command2 = new OleDbCommand(@"DELETE from tbl_mess
                                                      WHERE [ID] = @id", conn);
                command2.Parameters.AddWithValue("@id", ID);
                command2.ExecuteNonQuery();
            }
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            OleDbCommand command1 = new OleDbCommand(@"SELECT * From tbl_mess
                                                WHERE [ID] = @id ", conn);
            command1.Parameters.AddWithValue("@id", ID);
            OleDbDataReader reader1 = command1.ExecuteReader();
            if (reader1.Read())
            {
                if (reader1.GetInt16(6) == 1)
                {
                    button1.Image = Properties.Resources.star;
                    OleDbCommand command2 = new OleDbCommand(@"UPDATE tbl_mess
                                                    SET star = 0
                                                    WHERE [ID] = @CID", conn);
                    command2.Parameters.AddWithValue("@CID", ID);
                    command2.ExecuteNonQuery();
                }
                if (reader1.GetInt16(6) == 0)
                {
                    button1.Image = Properties.Resources.golden_star;
                    OleDbCommand command2 = new OleDbCommand(@"UPDATE tbl_mess
                                                    SET star = 1
                                                    WHERE [ID] = @CID", conn);
                    command2.Parameters.AddWithValue("@CID", ID);
                    command2.ExecuteNonQuery();
                }
            }
            conn.Close();

        }

        private void date_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void context_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {
            string fileName = file; var process = new System.Diagnostics.Process();

            process.StartInfo = new System.Diagnostics.ProcessStartInfo() { UseShellExecute = true, FileName = fileName };

            process.Start();
        }
    }
}
