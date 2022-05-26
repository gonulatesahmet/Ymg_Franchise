using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ELL = FRANCHISE_ELL;
namespace FRANCHISE_DAL
{
    public class CONNECTION
    {
        static string connectionText = "Data Source=LAPTOP-0RHSUCH5\\SQLEXPRESS;Initial Catalog=FRANCHISE;Integrated Security=True";
        public static SqlConnection getConnection()
        {
            SqlConnection connection = new SqlConnection(connectionText);
            connection.Open();
            return connection;
        }
        public static void EndConnection(SqlConnection connection)
        {
            if (connection == null)
            {
                return;
            }
            if (connection.State != ConnectionState.Closed && connection.State != ConnectionState.Broken)
            {
                connection.Close();
            }
            connection.Dispose();
        }
    }
}
