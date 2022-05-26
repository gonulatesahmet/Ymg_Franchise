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
    public class DISCOUNT
    {
        public static ELL.DISCOUNT[] DisList()
        {
            List<ELL.DISCOUNT> Dis = new List<ELL.DISCOUNT>();
            SqlCommand kmt = new SqlCommand("PR_DISCOUNTLIST", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = kmt.ExecuteReader();
            while (dr.Read())
            {
                Dis.Add(DisLoad(dr));
            }
            return Dis.ToArray();
        }
        public static ELL.DISCOUNT DisLoad(SqlDataReader dr)
        {
            ELL.DISCOUNT Dis = new ELL.DISCOUNT()
            {
                DisID = Convert.ToInt32(dr["DISID"]),
                DisName = Convert.ToString(dr["DISNAME"]),
                DisCode = Convert.ToString(dr["DISCODE"]),
                DisDescription = Convert.ToString(dr["DISDESCRIPTION"]),
                DisRate = Convert.ToDecimal(dr["DISRATE"]),
                DisState = Convert.ToString(dr["DISSTATE"])
            };
            if (Dis.DisState == "100")
            {
                Dis.DisState = "Aktif";
            }
            else Dis.DisState = "Pasif";
            return Dis;
        }
        public static void AddDis(ELL.DISCOUNT Dis)
        {
            SqlCommand kmt = new SqlCommand("PR_ADDDISCOUNT", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("DISNAME", Dis.DisName);
            kmt.Parameters.AddWithValue("DISCODE", Dis.DisCode);
            kmt.Parameters.AddWithValue("DISDESCRIPTION", Dis.DisDescription);
            kmt.Parameters.AddWithValue("DISRATE", Dis.DisRate);
            kmt.Parameters.AddWithValue("DISSTATE", Dis.DisState);
            kmt.ExecuteNonQuery();
            CONNECTION.EndConnection(CONNECTION.getConnection());
        }
        public static void ChangeStateDis(int DisID,string State)
        {
            SqlCommand kmt = new SqlCommand("PR_CHANGESTATEDISCOUNT", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("DISID", DisID);
            kmt.Parameters.AddWithValue("DISSTATE", State);
            kmt.ExecuteNonQuery();
            CONNECTION.EndConnection(CONNECTION.getConnection());
        }
        public static void DeleteDis(int DisID)
        {
            SqlCommand kmt = new SqlCommand("PR_DELETEDISCOUNT", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("DISID", DisID);
            kmt.ExecuteNonQuery();
            CONNECTION.EndConnection(CONNECTION.getConnection());
        }
    }
}
