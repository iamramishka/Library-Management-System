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
    public partial class AddStudent : Form
    {
        public AddStudent()
        {
            InitializeComponent();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirm?", "Alert", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            txt_Name.Clear();
            txt_Enrollment.Clear();
            txt_Department.Clear();
            txt_Semester.Clear();
            txt_Contact.Clear();
            //txt_Email.Clear();
            txt_Email.Text = "";

        }

        private void btn_save_info_Click(object sender, EventArgs e)
        {

            if (txt_Name.Text != "" && txt_Enrollment.Text != "" && txt_Semester.Text != "" && txt_Contact.Text != "" && txt_Email.Text != "")
            {
                String name = txt_Name.Text;
                String enroll = txt_Enrollment.Text;
                String dep = txt_Department.Text;
                String sem = txt_Semester.Text;
                Int64 mobile = Int64.Parse(txt_Contact.Text);
                String email = txt_Email.Text;


                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Server=127.0.0.1;Database=library;User Id=root;Password=myPassword;";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                con.Open();
                cmd.CommandText = "insert into NewStudent (sname,enroll,dep,sem,contact,email) values ('" + name + "','" + enroll + "','" + dep + "','" + sem + "'," + mobile + ",'" + email + "')";
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data Saved", "success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {

                MessageBox.Show("Please Fill Empty Filds", "Suggest",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }


        }
    }
}
