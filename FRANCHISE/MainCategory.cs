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
    public partial class MainCategory : DevExpress.XtraEditors.XtraForm
    {
        public int MainCategoryID;
        public string MainCategoryState = string.Empty;
        public MainCategory()
        {
            InitializeComponent();
        }
        public void MainCategoryList()
        {
            ELL.MAINCATEGORY[] MainCategory = BLL.MAINCATEGORY.MainCategoryList();
            gridControl1.DataSource = null;
            gridView1.Columns.Clear();
            gridControl1.DataSource = MainCategory;
            gridView1.Columns[0].Visible = false;
            gridView1.Columns[1].Caption = "ANA KATEGORİ AD";
            gridView1.Columns[2].Caption = "ANA KATEGORİ KOD";
            gridView1.Columns[3].Caption = "ANA KATEGORİ AÇIKLAMA";
            gridView1.Columns[4].Caption = "ANA KATEGORİ DURUM";
            this.gridControl1.TabIndex = 0;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;          // 0. satıra bir arama satırı getirir
            this.gridView1.OptionsBehavior.Editable = false;// gridview hücre focuslanmasını iptal eder. 
            this.gridView1.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;  //çok uzun başlıklarda alt satıra geçer.
            this.gridView1.ColumnPanelRowHeight = 50; //gridview header yüksekliği
            gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.Blue;
            gridView1.Appearance.HeaderPanel.BorderColor = Color.Black;
        }
        private void ButtonStatus()
        {
            if (MainCategoryID != 0)
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
        private void MainCategory_Load(object sender, EventArgs e)
        {
            MainCategoryList();
            ButtonStatus();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue("MainCategoryID") != null)
            {
                MainCategoryID = Convert.ToInt32(gridView1.GetFocusedRowCellValue("MainCategoryID").ToString());
                MainCategoryState = Convert.ToString(gridView1.GetFocusedRowCellValue("MainCategoryState").ToString());
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
                string Kategori = View.GetRowCellDisplayText(e.RowHandle, View.Columns["MainCategoryState"]);
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
            ELL.MAINCATEGORY MainCategory = new ELL.MAINCATEGORY()
            {
                MainCategoryName = txtBranchName.Text,
                MainCategoryCode = txtBranchCode.Text,
                MainCategoryDescription = txtBranchDescription.Text,
                MainCategoryState = "100"
            };
            try
            {
                BLL.MAINCATEGORY.AddMainCategory(MainCategory);
                BLL.HELPER.MessageBox("Ana Kategori Basariyla Eklenmistir");
                MainCategoryList();
            }
            catch (Exception)
            {
                BLL.HELPER.MessageBox("Ana Kategori Eklenirken Bir Sorun Olustu");
                throw;
            }
        }

        private void btnChangeState_Click(object sender, EventArgs e)
        {
            string Text;
            string State;
            if (MainCategoryState == "Aktif")
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
                BLL.MAINCATEGORY.ChangeStateMainCategory(MainCategoryID, State);
                MainCategoryID = 0;
                MainCategoryState = string.Empty;
                BLL.HELPER.MessageBox(Text);
                MainCategoryList();
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
            UpdateMainCategory frm = new UpdateMainCategory();
            frm.MainCategoryID = MainCategoryID;
            frm.Show();
            MainCategoryID = 0;
            ButtonStatus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                BLL.MAINCATEGORY.DeleteMainCategory(MainCategoryID);
                BLL.HELPER.MessageBox("Ana Kategori Basariyla Silinmistir");
                MainCategoryID = 0;
                ButtonStatus();
                MainCategoryList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
