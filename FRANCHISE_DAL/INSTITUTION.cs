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
    public class INSTITUTION
    {
        public static ELL.INSTITUTION InsBring(int InsID)
        {
            ELL.INSTITUTION Ins = new ELL.INSTITUTION();
            SqlCommand kmt = new SqlCommand("PR_INSBRING", CONNECTION.getConnection());
            kmt.Parameters.AddWithValue("INSID", InsID);
            kmt.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = kmt.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                Ins.InsID = InsID;
                Ins.InsName = Convert.ToString(dr["INSNAME"]);
                Ins.InsCode = Convert.ToString(dr["INSCODE"]);
                Ins.InsDescription = Convert.ToString(dr["INSDESCRIPTION"]);
                Ins.InsWeb = Convert.ToString(dr["INSWEB"]);
                Ins.InsMail = Convert.ToString(dr["INSMAIL"]);
                Ins.InsPhone = Convert.ToString(dr["INSPHONE"]);
                Ins.InsState = Convert.ToString(dr["INSSTATE"]);
                return Ins;
            }
            else return Ins;
        }
        public static void UpdateInstitution(ELL.INSTITUTION Ins)
        {
            SqlCommand kmt = new SqlCommand("PR_UPDATEINSTITUTION", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("INSNAME", Ins.InsName);
            kmt.Parameters.AddWithValue("INSCODE", Ins.InsCode);
            kmt.Parameters.AddWithValue("INSDESCRIPTION", Ins.InsDescription);
            kmt.Parameters.AddWithValue("INSWEB", Ins.InsWeb);
            kmt.Parameters.AddWithValue("INSPHONE", Ins.InsPhone);
            kmt.Parameters.AddWithValue("INSMAIL", Ins.InsMail);
            kmt.Parameters.AddWithValue("INSID", Ins.InsID);
        }
    }
}
