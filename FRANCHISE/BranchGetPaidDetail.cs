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
using DevExpress.XtraEditors;

namespace FRANCHISE
{
    public partial class BranchGetPaidDetail : DevExpress.XtraEditors.XtraForm
    {
        public int BranchID;
        public int BoardID;
        public int SittingID;
        public string BranchName ;

        public BranchGetPaidDetail()
        {
            InitializeComponent();
        }
        private void PaymentList()
        {
            ELL.TYPEOFPAYMENT[] TypeOfPayment = BLL.TYPEOFPAYMENT.TypeOfPaymentList();
            lupTypeOfPayment.Properties.DataSource = TypeOfPayment;
            lupTypeOfPayment.Properties.DisplayMember = "TypeOfPaymentName";
            lupTypeOfPayment.Properties.ValueMember = "TypeOfPaymentID";
            lupTypeOfPayment.Properties.PopulateColumns();
            lupTypeOfPayment.Properties.Columns[0].Visible = false;
            lupTypeOfPayment.Properties.Columns[2].Visible = false;
            lupTypeOfPayment.Properties.Columns[3].Visible = false;
            lupTypeOfPayment.Properties.Columns[4].Visible = false;
        }
        private void DisList()
        {
            ELL.DISCOUNT[] Dis = BLL.DISCOUNT.DisList();
            lupDis.Properties.DataSource = Dis;
            lupDis.Properties.DisplayMember = "DisName";
            lupDis.Properties.ValueMember = "DisID";
            lupDis.Properties.PopulateColumns();
            lupDis.Properties.Columns[0].Visible = false;
            lupDis.Properties.Columns[2].Visible = false;
            lupDis.Properties.Columns[3].Visible = false;
            lupDis.Properties.Columns[5].Visible = false;
        }
        private void BoardList()
        {
            ELL.BOARD Board = BLL.BOARD.BoardBring(BoardID);
            lblBoardName.Text = Board.BoardName;
            lblBoardState.Text = Board.BoardState;
        }
        private void SittingControl()
        {
            ELL.SITTING Sitting = BLL.SITTING.SittingControl(BoardID, BranchID, "100");
            SittingID = Sitting.SittingID;
            if(SittingID == 0)
            {

            }
            else
            {
                lblStartDate.Text = Sitting.StartDate.Hour.ToString() + ":" + Sitting.StartDate.Minute.ToString();
                var Date = DateTime.Now.Subtract(Sitting.StartDate);
                lblTotalDate.Text = Date.Hours + " Saat" + Date.Minutes + " Dakika";
                OrderingList();
            }
        }
        private void OrderingList()
        {
            if(SittingID != 0)
            {
                ELL.ORDERING[] Ordering = BLL.ORDERING.OrderingList(SittingID);
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
                lblTotalPrice.Text = gridView1.Columns[6].SummaryItem.SummaryValue.ToString();
            }
            else
            {
                gridControl1.DataSource = null;
                gridView1.Columns.Clear();
            }
        }
        private void BranchBring()
        {
            ELL.BRANCH branch = BLL.BRANCH.BranchBring(BranchID);
            BranchName = branch.BranchName;
        }
        private void Operation(object sender, EventArgs e)
        {
            SimpleButton btn = sender as SimpleButton;
            switch (btn.Name)
            {
                case "btn05":
                    lblVerilen.Text = (Convert.ToDecimal(0.05)+Convert.ToDecimal(lblVerilen.Text)).ToString();
                    lblVerilecek.Text = (Convert.ToDecimal(lblVerilen.Text) - Convert.ToDecimal(lblTotalPrice.Text)).ToString();
                    break;
                case "btn010":
                    lblVerilen.Text = (Convert.ToDecimal(0.10) + Convert.ToDecimal(lblVerilen.Text)).ToString();
                    lblVerilecek.Text = (Convert.ToDecimal(lblVerilen.Text) - Convert.ToDecimal(lblTotalPrice.Text)).ToString();
                    break;
                case "btn025":
                    lblVerilen.Text = (Convert.ToDecimal(0.25) + Convert.ToDecimal(lblVerilen.Text)).ToString();
                    lblVerilecek.Text = (Convert.ToDecimal(lblVerilen.Text) - Convert.ToDecimal(lblTotalPrice.Text)).ToString();
                    break;
                case "btn050":
                    lblVerilen.Text = (Convert.ToDecimal(0.50) + Convert.ToDecimal(lblVerilen.Text)).ToString();
                    lblVerilecek.Text = (Convert.ToDecimal(lblVerilen.Text) - Convert.ToDecimal(lblTotalPrice.Text)).ToString();
                    break;
                case "btn1":
                    lblVerilen.Text = (Convert.ToDecimal(1) + Convert.ToDecimal(lblVerilen.Text)).ToString();
                    lblVerilecek.Text = (Convert.ToDecimal(lblVerilen.Text) - Convert.ToDecimal(lblTotalPrice.Text)).ToString();
                    break;
                case "btn5":
                    lblVerilen.Text = (Convert.ToDecimal(5) + Convert.ToDecimal(lblVerilen.Text)).ToString();
                    lblVerilecek.Text = (Convert.ToDecimal(lblVerilen.Text) - Convert.ToDecimal(lblTotalPrice.Text)).ToString();
                    break;
                case "btn10":
                    lblVerilen.Text = (Convert.ToDecimal(10) + Convert.ToDecimal(lblVerilen.Text)).ToString();
                    lblVerilecek.Text = (Convert.ToDecimal(lblVerilen.Text) - Convert.ToDecimal(lblTotalPrice.Text)).ToString();
                    break;
                case "btn20":
                    lblVerilen.Text = (Convert.ToDecimal(20) + Convert.ToDecimal(lblVerilen.Text)).ToString();
                    lblVerilecek.Text = (Convert.ToDecimal(lblVerilen.Text) - Convert.ToDecimal(lblTotalPrice.Text)).ToString();
                    break;
                case "btn50":
                    lblVerilen.Text = (Convert.ToDecimal(50) + Convert.ToDecimal(lblVerilen.Text)).ToString();
                    lblVerilecek.Text = (Convert.ToDecimal(lblVerilen.Text) - Convert.ToDecimal(lblTotalPrice.Text)).ToString();
                    break;
                case "btn100":
                    lblVerilen.Text = (Convert.ToDecimal(100) + Convert.ToDecimal(lblVerilen.Text)).ToString();
                    lblVerilecek.Text = (Convert.ToDecimal(lblVerilen.Text) - Convert.ToDecimal(lblTotalPrice.Text)).ToString();
                    break;
                case "btn200":
                    lblVerilen.Text = (Convert.ToDecimal(200) + Convert.ToDecimal(lblVerilen.Text)).ToString();
                    lblVerilecek.Text = (Convert.ToDecimal(lblVerilen.Text) - Convert.ToDecimal(lblTotalPrice.Text)).ToString();
                    break;
                case "btnRefresh":
                    lblVerilen.Text = 0.ToString();
                    lblVerilecek.Text = 0.ToString();
                    break;
                default:
                    BLL.HELPER.MessageBox("Sayi Gir");
                    break;
            }
        }


