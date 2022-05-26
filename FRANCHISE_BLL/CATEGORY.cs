using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ELL = FRANCHISE_ELL;
using DAL = FRANCHISE_DAL;
namespace FRANCHISE_BLL
{
    public class CATEGORY
    {
        public static ELL.CATEGORY[] CategoryList()
        {
            ELL.CATEGORY[] Category = DAL.CATEGORY.CategoryList();
            return Category;
        }
        public static ELL.CATEGORY CategoryBring(int CategoryID)
        {
            ELL.CATEGORY Category = DAL.CATEGORY.CategoryBring(CategoryID);
            return Category;
        }
        public static void AddCategory(ELL.CATEGORY Category)
        {
            DAL.CATEGORY.AddCategory(Category);
        }
        public static void UpdateCategory(ELL.CATEGORY Category)
        {
            DAL.CATEGORY.UpdateCategory(Category);
        }
        public static void ChangeStateCategory(int CategoryID,string State)
        {
            DAL.CATEGORY.ChangeStateCategory(CategoryID, State);
        }
        public static void DeleteCategory(int CategoryID)
        {
            DAL.CATEGORY.DeleteCategory(CategoryID);
        }
        public static ELL.CATEGORY[] BoardCategoryList(int MainCategoryID)
        {
            ELL.CATEGORY[] Category = DAL.CATEGORY.BoardCategoryList(MainCategoryID);
            return Category;
        }
    }
}
