using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
//using MySql.Data.MySqlClient;

namespace Library_Management_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_Username_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void txt_Username_MouseClick(object sender, MouseEventArgs e)
        {
            if (txt_Username.Text == "Username")
            {
                txt_Username.Clear();
            }

        }

        private void txt_Password_MouseClick(object sender, MouseEventArgs e)
        {
            if (txt_Password.Text == "Password")
            {
                txt_Password.Clear();
                txt_Password.PasswordChar='*';
            }
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Server=127.0.0.1;Database=library;User Id=root;Password=myPassword;";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from loginTable where username ='"+txt_Username.Text+"' and pass ='" +txt_Password.Text+"'";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count != 0)
            {
                this.Hide();
                Dashboard dsa = new Dashboard();
                dsa.Show();
            }
            else
            {
                MessageBox.Show("Wrong username OR Password","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            
            }

        }
    }
}
