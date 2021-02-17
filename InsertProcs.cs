using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BoydCrudAdventures
{
    class InsertProcs
    {
        public static void insertRow(RowData rd)
        {
            insertCustomers(rd);
            insertCustomersAddress(rd);
            getCurrentCustId(rd);
            getCurrentAddId(rd);
            updateAddress(rd);
        }

        private static void insertCustomers(RowData rd)
        {
            using (SqlConnection conn = new SqlConnection(DB.getConnection()))
            {
                SqlCommand cmd = new SqlCommand("InsertCustomers", conn);
                cmd.CommandType = CommandType.StoredProcedure;

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

        private static void insertCustomersAddress(RowData rd)
        {
            using (SqlConnection conn = new SqlConnection(DB.getConnection()))
            {
                SqlCommand cmd = new SqlCommand("InsertAddress", conn);
                cmd.CommandType = CommandType.StoredProcedure;
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
        //gets the current customer ID that was just made from the first stored procedure so not to cause an error
        private static void getCurrentCustId(RowData rd)
        {
            using (SqlConnection conn = new SqlConnection(DB.getConnection()))
            {

                SqlCommand cmd = new SqlCommand("getlastCustID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                rd.custID = dr.GetInt32(0);

            }
        }
        //gets the current address ID that was just made from the first stored procedure so not to cause an error
        private static void getCurrentAddId(RowData rd)
        {

            using (SqlConnection conn = new SqlConnection(DB.getConnection()))
            {

                SqlCommand cmd = new SqlCommand("getlastaddID", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();
                rd.addID = dr.GetInt32(0);

            }
        }

        private static void updateAddress(RowData rd)
        {
            using (SqlConnection conn = new SqlConnection(DB.getConnection()))
            {
                SqlCommand cmd = new SqlCommand("InsertCustomerAddress", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@custID", rd.custID);
                cmd.Parameters.AddWithValue("@addID", rd.addID);
                cmd.Parameters.AddWithValue("@addressType", rd.addType);
                cmd.Parameters.AddWithValue("@modifiedDate", rd.modDate);
                conn.Open();
                cmd.ExecuteNonQuery();
            }
            

        }
    }
}
