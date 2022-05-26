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
    public class SITTING
    {
        public static ELL.SITTING SittingControl(int BoardID, int BranchID, string State)
        {
            ELL.SITTING Sitting = new ELL.SITTING();
            SqlCommand kmt = new SqlCommand("PR_SITTINGCONTROL", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("BOARDID", BoardID);
            kmt.Parameters.AddWithValue("BRANCHID", BranchID);
            kmt.Parameters.AddWithValue("SITTINGSTATE", State);
            SqlDataReader dr = kmt.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                Sitting.SittingID = Convert.ToInt32(dr["SITTINGID"]);
                Sitting.BoardID = Convert.ToInt32(dr["BOARDID"]);
                Sitting.BranchID = Convert.ToInt32(dr["BRANCHID"]);
                Sitting.StartDate = Convert.ToDateTime(dr["STARTDATE"]);
                Sitting.SittingState = Convert.ToString(dr["SITTINGSTATE"]);
                return Sitting;
            }
            else return Sitting;
        }
        public static void StartSitting(ELL.SITTING Sitting)
        {
            SqlCommand kmt = new SqlCommand("PR_STARTSITTING", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("BOARDID", Sitting.BoardID);
            kmt.Parameters.AddWithValue("BRANCHID", Sitting.BranchID);
            kmt.Parameters.AddWithValue("STARTDATE", Sitting.StartDate);
            kmt.Parameters.AddWithValue("SITTINGSTATE", Sitting.SittingState);
            kmt.Parameters.AddWithValue("TOTALPRICE", Sitting.TotalPrice);
            kmt.ExecuteNonQuery();
            CONNECTION.EndConnection(CONNECTION.getConnection());
        }
        public static void CloseSitting(ELL.SITTING Sitting)
        {
            SqlCommand kmt = new SqlCommand("PR_CLOSESITTING", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("SITTINGID", Sitting.SittingID);
            kmt.Parameters.AddWithValue("DUEDATE", Sitting.DueDate);
            kmt.Parameters.AddWithValue("SITTINGSTATE", Sitting.SittingState);
            kmt.Parameters.AddWithValue("TOTALPRICE", Sitting.TotalPrice);
            kmt.Parameters.AddWithValue("TYPEOFPAYMENTID", Sitting.TypeOfPaymentID);
            kmt.Parameters.AddWithValue("DISCOUNTID", Sitting.DisID);
            kmt.ExecuteNonQuery();
            CONNECTION.EndConnection(CONNECTION.getConnection());
        }














        public static ELL.SITTING[] BranchSittingPaymentReport(DateTime StartDate, DateTime DueDate, int BranchID)
        {
            List<ELL.SITTING> Sitting = new List<ELL.SITTING>();
            SqlCommand kmt = new SqlCommand("PR_BRANCHMONTHLYPAYMENTLIST", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("STARTDATE", StartDate);
            kmt.Parameters.AddWithValue("DUEDATE", DueDate);
            kmt.Parameters.AddWithValue("BRANCHID", BranchID);
            SqlDataReader dr = kmt.ExecuteReader();
            while (dr.Read())
            {
                Sitting.Add(SittingPaymentLoad(dr));
            }
            return Sitting.ToArray();
        }
        public static ELL.SITTING SittingPaymentLoad(SqlDataReader dr)
        {
            ELL.SITTING Sitting = new ELL.SITTING()
            {
                TypeOfPaymentName = Convert.ToString(dr["TYPEOFPAYMENTNAME"]),
                TotalPrice = Convert.ToDecimal(dr["TOTALPRICE"])
            };
            return Sitting;
        }






        public static ELL.SITTING[] SittingPaymentReport(DateTime StartDate, DateTime DueDate)
        {
            List<ELL.SITTING> Sitting = new List<ELL.SITTING>();
            SqlCommand kmt = new SqlCommand("PR_MONTHLYPAYMENTLIST", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("STARTDATE", StartDate);
            kmt.Parameters.AddWithValue("DUEDATE", DueDate);
            SqlDataReader dr = kmt.ExecuteReader();
            while (dr.Read())
            {
                Sitting.Add(SittingPaymentLoad(dr));
            }
            return Sitting.ToArray();
        }
    }
}
