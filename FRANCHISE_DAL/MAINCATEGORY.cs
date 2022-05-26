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
    public class MAINCATEGORY
    {
        public static ELL.MAINCATEGORY[] MainCategoryList()
        {
            List<ELL.MAINCATEGORY> MainCategory = new List<ELL.MAINCATEGORY>();
            SqlCommand kmt = new SqlCommand("PR_MAINCATEGORYLIST", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = kmt.ExecuteReader();
            while (dr.Read())
            {
                MainCategory.Add(MainCategoryLoad(dr));
            }
            return MainCategory.ToArray();
        }
        public static ELL.MAINCATEGORY MainCategoryLoad(SqlDataReader dr)
        {
            ELL.MAINCATEGORY MainCategory = new ELL.MAINCATEGORY()
            {
                MainCategoryID = Convert.ToInt32(dr["MAINCATEGORYID"]),
                MainCategoryName = Convert.ToString(dr["MAINCATEGORYNAME"]),
                MainCategoryCode = Convert.ToString(dr["MAINCATEGORYCODE"]),
                MainCategoryDescription = Convert.ToString(dr["MAINCATEGORYDESCRIPTION"]),
                MainCategoryState = Convert.ToString(dr["MAINCATEGORYSTATE"]),
            };
            if (MainCategory.MainCategoryState == "100")
            {
                MainCategory.MainCategoryState = "Aktif";
            }
            else MainCategory.MainCategoryState = "Pasif";

            return MainCategory;
        }
        public static ELL.MAINCATEGORY MainCategoryBring(int MainCategoryID)
        {
            SqlCommand kmt = new SqlCommand("PR_MAINCATEGORYBRING", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("MAINCATEGORYID", MainCategoryID);
            SqlDataReader dr = kmt.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                ELL.MAINCATEGORY MainCategory = new ELL.MAINCATEGORY()
                {
                    MainCategoryID = MainCategoryID,
                    MainCategoryName = Convert.ToString(dr["MAINCATEGORYNAME"]),
                    MainCategoryCode = Convert.ToString(dr["MAINCATEGORYCODE"]),
                    MainCategoryDescription = Convert.ToString(dr["MAINCATEGORYDESCRIPTION"]),
                    MainCategoryState = Convert.ToString(dr["MAINCATEGORYSTATE"])
                };
                return MainCategory;
            }
            else return null;
        }
        public static void AddMainCategory(ELL.MAINCATEGORY MainCategory)
        {
            SqlCommand kmt = new SqlCommand("PR_ADDMAINCATEGORY", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("MAINCATEGORYNAME", MainCategory.MainCategoryName);
            kmt.Parameters.AddWithValue("MAINCATEGORYCODE", MainCategory.MainCategoryCode);
            kmt.Parameters.AddWithValue("MAINCATEGORYDESCRIPTION", MainCategory.MainCategoryDescription);
            kmt.Parameters.AddWithValue("MAINCATEGORYSTATE", MainCategory.MainCategoryState);
            kmt.ExecuteNonQuery();
            CONNECTION.EndConnection(CONNECTION.getConnection());
        }
        public static void UpdateMainCategory(ELL.MAINCATEGORY MainCategory)
        {
            SqlCommand kmt = new SqlCommand("PR_UPDATEMAINCATEGORY", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("MAINCATEGORYNAME", MainCategory.MainCategoryName);
            kmt.Parameters.AddWithValue("MAINCATEGORYCODE", MainCategory.MainCategoryCode);
            kmt.Parameters.AddWithValue("MAINCATEGORYDESCRIPTION", MainCategory.MainCategoryDescription);
            kmt.Parameters.AddWithValue("MAINCATEGORYID", MainCategory.MainCategoryID);
            kmt.ExecuteNonQuery();
            CONNECTION.EndConnection(CONNECTION.getConnection());
        }
        public static void ChangeStateMainCategory(int MainCategoryID,string State)
        {
            SqlCommand kmt = new SqlCommand("PR_CHANGESTATEMAINCATEGORY", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("MAINCATEGORYID", MainCategoryID);
            kmt.Parameters.AddWithValue("MAINCATEGORYSTATE", State);
            kmt.ExecuteNonQuery();
            CONNECTION.EndConnection(CONNECTION.getConnection());
        }
        public static void DeleteMainCategory(int MainCategoryID)
        {
            SqlCommand kmt = new SqlCommand("PR_DELETEMAINCATEGORY", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("MAINCATEGORYID", MainCategoryID);
            kmt.ExecuteNonQuery();
            CONNECTION.EndConnection(CONNECTION.getConnection());
        }
    }
}
