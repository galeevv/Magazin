using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Magazin
{
    public partial class Change : Form
    {
        public int qq;
        public Change()
        {
            InitializeComponent();

            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=shop;";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader = null;

            connection.Open();

            cmd.CommandText = "SELECT nameProduct FROM products";
            cmd.Connection = connection;
            reader = cmd.ExecuteReader();

            int aa = reader.FieldCount;

            while (reader.Read()) // построчно считываем данные
            {

                for (int i = 0; i < aa; i += 1)
                {
                    comboBox1.Items.Add(reader.GetValue(i));
                }

            }
            reader.Close();
            connection.Close();
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=shop;";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            connection.Open();

            cmd.CommandText = "SELECT * FROM products WHERE nameProduct=" + "'" + this.namee.Text + "'";
            cmd.Connection = connection;

            cmd.CommandText = $"UPDATE products SET nameProduct = '{namee.Text}', price = '{price.Text}', amo = '{amo.Text}' WHERE nameProduct = '{Convert.ToString(comboBox1.Text)}'";
            cmd.Connection = connection;

            int test = cmd.ExecuteNonQuery();

            if (test >= 1)
            {
                MessageBox.Show("Товар успешно изменен");
                connection.Close();
                this.Hide();
            }
            connection.Close();

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox1.Load($@"C:\Users\emil_\source\repos\Magazin\Magazin\Images\{Convert.ToString(comboBox1.Text)}.PNG");

            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=shop;";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader = null;

            connection.Open();

            cmd.CommandText = $"SELECT * FROM products WHERE nameProduct = '{Convert.ToString(comboBox1.Text)}'";
            cmd.Connection = connection;
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                amo.Text = Convert.ToString(reader["amo"]);
                namee.Text = Convert.ToString(reader["nameProduct"]);
                price.Text = Convert.ToString(reader["price"]);
                qq = Convert.ToInt32(reader.GetValue(0));
            }

            reader.Close();
            connection.Close();
        }
    }
}
