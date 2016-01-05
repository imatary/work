namespace Stock.GUI.Reports
{
    partial class PrinterReportByStock
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridViewStocks = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColStockReportStockName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColStockReportProductID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColStockReportProductName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColStockReportUnitName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColStockReportQuantityExport = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColStockReportPrice = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColStockReportTotalPriceExport = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColStockReportProductGroup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.lbBaoCaoDoanhThu = new DevExpress.XtraReports.UI.XRLabel();
            this.lbDienThoai = new DevExpress.XtraReports.UI.XRLabel();
            this.lbFax = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewStocks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.winControlContainer1});
            this.Detail.HeightF = 242.7083F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // winControlContainer1
            // 
            this.winControlContainer1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 10.00001F);
            this.winControlContainer1.Name = "winControlContainer1";
            this.winControlContainer1.SizeF = new System.Drawing.SizeF(660.0001F, 222.7083F);
            this.winControlContainer1.WinControl = this.gridControl1;
            // 
            // gridControl1
            // 
            this.gridControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl1.Location = new System.Drawing.Point(0, 37);
            this.gridControl1.MainView = this.gridViewStocks;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(634, 214);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.UseEmbeddedNavigator = true;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewStocks});
            // 
            // gridViewStocks
            // 
            this.gridViewStocks.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColStockReportStockName,
            this.gridColStockReportProductID,
            this.gridColStockReportProductName,
            this.gridColStockReportUnitName,
            this.gridColStockReportQuantityExport,
            this.gridColStockReportPrice,
            this.gridColStockReportTotalPriceExport,
            this.gridColStockReportProductGroup});
            this.gridViewStocks.GridControl = this.gridControl1;
            this.gridViewStocks.GroupCount = 1;
            this.gridViewStocks.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Quantity", null, ": Số lượng: {0}"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalPriceExport", null, "Thành tiền: {0:0,0} VND"),
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.None, "", null, "")});
            this.gridViewStocks.Name = "gridViewStocks";
            this.gridViewStocks.OptionsView.ShowFooter = true;
            this.gridViewStocks.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColStockReportStockName, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColStockReportStockName
            // 
            this.gridColStockReportStockName.Caption = "Kho Hàng";
            this.gridColStockReportStockName.FieldName = "StockName";
            this.gridColStockReportStockName.Name = "gridColStockReportStockName";
            this.gridColStockReportStockName.Visible = true;
            this.gridColStockReportStockName.VisibleIndex = 0;
            // 
            // gridColStockReportProductID
            // 
            this.gridColStockReportProductID.Caption = "Mã Mặt Hàng";
            this.gridColStockReportProductID.FieldName = "ProductID";
            this.gridColStockReportProductID.Name = "gridColStockReportProductID";
            this.gridColStockReportProductID.Visible = true;
            this.gridColStockReportProductID.VisibleIndex = 1;
            // 
            // gridColStockReportProductName
            // 
            this.gridColStockReportProductName.Caption = "Tên Mặt Hàng";
            this.gridColStockReportProductName.FieldName = "ProductName";
            this.gridColStockReportProductName.Name = "gridColStockReportProductName";
            this.gridColStockReportProductName.Visible = true;
            this.gridColStockReportProductName.VisibleIndex = 2;
            // 
            // gridColStockReportUnitName
            // 
            this.gridColStockReportUnitName.Caption = "Đơn Vị";
            this.gridColStockReportUnitName.FieldName = "UnitName";
            this.gridColStockReportUnitName.Name = "gridColStockReportUnitName";
            this.gridColStockReportUnitName.Visible = true;
            this.gridColStockReportUnitName.VisibleIndex = 3;
            // 
            // gridColStockReportQuantityExport
            // 
            this.gridColStockReportQuantityExport.Caption = "Số Lượng";
            this.gridColStockReportQuantityExport.FieldName = "Quantity";
            this.gridColStockReportQuantityExport.Name = "gridColStockReportQuantityExport";
            this.gridColStockReportQuantityExport.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Quantity", "{0:0}")});
            this.gridColStockReportQuantityExport.Visible = true;
            this.gridColStockReportQuantityExport.VisibleIndex = 4;
            // 
            // gridColStockReportPrice
            // 
            this.gridColStockReportPrice.Caption = "Giá";
            this.gridColStockReportPrice.DisplayFormat.FormatString = "0,0 VNĐ";
            this.gridColStockReportPrice.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColStockReportPrice.FieldName = "Price";
            this.gridColStockReportPrice.Name = "gridColStockReportPrice";
            this.gridColStockReportPrice.Visible = true;
            this.gridColStockReportPrice.VisibleIndex = 5;
            // 
            // gridColStockReportTotalPriceExport
            // 
            this.gridColStockReportTotalPriceExport.Caption = "Thành Tiền";
            this.gridColStockReportTotalPriceExport.DisplayFormat.FormatString = "0,0 VNĐ";
            this.gridColStockReportTotalPriceExport.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColStockReportTotalPriceExport.FieldName = "TotalPriceExport";
            this.gridColStockReportTotalPriceExport.Name = "gridColStockReportTotalPriceExport";
            this.gridColStockReportTotalPriceExport.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalPriceExport", "{0:0,0} VNĐ")});
            this.gridColStockReportTotalPriceExport.Visible = true;
            this.gridColStockReportTotalPriceExport.VisibleIndex = 6;
            // 
            // gridColStockReportProductGroup
            // 
            this.gridColStockReportProductGroup.Caption = "Nhóm Hàng";
            this.gridColStockReportProductGroup.FieldName = "ProductGroupName";
            this.gridColStockReportProductGroup.Name = "gridColStockReportProductGroup";
            this.gridColStockReportProductGroup.Visible = true;
            this.gridColStockReportProductGroup.VisibleIndex = 0;
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 100F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 100F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel2,
            this.xrPictureBox1,
            this.lbBaoCaoDoanhThu,
            this.lbDienThoai,
            this.lbFax});
            this.PageHeader.HeightF = 182.2917F;
            this.PageHeader.Name = "PageHeader";
            // 
            // PageFooter
            // 
            this.PageFooter.HeightF = 100F;
            this.PageFooter.Name = "PageFooter";
            // 
            // xrLabel2
            // 
            this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold);
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(156.6668F, 45.02082F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(465.625F, 38.625F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.Text = "CÔNG TY TNHH ĐIỆN TỬ UMC VIỆT NAM";
            // 
            // xrPictureBox1
            // 
            this.xrPictureBox1.ImageUrl = "D:\\Dev\\Projects\\Stock PMC-AC\\Stock.GUI\\Resources\\umc.png";
            this.xrPictureBox1.LocationFloat = new DevExpress.Utils.PointFloat(37.70825F, 22.02084F);
            this.xrPictureBox1.Name = "xrPictureBox1";
            this.xrPictureBox1.SizeF = new System.Drawing.SizeF(100F, 92.79167F);
            this.xrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage;
            // 
            // lbBaoCaoDoanhThu
            // 
            this.lbBaoCaoDoanhThu.Font = new System.Drawing.Font("Times New Roman", 22F, System.Drawing.FontStyle.Bold);
            this.lbBaoCaoDoanhThu.LocationFloat = new DevExpress.Utils.PointFloat(0F, 127.6457F);
            this.lbBaoCaoDoanhThu.Name = "lbBaoCaoDoanhThu";
            this.lbBaoCaoDoanhThu.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.lbBaoCaoDoanhThu.SizeF = new System.Drawing.SizeF(660.0001F, 36.79174F);
            this.lbBaoCaoDoanhThu.StylePriority.UseFont = false;
            this.lbBaoCaoDoanhThu.StylePriority.UsePadding = false;
            this.lbBaoCaoDoanhThu.StylePriority.UseTextAlignment = false;
            this.lbBaoCaoDoanhThu.Text = "Bảng kê xuất kho theo Kho hàng và Hàng hóa";
            this.lbBaoCaoDoanhThu.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // lbDienThoai
            // 
            this.lbDienThoai.LocationFloat = new DevExpress.Utils.PointFloat(156.6668F, 91.81255F);
            this.lbDienThoai.Name = "lbDienThoai";
            this.lbDienThoai.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbDienThoai.SizeF = new System.Drawing.SizeF(77.08333F, 23F);
            this.lbDienThoai.Text = "Điện thoại:";
            // 
            // lbFax
            // 
            this.lbFax.LocationFloat = new DevExpress.Utils.PointFloat(434.5833F, 91.81255F);
            this.lbFax.Name = "lbFax";
            this.lbFax.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbFax.SizeF = new System.Drawing.SizeF(34.37497F, 23F);
            this.lbFax.Text = "Fax:";
            // 
            // PrinterReportByStock
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.PageHeader,
            this.PageFooter});
            this.Margins = new System.Drawing.Printing.Margins(100, 90, 100, 100);
            this.Version = "14.1";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewStocks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.WinControlContainer winControlContainer1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewStocks;
        private DevExpress.XtraGrid.Columns.GridColumn gridColStockReportStockName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColStockReportProductID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColStockReportProductName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColStockReportUnitName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColStockReportQuantityExport;
        private DevExpress.XtraGrid.Columns.GridColumn gridColStockReportPrice;
        private DevExpress.XtraGrid.Columns.GridColumn gridColStockReportTotalPriceExport;
        private DevExpress.XtraGrid.Columns.GridColumn gridColStockReportProductGroup;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRPictureBox xrPictureBox1;
        private DevExpress.XtraReports.UI.XRLabel lbBaoCaoDoanhThu;
        private DevExpress.XtraReports.UI.XRLabel lbDienThoai;
        private DevExpress.XtraReports.UI.XRLabel lbFax;
    }
}
