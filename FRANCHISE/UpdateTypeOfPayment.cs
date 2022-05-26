using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ELL = FRANCHISE_ELL;
using BLL = FRANCHISE_BLL;
namespace FRANCHISE
{
    public partial class UpdateTypeOfPayment : DevExpress.XtraEditors.XtraForm
    {
        public int TypeOfPaymentID;

        public UpdateTypeOfPayment()
        {
            InitializeComponent();
        }

        private void UpdateTypeOfPayment_Load(object sender, EventArgs e)
        {
            ELL.TYPEOFPAYMENT ToPay = BLL.TYPEOFPAYMENT.TypeOfPaymentBring(TypeOfPaymentID);
            txtBranchName.Text = ToPay.TypeOfPaymentName;
            txtBranchCode.Text = ToPay.TypeOfPaymentCode;
            txtBranchDescription.Text = ToPay.TypeOfPaymentDescription;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ELL.TYPEOFPAYMENT ToPay = new ELL.TYPEOFPAYMENT()
            {
                TypeOfPaymentName = txtBranchName.Text,
                TypeOfPaymentCode = txtBranchCode.Text,
                TypeOfPaymentDescription = txtBranchDescription.Text,
                TypeOfPaymentID = TypeOfPaymentID
            };
            try
            {
                BLL.TYPEOFPAYMENT.UpdateTypeOfPayment(ToPay);
                BLL.HELPER.MessageBox("Odeme Tur Basariyla Guncellenmistir");
                InsPayment frm = (InsPayment)Application.OpenForms["InsPayment"];
                frm.TypeOfPaymentList();
                this.Hide();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
