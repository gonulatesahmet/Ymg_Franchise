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
    public class EMPLOYEEAUTHORITY
    {
        public static ELL.EMPLOYEEAUTHORITY[] State0List(int EmployeeID)
        {
            List<ELL.EMPLOYEEAUTHORITY> EmpAut = new List<ELL.EMPLOYEEAUTHORITY>();
            SqlCommand kmt = new SqlCommand("PR_EMPAUTSTATE0LIST", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("EMPLOYEEID", EmployeeID);
            SqlDataReader dr = kmt.ExecuteReader();
            while (dr.Read())
            {
                EmpAut.Add(EmpAutLoad(dr));
            }
            return EmpAut.ToArray();
        }




        public static ELL.EMPLOYEEAUTHORITY[] State1List(int EmployeeID)
        {
            List<ELL.EMPLOYEEAUTHORITY> EmpAut = new List<ELL.EMPLOYEEAUTHORITY>();
            SqlCommand kmt = new SqlCommand("PR_EMPAUTSTATE1LIST", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("EMPLOYEEID", EmployeeID);
            SqlDataReader dr = kmt.ExecuteReader();
            while (dr.Read())
            {
                EmpAut.Add(EmpAutLoad(dr));
            }
            return EmpAut.ToArray();
        }





        public static ELL.EMPLOYEEAUTHORITY EmpAutLoad(SqlDataReader dr)
        {
            ELL.EMPLOYEEAUTHORITY EmpAut = new ELL.EMPLOYEEAUTHORITY()
            {
                EmpAutID = Convert.ToInt32(dr["EMPAUTID"]),
                EmployeeID = Convert.ToInt32(dr["EMPLOYEEID"]),
                EmployeeName = Convert.ToString(dr["EMPLOYEENAME"]),
                PageID = Convert.ToInt32(dr["PAGEID"]),
                PageName = Convert.ToString(dr["PAGENAME"]),
                AuthorityID = Convert.ToInt32(dr["AUTHORITYID"]),
                AuthorityName = Convert.ToString(dr["AUTHORITYNAME"]),
                EmpAutState = Convert.ToString(dr["EMPAUTSTATE"])
            };
            if (EmpAut.EmpAutState == "100")
            {
                EmpAut.EmpAutState = "Yetki Var";
            }
            else
            {
                EmpAut.EmpAutState = "Yetki Yok";
            }
            return EmpAut;
        }





        public static void ChangeStateEmpAut(int EmpAutID, string State)
        {
            SqlCommand kmt = new SqlCommand("PR_CHANGESTATEEMPAUT", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("EMPAUTID", EmpAutID);
            kmt.Parameters.AddWithValue("EMPAUTSTATE", State);
            kmt.ExecuteNonQuery();
            CONNECTION.EndConnection(CONNECTION.getConnection());
        }




        
        public static int PageControl(int EmployeeID, string FormName)
        {
            int Authority = 0;
            SqlCommand kmt = new SqlCommand("PR_PAGECONTROL", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("EMPLOYEEID", EmployeeID);
            kmt.Parameters.AddWithValue("PAGENAME", FormName);
            SqlDataReader dr = kmt.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                string State = dr["EMPAUTSTATE"].ToString();
                if(State == "100")
                {
                    Authority = 1;
                }
                else
                {
                    Authority = 0;
                }
            }
            return Authority;
        }
    }
}