        private void BranchGetPaidDetail_Load(object sender, EventArgs e)
        {
            btn05.Click += new EventHandler(Operation);
            btn010.Click += new EventHandler(Operation);
            btn025.Click += new EventHandler(Operation);
            btn050.Click += new EventHandler(Operation);
            btn1.Click += new EventHandler(Operation);
            btn5.Click += new EventHandler(Operation);
            btn10.Click += new EventHandler(Operation);
            btn20.Click += new EventHandler(Operation);
            btn50.Click += new EventHandler(Operation);
            btn100.Click += new EventHandler(Operation);
            btnRefresh.Click += new EventHandler(Operation);
            BranchBring();
            BoardList();
            SittingControl();
            PaymentList();
            DisList();
            btnGetPaid.Enabled = false;
        }

        private void lupTypeOfPayment_EditValueChanged(object sender, EventArgs e)
        {
            lblTypeOfPayment.Text = lupTypeOfPayment.Text;
            btnGetPaid.Enabled = true;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }

        private void btnGetPaid_Click(object sender, EventArgs e)
        {
            ELL.ORDERING[] Ordering = BLL.ORDERING.OrderingList(SittingID);
            for(int i =0; i < Ordering.Length; i++)
            {
                ELL.PRODUCTSTOCK Product = new ELL.PRODUCTSTOCK()
                {
                    BranchID = BranchID,
                    ProductID = Ordering[i].ProductID,
                    NumberOfProduct = Ordering[i].Piece
                };
                BLL.PRODUCTSTOCK.BuyingProduct(Product);
            }

            ELL.SITTING Sitting = new ELL.SITTING()
            {
                SittingID = SittingID,
                TotalPrice = Convert.ToDecimal(lblTotalPrice.Text),
                TypeOfPaymentID = Convert.ToInt32(lupTypeOfPayment.EditValue),
                DisID = Convert.ToInt32(lupDis.EditValue),
                DueDate = DateTime.Now,
                SittingState = "000"
            };

            BLL.BOARD.ChangeStateBoard(BoardID, "000");
            BLL.SITTING.CloseSitting(Sitting);
            BLL.HELPER.MessageBox("Masa Kapatildi");
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            ELL.ORDERING[] Ordering = BLL.ORDERING.OrderingList(SittingID);
            Font Title = new Font("Microsoft Sans Serif", 15, FontStyle.Bold);
            Font Main = new Font("Microsoft Sans Serif", 10, FontStyle.Italic);
            SolidBrush Sb = new SolidBrush(Color.Black);

            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Near;
            e.Graphics.DrawString(BranchName.ToString(), Title, Sb, 150, 160, sf);
            e.Graphics.DrawString("--------------------------------------------------------------------------------", Main, Sb, 150, 180, sf);
            e.Graphics.DrawString("Ürün Ad                          Adet                Fiyat", Main, Sb, 150, 200, sf);
            for(int i = 0; i < Ordering.Length; i++)
            {
                e.Graphics.DrawString(Ordering[i].ProductName, Main, Sb, 150, 220 + (i * 30), sf);
                e.Graphics.DrawString(Ordering[i].Piece.ToString(), Main, Sb, 300, 220 + (i * 30), sf);
                e.Graphics.DrawString(Ordering[i].TotalPrice.ToString(), Main, Sb, 450, 220 + (i * 30), sf);
            }
            e.Graphics.DrawString("--------------------------------------------------------------------------------", Main, Sb, 150, 220 + ((Ordering.Length + 1) * 30), sf);
            e.Graphics.DrawString("Toplam Fiyat : "+lblTotalPrice.Text, Main, Sb, 350, 220 + ((Ordering.Length + 2) * 30), sf);
        }

        private void lupDis_EditValueChanged(object sender, EventArgs e)
        {
            decimal TotalPrice = Convert.ToDecimal(lblTotalPrice.Text) - (Convert.ToDecimal(lblTotalPrice.Text) * (Convert.ToDecimal(lupDis.GetColumnValue("DisRate").ToString()) / 100));
            lblTotalPrice.Text = TotalPrice.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            lblTotalPrice.Text = gridView1.Columns[6].SummaryItem.SummaryValue.ToString();
        }
    }
}
