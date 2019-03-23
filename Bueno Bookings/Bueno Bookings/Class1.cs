using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Bueno_Bookings
{
    internal static class GetSendData
    {
        public static DataTable GetData(string sqlStatement)
        {
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.cnnString);

            DataTable dt = new DataTable();
            using (conn)
            {
                using (SqlCommand cmd = new SqlCommand(sqlStatement, conn))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            return dt;
        }

        public static int SendData(string sqlStatement)
        {
            int rowsAffected;
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.cnnString))
            {
                using (SqlCommand cmd = new SqlCommand(sqlStatement, conn))
                {
                    conn.Open();
                    rowsAffected = cmd.ExecuteNonQuery();
                }
            }

            return rowsAffected;
        }

        public static object GetScalarValue(string sqlStmt)
        {
            object retVal;
            SqlConnection conn = new SqlConnection(Properties.Settings.Default.cnnString);

            using (conn)
            {
                SqlCommand cmd = new SqlCommand(sqlStmt, conn);
                conn.Open();
                retVal = cmd.ExecuteScalar();
                conn.Close();
            }

            return retVal;
        }
    }
}
