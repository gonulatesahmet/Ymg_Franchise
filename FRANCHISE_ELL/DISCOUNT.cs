using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRANCHISE_ELL
{
    public class DISCOUNT
    {
        private int disID;
        private string disName = string.Empty;
        private string disCode = string.Empty;
        private string disDescription = string.Empty;
        private decimal disRate;
        private string disState = string.Empty;

        public int DisID { get => disID; set => disID = value; }
        public string DisName { get => disName; set => disName = value; }
        public string DisCode { get => disCode; set => disCode = value; }
        public string DisDescription { get => disDescription; set => disDescription = value; }
        public decimal DisRate { get => disRate; set => disRate = value; }
        public string DisState { get => disState; set => disState = value; }
    }
}
