using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRANCHISE_ELL
{
    public class MAINCATEGORY
    {
        private int mainCategoryID;
        private string mainCategoryName = string.Empty;
        private string mainCategoryCode = string.Empty;
        private string mainCategoryDescription = string.Empty;
        private string mainCategoryState = string.Empty;

        public int MainCategoryID { get => mainCategoryID; set => mainCategoryID = value; }
        public string MainCategoryName { get => mainCategoryName; set => mainCategoryName = value; }
        public string MainCategoryCode { get => mainCategoryCode; set => mainCategoryCode = value; }
        public string MainCategoryDescription { get => mainCategoryDescription; set => mainCategoryDescription = value; }
        public string MainCategoryState { get => mainCategoryState; set => mainCategoryState = value; }
    }
}
