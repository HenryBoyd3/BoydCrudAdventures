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

namespace BoydCrudAdventures
{
    public partial class Products : Form
    {
        public Products()
        {
            InitializeComponent();
            GetDatabasedata.getProducts(dataGridView1);
        }

        private void customersToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            var cust = new Customers();
            this.Close();
            cust.Show();
        }

        private void homeToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            var home = new Form1();
            this.Close();
            home.Show();
        }

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is a view of all data to change pages select the page you want to go to.");
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}


