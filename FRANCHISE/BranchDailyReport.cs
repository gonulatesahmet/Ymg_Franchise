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
using DevExpress.XtraEditors;
using DevExpress.Data;

namespace FRANCHISE
{
    public partial class BranchDailyReport : DevExpress.XtraEditors.XtraForm
    {
        public int BranchID;
        public BranchDailyReport()
        {
            InitializeComponent();
        }
        private void BranchDailyOrderingList()
        {
            ELL.ORDERING[] Ordering = BLL.ORDERING.BranchDailyOrderingList(BranchID);
            gridControl1.DataSource = null;
            gridView1.Columns.Clear();
            gridControl1.DataSource = Ordering;
            gridView1.Columns[0].Visible = false;
            gridView1.Columns[1].Visible = false;
            gridView1.Columns[2].Visible = false;
            gridView1.Columns[5].Visible = false;
            gridView1.Columns[7].Visible = false;
            gridView1.Columns[8].Visible = false;
            gridView1.Columns[9].Visible = false;
            gridView1.Columns[10].Visible = false;
            gridView1.Columns[11].Visible = false;
            gridView1.Columns[12].Visible = false;
            gridView1.Columns[3].Caption = "ÜRÜN AD";
            gridView1.Columns[4].Caption = "ADET";
            gridView1.Columns[6].Caption = "TOPLAM FİYAT";
            this.gridControl1.TabIndex = 0;
            this.gridView1.OptionsBehavior.Editable = false;// gridview hücre focuslanmasını iptal eder. 
            this.gridView1.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;  //çok uzun başlıklarda alt satıra geçer.
            this.gridView1.ColumnPanelRowHeight = 50; //gridview header yüksekliği
            this.gridView1.RowHeight = 50;
            gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Blue;
            gridView1.Appearance.HeaderPanel.BorderColor = Color.Black;


            gridView1.Columns[6].SummaryItem.SummaryType = SummaryItemType.Sum;
            gridView1.Columns[6].SummaryItem.DisplayFormat = "Fiyat = {0:n2}";
        }
        private void BranchDailyReportList()
        {
           ELL.BRANCHREPORT[] BranchList = BLL.BRANCHREPORT.BranchDailyReportList(BranchID);
            gridControl2.DataSource = null;
            gridView1.Columns.Clear();
            gridControl2.DataSource = BranchList;
            gridView2.Columns[0].Visible = false;
            gridView2.Columns[2].Visible = false;
            gridView2.Columns[3].Visible = false;
            gridView2.Columns[4].Visible = false;
            gridView2.Columns[5].Visible = false;
            gridView2.Columns[6].Visible = false;
            gridView2.Columns[7].Visible = false;
            gridView2.Columns[1].Caption = "RAPOR GÜNÜ";
            this.gridControl2.TabIndex = 0;
            this.gridView2.OptionsBehavior.Editable = false;// gridview hücre focuslanmasını iptal eder. 
            this.gridView2.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;  //çok uzun başlıklarda alt satıra geçer.
            this.gridView2.ColumnPanelRowHeight = 50; //gridview header yüksekliği
            this.gridView2.RowHeight = 50;
            gridView2.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Blue;
            gridView2.Appearance.HeaderPanel.BorderColor = Color.Black;
        }



        private void BranchDailyReport_Load(object sender, EventArgs e)
        {
            BranchDailyReportList();
            BranchDailyOrderingList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Gün Sonu Raporu Almak İstediğinizden Emin Misiniz?", "Bilgi", MessageBoxButtons.YesNo) != DialogResult.No)
            {
                int Control = BLL.BRANCHREPORT.BranchDailyReportControl(DateTime.Now, BranchID);
                if (Control != 0)
                {
                    BLL.HELPER.MessageBox("Gun Sonu Raporu Zaten Alinmis");
                }
                else
                {
                    ELL.ORDERING[] Ordering = BLL.ORDERING.BranchDailyOrderingList(BranchID);
                    for (int i = 0; i < Ordering.Length; i++)
                    {
                        ELL.BRANCHREPORT Br = new ELL.BRANCHREPORT()
                        {
                            ReportDay = DateTime.Now,
                            BranchID = BranchID,
                            Piece = Ordering[i].Piece,
                            ProductID = Ordering[i].ProductID,
                            TotalPrice = Ordering[i].TotalPrice
                        };
                        BLL.BRANCHREPORT.AddBranchDailyReport(Br);
                    }
                    BLL.HELPER.MessageBox("Gun Sonu Raporu Alindi");
                }
            }





           
        }

        private void gridView2_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            DateTime ReportDay = Convert.ToDateTime(gridView2.GetFocusedRowCellValue("ReportDay").ToString());
            ELL.BRANCHREPORT[] BranchReport = BLL.BRANCHREPORT.BranchDailyReportListDetail(BranchID, ReportDay);
            gridControl3.DataSource = null;
            gridView3.Columns.Clear();
            gridControl3.DataSource = BranchReport;
            gridView3.Columns[0].Visible = false;
            gridView3.Columns[1].Visible = false;
            gridView3.Columns[2].Visible = false;
            gridView3.Columns[6].Visible = false;
            gridView3.Columns[3].Caption = "ÜRÜN AD";
            gridView3.Columns[4].Caption = "ADET";
            gridView3.Columns[5].Caption = "TOPLAM TUTAR";
            gridView3.Columns[7].Caption = "ŞUBE ADI";

            gridView3.Columns[5].SummaryItem.SummaryType = SummaryItemType.Sum;
            gridView3.Columns[5].SummaryItem.DisplayFormat = "Fiyat = {0:n2}";
        }
    }
}
