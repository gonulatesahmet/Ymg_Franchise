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
    public partial class InsAppellation : DevExpress.XtraEditors.XtraForm
    {
        public int AppellationID;
        public string AppellationState = string.Empty;
        public InsAppellation()
        {
            InitializeComponent();
        }
        public void AppellationList()
        {
            ELL.APPELLATION[] Appellation = BLL.APPELLATION.AppellationList();
            gridControl1.DataSource = null;
            gridView1.Columns.Clear();
            gridControl1.DataSource = Appellation;
            gridView1.Columns[0].Visible = false;
            gridView1.Columns[1].Caption = "UNVAN AD";
            gridView1.Columns[2].Caption = "UNVAN KOD";
            gridView1.Columns[3].Caption = "UNVAN AÇIKLAMA";
            gridView1.Columns[5].Caption = "YETKI AD";
            gridView1.Columns[6].Caption = "UNVAN DURUM";
            this.gridControl1.TabIndex = 0;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;          // 0. satıra bir arama satırı getirir
            this.gridView1.OptionsBehavior.Editable = false;// gridview hücre focuslanmasını iptal eder. 
            this.gridView1.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;  //çok uzun başlıklarda alt satıra geçer.
            this.gridView1.ColumnPanelRowHeight = 50; //gridview header yüksekliği
            gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Blue;
            gridView1.Appearance.HeaderPanel.BorderColor = Color.Black;
        }






        private void AuthorityList()
        {
            ELL.AUTHORITY[] Authority = BLL.AUTHORITY.AuthorityList();
            lupAuthority.Properties.DataSource = Authority;
            lupAuthority.Properties.DisplayMember = "AuthorityName";
            lupAuthority.Properties.ValueMember = "AuthorityID";
            lupAuthority.Properties.PopulateColumns();
            lupAuthority.Properties.Columns[0].Visible = false;
            lupAuthority.Properties.Columns[2].Visible = false;
            lupAuthority.Properties.Columns[3].Visible = false;
            lupAuthority.Properties.Columns[4].Visible = false;
        }





        private void ButtonStatus()
        {
            if (AppellationID != 0)
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





        private void InsAppellation_Load(object sender, EventArgs e)
        {
            AppellationList();
            AuthorityList();
            ButtonStatus();
        }





        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue("AppellationID") != null)
            {
                AppellationID = Convert.ToInt32(gridView1.GetFocusedRowCellValue("AppellationID").ToString());
                AppellationState = Convert.ToString(gridView1.GetFocusedRowCellValue("AppellationState").ToString());
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
                string Kategori = View.GetRowCellDisplayText(e.RowHandle, View.Columns["AppellationState"]);
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
            ELL.APPELLATION Appellation = new ELL.APPELLATION()
            {
                AppellationName = txtBranchName.Text,
                AppellationCode = txtBranchCode.Text,
                AppellationDescription = txtBranchDescription.Text,
                AuthorityID = Convert.ToInt32(lupAuthority.EditValue),
                AppellationState = "100"
            };
            try
            {
                BLL.APPELLATION.AddAppellation(Appellation);
                BLL.HELPER.MessageBox("Unvan Basariyla Eklendi");
                AppellationList();
            }
            catch (Exception)
            {
                BLL.HELPER.MessageBox("Unvan Eklenirken Bir Hata Olustu");
                throw;
            }
        }

        private void btnChangeState_Click(object sender, EventArgs e)
        {
            string Text;
            string State;
            if (AppellationState == "Aktif")
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
                BLL.APPELLATION.ChangeStateAppellation(AppellationID, State);
                AppellationID = 0;
                AppellationState = string.Empty;
                BLL.HELPER.MessageBox(Text);
                AppellationList();
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
            UpdateAppellation frm = new UpdateAppellation();
            frm.AppellationID = AppellationID;
            frm.Show();
            AppellationID = 0;
            ButtonStatus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                BLL.APPELLATION.DeleteAppellation(AppellationID);
                BLL.HELPER.MessageBox("Sube Basariyla Silinmistir");
                AppellationID = 0;
                AppellationList();
                ButtonStatus();
            }
            catch (Exception)
            {
                BLL.HELPER.MessageBox("Sube Silinirken Bir Hata Olustu");
                throw;
            }
        }
    }
}
