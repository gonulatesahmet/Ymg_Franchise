using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRANCHISE_ELL
{
    public class TYPEOFPAYMENT
    {
        private int typeOfPaymentID;
        private string typeOfPaymentName = string.Empty;
        private string typeOfPaymentCode = string.Empty;
        private string typeOfPaymentDescription = string.Empty;
        private string typeOfPaymentState = string.Empty;

        public int TypeOfPaymentID { get => typeOfPaymentID; set => typeOfPaymentID = value; }
        public string TypeOfPaymentName { get => typeOfPaymentName; set => typeOfPaymentName = value; }
        public string TypeOfPaymentCode { get => typeOfPaymentCode; set => typeOfPaymentCode = value; }
        public string TypeOfPaymentDescription { get => typeOfPaymentDescription; set => typeOfPaymentDescription = value; }
        public string TypeOfPaymentState { get => typeOfPaymentState; set => typeOfPaymentState = value; }
    }
}
