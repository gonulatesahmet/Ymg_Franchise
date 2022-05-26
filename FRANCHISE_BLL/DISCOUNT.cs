using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ELL = FRANCHISE_ELL;
using DAL = FRANCHISE_DAL;
namespace FRANCHISE_BLL
{
    public class DISCOUNT
    {
        public static ELL.DISCOUNT[] DisList()
        {
            ELL.DISCOUNT[] Dis = DAL.DISCOUNT.DisList();
            return Dis;
        }
        public static void AddDis(ELL.DISCOUNT Dis)
        {
            DAL.DISCOUNT.AddDis(Dis);
        }
        public static void ChangeStateDis(int DisID,string State)
        {
            DAL.DISCOUNT.ChangeStateDis(DisID, State);
        }
        public static void DeleteDis(int DisID)
        {
            DAL.DISCOUNT.DeleteDis(DisID);
        }
    }
}
