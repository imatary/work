namespace Stock.GUI.Forms
{
    partial class FormStocks
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStocks));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bbiAddStock = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEditStock = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDeleteStock = new DevExpress.XtraBars.BarButtonItem();
            this.bbiRefeshStock = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPrinterStock = new DevExpress.XtraBars.BarButtonItem();
            this.bbiColseFormStock = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.gridControlStocks = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnStockID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnStockName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCreatedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnModifyBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnModifyLast = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlStocks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.bbiAddStock,
            this.bbiDeleteStock,
            this.bbiEditStock,
            this.bbiRefeshStock,
            this.bbiPrinterStock,
            this.bbiColseFormStock});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 8;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiAddStock, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiEditStock, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiDeleteStock, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiRefeshStock, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiPrinterStock, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiColseFormStock, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // bbiAddStock
            // 
            this.bbiAddStock.Caption = "Thêm (Ctrl+N)";
            this.bbiAddStock.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiAddStock.Glyph")));
            this.bbiAddStock.Id = 2;
            this.bbiAddStock.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiAddStock.LargeGlyph")));
            this.bbiAddStock.Name = "bbiAddStock";
            this.bbiAddStock.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiAddStock_ItemClick);
            // 
            // bbiEditStock
            // 
            this.bbiEditStock.Caption = "Sửa (Ctrl+E)";
            this.bbiEditStock.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiEditStock.Glyph")));
            this.bbiEditStock.Id = 4;
            this.bbiEditStock.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiEditStock.LargeGlyph")));
            this.bbiEditStock.Name = "bbiEditStock";
            this.bbiEditStock.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiEditStock_ItemClick);
            // 
            // bbiDeleteStock
            // 
            this.bbiDeleteStock.Caption = "Xóa (Ctrl+D)";
            this.bbiDeleteStock.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiDeleteStock.Glyph")));
            this.bbiDeleteStock.Id = 3;
            this.bbiDeleteStock.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiDeleteStock.LargeGlyph")));
            this.bbiDeleteStock.Name = "bbiDeleteStock";
            this.bbiDeleteStock.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiDeleteStock_ItemClick);
            // 
            // bbiRefeshStock
            // 
            this.bbiRefeshStock.Caption = "Nạp Lại (F5)";
            this.bbiRefeshStock.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiRefeshStock.Glyph")));
            this.bbiRefeshStock.Id = 5;
            this.bbiRefeshStock.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiRefeshStock.LargeGlyph")));
            this.bbiRefeshStock.Name = "bbiRefeshStock";
            this.bbiRefeshStock.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiRefeshStock_ItemClick);
            // 
            // bbiPrinterStock
            // 
            this.bbiPrinterStock.Caption = "In (Ctrl+P)";
            this.bbiPrinterStock.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiPrinterStock.Glyph")));
            this.bbiPrinterStock.Id = 6;
            this.bbiPrinterStock.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiPrinterStock.LargeGlyph")));
            this.bbiPrinterStock.Name = "bbiPrinterStock";
            // 
            // bbiColseFormStock
            // 
            this.bbiColseFormStock.Caption = "Đóng (Esc)";
            this.bbiColseFormStock.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiColseFormStock.Glyph")));
            this.bbiColseFormStock.Id = 7;
            this.bbiColseFormStock.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiColseFormStock.LargeGlyph")));
            this.bbiColseFormStock.Name = "bbiColseFormStock";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(566, 55);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 371);
            this.barDockControlBottom.Size = new System.Drawing.Size(566, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 55);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 316);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(566, 55);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 316);
            // 
            // gridControlStocks
            // 
            this.gridControlStocks.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControlStocks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlStocks.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridControlStocks.Location = new System.Drawing.Point(0, 55);
            this.gridControlStocks.MainView = this.gridView1;
            this.gridControlStocks.MenuManager = this.barManager1;
            this.gridControlStocks.Name = "gridControlStocks";
            this.gridControlStocks.Size = new System.Drawing.Size(566, 316);
            this.gridControlStocks.TabIndex = 4;
            this.gridControlStocks.UseEmbeddedNavigator = true;
            this.gridControlStocks.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnStockID,
            this.gridColumnStockName,
            this.gridColumnCreatedBy,
            this.gridColumnModifyBy,
            this.gridColumnModifyLast});
            this.gridView1.GridControl = this.gridControlStocks;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsFind.FindNullPrompt = "Nhập vào từ khóa cần tìm...";
            this.gridView1.OptionsFind.ShowClearButton = false;
            this.gridView1.OptionsFind.ShowFindButton = false;
            this.gridView1.OptionsSelection.CheckBoxSelectorColumnWidth = 30;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // gridColumnStockID
            // 
            this.gridColumnStockID.Caption = "Mã Kho Hàng";
            this.gridColumnStockID.FieldName = "StockID";
            this.gridColumnStockID.Name = "gridColumnStockID";
            this.gridColumnStockID.Visible = true;
            this.gridColumnStockID.VisibleIndex = 1;
            this.gridColumnStockID.Width = 124;
            // 
            // gridColumnStockName
            // 
            this.gridColumnStockName.Caption = "Tên Kho Hàng";
            this.gridColumnStockName.FieldName = "StockName";
            this.gridColumnStockName.Name = "gridColumnStockName";
            this.gridColumnStockName.Visible = true;
            this.gridColumnStockName.VisibleIndex = 2;
            this.gridColumnStockName.Width = 156;
            // 
            // gridColumnCreatedBy
            // 
            this.gridColumnCreatedBy.Caption = "Tạo Bởi";
            this.gridColumnCreatedBy.FieldName = "CreatedBy";
            this.gridColumnCreatedBy.Name = "gridColumnCreatedBy";
            this.gridColumnCreatedBy.Visible = true;
            this.gridColumnCreatedBy.VisibleIndex = 3;
            this.gridColumnCreatedBy.Width = 156;
            // 
            // gridColumnModifyBy
            // 
            this.gridColumnModifyBy.Caption = "Sửa Bởi";
            this.gridColumnModifyBy.FieldName = "ModifyBy";
            this.gridColumnModifyBy.Name = "gridColumnModifyBy";
            this.gridColumnModifyBy.Visible = true;
            this.gridColumnModifyBy.VisibleIndex = 4;
            this.gridColumnModifyBy.Width = 156;
            // 
            // gridColumnModifyLast
            // 
            this.gridColumnModifyLast.Caption = "Sửa Lần Cuối";
            this.gridColumnModifyLast.FieldName = "ModifyDate";
            this.gridColumnModifyLast.Name = "gridColumnModifyLast";
            this.gridColumnModifyLast.Visible = true;
            this.gridColumnModifyLast.VisibleIndex = 5;
            this.gridColumnModifyLast.Width = 158;
            // 
            // FormStocks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 371);
            this.Controls.Add(this.gridControlStocks);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "FormStocks";
            this.Text = "Kho Hàng";
            this.Load += new System.EventHandler(this.FormStocks_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlStocks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem bbiAddStock;
        private DevExpress.XtraBars.BarButtonItem bbiDeleteStock;
        private DevExpress.XtraBars.BarButtonItem bbiEditStock;
        private DevExpress.XtraBars.BarButtonItem bbiRefeshStock;
        private DevExpress.XtraBars.BarButtonItem bbiPrinterStock;
        private DevExpress.XtraBars.BarButtonItem bbiColseFormStock;
        private DevExpress.XtraGrid.GridControl gridControlStocks;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnStockID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnStockName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCreatedBy;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnModifyBy;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnModifyLast;
    }
}