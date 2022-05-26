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
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;

namespace FRANCHISE
{
    public partial class BranchStockStatus : DevExpress.XtraEditors.XtraForm
    {
        public int BranchID;
        public int ProductStockID;
        public BranchStockStatus()
        {
            InitializeComponent();
        }
        public void ProductStockList()
        {
            ELL.PRODUCTSTOCK[] ProductStock = BLL.PRODUCTSTOCK.ProductStockList(BranchID);
            gridControl1.DataSource = null;
            gridView1.Columns.Clear();
            gridControl1.DataSource = ProductStock;
            gridView1.Columns[0].Visible = false;
            gridView1.Columns[1].Visible = false;
            gridView1.Columns[4].Visible = false;
            gridView1.Columns[2].Caption = "ÜRÜN AD";
            gridView1.Columns[3].Caption = "ÜRÜN FOTOĞRAF";
            gridView1.Columns[5].Caption = "STOK SAYISI";
            this.gridControl1.TabIndex = 0;
            this.gridView1.OptionsBehavior.Editable = false;// gridview hücre focuslanmasını iptal eder. 
            this.gridView1.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;  //çok uzun başlıklarda alt satıra geçer.
            this.gridView1.ColumnPanelRowHeight = 50; //gridview header yüksekliği
            gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Blue;
            gridView1.Appearance.HeaderPanel.BorderColor = Color.Black;
            RepositoryItemPictureEdit pictureEdit = new RepositoryItemPictureEdit();
            pictureEdit.SizeMode = PictureSizeMode.Squeeze;
            gridControl1.RepositoryItems.Add(pictureEdit);
            gridView1.OptionsView.RowAutoHeight = true;
            gridView1.Columns[3].ColumnEdit = pictureEdit;
            gridView1.Columns[3].OptionsColumn.FixedWidth = true;
            gridView1.Columns[3].Width = 300;
            gridView1.RowHeight = 100;
        }
        private void ProductList()
        {
            ELL.PRODUCT[] Product = BLL.PRODUCT.NewProductStockList(BranchID);
            lupProduct.Properties.DataSource = Product;
            lupProduct.Properties.DisplayMember = "ProductName";
            lupProduct.Properties.ValueMember = "ProductID";
            lupProduct.Properties.PopulateColumns();
            lupProduct.Properties.Columns[0].Visible = false;
            lupProduct.Properties.Columns[3].Visible = false;
            lupProduct.Properties.Columns[4].Visible = false;
            lupProduct.Properties.Columns[5].Visible = false;
            lupProduct.Properties.Columns[6].Visible = false;
            lupProduct.Properties.Columns[7].Visible = false;
            lupProduct.Properties.Columns[8].Visible = false;
            lupProduct.Properties.Columns[9].Visible = false;
        }
        private void ButtonStatus()
        {
            if(ProductStockID != 0)
            {
                btnStockAdd.Enabled = true;
                btnDecrease.Enabled = true;
                btnStockAdd.BackColor = Color.Chartreuse;
            }
            else
            {
                btnStockAdd.Enabled = false;
                btnDecrease.Enabled = false;
            }
        }

        private void BranchStockStatus_Load(object sender, EventArgs e)
        {
            ProductStockList();
            ButtonStatus();
            grpNew.Visible = false;
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            ProductList();
            grpNew.Visible = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ELL.PRODUCTSTOCK ProductStock = new ELL.PRODUCTSTOCK()
            {
                BranchID = BranchID,
                ProductID = Convert.ToInt32(lupProduct.EditValue),
                NumberOfProduct = Convert.ToInt32(txtNumberOfStock.Text)
            };
            try
            {
                BLL.PRODUCTSTOCK.AddNewStock(ProductStock);
                BLL.HELPER.MessageBox("Yeni Stok Girisi Yapilmistir");
                ProductStockList();
            }
            catch (Exception)
            {
                BLL.HELPER.MessageBox("Bir Hata Olustu");
                throw;
            }
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue("ProductStockID") != null)
            {
                ProductStockID = Convert.ToInt32(gridView1.GetFocusedRowCellValue("ProductStockID").ToString());
                lblProductName.Text = gridView1.GetFocusedRowCellValue("ProductName").ToString();
                lblNumberOfStock.Text = gridView1.GetFocusedRowCellValue("NumberOfProduct").ToString();
                ButtonStatus();
            }
            else
            {
                BLL.HELPER.MessageBox("Lutfen Satir Seciniz");
            }
        }

        private void gridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                int NumberOfStock = Convert.ToInt32(View.GetRowCellDisplayText(e.RowHandle, View.Columns["NumberOfProduct"]));
                if (NumberOfStock >=20)
                {

                }
                else
                {
                    e.Appearance.ForeColor = Color.Black;
                    e.Appearance.BackColor = Color.Red;
                }
            }
        }

        private void btnStockAdd_Click(object sender, EventArgs e)
        {
            ELL.PRODUCTSTOCK ProductStock = new ELL.PRODUCTSTOCK()
            {
                ProductStockID = ProductStockID,
                NumberOfProduct = Convert.ToInt32(txtPiece.Text)
            };
            try
            {
                BLL.PRODUCTSTOCK.AddProductStock(ProductStock);
                BLL.HELPER.MessageBox("Stok Sayisi Artmistir");
                ProductStockList();

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnDecrease_Click(object sender, EventArgs e)
        {
            if(Convert.ToInt32(lblNumberOfStock.Text) - Convert.ToInt32(txtPiece.Text) >= 0)
            {
                ELL.PRODUCTSTOCK ProductStock = new ELL.PRODUCTSTOCK()
                {
                    ProductStockID = ProductStockID,
                    NumberOfProduct = Convert.ToInt32(txtPiece.Text)
                };
                try
                {
                    BLL.PRODUCTSTOCK.DecreaseProductStock(ProductStock);
                    BLL.HELPER.MessageBox("Stok Sayisi Azalmistir");
                    ProductStockList();
                }
                catch (Exception)
                {

                    throw;
                }
            }
            else
            {
                BLL.HELPER.MessageBox("Stok Sayisi 0 dan Kucuk Olamaz");
            }
            
        }
    }
}
