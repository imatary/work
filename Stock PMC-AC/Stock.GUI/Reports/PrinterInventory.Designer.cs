namespace Stock.GUI.Reports
{
    partial class PrinterInventory
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

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.winControlContainer1 = new DevExpress.XtraReports.UI.WinControlContainer();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.advBandedGridView3 = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridThongTin = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colProductGroupName = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colInventoryDate = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colProductID = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colProductName = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colUnitName = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridDauKi = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colQuantityFirst = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colTotalPriceFirst = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridNhapKho = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colQuantityImport = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colTotalPriceImport = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridXuatKho = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colQuantityExport = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colTotalPriceExport = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridCuoiKi = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.colQuantityInventory = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.colTotalInventory = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.lbNgayThang = new DevExpress.XtraReports.UI.XRLabel();
            this.lbKi = new DevExpress.XtraReports.UI.XRLabel();
            this.lbKi2 = new DevExpress.XtraReports.UI.XRLabel();
            this.lbKeToanTruong = new DevExpress.XtraReports.UI.XRLabel();
            this.lbKi1 = new DevExpress.XtraReports.UI.XRLabel();
            this.lbNguoiLap = new DevExpress.XtraReports.UI.XRLabel();
            this.lbGiamDoc = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.lbTongHopXuatNhapTon = new DevExpress.XtraReports.UI.XRLabel();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.advBandedGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.winControlContainer1});
            this.Detail.HeightF = 275F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // winControlContainer1
            // 
            this.winControlContainer1.LocationFloat = new DevExpress.Utils.PointFloat(1.625093F, 9.999974F);
            this.winControlContainer1.Name = "winControlContainer1";
            this.winControlContainer1.SizeF = new System.Drawing.SizeF(1157.375F, 255F);
            this.winControlContainer1.WinControl = this.gridControl2;
            // 
            // gridControl2
            // 
            this.gridControl2.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl2.Location = new System.Drawing.Point(2, 2);
            this.gridControl2.MainView = this.advBandedGridView3;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(1111, 245);
            this.gridControl2.TabIndex = 0;
            this.gridControl2.UseEmbeddedNavigator = true;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.advBandedGridView3});
            // 
            // advBandedGridView3
            // 
            this.advBandedGridView3.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridThongTin,
            this.gridDauKi,
            this.gridNhapKho,
            this.gridXuatKho,
            this.gridCuoiKi});
            this.advBandedGridView3.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.colProductGroupName,
            this.colInventoryDate,
            this.colProductID,
            this.colProductName,
            this.colUnitName,
            this.colQuantityFirst,
            this.colTotalPriceFirst,
            this.colQuantityImport,
            this.colTotalPriceImport,
            this.colQuantityExport,
            this.colTotalPriceExport,
            this.colQuantityInventory,
            this.colTotalInventory});
            this.advBandedGridView3.GridControl = this.gridControl2;
            this.advBandedGridView3.GroupCount = 2;
            this.advBandedGridView3.Name = "advBandedGridView3";
            this.advBandedGridView3.OptionsBehavior.Editable = false;
            this.advBandedGridView3.OptionsSelection.MultiSelect = true;
            this.advBandedGridView3.OptionsView.ShowAutoFilterRow = true;
            this.advBandedGridView3.OptionsView.ShowFooter = true;
            this.advBandedGridView3.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colProductGroupName, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colInventoryDate, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridThongTin
            // 
            this.gridThongTin.AppearanceHeader.Options.UseTextOptions = true;
            this.gridThongTin.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridThongTin.Caption = "Thông tin";
            this.gridThongTin.Columns.Add(this.colProductGroupName);
            this.gridThongTin.Columns.Add(this.colInventoryDate);
            this.gridThongTin.Columns.Add(this.colProductID);
            this.gridThongTin.Columns.Add(this.colProductName);
            this.gridThongTin.Columns.Add(this.colUnitName);
            this.gridThongTin.Name = "gridThongTin";
            this.gridThongTin.VisibleIndex = 0;
            this.gridThongTin.Width = 519;
            // 
            // colProductGroupName
            // 
            this.colProductGroupName.Caption = "Nhóm hàng";
            this.colProductGroupName.FieldName = "ProductGroupName";
            this.colProductGroupName.Name = "colProductGroupName";
            this.colProductGroupName.Visible = true;
            this.colProductGroupName.Width = 114;
            // 
            // colInventoryDate
            // 
            this.colInventoryDate.Caption = "Ngày ";
            this.colInventoryDate.FieldName = "InventoryDate";
            this.colInventoryDate.Name = "colInventoryDate";
            this.colInventoryDate.Visible = true;
            this.colInventoryDate.Width = 115;
            // 
            // colProductID
            // 
            this.colProductID.Caption = "Mã";
            this.colProductID.FieldName = "ProductID";
            this.colProductID.Name = "colProductID";
            this.colProductID.Visible = true;
            this.colProductID.Width = 62;
            // 
            // colProductName
            // 
            this.colProductName.Caption = "Hàng hoá";
            this.colProductName.FieldName = "ProductName";
            this.colProductName.Name = "colProductName";
            this.colProductName.Visible = true;
            this.colProductName.Width = 96;
            // 
            // colUnitName
            // 
            this.colUnitName.Caption = "Đơn vị tính";
            this.colUnitName.FieldName = "UnitName";
            this.colUnitName.Name = "colUnitName";
            this.colUnitName.Visible = true;
            this.colUnitName.Width = 132;
            // 
            // gridDauKi
            // 
            this.gridDauKi.AppearanceHeader.Options.UseTextOptions = true;
            this.gridDauKi.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridDauKi.Caption = "Đầu kì";
            this.gridDauKi.Columns.Add(this.colQuantityFirst);
            this.gridDauKi.Columns.Add(this.colTotalPriceFirst);
            this.gridDauKi.Name = "gridDauKi";
            this.gridDauKi.VisibleIndex = 1;
            this.gridDauKi.Width = 192;
            // 
            // colQuantityFirst
            // 
            this.colQuantityFirst.Caption = "Số lượng";
            this.colQuantityFirst.FieldName = "QuantityFirst";
            this.colQuantityFirst.Name = "colQuantityFirst";
            this.colQuantityFirst.Visible = true;
            this.colQuantityFirst.Width = 79;
            // 
            // colTotalPriceFirst
            // 
            this.colTotalPriceFirst.Caption = "Thanh tiền";
            this.colTotalPriceFirst.DisplayFormat.FormatString = "0,0";
            this.colTotalPriceFirst.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalPriceFirst.FieldName = "TotalPriceFirst";
            this.colTotalPriceFirst.Name = "colTotalPriceFirst";
            this.colTotalPriceFirst.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalPriceFirst", "Tổng: {0:0,0 vnđ}")});
            this.colTotalPriceFirst.Visible = true;
            this.colTotalPriceFirst.Width = 113;
            // 
            // gridNhapKho
            // 
            this.gridNhapKho.AppearanceHeader.Options.UseTextOptions = true;
            this.gridNhapKho.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridNhapKho.Caption = "Nhập kho";
            this.gridNhapKho.Columns.Add(this.colQuantityImport);
            this.gridNhapKho.Columns.Add(this.colTotalPriceImport);
            this.gridNhapKho.Name = "gridNhapKho";
            this.gridNhapKho.VisibleIndex = 2;
            this.gridNhapKho.Width = 186;
            // 
            // colQuantityImport
            // 
            this.colQuantityImport.Caption = "Số lượng";
            this.colQuantityImport.FieldName = "QuantityImport";
            this.colQuantityImport.Name = "colQuantityImport";
            this.colQuantityImport.Visible = true;
            this.colQuantityImport.Width = 62;
            // 
            // colTotalPriceImport
            // 
            this.colTotalPriceImport.Caption = "Thành tiền";
            this.colTotalPriceImport.DisplayFormat.FormatString = "0,0";
            this.colTotalPriceImport.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalPriceImport.FieldName = "TotalPriceImport";
            this.colTotalPriceImport.Name = "colTotalPriceImport";
            this.colTotalPriceImport.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalPriceImport", "Tổng: {0:0,0 vnđ}")});
            this.colTotalPriceImport.Visible = true;
            this.colTotalPriceImport.Width = 124;
            // 
            // gridXuatKho
            // 
            this.gridXuatKho.AppearanceHeader.Options.UseTextOptions = true;
            this.gridXuatKho.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridXuatKho.Caption = "Xuất kho";
            this.gridXuatKho.Columns.Add(this.colQuantityExport);
            this.gridXuatKho.Columns.Add(this.colTotalPriceExport);
            this.gridXuatKho.Name = "gridXuatKho";
            this.gridXuatKho.VisibleIndex = 3;
            this.gridXuatKho.Width = 205;
            // 
            // colQuantityExport
            // 
            this.colQuantityExport.Caption = "Số lượng";
            this.colQuantityExport.FieldName = "QuantityExport";
            this.colQuantityExport.Name = "colQuantityExport";
            this.colQuantityExport.Visible = true;
            this.colQuantityExport.Width = 68;
            // 
            // colTotalPriceExport
            // 
            this.colTotalPriceExport.Caption = "Thành tiền";
            this.colTotalPriceExport.DisplayFormat.FormatString = "0,0";
            this.colTotalPriceExport.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalPriceExport.FieldName = "TotalPriceExport";
            this.colTotalPriceExport.Name = "colTotalPriceExport";
            this.colTotalPriceExport.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalPriceExport", "Sum: {0:0,0 vnđ}")});
            this.colTotalPriceExport.Visible = true;
            this.colTotalPriceExport.Width = 137;
            // 
            // gridCuoiKi
            // 
            this.gridCuoiKi.AppearanceHeader.Options.UseTextOptions = true;
            this.gridCuoiKi.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridCuoiKi.Caption = "Tồn kho";
            this.gridCuoiKi.Columns.Add(this.colQuantityInventory);
            this.gridCuoiKi.Columns.Add(this.colTotalInventory);
            this.gridCuoiKi.Name = "gridCuoiKi";
            this.gridCuoiKi.VisibleIndex = 4;
            this.gridCuoiKi.Width = 208;
            // 
            // colQuantityInventory
            // 
            this.colQuantityInventory.Caption = "Số lượng";
            this.colQuantityInventory.FieldName = "QuantityInventory";
            this.colQuantityInventory.Name = "colQuantityInventory";
            this.colQuantityInventory.Visible = true;
            this.colQuantityInventory.Width = 61;
            // 
            // colTotalInventory
            // 
            this.colTotalInventory.Caption = "Thành tiền";
            this.colTotalInventory.DisplayFormat.FormatString = "0,0";
            this.colTotalInventory.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTotalInventory.FieldName = "TotalInventory";
            this.colTotalInventory.Name = "colTotalInventory";
            this.colTotalInventory.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalInventory", "Sum: {0:0,0 vnđ}")});
            this.colTotalInventory.Visible = true;
            this.colTotalInventory.Width = 147;
            // 
            // lbNgayThang
            // 
            this.lbNgayThang.Font = new System.Drawing.Font("Times New Roman", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNgayThang.LocationFloat = new DevExpress.Utils.PointFloat(972.4639F, 26.56333F);
            this.lbNgayThang.Name = "lbNgayThang";
            this.lbNgayThang.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbNgayThang.SizeF = new System.Drawing.SizeF(143.75F, 22.99998F);
            this.lbNgayThang.StylePriority.UseFont = false;
            this.lbNgayThang.Text = "Ngày... Tháng...Năm...";
            // 
            // lbKi
            // 
            this.lbKi.Font = new System.Drawing.Font("Times New Roman", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbKi.LocationFloat = new DevExpress.Utils.PointFloat(162.4999F, 122.1249F);
            this.lbKi.Name = "lbKi";
            this.lbKi.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbKi.SizeF = new System.Drawing.SizeF(120.8333F, 23F);
            this.lbKi.StylePriority.UseFont = false;
            this.lbKi.Text = "(Kí ghi rỏ họ tên)";
            // 
            // lbKi2
            // 
            this.lbKi2.Font = new System.Drawing.Font("Times New Roman", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbKi2.LocationFloat = new DevExpress.Utils.PointFloat(1014.583F, 122.1249F);
            this.lbKi2.Name = "lbKi2";
            this.lbKi2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbKi2.SizeF = new System.Drawing.SizeF(121.8751F, 23F);
            this.lbKi2.StylePriority.UseFont = false;
            this.lbKi2.Text = "(Kí ghi rỏ họ tên)";
            // 
            // lbKeToanTruong
            // 
            this.lbKeToanTruong.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbKeToanTruong.LocationFloat = new DevExpress.Utils.PointFloat(622.9167F, 99.12472F);
            this.lbKeToanTruong.Name = "lbKeToanTruong";
            this.lbKeToanTruong.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbKeToanTruong.SizeF = new System.Drawing.SizeF(120.8334F, 23.00002F);
            this.lbKeToanTruong.StylePriority.UseFont = false;
            this.lbKeToanTruong.Text = "Kế toán trưởng";
            // 
            // lbKi1
            // 
            this.lbKi1.Font = new System.Drawing.Font("Times New Roman", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbKi1.LocationFloat = new DevExpress.Utils.PointFloat(622.9167F, 122.1249F);
            this.lbKi1.Name = "lbKi1";
            this.lbKi1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbKi1.SizeF = new System.Drawing.SizeF(120.8334F, 23F);
            this.lbKi1.StylePriority.UseFont = false;
            this.lbKi1.Text = "(Kí ghi rỏ họ tên)";
            // 
            // lbNguoiLap
            // 
            this.lbNguoiLap.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNguoiLap.LocationFloat = new DevExpress.Utils.PointFloat(162.4999F, 99.12472F);
            this.lbNguoiLap.Name = "lbNguoiLap";
            this.lbNguoiLap.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbNguoiLap.SizeF = new System.Drawing.SizeF(120.8333F, 23.00002F);
            this.lbNguoiLap.StylePriority.UseFont = false;
            this.lbNguoiLap.StylePriority.UseTextAlignment = false;
            this.lbNguoiLap.Text = "Người lập";
            this.lbNguoiLap.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lbGiamDoc
            // 
            this.lbGiamDoc.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGiamDoc.LocationFloat = new DevExpress.Utils.PointFloat(1014.583F, 99.12485F);
            this.lbGiamDoc.Name = "lbGiamDoc";
            this.lbGiamDoc.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbGiamDoc.SizeF = new System.Drawing.SizeF(121.8751F, 23.00002F);
            this.lbGiamDoc.StylePriority.UseFont = false;
            this.lbGiamDoc.StylePriority.UseTextAlignment = false;
            this.lbGiamDoc.Text = "Giám đốc";
            this.lbGiamDoc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 49.37499F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // lbTongHopXuatNhapTon
            // 
            this.lbTongHopXuatNhapTon.Font = new System.Drawing.Font("Times New Roman", 26F, System.Drawing.FontStyle.Bold);
            this.lbTongHopXuatNhapTon.LocationFloat = new DevExpress.Utils.PointFloat(1.625086F, 9.999996F);
            this.lbTongHopXuatNhapTon.Name = "lbTongHopXuatNhapTon";
            this.lbTongHopXuatNhapTon.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbTongHopXuatNhapTon.SizeF = new System.Drawing.SizeF(1182.375F, 56.58339F);
            this.lbTongHopXuatNhapTon.StylePriority.UseFont = false;
            this.lbTongHopXuatNhapTon.StylePriority.UseTextAlignment = false;
            this.lbTongHopXuatNhapTon.Text = "TỔNG HỢP TỒN KHO";
            this.lbTongHopXuatNhapTon.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 122F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lbNguoiLap,
            this.lbKi,
            this.lbKi1,
            this.lbKeToanTruong,
            this.lbNgayThang,
            this.lbKi2,
            this.lbGiamDoc});
            this.PageFooter.HeightF = 205.5415F;
            this.PageFooter.Name = "PageFooter";
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lbTongHopXuatNhapTon});
            this.PageHeader.HeightF = 100F;
            this.PageHeader.Name = "PageHeader";
            // 
            // PrinterInventory
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.PageFooter,
            this.PageHeader});
            this.Margins = new System.Drawing.Printing.Margins(8, 8, 49, 122);
            this.PageWidth = 1200;
            this.PaperKind = System.Drawing.Printing.PaperKind.Standard12x11;
            this.Version = "14.1";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.advBandedGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.XRLabel lbTongHopXuatNhapTon;
        private DevExpress.XtraReports.UI.XRLabel lbKi2;
        private DevExpress.XtraReports.UI.XRLabel lbKi1;
        private DevExpress.XtraReports.UI.XRLabel lbKi;
        private DevExpress.XtraReports.UI.XRLabel lbKeToanTruong;
        private DevExpress.XtraReports.UI.XRLabel lbGiamDoc;
        private DevExpress.XtraReports.UI.XRLabel lbNguoiLap;
        private DevExpress.XtraReports.UI.XRLabel lbNgayThang;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.WinControlContainer winControlContainer1;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView advBandedGridView3;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridThongTin;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colProductGroupName;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colInventoryDate;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colProductID;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colProductName;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colUnitName;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridDauKi;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colQuantityFirst;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colTotalPriceFirst;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridNhapKho;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colQuantityImport;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colTotalPriceImport;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridXuatKho;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colQuantityExport;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colTotalPriceExport;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridCuoiKi;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colQuantityInventory;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn colTotalInventory;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
    }
}
