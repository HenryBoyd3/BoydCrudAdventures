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
            getData();
        }



        private void Products_Load(object sender, EventArgs e)
        {
            getData();

        }
        private void getData()
        {
            using (SqlConnection conn = new SqlConnection(DB.getConnection()))
            {
                SqlCommand cmd = new SqlCommand("getProducts", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable tabel = new DataTable();
                da.Fill(tabel);
                BindingSource binding = new BindingSource();
                binding.DataSource = tabel;
                dataGridView1.DataSource = tabel;
                dataGridView1.AutoGenerateColumns = true;

            }

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



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}


