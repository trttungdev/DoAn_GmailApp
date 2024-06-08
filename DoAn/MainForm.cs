using Microsoft.VisualBasic.ApplicationServices;
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
    public partial class MainForm : Form
    {
        public string email;
        private string click;
        public string GetYourVariable()
        {
            return click;
        }
        public MainForm(string email)
        {
            InitializeComponent();
            this.email = email;
        }
        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source = C:\\Users\\Admin\\source\\repos\\DoAn\\DoAn\\bin\\Debug\\db_gmail.accdb");
        public void YourMethod()
        {
            if (click == "receive")
            {
                receive_Click(null, EventArgs.Empty);
            }
            if (click == "star")
            {
                star_Click(null, EventArgs.Empty);
            }
            if (click == "send")
            {
                send_Click(null, EventArgs.Empty);
            }
            if (click == "bin")
            {
                bin_Click(null, EventArgs.Empty);
            }
        }
        public void receive_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            searchBox.Visible = true;
            click = "receive";
            receive.BackColor = Color.FromArgb(211, 227, 253);
            star.BackColor = Color.FromArgb(246, 248, 252);
            send.BackColor = Color.FromArgb(246, 248, 252);
            draft.BackColor = Color.FromArgb(246, 248, 252);
            bin.BackColor = Color.FromArgb(246, 248, 252);
            profile.BackColor = Color.FromArgb(246, 248, 252);
            flowLayoutPanel1.Controls.Clear();
            int x = 0, y = 0;
            conn.Open();
            OleDbCommand command1 = new OleDbCommand(@"SELECT ID, [from], title, context, [time]
                                                    FROM tbl_mess AS T1
                                                    WHERE [time] = (
                                                        SELECT MAX([time])
                                                        FROM tbl_mess AS T2
                                                        WHERE T2.[from] = T1.[from] AND T2.title = T1.title
                                                    )
                                                      AND [to] = @email
                                                      AND bin = 0
                                                      AND draft = 0
                                                    ORDER BY [time] DESC", conn);
            command1.Parameters.AddWithValue("@email", email);
            OleDbDataReader reader1 = command1.ExecuteReader();
            while (reader1.Read())
            {
                string tua_de = reader1.GetString(2);

                string context;
                if (reader1.GetString(3) == "Null")
                {
                    context = "";
                }
                else
                {
                    context = "- " + reader1.GetString(3);
                }

                string time = reader1.GetDateTime(4).ToString("dd 'thg' MM");
                string emailF = reader1.GetString(1);
                int ID = reader1.GetInt32(0);
                string ten;

                OleDbCommand command = new OleDbCommand(@"SELECT * From tbl_mess
                                                WHERE title = @title AND from = @fr AND to = @t AND [ID] > @id", conn);
                command.Parameters.AddWithValue("@title", tua_de);
                command.Parameters.AddWithValue("@fr", email);
                command.Parameters.AddWithValue("@t", emailF);
                command.Parameters.AddWithValue("@id", ID);
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.GetString(3) == "Null")
                    {
                        context = "";
                    }
                    else
                    {
                        context = "- " + reader.GetString(3);
                    }
                    ID = reader.GetInt32(0);
                }

                OleDbCommand command2 = new OleDbCommand(@"SELECT * From tbl_users
                                                WHERE email = @email ", conn);
                command2.Parameters.AddWithValue("@email", emailF);
                OleDbDataReader reader2 = command2.ExecuteReader();
                if (reader2.Read())
                {
                    if (email == emailF)
                    {
                        ten = "Tôi";
                    }
                    else
                    {
                        ten = reader2.GetString(2);

                    }

                    int cnt = 0;
                    List<int> danhSachID = new List<int>();
                    OleDbCommand command3 = new OleDbCommand(@"SELECT * From tbl_mess
                                                WHERE title = @title AND from = @fr AND to = @t", conn);
                    command3.Parameters.AddWithValue("@title", tua_de);
                    command3.Parameters.AddWithValue("@fr", email);
                    command3.Parameters.AddWithValue("@t", emailF);
                    OleDbDataReader reader3 = command3.ExecuteReader();
                    if (reader3.Read() && email != emailF)
                    {
                        ten = ten + ", Tôi";
                    }

                    OleDbCommand command4 = new OleDbCommand(@"SELECT * From tbl_mess
                                                WHERE title = @title AND 
                                                      ((from = @fr AND to = @t) 
                                                      OR (from = @t AND to = @fr))
                                                      AND bin = 0", conn);
                    command4.Parameters.AddWithValue("@title", tua_de);
                    command4.Parameters.AddWithValue("@fr", email);
                    command4.Parameters.AddWithValue("@t", emailF);
                    OleDbDataReader reader4 = command4.ExecuteReader();
                    while (reader4.Read())
                    {
                        cnt += 1;
                        danhSachID.Add(reader4.GetInt32(0));
                    }

                    message uc = new message(email, tua_de, context, time, ten, ID, emailF, email, danhSachID, this);
                    if (cnt > 1)
                    {
                        uc.number.Visible = true;
                        uc.number.Text = cnt.ToString();
                    }
                    flowLayoutPanel1.Controls.Add(uc);

                }

            }
            conn.Close();

        }

        private void star_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            searchBox.Visible = true;
            click = "star";
            receive.BackColor = Color.FromArgb(246, 248, 252);
            star.BackColor = Color.FromArgb(211, 227, 253);
            send.BackColor = Color.FromArgb(246, 248, 252);
            draft.BackColor = Color.FromArgb(246, 248, 252);
            bin.BackColor = Color.FromArgb(246, 248, 252);
            profile.BackColor = Color.FromArgb(246, 248, 252);
            flowLayoutPanel1.Controls.Clear();
            int x = 0, y = 0;
            conn.Open();
            OleDbCommand command1 = new OleDbCommand(@"SELECT *
                                                        FROM tbl_mess AS T1
                                                        WHERE [time] = (
                                                            SELECT MAX([time])
                                                            FROM tbl_mess AS T2
                                                            WHERE 
                                                                ((T2.[from] = T1.[from] AND T2.[to] = T1.[to]) OR (T2.[from] = T1.[to] AND T2.[to] = T1.[from]))
                                                                AND T2.title = T1.title
                                                                AND EXISTS (
                                                                    SELECT 1
                                                                    FROM tbl_mess AS T3
                                                                    WHERE 
                                                                        ((T3.[from] = T1.[from] AND T3.[to] = T1.[to]) OR (T3.[from] = T1.[to] AND T3.[to] = T1.[from]))
                                                                        AND T3.star = 1
                                                                        AND T3.title = T1.title
                                                                )
                                                            )
                                                            AND (T1.[from] = @email OR T1.[to] = @email)
                                                            AND bin = 0
                                                            AND draft = 0
                                                        ORDER BY [time] DESC
                                                        UNION
                                                        SELECT *
                                                        FROM tbl_mess AS T4
                                                        WHERE T4.[from] = @email
                                                            AND draft = 1
                                                            AND star = 1
                                                            AND bin = 0
                                                            ORDER BY [time] DESC", conn);
            command1.Parameters.AddWithValue("@emai", email);
            OleDbDataReader reader1 = command1.ExecuteReader();
            while (reader1.Read())
            {
                string tua_de;
                string context;
                string time;
                int ID;
                string From;
                string To;
                string ten = "";
                List<int> danhSachID = new List<int>();
                if (reader1.GetInt16(10) == 0)
                {
                    tua_de = reader1.GetString(2);
                    if (reader1.GetString(3) == "Null")
                    {
                        context = "";
                    }
                    else
                    {
                        context = "- " + reader1.GetString(3);
                    }
                    time = reader1.GetDateTime(4).ToString("dd 'thg' MM");
                    ID = reader1.GetInt32(0);
                    From = reader1.GetString(1);
                    To = reader1.GetString(9);
                    if (From == To)
                    {
                        int cnt = 0;
                        ten = "Tôi";
                        OleDbCommand command4 = new OleDbCommand(@"SELECT * From tbl_mess
                                                WHERE title = @title AND 
                                                      from = @fr AND to = @t AND bin = 0 ", conn);
                        command4.Parameters.AddWithValue("@title", tua_de);
                        command4.Parameters.AddWithValue("@fr", From);
                        command4.Parameters.AddWithValue("@t", To);
                        OleDbDataReader reader4 = command4.ExecuteReader();
                        while (reader4.Read())
                        {
                            danhSachID.Add(reader4.GetInt32(0));
                            cnt += 1;
                        }
                        message uc = new message(email, tua_de, context, time, ten, ID, From, To, danhSachID, this);
                        uc.button1.Image = Properties.Resources.golden_star;
                        if (cnt > 1)
                        {
                            uc.number.Visible = true;
                            uc.number.Text = cnt.ToString();
                        }
                        flowLayoutPanel1.Controls.Add(uc);
                        uc.Size = new System.Drawing.Size(1237, 49);
                        uc.Location = new System.Drawing.Point(x, y);
                        y += 49;
                    }
                    else
                    {
                        if (From != email)
                        {
                            int cnt = 0;
                            OleDbCommand command2 = new OleDbCommand(@"SELECT * From tbl_users
                                                WHERE email = @email ", conn);
                            command2.Parameters.AddWithValue("@email", From);
                            OleDbDataReader reader2 = command2.ExecuteReader();
                            if (reader2.Read())
                            {
                                ten = reader2.GetString(2);
                            }
                            OleDbCommand command3 = new OleDbCommand(@"SELECT * From tbl_mess
                                                WHERE title = @title AND from = @fr AND to = @t ", conn);
                            command3.Parameters.AddWithValue("@title", tua_de);
                            command3.Parameters.AddWithValue("@fr", From);
                            command3.Parameters.AddWithValue("@t", email);
                            OleDbDataReader reader3 = command3.ExecuteReader();
                            if (reader3.Read())
                            {
                                ten = ten + ", Tôi";
                            }
                            OleDbCommand command4 = new OleDbCommand(@"SELECT * From tbl_mess
                                                WHERE title = @title AND 
                                                      ((from = @fr AND to = @t) 
                                                      OR (from = @t AND to = @fr)) AND bin = 0", conn);
                            command4.Parameters.AddWithValue("@title", tua_de);
                            command4.Parameters.AddWithValue("@fr", From);
                            command4.Parameters.AddWithValue("@t", To);
                            OleDbDataReader reader4 = command4.ExecuteReader();
                            while (reader4.Read())
                            {
                                danhSachID.Add(reader4.GetInt32(0));
                                cnt += 1;
                            }
                            message uc = new message(email, tua_de, context, time, ten, ID, From, To, danhSachID, this);
                            uc.button1.Image = Properties.Resources.golden_star;
                            if (cnt > 1)
                            {
                                uc.number.Visible = true;
                                uc.number.Text = cnt.ToString();
                            }
                            flowLayoutPanel1.Controls.Add(uc);
                            uc.Size = new System.Drawing.Size(1237, 49);
                            uc.Location = new System.Drawing.Point(x, y);
                            y += 49;
                        }
                        if (To != email)
                        {
                            int cnt = 0;
                            OleDbCommand command2 = new OleDbCommand(@"SELECT * From tbl_users
                                                WHERE email = @email ", conn);
                            command2.Parameters.AddWithValue("@email", To);
                            OleDbDataReader reader2 = command2.ExecuteReader();
                            if (reader2.Read())
                            {
                                ten = reader2.GetString(2);
                            }
                            OleDbCommand command3 = new OleDbCommand(@"SELECT * From tbl_mess
                                                WHERE title = @title AND from = @fr AND to = @t ", conn);
                            command3.Parameters.AddWithValue("@title", tua_de);
                            command3.Parameters.AddWithValue("@fr", email);
                            command3.Parameters.AddWithValue("@t", To);
                            OleDbDataReader reader3 = command3.ExecuteReader();
                            if (reader3.Read())
                            {
                                ten = ten + ", Tôi";
                            }
                            else
                            {
                                ten = "Tôi";
                            }
                            OleDbCommand command4 = new OleDbCommand(@"SELECT * From tbl_mess
                                                WHERE title = @title AND 
                                                      ((from = @fr AND to = @t) 
                                                      OR (from = @t AND to = @fr))", conn);
                            command4.Parameters.AddWithValue("@title", tua_de);
                            command4.Parameters.AddWithValue("@fr", From);
                            command4.Parameters.AddWithValue("@t", To);
                            OleDbDataReader reader4 = command4.ExecuteReader();
                            while (reader4.Read())
                            {
                                danhSachID.Add(reader4.GetInt32(0));
                                cnt += 1;
                            }
                            message uc = new message(email, tua_de, context, time, ten, ID, From, To, danhSachID, this);
                            uc.button1.Image = Properties.Resources.golden_star;
                            if (cnt > 1)
                            {
                                uc.number.Visible = true;
                                uc.number.Text = cnt.ToString();
                            }
                            flowLayoutPanel1.Controls.Add(uc);
                            uc.Size = new System.Drawing.Size(1237, 49);
                            uc.Location = new System.Drawing.Point(x, y);
                            y += 49;
                        }
                    }


                }
                if (reader1.GetInt16(10) == 1)
                {
                    tua_de = reader1.GetString(2);

                    if (reader1.GetString(3) == "Null")
                    {
                        context = "";
                    }
                    else
                    {
                        context = "- " + reader1.GetString(3);
                    }
                    time = reader1.GetDateTime(4).ToString("dd 'thg' MM");
                    To = reader1.GetString(9);
                    ID = reader1.GetInt32(0);
                    ten = "Thư nháp";
                    danhSachID.Add(ID);
                    message uc = new message(email, tua_de, context, time, ten, ID, email, To, danhSachID, this);
                    uc.button1.Image = Properties.Resources.golden_star;
                    flowLayoutPanel1.Controls.Add(uc);
                    uc.Size = new System.Drawing.Size(1237, 49);
                    uc.Location = new System.Drawing.Point(x, y);
                    uc.name.ForeColor = System.Drawing.Color.Red;
                    y += 49;
                }


            }

            conn.Close();
        }



        private void send_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            searchBox.Visible = true;
            click = "send";
            receive.BackColor = Color.FromArgb(246, 248, 252);
            star.BackColor = Color.FromArgb(246, 248, 252);
            send.BackColor = Color.FromArgb(211, 227, 253);
            draft.BackColor = Color.FromArgb(246, 248, 252);
            bin.BackColor = Color.FromArgb(246, 248, 252);
            profile.BackColor = Color.FromArgb(246, 248, 252);
            flowLayoutPanel1.Controls.Clear();
            int x = 0, y = 0;
            conn.Open();
            OleDbCommand command1 = new OleDbCommand(@"SELECT *
                                                    FROM tbl_mess AS T1
                                                    WHERE [time] = (
                                                        SELECT MAX([time])
                                                        FROM tbl_mess AS T2
                                                        WHERE T2.[to] = T1.[to] AND T2.title = T1.title 
                                                    )
                                                      AND [from] = @email
                                                      AND bin = 0 
                                                      AND draft = 0
                                                    ORDER BY [time] DESC", conn);
            command1.Parameters.AddWithValue("@email", email);
            OleDbDataReader reader1 = command1.ExecuteReader();
            while (reader1.Read())
            {
                string tua_de = reader1.GetString(2);

                string context;
                if (reader1.GetString(3) == "Null")
                {
                    context = "";
                }
                else
                {
                    context = "- " + reader1.GetString(3);
                }
                string time = reader1.GetDateTime(4).ToString("dd 'thg' MM");
                string emailF = reader1.GetString(9);
                int ID = reader1.GetInt32(0);

                OleDbCommand command = new OleDbCommand(@"SELECT * From tbl_mess
                                                WHERE title = @title AND from = @fr AND to = @t AND [ID] > @id", conn);
                command.Parameters.AddWithValue("@title", tua_de);
                command.Parameters.AddWithValue("@fr", emailF);
                command.Parameters.AddWithValue("@t", email);
                command.Parameters.AddWithValue("@id", ID);
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.GetString(3) == "Null")
                    {
                        context = "";
                    }
                    else
                    {
                        context = "- " + reader.GetString(3);
                    }
                    ID = reader.GetInt32(0);
                }
                OleDbCommand command2 = new OleDbCommand(@"SELECT * From tbl_users
                                                WHERE email = @email ", conn);
                command2.Parameters.AddWithValue("@email", emailF);
                OleDbDataReader reader2 = command2.ExecuteReader();
                if (reader2.Read())
                {
                    string ten;
                    if (email == emailF)
                    {
                        ten = "Đến:Tôi";
                    }
                    else
                    {
                        ten = "Đến:" + reader2.GetString(2);
                    }
                    int cnt = 0;
                    List<int> danhSachID = new List<int>();
                    OleDbCommand command4 = new OleDbCommand(@"SELECT * From tbl_mess
                                                WHERE title = @title AND 
                                                      ((from = @fr AND to = @t) 
                                                      OR (from = @t AND to = @fr)) AND bin = 0", conn);
                    command4.Parameters.AddWithValue("@tiitle", tua_de);
                    command4.Parameters.AddWithValue("@fr", email);
                    command4.Parameters.AddWithValue("@t", emailF);
                    OleDbDataReader reader4 = command4.ExecuteReader();
                    while (reader4.Read())
                    {
                        cnt += 1;
                        danhSachID.Add(reader4.GetInt32(0));
                    }

                    message uc = new message(email, tua_de, context, time, ten, ID, emailF, email, danhSachID, this);
                    if (cnt > 1)
                    {
                        uc.number.Visible = true;
                        uc.number.Text = cnt.ToString();
                    }
                    flowLayoutPanel1.Controls.Add(uc);
                    uc.Size = new System.Drawing.Size(1237, 49);
                    uc.Location = new System.Drawing.Point(x, y);
                    y += 49;
                }

            }
            conn.Close();
        }

        private void draft_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            searchBox.Visible = true;
            click = "draft";
            receive.BackColor = Color.FromArgb(246, 248, 252);
            star.BackColor = Color.FromArgb(246, 248, 252);
            send.BackColor = Color.FromArgb(246, 248, 252);
            draft.BackColor = Color.FromArgb(211, 227, 253);
            bin.BackColor = Color.FromArgb(246, 248, 252);
            profile.BackColor = Color.FromArgb(246, 248, 252);
            flowLayoutPanel1.Controls.Clear();
            int x = 0, y = 0;
            conn.Open();
            OleDbCommand command1 = new OleDbCommand(@"SELECT *
                                                    FROM tbl_mess
                                                    WHERE [from] = @email
                                                    AND bin = 0
                                                    AND draft = 1
                                                    ORDER BY [time] DESC", conn);
            command1.Parameters.AddWithValue("@email", email);
            OleDbDataReader reader1 = command1.ExecuteReader();
            while (reader1.Read())
            {
                string tua_de = reader1.GetString(2);

                string context;
                if (reader1.GetString(3) == "Null")
                {
                    context = "";
                }
                else
                {
                    context = "- " + reader1.GetString(3);
                }
                string time = reader1.GetDateTime(4).ToString("dd 'thg' MM");
                string emailF = reader1.GetString(9);
                int ID = reader1.GetInt32(0);
                string ten = "Thư nháp";
                List<int> danhSachID = new List<int>();
                danhSachID.Add(ID);
                message uc = new message(email, tua_de, context, time, ten, ID, emailF, email, danhSachID, this);
                flowLayoutPanel1.Controls.Add(uc);
                uc.Size = new System.Drawing.Size(1237, 49);
                uc.Location = new System.Drawing.Point(x, y);
                uc.name.ForeColor = System.Drawing.Color.Red;
                y += 49;
            }
            conn.Close();
        }

        private void bin_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            searchBox.Visible = true;
            click = "bin";
            receive.BackColor = Color.FromArgb(246, 248, 252);
            star.BackColor = Color.FromArgb(246, 248, 252);
            send.BackColor = Color.FromArgb(246, 248, 252);
            draft.BackColor = Color.FromArgb(246, 248, 252);
            bin.BackColor = Color.FromArgb(211, 227, 253);
            profile.BackColor = Color.FromArgb(246, 248, 252);
            flowLayoutPanel1.Controls.Clear();
            int x = 0, y = 0;
            conn.Open();
            OleDbCommand command1 = new OleDbCommand(@"SELECT *
                                                        FROM tbl_mess AS T1
                                                        WHERE [time] = (
                                                            SELECT MAX([time])
                                                            FROM tbl_mess AS T2
                                                            WHERE 
                                                                ((T2.[from] = T1.[from] AND T2.[to] = T1.[to]) OR (T2.[from] = T1.[to] AND T2.[to] = T1.[from]))
                                                                AND T2.title = T1.title
                                                                )
                                                            
                                                            AND (T1.[from] = @email OR T1.[to] = @email)
                                                            AND bin = 1
                                                        ORDER BY [time] DESC", conn);
            command1.Parameters.AddWithValue("@email", email);
            OleDbDataReader reader1 = command1.ExecuteReader();
            while (reader1.Read())
            {
                string tua_de;
                string context;
                string time;
                int ID;
                string From;
                string To;
                string ten = "";
                List<int> danhSachID = new List<int>();
                if (reader1.GetInt16(10) == 0)
                {
                    tua_de = reader1.GetString(2);
                    if (reader1.GetString(3) == "Null")
                    {
                        context = "";
                    }
                    else
                    {
                        context = "- " + reader1.GetString(3);
                    }
                    time = reader1.GetDateTime(4).ToString("dd 'thg' MM");
                    ID = reader1.GetInt32(0);
                    From = reader1.GetString(1);
                    To = reader1.GetString(9);
                    if (From == To)
                    {
                        int cnt = 0;
                        ten = "Tôi";
                        OleDbCommand command4 = new OleDbCommand(@"SELECT * From tbl_mess
                                                WHERE title = @title AND 
                                                      from = @fr AND to = @t AND bin = 1 ", conn);
                        command4.Parameters.AddWithValue("@title", tua_de);
                        command4.Parameters.AddWithValue("@fr", From);
                        command4.Parameters.AddWithValue("@t", To);
                        OleDbDataReader reader4 = command4.ExecuteReader();
                        while (reader4.Read())
                        {
                            danhSachID.Add(reader4.GetInt32(0));
                            cnt += 1;
                        }
                        message uc = new message(email, tua_de, context, time, ten, ID, From, To, danhSachID, this);
                        uc.button1.Visible = false;
                        if (cnt > 1)
                        {
                            uc.number.Visible = true;
                            uc.number.Text = cnt.ToString();
                        }
                        flowLayoutPanel1.Controls.Add(uc);
                        uc.Size = new System.Drawing.Size(1237, 49);
                        uc.Location = new System.Drawing.Point(x, y);
                        y += 49;
                    }
                    else
                    {
                        if (From != email)
                        {
                            int cnt = 0;
                            OleDbCommand command2 = new OleDbCommand(@"SELECT * From tbl_users
                                                WHERE email = @email ", conn);
                            command2.Parameters.AddWithValue("@email", From);
                            OleDbDataReader reader2 = command2.ExecuteReader();
                            if (reader2.Read())
                            {
                                ten = reader2.GetString(2);
                            }
                            OleDbCommand command3 = new OleDbCommand(@"SELECT * From tbl_mess
                                                WHERE title = @title AND from = @fr AND to = @t ", conn);
                            command3.Parameters.AddWithValue("@title", tua_de);
                            command3.Parameters.AddWithValue("@fr", From);
                            command3.Parameters.AddWithValue("@t", email);
                            OleDbDataReader reader3 = command3.ExecuteReader();
                            if (reader3.Read())
                            {
                                ten = ten + ", Tôi";
                            }
                            OleDbCommand command4 = new OleDbCommand(@"SELECT * From tbl_mess
                                                WHERE title = @title AND 
                                                      ((from = @fr AND to = @t) 
                                                      OR (from = @t AND to = @fr)) AND bin = 1", conn);
                            command4.Parameters.AddWithValue("@title", tua_de);
                            command4.Parameters.AddWithValue("@fr", From);
                            command4.Parameters.AddWithValue("@t", To);
                            OleDbDataReader reader4 = command4.ExecuteReader();
                            while (reader4.Read())
                            {
                                danhSachID.Add(reader4.GetInt32(0));
                                cnt += 1;
                            }
                            message uc = new message(email, tua_de, context, time, ten, ID, From, To, danhSachID, this);
                            uc.button1.Visible = false;
                            if (cnt > 1)
                            {
                                uc.number.Visible = true;
                                uc.number.Text = cnt.ToString();
                            }
                            flowLayoutPanel1.Controls.Add(uc);
                            uc.Size = new System.Drawing.Size(1237, 49);
                            uc.Location = new System.Drawing.Point(x, y);
                            y += 49;
                        }
                        if (To != email)
                        {
                            int cnt = 0;
                            OleDbCommand command2 = new OleDbCommand(@"SELECT * From tbl_users
                                                WHERE email = @email ", conn);
                            command2.Parameters.AddWithValue("@email", To);
                            OleDbDataReader reader2 = command2.ExecuteReader();
                            if (reader2.Read())
                            {
                                ten = reader2.GetString(2);
                            }
                            OleDbCommand command3 = new OleDbCommand(@"SELECT * From tbl_mess
                                                WHERE title = @title AND from = @fr AND to = @t ", conn);
                            command3.Parameters.AddWithValue("@title", tua_de);
                            command3.Parameters.AddWithValue("@fr", email);
                            command3.Parameters.AddWithValue("@t", To);
                            OleDbDataReader reader3 = command3.ExecuteReader();
                            if (reader3.Read())
                            {
                                ten = ten + ", Tôi";
                            }
                            else
                            {
                                ten = "Tôi";
                            }
                            OleDbCommand command4 = new OleDbCommand(@"SELECT * From tbl_mess
                                                WHERE title = @title AND 
                                                      ((from = @fr AND to = @t) 
                                                      OR (from = @t AND to = @fr)) AND bin = 1", conn);
                            command4.Parameters.AddWithValue("@title", tua_de);
                            command4.Parameters.AddWithValue("@fr", From);
                            command4.Parameters.AddWithValue("@t", To);
                            OleDbDataReader reader4 = command4.ExecuteReader();
                            while (reader4.Read())
                            {
                                danhSachID.Add(reader4.GetInt32(0));
                                cnt += 1;
                            }
                            message uc = new message(email, tua_de, context, time, ten, ID, From, To, danhSachID, this);
                            uc.button1.Visible = false;
                            if (cnt > 1)
                            {
                                uc.number.Visible = true;
                                uc.number.Text = cnt.ToString();
                            }
                            flowLayoutPanel1.Controls.Add(uc);
                            uc.Size = new System.Drawing.Size(1237, 49);
                            uc.Location = new System.Drawing.Point(x, y);
                            y += 49;
                        }
                    }


                }
                if (reader1.GetInt16(10) == 1)
                {
                    tua_de = reader1.GetString(2);

                    if (reader1.GetString(3) == "Null")
                    {
                        context = "";
                    }
                    else
                    {
                        context = "- " + reader1.GetString(3);
                    }
                    time = reader1.GetDateTime(4).ToString("dd 'thg' MM");
                    To = reader1.GetString(9);
                    ID = reader1.GetInt32(0);
                    ten = "Thư nháp";
                    danhSachID.Add(ID);
                    message uc = new message(email, tua_de, context, time, ten, ID, email, To, danhSachID, this);
                    uc.button1.Visible = false;
                    flowLayoutPanel1.Controls.Add(uc);
                    uc.Size = new System.Drawing.Size(1237, 49);
                    uc.Location = new System.Drawing.Point(x, y);
                    uc.name.ForeColor = System.Drawing.Color.Red;
                    y += 49;
                }


            }
            conn.Close();
        }

        private void SoanThu_Click(object sender, EventArgs e)
        {
            new MessForm(email).Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            receive_Click(sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            searchBox.Visible = true;
            receive.BackColor = Color.FromArgb(246, 248, 252);
            star.BackColor = Color.FromArgb(246, 248, 252);
            send.BackColor = Color.FromArgb(246, 248, 252);
            draft.BackColor = Color.FromArgb(246, 248, 252);
            bin.BackColor = Color.FromArgb(246, 248, 252);
            profile.BackColor = Color.FromArgb(211, 227, 253);
            flowLayoutPanel1.Controls.Clear();
            account uc = new account(email);
            flowLayoutPanel1.Controls.Add(uc);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (click == "receive")
            {
                if (searchBox.Text.Length > 0)
                {
                    string s = searchBox.Text;

                    flowLayoutPanel1.Controls.Clear();
                    int x = 0, y = 0;
                    conn.Open();
                    OleDbCommand command1 = new OleDbCommand(@"SELECT *
                                                    FROM tbl_mess AS T1
                                                    WHERE [time] = (
                                                        SELECT MAX([time])
                                                        FROM tbl_mess AS T2
                                                        WHERE T2.[from] = T1.[from] AND T2.title = T1.title
                                                    )
                                                      AND [to] = @email
                                                      AND T1.title = @s
                                                      AND bin = 0
                                                      AND draft = 0
                                                    ORDER BY [time] DESC", conn);
                    command1.Parameters.AddWithValue("@email", email);
                    command1.Parameters.AddWithValue("@s", s);
                    OleDbDataReader reader1 = command1.ExecuteReader();
                    while (reader1.Read())
                    {
                        string tua_de = reader1.GetString(2);

                        string context;
                        if (reader1.GetString(3) == "Null")
                        {
                            context = "";
                        }
                        else
                        {
                            context = "- " + reader1.GetString(3);
                        }

                        string time = reader1.GetDateTime(4).ToString("dd 'thg' MM");
                        string emailF = reader1.GetString(1);
                        int ID = reader1.GetInt32(0);
                        string ten;

                        OleDbCommand command = new OleDbCommand(@"SELECT * From tbl_mess
                                                WHERE title = @title AND from = @fr AND to = @t AND [ID] > @id", conn);
                        command.Parameters.AddWithValue("@title", tua_de);
                        command.Parameters.AddWithValue("@fr", email);
                        command.Parameters.AddWithValue("@t", emailF);
                        command.Parameters.AddWithValue("@id", ID);
                        OleDbDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            if (reader.GetString(3) == "Null")
                            {
                                context = "";
                            }
                            else
                            {
                                context = "- " + reader.GetString(3);
                            }
                            ID = reader.GetInt32(0);
                        }

                        OleDbCommand command2 = new OleDbCommand(@"SELECT * From tbl_users
                                                WHERE email = @email ", conn);
                        command2.Parameters.AddWithValue("@email", emailF);
                        OleDbDataReader reader2 = command2.ExecuteReader();
                        if (reader2.Read())
                        {
                            if (email == emailF)
                            {
                                ten = "Tôi";
                            }
                            else
                            {
                                ten = reader2.GetString(2);

                            }

                            int cnt = 0;
                            List<int> danhSachID = new List<int>();
                            OleDbCommand command3 = new OleDbCommand(@"SELECT * From tbl_mess
                                                WHERE title = @title AND from = @fr AND to = @t", conn);
                            command3.Parameters.AddWithValue("@title", tua_de);
                            command3.Parameters.AddWithValue("@fr", email);
                            command3.Parameters.AddWithValue("@t", emailF);
                            OleDbDataReader reader3 = command3.ExecuteReader();
                            if (reader3.Read() && email != emailF)
                            {
                                ten = ten + ", Tôi";
                            }

                            OleDbCommand command4 = new OleDbCommand(@"SELECT * From tbl_mess
                                                WHERE title = @title AND 
                                                      ((from = @fr AND to = @t) 
                                                      OR (from = @t AND to = @fr))
                                                      AND bin = 0", conn);
                            command4.Parameters.AddWithValue("@title", tua_de);
                            command4.Parameters.AddWithValue("@fr", email);
                            command4.Parameters.AddWithValue("@t", emailF);
                            OleDbDataReader reader4 = command4.ExecuteReader();
                            while (reader4.Read())
                            {
                                cnt += 1;
                                danhSachID.Add(reader4.GetInt32(0));
                            }

                            message uc = new message(email, tua_de, context, time, ten, ID, emailF, email, danhSachID, this);
                            if (cnt > 1)
                            {
                                uc.number.Visible = true;
                                uc.number.Text = cnt.ToString();
                            }
                            flowLayoutPanel1.Controls.Add(uc);

                        }

                    }
                    conn.Close();
                }
                else
                { receive_Click(null, EventArgs.Empty); }
            }
            if (click == "star")
            {
                if (searchBox.Text.Length > 0)
                {
                    string s = searchBox.Text;
                    flowLayoutPanel1.Controls.Clear();
                    int x = 0, y = 0;
                    conn.Open();
                    OleDbCommand command1 = new OleDbCommand(@"SELECT *
                                                        FROM tbl_mess AS T1
                                                        WHERE [time] = (
                                                            SELECT MAX([time])
                                                            FROM tbl_mess AS T2
                                                            WHERE 
                                                                ((T2.[from] = T1.[from] AND T2.[to] = T1.[to]) OR (T2.[from] = T1.[to] AND T2.[to] = T1.[from]))
                                                                AND T2.title = T1.title
                                                                AND EXISTS (
                                                                    SELECT 1
                                                                    FROM tbl_mess AS T3
                                                                    WHERE 
                                                                        ((T3.[from] = T1.[from] AND T3.[to] = T1.[to]) OR (T3.[from] = T1.[to] AND T3.[to] = T1.[from]))
                                                                        AND T3.star = 1
                                                                        AND T3.title = T1.title
                                                                )
                                                            )
                                                            AND (T1.[from] = @email OR T1.[to] = @email)
                                                            AND T1.title = @s
                                                            AND bin = 0
                                                            AND draft = 0
                                                        ORDER BY [time] DESC
                                                        UNION
                                                        SELECT *
                                                        FROM tbl_mess AS T4
                                                        WHERE T4.[from] = @email
                                                            AND T4.title = @s
                                                            AND draft = 1
                                                            AND star = 1
                                                            AND bin = 0
                                                            ORDER BY [time] DESC", conn);
                    command1.Parameters.AddWithValue("@emai", email);
                    command1.Parameters.AddWithValue("@s", s);
                    OleDbDataReader reader1 = command1.ExecuteReader();
                    while (reader1.Read())
                    {
                        string tua_de;
                        string context;
                        string time;
                        int ID;
                        string From;
                        string To;
                        string ten = "";
                        List<int> danhSachID = new List<int>();
                        if (reader1.GetInt16(10) == 0)
                        {
                            tua_de = reader1.GetString(2);
                            if (reader1.GetString(3) == "Null")
                            {
                                context = "";
                            }
                            else
                            {
                                context = "- " + reader1.GetString(3);
                            }
                            time = reader1.GetDateTime(4).ToString("dd 'thg' MM");
                            ID = reader1.GetInt32(0);
                            From = reader1.GetString(1);
                            To = reader1.GetString(9);
                            if (From == To)
                            {
                                int cnt = 0;
                                ten = "Tôi";
                                OleDbCommand command4 = new OleDbCommand(@"SELECT * From tbl_mess
                                                WHERE title = @title AND 
                                                      from = @fr AND to = @t AND bin = 0 ", conn);
                                command4.Parameters.AddWithValue("@title", tua_de);
                                command4.Parameters.AddWithValue("@fr", From);
                                command4.Parameters.AddWithValue("@t", To);
                                OleDbDataReader reader4 = command4.ExecuteReader();
                                while (reader4.Read())
                                {
                                    danhSachID.Add(reader4.GetInt32(0));
                                    cnt += 1;
                                }
                                message uc = new message(email, tua_de, context, time, ten, ID, From, To, danhSachID, this);
                                uc.button1.Image = Properties.Resources.golden_star;
                                if (cnt > 1)
                                {
                                    uc.number.Visible = true;
                                    uc.number.Text = cnt.ToString();
                                }
                                flowLayoutPanel1.Controls.Add(uc);
                                uc.Size = new System.Drawing.Size(1237, 49);
                                uc.Location = new System.Drawing.Point(x, y);
                                y += 49;
                            }
                            else
                            {
                                if (From != email)
                                {
                                    int cnt = 0;
                                    OleDbCommand command2 = new OleDbCommand(@"SELECT * From tbl_users
                                                WHERE email = @email ", conn);
                                    command2.Parameters.AddWithValue("@email", From);
                                    OleDbDataReader reader2 = command2.ExecuteReader();
                                    if (reader2.Read())
                                    {
                                        ten = reader2.GetString(2);
                                    }
                                    OleDbCommand command3 = new OleDbCommand(@"SELECT * From tbl_mess
                                                WHERE title = @title AND from = @fr AND to = @t ", conn);
                                    command3.Parameters.AddWithValue("@title", tua_de);
                                    command3.Parameters.AddWithValue("@fr", From);
                                    command3.Parameters.AddWithValue("@t", email);
                                    OleDbDataReader reader3 = command3.ExecuteReader();
                                    if (reader3.Read())
                                    {
                                        ten = ten + ", Tôi";
                                    }
                                    OleDbCommand command4 = new OleDbCommand(@"SELECT * From tbl_mess
                                                WHERE title = @title AND 
                                                      ((from = @fr AND to = @t) 
                                                      OR (from = @t AND to = @fr)) AND bin = 0", conn);
                                    command4.Parameters.AddWithValue("@title", tua_de);
                                    command4.Parameters.AddWithValue("@fr", From);
                                    command4.Parameters.AddWithValue("@t", To);
                                    OleDbDataReader reader4 = command4.ExecuteReader();
                                    while (reader4.Read())
                                    {
                                        danhSachID.Add(reader4.GetInt32(0));
                                        cnt += 1;
                                    }
                                    message uc = new message(email, tua_de, context, time, ten, ID, From, To, danhSachID, this);
                                    uc.button1.Image = Properties.Resources.golden_star;
                                    if (cnt > 1)
                                    {
                                        uc.number.Visible = true;
                                        uc.number.Text = cnt.ToString();
                                    }
                                    flowLayoutPanel1.Controls.Add(uc);
                                    uc.Size = new System.Drawing.Size(1237, 49);
                                    uc.Location = new System.Drawing.Point(x, y);
                                    y += 49;
                                }
                                if (To != email)
                                {
                                    int cnt = 0;
                                    OleDbCommand command2 = new OleDbCommand(@"SELECT * From tbl_users
                                                WHERE email = @email ", conn);
                                    command2.Parameters.AddWithValue("@email", To);
                                    OleDbDataReader reader2 = command2.ExecuteReader();
                                    if (reader2.Read())
                                    {
                                        ten = reader2.GetString(2);
                                    }
                                    OleDbCommand command3 = new OleDbCommand(@"SELECT * From tbl_mess
                                                WHERE title = @title AND from = @fr AND to = @t ", conn);
                                    command3.Parameters.AddWithValue("@title", tua_de);
                                    command3.Parameters.AddWithValue("@fr", email);
                                    command3.Parameters.AddWithValue("@t", To);
                                    OleDbDataReader reader3 = command3.ExecuteReader();
                                    if (reader3.Read())
                                    {
                                        ten = ten + ", Tôi";
                                    }
                                    else
                                    {
                                        ten = "Tôi";
                                    }
                                    OleDbCommand command4 = new OleDbCommand(@"SELECT * From tbl_mess
                                                WHERE title = @title AND 
                                                      ((from = @fr AND to = @t) 
                                                      OR (from = @t AND to = @fr))", conn);
                                    command4.Parameters.AddWithValue("@title", tua_de);
                                    command4.Parameters.AddWithValue("@fr", From);
                                    command4.Parameters.AddWithValue("@t", To);
                                    OleDbDataReader reader4 = command4.ExecuteReader();
                                    while (reader4.Read())
                                    {
                                        danhSachID.Add(reader4.GetInt32(0));
                                        cnt += 1;
                                    }
                                    message uc = new message(email, tua_de, context, time, ten, ID, From, To, danhSachID, this);
                                    uc.button1.Image = Properties.Resources.golden_star;
                                    if (cnt > 1)
                                    {
                                        uc.number.Visible = true;
                                        uc.number.Text = cnt.ToString();
                                    }
                                    flowLayoutPanel1.Controls.Add(uc);
                                    uc.Size = new System.Drawing.Size(1237, 49);
                                    uc.Location = new System.Drawing.Point(x, y);
                                    y += 49;
                                }
                            }


                        }
                        if (reader1.GetInt16(10) == 1)
                        {
                            tua_de = reader1.GetString(2);

                            if (reader1.GetString(3) == "Null")
                            {
                                context = "";
                            }
                            else
                            {
                                context = "- " + reader1.GetString(3);
                            }
                            time = reader1.GetDateTime(4).ToString("dd 'thg' MM");
                            To = reader1.GetString(9);
                            ID = reader1.GetInt32(0);
                            ten = "Thư nháp";
                            danhSachID.Add(ID);
                            message uc = new message(email, tua_de, context, time, ten, ID, email, To, danhSachID, this);
                            uc.button1.Image = Properties.Resources.golden_star;
                            flowLayoutPanel1.Controls.Add(uc);
                            uc.Size = new System.Drawing.Size(1237, 49);
                            uc.Location = new System.Drawing.Point(x, y);
                            uc.name.ForeColor = System.Drawing.Color.Red;
                            y += 49;
                        }


                    }

                    conn.Close();
                }
                else
                { star_Click(null, EventArgs.Empty); }

            }
            if (click == "send")
            {
                if (searchBox.Text.Length > 0)
                {
                    string s = searchBox.Text;
                    flowLayoutPanel1.Controls.Clear();
                    int x = 0, y = 0;
                    conn.Open();
                    OleDbCommand command1 = new OleDbCommand(@"SELECT *
                                                    FROM tbl_mess AS T1
                                                    WHERE [time] = (
                                                        SELECT MAX([time])
                                                        FROM tbl_mess AS T2
                                                        WHERE T2.[to] = T1.[to] AND T2.title = T1.title 
                                                    )
                                                      AND [from] = @email
                                                      AND T1.title = @s
                                                      AND bin = 0 
                                                      AND draft = 0
                                                    ORDER BY [time] DESC", conn);
                    command1.Parameters.AddWithValue("@email", email);
                    command1.Parameters.AddWithValue("@s", s);
                    OleDbDataReader reader1 = command1.ExecuteReader();
                    while (reader1.Read())
                    {
                        string tua_de = reader1.GetString(2);

                        string context;
                        if (reader1.GetString(3) == "Null")
                        {
                            context = "";
                        }
                        else
                        {
                            context = "- " + reader1.GetString(3);
                        }
                        string time = reader1.GetDateTime(4).ToString("dd 'thg' MM");
                        string emailF = reader1.GetString(9);
                        int ID = reader1.GetInt32(0);

                        OleDbCommand command = new OleDbCommand(@"SELECT * From tbl_mess
                                                WHERE title = @title AND from = @fr AND to = @t AND [ID] > @id", conn);
                        command.Parameters.AddWithValue("@title", tua_de);
                        command.Parameters.AddWithValue("@fr", emailF);
                        command.Parameters.AddWithValue("@t", email);
                        command.Parameters.AddWithValue("@id", ID);
                        OleDbDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            if (reader.GetString(3) == "Null")
                            {
                                context = "";
                            }
                            else
                            {
                                context = "- " + reader.GetString(3);
                            }
                            ID = reader.GetInt32(0);
                        }
                        OleDbCommand command2 = new OleDbCommand(@"SELECT * From tbl_users
                                                WHERE email = @email ", conn);
                        command2.Parameters.AddWithValue("@email", emailF);
                        OleDbDataReader reader2 = command2.ExecuteReader();
                        if (reader2.Read())
                        {
                            string ten;
                            if (email == emailF)
                            {
                                ten = "Đến:Tôi";
                            }
                            else
                            {
                                ten = "Đến:" + reader2.GetString(2);
                            }
                            int cnt = 0;
                            List<int> danhSachID = new List<int>();
                            OleDbCommand command4 = new OleDbCommand(@"SELECT * From tbl_mess
                                                WHERE title = @title AND 
                                                      ((from = @fr AND to = @t) 
                                                      OR (from = @t AND to = @fr)) AND bin = 0", conn);
                            command4.Parameters.AddWithValue("@tiitle", tua_de);
                            command4.Parameters.AddWithValue("@fr", email);
                            command4.Parameters.AddWithValue("@t", emailF);
                            OleDbDataReader reader4 = command4.ExecuteReader();
                            while (reader4.Read())
                            {
                                cnt += 1;
                                danhSachID.Add(reader4.GetInt32(0));
                            }

                            message uc = new message(email, tua_de, context, time, ten, ID, emailF, email, danhSachID, this);
                            if (cnt > 1)
                            {
                                uc.number.Visible = true;
                                uc.number.Text = cnt.ToString();
                            }
                            flowLayoutPanel1.Controls.Add(uc);
                            uc.Size = new System.Drawing.Size(1237, 49);
                            uc.Location = new System.Drawing.Point(x, y);
                            y += 49;
                        }

                    }
                    conn.Close();
                }
                else
                { send_Click(null, EventArgs.Empty); }
            }
            if (click == "bin")
            {
                if (searchBox.Text.Length > 0)
                {
                    string s = searchBox.Text;
                    flowLayoutPanel1.Controls.Clear();
                    int x = 0, y = 0;
                    conn.Open();
                    OleDbCommand command1 = new OleDbCommand(@"SELECT *
                                                        FROM tbl_mess AS T1
                                                        WHERE [time] = (
                                                            SELECT MAX([time])
                                                            FROM tbl_mess AS T2
                                                            WHERE 
                                                                ((T2.[from] = T1.[from] AND T2.[to] = T1.[to]) OR (T2.[from] = T1.[to] AND T2.[to] = T1.[from]))
                                                                AND T2.title = T1.title
                                                                )
                                                            
                                                            AND (T1.[from] = @email OR T1.[to] = @email)
                                                            AND T1.title = @s
                                                            AND bin = 1
                                                        ORDER BY [time] DESC", conn);
                    command1.Parameters.AddWithValue("@email", email);
                    command1.Parameters.AddWithValue("@s", s);
                    OleDbDataReader reader1 = command1.ExecuteReader();
                    while (reader1.Read())
                    {
                        string tua_de;
                        string context;
                        string time;
                        int ID;
                        string From;
                        string To;
                        string ten = "";
                        List<int> danhSachID = new List<int>();
                        if (reader1.GetInt16(10) == 0)
                        {
                            tua_de = reader1.GetString(2);
                            if (reader1.GetString(3) == "Null")
                            {
                                context = "";
                            }
                            else
                            {
                                context = "- " + reader1.GetString(3);
                            }
                            time = reader1.GetDateTime(4).ToString("dd 'thg' MM");
                            ID = reader1.GetInt32(0);
                            From = reader1.GetString(1);
                            To = reader1.GetString(9);
                            if (From == To)
                            {
                                int cnt = 0;
                                ten = "Tôi";
                                OleDbCommand command4 = new OleDbCommand(@"SELECT * From tbl_mess
                                                WHERE title = @title AND 
                                                      from = @fr AND to = @t AND bin = 1 ", conn);
                                command4.Parameters.AddWithValue("@title", tua_de);
                                command4.Parameters.AddWithValue("@fr", From);
                                command4.Parameters.AddWithValue("@t", To);
                                OleDbDataReader reader4 = command4.ExecuteReader();
                                while (reader4.Read())
                                {
                                    danhSachID.Add(reader4.GetInt32(0));
                                    cnt += 1;
                                }
                                message uc = new message(email, tua_de, context, time, ten, ID, From, To, danhSachID, this);
                                uc.button1.Visible = false;
                                if (cnt > 1)
                                {
                                    uc.number.Visible = true;
                                    uc.number.Text = cnt.ToString();
                                }
                                flowLayoutPanel1.Controls.Add(uc);
                                uc.Size = new System.Drawing.Size(1237, 49);
                                uc.Location = new System.Drawing.Point(x, y);
                                y += 49;
                            }
                            else
                            {
                                if (From != email)
                                {
                                    int cnt = 0;
                                    OleDbCommand command2 = new OleDbCommand(@"SELECT * From tbl_users
                                                WHERE email = @email ", conn);
                                    command2.Parameters.AddWithValue("@email", From);
                                    OleDbDataReader reader2 = command2.ExecuteReader();
                                    if (reader2.Read())
                                    {
                                        ten = reader2.GetString(2);
                                    }
                                    OleDbCommand command3 = new OleDbCommand(@"SELECT * From tbl_mess
                                                WHERE title = @title AND from = @fr AND to = @t ", conn);
                                    command3.Parameters.AddWithValue("@title", tua_de);
                                    command3.Parameters.AddWithValue("@fr", From);
                                    command3.Parameters.AddWithValue("@t", email);
                                    OleDbDataReader reader3 = command3.ExecuteReader();
                                    if (reader3.Read())
                                    {
                                        ten = ten + ", Tôi";
                                    }
                                    OleDbCommand command4 = new OleDbCommand(@"SELECT * From tbl_mess
                                                WHERE title = @title AND 
                                                      ((from = @fr AND to = @t) 
                                                      OR (from = @t AND to = @fr)) AND bin = 1", conn);
                                    command4.Parameters.AddWithValue("@title", tua_de);
                                    command4.Parameters.AddWithValue("@fr", From);
                                    command4.Parameters.AddWithValue("@t", To);
                                    OleDbDataReader reader4 = command4.ExecuteReader();
                                    while (reader4.Read())
                                    {
                                        danhSachID.Add(reader4.GetInt32(0));
                                        cnt += 1;
                                    }
                                    message uc = new message(email, tua_de, context, time, ten, ID, From, To, danhSachID, this);
                                    uc.button1.Visible = false;
                                    if (cnt > 1)
                                    {
                                        uc.number.Visible = true;
                                        uc.number.Text = cnt.ToString();
                                    }
                                    flowLayoutPanel1.Controls.Add(uc);
                                    uc.Size = new System.Drawing.Size(1237, 49);
                                    uc.Location = new System.Drawing.Point(x, y);
                                    y += 49;
                                }
                                if (To != email)
                                {
                                    int cnt = 0;
                                    OleDbCommand command2 = new OleDbCommand(@"SELECT * From tbl_users
                                                WHERE email = @email ", conn);
                                    command2.Parameters.AddWithValue("@email", To);
                                    OleDbDataReader reader2 = command2.ExecuteReader();
                                    if (reader2.Read())
                                    {
                                        ten = reader2.GetString(2);
                                    }
                                    OleDbCommand command3 = new OleDbCommand(@"SELECT * From tbl_mess
                                                WHERE title = @title AND from = @fr AND to = @t ", conn);
                                    command3.Parameters.AddWithValue("@title", tua_de);
                                    command3.Parameters.AddWithValue("@fr", email);
                                    command3.Parameters.AddWithValue("@t", To);
                                    OleDbDataReader reader3 = command3.ExecuteReader();
                                    if (reader3.Read())
                                    {
                                        ten = ten + ", Tôi";
                                    }
                                    else
                                    {
                                        ten = "Tôi";
                                    }
                                    OleDbCommand command4 = new OleDbCommand(@"SELECT * From tbl_mess
                                                WHERE title = @title AND 
                                                      ((from = @fr AND to = @t) 
                                                      OR (from = @t AND to = @fr)) AND bin = 1", conn);
                                    command4.Parameters.AddWithValue("@title", tua_de);
                                    command4.Parameters.AddWithValue("@fr", From);
                                    command4.Parameters.AddWithValue("@t", To);
                                    OleDbDataReader reader4 = command4.ExecuteReader();
                                    while (reader4.Read())
                                    {
                                        danhSachID.Add(reader4.GetInt32(0));
                                        cnt += 1;
                                    }
                                    message uc = new message(email, tua_de, context, time, ten, ID, From, To, danhSachID, this);
                                    uc.button1.Visible = false;
                                    if (cnt > 1)
                                    {
                                        uc.number.Visible = true;
                                        uc.number.Text = cnt.ToString();
                                    }
                                    flowLayoutPanel1.Controls.Add(uc);
                                    uc.Size = new System.Drawing.Size(1237, 49);
                                    uc.Location = new System.Drawing.Point(x, y);
                                    y += 49;
                                }
                            }


                        }
                        if (reader1.GetInt16(10) == 1)
                        {
                            tua_de = reader1.GetString(2);

                            if (reader1.GetString(3) == "Null")
                            {
                                context = "";
                            }
                            else
                            {
                                context = "- " + reader1.GetString(3);
                            }
                            time = reader1.GetDateTime(4).ToString("dd 'thg' MM");
                            To = reader1.GetString(9);
                            ID = reader1.GetInt32(0);
                            ten = "Thư nháp";
                            danhSachID.Add(ID);
                            message uc = new message(email, tua_de, context, time, ten, ID, email, To, danhSachID, this);
                            uc.button1.Visible = false;
                            flowLayoutPanel1.Controls.Add(uc);
                            uc.Size = new System.Drawing.Size(1237, 49);
                            uc.Location = new System.Drawing.Point(x, y);
                            uc.name.ForeColor = System.Drawing.Color.Red;
                            y += 49;
                        }


                    }
                    conn.Close();
                }
                else
                { bin_Click(null, EventArgs.Empty); }
            }
        }

       
    }
}
