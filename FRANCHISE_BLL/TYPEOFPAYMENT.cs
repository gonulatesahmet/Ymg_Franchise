using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ELL = FRANCHISE_ELL;
using DAL = FRANCHISE_DAL;
namespace FRANCHISE_BLL
{
    public class TYPEOFPAYMENT
    {
        public static ELL.TYPEOFPAYMENT[] TypeOfPaymentList()
        {
            ELL.TYPEOFPAYMENT[] TypeOfPayment = DAL.TYPEOFPAYMENT.TypeOfPaymentList();
            return TypeOfPayment;
        }
        public static ELL.TYPEOFPAYMENT TypeOfPaymentBring(int TypeOfPaymentID)
        {
            ELL.TYPEOFPAYMENT TypeOfPayment = DAL.TYPEOFPAYMENT.TypeOfPaymentBring(TypeOfPaymentID);
            return TypeOfPayment;
        }
        public static void AddTypeOfPayment(ELL.TYPEOFPAYMENT TypeOfPayment)
        {
            DAL.TYPEOFPAYMENT.AddTypeOfPayment(TypeOfPayment);
        }
        public static void UpdateTypeOfPayment(ELL.TYPEOFPAYMENT TypeOfPayment)
        {
            DAL.TYPEOFPAYMENT.UpdateTypeOfPayment(TypeOfPayment);
        }
        public static void ChangeStateTypeOfPayment(int TypeOfPaymentID, string TypeOfPaymentState)
        {
            DAL.TYPEOFPAYMENT.ChangeStateTypeOfPayment(TypeOfPaymentID, TypeOfPaymentState);
        }
        public static void DeleteTypeOfPayment(int TypeOfPaymentID)
        {
            DAL.TYPEOFPAYMENT.DeleteTypeOfPayment(TypeOfPaymentID);
        }
    }
}
