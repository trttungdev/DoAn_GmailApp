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
    public partial class MessForm2 : Form
    {
        int ID;
        string path;
        string email;
        public MessForm2(int ID, string email, string path)
        {
            InitializeComponent();
            this.ID = ID;
            this.email = email;
            this.path = path;
            this.Location = new Point(1080, 400);
        }
        OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source = C:\\Users\\Admin\\source\\repos\\DoAn\\DoAn\\bin\\Debug\\db_gmail.accdb");

        private void SoanThu_Click(object sender, EventArgs e)
        {
            conn.Open();
            string login = "SELECT * from tbl_users WHERE email = '" + To.Text + "'";
            OleDbCommand cmd = new OleDbCommand(login, conn);
            OleDbDataReader dr = cmd.ExecuteReader();
            if (dr.Read() == true)
            {
                OleDbCommand command1 = new OleDbCommand(@"INSERT INTO tbl_mess ([from],[title],[context],[to],[image],draft) 
                                                            VALUES 
                                                            (@fr,@title,@context,@t,@img,0)", conn);
                command1.Parameters.AddWithValue("@fr", email);
                if (title != null)
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
                command1.Parameters.AddWithValue("@t", To.Text);
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
                this.Close();
            }
            conn.Open();
            OleDbCommand command = new OleDbCommand(@"DELETE * From tbl_mess
                                                WHERE [ID] = @id ", conn);
            command.Parameters.AddWithValue("@id", ID);
            command.ExecuteNonQuery();
            conn.Close();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
