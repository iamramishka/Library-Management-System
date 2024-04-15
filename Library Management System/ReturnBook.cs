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
    public partial class ReturnBook : Form
    {
        public ReturnBook()
        {
            InitializeComponent();
        }

        private void search_student_btn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Server=127.0.0.1;Database=library;User Id=root;Password=myPassword;";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            //con.Open();

            //cmd = new SqlCommand("select bName from NewBook", con);
            //SqlDataReader Sdr = cmd.ExecuteReader();
            cmd.CommandText = "select * from IRBook where std_enroll = '" + search_student_txt.Text + "' and book_return_date IS NULL";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count != 0)
            {
                dataGridView1.DataSource = ds.Tables[0];
            }
            else
            {
                MessageBox.Show("Invalid ID or No Book Issued","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }


        }

        private void ReturnBook_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
            search_student_txt.Clear();
        }

        String bname;
        String bdate;
        Int64 rowid;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            panel2.Visible = true;

            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                rowid = Int64.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                bname = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
                bdate = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            
            }
            book_name_txt.Text = bname;
            book_issue_txt.Text = bdate;

        }

        private void return_btn_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Server=127.0.0.1;Database=library;User Id=root;Password=myPassword;";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            con.Open();

            cmd.CommandText = "update IRBook set book_return_date = '" + return_dateTimePicker.Text + "' where std_enroll = '" + search_student_txt.Text + "' and id = " +rowid+"";
            cmd.ExecuteNonQuery();
            con.Close();


            MessageBox.Show("Return Sucessfull.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            ReturnBook_Load(this,null);
        }

        private void search_student_txt_TextChanged(object sender, EventArgs e)
        {
            if (search_student_txt.Text == "")
            {
                panel2.Visible = false;
                dataGridView1.DataSource = null;
            
            }

        }

        private void refresh_btn_Click(object sender, EventArgs e)
        {
            search_student_txt.Clear();
        }

        private void exit_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }
    }
}
