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
using DevExpress.Data;
using DevExpress.XtraCharts;

namespace FRANCHISE
{
    public partial class InsMonthlyReport : DevExpress.XtraEditors.XtraForm
    {
        public InsMonthlyReport()
        {
            InitializeComponent();
        }

        private void gridview1()
        {
            ELL.SITTING[] Sitting = BLL.SITTING.SittingPaymentReport(Convert.ToDateTime(dtpStartDate.Text), Convert.ToDateTime(dtpDueDate.Text));
            gridControl1.DataSource = null;
            gridView1.Columns.Clear();
            gridControl1.DataSource = Sitting;
            gridView1.Columns[0].Visible = false;
            gridView1.Columns[1].Visible = false;
            gridView1.Columns[4].Visible = false;
            gridView1.Columns[2].Visible = false;
            gridView1.Columns[5].Visible = false;
            gridView1.Columns[6].Visible = false;
            gridView1.Columns[8].Visible = false;
            gridView1.Columns[9].Visible = false;
            gridView1.Columns[10].Visible = false;
            gridView1.Columns[3].Caption = "TOPLAM TUTAR";
            gridView1.Columns[7].Caption = "ODEME TÜR";

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

        private void gridview2()
        {
            ELL.ORDERING[] Ordering = BLL.ORDERING.MonthlyOrderingList(Convert.ToDateTime(dtpStartDate.Text), Convert.ToDateTime(dtpDueDate.Text));
            gridControl2.DataSource = null;
            gridView2.Columns.Clear();
            gridControl2.DataSource = Ordering;
            gridView2.Columns[0].Visible = false;
            gridView2.Columns[1].Visible = false;
            gridView2.Columns[2].Visible = false;
            gridView2.Columns[5].Visible = false;
            gridView2.Columns[7].Visible = false;
            gridView2.Columns[8].Visible = false;
            gridView2.Columns[9].Visible = false;
            gridView2.Columns[10].Visible = false;
            gridView2.Columns[11].Visible = false;
            gridView2.Columns[12].Visible = false;
            gridView2.Columns[3].Caption = "ÜRÜN AD";
            gridView2.Columns[4].Caption = "ADET";
            gridView2.Columns[6].Caption = "TOPLAM FİYAT";
            this.gridControl2.TabIndex = 0;
            this.gridView2.OptionsBehavior.Editable = false;// gridview hücre focuslanmasını iptal eder. 
            this.gridView2.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;  //çok uzun başlıklarda alt satıra geçer.
            this.gridView2.ColumnPanelRowHeight = 50; //gridview header yüksekliği
            this.gridView2.RowHeight = 50;
            gridView2.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Blue;
            gridView2.Appearance.HeaderPanel.BorderColor = Color.Black;


            gridView2.Columns[6].SummaryItem.SummaryType = SummaryItemType.Sum;
            gridView2.Columns[6].SummaryItem.DisplayFormat = "Fiyat = {0:n2}";


            
        }



        private void InsMonthlyReport_Load(object sender, EventArgs e)
        {

        }

        private void btnList_Click(object sender, EventArgs e)
        {
            gridview1();
            gridview2();
        }
    }
}
