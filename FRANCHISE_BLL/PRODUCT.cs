using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ELL = FRANCHISE_ELL;
using DAL = FRANCHISE_DAL;
namespace FRANCHISE_BLL
{
    public class PRODUCT
    {
        public static ELL.PRODUCT[] ProductList()
        {
            ELL.PRODUCT[] Product = DAL.PRODUCT.ProductList();
            return Product;
        }
        public static ELL.PRODUCT ProductBring(int ProductID)
        {
            ELL.PRODUCT Product = DAL.PRODUCT.ProductBring(ProductID);
            return Product;
        }
        public static void AddProduct(ELL.PRODUCT Product)
        {
            DAL.PRODUCT.AddProduct(Product);
        }
        public static void UpdateProduct(ELL.PRODUCT Product)
        {
            DAL.PRODUCT.UpdateProduct(Product);
        }
        public static void ChangeStateProduct(int ProductID,string State)
        {
            DAL.PRODUCT.ChangeStateProduct(ProductID, State);
        }
        public static void DeleteProduct(int ProductID)
        {
            DAL.PRODUCT.DeleteProduct(ProductID);
        }
        public static void UpdateImageProduct(int ProductID, byte[] ProductImage)
        {
            DAL.PRODUCT.UpdateImageProduct(ProductID, ProductImage);
        }
        public static ELL.PRODUCT[] NewProductStockList(int BranchID)
        {
            ELL.PRODUCT[] Product = DAL.PRODUCT.NewProductStockList(BranchID);
            return Product;
        }
        public static ELL.PRODUCT[] BoardProductList(int CategoryID)
        {
            ELL.PRODUCT[] Product = DAL.PRODUCT.BoardProductList(CategoryID);
            return Product;
        }
    }
}
