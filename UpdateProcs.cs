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
    class UpdateProcs
    {
        public static void updateRow(RowData rd)
        {
            updateCustomers(rd);
            updateCustomersAddress(rd);
            updateAddress(rd);
        }
        private static void updateCustomers(RowData rd)
        {

            using (SqlConnection conn = new SqlConnection(DB.getConnection()))
            {
                SqlCommand cmd = new SqlCommand("UpdateCustomers", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@custID", rd.custID);
                cmd.Parameters.AddWithValue("@Title", rd.title);
                cmd.Parameters.AddWithValue("@firstName", rd.firstName);
                cmd.Parameters.AddWithValue("@lastName", rd.lastName);
                cmd.Parameters.AddWithValue("@middleName", rd.middleName);
                cmd.Parameters.AddWithValue("@suffix", rd.suffex);
                cmd.Parameters.AddWithValue("@companyName", rd.companyName);
                cmd.Parameters.AddWithValue("@salesPerson", rd.salesPerson);
                cmd.Parameters.AddWithValue("@emailAddress", rd.email);
                cmd.Parameters.AddWithValue("@phone", rd.phone);
                cmd.Parameters.AddWithValue("@PasswordHash", rd.passhash);
                cmd.Parameters.AddWithValue("@PasswordSalt", rd.passSalt);
                cmd.Parameters.AddWithValue("@modifydate", rd.modDate);
                conn.Open();
                cmd.ExecuteNonQuery();
            }

        }
        private static void updateCustomersAddress(RowData rd) 
        {
            using (SqlConnection conn = new SqlConnection(DB.getConnection()))
            {
                SqlCommand cmd = new SqlCommand("updateCustomerAddress", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@customerID", rd.custID);
                cmd.Parameters.AddWithValue("@addressID", rd.addID);
                cmd.Parameters.AddWithValue("@addressType", rd.addType);
                cmd.Parameters.AddWithValue("@modifiedDate", rd.modDate);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
        private static void updateAddress(RowData rd)
        {
            using (SqlConnection conn = new SqlConnection(DB.getConnection()))
            {
                SqlCommand cmd = new SqlCommand("updateAddress", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@addressID", rd.addID);
                cmd.Parameters.AddWithValue("@addressLine1", rd.addLine1);
                cmd.Parameters.AddWithValue("@addressLine2", rd.addLine2);
                cmd.Parameters.AddWithValue("@city", rd.city);
                cmd.Parameters.AddWithValue("@stateProvince", rd.stateProv);
                cmd.Parameters.AddWithValue("@countryRegion", rd.country);
                cmd.Parameters.AddWithValue("@postalCode", rd.postalc);
                cmd.Parameters.AddWithValue("@modifiedDate", rd.modDate);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

    }
}
