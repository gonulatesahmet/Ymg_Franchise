using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRANCHISE_ELL
{
    public class BRANCHREPORT
    {
        private int branchDailyReportID;
        private DateTime reportDay;
        private int productID;
        private string productName = string.Empty;
        private int piece;
        private decimal totalPrice;
        private int branchID;
        private string branchName = string.Empty;

        public int BranchDailyReportID { get => branchDailyReportID; set => branchDailyReportID = value; }
        public DateTime ReportDay { get => reportDay; set => reportDay = value; }
        public int ProductID { get => productID; set => productID = value; }
        public string ProductName { get => productName; set => productName = value; }
        public int Piece { get => piece; set => piece = value; }
        public decimal TotalPrice { get => totalPrice; set => totalPrice = value; }
        public int BranchID { get => branchID; set => branchID = value; }
        public string BranchName { get => branchName; set => branchName = value; }
    }
}
