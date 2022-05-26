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
    public class ORDERING
    {
        public static ELL.ORDERING[] OrderingList(int SittingID)
        {
            List<ELL.ORDERING> Ordering = new List<ELL.ORDERING>();
            SqlCommand kmt = new SqlCommand("PR_ORDERINGLIST", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("SITTINGID", SittingID);
            SqlDataReader dr = kmt.ExecuteReader();
            while (dr.Read())
            {
                Ordering.Add(OrderingLoad(dr));
            }
            return Ordering.ToArray();
        }
        public static ELL.ORDERING OrderingLoad(SqlDataReader dr)
        {
            ELL.ORDERING Ordering = new ELL.ORDERING()
            {
                OrderingID = Convert.ToInt32(dr["ORDERINGID"]),
                SittingID = Convert.ToInt32(dr["SITTINGID"]),
                ProductID = Convert.ToInt32(dr["PRODUCTID"]),
                ProductName = Convert.ToString(dr["PRODUCTNAME"]),
                Piece = Convert.ToInt32(dr["PIECE"]),
                ProductPrice = Convert.ToDecimal(dr["PRODUCTPRICE"]),
                TotalPrice = Convert.ToDecimal(dr["TOTALPRICE"]),
                OrderingDate = Convert.ToDateTime(dr["ORDERINGDATE"]),
                EmployeeID = Convert.ToInt32(dr["EMPLOYEEID"]),
                EmployeeName = Convert.ToString(dr["EMPLOYEENAME"]),
                BranchID = Convert.ToInt32(dr["BRANCHID"]),
                BranchName = Convert.ToString(dr["BRANCHNAME"]),
                OrderingState = Convert.ToString(dr["ORDERINGSTATE"])
            };
            return Ordering;
        }
        public static void AddOrdering(ELL.ORDERING Ordering)
        {
            SqlCommand kmt = new SqlCommand("PR_ADDORDERING", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("SITTINGID", Ordering.SittingID);
            kmt.Parameters.AddWithValue("PRODUCTID", Ordering.ProductID);
            kmt.Parameters.AddWithValue("PIECE", Ordering.Piece);
            kmt.Parameters.AddWithValue("ORDERINGDATE", Ordering.OrderingDate);
            kmt.Parameters.AddWithValue("EMPLOYEEID", Ordering.EmployeeID);
            kmt.Parameters.AddWithValue("BRANCHID", Ordering.BranchID);
            kmt.Parameters.AddWithValue("ORDERINGSTATE", Ordering.OrderingState);
            kmt.ExecuteNonQuery();
            CONNECTION.EndConnection(CONNECTION.getConnection());
        }
        public static void DeleteOrdering(int OrderingID)
        {
            SqlCommand kmt = new SqlCommand("PR_DELETEORDERING", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("ORDERINGID", OrderingID);
            kmt.Parameters.AddWithValue("ORDERINGSTATE", "000");
        }
        public static void PlusOrdering(int OrderingID)
        {
            SqlCommand kmt = new SqlCommand("PR_PLUSORDERING", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("ORDERINGID", OrderingID);
            kmt.Parameters.AddWithValue("PIECE", 1);
            kmt.ExecuteNonQuery();
            CONNECTION.EndConnection(CONNECTION.getConnection());
        }
        public static void DecreaseOrdering(int OrderingID)
        {
            SqlCommand kmt = new SqlCommand("PR_DECREASEORDERING", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("ORDERINGID", OrderingID);
            kmt.Parameters.AddWithValue("PIECE", -1);
            kmt.ExecuteNonQuery();
            CONNECTION.EndConnection(CONNECTION.getConnection());
        }
        public static void ChangeStateOrdering(int OrderingID)
        {
            SqlCommand kmt = new SqlCommand("PR_CHANGESTATEORDERING", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("ORDERINGID", OrderingID);
            kmt.Parameters.AddWithValue("ORDERINGSTATE", "000");
            kmt.ExecuteNonQuery();
            CONNECTION.EndConnection(CONNECTION.getConnection());
        }



        public static ELL.ORDERING[] BranchDailyOrderingList(int BranchID)
        {
            List<ELL.ORDERING> Ordering = new List<ELL.ORDERING>();
            SqlCommand kmt = new SqlCommand("PR_BRANCHDAILYORDERINGLIST", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("BRANCHID", BranchID);
            SqlDataReader dr = kmt.ExecuteReader();
            while (dr.Read())
            {
                Ordering.Add(BranchDailyOrderingList(dr));
            }
            return Ordering.ToArray();
        }
        public static ELL.ORDERING BranchDailyOrderingList(SqlDataReader dr)
        {
            ELL.ORDERING Ordering = new ELL.ORDERING()
            {
                ProductID = Convert.ToInt32(dr["PRODUCTID"]),
                ProductName = Convert.ToString(dr["PRODUCTNAME"]),
                Piece = Convert.ToInt32(dr["PIECE"]),
                TotalPrice = Convert.ToInt32(dr["TOTALPRICE"])
            };
            return Ordering;
        }

        public static ELL.ORDERING[] BranchMonthlyOrderingList(DateTime StartDate, DateTime DueDate, int BranchID)
        {
            List<ELL.ORDERING> Ordering = new List<ELL.ORDERING>();
            SqlCommand kmt = new SqlCommand("PR_BRANCHMONTHLYREPORTLIST", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("STARTDATE", StartDate);
            kmt.Parameters.AddWithValue("DUEDATE", DueDate);
            kmt.Parameters.AddWithValue("BRANCHID", BranchID);
            SqlDataReader dr = kmt.ExecuteReader();
            while (dr.Read())
            {
                Ordering.Add(BranchDailyOrderingList(dr));
            }
            return Ordering.ToArray();
        }

        public static ELL.ORDERING[] MonthlyOrderingList(DateTime StartDate, DateTime DueDate)
        {
            List<ELL.ORDERING> Ordering = new List<ELL.ORDERING>();
            SqlCommand kmt = new SqlCommand("PR_MONTHLYREPORTLIST", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("STARTDATE", StartDate);
            kmt.Parameters.AddWithValue("DUEDATE", DueDate);
            SqlDataReader dr = kmt.ExecuteReader();
            while (dr.Read())
            {
                Ordering.Add(BranchDailyOrderingList(dr));
            }
            return Ordering.ToArray();
        }
    }
}
