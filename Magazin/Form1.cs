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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Class1.Wqe = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=shop;";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader = null;

            connection.Open();

            cmd.CommandText = "SELECT * FROM users WHERE phone=" + "'" + this.phone.Text + "'" + "AND pass=" + "'" + this.pass.Text + "'";
            cmd.Connection = connection;
            reader = cmd.ExecuteReader();

            reader.Read();

            if (reader.HasRows)
            {
                if (phone.Text == reader["phone"].ToString())
                {
                    if (reader["adm"].ToString() == "True")
                    {
                        MessageBox.Show($"Админ {reader["name"]}");
                        Form aifrm = new adm();
                        aifrm.Show();
                        this.Hide();
                    }
                    else if (reader["manager"].ToString() == "True")
                    {
                        MessageBox.Show($"Менеджер {reader["name"]}");
                        Form aifrm = new Manager();
                        aifrm.Show();
                        this.Hide();
                    }
                    else
                    {
                        Class1.Wqe = reader["id"].ToString();
                        MessageBox.Show("Авторизация успешна");
                        Form ifrm = new shop();
                        ifrm.Show();
                        this.Hide();
                    }                   
                }
                else
                {
                    MessageBox.Show("Ошибка 1");
                }
            }
            else
            {
                MessageBox.Show("Проверьте логин или пароль");
            }

            reader.Close();
            connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form qifrm = new regist();
            qifrm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form ifrm = new shop();
            ifrm.Show();
            this.Hide();
        }
    }
}
