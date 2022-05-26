using DevExpress.XtraEditors;
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
    public partial class Login : DevExpress.XtraEditors.XtraForm
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                BLL.HELPER.MessageBox("Kullanici Adi Bos Birakilamaz");
            }
            else
            {
                if (string.IsNullOrEmpty(txtUserPassword.Text))
                {
                    BLL.HELPER.MessageBox("Sifre Bos Birakilamaz");
                }
                else
                {
                    int EmployeeID = BLL.EMPLOYEE.EmployeeLoginControl(txtUserName.Text, txtUserPassword.Text);
                    if(EmployeeID == 0)
                    {
                        BLL.HELPER.MessageBox("Kullanici Adi Veya Sifre Hatali");
                    }
                    else
                    {
                        this.Hide();
                        Home frm = new Home();
                        frm.EmployeeID = EmployeeID;
                        frm.Show();
                    }
                }
            }
        }
    }
}
