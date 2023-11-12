using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Magazin
{
    public partial class shop : Form
    {
        public int a;
        public int qq;
        public int aamm = 50;
        public int tt;
        public shop()
        {
            InitializeComponent();

            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=shop;";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader = null;

            if (Class1.Wqe == null)
            {
                MessageBox.Show("Режим просмотра товаров");
            }
            else
            {
                connection.Open();
                cmd.CommandText = $"SELECT balance FROM users WHERE id = {Class1.Wqe}";
                cmd.Connection = connection;
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    a = Convert.ToInt32(reader.GetValue(0));
                    balance.Text = Convert.ToString(a);
                    Class1.Lls = a;
                }

                reader.Close();
                connection.Close();
            }

            //reader.Close();

            connection.Open();

            cmd.CommandText = "SELECT nameProduct FROM products";
            cmd.Connection = connection;
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                comboBox1.Items.Add(reader.GetValue(0));
            }

            reader.Close();
            connection.Close();

            comboBox1.SelectedIndex = 0;

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (Class1.Wqe == null)
            {
                MessageBox.Show("Режим просмотра товаров, пожалуйста авторизуйтесь!");
            }
            else
            {
                int bb = Convert.ToInt32(balance.Text);

                if (bb <= 0 | qq > bb)
                {
                    MessageBox.Show("Пополните баланс");
                }
                else
                {
                    if (aamm<=0)
                    {
                        MessageBox.Show("Товар кончился((");
                    }
                    else
                    {
                        int qwee = bb - qq;
                        balance.Text = Convert.ToString(qwee);
                        Class1.Lls = qwee;

                        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=shop;";

                        SqlConnection connection = new SqlConnection(connectionString);
                        SqlCommand cmd = new SqlCommand();
                        SqlDataReader reader = null;

                        connection.Open();

                        cmd.CommandText = $"UPDATE users SET balance = {qwee} WHERE id = {Class1.Wqe}";
                        cmd.Connection = connection;
                        reader = cmd.ExecuteReader();

                        connection.Close();
                        connection.Open();

                        cmd.CommandText = $"SELECT * FROM products WHERE nameProduct = '{comboBox1.Text}'";
                        cmd.Connection = connection;
                        reader = cmd.ExecuteReader();
                        reader.Read();
                        string am = reader["amo"].ToString();
                        int asd = Convert.ToInt32(am) - 1;
                        aamm = asd;

                        reader.Close();
                        connection.Close();
                        connection.Open();

                        cmd.CommandText = $"UPDATE products SET amo = {asd}  WHERE nameProduct = '{comboBox1.Text}'";
                        cmd.Connection = connection;
                        reader = cmd.ExecuteReader();

                        amoo.Text = Convert.ToString(asd);

                        connection.Close();

                        listBox1.Items.Add($"{comboBox1.Text} (1)");


                    }
                }
            }            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBox1.Load($@"C:\Users\emil_\source\repos\Magazin\Magazin\Images\{Convert.ToString(comboBox1.Text)}.PNG");

            string ggg = Convert.ToString(comboBox1.Text);

            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=shop;";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader = null;

            connection.Open();

            cmd.CommandText = $"SELECT price FROM products WHERE nameProduct = '{Convert.ToString(comboBox1.Text)}'";
            cmd.Connection = connection;
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                price.Text = Convert.ToString(reader.GetValue(0) + "$");
                qq = Convert.ToInt32(reader.GetValue(0));
            }

            reader.Close();
            connection.Close();

            connection.Open();

            cmd.CommandText = $"SELECT * FROM products WHERE nameProduct = '{comboBox1.Text}'";
            cmd.Connection = connection;
            reader = cmd.ExecuteReader();
            reader.Read();
            string am = reader["amo"].ToString();
            amoo.Text = am;
            aamm = Convert.ToInt32(amoo.Text);

            reader.Close();
            connection.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (Class1.Wqe == null)
            {
                MessageBox.Show("Режим просмотра товаров, пожалуйста авторизуйтесь!");
            }
            else
            {
                Form ifrm = new AddBalance();
                ifrm.Show();

            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            if (Class1.Wqe == null)
            {
                MessageBox.Show("Режим просмотра товаров, пожалуйста авторизуйтесь!");
            }
            else
            {
                string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=shop;";

                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader = null;

                connection.Open();

                cmd.CommandText = $"SELECT balance FROM users WHERE id = {Class1.Wqe}";
                cmd.Connection = connection;
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    a = Convert.ToInt32(reader.GetValue(0));
                    balance.Text = Convert.ToString(a);
                }

                reader.Close();
                connection.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form ifrm = new Form1();
            ifrm.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            tt++;
            if (tt % 2 == 0)
            {
                listBox1.Visible = false;
            }
            else
            {
                listBox1.Visible = true;
            }
        }
    }
}
