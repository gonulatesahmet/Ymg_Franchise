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
using System.IO;
using DevExpress.Data;

namespace FRANCHISE
{
    public partial class BranchBoardDeatil : DevExpress.XtraEditors.XtraForm
    {
        public int BranchID;
        public int BoardID;
        public int EmployeeID;
        public int SittingID;
        public int OrderingID;
        public BranchBoardDeatil()
        {
            InitializeComponent();
        }



        private void BranchBring()
        {
            ELL.BRANCH Branch = BLL.BRANCH.BranchBring(BranchID);
            lblBranchName.Text = Branch.BranchName;

        }




        private void BoardBring()
        {
            ELL.BOARD Board = BLL.BOARD.BoardBring(BoardID);
            lblBoardName.Text = Board.BoardName;

        }




        private void SittingControl()
        {
            ELL.SITTING Sitting = BLL.SITTING.SittingControl(BoardID, BranchID, "100");
            SittingID = Sitting.SittingID;
            if (Sitting.SittingID == 0)
            {
                lblBoardState.Text = "Pasif";
                lblBoardState.ForeColor = Color.Red;
                btnBoardOpen.Enabled = true;
            }
            else
            {
                lblBoardState.Text = "Aktif";
                lblBoardState.ForeColor = Color.Green;
                btnBoardOpen.Enabled = false;
            }
        }


        
        
        private void EmployeeBring()
        {
            ELL.EMPLOYEE Employee = BLL.EMPLOYEE.EmployeeBring(EmployeeID);
            lblEmployeeName.Text = Employee.EmployeeName + " " + Employee.EmployeeSurName;
        }
        
        




        private void MainCategoryList()
        {
            if(SittingID != 0)
            {
                ELL.MAINCATEGORY[] MainCategory = BLL.MAINCATEGORY.MainCategoryList();
                pnlMainCategory.Controls.Clear();
                for (int i = 0; i < MainCategory.Length; i++)
                {
                    SimpleButton btn = new SimpleButton()
                    {
                        Height = 70,
                        Width = 210,
                        Text = MainCategory[i].MainCategoryName,
                        Name = "btnMainCategory" + i.ToString() + "-" + MainCategory[i].MainCategoryID.ToString(),
                        Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold)
                    };
                    pnlMainCategory.Controls.Add(btn);
                    btn.Click += Btn_Click;

                }
            }
            else
            {

            }
            
        }

        private void Btn_Click(object sender, EventArgs e)
        {
            int MainCategoryID = Convert.ToInt32(((SimpleButton)sender).Name.Substring((((SimpleButton)sender).Name.IndexOf('-') + 1)));
            CategoryList(MainCategoryID);
        }




