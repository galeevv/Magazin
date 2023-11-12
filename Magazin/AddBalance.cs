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
    public partial class AddBalance : Form
    {
        public AddBalance()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (money.Text == "")
            {
                MessageBox.Show("Введите сумму!");
            }
            else
            {
                string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=shop;";

                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader = null;

                connection.Open();

                int a = Class1.Lls + Convert.ToInt32(money.Text);

                cmd.CommandText = $"UPDATE users SET balance = {a} WHERE id = {Class1.Wqe}";
                cmd.Connection = connection;
                reader = cmd.ExecuteReader();

                connection.Close();

                MessageBox.Show("Успешно зачислино на ваш аккаунт!");
                this.Hide();
            }
        }
    }
}
