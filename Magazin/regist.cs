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
    public partial class regist : Form
    {
        public regist()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (phone.Text == "" || pass.Text == "" || name.Text == "" || surname.Text == "")
            {
                MessageBox.Show("Заполните все пункты!");
            }
            else
            {
                string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=shop;";

                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader = null;

                connection.Open();

                cmd.CommandText = "SELECT * FROM users WHERE phone=" + "'" + this.phone.Text + "'";
                cmd.Connection = connection;
                reader = cmd.ExecuteReader();

                reader.Read();

                if (reader.HasRows)
                {
                    if (phone.Text == reader["phone"].ToString())
                    {
                        MessageBox.Show("Такой пользователь уже есть");
                        reader.Close();
                    }
                }
                else
                {
                    reader.Close();
                    cmd.CommandText = "INSERT Users VALUES " + "('" + phone.Text + "', '" + pass.Text + "', '" + name.Text + "', '" + surname.Text + "', '" + "1000" + "', '" + "false" + "', '" + "false" + "')";
                    cmd.Connection = connection;

                    int test = cmd.ExecuteNonQuery();

                    if (test >= 1)
                    {
                        connection.Close();
                        MessageBox.Show("Регистрация успешна");
                        Form ifrm = new Form1();
                        ifrm.Show();
                        this.Hide();
                    }
                    connection.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form ifrm = new Form1();
            ifrm.Show();
            this.Hide();
        }
    }
}
