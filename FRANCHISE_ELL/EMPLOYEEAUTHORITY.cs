using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRANCHISE_ELL
{
    public class EMPLOYEEAUTHORITY
    {
        private int empAutID;
        private int employeeID;
        private string employeeName = string.Empty;
        private int pageID;
        private string pageName = string.Empty;
        private int authorityID;
        private string authorityName = string.Empty;
        private string empAutState = string.Empty;

        public int EmpAutID { get => empAutID; set => empAutID = value; }
        public int EmployeeID { get => employeeID; set => employeeID = value; }
        public string EmployeeName { get => employeeName; set => employeeName = value; }
        public int PageID { get => pageID; set => pageID = value; }
        public string PageName { get => pageName; set => pageName = value; }
        public int AuthorityID { get => authorityID; set => authorityID = value; }
        public string AuthorityName { get => authorityName; set => authorityName = value; }
        public string EmpAutState { get => empAutState; set => empAutState = value; }
    }
}
