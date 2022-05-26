using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ELL = FRANCHISE_ELL;
namespace FRANCHISE_DAL
{
    public class EMPLOYEE
    {
        public static int EmployeeLoginControl(string UserName, string UserPass)
        {
            int EmployeeID = 0;
            SqlCommand kmt = new SqlCommand("PR_EMPLOYEELOGINCONTROL", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("USERNAME", UserName);
            kmt.Parameters.AddWithValue("USERPASSWORD", UserPass);
            SqlDataReader dr = kmt.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                EmployeeID = Convert.ToInt32(dr["EMPLOYEEID"]);
                return EmployeeID;
            }
            else { return EmployeeID; }
        }
        public static ELL.EMPLOYEE EmployeeBring(int EmployeeID)
        {
            
            SqlCommand kmt = new SqlCommand("PR_EMPLOYEEBRING", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("EMPLOYEEID", EmployeeID);
            SqlDataReader dr = kmt.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                ELL.EMPLOYEE Employee = new ELL.EMPLOYEE()
                {
                    EmployeeID = EmployeeID,
                    EmployeeName = Convert.ToString(dr["EMPLOYEENAME"]),
                    EmployeeSurName = Convert.ToString(dr["EMPLOYEESURNAME"]),
                    EmployeeIDNumber = Convert.ToString(dr["EMPLOYEEIDNUMBER"]),
                    EmployeeBirthDate = Convert.ToDateTime(dr["EMPLOYEEBIRTHDATE"]),
                    EmployeePhone = Convert.ToString(dr["EMPLOYEEPHONE"]),
                    EmployeeAddress = Convert.ToString(dr["EMPLOYEEADDRESS"]),
                    UserName = Convert.ToString(dr["USERNAME"]),
                    UserPassword = Convert.ToString(dr["USERPASSWORD"]),
                    EmployeeCode = Convert.ToString(dr["EMPLOYEECODE"]),
                    AppellationID = Convert.ToInt32(dr["APPELLATIONID"]),
                    AppellationName = Convert.ToString(dr["APPELLATIONNAME"]),
                    BranchID = Convert.ToInt32(dr["BRANCHID"]),
                    BranchName = Convert.ToString(dr["BRANCHNAME"]),
                    EmployeeState = Convert.ToString(dr["EMPLOYEESTATE"])
                };
                return Employee;
            }
            else return null;
        }
        public static ELL.EMPLOYEE[] EmployeeList(int InsID)
        {
            List<ELL.EMPLOYEE> Employee = new List<ELL.EMPLOYEE>();
            SqlCommand kmt = new SqlCommand("PR_EMPLOYEELIST", CONNECTION.getConnection());
            kmt.Parameters.AddWithValue("INSID", InsID);
            kmt.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = kmt.ExecuteReader();
            while (dr.Read())
            {
                Employee.Add(EmployeeLoad(dr));
            }
            return Employee.ToArray();
        }
        public static ELL.EMPLOYEE EmployeeLoad(SqlDataReader dr)
        {
            ELL.EMPLOYEE Employee = new ELL.EMPLOYEE()
            {
                EmployeeID = Convert.ToInt32(dr["EMPLOYEEID"]),
                EmployeeName = Convert.ToString(dr["EMPLOYEENAME"]),
                EmployeeSurName = Convert.ToString(dr["EMPLOYEESURNAME"]),
                EmployeeIDNumber = Convert.ToString(dr["EMPLOYEEIDNUMBER"]),
                EmployeeBirthDate = Convert.ToDateTime(dr["EMPLOYEEBIRTHDATE"]),
                UserName = Convert.ToString(dr["USERNAME"]),
                UserPassword = Convert.ToString(dr["USERPASSWORD"]),
                EmployeeCode = Convert.ToString(dr["EMPLOYEECODE"]),
                AppellationID = Convert.ToInt32(dr["APPELLATIONID"]),
                AppellationName = Convert.ToString(dr["APPELLATIONNAME"]),
                BranchID = Convert.ToInt32(dr["BRANCHID"]),
                BranchName = Convert.ToString(dr["BRANCHNAME"]),
                EmployeePhone = Convert.ToString(dr["EMPLOYEEPHONE"]),
                EmployeeAddress = Convert.ToString(dr["EMPLOYEEADDRESS"]),
                EmployeeState = Convert.ToString(dr["EMPLOYEESTATE"])
            };
            if (Employee.EmployeeState == "100")
            {
                Employee.EmployeeState = "Aktif";
            }
            else Employee.EmployeeState = "Pasif";
            return Employee;
        }
        public static void AddEmployee(ELL.EMPLOYEE Employee)
        {
            SqlCommand kmt = new SqlCommand("PR_ADDEMPLOYEE", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("EMPLOYEENAME", Employee.EmployeeName);
            kmt.Parameters.AddWithValue("EMPLOYEESURNAME", Employee.EmployeeSurName);
            kmt.Parameters.AddWithValue("EMPLOYEEIDNUMBER", Employee.EmployeeIDNumber);
            kmt.Parameters.AddWithValue("EMPLOYEEBIRTHDATE", Employee.EmployeeBirthDate);
            kmt.Parameters.AddWithValue("USERNAME", Employee.UserName);
            kmt.Parameters.AddWithValue("USERPASSWORD", Employee.UserPassword);
            kmt.Parameters.AddWithValue("EMPLOYEECODE", Employee.EmployeeCode);
            kmt.Parameters.AddWithValue("APPELLATIONID", Employee.AppellationID);
            kmt.Parameters.AddWithValue("BRANCHID", Employee.BranchID);
            kmt.Parameters.AddWithValue("EMPLOYEEPHONE", Employee.EmployeePhone);
            kmt.Parameters.AddWithValue("EMPLOYEEADDRESS", Employee.EmployeeAddress);
            kmt.Parameters.AddWithValue("EMPLOYEESTATE", Employee.EmployeeState);
            kmt.ExecuteNonQuery();
            CONNECTION.EndConnection(CONNECTION.getConnection());
        }
        public static void UpdateEmployee(ELL.EMPLOYEE Employee)
        {
            SqlCommand kmt = new SqlCommand("PR_UPDATEEMPLOYEE", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("EMPLOYEENAME", Employee.EmployeeName);
            kmt.Parameters.AddWithValue("EMPLOYEESURNAME", Employee.EmployeeSurName);
            kmt.Parameters.AddWithValue("EMPLOYEEIDNUMBER", Employee.EmployeeIDNumber);
            kmt.Parameters.AddWithValue("EMPLOYEEBIRTHDATE", Employee.EmployeeBirthDate);
            kmt.Parameters.AddWithValue("USERNAME", Employee.UserName);
            kmt.Parameters.AddWithValue("USERPASSWORD", Employee.UserPassword);
            kmt.Parameters.AddWithValue("EMPLOYEECODE", Employee.EmployeeCode);
            kmt.Parameters.AddWithValue("APPELLATIONID", Employee.AppellationID);
            kmt.Parameters.AddWithValue("BRANCHID", Employee.BranchID);
            kmt.Parameters.AddWithValue("EMPLOYEEPHONE", Employee.EmployeePhone);
            kmt.Parameters.AddWithValue("EMPLOYEEADDRESS", Employee.EmployeeAddress);
            kmt.Parameters.AddWithValue("EMPLOYEEID", Employee.EmployeeID);
            kmt.ExecuteNonQuery();
            CONNECTION.EndConnection(CONNECTION.getConnection());
        }
        public static void ChangeStateEmployee(int EmployeeID,string State)
        {
            SqlCommand kmt = new SqlCommand("PR_CHANGESTATEEMPLOYEE", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("EMPLOYEEID", EmployeeID);
            kmt.Parameters.AddWithValue("EMPLOYEESTATE", State);
            kmt.ExecuteNonQuery();
            CONNECTION.EndConnection(CONNECTION.getConnection());
        }
        public static void DeleteEmployee(int EmployeeID)
        {
            SqlCommand kmt = new SqlCommand("PR_DELETEEMPLOYEE", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("EMPLOYEEID", EmployeeID);
            kmt.ExecuteNonQuery();
            CONNECTION.EndConnection(CONNECTION.getConnection());
        }
        public static ELL.EMPLOYEE[] BranchEmployeeList(int BranchID)
        {
            List<ELL.EMPLOYEE> Employee = new List<ELL.EMPLOYEE>();
            SqlCommand kmt = new SqlCommand("PR_BRANCHEMPLOYEELIST", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("BRANCHID", BranchID);
            SqlDataReader dr = kmt.ExecuteReader();
            while (dr.Read())
            {
                Employee.Add(EmployeeLoad(dr));
            }
            return Employee.ToArray();
        }
        public static int EmployeeBoardControl(string Code)
        {
            int EmployeeID = 0;
            SqlCommand kmt = new SqlCommand("PR_EMPLOYEEBOARDCONTROL", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("EMPLOYEECODE", Code);
            SqlDataReader dr = kmt.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                EmployeeID = Convert.ToInt32(dr["EMPLOYEEID"]);
                return EmployeeID;
            }
            else return EmployeeID;
        }



       
    }
}
