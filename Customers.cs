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
            getData();

        }

        private void Customers_Load(object sender, EventArgs e)
        {


        }
        private void getData()
        {
            using (SqlConnection conn = new SqlConnection(DB.getConnection()))
            {
                SqlCommand cmd = new SqlCommand("GetCustomers", conn);
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void RefreshCust_Click(object sender, EventArgs e)
        {
            getData();         


        }
        //this is to do everything through code

        private void UpdateSQL_Click(object sender, EventArgs e)
        {

            dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Selected = true;
            
                string a = string.Empty;
                var custID = dataGridView1.SelectedRows[0].Cells[0].Value;
                var addID = dataGridView1.SelectedRows[0].Cells[12].Value;
                string title = a, firstName = a, middleName = a, lastName = a, suffex = a, companyName = a, salesPerson = a, email = a, phone = a, passhash = a;
                string passSalt = a, addId = a, addType = a, addLine1 = a, addLine2 = a, city = a, stateProv = a, country = a, postalc = a, rowguid = a, modDate = a;
                var currect = dataGridView1.SelectedRows;
                foreach (DataGridViewRow cell in currect)
                {

                title = cell.Cells[1].Value.ToString();
                firstName = cell.Cells[2].Value.ToString();
                middleName = cell.Cells[3].Value.ToString();
                lastName = cell.Cells[4].Value.ToString();
                suffex = cell.Cells[5].Value.ToString();
                companyName = cell.Cells[6].Value.ToString();
                salesPerson = cell.Cells[7].Value.ToString();
                email = cell.Cells[8].Value.ToString();
                phone = cell.Cells[9].Value.ToString();
                passhash = cell.Cells[10].Value.ToString();
                passSalt = cell.Cells[11].Value.ToString();
                addType = cell.Cells[13].Value.ToString();
                addLine1 = cell.Cells[14].Value.ToString();
                addLine2 = cell.Cells[15].Value.ToString();
                city = cell.Cells[16].Value.ToString();
                stateProv = cell.Cells[17].Value.ToString();
                country = cell.Cells[18].Value.ToString();
                postalc = cell.Cells[19].Value.ToString();
                modDate = cell.Cells[21].Value.ToString();
            }

                using (SqlConnection conn = new SqlConnection(DB.getConnection()))
                {
                    SqlCommand cmd = new SqlCommand("UpdateCustomers", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@custID", custID);
                    cmd.Parameters.AddWithValue("@Title", title);
                    cmd.Parameters.AddWithValue("@firstName", firstName);
                    cmd.Parameters.AddWithValue("@lastName", lastName);
                    cmd.Parameters.AddWithValue("@middleName", middleName);
                    cmd.Parameters.AddWithValue("@suffix", suffex);
                    cmd.Parameters.AddWithValue("@companyName", companyName);
                    cmd.Parameters.AddWithValue("@salesPerson", salesPerson);
                    cmd.Parameters.AddWithValue("@emailAddress", email);
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@PasswordHash", passhash);
                    cmd.Parameters.AddWithValue("@PasswordSalt", passSalt);
                    cmd.Parameters.AddWithValue("@modifydate", modDate);
                    conn.Open();
                    cmd.ExecuteNonQuery();

                }
                using (SqlConnection conn = new SqlConnection(DB.getConnection()))
                {
                    SqlCommand cmd = new SqlCommand("updateCustomerAddress", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@customerID", custID);
                    cmd.Parameters.AddWithValue("@addressID", addId);
                    cmd.Parameters.AddWithValue("@addressType", addType);
                    cmd.Parameters.AddWithValue("@modifiedDate", modDate);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                using (SqlConnection conn = new SqlConnection(DB.getConnection()))
                {
                    SqlCommand cmd = new SqlCommand("updateAddress", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@addressID", addId);
                    cmd.Parameters.AddWithValue("@addressLine1", addLine1);
                    cmd.Parameters.AddWithValue("@addressLine2", addLine2);
                    cmd.Parameters.AddWithValue("@city", city);
                    cmd.Parameters.AddWithValue("@stateProvince", stateProv);
                    cmd.Parameters.AddWithValue("@countryRegion", country);
                    cmd.Parameters.AddWithValue("@postalCode", postalc);
                    cmd.Parameters.AddWithValue("@modifiedDate", modDate);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                getData();

        }

        private void Insert_Click(object sender, EventArgs e)
        {

            dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Selected = true;
          var bob =  dataGridView1.Rows;
            string a = string.Empty;
                var custID = dataGridView1.SelectedRows[0].Cells[0].Value;
                var addID = dataGridView1.SelectedRows[0].Cells[12].Value;
                string title = a, firstName = a, middleName = a, lastName = a, suffex = a, companyName = a, salesPerson = a, email = a, phone = a, passhash = a;
                string passSalt = a, addId = a, addType = a, addLine1 = a, addLine2 = a, city = a, stateProv = a, country = a, postalc = a, rowguid = a, modDate = a;
                var currect = dataGridView1.SelectedRows;
                foreach (DataGridViewRow cell in currect)
                {

                    title = cell.Cells[1].Value.ToString();
                    firstName = cell.Cells[2].Value.ToString();
                    middleName = cell.Cells[3].Value.ToString();
                    lastName = cell.Cells[4].Value.ToString();
                    suffex = cell.Cells[5].Value.ToString();
                    companyName = cell.Cells[6].Value.ToString();
                    salesPerson = cell.Cells[7].Value.ToString();
                    email = cell.Cells[8].Value.ToString();
                    phone = cell.Cells[9].Value.ToString();
                    passhash = cell.Cells[10].Value.ToString();
                    passSalt = cell.Cells[11].Value.ToString();
                    addType = cell.Cells[13].Value.ToString();
                    addLine1 = cell.Cells[14].Value.ToString();
                    addLine2 = cell.Cells[15].Value.ToString();
                    city = cell.Cells[16].Value.ToString();
                    stateProv = cell.Cells[17].Value.ToString();
                    country = cell.Cells[18].Value.ToString();
                    postalc = cell.Cells[19].Value.ToString();
                    modDate = cell.Cells[21].Value.ToString();
                }
                using (SqlConnection conn = new SqlConnection(DB.getConnection()))
                {
                    SqlCommand cmd = new SqlCommand("InsertCustomers", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Title", title);
                    cmd.Parameters.AddWithValue("@firstName", firstName);
                    cmd.Parameters.AddWithValue("@lastName", lastName);
                    cmd.Parameters.AddWithValue("@middleName", middleName);
                    cmd.Parameters.AddWithValue("@suffix", suffex);
                    cmd.Parameters.AddWithValue("@companyName", companyName);
                    cmd.Parameters.AddWithValue("@salesPerson", salesPerson);
                    cmd.Parameters.AddWithValue("@emailAddress", email);
                    cmd.Parameters.AddWithValue("@phone", phone);
                    cmd.Parameters.AddWithValue("@PasswordHash", passhash);
                    cmd.Parameters.AddWithValue("@PasswordSalt", passSalt);
                    cmd.Parameters.AddWithValue("@modifydate", modDate);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                using (SqlConnection conn = new SqlConnection(DB.getConnection()))
                {
                    SqlCommand cmd = new SqlCommand("InsertAddress", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@addressLine1", addLine1);
                    cmd.Parameters.AddWithValue("@addressLine2", addLine2);
                    cmd.Parameters.AddWithValue("@city", city);
                    cmd.Parameters.AddWithValue("@stateProvince", stateProv);
                    cmd.Parameters.AddWithValue("@countryRegion", country);
                    cmd.Parameters.AddWithValue("@postalCode", postalc);
                    cmd.Parameters.AddWithValue("@modifiedDate", modDate);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                //"getlastCustID"
                using (SqlConnection conn = new SqlConnection(DB.getConnection()))
                {

                    SqlCommand cmd = new SqlCommand("getlastCustID", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    custID = dr.GetInt32(0);

                }
                using (SqlConnection conn = new SqlConnection(DB.getConnection()))
                {

                    SqlCommand cmd = new SqlCommand("getlastaddID", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();
                    addID = dr.GetInt32(0);

                }
                using (SqlConnection conn = new SqlConnection(DB.getConnection()))
                {

                    dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                    SqlCommand cmd = new SqlCommand("InsertCustomerAddress", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@custID", custID);
                    cmd.Parameters.AddWithValue("@addID", addID);
                    cmd.Parameters.AddWithValue("@addressType", addType);
                    cmd.Parameters.AddWithValue("@modifiedDate", modDate);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
                getData();
            

        }

        private void Delete_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Selected = true;
            using (SqlConnection conn = new SqlConnection(DB.getConnection()))
                {
                    var custID = dataGridView1.SelectedRows[0].Cells[0].Value;
                    var addID = dataGridView1.SelectedRows[0].Cells[13].Value;
                    SqlCommand cmd = new SqlCommand("DeleteCustomers", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@custID", custID);
                    cmd.Parameters.AddWithValue("@addressID", addID);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }

                getData();
        }
    }
}
