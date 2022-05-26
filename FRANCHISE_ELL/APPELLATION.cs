using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRANCHISE_ELL
{
    public class APPELLATION
    {
        private int appellationID;
        private string appellationName = string.Empty;
        private string appellationCode = string.Empty;
        private string appellationDescription = string.Empty;
        private int authorityID;
        private string authorityName = string.Empty;
        private string appellationState = string.Empty;

        public int AppellationID { get => appellationID; set => appellationID = value; }
        public string AppellationName { get => appellationName; set => appellationName = value; }
        public string AppellationCode { get => appellationCode; set => appellationCode = value; }
        public string AppellationDescription { get => appellationDescription; set => appellationDescription = value; }
        public int AuthorityID { get => authorityID; set => authorityID = value; }
        public string AuthorityName { get => authorityName; set => authorityName = value; }
        public string AppellationState { get => appellationState; set => appellationState = value; }
    }
}
