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
    public partial class ViewStudentInformation : Form
    {
        public ViewStudentInformation()
        {
            InitializeComponent();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text != "")
            {
                label1.Visible = false;
                //Image image = image.Fromfile("D:/University/2nd Year/2nd Sem/Computer Lab/Liberay Management System/search1.gif");
                //Image image = Image.FromFile("D:/University/2nd Year/2nd Sem/Computer Lab/Liberay Management System/search1.gif");
                Image image = Image.FromFile("C:/Users/ramis/OneDrive/Desktop/Library Management System/Library Management System/images/search1.gif");
                pictureBox1.Image = image;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Server=127.0.0.1;Database=library;User Id=root;Password=myPassword;";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * NewStudent where enroll LIKE '"+txtSearch+"%'";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);
                dataGridView1.DataSource = DS.Tables[0];
            
            }
            else
            {
                label1.Visible = true;
                //Image image = image.Fromfile("D:/University/2nd Year/2nd Sem/Computer Lab/Liberay Management System/search.gif");
                
                //Image image = Image.FromFile("D:/University/2nd Year/2nd Sem/Computer Lab/Liberay Management System/search.gif");
                Image image = Image.FromFile("C:/Users/ramis/OneDrive/Desktop/Library Management System/Library Management System/images/search.gif");
                pictureBox1.Image = image;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Server=127.0.0.1;Database=library;User Id=root;Password=myPassword;";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * NewStudent";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);

                dataGridView1.DataSource = DS.Tables[0];
            
            }

        }

        private void ViewStudentInformation_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Server=127.0.0.1;Database=library;User Id=root;Password=myPassword;";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * NewStudent";
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);

            dataGridView1.DataSource = DS.Tables[0];

        }

        int bid;
        Int64 rowid;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                bid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            
            }

            panel2.Visible = true;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Server=127.0.0.1;Database=library;User Id=root;Password=myPassword;";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * NewStudent where stuid = "+bid+"";
            SqlDataAdapter DA = new SqlDataAdapter(cmd);
            DataSet DS = new DataSet();
            DA.Fill(DS);

            rowid = Int64.Parse(DS.Tables[0].Rows[0][0].ToString());

            textStuName.Text = DS.Tables[0].Rows[0][1].ToString();
            text_Enrollment_No.Text = DS.Tables[0].Rows[0][2].ToString();
            text_Department.Text = DS.Tables[0].Rows[0][3].ToString();
            text_Student_Semester.Text = DS.Tables[0].Rows[0][4].ToString();
            text_Student_Contact.Text = DS.Tables[0].Rows[0][5].ToString();
            text_Student_Email.Text = DS.Tables[0].Rows[0][6].ToString();

        }

        private void button_Update_Click(object sender, EventArgs e)
        {
            String sname = textStuName.Text;
            String enroll = text_Enrollment_No.Text;
            String dep = text_Department.Text;
            String sem = text_Student_Semester.Text;
            Int64 contact = Int64.Parse(text_Student_Contact.Text);
            String semail = text_Student_Email.Text;

            if (MessageBox.Show("Data will Be Updated.Confirm?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Server=127.0.0.1;Database=library;User Id=root;Password=myPassword;";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "update NewStudent set sname ='" + sname + "',enroll='" + enroll + "',dep = '" + dep + "',sem='" + sem + "',contact='" + contact + "',email = '" + semail + "' where stuid = " + rowid + "";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);


                ViewStudentInformation_Load(this,null);
            }

            

        }

        private void btn_viewStudent_Refresh_Click(object sender, EventArgs e)
        {
            ViewStudentInformation_Load(this, null);
        }

        private void button_Delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data will Be Deleted.Confirm?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Server=127.0.0.1;Database=library;User Id=root;Password=myPassword;";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "delete from NewStudent where stuid = "+rowid+"";
                SqlDataAdapter DA = new SqlDataAdapter(cmd);
                DataSet DS = new DataSet();
                DA.Fill(DS);


                ViewStudentInformation_Load(this, null);
            }

        }

        private void button_Cancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Unsaved Data will be Lost.", "Are You Sure?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