        private void CategoryList(int MainCategoryID)
        {
            ELL.CATEGORY[] Category = BLL.CATEGORY.BoardCategoryList(MainCategoryID);
            PnlCategory.Controls.Clear();
            for(int i =0; i<Category.Length; i++)
            {
                SimpleButton btn = new SimpleButton()
                {
                    Height = 70,
                    Width = 210,
                    Text = Category[i].CategoryName,
                    Name = "btnCategory" + i.ToString() + "-" + Category[i].CategoryID,
                    Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold)
                };
                PnlCategory.Controls.Add(btn);
                btn.Click += Btn_Click1;
            }
        }




        private void Btn_Click1(object sender, EventArgs e)
        {
            int CategoryID = Convert.ToInt32(((SimpleButton)sender).Name.Substring((((SimpleButton)sender).Name.IndexOf('-') + 1)));
            ProductList(CategoryID);
        }




        private void ProductList(int CategoryID)
        {
            ELL.PRODUCT[] Product = BLL.PRODUCT.BoardProductList(CategoryID);
            pnlProduct.Controls.Clear();
            for(int i = 0; i < Product.Length; i++)
            {
                FlowLayoutPanel pnl = new FlowLayoutPanel()
                {
                    BorderStyle = BorderStyle.FixedSingle,
                    Height = 200,
                    Width = 210,
                    Name = "pnlProduct" + i.ToString() + "-" + Product[i].ProductID,
                    FlowDirection=FlowDirection.TopDown,
                };

                MemoryStream mem = new MemoryStream(Product[i].ProductImage);
                PictureBox pb = new PictureBox()
                {
                    Image = Image.FromStream(mem),
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Size = new Size(210, 100)
                };

                LabelControl lbl = new LabelControl()
                {
                    Text = Product[i].ProductName,
                    Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular),
                    ForeColor = Color.White,
                };
                LabelControl lbl2 = new LabelControl()
                {
                    Text = Product[i].ProductPrice.ToString()+" TL",
                    Font = new Font("Microsoft Sans Serif", 12, FontStyle.Regular),
                    ForeColor = Color.White,
                };
                SimpleButton btn = new SimpleButton()
                {
                    Width = 195,
                    Height = 30,
                    Text = "Ekle",
                    Name = "btnEkle" + i.ToString() + "-" + Product[i].ProductID,
                    Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold),
                    
                };
                btn.Click += Btn_Click2;


                pnl.Controls.Add(pb);
                pnl.Controls.Add(lbl);
                pnl.Controls.Add(lbl2);
                pnl.Controls.Add(btn);
                pnlProduct.Controls.Add(pnl);
            }
        }

        private void Btn_Click2(object sender, EventArgs e)
        {
            int ProductID = Convert.ToInt32(((SimpleButton)sender).Name.Substring((((SimpleButton)sender).Name.IndexOf('-') + 1)));
            ELL.ORDERING Ordering = new ELL.ORDERING()
            {
                BranchID = BranchID,
                SittingID = SittingID,
                EmployeeID = EmployeeID,
                OrderingState = "100",
                OrderingDate = DateTime.Now,
                ProductID = ProductID
            };
            if (string.IsNullOrEmpty(txtCode.Text))
            {
                Ordering.Piece = 1;
            }
            else
            {
                Ordering.Piece = Convert.ToInt32(txtCode.Text);
            }
            try
            {
                BLL.ORDERING.AddOrdering(Ordering);
                txtCode.Text = "";
                OrderingList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        


        private void Operation(object sender, EventArgs e)
        {
            SimpleButton btn = sender as SimpleButton;
            switch (btn.Name)
            {
                case "btn1":
                    txtCode.Text += (1).ToString();
                    break;
                case "btn2":
                    txtCode.Text += (2).ToString();
                    break;
                case "btn3":
                    txtCode.Text += (3).ToString();
                    break;
                case "btn4":
                    txtCode.Text += (4).ToString();
                    break;
                case "btn5":
                    txtCode.Text += (5).ToString();
                    break;
                case "btn6":
                    txtCode.Text += (6).ToString();
                    break;
                case "btn7":
                    txtCode.Text += (7).ToString();
                    break;
                case "btn8":
                    txtCode.Text += (8).ToString();
                    break;
                case "btn9":
                    txtCode.Text += (9).ToString();
                    break;
                case "btn0":
                    txtCode.Text += (0).ToString();
                    break;
                case "btnDelete":
                    if (txtCode.Text.Length == 0)
                    {
                        BLL.HELPER.MessageBox("Kutu Zaten Bos");
                    }
                    else
                    {
                        txtCode.Text = txtCode.Text.Remove(txtCode.Text.Length - 1, 1);
                    }
                    break;
                default:
                    BLL.HELPER.MessageBox("Sayi Gir");
                    break;
            }
        }




        private void ButtonStatus()
        {
            if (OrderingID != 0)
            {
                btnPlus.Enabled = true;
                btnDecrease.Enabled = true;
                btnOrderingDelete.Enabled = true;
            }
            else
            {
                btnPlus.Enabled = false;
                btnDecrease.Enabled = false;
                btnOrderingDelete.Enabled = false;
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
            }
            else
            {
                gridControl1.DataSource = null;
                gridView1.Columns.Clear();
            }
        }




        private void BranchBoardDeatil_Load(object sender, EventArgs e)
        {
            btn1.Click += new EventHandler(Operation);
            btn2.Click += new EventHandler(Operation);
            btn3.Click += new EventHandler(Operation);
            btn4.Click += new EventHandler(Operation);
            btn5.Click += new EventHandler(Operation);
            btn6.Click += new EventHandler(Operation);
            btn7.Click += new EventHandler(Operation);
            btn8.Click += new EventHandler(Operation);
            btn9.Click += new EventHandler(Operation);
            btn0.Click += new EventHandler(Operation);
            btnDelete.Click += new EventHandler(Operation);
            BranchBring();
            EmployeeBring();
            BoardBring();
            SittingControl();
            MainCategoryList();
            OrderingList();
            ButtonStatus();

        }




        private void simpleButton1_Click(object sender, EventArgs e)
        {
            ELL.SITTING Sitting = new ELL.SITTING()
            {
                BoardID = BoardID,
                BranchID = BranchID,
                StartDate = DateTime.Now,
                SittingState = "100",
                TotalPrice = 0
            };
            try
            {
                BLL.SITTING.StartSitting(Sitting);
                BLL.BOARD.ChangeStateBoard(BoardID, "100");
                BLL.HELPER.MessageBox("Oturum Acildi");
                SittingControl();
                MainCategoryList();
            }
            catch (Exception)
            {
                
                throw;
            }
        }




       

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue("OrderingID") != null)
            {
                OrderingID = Convert.ToInt32(gridView1.GetFocusedRowCellValue("OrderingID").ToString());
                ButtonStatus();

            }
            else
            {
                BLL.HELPER.MessageBox("Lutfen Satira Tiklayiniz");
            }
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            
            try
            {
                BLL.ORDERING.PlusOrdering(OrderingID);
                OrderingList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnDecrease_Click(object sender, EventArgs e)
        {
            BLL.ORDERING.DecreaseOrdering(OrderingID);
            OrderingList();
        }

        private void btnOrderingDelete_Click(object sender, EventArgs e)
        {
            BLL.ORDERING.ChangeStateOrdering(OrderingID);
            OrderingList();
        }
    }
}
