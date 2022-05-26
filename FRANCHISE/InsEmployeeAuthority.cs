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
    public partial class InsEmployeeAuthority : DevExpress.XtraEditors.XtraForm
    {
        public int EmpAutID;
        public int EmployeeID;
        public int InsID;
        public InsEmployeeAuthority()
        {
            InitializeComponent();
        }

        private void EmployeeList()
        {
            ELL.EMPLOYEE[] Employee = BLL.EMPLOYEE.EmployeeList(InsID);
            lupEmployee.Properties.DataSource = Employee;
            lupEmployee.Properties.DisplayMember = "EmployeeName";
            lupEmployee.Properties.ValueMember = "EmployeeID";
            lupEmployee.Properties.PopulateColumns();
            lupEmployee.Properties.Columns[0].Visible = false;
            lupEmployee.Properties.Columns[3].Visible = false;
            lupEmployee.Properties.Columns[4].Visible = false;
            lupEmployee.Properties.Columns[5].Visible = false;
            lupEmployee.Properties.Columns[6].Visible = false;
            lupEmployee.Properties.Columns[7].Visible = false;
            lupEmployee.Properties.Columns[8].Visible = false;
            lupEmployee.Properties.Columns[9].Visible = false;
            lupEmployee.Properties.Columns[10].Visible = false;
            lupEmployee.Properties.Columns[11].Visible = false;
            lupEmployee.Properties.Columns[12].Visible = false;
            lupEmployee.Properties.Columns[13].Visible = false;
            lupEmployee.Properties.Columns[14].Visible = false;
        }





        private void gridview1(int EmployeeID)
        {
            ELL.EMPLOYEEAUTHORITY[] State0 = BLL.EMPLOYEEAUTHORITY.State0List(EmployeeID);
            gridControl1.DataSource = null;
            gridView1.Columns.Clear();
            gridControl1.DataSource = State0;
            gridView1.Columns[0].Visible = false;
            gridView1.Columns[1].Visible = false;
            gridView1.Columns[3].Visible = false;
            gridView1.Columns[5].Visible = false;
            gridView1.Columns[2].Caption = "ÇALIŞAN AD";
            gridView1.Columns[4].Caption = "SAYFA AD";
            gridView1.Columns[6].Caption = "YETKİ ADI";
            gridView1.Columns[7].Caption = "İZİN DURUM";
            this.gridControl1.TabIndex = 0;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;          // 0. satıra bir arama satırı getirir
            this.gridView1.OptionsBehavior.Editable = false;// gridview hücre focuslanmasını iptal eder. 
            this.gridView1.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;  //çok uzun başlıklarda alt satıra geçer.
            this.gridView1.ColumnPanelRowHeight = 50; //gridview header yüksekliği
            gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Blue;
            gridView1.Appearance.HeaderPanel.BorderColor = Color.Black;
        }





        private void gridview2(int EmployeeID)
        {
            ELL.EMPLOYEEAUTHORITY[] State1 = BLL.EMPLOYEEAUTHORITY.State1List(EmployeeID);
            gridControl2.DataSource = null;
            gridView2.Columns.Clear();
            gridControl2.DataSource = State1;
            gridView2.Columns[0].Visible = false;
            gridView2.Columns[1].Visible = false;
            gridView2.Columns[3].Visible = false;
            gridView2.Columns[5].Visible = false;
            gridView2.Columns[2].Caption = "ÇALIŞAN AD";
            gridView2.Columns[4].Caption = "SAYFA AD";
            gridView2.Columns[6].Caption = "YETKİ ADI";
            gridView2.Columns[7].Caption = "İZİN DURUM";
            this.gridControl2.TabIndex = 0;
            this.gridView2.OptionsView.ShowAutoFilterRow = true;          // 0. satıra bir arama satırı getirir
            this.gridView2.OptionsBehavior.Editable = false;// gridview hücre focuslanmasını iptal eder. 
            this.gridView2.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;  //çok uzun başlıklarda alt satıra geçer.
            this.gridView2.ColumnPanelRowHeight = 50; //gridview header yüksekliği
            gridView2.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Blue;
            gridView2.Appearance.HeaderPanel.BorderColor = Color.Black;
        }
        private void InsEmployeeAuthority_Load(object sender, EventArgs e)
        {
            EmployeeList();
        }

        private void lupEmployee_EditValueChanged(object sender, EventArgs e)
        {
            EmployeeID = Convert.ToInt32(lupEmployee.EditValue);
            gridview1(EmployeeID);
            gridview2(EmployeeID);
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue("EmpAutID") != null)
            {
                string State = "100";
                EmpAutID = Convert.ToInt32(gridView1.GetFocusedRowCellValue("EmpAutID").ToString());
                BLL.EMPLOYEEAUTHORITY.ChangeStateEmpAut(EmpAutID, State);
                gridview1(EmployeeID);
                gridview2(EmployeeID);
            }
            else
            {
                BLL.HELPER.MessageBox("Lutfen Satir Seciniz");
            }
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            if (gridView2.GetFocusedRowCellValue("EmpAutID") != null)
            {
                string State = "000";
                EmpAutID = Convert.ToInt32(gridView2.GetFocusedRowCellValue("EmpAutID").ToString());
                BLL.EMPLOYEEAUTHORITY.ChangeStateEmpAut(EmpAutID, State);
                gridview1(EmployeeID);
                gridview2(EmployeeID);
            }
            else
            {
                BLL.HELPER.MessageBox("Lutfen Satir Seciniz");
            }
        }
    }
}
