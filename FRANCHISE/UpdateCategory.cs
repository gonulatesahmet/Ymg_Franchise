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
namespace FRANCHISE
{
    public partial class UpdateCategory : DevExpress.XtraEditors.XtraForm
    {
        public int CategoryID;
        public UpdateCategory()
        {
            InitializeComponent();
        }
        private void MainCategoryList()
        {
            ELL.MAINCATEGORY[] MainCategory = BLL.MAINCATEGORY.MainCategoryList();
            lupMainCategory.Properties.DataSource = MainCategory;
            lupMainCategory.Properties.DisplayMember = "MainCategoryName";
            lupMainCategory.Properties.ValueMember = "MainCategoryID";
            lupMainCategory.Properties.PopulateColumns();
            lupMainCategory.Properties.Columns[0].Visible = false;
            lupMainCategory.Properties.Columns[2].Visible = false;
            lupMainCategory.Properties.Columns[3].Visible = false;
            lupMainCategory.Properties.Columns[4].Visible = false;
            lupMainCategory.Properties.Columns[1].Caption = "ANA KATEGORI";
        }

        private void UpdateCategory_Load(object sender, EventArgs e)
        {
            MainCategoryList();
            ELL.CATEGORY Category = BLL.CATEGORY.CategoryBring(CategoryID);
            lupMainCategory.EditValue = Category.MainCategoryID;
            txtBranchName.Text = Category.CategoryName;
            txtBranchCode.Text = Category.CategoryCode;
            txtBranchDescription.Text = Category.CategoryDescription;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ELL.CATEGORY Category = new ELL.CATEGORY()
            {
                CategoryName = txtBranchName.Text,
                CategoryCode = txtBranchCode.Text,
                CategoryDescription = txtBranchDescription.Text,
                MainCategoryID = Convert.ToInt32(lupMainCategory.EditValue),
                CategoryID = CategoryID
            };
            try
            {
                BLL.CATEGORY.UpdateCategory(Category);
                BLL.HELPER.MessageBox("Kategori Basariyla Guncellenmistir");
                Category frm = (Category)Application.OpenForms["Category"];
                frm.CategoryList();
                this.Hide();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
