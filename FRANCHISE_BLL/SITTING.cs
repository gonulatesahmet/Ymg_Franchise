using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ELL = FRANCHISE_ELL;
using DAL = FRANCHISE_DAL;
namespace FRANCHISE_BLL
{
    public class SITTING
    {
        public static ELL.SITTING SittingControl(int BoardID,int BranchID,string State)
        {
            ELL.SITTING Sitting = DAL.SITTING.SittingControl(BoardID, BranchID, State);
            return Sitting;
        }
        public static void StartSitting(ELL.SITTING Sitting)
        {
            DAL.SITTING.StartSitting(Sitting);
        }
        public static void CloseSitting(ELL.SITTING Sitting)
        {
            DAL.SITTING.CloseSitting(Sitting);
        }





        public static ELL.SITTING[] BranchSittingPaymentReport(DateTime StartDate, DateTime DueDate, int BranchID)
        {
            ELL.SITTING[] Sitting = DAL.SITTING.BranchSittingPaymentReport(StartDate, DueDate, BranchID);
            return Sitting;
        }


        public static ELL.SITTING[] SittingPaymentReport(DateTime StartDate, DateTime DueDate)
        {
            ELL.SITTING[] Sitting = DAL.SITTING.SittingPaymentReport(StartDate, DueDate);
            return Sitting;
        }
    }
}
