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
    public partial class AddBooks : Form
    {
        public AddBooks()
        {
            InitializeComponent();
        }

        private void save_btn_Click(object sender, EventArgs e)
        {
            if (bookname_txt.Text != "" && book_author_name_txt.Text != "" && book_publication_txt.Text != "" && book_price_txt.Text != "" && book_quantity_txt.Text != "")
            {

                String bookname = bookname_txt.Text;
                String bookauthor = book_author_name_txt.Text;
                String publication = book_publication_txt.Text;
                String pickdate = book_purchase_dateTimePicker.Text;
                Double price = Double.Parse(book_price_txt.Text);
                int quantity = int.Parse(book_quantity_txt.Text);

                SqlConnection con = new SqlConnection();
                //con.ConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=library;";
                con.ConnectionString = "Server=127.0.0.1;Database=library;User Id=root;Password=myPassword;";

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                con.Open();
                cmd.CommandText = "insert into newbook (bName,bAuthor,bPubl,bPdate,bPrice,bQuan) values ('" + bookname + "','" + bookauthor + "','" + publication + "','" + pickdate + "'," + price + "," + quantity + ")";
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Data Saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                bookname_txt.Clear();
                book_author_name_txt.Clear();
                book_publication_txt.Clear();
                book_price_txt.Clear();
                book_quantity_txt.Clear();

            }
            else
            {

                MessageBox.Show("Empty Field Not Allowed","Warning",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will DELETE your unsaved Data.", "Are you Sure? ", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
        }
    }
}
