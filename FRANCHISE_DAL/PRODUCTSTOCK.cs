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
    public class PRODUCTSTOCK
    {
        public static ELL.PRODUCTSTOCK[] ProductStockList(int BranchID)
        {
            List<ELL.PRODUCTSTOCK> ProductStock = new List<ELL.PRODUCTSTOCK>();
            SqlCommand kmt = new SqlCommand("PR_PRODUCTSTOCKLIST", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("BRANCHID", BranchID);
            SqlDataReader dr = kmt.ExecuteReader();
            while (dr.Read())
            {
                ProductStock.Add(ProductStockLoad(dr));
            }
            return ProductStock.ToArray();
        }
        public static ELL.PRODUCTSTOCK ProductStockLoad(SqlDataReader dr)
        {
            ELL.PRODUCTSTOCK ProductStock = new ELL.PRODUCTSTOCK()
            {
                BranchID = Convert.ToInt32(dr["BRANCHID"]),
                ProductStockID = Convert.ToInt32(dr["PRODUCTSTOCKID"]),
                ProductID = Convert.ToInt32(dr["PRODUCTID"]),
                ProductName = Convert.ToString(dr["PRODUCTNAME"]),
                ProductImage = (byte[])(dr["PRODUCTIMAGE"]),
                NumberOfProduct = Convert.ToInt32(dr["NUMBEROFPRODUCT"])
            };
            return ProductStock;
        }
        public static void AddNewProductStock(ELL.PRODUCTSTOCK ProductStock)
        {
            SqlCommand kmt = new SqlCommand("PR_ADDNEWPRODUCTSTOCK", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("PRODUCTID", ProductStock.ProductID);
            kmt.Parameters.AddWithValue("BRANCHID", ProductStock.BranchID);
            kmt.Parameters.AddWithValue("NUMBEROFSTOCK", ProductStock.NumberOfProduct);
            kmt.ExecuteNonQuery();
            CONNECTION.EndConnection(CONNECTION.getConnection());
        }
        public static void AddProductStock(ELL.PRODUCTSTOCK ProductStock)
        {
            SqlCommand kmt = new SqlCommand("PR_ADDPRODUCTSTOCK", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("PRODUCTSTOCKID", ProductStock.ProductStockID);
            kmt.Parameters.AddWithValue("NUMBEROFPRODUCT", ProductStock.NumberOfProduct);
            kmt.ExecuteNonQuery();
            CONNECTION.EndConnection(CONNECTION.getConnection());
        }
        public static void DecreaseProductStock(ELL.PRODUCTSTOCK ProductStock)
        {
            SqlCommand kmt = new SqlCommand("PR_DECREASEPRODUCTSTOCK", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("PRODUCTSTOCKID", ProductStock.ProductStockID);
            kmt.Parameters.AddWithValue("NUMBEROFSTOCK", ProductStock.NumberOfProduct);
            kmt.ExecuteNonQuery();
            CONNECTION.EndConnection(CONNECTION.getConnection());
        }

        public static void BuyingProduct(ELL.PRODUCTSTOCK ProductStock)
        {
            SqlCommand kmt = new SqlCommand("PR_BUYINGPRODUCT", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("PRODUCTID", ProductStock.ProductID);
            kmt.Parameters.AddWithValue("NUMBEROFSTOCK", ProductStock.NumberOfProduct);
            kmt.Parameters.AddWithValue("BRANCHID", ProductStock.BranchID);
            kmt.ExecuteNonQuery();
            CONNECTION.EndConnection(CONNECTION.getConnection());
        }
    }
}
