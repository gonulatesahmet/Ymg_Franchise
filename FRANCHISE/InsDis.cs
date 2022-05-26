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
    public partial class InsDis : DevExpress.XtraEditors.XtraForm
    {
        public int DisID;
        public string DisState = string.Empty;
        public InsDis()
        {
            InitializeComponent();
        }
        public void DisList()
        {
            ELL.DISCOUNT[] Dis = BLL.DISCOUNT.DisList();
            gridControl1.DataSource = null;
            gridView1.Columns.Clear();
            gridControl1.DataSource = Dis;
            gridView1.Columns[0].Visible = false;
            gridView1.Columns[1].Caption = "İNDİRİM AD";
            gridView1.Columns[2].Caption = "İNDİRİM KOD";
            gridView1.Columns[3].Caption = "İNDİRİM AÇIKLAMA";
            gridView1.Columns[4].Caption = "İNDİRİM ORAN";
            gridView1.Columns[5].Caption = "İNDİRİM DURUM";
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
            if (DisID != 0)
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





        private void InsDis_Load(object sender, EventArgs e)
        {
            DisList();
            ButtonStatus();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue("DisID") != null)
            {
                DisID = Convert.ToInt32(gridView1.GetFocusedRowCellValue("DisID").ToString());
                DisState = Convert.ToString(gridView1.GetFocusedRowCellValue("DisState").ToString());
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
                string Kategori = View.GetRowCellDisplayText(e.RowHandle, View.Columns["DisState"]);
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
            ELL.DISCOUNT Dis = new ELL.DISCOUNT()
            {
                DisName = txtBranchName.Text,
                DisCode = txtBranchCode.Text,
                DisDescription = txtBranchDescription.Text,
                DisRate = Convert.ToInt32(txtRate.Text),
                DisState = "100"
            };
            try
            {
                BLL.DISCOUNT.AddDis(Dis);
                BLL.HELPER.MessageBox("Indirim Eklenmistir");
                DisList();
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
            if (DisState == "Aktif")
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
                BLL.DISCOUNT.ChangeStateDis(DisID, State);
                DisID = 0;
                DisState = string.Empty;
                BLL.HELPER.MessageBox(Text);
                DisList();
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
                BLL.DISCOUNT.DeleteDis(DisID);
                BLL.HELPER.MessageBox("Indirim Silinmistir");
                DisID = 0;
                ButtonStatus();
                DisList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
