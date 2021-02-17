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
    public partial class Customers : Form
    {
        public Customers()
        {
            InitializeComponent();
            GetDatabasedata.getCustomers(dataGridView1);
        }


        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var home = new Form1();
            this.Close();
            home.Show();
        }

        private void productsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            var prod = new Products();
            this.Close();
            prod.Show();
        }

        private void RefreshCust_Click(object sender, EventArgs e)
        {
             GetDatabasedata.getCustomers(dataGridView1);
        }

        private void UpdateSQL_Click(object sender, EventArgs e)
        {

            dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Selected = true;
            RowData rd = new RowData(dataGridView1);
            UpdateProcs.updateRow(rd);
            GetDatabasedata.getCustomers(dataGridView1);

        }

        private void Insert_Click(object sender, EventArgs e)
        {           
            dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Selected = true;
            RowData rd = new RowData(dataGridView1);
            InsertProcs.insertRow(rd);
            GetDatabasedata.getCustomers(dataGridView1);
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Selected = true;
            DeleteProcs.deleteRow(dataGridView1);
            GetDatabasedata.getCustomers(dataGridView1);
        }
    }
}
