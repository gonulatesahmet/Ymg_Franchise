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

namespace FRANCHISE
{
    public partial class Category : DevExpress.XtraEditors.XtraForm
    {
        public int CategoryID;
        public string CategoryState = string.Empty;
        public Category()
        {
            InitializeComponent();
        }
        public void CategoryList()
        {
            ELL.CATEGORY[] Category = BLL.CATEGORY.CategoryList();
            gridControl1.DataSource = null;
            gridView1.Columns.Clear();
            gridControl1.DataSource = Category;
            gridView1.Columns[0].Visible = false;
            gridView1.Columns[4].Visible = false;
            gridView1.Columns[1].Caption = "KATEGORİ AD";
            gridView1.Columns[2].Caption = "KATEGORİ KOD";
            gridView1.Columns[3].Caption = "KATEGORİ AÇIKLAMA";
            gridView1.Columns[5].Caption = "ANA KATEGORİ AD";
            gridView1.Columns[6].Caption = "KATEGORİ DURUM";
            this.gridControl1.TabIndex = 0;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;          // 0. satıra bir arama satırı getirir
            this.gridView1.OptionsBehavior.Editable = false;// gridview hücre focuslanmasını iptal eder. 
            this.gridView1.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;  //çok uzun başlıklarda alt satıra geçer.
            this.gridView1.ColumnPanelRowHeight = 50; //gridview header yüksekliği
            gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Blue;
            gridView1.Appearance.HeaderPanel.BorderColor = Color.Black;
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
        private void ButtonStatus()
        {
            if (CategoryID != 0)
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
        private void Category_Load(object sender, EventArgs e)
        {
            CategoryList();
            MainCategoryList();
            ButtonStatus();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue("CategoryID") != null)
            {
                CategoryID = Convert.ToInt32(gridView1.GetFocusedRowCellValue("CategoryID").ToString());
                CategoryState = Convert.ToString(gridView1.GetFocusedRowCellValue("CategoryState").ToString());
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
                string Kategori = View.GetRowCellDisplayText(e.RowHandle, View.Columns["CategoryState"]);
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ELL.CATEGORY Category = new ELL.CATEGORY()
            {
                CategoryName = txtBranchName.Text,
                CategoryCode = txtBranchCode.Text,
                CategoryDescription = txtBranchDescription.Text,
                MainCategoryID = Convert.ToInt32(lupMainCategory.EditValue),
                CategoryState = "100"
            };
            try
            {
                BLL.CATEGORY.AddCategory(Category);
                BLL.HELPER.MessageBox("Kategori Basariyla Eklendi");
                CategoryList();
            }
            catch (Exception)
            {
                BLL.HELPER.MessageBox("Kategori Eklenirken Bir Hata Olustu");

                throw;
            }
        }

        private void btnChangeState_Click(object sender, EventArgs e)
        {
            string Text;
            string State;
            if (CategoryState == "Aktif")
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
                BLL.CATEGORY.ChangeStateCategory(CategoryID, State);
                CategoryID = 0;
                CategoryState = string.Empty;
                BLL.HELPER.MessageBox(Text);
                CategoryList();
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
            UpdateCategory frm = new UpdateCategory();
            frm.CategoryID = CategoryID;
            frm.Show();
            CategoryID = 0;
            ButtonStatus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                BLL.CATEGORY.DeleteCategory(CategoryID);
                BLL.HELPER.MessageBox("Kategori Basariyla Silindi");
                CategoryID = 0;
                ButtonStatus();
                CategoryList();
            }
            catch (Exception)
            {
                BLL.HELPER.MessageBox("Kategori Silinirken Bir Hata Olustu");
                throw;
            }
        }
    }
}
