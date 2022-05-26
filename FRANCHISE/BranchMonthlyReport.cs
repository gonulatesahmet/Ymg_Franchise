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
    public partial class BranchMonthlyReport : DevExpress.XtraEditors.XtraForm
    {
        public int BranchID;
        public BranchMonthlyReport()
        {
            InitializeComponent();
        }

        private void BranchMonthlyReport_Load(object sender, EventArgs e)
        {
            
        }


        private void gridview1()
        {

            ELL.SITTING[] Sitting = BLL.SITTING.BranchSittingPaymentReport(Convert.ToDateTime(dtpStartDate.Text), Convert.ToDateTime(dtpDueDate.Text), BranchID);
            gridControl1.DataSource = null;
            gridView3.Columns.Clear();
            gridControl1.DataSource = Sitting;
            gridView3.Columns[0].Visible = false;
            gridView3.Columns[1].Visible = false;
            gridView3.Columns[4].Visible = false;
            gridView3.Columns[2].Visible = false;
            gridView3.Columns[5].Visible = false;
            gridView3.Columns[6].Visible = false;
            gridView3.Columns[8].Visible = false;
            gridView3.Columns[9].Visible = false;
            gridView3.Columns[10].Visible = false;
            gridView3.Columns[3].Caption = "TOPLAM TUTAR";
            gridView3.Columns[7].Caption = "ODEME TÜR";

            this.gridControl1.TabIndex = 0;
            this.gridView3.OptionsBehavior.Editable = false;// gridview hücre focuslanmasını iptal eder. 
            this.gridView3.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;  //çok uzun başlıklarda alt satıra geçer.
            this.gridView3.ColumnPanelRowHeight = 50; //gridview header yüksekliği
            this.gridView3.RowHeight = 50;
            gridView3.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Blue;
            gridView3.Appearance.HeaderPanel.BorderColor = Color.Black;
            gridView3.Columns[6].SummaryItem.SummaryType = SummaryItemType.Sum;
            gridView3.Columns[6].SummaryItem.DisplayFormat = "Fiyat = {0:n2}";


            Series Series = new Series("Bar", ViewType.Bar);
            for(int i = 0; i < Sitting.Length; i++)
            {
                Series.Points.Add(new SeriesPoint(Sitting[i].TypeOfPaymentName, Sitting[i].TotalPrice));
            }
            chartControl1.Series.Add(Series);
            ((BarSeriesView)Series.View).FillStyle.FillMode = FillMode.Hatch;
            chartControl1.Series.Add(Series);


            
        }
        private void gridview2()
        {

            ELL.ORDERING[] Ordering = BLL.ORDERING.BranchMonthlyOrderingList(Convert.ToDateTime(dtpStartDate.Text), Convert.ToDateTime(dtpDueDate.Text), BranchID);
            gridControl2.DataSource = null;
            gridView4.Columns.Clear();
            gridControl2.DataSource = Ordering;
            gridView4.Columns[0].Visible = false;
            gridView4.Columns[1].Visible = false;
            gridView4.Columns[2].Visible = false;
            gridView4.Columns[5].Visible = false;
            gridView4.Columns[7].Visible = false;
            gridView4.Columns[8].Visible = false;
            gridView4.Columns[9].Visible = false;
            gridView4.Columns[10].Visible = false;
            gridView4.Columns[11].Visible = false;
            gridView4.Columns[12].Visible = false;
            gridView4.Columns[3].Caption = "ÜRÜN AD";
            gridView4.Columns[4].Caption = "ADET";
            gridView4.Columns[6].Caption = "TOPLAM FİYAT";
            this.gridControl2.TabIndex = 0;
            this.gridView4.OptionsBehavior.Editable = false;// gridview hücre focuslanmasını iptal eder. 
            this.gridView4.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;  //çok uzun başlıklarda alt satıra geçer.
            this.gridView4.ColumnPanelRowHeight = 50; //gridview header yüksekliği
            this.gridView4.RowHeight = 50;
            gridView4.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Blue;
            gridView4.Appearance.HeaderPanel.BorderColor = Color.Black;


            gridView4.Columns[6].SummaryItem.SummaryType = SummaryItemType.Sum;
            gridView4.Columns[6].SummaryItem.DisplayFormat = "Fiyat = {0:n2}";


            Series Series = new Series("Pie Chart", ViewType.Pie);
            Series.Label.TextPattern = "{A}: {V:#,#}: {VP:p2}";
            ((PieSeriesLabel)Series.Label).Position = PieSeriesLabelPosition.TwoColumns;
            ((PieSeriesLabel)Series.Label).ResolveOverlappingMode = ResolveOverlappingMode.Default;
            ChartTitle Title = new ChartTitle();
            Title.Text = "Satılan Ürünler";
            Title.WordWrap = true;
            chartControl3.Titles.Add(Title);
            for(int i = 0; i < Ordering.Length; i++)
            {
                Series.Points.Add(new SeriesPoint(Ordering[i].ProductName,Ordering[i].Piece));
            }
            PieSeriesView myView = (PieSeriesView)Series.View;
            myView.ExplodedPointsFilters.Add(new SeriesPointFilter(SeriesPointKey.Value_1, DataFilterCondition.GreaterThanOrEqual, 9));
            myView.ExplodedPointsFilters.Add(new SeriesPointFilter(SeriesPointKey.Argument, DataFilterCondition.NotEqual, "Others"));
            myView.ExplodeMode = PieExplodeMode.UseFilters;
            myView.ExplodedDistancePercentage = 30;
            myView.RuntimeExploding = true;
            myView.HeightToWidthRatio = 0.75;
            chartControl3.Series.Add(Series);



            Series Series2 = new Series("Pie Chart 3D", ViewType.Pie);
            Series2.Label.TextPattern = "{A}: {V:c2}: {VP:p2}";
            ((PieSeriesLabel)Series2.Label).Position = PieSeriesLabelPosition.TwoColumns;
            ((PieSeriesLabel)Series2.Label).ResolveOverlappingMode = ResolveOverlappingMode.Default;
            Title.WordWrap = true;
            chartControl2.Titles.Add(Title);
            for(int i = 0; i <Ordering.Length; i++)
            {
                Series2.Points.Add(new SeriesPoint(Ordering[i].ProductName, Ordering[i].TotalPrice));
            }
            chartControl2.Series.Add(Series2);
        }



        private void BranchDailyReport()
        {
            ELL.BRANCHREPORT[] BranchReport = BLL.BRANCHREPORT.BranchMonthlyReport(Convert.ToDateTime(dtpStartDate.Text), Convert.ToDateTime(dtpDueDate.Text), BranchID);
            Series Series = new Series("Bar", ViewType.Bar);
            for(int i = 0; i < BranchReport.Length; i++)
            {
                Series.Points.Add(new SeriesPoint(BranchReport[i].ReportDay, BranchReport[i].TotalPrice));
            }
            chartControl4.Series.Add(Series);
            ((BarSeriesView)Series.View).FillStyle.FillMode = FillMode.Hatch;
            chartControl4.Series.Add(Series);
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            gridview1();
            gridview2();
            BranchDailyReport();
        }
    }
}
