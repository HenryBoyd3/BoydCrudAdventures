using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoydCrudAdventures
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void productsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var prod = new Products();
            this.Hide();
            prod.Show();

        }

        private void customersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var cust = new Customers();
            this.Hide();
            cust.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var prod = new Products();
            this.Hide();
            prod.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var cust = new Customers();
            this.Hide();
            cust.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
