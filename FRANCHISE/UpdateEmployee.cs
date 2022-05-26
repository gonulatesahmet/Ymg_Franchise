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
    public partial class UpdateEmployee : DevExpress.XtraEditors.XtraForm
    {
        public int InsID;
        public int BranchID;
        public int EmployeeID;
        public UpdateEmployee()
        {
            InitializeComponent();
        }
        private void AppellationList()
        {
            ELL.APPELLATION[] Appellation = BLL.APPELLATION.AppellationList();
            lupAppellation.Properties.DataSource = Appellation;
            lupAppellation.Properties.DisplayMember = "AppellationName";
            lupAppellation.Properties.ValueMember = "AppellationID";
            lupAppellation.Properties.PopulateColumns();
            lupAppellation.Properties.Columns[0].Visible = false;
            lupAppellation.Properties.Columns[2].Visible = false;
            lupAppellation.Properties.Columns[3].Visible = false;
            lupAppellation.Properties.Columns[4].Visible = false;
        }
        private void BranchList()
        {
            ELL.BRANCH[] Branch = BLL.BRANCH.BranchList(InsID);
            lupBranch.Properties.DisplayMember = "BranchName";
            lupBranch.Properties.ValueMember = "BranchID";
            lupBranch.Properties.PopulateColumns();
            lupBranch.Properties.Columns[0].Visible = false;
            lupBranch.Properties.Columns[2].Visible = false;
            lupBranch.Properties.Columns[3].Visible = false;
            lupBranch.Properties.Columns[4].Visible = false;
            lupBranch.Properties.Columns[5].Visible = false;
            lupBranch.Properties.Columns[6].Visible = false;
            lupBranch.Properties.Columns[7].Visible = false;
            lupBranch.Properties.Columns[8].Visible = false;
            lupBranch.Properties.Columns[9].Visible = false;
            lupBranch.Properties.Columns[10].Visible = false;
        }
        private void UpdateEmployee_Load(object sender, EventArgs e)
        {
            AppellationList();
            ELL.EMPLOYEE Employee = BLL.EMPLOYEE.EmployeeBring(EmployeeID);
            txtEmployeeName.Text = Employee.EmployeeName;
            txtEmployeeSurname.Text = Employee.EmployeeSurName;
            txtEmployeeIDNumber.Text = Employee.EmployeeIDNumber;
            dtpEmployeeBirthDate.Text = Employee.EmployeeBirthDate.ToString();
            txtUserName.Text = Employee.UserName;
            txtUserPassword.Text = Employee.UserPassword;
            txtEmployeeCode.Text = Employee.EmployeeCode;
            lupAppellation.EditValue = Employee.AppellationID;
            lupBranch.EditValue = Employee.BranchID;
            txtEmployeePhone.Text = Employee.EmployeePhone;
            txtEmployeeAddress.Text = Employee.EmployeeAddress;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ELL.EMPLOYEE Employee = new ELL.EMPLOYEE()
            {
                EmployeeName = txtEmployeeName.Text,
                EmployeeSurName = txtEmployeeSurname.Text,
                EmployeeIDNumber = txtEmployeeIDNumber.Text,
                EmployeeBirthDate = Convert.ToDateTime(dtpEmployeeBirthDate.Text),
                UserName = txtUserName.Text,
                UserPassword = txtUserPassword.Text,
                EmployeeCode = txtEmployeeCode.Text,
                AppellationID = Convert.ToInt32(lupAppellation.EditValue),
                EmployeePhone = txtEmployeePhone.Text,
                EmployeeAddress = txtEmployeeAddress.Text,
                EmployeeID = EmployeeID
            };
            if(BranchID != 0)
            {
                Employee.BranchID = BranchID;
                BLL.EMPLOYEE.UpdateEmployee(Employee);
                BLL.HELPER.MessageBox("Calisan Basariyla Guncellenmistir");
                BranchEmployee frm = (BranchEmployee)Application.OpenForms["BranchEmployee"];
                frm.EmployeeList();
                this.Hide();
            }
            else
            {
                Employee.BranchID = Convert.ToInt32(lupBranch.EditValue);
                BLL.EMPLOYEE.UpdateEmployee(Employee);
                BLL.HELPER.MessageBox("Calisan Basariyla Guncellenmistir");
                InsEmployee frm = (InsEmployee)Application.OpenForms["InsEmployee"];
                frm.EmployeeList();
                this.Hide();
            }
           
        }
    }
}
