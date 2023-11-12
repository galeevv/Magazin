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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Magazin
{
    public partial class adm_users : Form
    {
        public adm_users()
        {
            InitializeComponent();

            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=shop;";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader = null;

            connection.Open();

            cmd.CommandText = "SELECT phone FROM users";
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

        private void button3_Click(object sender, EventArgs e)
        {
            Form ifrm = new adm();
            ifrm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=shop;";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            connection.Open();

            cmd.CommandText = $"DELETE FROM users WHERE phone = '{Convert.ToString(comboBox1.Text)}'";
            cmd.Connection = connection;

            int test = cmd.ExecuteNonQuery();

            if (test >= 1)
            {
                MessageBox.Show("Человечик успешно удален");
                connection.Close();
            }
            connection.Close();





            comboBox1.Items.Clear();

            SqlDataReader reader = null;

            connection.Open();

            cmd.CommandText = "SELECT phone FROM users";
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

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=shop;";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();

            connection.Open();

            cmd.CommandText = $"UPDATE users SET phone = '{phone.Text}', pass = '{pass.Text}', name = '{namee.Text}', surname = '{surname.Text}', balance = '{balance.Text}', adm = '{adm.Text}', manager = '{manager.Text}' WHERE phone = '{Convert.ToString(comboBox1.Text)}'";
            cmd.Connection = connection;

            int test = cmd.ExecuteNonQuery();

            if (test >= 1)
            {
                MessageBox.Show("Человечик успешно изменен");
                connection.Close();
            }
            connection.Close();





            comboBox1.Items.Clear();

            SqlDataReader reader = null;

            connection.Open();

            cmd.CommandText = "SELECT phone FROM users";
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
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=shop;";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader = null;

            connection.Open();

            cmd.CommandText = $"SELECT * FROM users WHERE phone = '{Convert.ToString(comboBox1.Text)}'";
            cmd.Connection = connection;
            reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                phone.Text = Convert.ToString(reader["phone"]);
                pass.Text = Convert.ToString(reader["pass"]);
                namee.Text = Convert.ToString(reader["name"]);
                surname.Text = Convert.ToString(reader["surname"]);
                balance.Text = Convert.ToString(reader["balance"]);
                adm.Text = Convert.ToString(reader["adm"]);
                manager.Text = Convert.ToString(reader["manager"]);
            }

            reader.Close();
            connection.Close();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();

            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=shop;";

            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand();
            SqlDataReader reader = null;

            connection.Open();

            cmd.CommandText = "SELECT phone FROM users";
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

            MessageBox.Show("Данные успешно обновлены!");
            comboBox1.SelectedIndex = 0;
        }
    }
}
