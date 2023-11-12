using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Magazin
{
    public partial class adm_products : Form
    {
        public int a;
        public adm_products()
        {
            InitializeComponent();

            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=shop;";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader = null;

            connection.Open();

            cmd.CommandText = "SELECT * FROM products";
            cmd.Connection = connection;
            reader = cmd.ExecuteReader();

            while (reader.Read()) 
            {
                listBox1.Items.Add($"{reader.GetValue(0)}\t {reader.GetValue(1)}\t {reader.GetValue(2)}\t {reader.GetValue(3)}");
            }


            reader.Close();
            connection.Close();

            connection.Open();

            cmd.CommandText = "SELECT * FROM products";
            cmd.Connection = connection;
            reader = cmd.ExecuteReader();

            reader.Read();

            MessageBox.Show(Convert.ToString(reader.FieldCount));

            int aa = reader.FieldCount;

            for (int i = 0; i < aa; i += 1)
            {
                label1.Text += $"| {reader.GetName(i)} \t ";
            }

            reader.Close();
            connection.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form ifrm = new adm();
            ifrm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form ifrm = new AddP();
            ifrm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form ifrm = new Change();
            ifrm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form ifrm = new delete();
            ifrm.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=shop;";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader = null;

            connection.Open();

            cmd.CommandText = "SELECT * FROM products";
            cmd.Connection = connection;
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                listBox1.Items.Add($"{reader.GetValue(0)}\t {reader.GetValue(1)}\t {reader.GetValue(2)}\t {reader.GetValue(3)}");
            }


            reader.Close();
            connection.Close();
        }
    }
}
