using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRANCHISE_ELL
{
    public class AUTHORITY
    {
        private int authorityID;
        private string authorityName = string.Empty;
        private string authorityCode = string.Empty;
        private string authorityDescription = string.Empty;
        private string authorityState = string.Empty;

        public int AuthorityID { get => authorityID; set => authorityID = value; }
        public string AuthorityName { get => authorityName; set => authorityName = value; }
        public string AuthorityCode { get => authorityCode; set => authorityCode = value; }
        public string AuthorityDescription { get => authorityDescription; set => authorityDescription = value; }
        public string AuthorityState { get => authorityState; set => authorityState = value; }
    }
}
