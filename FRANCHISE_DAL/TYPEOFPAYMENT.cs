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
    public class TYPEOFPAYMENT
    {
        public static ELL.TYPEOFPAYMENT[] TypeOfPaymentList()
        {
            List<ELL.TYPEOFPAYMENT> TypeOfPayment = new List<ELL.TYPEOFPAYMENT>();
            SqlCommand kmt = new SqlCommand("PR_TYPEOFPAYMENTLIST", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = kmt.ExecuteReader();
            while (dr.Read())
            {
                TypeOfPayment.Add(TypeOfPaymentLoad(dr));
            }
            return TypeOfPayment.ToArray();
        }
        public static ELL.TYPEOFPAYMENT TypeOfPaymentLoad(SqlDataReader dr)
        {
            ELL.TYPEOFPAYMENT TypeOfPayment = new ELL.TYPEOFPAYMENT()
            {
                TypeOfPaymentID = Convert.ToInt32(dr["TYPEOFPAYMENTID"]),
                TypeOfPaymentName = Convert.ToString(dr["TYPEOFPAYMENTNAME"]),
                TypeOfPaymentCode = Convert.ToString(dr["TYPEOFPAYMENTCODE"]),
                TypeOfPaymentDescription = Convert.ToString(dr["TYPEOFPAYMENTDESCRIPTION"]),
                TypeOfPaymentState = Convert.ToString(dr["TYPEOFPAYMENTSTATE"])
            };
            if (TypeOfPayment.TypeOfPaymentState == "100")
            {
                TypeOfPayment.TypeOfPaymentState = "Aktif";
            }
            else TypeOfPayment.TypeOfPaymentState = "Pasif";
            return TypeOfPayment;
        }
        public static ELL.TYPEOFPAYMENT TypeOfPaymentBring(int TypeOfPaymentID)
        {
            SqlCommand kmt = new SqlCommand("PR_TYPEOFPAYMENTBRING", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("TYPEOFPAYMENTID", TypeOfPaymentID);
            SqlDataReader dr = kmt.ExecuteReader();
            if (dr.HasRows)
            {
                dr.Read();
                ELL.TYPEOFPAYMENT TypeOfPayment = new ELL.TYPEOFPAYMENT()
                {
                    TypeOfPaymentID = TypeOfPaymentID,
                    TypeOfPaymentName = Convert.ToString(dr["TYPEOFPAYMENTNAME"]),
                    TypeOfPaymentCode = Convert.ToString(dr["TYPEOFPAYMENTCODE"]),
                    TypeOfPaymentDescription = Convert.ToString(dr["TYPEOFPAYMENTDESCRIPTION"]),
                    TypeOfPaymentState = Convert.ToString(dr["TYPEOFPAYMENTSTATE"])
                };
                return TypeOfPayment;
            }
            else return null;
        }
        public static void AddTypeOfPayment(ELL.TYPEOFPAYMENT TypeOfPayment)
        {
            SqlCommand kmt = new SqlCommand("PR_ADDTYPEOFPAYMENT", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("TYPEOFPAYMENTNAME", TypeOfPayment.TypeOfPaymentName);
            kmt.Parameters.AddWithValue("TYPEOFPAYMENTCODE", TypeOfPayment.TypeOfPaymentCode);
            kmt.Parameters.AddWithValue("TYPEOFPAYMENTDESCRIPTION", TypeOfPayment.TypeOfPaymentDescription);
            kmt.Parameters.AddWithValue("TYPEOFPAYMENTSTATE", TypeOfPayment.TypeOfPaymentState);
            kmt.ExecuteNonQuery();
            CONNECTION.EndConnection(CONNECTION.getConnection());
        }
        public static void UpdateTypeOfPayment(ELL.TYPEOFPAYMENT TypeOfPayment)
        {
            SqlCommand kmt = new SqlCommand("PR_UPDATETYPEOFPAYMENT", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("TYPEOFPAYMENTNAME", TypeOfPayment.TypeOfPaymentName);
            kmt.Parameters.AddWithValue("TYPEOFPAYMENTCODE", TypeOfPayment.TypeOfPaymentCode);
            kmt.Parameters.AddWithValue("TYPEOFPAYMENTDESCRIPTION", TypeOfPayment.TypeOfPaymentDescription);
            kmt.Parameters.AddWithValue("TYPEOFPAYMENTID", TypeOfPayment.TypeOfPaymentID);
            kmt.ExecuteNonQuery();
            CONNECTION.EndConnection(CONNECTION.getConnection());
        }
        public static void ChangeStateTypeOfPayment(int TypeOfPaymentID,string TypeOfPaymentState)
        {
            SqlCommand kmt = new SqlCommand("PR_CHANGESTATETYPEOFPAYMENT", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("TYPEOFPAYMENTID", TypeOfPaymentID);
            kmt.Parameters.AddWithValue("TYPEOFPAYMENTSTATE", TypeOfPaymentState);
            kmt.ExecuteNonQuery();
            CONNECTION.EndConnection(CONNECTION.getConnection());
        }
        public static void DeleteTypeOfPayment(int TypeOfPaymentID)
        {
            SqlCommand kmt = new SqlCommand("PR_DELETETYPEOFPAYMENT", CONNECTION.getConnection());
            kmt.CommandType = CommandType.StoredProcedure;
            kmt.Parameters.AddWithValue("TYPEOFPAYMENTID", TypeOfPaymentID);
            kmt.ExecuteNonQuery();
            CONNECTION.EndConnection(CONNECTION.getConnection());
        }
    }
}
