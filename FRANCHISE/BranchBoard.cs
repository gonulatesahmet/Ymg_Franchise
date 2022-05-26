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
    public partial class BranchBoard : DevExpress.XtraEditors.XtraForm
    {
        public int BranchID;
        public int BoardID;
        
        public BranchBoard()
        {
            InitializeComponent();
        }
        public void BoardList()
        {
            ELL.BOARD[] Board = BLL.BOARD.BoardList(BranchID);
            gridControl1.DataSource = null;
            gridView1.Columns.Clear();
            gridControl1.DataSource = Board;
            gridView1.Columns[0].Visible = false;
            gridView1.Columns[4].Visible = false;
            gridView1.Columns[1].Caption = "MASA AD";
            gridView1.Columns[2].Caption = "MASA KOD";
            gridView1.Columns[3].Caption = "MASA AÇIKLAMA";
            gridView1.Columns[5].Caption = "ŞUBE AD";
            gridView1.Columns[6].Caption = "MASA DURUM";
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
            if (BoardID != 0)
            {
                btnDelete.Enabled = true;
                btnUpdate.Enabled = true;
                
            }
            else
            {
                btnDelete.Enabled = false;
                btnUpdate.Enabled = false;
                
            }
        }
        private void Empty()
        {
            txtBoardName.Text = "";
            txtBoardCode.Text = "";
            txtBoardDescription.Text = "";
        }

        private void BranchBoard_Load(object sender, EventArgs e)
        {
            BoardList();
            ButtonStatus();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue("BoardID") != null)
            {
                BoardID = Convert.ToInt32(gridView1.GetFocusedRowCellValue("BoardID").ToString());
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
                string Kategori = View.GetRowCellDisplayText(e.RowHandle, View.Columns["BoardState"]);
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
            ELL.BOARD Board = new ELL.BOARD()
            {
                BoardName = txtBoardName.Text,
                BoardCode = txtBoardCode.Text,
                BoardDescription = txtBoardDescription.Text,
                BranchID = BranchID,
                BoardState = "000"
            };
            try
            {
                BLL.BOARD.AddBoard(Board);
                BLL.HELPER.MessageBox("Masa Basariyla Eklenmistir");
                BoardList();
                Empty();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateBranchBoard frm = new UpdateBranchBoard();
            frm.BoardID = BoardID;
            frm.Show();
            BoardID = 0;
            ButtonStatus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                BLL.BOARD.DeleteBoard(BoardID);
                BLL.HELPER.MessageBox("Masa Basariyla Silinmistir.");
                BoardID = 0;
                ButtonStatus();
                BoardList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
