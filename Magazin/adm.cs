using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Magazin
{
    public partial class adm : Form
    {
        public adm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form ifrm = new adm_products();
            ifrm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form ifrm = new adm_users();
            ifrm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form ifrm = new Form1();
            ifrm.Show();
            this.Hide();
        }
    }
}
