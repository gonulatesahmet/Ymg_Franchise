using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ELL = FRANCHISE_ELL;
using DAL = FRANCHISE_DAL;
namespace FRANCHISE_BLL
{
    public class PRODUCTSTOCK
    {
        public static ELL.PRODUCTSTOCK[] ProductStockList(int BranchID)
        {
            ELL.PRODUCTSTOCK[] ProductStock = DAL.PRODUCTSTOCK.ProductStockList(BranchID);
            return ProductStock;
        }
        public static void AddNewStock(ELL.PRODUCTSTOCK ProductStock)
        {
            DAL.PRODUCTSTOCK.AddNewProductStock(ProductStock);
        }
        public static void AddProductStock(ELL.PRODUCTSTOCK ProductStock)
        {
            DAL.PRODUCTSTOCK.AddProductStock(ProductStock);
        }
        public static void DecreaseProductStock(ELL.PRODUCTSTOCK ProductStock)
        {
            DAL.PRODUCTSTOCK.DecreaseProductStock(ProductStock);
        }

        public static void BuyingProduct(ELL.PRODUCTSTOCK ProductStock)
        {
            DAL.PRODUCTSTOCK.BuyingProduct(ProductStock);
        }
    }
}
