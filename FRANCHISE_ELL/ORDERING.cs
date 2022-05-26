using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRANCHISE_ELL
{
    public class ORDERING
    {
        private int orderingID;
        private int sittingID;
        private int productID;
        private string productName = string.Empty;
        private int piece;
        private decimal productPrice;
        private decimal totalPrice;
        private DateTime orderingDate;
        private int employeeID;
        private string employeeName = string.Empty;
        private int branchID;
        private string branchName = string.Empty;
        private string orderingState = string.Empty;

        public int OrderingID { get => orderingID; set => orderingID = value; }
        public int SittingID { get => sittingID; set => sittingID = value; }
        public int ProductID { get => productID; set => productID = value; }
        public string ProductName { get => productName; set => productName = value; }
        public int Piece { get => piece; set => piece = value; }
        public decimal ProductPrice { get => productPrice; set => productPrice = value; }
        public decimal TotalPrice { get => totalPrice; set => totalPrice = value; }
        public DateTime OrderingDate { get => orderingDate; set => orderingDate = value; }
        public int EmployeeID { get => employeeID; set => employeeID = value; }
        public string EmployeeName { get => employeeName; set => employeeName = value; }
        public int BranchID { get => branchID; set => branchID = value; }
        public string BranchName { get => branchName; set => branchName = value; }
        public string OrderingState { get => orderingState; set => orderingState = value; }
    }
}
