using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRANCHISE_ELL
{
    public class PRODUCT
    {
        private int productID;
        private byte[] productImage;
        private string productName = string.Empty;
        private string productCode = string.Empty;
        private string productDescription = string.Empty;
        private decimal productPrice;
        private string stockStatus = string.Empty;
        private int categoryID;
        private string categoryName = string.Empty;
        private string productState = string.Empty;

        public int ProductID { get => productID; set => productID = value; }
        public byte[] ProductImage { get => productImage; set => productImage = value; }
        public string ProductName { get => productName; set => productName = value; }
        public string ProductCode { get => productCode; set => productCode = value; }
        public string ProductDescription { get => productDescription; set => productDescription = value; }
        public decimal ProductPrice { get => productPrice; set => productPrice = value; }
        public string StockStatus { get => stockStatus; set => stockStatus = value; }
        public int CategoryID { get => categoryID; set => categoryID = value; }
        public string CategoryName { get => categoryName; set => categoryName = value; }
        public string ProductState { get => productState; set => productState = value; }
    }
}
