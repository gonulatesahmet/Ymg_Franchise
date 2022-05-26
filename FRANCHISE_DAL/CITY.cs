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
    public class CITY
    {
        public static ELL.CITY[] CityList()
        {
            List<ELL.CITY> City = new List<ELL.CITY>();
            SqlCommand kmt = new SqlCommand("PR_CITYLIST", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = kmt.ExecuteReader();
            while (dr.Read())
            {
                City.Add(CityLoad(dr));
            }
            return City.ToArray();
        }
        public static ELL.CITY CityLoad(SqlDataReader dr)
        {
            ELL.CITY City = new ELL.CITY()
            {
                CityID = Convert.ToInt32(dr["CITYID"]),
                CityName = Convert.ToString(dr["CITYNAME"])
            };
            return City;
        }
    }
}
