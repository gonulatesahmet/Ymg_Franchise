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
    public class APPELLATION
    {
        public static ELL.APPELLATION[] AppellationList()
        {
            List<ELL.APPELLATION> Appellation = new List<ELL.APPELLATION>();
            SqlCommand kmt = new SqlCommand("PR_APPELLATIONLIST", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = kmt.ExecuteReader();
            while (dr.Read())
            {
                Appellation.Add(AppellationLoad(dr));
            }
            return Appellation.ToArray();
        }
        public static ELL.APPELLATION AppellationLoad(SqlDataReader dr)
        {
            ELL.APPELLATION Appellation = new ELL.APPELLATION()
            {
                AppellationID = Convert.ToInt32(dr["APPELLATIONID"]),
                AppellationName = Convert.ToString(dr["APPELLATIONNAME"]),
                AppellationCode = Convert.ToString(dr["APPELLATIONCODE"]),
                AppellationDescription = Convert.ToString(dr["APPELLATIONDESCRIPTION"]),
                AuthorityID = Convert.ToInt32(dr["AUTHORITYID"]),
                AuthorityName = Convert.ToString(dr["AUTHORITYNAME"]),
                AppellationState = Convert.ToString(dr["APPELLATIONSTATE"]),
            };
            if (Appellation.AppellationState == "100")
            {
                Appellation.AppellationState = "Aktif";
            }
            else Appellation.AppellationState = "Pasif";
            return Appellation;
        }
        public static ELL.APPELLATION AppellationBring(int AppellationID)
        {
            SqlCommand kmt = new SqlCommand("PR_APPELLATIONBRING", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("APPELLATIONID", AppellationID);
            SqlDataReader dr = kmt.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                ELL.APPELLATION Appellation = new ELL.APPELLATION()
                {
                    AppellationID = AppellationID,
                    AppellationName = Convert.ToString(dr["APPELLATIONNAME"]),
                    AppellationCode = Convert.ToString(dr["APPELLATIONCODE"]),
                    AppellationDescription = Convert.ToString(dr["APPELLATIONDESCRIPTION"]),
                    AuthorityID = Convert.ToInt32(dr["AUTHORITYID"]),
                    AppellationState = Convert.ToString(dr["APPELLATIONSTATE"]),
                };
                return Appellation;
            }
            else return null;
        }
        public static void AddAppellation(ELL.APPELLATION Appellation)
        {
            SqlCommand kmt = new SqlCommand("PR_ADDAPPELLATION", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("APPELLATIONNAME", Appellation.AppellationName);
            kmt.Parameters.AddWithValue("APPELLATIONCODE", Appellation.AppellationCode);
            kmt.Parameters.AddWithValue("APPELLATIONDESCRIPTION", Appellation.AppellationDescription);
            kmt.Parameters.AddWithValue("AUTHORITYID", Appellation.AuthorityID);
            kmt.Parameters.AddWithValue("APPELLATIONSTATE", Appellation.AppellationState);
            kmt.ExecuteNonQuery();
            CONNECTION.EndConnection(CONNECTION.getConnection());
        }
        public static void UpdateAppellation(ELL.APPELLATION Appellation)
        {
            SqlCommand kmt = new SqlCommand("PR_UPDATEAPPELLATION", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("APPELLATIONNAME", Appellation.AppellationName);
            kmt.Parameters.AddWithValue("APPELLATIONCODE", Appellation.AppellationCode);
            kmt.Parameters.AddWithValue("APPELLATIONDESCRIPTION", Appellation.AppellationDescription);
            kmt.Parameters.AddWithValue("AUTHORITYID", Appellation.AuthorityID);
            kmt.Parameters.AddWithValue("APPELLATIONID", Appellation.AppellationID);
            kmt.ExecuteNonQuery();
            CONNECTION.EndConnection(CONNECTION.getConnection());
        }
        public static void ChangeStateAppellation(int AppellationID, string State)
        {
            SqlCommand kmt = new SqlCommand("PR_CHANGESTATEAPPELLATION", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("APPELLATIONID", AppellationID);
            kmt.Parameters.AddWithValue("APPELLATIONSTATE", State);
            kmt.ExecuteNonQuery();
            CONNECTION.EndConnection(CONNECTION.getConnection());
        }
        public static void DeleteAppellation(int AppellationID)
        {
            SqlCommand kmt = new SqlCommand("PR_DELETEAPPELLATION", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("APPELLATIONID", AppellationID);
            kmt.ExecuteNonQuery();
            CONNECTION.EndConnection(CONNECTION.getConnection());
        }
    }
}
