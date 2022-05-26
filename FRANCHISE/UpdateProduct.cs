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
using System.IO;

namespace FRANCHISE
{
    public partial class UpdateProduct : DevExpress.XtraEditors.XtraForm
    {
        public int ProductID;
        string FilePath = string.Empty;

        public UpdateProduct()
        {
            InitializeComponent();
        }
        public void DialogHazirla()
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
        public void CategoryList()
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
        private void UpdateProduct_Load(object sender, EventArgs e)
        {
            CategoryList();
            ELL.PRODUCT Product = BLL.PRODUCT.ProductBring(ProductID);
            txtProductName.Text = Product.ProductName;
            txtProductCode.Text = Product.ProductCode;
            txtProductDescription.Text = Product.ProductDescription;
            txtProductPrice.Text = Product.ProductPrice.ToString();
            cbbStockStatus.Text = Product.StockStatus;
            lupCategory.EditValue = Product.CategoryID;
            MemoryStream mem = new MemoryStream(Product.ProductImage);
            picProductImage.Image = Image.FromStream(mem);
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            DialogHazirla();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {


            ELL.PRODUCT Product = new ELL.PRODUCT()
            {
                ProductName = txtProductName.Text,
                ProductCode = txtProductCode.Text,
                ProductDescription = txtProductDescription.Text,
                ProductPrice = Convert.ToDecimal(txtProductPrice.Text),
                CategoryID = Convert.ToInt32(lupCategory.EditValue),
                ProductID = ProductID,
            };
            if (cbbStockStatus.Text == "Sayılabilir")
            {
                Product.StockStatus = "100";
            }
            else
            {
                Product.StockStatus = "000";
            }
            
            try
            {
                BLL.PRODUCT.UpdateProduct(Product);
                BLL.HELPER.MessageBox("Urun Basariyla Guncellendi");
                Product frm = (Product)Application.OpenForms["Product"];
                frm.ProductList();
                this.Hide();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnUpdateImg_Click(object sender, EventArgs e)
        {
            FileStream fs = new FileStream(FilePath, FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            byte[] ProductImage = br.ReadBytes((int)fs.Length);
            BLL.PRODUCT.UpdateImageProduct(ProductID, ProductImage);
            br.Close();
            fs.Close();
        }
    }
}
