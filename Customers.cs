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

        private void helpToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("to update a row find the cell you wish to edit double click that cell then enter the data you wish to update once you finish what you want to change click the update button." +
                "\n\nto add a row, go to the end of the list and select the row under the last filled row, enter all the data you need then click the insert button." +
                "\n\nunable to edit the address data before customerID 1000 due to old values not having correct data for addresses.");
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
