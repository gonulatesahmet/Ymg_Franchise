using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ELL = FRANCHISE_ELL;
using DAL = FRANCHISE_DAL;
namespace FRANCHISE_BLL
{
    public class EMPLOYEE
    {
        public static int EmployeeLoginControl(string UserName, string UserPass)
        {
            int EmployeeID = DAL.EMPLOYEE.EmployeeLoginControl(UserName, UserPass);
            return EmployeeID;
        }
        public static ELL.EMPLOYEE EmployeeBring(int EmployeeID)
        {
            ELL.EMPLOYEE Employee = DAL.EMPLOYEE.EmployeeBring(EmployeeID);
            return Employee;
        }
        public static ELL.EMPLOYEE[] EmployeeList(int InsID)
        {
            ELL.EMPLOYEE[] Employee = DAL.EMPLOYEE.EmployeeList(InsID);
            return Employee;
        }
        public static void AddEmployee(ELL.EMPLOYEE Employee)
        {
            DAL.EMPLOYEE.AddEmployee(Employee);
        }
        public static void UpdateEmployee(ELL.EMPLOYEE Employee)
        {
            DAL.EMPLOYEE.UpdateEmployee(Employee);
        }
        public static void ChangeStateEmployee(int EmployeeID, string State)
        {
            DAL.EMPLOYEE.ChangeStateEmployee(EmployeeID, State);
        }
        public static void DeleteEmployee(int EmployeeID)
        {
            DAL.EMPLOYEE.DeleteEmployee(EmployeeID);
        }
        public static ELL.EMPLOYEE[] BranchEmployeeList(int BranchID)
        {
            ELL.EMPLOYEE[] Employee = DAL.EMPLOYEE.BranchEmployeeList(BranchID);
            return Employee;
        }
        public static int EmployeeBoardControl(string Code)
        {
            int EmployeeID = DAL.EMPLOYEE.EmployeeBoardControl(Code);
            return EmployeeID;
        }
    }
}
