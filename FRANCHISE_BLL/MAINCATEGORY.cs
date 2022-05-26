using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ELL = FRANCHISE_ELL;
using DAL = FRANCHISE_DAL;
namespace FRANCHISE_BLL
{
    public class MAINCATEGORY
    {
        public static ELL.MAINCATEGORY[] MainCategoryList()
        {
            ELL.MAINCATEGORY[] MainCategory = DAL.MAINCATEGORY.MainCategoryList();
            return MainCategory;
        }
        public static ELL.MAINCATEGORY MainCategoryBring(int MainCategoryID)
        {
            ELL.MAINCATEGORY MainCategory = DAL.MAINCATEGORY.MainCategoryBring(MainCategoryID);
            return MainCategory;
        }
        public static void AddMainCategory(ELL.MAINCATEGORY MainCategory)
        {
            DAL.MAINCATEGORY.AddMainCategory(MainCategory);
        }
        public static void UpdateMainCategory(ELL.MAINCATEGORY MainCategory)
        {
            DAL.MAINCATEGORY.UpdateMainCategory(MainCategory);
        }
        public static void ChangeStateMainCategory(int MainCategoryID,string State)
        {
            DAL.MAINCATEGORY.ChangeStateMainCategory(MainCategoryID, State);
        }
        public static void DeleteMainCategory(int MainCategoryID)
        {
            DAL.MAINCATEGORY.DeleteMainCategory(MainCategoryID);
        }
    }
}
