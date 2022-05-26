using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ELL = FRANCHISE_ELL;
using DAL = FRANCHISE_DAL; 
namespace FRANCHISE_BLL
{
    public class BRANCHREPORT
    {
        public static void AddBranchDailyReport(ELL.BRANCHREPORT BranchReport)
        {
            DAL.BRANCHREPORT.AddBranchDailyReport(BranchReport);
        }
        public static int BranchDailyReportControl(DateTime dt,int BranchID)
        {
            int Control = DAL.BRANCHREPORT.BranchDailyReportControl(dt, BranchID);
            return Control;
        }

        public static ELL.BRANCHREPORT[] BranchDailyReportList(int BranchID)
        {
            ELL.BRANCHREPORT[] BranchReport = DAL.BRANCHREPORT.BranchDailyReportList(BranchID);
            return BranchReport;
        }
        
        public static ELL.BRANCHREPORT[] BranchDailyReportListDetail(int BranchID,DateTime ReportDay)
        {
            ELL.BRANCHREPORT[] BranchReport = DAL.BRANCHREPORT.BranchDailyReportListDetail(BranchID, ReportDay);
            return BranchReport;
        }
        public static ELL.BRANCHREPORT[] BranchMonthlyReport(DateTime StartDate, DateTime DueDate, int BranchID)
        {
            ELL.BRANCHREPORT[] BranchReport = DAL.BRANCHREPORT.BranchMonthlyReport(StartDate, DueDate, BranchID);
            return BranchReport;
        }





        public static ELL.BRANCHREPORT[] InsDailyList(int InsID, DateTime ReportDay)
        {
            ELL.BRANCHREPORT[] Ins = DAL.BRANCHREPORT.InsDailyList(InsID, ReportDay);
            return Ins;
        }
    }
}
