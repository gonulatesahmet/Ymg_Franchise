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
    public partial class InsBranch : DevExpress.XtraEditors.XtraForm
    {
        public int InsID;
        public int BranchID;
        public string BranchState = string.Empty;
        public InsBranch()
        {
            InitializeComponent();
        }
        public void BranchList()
        {
            ELL.BRANCH[] Branch = BLL.BRANCH.BranchList(InsID);
            gridControl1.DataSource = null;
            gridView1.Columns.Clear();
            gridControl1.DataSource = Branch;
            gridView1.Columns[0].Visible = false;
            gridView1.Columns[4].Visible = false;
            gridView1.Columns[6].Visible = false;
            gridView1.Columns[8].Visible = false;
            gridView1.Columns[1].Caption = "ŞUBE ADI";
            gridView1.Columns[2].Caption = "ŞUBE KOD";
            gridView1.Columns[3].Caption = "ŞUBE AÇIKLAMA";
            gridView1.Columns[5].Caption = "ŞEHİR";
            gridView1.Columns[7].Caption = "İLÇE";
            gridView1.Columns[9].Caption = "KURUM";
            gridView1.Columns[10].Caption = "ŞUBE DURUM";
            this.gridControl1.TabIndex = 0;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;          // 0. satıra bir arama satırı getirir
            this.gridView1.OptionsBehavior.Editable = false;// gridview hücre focuslanmasını iptal eder. 
            this.gridView1.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;  //çok uzun başlıklarda alt satıra geçer.
            this.gridView1.ColumnPanelRowHeight = 50; //gridview header yüksekliği
            gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Blue;
            gridView1.Appearance.HeaderPanel.BorderColor = Color.Black;
        }
        private void CityList()
        {
            ELL.CITY[] City = BLL.CITY.CityList();
            lupCity.Properties.DataSource = City;
            lupCity.Properties.DisplayMember = "CityName";
            lupCity.Properties.ValueMember = "CityID";
            lupCity.Properties.PopulateColumns();
            lupCity.Properties.Columns[0].Visible = false;
        }
        private void ButtonStatus()
        {
            if(BranchID != 0)
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
        private void InsBranch_Load(object sender, EventArgs e)
        {
            BranchList();
            CityList();
            ButtonStatus();
        }
        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue("BranchID") != null) 
            {
                BranchID = Convert.ToInt32(gridView1.GetFocusedRowCellValue("BranchID").ToString());
                BranchState = Convert.ToString(gridView1.GetFocusedRowCellValue("BranchState").ToString());
                ButtonStatus();
            }
            else
            {
                BLL.HELPER.MessageBox("Lutfen Satir Seciniz");
            }
            
        }
        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                string Kategori = View.GetRowCellDisplayText(e.RowHandle, View.Columns["BranchState"]);
                if (Kategori == "Aktif")
                {
                    e.Appearance.ForeColor = Color.Black;
                }
                else
                {
                    e.Appearance.BackColor = Color.Red;
                }
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ELL.BRANCH Branch = new ELL.BRANCH()
            {
                BranchName = txtBranchName.Text,
                BranchCode = txtBranchCode.Text,
                BranchDescription = txtBranchDescription.Text,
                CityID = Convert.ToInt32(lupCity.EditValue),
                DistrictID = Convert.ToInt32(lupDistrict.EditValue),
                InsID = InsID,
                BranchState = "100"
            };
            try
            {
                BLL.BRANCH.AddBranch(Branch);
                BLL.HELPER.MessageBox("Sube Basariyla Eklendi");
                BranchList();
            }
            catch (Exception)
            {
                BLL.HELPER.MessageBox("Sube Eklenirken Bir Hata Olustu");
                throw;
            }
        }

        private void btnChangeState_Click(object sender, EventArgs e)
        {
            string Text;
            string State;
            if (BranchState == "Aktif")
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
                BLL.BRANCH.ChangeStateBranch(BranchID, State);
                BranchID = 0;
                BranchState = string.Empty;
                BLL.HELPER.MessageBox(Text);
                BranchList();
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
            UpdateBranch frm = new UpdateBranch();
            frm.BranchID = BranchID;
            frm.Show();
            BranchID = 0;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                BLL.BRANCH.DeleteBranch(BranchID);
                BLL.HELPER.MessageBox("Sube Basariyla Silinmistir");
                BranchID = 0;
                BranchList();
                ButtonStatus();
            }
            catch (Exception)
            {
                BLL.HELPER.MessageBox("Sube Silinirken Bir Hata Olustu");
                throw;
            }
        }
        private void lupCity_EditValueChanged(object sender, EventArgs e)
        {
            ELL.DISTRICT[] District = BLL.DISTRICT.DistrictList(Convert.ToInt32(lupCity.EditValue));
            lupDistrict.Properties.DataSource = District;
            lupDistrict.Properties.DisplayMember = "DistrictName";
            lupDistrict.Properties.ValueMember = "DistrictID";
            lupDistrict.Properties.PopulateColumns();
            lupDistrict.Properties.Columns[0].Visible = false;
            lupDistrict.Properties.Columns[2].Visible = false;
        }
    }
}
