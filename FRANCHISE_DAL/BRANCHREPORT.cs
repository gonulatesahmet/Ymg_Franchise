using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ELL = FRANCHISE_ELL;
namespace FRANCHISE_DAL
{
    public class BRANCHREPORT
    {
        public static int BranchDailyReportControl(DateTime dt,int BranchID)
        {
            int Control = 0;
            SqlCommand kmt = new SqlCommand("PR_BRANCHDAILYREPORTCONTROL", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("REPORTDAY", dt);
            kmt.Parameters.AddWithValue("BRANCHID", BranchID);
            SqlDataReader dr = kmt.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                Control = Convert.ToInt32(dr["BRANCHDAILYREPORTID"]);
            }
            else Control = 0;
            return Control;
        }
        public static void AddBranchDailyReport(ELL.BRANCHREPORT BranchReport)
        {
            SqlCommand kmt = new SqlCommand("PR_ADDBRANCHDAILYREPORT", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("REPORTDAY", BranchReport.ReportDay);
            kmt.Parameters.AddWithValue("PRODUCTID", BranchReport.ProductID);
            kmt.Parameters.AddWithValue("PIECE", BranchReport.Piece);
            kmt.Parameters.AddWithValue("TOTALPRICE", BranchReport.TotalPrice);
            kmt.Parameters.AddWithValue("BRANCHID", BranchReport.BranchID);
            kmt.ExecuteNonQuery();
            CONNECTION.EndConnection(CONNECTION.getConnection());
        }

        public static ELL.BRANCHREPORT[] BranchDailyReportList(int BranchID)
        {
            List<ELL.BRANCHREPORT> BranchReport = new List<ELL.BRANCHREPORT>();
            SqlCommand kmt = new SqlCommand("PR_BRANCHDAILYREPORTLIST", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("BRANCHID", BranchID);
            SqlDataReader dr = kmt.ExecuteReader();
            while (dr.Read())
            {
                BranchReport.Add(BranchReportLoad(dr));
            }
            return BranchReport.ToArray();
        }
        public static ELL.BRANCHREPORT BranchReportLoad(SqlDataReader dr)
        {
            ELL.BRANCHREPORT BranchReport = new ELL.BRANCHREPORT()
            {
                ReportDay = Convert.ToDateTime(dr["REPORTDAY"])
            };
            return BranchReport;
        }

        public static ELL.BRANCHREPORT[] BranchDailyReportListDetail(int BranchID, DateTime ReportDay)
        {
            List<ELL.BRANCHREPORT> BranchReport = new List<ELL.BRANCHREPORT>();
            SqlCommand kmt = new SqlCommand("PR_BRANCHDAILYREPORTLISTDETAIL", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("BRANCHID", BranchID);
            kmt.Parameters.AddWithValue("REPORTDAY", ReportDay);
            SqlDataReader dr = kmt.ExecuteReader();
            while (dr.Read())
            {
                BranchReport.Add(BranchReportDetailLoad(dr));
            }
            return BranchReport.ToArray();
        }
        public static ELL.BRANCHREPORT BranchReportDetailLoad(SqlDataReader dr)
        {
            ELL.BRANCHREPORT BranchReport = new ELL.BRANCHREPORT()
            {
                BranchDailyReportID = Convert.ToInt32(dr["BRANCHDAILYREPORTID"]),
                ReportDay = Convert.ToDateTime(dr["REPORTDAY"]),
                ProductID = Convert.ToInt32(dr["PRODUCTID"]),
                ProductName = Convert.ToString(dr["PRODUCTNAME"]),
                Piece = Convert.ToInt32(dr["PIECE"]),
                TotalPrice = Convert.ToDecimal(dr["TOTALPRICE"]),
                BranchID = Convert.ToInt32(dr["BRANCHID"]),
                BranchName = Convert.ToString(dr["BRANCHNAME"])
            };
            return BranchReport;
        }




        public static ELL.BRANCHREPORT[] BranchMonthlyReport(DateTime StartDate, DateTime DueDate, int BranchID)
        {
            List<ELL.BRANCHREPORT> BranchReport = new List<ELL.BRANCHREPORT>();
            SqlCommand kmt = new SqlCommand("PR_BRANCHMONTHLYREPORT", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("STARTDATE", StartDate);
            kmt.Parameters.AddWithValue("DUEDATE", DueDate);
            kmt.Parameters.AddWithValue("BRANCHID", BranchID);
            SqlDataReader dr = kmt.ExecuteReader();
            while (dr.Read())
            {
                BranchReport.Add(BranchMonthlyReportLoad(dr));
            }
            return BranchReport.ToArray();
        }
        
        public static ELL.BRANCHREPORT BranchMonthlyReportLoad(SqlDataReader dr)
        {
            ELL.BRANCHREPORT BranchReport = new ELL.BRANCHREPORT()
            {
                ReportDay = Convert.ToDateTime(dr["REPORTDAY"]),
                TotalPrice = Convert.ToDecimal(dr["TOTALPRICE"])
            };
            return BranchReport;
        }






        public static ELL.BRANCHREPORT[] InsDailyList(int InsID,DateTime ReportDay)
        {
            List<ELL.BRANCHREPORT> Ins = new List<ELL.BRANCHREPORT>();
            SqlCommand kmt = new SqlCommand("PR_INSDAILYREPORT", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("INSID", InsID);
            kmt.Parameters.AddWithValue("REPORTDAY", ReportDay);
            SqlDataReader dr = kmt.ExecuteReader();
            while (dr.Read())
            {
                Ins.Add(InsDailyReportListLoad(dr));
            }
            return Ins.ToArray();
        }

        public static ELL.BRANCHREPORT InsDailyReportListLoad(SqlDataReader dr)
        {
            ELL.BRANCHREPORT Ins = new ELL.BRANCHREPORT()
            {
                BranchID = Convert.ToInt32(dr["BRANCHID"]),
                BranchName = Convert.ToString(dr["BRANCHNAME"]),
                ReportDay = Convert.ToDateTime(dr["REPORTDAY"]),
                TotalPrice = Convert.ToDecimal(dr["TOTALPRICE"])
            };
            return Ins;
        }
    }
}
