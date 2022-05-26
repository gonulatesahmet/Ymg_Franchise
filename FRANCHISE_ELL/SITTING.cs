using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRANCHISE_ELL
{
    public class SITTING
    {
        private int sittingID;
        private int branchID;
        private int boardID;
        private decimal totalPrice;
        private DateTime startDate;
        private DateTime dueDate;
        private int typeOfPaymentID;
        private string typeOfPaymentName = string.Empty;
        private int disID;
        private string disName = string.Empty;
        private string sittingState = string.Empty;

        public int SittingID { get => sittingID; set => sittingID = value; }
        public int BranchID { get => branchID; set => branchID = value; }
        public int BoardID { get => boardID; set => boardID = value; }
        public decimal TotalPrice { get => totalPrice; set => totalPrice = value; }
        public DateTime StartDate { get => startDate; set => startDate = value; }
        public DateTime DueDate { get => dueDate; set => dueDate = value; }
        public int TypeOfPaymentID { get => typeOfPaymentID; set => typeOfPaymentID = value; }
        public string TypeOfPaymentName { get => typeOfPaymentName; set => typeOfPaymentName = value; }
        public int DisID { get => disID; set => disID = value; }
        public string DisName { get => disName; set => disName = value; }
        public string SittingState { get => sittingState; set => sittingState = value; }
    }
}
