using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRANCHISE_ELL
{
    public class INSTITUTION
    {
        private int insID;
        private string insName = string.Empty;
        private string insCode = string.Empty;
        private string insDescription = string.Empty;
        private string insWeb = string.Empty;
        private string insMail = string.Empty;
        private string insPhone = string.Empty;
        private string insState = string.Empty;

        public int InsID { get => insID; set => insID = value; }
        public string InsName { get => insName; set => insName = value; }
        public string InsCode { get => insCode; set => insCode = value; }
        public string InsDescription { get => insDescription; set => insDescription = value; }
        public string InsWeb { get => insWeb; set => insWeb = value; }
        public string InsMail { get => insMail; set => insMail = value; }
        public string InsPhone { get => insPhone; set => insPhone = value; }
        public string InsState { get => insState; set => insState = value; }
    }
}
