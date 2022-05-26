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
    public class PRODUCT
    {
        public static ELL.PRODUCT[] ProductList()
        {
            List<ELL.PRODUCT> Product = new List<ELL.PRODUCT>();
            SqlCommand kmt = new SqlCommand("PR_PRODUCTLIST", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = kmt.ExecuteReader();
            while (dr.Read())
            {
                Product.Add(ProductLoad(dr));
            }
            return Product.ToArray();
        }
        public static ELL.PRODUCT ProductLoad(SqlDataReader dr)
        {
            ELL.PRODUCT Product = new ELL.PRODUCT()
            {
                ProductID = Convert.ToInt32(dr["PRODUCTID"]),
                ProductName = Convert.ToString(dr["PRODUCTNAME"]),
                ProductCode = Convert.ToString(dr["PRODUCTCODE"]),
                ProductDescription = Convert.ToString(dr["PRODUCTDESCRIPTION"]),
                ProductPrice = Convert.ToDecimal(dr["PRODUCTPRICE"]),
                StockStatus = Convert.ToString(dr["STOCKSTATUS"]),
                ProductImage = (byte[])(dr["PRODUCTIMAGE"]),
                CategoryID = Convert.ToInt32(dr["CATEGORYID"]),
                CategoryName = Convert.ToString(dr["CATEGORYNAME"]),
                ProductState = Convert.ToString(dr["PRODUCTSTATE"])
            };
            if(Product.StockStatus == "100")
            {
                Product.StockStatus = "Sayılabilir";
            }
            else
            {
                Product.StockStatus = "Sayılamaz";
            }
            if(Product.ProductState == "100")
            {
                Product.ProductState = "Aktif";
            }
            else
            {
                Product.ProductState = "Pasif";
            }
            return Product;
        }
        public static ELL.PRODUCT ProductBring(int ProductID)
        {
            SqlCommand kmt = new SqlCommand("PR_PRODUCTBRING", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("PRODUCTID", ProductID);
            SqlDataReader dr = kmt.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                ELL.PRODUCT Product = new ELL.PRODUCT()
                {
                    ProductID = ProductID,
                    ProductName = Convert.ToString(dr["PRODUCTNAME"]),
                    ProductCode = Convert.ToString(dr["PRODUCTCODE"]),
                    ProductDescription = Convert.ToString(dr["PRODUCTDESCRIPTION"]),
                    ProductPrice = Convert.ToDecimal(dr["PRODUCTPRICE"]),
                    StockStatus = Convert.ToString(dr["STOCKSTATUS"]),
                    ProductImage = (byte[])(dr["PRODUCTIMAGE"]),
                    CategoryID = Convert.ToInt32(dr["CATEGORYID"]),
                    ProductState = Convert.ToString(dr["PRODUCTSTATE"])
                };
                if(Product.StockStatus == "100")
                {
                    Product.StockStatus = "Sayılabilir";
                }
                else
                {
                    Product.StockStatus = "Sayılamaz";
                }
                return Product;
            }
            else return null;
        }
        public static void AddProduct(ELL.PRODUCT Product)
        {
            SqlCommand kmt = new SqlCommand("PR_ADDPRODUCT", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("PRODUCTNAME", Product.ProductName);
            kmt.Parameters.AddWithValue("PRODUCTCODE", Product.ProductCode);
            kmt.Parameters.AddWithValue("PRODUCTDESCRIPTION", Product.ProductDescription);
            kmt.Parameters.AddWithValue("PRODUCTPRICE", Product.ProductPrice);
            kmt.Parameters.AddWithValue("STOCKSTATUS", Product.StockStatus);
            kmt.Parameters.AddWithValue("PRODUCTIMAGE", Product.ProductImage);
            kmt.Parameters.AddWithValue("CATEGORYID", Product.CategoryID);
            kmt.Parameters.AddWithValue("PRODUCTSTATE", Product.ProductState);
            kmt.ExecuteNonQuery();
            CONNECTION.EndConnection(CONNECTION.getConnection());
        }
        public static void UpdateProduct(ELL.PRODUCT Product)
        {
            SqlCommand kmt = new SqlCommand("PR_UPDATEPRODUCT", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("PRODUCTNAME", Product.ProductName);
            kmt.Parameters.AddWithValue("PRODUCTCODE", Product.ProductCode);
            kmt.Parameters.AddWithValue("PRODUCTDESCRIPTION", Product.ProductDescription);
            kmt.Parameters.AddWithValue("PRODUCTPRICE", Product.ProductPrice);
            kmt.Parameters.AddWithValue("STOCKSTATUS", Product.StockStatus);
            kmt.Parameters.AddWithValue("CATEGORYID", Product.CategoryID);
            kmt.Parameters.AddWithValue("PRODUCTID", Product.ProductID);
            kmt.ExecuteNonQuery();
            CONNECTION.EndConnection(CONNECTION.getConnection());
        }
        public static void ChangeStateProduct(int ProductID,string State)
        {
            SqlCommand kmt = new SqlCommand("PR_CHANGESTATEPRODUCT", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("PRODUCTID", ProductID);
            kmt.Parameters.AddWithValue("PRODUCTSTATE", State);
            kmt.ExecuteNonQuery();
            CONNECTION.EndConnection(CONNECTION.getConnection());
        }
        public static void DeleteProduct(int ProductID)
        {
            SqlCommand kmt = new SqlCommand("PR_DELETEPRODUCT", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("PRODUCTID", ProductID);
            kmt.ExecuteNonQuery();
            CONNECTION.EndConnection(CONNECTION.getConnection());
        }
        public static void UpdateImageProduct(int ProductID, byte[] ProductImage)
        {
            SqlCommand kmt = new SqlCommand("PR_UPDATEIMAGEPRODUCT", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("PRODUCTID", ProductID);
            kmt.Parameters.AddWithValue("PRODUCTIMAGE", ProductImage);
            kmt.ExecuteNonQuery();
            CONNECTION.EndConnection(CONNECTION.getConnection());
        }




        public static ELL.PRODUCT[] NewProductStockList(int BranchID)
        {
            List<ELL.PRODUCT> Product = new List<ELL.PRODUCT>();
            SqlCommand kmt = new SqlCommand("PR_NEWPRODUCTSTOCKLIST", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("BRANCHID", BranchID);
            SqlDataReader dr = kmt.ExecuteReader();
            while (dr.Read())
            {
                Product.Add(ProductLoad(dr));
            }
            return Product.ToArray();
        }


        public static ELL.PRODUCT[] BoardProductList(int CategoryID)
        {
            List<ELL.PRODUCT> Product = new List<ELL.PRODUCT>();
            SqlCommand kmt = new SqlCommand("PR_BOARDPRODUCTLIST", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("CATEGORYID", CategoryID);
            SqlDataReader dr = kmt.ExecuteReader();
            while (dr.Read())
            {
                Product.Add(ProductLoad(dr));
            }
            return Product.ToArray();
        }
    }
}
