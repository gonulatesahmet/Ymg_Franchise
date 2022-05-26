using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRANCHISE_ELL
{
    public class EMPLOYEE
    {
        private int employeeID;
        private string employeeName = string.Empty;
        private string employeeSurName = string.Empty;
        private string employeeIDNumber = string.Empty;
        private DateTime employeeBirthDate;
        private string employeePhone = string.Empty;
        private string employeeAddress = string.Empty;
        private string userName = string.Empty;
        private string userPassword = string.Empty;
        private string employeeCode = string.Empty;
        private int appellationID;
        private string appellationName = string.Empty;
        private int branchID;
        private string branchName = string.Empty;
        private string employeeState = string.Empty;

        public int EmployeeID { get => employeeID; set => employeeID = value; }
        public string EmployeeName { get => employeeName; set => employeeName = value; }
        public string EmployeeSurName { get => employeeSurName; set => employeeSurName = value; }
        public string EmployeeIDNumber { get => employeeIDNumber; set => employeeIDNumber = value; }
        public DateTime EmployeeBirthDate { get => employeeBirthDate; set => employeeBirthDate = value; }
        public string EmployeePhone { get => employeePhone; set => employeePhone = value; }
        public string EmployeeAddress { get => employeeAddress; set => employeeAddress = value; }
        public string UserName { get => userName; set => userName = value; }
        public string UserPassword { get => userPassword; set => userPassword = value; }
        public string EmployeeCode { get => employeeCode; set => employeeCode = value; }
        public int AppellationID { get => appellationID; set => appellationID = value; }
        public string AppellationName { get => appellationName; set => appellationName = value; }
        public int BranchID { get => branchID; set => branchID = value; }
        public string BranchName { get => branchName; set => branchName = value; }
        public string EmployeeState { get => employeeState; set => employeeState = value; }
    }
}
