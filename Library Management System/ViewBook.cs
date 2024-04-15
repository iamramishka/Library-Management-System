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
    public partial class ViewBook : Form
    {
        public ViewBook()
        {
            InitializeComponent();
        }

        private void ViewBook_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Server=127.0.0.1;Database=library;User Id=root;Password=myPassword;";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from newbook";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];

        }
        int bid;
        Int64 rowid;
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                bid = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                //MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());

            }
            panel2.Visible = true;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Server=127.0.0.1;Database=library;User Id=root;Password=myPassword;";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from newbook where bid" + bid + "";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            rowid = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());

            book_name_txt.Text = ds.Tables[0].Rows[0][1].ToString();
            book_author_name_txt.Text = ds.Tables[0].Rows[0][2].ToString();
            book_publication_txt.Text = ds.Tables[0].Rows[0][3].ToString();
            dateTimePicker1.Text = ds.Tables[0].Rows[0][4].ToString();
            book_price_txt.Text = ds.Tables[0].Rows[0][5].ToString();
            book_quantity_txt.Text = ds.Tables[0].Rows[0][6].ToString();

        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void bookname_txt_TextChanged(object sender, EventArgs e)
        {
            if (bookname_txt.Text != "")
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Server=127.0.0.1;Database=library;User Id=root;Password=myPassword;";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from newbook where bName LIKE'" + bookname_txt + "%'";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];

            }
            else
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Server=127.0.0.1;Database=library;User Id=root;Password=myPassword;";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from newbook";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView1.DataSource = ds.Tables[0];


            }
        }

        private void refresh_btn_Click(object sender, EventArgs e)
        {
            bookname_txt.Clear();
            panel2.Visible = false;
        }

        private void update_btn_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Data Will be Updated. Confirm?", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                String bname = book_name_txt.Text;
                String bauthor = book_author_name_txt.Text;
                String publication = book_publication_txt.Text;
                String pdate = dateTimePicker1.Text;
                Int64 price = Int64.Parse(book_price_txt.Text);
                Int64 quan = Int64.Parse(book_quantity_txt.Text);

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Server=127.0.0.1;Database=library;User Id=root;Password=myPassword;";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "update newbook set bName ='" + bname + "' , bAuthor='" + bauthor + "'  ,bPubl='" + publication + "',bPdate = '" + pdate + "' ,bPrice	= " + price + " ,	bQuan  = " + quan + " where bid ="+rowid+"";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
            }
        }

        private void delete_btn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Data Will be Deleted. Confirm?", "Confirmation Dialog", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "Server=127.0.0.1;Database=library;User Id=root;Password=myPassword;";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "delete from newbook where bid = "+rowid+"";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
            }
        }
    }
}
