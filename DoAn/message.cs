using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace DoAn
{
    public partial class message : UserControl
    {
        string email;
        int ID;
        string ten;
        string tua_de;
        string context;
        string time;
        string from;
        string to;
        List<int> danhSachID = new List<int>();
        MainForm mainForm;
        
        public message(string email, string tua_de, string context, string time, string ten, int ID, string from, string to, List<int> danhSachID, MainForm mainForm)
        {
            InitializeComponent();
            this.context = context;
            this.time = time;
            this.ten = ten;
            this.ID = ID;
            this.tua_de = tua_de;
            this.from = from;
            this.to = to;
            this.danhSachID = danhSachID;
            this.email = email;
            this.mainForm = mainForm;
        }
        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source = C:\\Users\\Admin\\source\\repos\\DoAn\\DoAn\\bin\\Debug\\db_gmail.accdb");

        private void message_Load(object sender, EventArgs e)
        {
            name.Text = ten;
            Title.Text = tua_de;
            date.Text = time;
            NoiDung.Text = context;
            conn.Open();
            danhSachID.Sort((a, b) => b.CompareTo(a));
            foreach (int ID in danhSachID)
            {
                OleDbCommand command1 = new OleDbCommand(@"SELECT * From tbl_mess
                                                WHERE [ID] = @id ", conn);
                command1.Parameters.AddWithValue("@id", ID);
                OleDbDataReader reader1 = command1.ExecuteReader();
                if (reader1.Read())
                {
                    if (reader1.GetInt16(6) == 1)
                    {
                        button1.Image = Properties.Resources.golden_star;
                        break;
                    }
                }
            }
            OleDbCommand command = new OleDbCommand(@"SELECT * From tbl_mess
                                                WHERE [ID] = @id ", conn);
            command.Parameters.AddWithValue("@id", ID);
            OleDbDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {

                if (reader.GetInt16(5) == 1)
                {
                    button2.Image = Properties.Resources.unseen;
                    this.BackColor = Color.FromArgb(242, 246, 252);
                    name.ForeColor = Color.Black;
                    name.Font = new Font(name.Font, FontStyle.Regular);
                    Title.Font = new Font(Title.Font, FontStyle.Regular);
                    date.Font = new Font(date.Font, FontStyle.Regular);
                }
                if (reader.GetInt16(5) == 0)
                {
                    button2.Image = Properties.Resources.seen;
                    this.BackColor = Color.White;
                    name.ForeColor = Color.Black;
                    name.Font = new Font(name.Font, FontStyle.Bold);
                    Title.Font = new Font(Title.Font, FontStyle.Bold);
                    date.Font = new Font(date.Font, FontStyle.Bold);
                }
            }
            conn.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            bool is_star1 = false;
            bool is_star2 = false;
            conn.Open();
            for (int i = 0; i < danhSachID.Count; i++)
            {
                OleDbCommand command1 = new OleDbCommand(@"SELECT * From tbl_mess
                                                WHERE [ID] = @id ", conn);
                command1.Parameters.AddWithValue("@id", danhSachID[i]);
                OleDbDataReader reader1 = command1.ExecuteReader();
                if (reader1.Read())
                {
                    if (reader1.GetInt16(6) == 1)
                    {
                        is_star1 = true;
                        OleDbCommand command2 = new OleDbCommand(@"UPDATE tbl_mess
                                                    SET star = 0
                                                    WHERE [ID] = @CID", conn);
                        command2.Parameters.AddWithValue("@CID", danhSachID[i]);
                        command2.ExecuteNonQuery();
                        for (int j = i + 1; j < danhSachID.Count; j++)
                        {
                            OleDbCommand command3 = new OleDbCommand(@"SELECT * From tbl_mess
                                                WHERE [ID] = @id ", conn);
                            command3.Parameters.AddWithValue("@id", danhSachID[j]);
                            OleDbDataReader reader3 = command3.ExecuteReader();
                            if (reader3.Read())
                            {
                                if (reader3.GetInt16(6) == 1)
                                {
                                    is_star2 = true;
                                    button1.Image = Properties.Resources.golden_star;
                                    break;
                                }

                            }
                        }
                        if (is_star2 == false)
                        {
                            button1.Image = Properties.Resources.star;
                        }
                        break;
                    }

                }
            }
            if (is_star1 == false)
            {
                button1.Image = Properties.Resources.golden_star;
                OleDbCommand command4 = new OleDbCommand(@"UPDATE tbl_mess
                                                    SET star = 1
                                                    WHERE [ID] = @CID", conn);
                command4.Parameters.AddWithValue("@CID", danhSachID[0]);
                command4.ExecuteNonQuery();
            }

            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            conn.Open();
            OleDbCommand command = new OleDbCommand(@"SELECT * From tbl_mess
                                                        WHERE title = @title AND 
                                                      ((from = @fr AND to = @t) 
                                                      OR (from = @t AND to = @fr))", conn);
            command.Parameters.AddWithValue("@title", tua_de);
            command.Parameters.AddWithValue("@fr", from);
            command.Parameters.AddWithValue("@t", to);
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (reader.GetInt16(5) == 1)
                {
                    button2.Image = Properties.Resources.seen;
                    this.BackColor = Color.White;
                    name.Font = new Font(name.Font, FontStyle.Bold);
                    Title.Font = new Font(Title.Font, FontStyle.Bold);
                    date.Font = new Font(date.Font, FontStyle.Bold);
                    OleDbCommand command1 = new OleDbCommand(@"UPDATE tbl_mess
                                                    SET seen = 0
                                                     WHERE title = @title AND 
                                                      ((from = @fr AND to = @t) 
                                                      OR (from = @t AND to = @fr))", conn);
                    command1.Parameters.AddWithValue("@title", tua_de);
                    command1.Parameters.AddWithValue("@fr", from);
                    command1.Parameters.AddWithValue("@t", to);
                    command1.ExecuteNonQuery();
                    break;
                }
                else
                {
                    button2.Image = Properties.Resources.unseen;
                    this.BackColor = Color.FromArgb(242, 246, 252);
                    name.Font = new Font(name.Font, FontStyle.Regular);
                    Title.Font = new Font(Title.Font, FontStyle.Regular);
                    date.Font = new Font(date.Font, FontStyle.Regular);
                    OleDbCommand command1 = new OleDbCommand(@"UPDATE tbl_mess
                                                    SET seen = 1
                                                     WHERE title = @title AND 
                                                      ((from = @fr AND to = @t) 
                                                      OR (from = @t AND to = @fr))", conn);
                    command1.Parameters.AddWithValue("@title", tua_de);
                    command1.Parameters.AddWithValue("@fr", from);
                    command1.Parameters.AddWithValue("@t", to);
                    command1.ExecuteNonQuery();
                    break;
                }
            }
            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var panel = this.Parent as FlowLayoutPanel;
            panel.Controls.Remove(this);
            conn.Open();
            OleDbCommand command = new OleDbCommand(@"SELECT * From tbl_mess
                                                        WHERE title = @title AND 
                                                      ((from = @fr AND to = @t) 
                                                      OR (from = @t AND to = @fr))", conn);
            command.Parameters.AddWithValue("@title", tua_de);
            command.Parameters.AddWithValue("@fr", from);
            command.Parameters.AddWithValue("@t", to);
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                if (reader.GetInt16(7) == 1)
                {
                    OleDbCommand command1 = new OleDbCommand(@"DELETE from tbl_mess
                                                     WHERE title = @title AND 
                                                      ((from = @fr AND to = @t) 
                                                      OR (from = @t AND to = @fr))", conn);
                    command1.Parameters.AddWithValue("@title", tua_de);
                    command1.Parameters.AddWithValue("@fr", from);
                    command1.Parameters.AddWithValue("@t", to);
                    command1.ExecuteNonQuery();
                    break;
                }
                else
                {
                    OleDbCommand command1 = new OleDbCommand(@"UPDATE tbl_mess
                                                        SET bin = 1
                                                     WHERE title = @title AND 
                                                      ((from = @fr AND to = @t) 
                                                      OR (from = @t AND to = @fr))", conn);
                    command1.Parameters.AddWithValue("@title", tua_de);
                    command1.Parameters.AddWithValue("@fr", from);
                    command1.Parameters.AddWithValue("@t", to);
                    command1.ExecuteNonQuery();
                    break;
                }
            }
            conn.Close();

        }

        private void NoiDung_Click(object sender, EventArgs e)
        {
            mainForm.pictureBox1.Visible = false;
            mainForm.searchBox.Visible = false;
            conn.Open();
            OleDbCommand command = new OleDbCommand(@"SELECT * From tbl_mess
                                                WHERE [ID] = @id ", conn);
            command.Parameters.AddWithValue("@id", ID);
            OleDbDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                if (reader.GetInt16("draft")==1)
                {
                    MessForm2 mess = new MessForm2(ID,email,reader.GetString("image"));
                    mess.To.Text = reader.GetString("to");
                    if (reader.GetString("title")=="không có chủ đề")
                    {
                        mess.title.Text = "";
                    }
                    else
                    {
                        mess.title.Text=reader.GetString("title");
                    }
                    if (reader.GetString("context") == "Null")
                    {
                        mess.context.Text = "";
                    }
                    else
                    {
                        mess.context.Text = reader.GetString("context");
                    }
                    if (reader.GetString("image") != "Null")
                    {
                        mess.pictureBox1.Image = Image.FromFile(reader.GetString("image"));
                    }
                    mess.Show();
                    conn.Close();

                }
                else
                {
                    var panel = this.Parent as FlowLayoutPanel;
                    panel.Controls.Clear();
                    OpenMessage uc = new OpenMessage(danhSachID, email, mainForm);
                    panel.Controls.Add(uc);
                    
                    foreach (int ID in danhSachID)
                    {
                        OleDbCommand command1 = new OleDbCommand(@"UPDATE tbl_mess
                                                    SET seen = 1
                                                     WHERE [ID] = @id", conn);
                        command1.Parameters.AddWithValue("@id", ID);
                        command1.ExecuteNonQuery();
                    }
                    conn.Close();
                }
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void name_Click(object sender, EventArgs e)
        {
            mainForm.pictureBox1.Visible = false;
            mainForm.searchBox.Visible = false;
            conn.Open();
            OleDbCommand command = new OleDbCommand(@"SELECT * From tbl_mess
                                                WHERE [ID] = @id ", conn);
            command.Parameters.AddWithValue("@id", ID);
            OleDbDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                if (reader.GetInt16("draft") == 1)
                {
                    MessForm2 mess = new MessForm2(ID, email, reader.GetString("image"));
                    mess.To.Text = reader.GetString("to");
                    if (reader.GetString("title") == "không có chủ đề")
                    {
                        mess.title.Text = "";
                    }
                    else
                    {
                        mess.title.Text = reader.GetString("title");
                    }
                    if (reader.GetString("context") == "Null")
                    {
                        mess.context.Text = "";
                    }
                    else
                    {
                        mess.context.Text = reader.GetString("context");
                    }
                    if (reader.GetString("image") != "Null")
                    {
                        mess.pictureBox1.Image = Image.FromFile(reader.GetString("image"));
                    }
                    mess.Show();
                    conn.Close();

                }
                else
                {
                    var panel = this.Parent as FlowLayoutPanel;
                    panel.Controls.Clear();
                    OpenMessage uc = new OpenMessage(danhSachID, email, mainForm);
                    panel.Controls.Add(uc);

                    foreach (int ID in danhSachID)
                    {
                        OleDbCommand command1 = new OleDbCommand(@"UPDATE tbl_mess
                                                    SET seen = 1
                                                     WHERE [ID] = @id", conn);
                        command1.Parameters.AddWithValue("@id", ID);
                        command1.ExecuteNonQuery();
                    }
                    conn.Close();
                }
            }
        }

        private void message_Click(object sender, EventArgs e)
        {

        }

        private void message_MouseClick(object sender, MouseEventArgs e)
        {
            mainForm.pictureBox1.Visible = false;
            mainForm.searchBox.Visible = false;
            conn.Open();
            OleDbCommand command = new OleDbCommand(@"SELECT * From tbl_mess
                                                WHERE [ID] = @id ", conn);
            command.Parameters.AddWithValue("@id", ID);
            OleDbDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                if (reader.GetInt16("draft") == 1)
                {
                    MessForm2 mess = new MessForm2(ID, email, reader.GetString("image"));
                    mess.To.Text = reader.GetString("to");
                    if (reader.GetString("title") == "không có chủ đề")
                    {
                        mess.title.Text = "";
                    }
                    else
                    {
                        mess.title.Text = reader.GetString("title");
                    }
                    if (reader.GetString("context") == "Null")
                    {
                        mess.context.Text = "";
                    }
                    else
                    {
                        mess.context.Text = reader.GetString("context");
                    }
                    if (reader.GetString("image") != "Null")
                    {
                        mess.pictureBox1.Image = Image.FromFile(reader.GetString("image"));
                    }
                    mess.Show();
                    conn.Close();

                }
                else
                {
                    var panel = this.Parent as FlowLayoutPanel;
                    panel.Controls.Clear();
                    OpenMessage uc = new OpenMessage(danhSachID, email, mainForm);
                    panel.Controls.Add(uc);

                    foreach (int ID in danhSachID)
                    {
                        OleDbCommand command1 = new OleDbCommand(@"UPDATE tbl_mess
                                                    SET seen = 1
                                                     WHERE [ID] = @id", conn);
                        command1.Parameters.AddWithValue("@id", ID);
                        command1.ExecuteNonQuery();
                    }
                    conn.Close();
                }
            }
        }

        private void date_Click(object sender, EventArgs e)
        {
            mainForm.pictureBox1.Visible = false;
            mainForm.searchBox.Visible = false;
            conn.Open();
            OleDbCommand command = new OleDbCommand(@"SELECT * From tbl_mess
                                                WHERE [ID] = @id ", conn);
            command.Parameters.AddWithValue("@id", ID);
            OleDbDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                if (reader.GetInt16("draft") == 1)
                {
                    MessForm2 mess = new MessForm2(ID, email, reader.GetString("image"));
                    mess.To.Text = reader.GetString("to");
                    if (reader.GetString("title") == "không có chủ đề")
                    {
                        mess.title.Text = "";
                    }
                    else
                    {
                        mess.title.Text = reader.GetString("title");
                    }
                    if (reader.GetString("context") == "Null")
                    {
                        mess.context.Text = "";
                    }
                    else
                    {
                        mess.context.Text = reader.GetString("context");
                    }
                    if (reader.GetString("image") != "Null")
                    {
                        mess.pictureBox1.Image = Image.FromFile(reader.GetString("image"));
                    }
                    mess.Show();
                    conn.Close();

                }
                else
                {
                    var panel = this.Parent as FlowLayoutPanel;
                    panel.Controls.Clear();
                    OpenMessage uc = new OpenMessage(danhSachID, email, mainForm);
                    panel.Controls.Add(uc);

                    foreach (int ID in danhSachID)
                    {
                        OleDbCommand command1 = new OleDbCommand(@"UPDATE tbl_mess
                                                    SET seen = 1
                                                     WHERE [ID] = @id", conn);
                        command1.Parameters.AddWithValue("@id", ID);
                        command1.ExecuteNonQuery();
                    }
                    conn.Close();
                }
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel1_Click(object sender, EventArgs e)
        {
            mainForm.pictureBox1.Visible = false;
            mainForm.searchBox.Visible = false;
            conn.Open();
            OleDbCommand command = new OleDbCommand(@"SELECT * From tbl_mess
                                                WHERE [ID] = @id ", conn);
            command.Parameters.AddWithValue("@id", ID);
            OleDbDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                if (reader.GetInt16("draft") == 1)
                {
                    MessForm2 mess = new MessForm2(ID, email, reader.GetString("image"));
                    mess.To.Text = reader.GetString("to");
                    if (reader.GetString("title") == "không có chủ đề")
                    {
                        mess.title.Text = "";
                    }
                    else
                    {
                        mess.title.Text = reader.GetString("title");
                    }
                    if (reader.GetString("context") == "Null")
                    {
                        mess.context.Text = "";
                    }
                    else
                    {
                        mess.context.Text = reader.GetString("context");
                    }
                    if (reader.GetString("image") != "Null")
                    {
                        mess.pictureBox1.Image = Image.FromFile(reader.GetString("image"));
                    }
                    mess.Show();
                    conn.Close();

                }
                else
                {
                    var panel = this.Parent as FlowLayoutPanel;
                    panel.Controls.Clear();
                    OpenMessage uc = new OpenMessage(danhSachID, email, mainForm);
                    panel.Controls.Add(uc);

                    foreach (int ID in danhSachID)
                    {
                        OleDbCommand command1 = new OleDbCommand(@"UPDATE tbl_mess
                                                    SET seen = 1
                                                     WHERE [ID] = @id", conn);
                        command1.Parameters.AddWithValue("@id", ID);
                        command1.ExecuteNonQuery();
                    }
                    conn.Close();
                }
            }
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel2_Click(object sender, EventArgs e)
        {
            mainForm.pictureBox1.Visible = false;
            mainForm.searchBox.Visible = false;
            conn.Open();
            OleDbCommand command = new OleDbCommand(@"SELECT * From tbl_mess
                                                WHERE [ID] = @id ", conn);
            command.Parameters.AddWithValue("@id", ID);
            OleDbDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                if (reader.GetInt16("draft") == 1)
                {
                    MessForm2 mess = new MessForm2(ID, email, reader.GetString("image"));
                    mess.To.Text = reader.GetString("to");
                    if (reader.GetString("title") == "không có chủ đề")
                    {
                        mess.title.Text = "";
                    }
                    else
                    {
                        mess.title.Text = reader.GetString("title");
                    }
                    if (reader.GetString("context") == "Null")
                    {
                        mess.context.Text = "";
                    }
                    else
                    {
                        mess.context.Text = reader.GetString("context");
                    }
                    if (reader.GetString("image") != "Null")
                    {
                        mess.pictureBox1.Image = Image.FromFile(reader.GetString("image"));
                    }
                    mess.Show();
                    conn.Close();

                }
                else
                {
                    var panel = this.Parent as FlowLayoutPanel;
                    panel.Controls.Clear();
                    OpenMessage uc = new OpenMessage(danhSachID, email, mainForm);
                    panel.Controls.Add(uc);

                    foreach (int ID in danhSachID)
                    {
                        OleDbCommand command1 = new OleDbCommand(@"UPDATE tbl_mess
                                                    SET seen = 1
                                                     WHERE [ID] = @id", conn);
                        command1.Parameters.AddWithValue("@id", ID);
                        command1.ExecuteNonQuery();
                    }
                    conn.Close();
                }
            }
        }

        private void number_Click(object sender, EventArgs e)
        {
            mainForm.pictureBox1.Visible = false;
            mainForm.searchBox.Visible = false;
            conn.Open();
            OleDbCommand command = new OleDbCommand(@"SELECT * From tbl_mess
                                                WHERE [ID] = @id ", conn);
            command.Parameters.AddWithValue("@id", ID);
            OleDbDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                if (reader.GetInt16("draft") == 1)
                {
                    MessForm2 mess = new MessForm2(ID, email, reader.GetString("image"));
                    mess.To.Text = reader.GetString("to");
                    if (reader.GetString("title") == "không có chủ đề")
                    {
                        mess.title.Text = "";
                    }
                    else
                    {
                        mess.title.Text = reader.GetString("title");
                    }
                    if (reader.GetString("context") == "Null")
                    {
                        mess.context.Text = "";
                    }
                    else
                    {
                        mess.context.Text = reader.GetString("context");
                    }
                    if (reader.GetString("image") != "Null")
                    {
                        mess.pictureBox1.Image = Image.FromFile(reader.GetString("image"));
                    }
                    mess.Show();
                    conn.Close();

                }
                else
                {
                    var panel = this.Parent as FlowLayoutPanel;
                    panel.Controls.Clear();
                    OpenMessage uc = new OpenMessage(danhSachID, email, mainForm);
                    panel.Controls.Add(uc);

                    foreach (int ID in danhSachID)
                    {
                        OleDbCommand command1 = new OleDbCommand(@"UPDATE tbl_mess
                                                    SET seen = 1
                                                     WHERE [ID] = @id", conn);
                        command1.Parameters.AddWithValue("@id", ID);
                        command1.ExecuteNonQuery();
                    }
                    conn.Close();
                }
            }
        }

        private void NoiDung_Click_1(object sender, EventArgs e)
        {
            mainForm.pictureBox1.Visible = false;
            mainForm.searchBox.Visible = false;
            conn.Open();
            OleDbCommand command = new OleDbCommand(@"SELECT * From tbl_mess
                                                WHERE [ID] = @id ", conn);
            command.Parameters.AddWithValue("@id", ID);
            OleDbDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                if (reader.GetInt16("draft") == 1)
                {
                    MessForm2 mess = new MessForm2(ID, email, reader.GetString("image"));
                    mess.To.Text = reader.GetString("to");
                    if (reader.GetString("title") == "không có chủ đề")
                    {
                        mess.title.Text = "";
                    }
                    else
                    {
                        mess.title.Text = reader.GetString("title");
                    }
                    if (reader.GetString("context") == "Null")
                    {
                        mess.context.Text = "";
                    }
                    else
                    {
                        mess.context.Text = reader.GetString("context");
                    }
                    if (reader.GetString("image") != "Null")
                    {
                        mess.pictureBox1.Image = Image.FromFile(reader.GetString("image"));
                    }
                    mess.Show();
                    conn.Close();

                }
                else
                {
                    var panel = this.Parent as FlowLayoutPanel;
                    panel.Controls.Clear();
                    OpenMessage uc = new OpenMessage(danhSachID, email, mainForm);
                    panel.Controls.Add(uc);

                    foreach (int ID in danhSachID)
                    {
                        OleDbCommand command1 = new OleDbCommand(@"UPDATE tbl_mess
                                                    SET seen = 1
                                                     WHERE [ID] = @id", conn);
                        command1.Parameters.AddWithValue("@id", ID);
                        command1.ExecuteNonQuery();
                    }
                    conn.Close();
                }
            }
        }
    }
}
