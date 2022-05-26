
namespace FRANCHISE
{
    partial class BranchStockStatus
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BranchStockStatus));
            this.grpNew = new DevExpress.XtraEditors.GroupControl();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.txtNumberOfStock = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lupProduct = new DevExpress.XtraEditors.LookUpEdit();
            this.btnNew = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnDecrease = new DevExpress.XtraEditors.SimpleButton();
            this.btnStockAdd = new DevExpress.XtraEditors.SimpleButton();
            this.lblNumberOfStock = new DevExpress.XtraEditors.LabelControl();
            this.lblProductName = new DevExpress.XtraEditors.LabelControl();
            this.txtPiece = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.grpNew)).BeginInit();
            this.grpNew.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumberOfStock.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupProduct.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPiece.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // grpNew
            // 
            this.grpNew.Controls.Add(this.btnAdd);
            this.grpNew.Controls.Add(this.txtNumberOfStock);
            this.grpNew.Controls.Add(this.labelControl2);
            this.grpNew.Controls.Add(this.labelControl1);
            this.grpNew.Controls.Add(this.lupProduct);
            this.grpNew.Location = new System.Drawing.Point(12, 129);
            this.grpNew.Name = "grpNew";
            this.grpNew.Size = new System.Drawing.Size(316, 667);
            this.grpNew.TabIndex = 0;
            this.grpNew.Text = "Yeni Kayıt";
            // 
            // btnAdd
            // 
            this.btnAdd.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.btnAdd.Appearance.Options.UseFont = true;
            this.btnAdd.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.ImageOptions.Image")));
            this.btnAdd.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnAdd.Location = new System.Drawing.Point(6, 163);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(305, 58);
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "Ekle";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtNumberOfStock
            // 
            this.txtNumberOfStock.Location = new System.Drawing.Point(6, 114);
            this.txtNumberOfStock.Name = "txtNumberOfStock";
            this.txtNumberOfStock.Size = new System.Drawing.Size(305, 20);
            this.txtNumberOfStock.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(6, 94);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(51, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Stok Sayısı";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(6, 34);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(58, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Ürün Seçiniz";
            // 
            // lupProduct
            // 
            this.lupProduct.Location = new System.Drawing.Point(5, 54);
            this.lupProduct.Name = "lupProduct";
            this.lupProduct.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lupProduct.Size = new System.Drawing.Size(306, 20);
            this.lupProduct.TabIndex = 0;
            // 
            // btnNew
            // 
            this.btnNew.Appearance.Font = new System.Drawing.Font("Tahoma", 15F);
            this.btnNew.Appearance.Options.UseFont = true;
            this.btnNew.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNew.ImageOptions.Image")));
            this.btnNew.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnNew.Location = new System.Drawing.Point(13, 13);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(315, 110);
            this.btnNew.TabIndex = 2;
            this.btnNew.Text = "Yeni Kayıt";
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.groupControl1);
            this.groupControl2.Controls.Add(this.gridControl1);
            this.groupControl2.Location = new System.Drawing.Point(334, 13);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(1564, 783);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "Stoklar";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btnDecrease);
            this.groupControl1.Controls.Add(this.btnStockAdd);
            this.groupControl1.Controls.Add(this.lblNumberOfStock);
            this.groupControl1.Controls.Add(this.lblProductName);
            this.groupControl1.Controls.Add(this.txtPiece);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Location = new System.Drawing.Point(6, 709);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1553, 69);
            this.groupControl1.TabIndex = 1;
            this.groupControl1.Text = "Stok Güncelle";
            // 
            // btnDecrease
            // 
            this.btnDecrease.Location = new System.Drawing.Point(940, 43);
            this.btnDecrease.Name = "btnDecrease";
            this.btnDecrease.Size = new System.Drawing.Size(134, 20);
            this.btnDecrease.TabIndex = 7;
            this.btnDecrease.Text = "Azalt";
            this.btnDecrease.Click += new System.EventHandler(this.btnDecrease_Click);
            // 
            // btnStockAdd
            // 
            this.btnStockAdd.Location = new System.Drawing.Point(800, 43);
            this.btnStockAdd.Name = "btnStockAdd";
            this.btnStockAdd.Size = new System.Drawing.Size(134, 20);
            this.btnStockAdd.TabIndex = 6;
            this.btnStockAdd.Text = "Ekle";
            this.btnStockAdd.Click += new System.EventHandler(this.btnStockAdd_Click);
            // 
            // lblNumberOfStock
            // 
            this.lblNumberOfStock.Location = new System.Drawing.Point(312, 46);
            this.lblNumberOfStock.Name = "lblNumberOfStock";
            this.lblNumberOfStock.Size = new System.Drawing.Size(6, 13);
            this.lblNumberOfStock.TabIndex = 5;
            this.lblNumberOfStock.Text = "*";
            // 
            // lblProductName
            // 
            this.lblProductName.Location = new System.Drawing.Point(60, 46);
            this.lblProductName.Name = "lblProductName";
            this.lblProductName.Size = new System.Drawing.Size(6, 13);
            this.lblProductName.TabIndex = 4;
            this.lblProductName.Text = "*";
            // 
            // txtPiece
            // 
            this.txtPiece.Location = new System.Drawing.Point(604, 43);
            this.txtPiece.Name = "txtPiece";
            this.txtPiece.Size = new System.Drawing.Size(154, 20);
            this.txtPiece.TabIndex = 3;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(520, 46);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(78, 13);
            this.labelControl5.TabIndex = 2;
            this.labelControl5.Text = "Eklenecek Stok :";
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(248, 46);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(58, 13);
            this.labelControl4.TabIndex = 1;
            this.labelControl4.Text = "Stok Sayısı :";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(6, 46);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(48, 13);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Ürün Adı :";
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(6, 24);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1553, 679);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);
            this.gridView1.RowCellStyle += new DevExpress.XtraGrid.Views.Grid.RowCellStyleEventHandler(this.gridView1_RowCellStyle);
            // 
            // BranchStockStatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1910, 808);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.grpNew);
            this.Name = "BranchStockStatus";
            this.Text = "BranchStockStatus";
            this.Load += new System.EventHandler(this.BranchStockStatus_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grpNew)).EndInit();
            this.grpNew.ResumeLayout(false);
            this.grpNew.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumberOfStock.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lupProduct.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPiece.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grpNew;
        private DevExpress.XtraEditors.SimpleButton btnNew;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.TextEdit txtNumberOfStock;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit lupProduct;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.SimpleButton btnDecrease;
        private DevExpress.XtraEditors.SimpleButton btnStockAdd;
        private DevExpress.XtraEditors.LabelControl lblNumberOfStock;
        private DevExpress.XtraEditors.LabelControl lblProductName;
        private DevExpress.XtraEditors.TextEdit txtPiece;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
    }
}