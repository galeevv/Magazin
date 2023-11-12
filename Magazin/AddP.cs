using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Magazin
{
    public partial class AddP : Form
    {
        public int qweq = 0;
        public AddP()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string copyR = $@"C:\Users\emil_\source\repos\Magazin\Magazin\Images\{namee.Text}.PNG";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = "c:";
            ofd.Filter = "Image Files (*.BMP, *.JPG, *.PNG)|*.jpg;*.bmp;*.png";
            ofd.FilterIndex = 2;
            ofd.RestoreDirectory = true;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                File.Move(ofd.FileName, copyR);
                qweq++;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (qweq > 0)
            {
                string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=shop;";

                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand();
                SqlDataReader reader = null;

                connection.Open();

                cmd.CommandText = "SELECT * FROM products WHERE nameProduct=" + "'" + this.namee.Text + "'";
                cmd.Connection = connection;
                reader = cmd.ExecuteReader();

                reader.Read();

                if (reader.HasRows)
                {
                    if (namee.Text == reader["nameProduct"].ToString())
                    {
                        MessageBox.Show("Такой товар уже есть");
                        reader.Close();
                    }
                }
                else
                {
                    reader.Close();
                    cmd.CommandText = "INSERT products VALUES " + "('" + namee.Text + "', '" + price.Text + "', '" + amo.Text + "')";
                    cmd.Connection = connection;

                    int test = cmd.ExecuteNonQuery();

                    if (test >= 1)
                    {
                        MessageBox.Show("Товар успешно добавлен");
                        connection.Close();
                        this.Hide();
                    }
                    connection.Close();
                }
            }
            else
            {
                MessageBox.Show("Загрузите фотографию!");
            }
        }
    }
}
