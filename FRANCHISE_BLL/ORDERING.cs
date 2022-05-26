using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ELL = FRANCHISE_ELL;
using DAL = FRANCHISE_DAL;
namespace FRANCHISE_BLL
{
    public class ORDERING
    {
        public static ELL.ORDERING[] OrderingList(int SittingID)
        {
            ELL.ORDERING[] Ordering = DAL.ORDERING.OrderingList(SittingID);
            return Ordering;
        }
        public static void AddOrdering(ELL.ORDERING Ordering)
        {
            DAL.ORDERING.AddOrdering(Ordering);
        }
        public static void PlusOrdering(int OrderingID)
        {
            DAL.ORDERING.PlusOrdering(OrderingID);
        }
        public static void DecreaseOrdering(int OrderingID)
        {
            DAL.ORDERING.DecreaseOrdering(OrderingID);
        }
        public static void ChangeStateOrdering(int OrderingID)
        {
            DAL.ORDERING.ChangeStateOrdering(OrderingID);
        }







        public static ELL.ORDERING[] BranchDailyOrderingList(int BranchID)
        {
            ELL.ORDERING[] Ordering = DAL.ORDERING.BranchDailyOrderingList(BranchID);
            return Ordering;
        }
        public static ELL.ORDERING[] BranchMonthlyOrderingList(DateTime StartDate, DateTime DueDate, int BranchID)
        {
            ELL.ORDERING[] Ordering = DAL.ORDERING.BranchMonthlyOrderingList(StartDate, DueDate, BranchID);
            return Ordering;
        }

        public static ELL.ORDERING[] MonthlyOrderingList(DateTime StartDate, DateTime DueDate)
        {
            ELL.ORDERING[] Ordering = DAL.ORDERING.MonthlyOrderingList(StartDate, DueDate);
            return Ordering;
        }
    }
}
