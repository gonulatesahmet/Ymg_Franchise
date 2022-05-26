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
    public class CATEGORY
    {
        public static ELL.CATEGORY[] CategoryList()
        {
            List<ELL.CATEGORY> Category = new List<ELL.CATEGORY>();
            SqlCommand kmt = new SqlCommand("PR_CATEGORYLIST", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = kmt.ExecuteReader();
            while (dr.Read())
            {
                Category.Add(CategoryLoad(dr));
            }
            return Category.ToArray();
        }
        public static ELL.CATEGORY CategoryLoad(SqlDataReader dr)
        {
            ELL.CATEGORY Category = new ELL.CATEGORY()
            {
                CategoryID = Convert.ToInt32(dr["CATEGORYID"]),
                CategoryName = Convert.ToString(dr["CATEGORYNAME"]),
                CategoryCode = Convert.ToString(dr["CATEGORYCODE"]),
                CategoryDescription = Convert.ToString(dr["CATEGORYDESCRIPTION"]),
                MainCategoryID = Convert.ToInt32(dr["MAINCATEGORYID"]),
                MainCategoryName = Convert.ToString(dr["MAINCATEGORYNAME"]),
                CategoryState = Convert.ToString(dr["CATEGORYSTATE"])
            };
            if (Category.CategoryState == "100")
            {
                Category.CategoryState = "Aktif";
            }
            else Category.CategoryState = "Pasif";
            return Category;
        }
        public static ELL.CATEGORY CategoryBring(int CategoryID)
        {
            SqlCommand kmt = new SqlCommand("PR_CATEGORYBRING", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("CATEGORYID", CategoryID);
            SqlDataReader dr = kmt.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                ELL.CATEGORY Category = new ELL.CATEGORY()
                {
                    CategoryID = CategoryID,
                    CategoryName = Convert.ToString(dr["CATEGORYNAME"]),
                    CategoryCode = Convert.ToString(dr["CATEGORYCODE"]),
                    CategoryDescription = Convert.ToString(dr["CATEGORYDESCRIPTION"]),
                    MainCategoryID = Convert.ToInt32(dr["MAINCATEGORYID"]),
                    CategoryState = Convert.ToString(dr["CATEGORYSTATE"])
                };
                return Category;
            }
            else return null;
        }
        public static void AddCategory(ELL.CATEGORY Category)
        {
            SqlCommand kmt = new SqlCommand("PR_ADDCATEGORY", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("CATEGORYNAME", Category.CategoryName);
            kmt.Parameters.AddWithValue("CATEGORYCODE", Category.CategoryCode);
            kmt.Parameters.AddWithValue("CATEGORYDESCRIPTION", Category.CategoryDescription);
            kmt.Parameters.AddWithValue("MAINCATEGORYID", Category.MainCategoryID);
            kmt.Parameters.AddWithValue("CATEGORYSTATE", Category.CategoryState);
            kmt.ExecuteNonQuery();
            CONNECTION.EndConnection(CONNECTION.getConnection());
        }
        public static void UpdateCategory(ELL.CATEGORY Category)
        {
            SqlCommand kmt = new SqlCommand("PR_UPDATECATEGORY", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("CATEGORYNAME", Category.CategoryName);
            kmt.Parameters.AddWithValue("CATEGORYCODE", Category.CategoryCode);
            kmt.Parameters.AddWithValue("CATEGORYDESCRIPTION", Category.CategoryDescription);
            kmt.Parameters.AddWithValue("MAINCATEGORYID", Category.MainCategoryID);
            kmt.Parameters.AddWithValue("CATEGORYID", Category.CategoryID);
            kmt.ExecuteNonQuery();
            CONNECTION.EndConnection(CONNECTION.getConnection());
        }
        public static void ChangeStateCategory(int CategoryID,string State)
        {
            SqlCommand kmt = new SqlCommand("PR_CHANGESTATECATEGORY", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("CATEGORYID", CategoryID);
            kmt.Parameters.AddWithValue("CATEGORYSTATE", State);
            kmt.ExecuteNonQuery();
            CONNECTION.EndConnection(CONNECTION.getConnection());
        }
        public static void DeleteCategory(int CategoryID)
        {
            SqlCommand kmt = new SqlCommand("PR_DELETECATEGORY", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("CATEGORYID", CategoryID);
            kmt.ExecuteNonQuery();
            CONNECTION.EndConnection(CONNECTION.getConnection());
        }

        public static ELL.CATEGORY[] BoardCategoryList(int MainCategoryID)
        {
            List<ELL.CATEGORY> Category = new List<ELL.CATEGORY>();
            SqlCommand kmt = new SqlCommand("PR_BOARDCATEGORYLIST", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("MAINCATEGORYID", MainCategoryID);
            SqlDataReader dr = kmt.ExecuteReader();
            while (dr.Read())
            {
                Category.Add(CategoryLoad(dr));
            }
            return Category.ToArray();
        }
    }
}
