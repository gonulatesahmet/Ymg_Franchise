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
using DevExpress.XtraCharts;

namespace FRANCHISE
{
    public partial class InsDailyReport : DevExpress.XtraEditors.XtraForm
    {
        public int InsID;
        public InsDailyReport()
        {
            InitializeComponent();
        }

        private void InsDailyReportList(DateTime ReportDay)
        {
            ELL.BRANCHREPORT[] Ins = BLL.BRANCHREPORT.InsDailyList(InsID, ReportDay);
            Series Series = new Series("Bar", ViewType.Bar);
            for (int i = 0; i < Ins.Length; i++)
            {
                Series.Points.Add(new SeriesPoint(Ins[i].BranchName, Ins[i].TotalPrice));
            }
            chartControl1.Series.Add(Series);
            ((BarSeriesView)Series.View).FillStyle.FillMode = FillMode.Hatch;
            chartControl1.Series.Add(Series);
        }



        private void InsDailyReport_Load(object sender, EventArgs e)
        {
            
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            chartControl1.Series.Clear();
            InsDailyReportList(Convert.ToDateTime(dtpReportDay.Text));
        }
    }
}
