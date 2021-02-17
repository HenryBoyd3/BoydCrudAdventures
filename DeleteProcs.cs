using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace BoydCrudAdventures
{
    class DeleteProcs
    {
        public static void deleteRow(DataGridView dv) 
        {
            deleteRowProc(dv);
        }

        private static void deleteRowProc(DataGridView dv)
        {
            using (SqlConnection conn = new SqlConnection(DB.getConnection()))
            {
                var custID = dv.SelectedRows[0].Cells[0].Value;
                var addID = dv.SelectedRows[0].Cells[13].Value;
                SqlCommand cmd = new SqlCommand("DeleteCustomers", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@custID", custID);
                cmd.Parameters.AddWithValue("@addressID", addID);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
