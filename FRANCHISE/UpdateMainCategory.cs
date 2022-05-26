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
    public partial class UpdateMainCategory : DevExpress.XtraEditors.XtraForm
    {
        public int MainCategoryID;
        public UpdateMainCategory()
        {
            InitializeComponent();
        }

        private void UpdateMainCategory_Load(object sender, EventArgs e)
        {
            ELL.MAINCATEGORY MainCategory = BLL.MAINCATEGORY.MainCategoryBring(MainCategoryID);
            txtBranchName.Text = MainCategory.MainCategoryName;
            txtBranchCode.Text = MainCategory.MainCategoryCode;
            txtBranchDescription.Text = MainCategory.MainCategoryDescription;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            ELL.MAINCATEGORY MainCategory = new ELL.MAINCATEGORY()
            {
                MainCategoryName = txtBranchName.Text,
                MainCategoryCode = txtBranchCode.Text,
                MainCategoryDescription = txtBranchDescription.Text,
                MainCategoryID = MainCategoryID
            };
            try
            {
                BLL.MAINCATEGORY.UpdateMainCategory(MainCategory);
                BLL.HELPER.MessageBox("Ana Kategori Basariyla Guncellenmistir");
                MainCategory frm = (MainCategory)Application.OpenForms["MainCategory"];
                frm.MainCategoryList();
                this.Hide();
            }
            catch (Exception)
            {

                throw;
            }
        }

        
    }
}
