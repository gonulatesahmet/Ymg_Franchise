using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRANCHISE_ELL
{
    public class CATEGORY
    {
        private int categoryID;
        private string categoryName = string.Empty;
        private string categoryCode = string.Empty;
        private string categoryDescription = string.Empty;
        private int mainCategoryID;
        private string mainCategoryName = string.Empty;
        private string categoryState = string.Empty;

        public int CategoryID { get => categoryID; set => categoryID = value; }
        public string CategoryName { get => categoryName; set => categoryName = value; }
        public string CategoryCode { get => categoryCode; set => categoryCode = value; }
        public string CategoryDescription { get => categoryDescription; set => categoryDescription = value; }
        public int MainCategoryID { get => mainCategoryID; set => mainCategoryID = value; }
        public string MainCategoryName { get => mainCategoryName; set => mainCategoryName = value; }
        public string CategoryState { get => categoryState; set => categoryState = value; }
    }
}
