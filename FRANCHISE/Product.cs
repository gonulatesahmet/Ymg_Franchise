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
using System.IO;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraEditors.Controls;

namespace FRANCHISE
{
    public partial class Product : DevExpress.XtraEditors.XtraForm
    {
        public int ProductID;
        public string ProductState = string.Empty;
        string FilePath;
        public Product()
        {
            InitializeComponent();
        }
        public void DialogPrePare()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Resim Ac";
            ofd.Filter = "Jpeg Dosyasi(*.jpg)|*.jpg|Gif Dosyasi (*.gif)|*.gif|Png Dosyasi (*.png)|*.png";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                picProductImage.Image = Image.FromFile(ofd.FileName);
                FilePath = ofd.FileName.ToString();
            }
        }

        private void CategoryList()
        {
            ELL.CATEGORY[] Category = BLL.CATEGORY.CategoryList();
            lupCategory.Properties.DataSource = Category;
            lupCategory.Properties.DisplayMember = "CategoryName";
            lupCategory.Properties.ValueMember = "CategoryID";
            lupCategory.Properties.PopulateColumns();
            lupCategory.Properties.Columns[0].Visible = false;
            lupCategory.Properties.Columns[2].Visible = false;
            lupCategory.Properties.Columns[3].Visible = false;
            lupCategory.Properties.Columns[4].Visible = false;
            lupCategory.Properties.Columns[5].Visible = false;
            lupCategory.Properties.Columns[6].Visible = false;
        }
        public void ProductList()
        {
            ELL.PRODUCT[] Product = BLL.PRODUCT.ProductList();
            gridControl1.DataSource = null;
            gridView1.Columns.Clear();
            gridControl1.DataSource = Product;
            gridView1.Columns[0].Visible = false;
            gridView1.Columns[7].Visible = false;
            gridView1.Columns[1].Caption = "ÜRÜN FOTOĞRAF";
            gridView1.Columns[2].Caption = "ÜRÜN AD";
            gridView1.Columns[3].Caption = "ÜRÜN KOD";
            gridView1.Columns[4].Caption = "ÜRÜN AÇIKLAMA";
            gridView1.Columns[5].Caption = "ÜRÜN FİYAT";
            gridView1.Columns[6].Caption = "STOK DURUM";
            gridView1.Columns[8].Caption = "KATEGORİ AD";
            gridView1.Columns[9].Caption = "ÜRÜN DURUM";
            this.gridControl1.TabIndex = 0;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;          // 0. satıra bir arama satırı getirir
            this.gridView1.OptionsBehavior.Editable = false;// gridview hücre focuslanmasını iptal eder. 
            this.gridView1.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;  //çok uzun başlıklarda alt satıra geçer.
            this.gridView1.ColumnPanelRowHeight = 50; //gridview header yüksekliği
            gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Blue;
            gridView1.Appearance.HeaderPanel.BorderColor = Color.Black;
            RepositoryItemPictureEdit pictureEdit = new RepositoryItemPictureEdit();
            pictureEdit.SizeMode = PictureSizeMode.Squeeze;
            gridControl1.RepositoryItems.Add(pictureEdit);
            gridView1.OptionsView.RowAutoHeight = true;
            gridView1.Columns[1].ColumnEdit = pictureEdit;
        }
        private void ButtonStatus()
        {
            if (ProductID != 0)
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
        private void Product_Load(object sender, EventArgs e)
        {
            ButtonStatus();
            CategoryList();
            ProductList();
        }
        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue("ProductID") != null)
            {
                ProductID = Convert.ToInt32(gridView1.GetFocusedRowCellValue("ProductID").ToString());
                ProductState = Convert.ToString(gridView1.GetFocusedRowCellValue("ProductState").ToString());
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
                string Kategori = View.GetRowCellDisplayText(e.RowHandle, View.Columns["ProductState"]);
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

        private void btnOpen_Click(object sender, EventArgs e)
        {
            DialogPrePare();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(FilePath, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            ELL.PRODUCT Product = new ELL.PRODUCT()
            {
                ProductName = txtProductName.Text,
                ProductCode = txtProductCode.Text,
                ProductDescription = txtProductDescription.Text,
                ProductImage = br.ReadBytes((int)fs.Length),
                ProductPrice = Convert.ToDecimal(txtProductPrice.Text),
                CategoryID = Convert.ToInt32(lupCategory.EditValue),
                ProductState = "100"
            };
            if (cbbStockStatus.Text == "Sayılabilir")
            {
                Product.StockStatus = "100";
            }
            else
            {
                Product.StockStatus = "000";
            }
            br.Close();
            fs.Close();
            try
            {
                BLL.PRODUCT.AddProduct(Product);
                BLL.HELPER.MessageBox("Urun Basariyla Eklendi");
                ProductList();
            }
            catch (Exception)
            {
                BLL.HELPER.MessageBox("Urun Eklenirken Bir Hata Olustu");
                throw;
            }
            
        }

        private void btnChangeState_Click(object sender, EventArgs e)
        {
            string Text;
            string State;
            if (ProductState == "Aktif")
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
                BLL.PRODUCT.ChangeStateProduct(ProductID, State);
                ProductID = 0;
                ProductState = string.Empty;
                BLL.HELPER.MessageBox(Text);
                ProductList();
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
            UpdateProduct frm = new UpdateProduct();
            frm.ProductID = ProductID;
            frm.Show();
            ProductID = 0;
            ButtonStatus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                BLL.PRODUCT.DeleteProduct(ProductID);
                BLL.HELPER.MessageBox("Urun Basariyla Silindi");
                ProductID = 0;
                ButtonStatus();
                ProductList();
            }
            catch (Exception)
            {
                BLL.HELPER.MessageBox("Urun Silinirken Bir Hata Olustu");
                throw;
            }
        }

      
    }
}
