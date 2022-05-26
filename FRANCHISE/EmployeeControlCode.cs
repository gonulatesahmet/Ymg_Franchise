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
    public partial class EmployeeControlCode : DevExpress.XtraEditors.XtraForm
    {
        public int BranchID;
        public int BoardID;
        private void Operation(object sender, EventArgs e)
        {
            SimpleButton btn = sender as SimpleButton;
            switch (btn.Name)
            {
                case "btn1":
                    txtCode.Text += (1).ToString();
                    break;
                case "btn2":
                    txtCode.Text += (2).ToString();
                    break;
                case "btn3":
                    txtCode.Text += (3).ToString();
                    break;
                case "btn4":
                    txtCode.Text += (4).ToString();
                    break;
                case "btn5":
                    txtCode.Text += (5).ToString();
                    break;
                case "btn6":
                    txtCode.Text += (6).ToString();
                    break;
                case "btn7":
                    txtCode.Text += (7).ToString();
                    break;
                case "btn8":
                    txtCode.Text += (8).ToString();
                    break;
                case "btn9":
                    txtCode.Text += (9).ToString();
                    break;
                case "btn0":
                    txtCode.Text += (0).ToString();
                    break;
                case "Sil":
                    if (txtCode.Text.Length == 0)
                    {
                        BLL.HELPER.MessageBox("Kutu Zaten Bos");
                    }
                    else
                    {
                        txtCode.Text = txtCode.Text.Remove(txtCode.Text.Length - 1, 1);
                    }
                    break;
                default:
                    BLL.HELPER.MessageBox("Sayi Gir");
                    break;
            }
        }
        public EmployeeControlCode()
        {
            InitializeComponent();
        }
        private void EmployeeControlCode_Load(object sender, EventArgs e)
        {
            btn1.Click += new EventHandler(Operation);
            btn2.Click += new EventHandler(Operation);
            btn3.Click += new EventHandler(Operation);
            btn4.Click += new EventHandler(Operation);
            btn5.Click += new EventHandler(Operation);
            btn6.Click += new EventHandler(Operation);
            btn7.Click += new EventHandler(Operation);
            btn8.Click += new EventHandler(Operation);
            btn9.Click += new EventHandler(Operation);
            btn0.Click += new EventHandler(Operation);
            btnDelete.Click += new EventHandler(Operation);
        }

        private void btnControl_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCode.Text))
            {
                BLL.HELPER.MessageBox("Lutfen Kodunuzu Giriniz");
            }
            else
            {
                int EmployeeID = BLL.EMPLOYEE.EmployeeBoardControl(txtCode.Text);
                if(EmployeeID == 0)
                {
                    BLL.HELPER.MessageBox("Hatali Kod Girisi");
                }
                else
                {
                    BranchBoardDeatil frm = new BranchBoardDeatil();
                    frm.BranchID = BranchID;
                    frm.BoardID = BoardID;
                    frm.EmployeeID = EmployeeID;
                    frm.Show();
                    this.Hide();
                }
            }
        }
    }
}
