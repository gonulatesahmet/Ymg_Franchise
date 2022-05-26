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
    public partial class InsPayment : DevExpress.XtraEditors.XtraForm
    {
        public int TypeOfPaymentID;
        public string TypeOfPaymentState = string.Empty;
        public InsPayment()
        {
            InitializeComponent();
        }
        public void TypeOfPaymentList()
        {
            ELL.TYPEOFPAYMENT[] Payment = BLL.TYPEOFPAYMENT.TypeOfPaymentList();
            gridControl1.DataSource = null;
            gridView1.Columns.Clear();
            gridControl1.DataSource = Payment;
            gridView1.Columns[0].Visible = false;
            gridView1.Columns[1].Caption = "ÖDEME AD";
            gridView1.Columns[2].Caption = "ÖDEME KOD";
            gridView1.Columns[3].Caption = "ÖDEME AÇIKLAMA";
            gridView1.Columns[4].Caption = "ÖDEME DURUM";
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
            if (TypeOfPaymentID != 0)
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
        private void InsPayment_Load(object sender, EventArgs e)
        {
            TypeOfPaymentList();
            ButtonStatus();
        }

        private void gridView1_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue("TypeOfPaymentID") != null)
            {
                TypeOfPaymentID = Convert.ToInt32(gridView1.GetFocusedRowCellValue("TypeOfPaymentID").ToString());
                TypeOfPaymentState = Convert.ToString(gridView1.GetFocusedRowCellValue("TypeOfPaymentState").ToString());
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
                string Kategori = View.GetRowCellDisplayText(e.RowHandle, View.Columns["TypeOfPaymentState"]);
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
            ELL.TYPEOFPAYMENT TypeOfPayment = new ELL.TYPEOFPAYMENT()
            {
                TypeOfPaymentName = txtBranchName.Text,
                TypeOfPaymentCode = txtBranchCode.Text,
                TypeOfPaymentDescription = txtBranchDescription.Text,
                TypeOfPaymentState = "100"
            };
            try
            {
                BLL.TYPEOFPAYMENT.AddTypeOfPayment(TypeOfPayment);
                BLL.HELPER.MessageBox("Odeme Tur Basariyla Eklendi");
                TypeOfPaymentList();
            }
            catch (Exception)
            {
                BLL.HELPER.MessageBox("Odeme Tur Eklenirken Bir Hata Olustu");
                throw;
            }
        }

        private void btnChangeState_Click(object sender, EventArgs e)
        {
            string Text;
            string State;
            if (TypeOfPaymentState == "Aktif")
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
                BLL.TYPEOFPAYMENT.ChangeStateTypeOfPayment(TypeOfPaymentID, State);
                TypeOfPaymentID = 0;
                TypeOfPaymentState = string.Empty;
                BLL.HELPER.MessageBox(Text);
                TypeOfPaymentList();
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
            UpdateTypeOfPayment frm = new UpdateTypeOfPayment();
            frm.TypeOfPaymentID = TypeOfPaymentID;
            frm.Show();
            TypeOfPaymentID = 0;
            ButtonStatus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                BLL.TYPEOFPAYMENT.DeleteTypeOfPayment(TypeOfPaymentID);
                BLL.HELPER.MessageBox("Odeme Tur Basariyla Silindi");
                TypeOfPaymentID = 0;
                ButtonStatus();
                TypeOfPaymentList();
            }
            catch (Exception)
            {
                BLL.HELPER.MessageBox("Odeme Tur Silinirken Bir Hata Olustu");
                throw;
            }
        }
    }
}
