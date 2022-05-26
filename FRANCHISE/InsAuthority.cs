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
    public partial class InsAuthority : DevExpress.XtraEditors.XtraForm
    {
        public int AuthorityID;
        public string AuthorityState = string.Empty;
        public InsAuthority()
        {
            InitializeComponent();
        }
        public void AuthorityList()
        {
            ELL.AUTHORITY[] Authority = BLL.AUTHORITY.AuthorityList();
            gridControl1.DataSource = null;
            gridView1.Columns.Clear();
            gridControl1.DataSource = Authority;
            gridView1.Columns[0].Visible = false;
            gridView1.Columns[1].Caption = "YETKİ AD";
            gridView1.Columns[2].Caption = "YETKİ KOD";
            gridView1.Columns[3].Caption = "YETKİ AÇIKLAMA";
            gridView1.Columns[4].Caption = "YETKİ DURUM";
            this.gridControl1.TabIndex = 0;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;          // 0. satıra bir arama satırı getirir
            this.gridView1.OptionsBehavior.Editable = false;// gridview hücre focuslanmasını iptal eder. 
            this.gridView1.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;  //çok uzun başlıklarda alt satıra geçer.
            this.gridView1.ColumnPanelRowHeight = 50; //gridview header yüksekliği
            gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Blue;
            gridView1.Appearance.HeaderPanel.BorderColor = Color.Black;
        }
        private void ButtonStatus()
        {
            if (AuthorityID != 0)
            {
                btnDelete.Enabled = true;
                btnChangeState.Enabled = true;
            }
            else
            {
                btnDelete.Enabled = false;
                btnChangeState.Enabled = false;
            }
        }


        private void InsAuthority_Load(object sender, EventArgs e)
        {
            AuthorityList();
            ButtonStatus();
        }




        private void btnAdd_Click(object sender, EventArgs e)
        {
            ELL.AUTHORITY Authorty = new ELL.AUTHORITY()
            {
                AuthorityName = txtBranchName.Text,
                AuthorityCode = txtBranchCode.Text,
                AuthorityDescription = txtBranchDescription.Text,
                AuthorityState = "100"
            };
            try
            {
                BLL.AUTHORITY.AddAuthority(Authorty);
                BLL.HELPER.MessageBox("Yetki Basariyla Eklenmistir");
                AuthorityList();
            }
            catch (Exception)
            {

                throw;
            }
        }





        private void btnChangeState_Click(object sender, EventArgs e)
        {
            string Text;
            string State;
            if (AuthorityState == "Aktif")
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
                BLL.AUTHORITY.ChangeStateAuthority(AuthorityID, State);
                AuthorityID = 0;
                AuthorityState = string.Empty;
                BLL.HELPER.MessageBox(Text);
                AuthorityList();
                ButtonStatus();
            }
            catch (Exception)
            {
                BLL.HELPER.MessageBox("Durum Degistirilemedi");
                throw;
            }
        }






        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                BLL.AUTHORITY.DeleteAuthority(AuthorityID);
                BLL.HELPER.MessageBox("Yetki Basariyla Silindi");
            }
            catch (Exception)
            {

                throw;
            }
        }





        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue("CategoryID") != null)
            {
                AuthorityID = Convert.ToInt32(gridView1.GetFocusedRowCellValue("AuthorityID").ToString());
                AuthorityState = Convert.ToString(gridView1.GetFocusedRowCellValue("AuthorityState").ToString());
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
                string Kategori = View.GetRowCellDisplayText(e.RowHandle, View.Columns["AuthorityState"]);
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
    }
}
