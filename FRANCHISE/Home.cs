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
    public partial class Home : DevExpress.XtraEditors.XtraForm
    {
        public int EmployeeID;
        public int InsID;
        public int BranchID;
        


        public Home()
        {
            InitializeComponent();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            ELL.EMPLOYEE Employee = BLL.EMPLOYEE.EmployeeBring(EmployeeID);
            EmployeeName.NullText = Employee.EmployeeName + " " + Employee.EmployeeSurName;
            BranchName.NullText = Employee.BranchName;
            AppellationName.NullText = Employee.AppellationName;

            ELL.BRANCH Branch = BLL.BRANCH.BranchBring(Employee.BranchID);
            InsName.NullText = Branch.InsName;
            InsID = Branch.InsID;
            BranchID = Branch.BranchID;
        }

        private void btnInsBranch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string FormName = "InsBranch";
            int Authority = BLL.EMPLOYEEAUTHORITY.PageControl(EmployeeID, FormName);
            if(Authority != 0)
            {
                InsBranch frm = new InsBranch();
                frm.MdiParent = this;
                frm.InsID = InsID;
                frm.Show();
            }
            else
            {
                BLL.HELPER.MessageBox("Bu Sayfaya Giris Yetkiniz Yoktur !");
            }

            
        }

        private void btnAppellation_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string FormName = "InsAppellation";
            int Authority = BLL.EMPLOYEEAUTHORITY.PageControl(EmployeeID, FormName);
            if(Authority != 0)
            {
                InsAppellation frm = new InsAppellation();
                frm.MdiParent = this;
                frm.Show();
            }
            else
            {
                BLL.HELPER.MessageBox("Bu Sayfaya Giris Yetkiniz Yoktur !");
            }
        }

        private void btnInsEmployee_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string FormName = "InsEmployee";
            int Authority = BLL.EMPLOYEEAUTHORITY.PageControl(EmployeeID, FormName);
            if (Authority != 0)
            {
                InsEmployee frm = new InsEmployee();
                frm.InsID = InsID;
                frm.MdiParent = this;
                frm.Show();
            }
            else
            {
                BLL.HELPER.MessageBox("Bu Sayfaya Giris Yetkiniz Yoktur !");
            }
        }

        private void btnMainCategory_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string FormName = "MainCategory";
            int Authority = BLL.EMPLOYEEAUTHORITY.PageControl(EmployeeID, FormName);
            if (Authority != 0)
            {
                MainCategory frm = new MainCategory();
                frm.MdiParent = this;
                frm.Show();

            }
            else
            {
                BLL.HELPER.MessageBox("Bu Sayfaya Giris Yetkiniz Yoktur !");
            }
        }

        private void btnCategory_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string FormName = "Category";
            int Authority = BLL.EMPLOYEEAUTHORITY.PageControl(EmployeeID, FormName);
            if (Authority != 0)
            {
                Category frm = new Category();
                frm.MdiParent = this;
                frm.Show();
            }
            else
            {
                BLL.HELPER.MessageBox("Bu Sayfaya Giris Yetkiniz Yoktur !");
            }
        }

        private void btnInsProduct_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string FormName = "Product";
            int Authority = BLL.EMPLOYEEAUTHORITY.PageControl(EmployeeID, FormName);
            if (Authority != 0)
            {
                Product frm = new Product();
                frm.MdiParent = this;
                frm.Show();
            }
            else
            {
                BLL.HELPER.MessageBox("Bu Sayfaya Giris Yetkiniz Yoktur !");
            }
        }

        private void btnPayment_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string FormName = "InsPayment";
            int Authority = BLL.EMPLOYEEAUTHORITY.PageControl(EmployeeID, FormName);
            if (Authority != 0)
            {
                InsPayment frm = new InsPayment();
                frm.MdiParent = this;
                frm.Show();
            }
            
             else
            {
                BLL.HELPER.MessageBox("Bu Sayfaya Giris Yetkiniz Yoktur !");
            }
        }

        private void btnBranchBoard_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string FormName = "BranchBoard";
            int Authority = BLL.EMPLOYEEAUTHORITY.PageControl(EmployeeID, FormName);
            if (Authority != 0)
            {
                BranchBoard frm = new BranchBoard();
                frm.MdiParent = this;
                frm.BranchID = BranchID;
                frm.Show();
            }
            else
            {
                BLL.HELPER.MessageBox("Bu Sayfaya Giris Yetkiniz Yoktur !");
            }
        }

        private void btnBranchStockStatus_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string FormName = "BranchStockStatus";
            int Authority = BLL.EMPLOYEEAUTHORITY.PageControl(EmployeeID, FormName);
            if (Authority != 0)
            {
                BranchStockStatus frm = new BranchStockStatus();
                frm.BranchID = BranchID;
                frm.MdiParent = this;
                frm.Show();
            }
             else
            {
                BLL.HELPER.MessageBox("Bu Sayfaya Giris Yetkiniz Yoktur !");
            }
        }

        private void btnBranchEmployee_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string FormName = "BranchEmployee";
            int Authority = BLL.EMPLOYEEAUTHORITY.PageControl(EmployeeID, FormName);
            if (Authority != 0)
            {
                BranchEmployee frm = new BranchEmployee();
            frm.BranchID = BranchID;
            frm.MdiParent = this;
            frm.Show();
            }
            else
            {
                BLL.HELPER.MessageBox("Bu Sayfaya Giris Yetkiniz Yoktur !");
            }
        }

        private void btnBranchBoardStatus_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string FormName = "BranchBoardStatus";
            int Authority = BLL.EMPLOYEEAUTHORITY.PageControl(EmployeeID, FormName);
            if (Authority != 0)
            {
                BranchBoardStatus frm = new BranchBoardStatus();
            frm.BranchID = BranchID;
            frm.MdiParent = this;
            frm.Show();
            }
            else
            {
                BLL.HELPER.MessageBox("Bu Sayfaya Giris Yetkiniz Yoktur !");
            }
        }
    

        private void btnGetPaid_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string FormName = "BranchGetPaid";
            int Authority = BLL.EMPLOYEEAUTHORITY.PageControl(EmployeeID, FormName);
            if (Authority != 0)
            {
                BranchGetPaid frm = new BranchGetPaid();
            frm.BranchID = BranchID;
            frm.MdiParent = this;
            frm.Show();
            }
            else
            {
                BLL.HELPER.MessageBox("Bu Sayfaya Giris Yetkiniz Yoktur !");
            }
        }

        private void btnDiscount_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string FormName = "InsDis";
            int Authority = BLL.EMPLOYEEAUTHORITY.PageControl(EmployeeID, FormName);
            if (Authority != 0)
            {
                InsDis frm = new InsDis();
            frm.MdiParent = this;
            frm.Show();
            }
            else
            {
                BLL.HELPER.MessageBox("Bu Sayfaya Giris Yetkiniz Yoktur !");
            }
        }

        private void btnBranchDailyReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string FormName = "BranchDailyReport";
            int Authority = BLL.EMPLOYEEAUTHORITY.PageControl(EmployeeID, FormName);
            if (Authority != 0)
            {
                BranchDailyReport frm = new BranchDailyReport();
            frm.BranchID = BranchID;
            frm.MdiParent = this;
            frm.Show();
            }
            else
            {
                BLL.HELPER.MessageBox("Bu Sayfaya Giris Yetkiniz Yoktur !");
            }
        }

        private void btnBranchMonthlyReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string FormName = "BranchMonthlyReport";
            int Authority = BLL.EMPLOYEEAUTHORITY.PageControl(EmployeeID, FormName);
            if (Authority != 0)
            {
                BranchMonthlyReport frm = new BranchMonthlyReport();
            frm.MdiParent = this;
            frm.BranchID = BranchID;
            frm.Show();
            }
            else
            {
                BLL.HELPER.MessageBox("Bu Sayfaya Giris Yetkiniz Yoktur !");
            }
        }

        private void btnAuthority_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string FormName = "InsAuthority";
            int Authority = BLL.EMPLOYEEAUTHORITY.PageControl(EmployeeID, FormName);
            if (Authority != 0)
            {
                InsAuthority frm = new InsAuthority();
            frm.MdiParent = this;
            frm.Show();
            }
            else
            {
                BLL.HELPER.MessageBox("Bu Sayfaya Giris Yetkiniz Yoktur !");
            }
        }

        private void btnInsEmpAut_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string FormName = "InsEmployeeAuthority";
            int Authority = BLL.EMPLOYEEAUTHORITY.PageControl(EmployeeID, FormName);
            if (Authority != 0)
            {
                InsEmployeeAuthority frm = new InsEmployeeAuthority();
            frm.InsID = InsID;
            frm.MdiParent = this;
            frm.Show();
            }
            else
            {
                BLL.HELPER.MessageBox("Bu Sayfaya Giris Yetkiniz Yoktur !");
            }
        }

        private void btnInsDailyReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            string FormName = "InsDailyReport";
            int Authority = BLL.EMPLOYEEAUTHORITY.PageControl(EmployeeID, FormName);
            if(Authority != 0)
            {
                InsDailyReport frm = new InsDailyReport();
                frm.InsID = InsID;
                frm.MdiParent = this;
                frm.Show();
            }
            else
            {
                BLL.HELPER.MessageBox("Bu Sayfaya Giris Yetkiniz Yoktur !");
            }
        }

        private void btnMonthlyReport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
                InsMonthlyReport frm = new InsMonthlyReport();
                frm.MdiParent = this;
                frm.Show();
            
        }
    }
}
