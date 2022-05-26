using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ELL = FRANCHISE_ELL;
using DAL = FRANCHISE_DAL;
namespace FRANCHISE_BLL
{
    public class EMPLOYEEAUTHORITY
    {
        public static ELL.EMPLOYEEAUTHORITY[] State0List(int EmployeeID)
        {
            ELL.EMPLOYEEAUTHORITY[] EmployeeAut = DAL.EMPLOYEEAUTHORITY.State0List(EmployeeID);
            return EmployeeAut;
        }
        



        public static ELL.EMPLOYEEAUTHORITY[] State1List(int EmployeeID)
        {
            ELL.EMPLOYEEAUTHORITY[] EmployeeAut = DAL.EMPLOYEEAUTHORITY.State1List(EmployeeID);
            return EmployeeAut;
        }




        public static void ChangeStateEmpAut(int EmpAutID, string State)
        {
            DAL.EMPLOYEEAUTHORITY.ChangeStateEmpAut(EmpAutID, State);
        }





        public static int PageControl(int EmployeeID, string FormName)
        {
            int Authority = DAL.EMPLOYEEAUTHORITY.PageControl(EmployeeID, FormName);
            return Authority;
        }
    }
}
