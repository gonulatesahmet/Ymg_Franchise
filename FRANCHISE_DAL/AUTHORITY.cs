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
    public class AUTHORITY
    {
        public static ELL.AUTHORITY[] AuthorityList()
        {
            List<ELL.AUTHORITY> Authority = new List<ELL.AUTHORITY>();
            SqlCommand kmt = new SqlCommand("PR_AUTHORITYLIST", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = kmt.ExecuteReader();
            while (dr.Read())
            {
                Authority.Add(AuthorityLoad(dr));
            }
            return Authority.ToArray();
        }





        public static ELL.AUTHORITY AuthorityLoad(SqlDataReader dr)
        {
            ELL.AUTHORITY Authority = new ELL.AUTHORITY()
            {
                AuthorityID = Convert.ToInt32(dr["AUTHORITYID"]),
                AuthorityName = Convert.ToString(dr["AUTHORITYNAME"]),
                AuthorityCode = Convert.ToString(dr["AUTHORITYCODE"]),
                AuthorityDescription = Convert.ToString(dr["AUTHORITYDESCRIPTION"]),
                AuthorityState = Convert.ToString(dr["AUTHORITYSTATE"])
            };
            if (Authority.AuthorityState == "100")
            {
                Authority.AuthorityState = "Aktif";
            }
            else
            {
                Authority.AuthorityState = "Pasif";
            }
            return Authority;
        }





        public static void AddAuthority(ELL.AUTHORITY Authority)
        {
            SqlCommand kmt = new SqlCommand("PR_ADDAUTHORITY", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("AUTHORITYNAME", Authority.AuthorityName);
            kmt.Parameters.AddWithValue("AUTHORITYCODE", Authority.AuthorityCode);
            kmt.Parameters.AddWithValue("AUTHORITYDESCRIPTION", Authority.AuthorityDescription);
            kmt.Parameters.AddWithValue("AUTHORITYSTATE", Authority.AuthorityState);
            kmt.ExecuteNonQuery();
            CONNECTION.EndConnection(CONNECTION.getConnection());
        }





        public static void UpdateAuthority(ELL.AUTHORITY Authority)
        {
            SqlCommand kmt = new SqlCommand("PR_UPDATEAUTHORITY", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("AUTHORITYNAME", Authority.AuthorityName);
            kmt.Parameters.AddWithValue("AUTHORITYCODE", Authority.AuthorityCode);
            kmt.Parameters.AddWithValue("AUTHORITYDESCRIPTION", Authority.AuthorityDescription);
            kmt.Parameters.AddWithValue("AUTHORITYID", Authority.AuthorityID);
            kmt.ExecuteNonQuery();
            CONNECTION.EndConnection(CONNECTION.getConnection());
        }





        public static void ChangeStateAuthority(int AuthorityID, string State)
        {
            SqlCommand kmt = new SqlCommand("PR_CHANGESTATEAUTHORITY", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("AUTHORITYID", AuthorityID);
            kmt.Parameters.AddWithValue("AUTHORITYSTATE", State);
            kmt.ExecuteNonQuery();
            CONNECTION.EndConnection(CONNECTION.getConnection());
        }





        public static void DeleteAuthority(int AuthorityID)
        {
            SqlCommand kmt = new SqlCommand("PR_DELETEAUTHORITY", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("AUTHORITYID", AuthorityID);
            kmt.ExecuteNonQuery();
            CONNECTION.EndConnection(CONNECTION.getConnection());
        }
    }
}
