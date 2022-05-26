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
using DevExpress.XtraGrid.Views.Grid;

namespace FRANCHISE
{
    public partial class InsEmployee : DevExpress.XtraEditors.XtraForm
    {
        public int InsID;
        public int EmployeeID;
        public string EmployeeState = string.Empty;
        public InsEmployee()
        {
            InitializeComponent();
        }
        public void EmployeeList()
        {
            ELL.EMPLOYEE[] Employee = BLL.EMPLOYEE.EmployeeList(InsID);
            gridControl1.DataSource = null;
            gridView1.Columns.Clear();
            gridControl1.DataSource = Employee;
            gridView1.Columns[0].Visible = false;
            gridView1.Columns[10].Visible = false;
            gridView1.Columns[12].Visible = false;
            gridView1.Columns[1].Caption = "ÇALIŞAN AD";
            gridView1.Columns[2].Caption = "ÇALIŞAN SOYAD";
            gridView1.Columns[3].Caption = "ÇALIŞAN KİMLİK NO";
            gridView1.Columns[4].Caption = "ÇALIŞAN DOĞUM TARİH";
            gridView1.Columns[5].Caption = "ÇALIŞAN TELEFON";
            gridView1.Columns[6].Caption = "ÇALIŞAN ADRES";
            gridView1.Columns[7].Caption = "ÇALIŞAN KULLANICI ADI";
            gridView1.Columns[8].Caption = "ÇALIŞAN KULLANICI ŞİFRE";
            gridView1.Columns[9].Caption = "ÇALIŞAN KOD";
            gridView1.Columns[11].Caption = "ÇALIŞAN UNVAN";
            gridView1.Columns[13].Caption = "ÇALIŞAN ŞUBE";
            gridView1.Columns[14].Caption = "ÇALIŞAN DURUM";
            this.gridControl1.TabIndex = 0;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;          // 0. satıra bir arama satırı getirir
            this.gridView1.OptionsBehavior.Editable = false;// gridview hücre focuslanmasını iptal eder. 
            this.gridView1.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;  //çok uzun başlıklarda alt satıra geçer.
            this.gridView1.ColumnPanelRowHeight = 50; //gridview header yüksekliği
            gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Blue;
            gridView1.Appearance.HeaderPanel.BorderColor = Color.Black;
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
            lupAppellation.Properties.Columns[5].Visible = false;
            lupAppellation.Properties.Columns[6].Visible = false;
        }
        private void BranchList()
        {
            ELL.BRANCH[] Branch = BLL.BRANCH.BranchList(InsID);
            lupBranch.Properties.DataSource = Branch;
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
        private void ButtonStatus()
        {
            if (EmployeeID != 0)
            {
                btnDelete.Enabled = true;
                btnUpdate.Enabled = true;
                btnChangeState.Enabled = true;
            }
            else
            {
                btnDelete.Enabled = false;
                btnUpdate.Enabled = false;
                btnChangeState.Enabled = false;
            }
        }

        private void InsEmployee_Load(object sender, EventArgs e)
        {
            EmployeeList();
            AppellationList();
            BranchList();
            ButtonStatus();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue("EmployeeID") != null)
            {
                EmployeeID = Convert.ToInt32(gridView1.GetFocusedRowCellValue("EmployeeID").ToString());
                EmployeeState = Convert.ToString(gridView1.GetFocusedRowCellValue("EmployeeState").ToString());
                ButtonStatus();
            }
            else
            {
                BLL.HELPER.MessageBox("Lutfen Satir Seciniz");
            }
        }

        private void gridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                string Kategori = View.GetRowCellDisplayText(e.RowHandle, View.Columns["EmployeeState"]);
                if (Kategori == "Aktif")
                {
                    
                }
                else
                {
                    e.Appearance.ForeColor = Color.Black;
                    e.Appearance.BackColor = Color.Red;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ELL.EMPLOYEE Employee = new ELL.EMPLOYEE()
            {
                EmployeeName = txtEmployeeName.Text,
                EmployeeSurName = txtEmployeeSurname.Text,
                EmployeeIDNumber = txtEmployeeIDNumber.Text,
                EmployeeBirthDate = Convert.ToDateTime(dtpEmployeeBirthDate.SelectedText),
                UserName = txtUserName.Text,
                UserPassword = txtUserPassword.Text,
                EmployeeCode = txtEmployeeCode.Text,
                AppellationID = Convert.ToInt32(lupAppellation.EditValue),
                BranchID = Convert.ToInt32(lupBranch.EditValue),
                EmployeePhone = txtEmployeePhone.Text,
                EmployeeAddress = txtEmployeeAddress.Text,
                EmployeeState = "100",
            };
            try
            {
                BLL.EMPLOYEE.AddEmployee(Employee);
                BLL.HELPER.MessageBox("Calisan Basariyla Eklenmistir");
                EmployeeList();
            }
            catch (Exception)
            {
                BLL.HELPER.MessageBox("Calisan Eklenirken Bir Sorun Olustu");
                throw;
            }
        }

        private void btnChangeState_Click(object sender, EventArgs e)
        {
            string Text;
            string State;
            if (EmployeeState == "Aktif")
            {
                Text = "Durum Pasif Edilmistir";
                State = "000";
            }
            else
            {
                Text = "Durum Aktif Edilmistir";
                State = "100";
            }
            try
            {
                BLL.EMPLOYEE.ChangeStateEmployee(EmployeeID, State);
                EmployeeID = 0;
                EmployeeState = string.Empty;
                BLL.HELPER.MessageBox(Text);
                EmployeeList();
                ButtonStatus();
            }
            catch (Exception)
            {
                BLL.HELPER.MessageBox("Durum Degistirilemedi");
                throw;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateEmployee frm = new UpdateEmployee();
            frm.EmployeeID = EmployeeID;
            frm.InsID = InsID;
            frm.Show();
            EmployeeID = 0;
            ButtonStatus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                BLL.EMPLOYEE.DeleteEmployee(EmployeeID);
                BLL.HELPER.MessageBox("Calisan Basariyla Silinmistir");
                EmployeeID = 0;
                ButtonStatus();
                EmployeeList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
