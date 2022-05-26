using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRANCHISE_ELL
{
    public class PRODUCTSTOCK
    {
        private int productStockID;
        private int productID;
        private string productName = string.Empty;
        private byte[] productImage;
        private int branchID;
        private int numberOfProduct;

        public int ProductStockID { get => productStockID; set => productStockID = value; }
        public int ProductID { get => productID; set => productID = value; }
        public string ProductName { get => productName; set => productName = value; }
        public byte[] ProductImage { get => productImage; set => productImage = value; }
        public int BranchID { get => branchID; set => branchID = value; }
        public int NumberOfProduct { get => numberOfProduct; set => numberOfProduct = value; }
    }
}
