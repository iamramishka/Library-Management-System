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
    public partial class IssueBooks : Form
    {
        public IssueBooks()
        {
            InitializeComponent();
        }

        private void IssueBooks_Load(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Server=127.0.0.1;Database=library;User Id=root;Password=myPassword;";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();

            cmd = new SqlCommand("select bName from NewBook",con);
            SqlDataReader Sdr = cmd.ExecuteReader();

            while (Sdr.Read())
            {
                for (int i = 0; i < Sdr.FieldCount; i++)
                {
                    books_name_combobox.Items.Add(Sdr.GetString(i));
                }
            
            }
            Sdr.Close();
            con.Close();

        }

        int count;

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void search_student_btn_Click(object sender, EventArgs e)
        {
            if (search_btn.Text != "")
            {
                String eid = search_btn.Text;
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Server=127.0.0.1;Database=library;User Id=root;Password=myPassword;";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from NewStudent where enroll = '" + eid + "'";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);

                cmd.CommandText = "select count(std_enroll) from IRBook where std_enroll = '" + eid + "' and book_return_date is null";
                SqlDataAdapter DA1 = new SqlDataAdapter(cmd);
                DataSet DS1 = new DataSet();
                DA.Fill(DS1);

                count = int.Parse(DS1.Tables[0].Rows[0][0].ToString());

                if (DS.Tables[0].Rows.Count != 0)
                {
                    student_name_txtbox.Text = DS.Tables[0].Rows[0][1].ToString();
                    department_txtbox.Text = DS.Tables[0].Rows[0][3].ToString();
                    student_semester_txtbox.Text = DS.Tables[0].Rows[0][4].ToString();
                    student_contact_txtbox.Text = DS.Tables[0].Rows[0][5].ToString();
                    student_email_txtbox.Text = DS.Tables[0].Rows[0][6].ToString();


                }
                else
                {
                    student_name_txtbox.Clear();
                    department_txtbox.Clear();
                    student_semester_txtbox.Clear();
                    student_contact_txtbox.Clear();
                    student_email_txtbox.Clear();
                    MessageBox.Show("Invalid Enrollment No","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                }

            }
        }

        private void issue_book_btn_Click(object sender, EventArgs e)
        {
            if (student_name_txtbox.Text != "")
            {
                if (books_name_combobox.SelectedIndex != -1 && count <= 2)
                {
                    String enroll = search_btn.Text;
                    String sname = student_name_txtbox.Text;
                    String sdep = department_txtbox.Text;
                    String sem = student_semester_txtbox.Text;
                    Int64 contact = Int64.Parse(student_contact_txtbox.Text);
                    String email = student_email_txtbox.Text;
                    String bookname = books_name_combobox.Text;
                    String bookIssueDate = dateTimePicker.Text;



                    String eid = search_btn.Text;
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = "Server=127.0.0.1;Database=library;User Id=root;Password=myPassword;";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;
                    con.Open();
                    cmd.CommandText = "insert into IRBook (std enroll,std_name,std_dep,std_sem,std_contact,std_email,book_name,book_issue_date) values ('" + enroll + "','" + sname + "','" + sdep + "','" + sem + "','" + contact + ",'" + email + "','" + bookname + "','" + bookIssueDate + "')";
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("Book Issued.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Select Book OR Maximum number of book Has bee Issued", "No Book Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
            else
            {
                MessageBox.Show("Enter valid Enrollment No","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            
            }
        }

        private void search_btn_TextChanged(object sender, EventArgs e)
        {
            if (search_btn.Text == "")
            {
                student_name_txtbox.Clear();
                department_txtbox.Clear();
                student_semester_txtbox.Clear();
                student_contact_txtbox.Clear();
                student_email_txtbox.Clear();
            
            
            }
        }

        private void refresh_btn_Click(object sender, EventArgs e)
        {
            search_btn.Clear();
        }

        private void exit_btn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
