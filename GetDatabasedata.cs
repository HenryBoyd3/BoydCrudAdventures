using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BoydCrudAdventures
{
    class GetDatabasedata
    {
        public static DataGridView getProducts(DataGridView prodData)
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
                prodData.DataSource = tabel;
                prodData.AutoGenerateColumns = true;

            }
            return prodData;
        }
        public static DataGridView getCustomers(DataGridView custdata)
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
                custdata.DataSource = tabel;
                custdata.AutoGenerateColumns = true;
            }
            return custdata;
        }
    }
}
