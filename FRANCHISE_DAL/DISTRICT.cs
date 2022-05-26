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
    public class DISTRICT
    {
        public static ELL.DISTRICT[] DistrictList(int CityID)
        {
            List<ELL.DISTRICT> District = new List<ELL.DISTRICT>();
            SqlCommand kmt = new SqlCommand("PR_DISTRICTLIST", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("CITYID", CityID);
            SqlDataReader dr = kmt.ExecuteReader();
            while (dr.Read())
            {
                District.Add(DistrictLoad(dr));
            }
            return District.ToArray();
        }
        public static ELL.DISTRICT DistrictLoad(SqlDataReader dr)
        {
            ELL.DISTRICT District = new ELL.DISTRICT()
            {
                DistrictID = Convert.ToInt32(dr["DISTRICTID"]),
                DistrictName = Convert.ToString(dr["DISTRICTNAME"]),
                CityID = Convert.ToInt32(dr["CITYID"])
            };
            return District;
        }
    }
}
