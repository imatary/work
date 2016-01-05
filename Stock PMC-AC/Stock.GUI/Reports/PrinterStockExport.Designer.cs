namespace Stock.GUI.Reports
{
    partial class PrinterStockExport
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
            this.gridViewOrder = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn25 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.resTENMATHANG = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemCalcEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit();
            this.repositoryItemSpinEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.lbDienThoai = new DevExpress.XtraReports.UI.XRLabel();
            this.lbBaoCaoDoanhThu = new DevExpress.XtraReports.UI.XRLabel();
            this.lbFax = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLblEmployeeName = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLblAddressName = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLblOrderExportID = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLblLyDo = new DevExpress.XtraReports.UI.XRLabel();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrLblTotal = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.lbKeToanTruong = new DevExpress.XtraReports.UI.XRLabel();
            this.lbKi = new DevExpress.XtraReports.UI.XRLabel();
            this.lbNgayThang = new DevExpress.XtraReports.UI.XRLabel();
            this.lbKi1 = new DevExpress.XtraReports.UI.XRLabel();
            this.lbNguoiLap = new DevExpress.XtraReports.UI.XRLabel();
            this.lbKi2 = new DevExpress.XtraReports.UI.XRLabel();
            this.lbGiamDoc = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resTENMATHANG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCalcEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.winControlContainer1});
            this.Detail.HeightF = 197.5F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // winControlContainer1
            // 
            this.winControlContainer1.LocationFloat = new DevExpress.Utils.PointFloat(10.00001F, 10.00001F);
            this.winControlContainer1.Name = "winControlContainer1";
            this.winControlContainer1.SizeF = new System.Drawing.SizeF(630F, 176F);
            this.winControlContainer1.WinControl = this.gridControl1;
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.EmbeddedNavigator.Buttons.CancelEdit.Visible = false;
            this.gridControl1.EmbeddedNavigator.Buttons.Edit.ImageIndex = 0;
            this.gridControl1.EmbeddedNavigator.Buttons.EndEdit.Visible = false;
            this.gridControl1.Location = new System.Drawing.Point(2, 2);
            this.gridControl1.MainView = this.gridViewOrder;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.resTENMATHANG,
            this.repositoryItemCalcEdit1,
            this.repositoryItemSpinEdit1,
            this.repositoryItemTextEdit1,
            this.repositoryItemLookUpEdit1});
            this.gridControl1.Size = new System.Drawing.Size(605, 169);
            this.gridControl1.TabIndex = 6;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewOrder});
            // 
            // gridViewOrder
            // 
            this.gridViewOrder.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn22,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn25});
            this.gridViewOrder.GridControl = this.gridControl1;
            this.gridViewOrder.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "OrderID", null, "")});
            this.gridViewOrder.Name = "gridViewOrder";
            this.gridViewOrder.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridViewOrder.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridViewOrder.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDownFocused;
            this.gridViewOrder.OptionsDetail.AllowExpandEmptyDetails = true;
            this.gridViewOrder.OptionsDetail.AllowOnlyOneMasterRowExpanded = true;
            this.gridViewOrder.OptionsDetail.AutoZoomDetail = true;
            this.gridViewOrder.OptionsSelection.InvertSelection = true;
            this.gridViewOrder.OptionsView.EnableAppearanceEvenRow = true;
            this.gridViewOrder.OptionsView.EnableAppearanceOddRow = true;
            this.gridViewOrder.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Bottom;
            this.gridViewOrder.OptionsView.RowAutoHeight = true;
            this.gridViewOrder.OptionsView.ShowButtonMode = DevExpress.XtraGrid.Views.Base.ShowButtonModeEnum.ShowAlways;
            this.gridViewOrder.OptionsView.ShowFooter = true;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Mã Mặt Hàng";
            this.gridColumn5.FieldName = "ProductId";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 0;
            this.gridColumn5.Width = 70;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Tên Mặt Hàng";
            this.gridColumn6.FieldName = "ProductName";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 1;
            this.gridColumn6.Width = 120;
            // 
            // gridColumn22
            // 
            this.gridColumn22.Caption = "Đơn Vị Tính";
            this.gridColumn22.FieldName = "UnitId";
            this.gridColumn22.Name = "gridColumn22";
            this.gridColumn22.Visible = true;
            this.gridColumn22.VisibleIndex = 2;
            this.gridColumn22.Width = 60;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Số Lượng";
            this.gridColumn7.FieldName = "Quantity";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum)});
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 3;
            this.gridColumn7.Width = 60;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Đơn Giá";
            this.gridColumn8.DisplayFormat.FormatString = "{0:0,0 VNĐ}";
            this.gridColumn8.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn8.FieldName = "Price";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 4;
            this.gridColumn8.Width = 100;
            // 
            // gridColumn25
            // 
            this.gridColumn25.Caption = "Tổng Cộng";
            this.gridColumn25.DisplayFormat.FormatString = "{0:0,0 VNĐ}";
            this.gridColumn25.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.gridColumn25.FieldName = "Total";
            this.gridColumn25.Name = "gridColumn25";
            this.gridColumn25.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Total", "{0:0,0 VNĐ}")});
            this.gridColumn25.Visible = true;
            this.gridColumn25.VisibleIndex = 5;
            this.gridColumn25.Width = 130;
            // 
            // resTENMATHANG
            // 
            this.resTENMATHANG.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
            this.resTENMATHANG.AutoHeight = false;
            this.resTENMATHANG.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.resTENMATHANG.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("TENMH", "Product Name"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("MAMH", "Ma")});
            this.resTENMATHANG.DisplayMember = "TENMH";
            this.resTENMATHANG.DropDownRows = 10;
            this.resTENMATHANG.MaxLength = 1000000000;
            this.resTENMATHANG.Name = "resTENMATHANG";
            this.resTENMATHANG.NullText = "Chon";
            this.resTENMATHANG.PopupWidth = 220;
            this.resTENMATHANG.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.resTENMATHANG.ValueMember = "MAMH";
            // 
            // repositoryItemCalcEdit1
            // 
            this.repositoryItemCalcEdit1.AutoHeight = false;
            this.repositoryItemCalcEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemCalcEdit1.Mask.EditMask = "c";
            this.repositoryItemCalcEdit1.Name = "repositoryItemCalcEdit1";
            this.repositoryItemCalcEdit1.NullValuePromptShowForEmptyValue = true;
            // 
            // repositoryItemSpinEdit1
            // 
            this.repositoryItemSpinEdit1.AutoHeight = false;
            this.repositoryItemSpinEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemSpinEdit1.IsFloatValue = false;
            this.repositoryItemSpinEdit1.Mask.EditMask = "N00";
            this.repositoryItemSpinEdit1.Name = "repositoryItemSpinEdit1";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Mask.EditMask = "p";
            this.repositoryItemTextEdit1.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.MaxLength = 100000;
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            this.repositoryItemLookUpEdit1.NullValuePromptShowForEmptyValue = true;
            this.repositoryItemLookUpEdit1.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            this.repositoryItemLookUpEdit1.ValueMember = "MAMH";
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 56.95839F;
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
            this.lbDienThoai,
            this.lbBaoCaoDoanhThu,
            this.lbFax,
            this.xrLabel1,
            this.xrLblEmployeeName,
            this.xrLabel6,
            this.xrLblAddressName,
            this.xrLabel8,
            this.xrLblOrderExportID,
            this.xrPictureBox1,
            this.xrLabel2,
            this.xrLabel4,
            this.xrLblLyDo});
            this.PageHeader.HeightF = 296.875F;
            this.PageHeader.Name = "PageHeader";
            // 
            // lbDienThoai
            // 
            this.lbDienThoai.LocationFloat = new DevExpress.Utils.PointFloat(140.8334F, 100.0834F);
            this.lbDienThoai.Name = "lbDienThoai";
            this.lbDienThoai.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbDienThoai.SizeF = new System.Drawing.SizeF(77.08333F, 23F);
            this.lbDienThoai.Text = "Điện thoại:";
            // 
            // lbBaoCaoDoanhThu
            // 
            this.lbBaoCaoDoanhThu.Font = new System.Drawing.Font("Times New Roman", 22F, System.Drawing.FontStyle.Bold);
            this.lbBaoCaoDoanhThu.LocationFloat = new DevExpress.Utils.PointFloat(217.7084F, 135.9166F);
            this.lbBaoCaoDoanhThu.Name = "lbBaoCaoDoanhThu";
            this.lbBaoCaoDoanhThu.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.lbBaoCaoDoanhThu.SizeF = new System.Drawing.SizeF(282.2917F, 36.79173F);
            this.lbBaoCaoDoanhThu.StylePriority.UseFont = false;
            this.lbBaoCaoDoanhThu.StylePriority.UsePadding = false;
            this.lbBaoCaoDoanhThu.StylePriority.UseTextAlignment = false;
            this.lbBaoCaoDoanhThu.Text = "PHIẾU XUẤT KHO";
            this.lbBaoCaoDoanhThu.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lbFax
            // 
            this.lbFax.LocationFloat = new DevExpress.Utils.PointFloat(418.7499F, 100.0834F);
            this.lbFax.Name = "lbFax";
            this.lbFax.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbFax.SizeF = new System.Drawing.SizeF(34.37497F, 23F);
            this.lbFax.Text = "Fax:";
            // 
            // xrLabel1
            // 
            this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(21.87487F, 190.0416F);
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(170.8333F, 23F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.Text = "Họ và tên người nhận hàng:";
            // 
            // xrLblEmployeeName
            // 
            this.xrLblEmployeeName.LocationFloat = new DevExpress.Utils.PointFloat(192.7083F, 190.0416F);
            this.xrLblEmployeeName.Name = "xrLblEmployeeName";
            this.xrLblEmployeeName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLblEmployeeName.SizeF = new System.Drawing.SizeF(192.7083F, 23F);
            this.xrLblEmployeeName.StylePriority.UseTextAlignment = false;
            this.xrLblEmployeeName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel6
            // 
            this.xrLabel6.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(21.87487F, 213.0416F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(115.625F, 23F);
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.Text = "Địa chỉ (Bộ phận):";
            // 
            // xrLblAddressName
            // 
            this.xrLblAddressName.LocationFloat = new DevExpress.Utils.PointFloat(137.4999F, 213.0416F);
            this.xrLblAddressName.Name = "xrLblAddressName";
            this.xrLblAddressName.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLblAddressName.SizeF = new System.Drawing.SizeF(247.9167F, 23F);
            this.xrLblAddressName.StylePriority.UseTextAlignment = false;
            this.xrLblAddressName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel8
            // 
            this.xrLabel8.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(464.25F, 15.70835F);
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(50.20844F, 23F);
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.Text = "Phiếu:";
            // 
            // xrLblOrderExportID
            // 
            this.xrLblOrderExportID.LocationFloat = new DevExpress.Utils.PointFloat(514.4583F, 15.70835F);
            this.xrLblOrderExportID.Name = "xrLblOrderExportID";
            this.xrLblOrderExportID.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLblOrderExportID.SizeF = new System.Drawing.SizeF(122.4166F, 23F);
            this.xrLblOrderExportID.StylePriority.UseTextAlignment = false;
            this.xrLblOrderExportID.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrPictureBox1
            // 
            this.xrPictureBox1.ImageUrl = "D:\\Dev\\Projects\\Stock PMC-AC\\Stock.GUI\\Resources\\umc.png";
            this.xrPictureBox1.LocationFloat = new DevExpress.Utils.PointFloat(21.87487F, 30.29169F);
            this.xrPictureBox1.Name = "xrPictureBox1";
            this.xrPictureBox1.SizeF = new System.Drawing.SizeF(100F, 92.79167F);
            this.xrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold);
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(140.8334F, 53.29167F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(465.625F, 38.625F);
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.Text = "CÔNG TY TNHH ĐIỆN TỬ UMC VIỆT NAM";
            // 
            // xrLabel4
            // 
            this.xrLabel4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(21.87487F, 236.0416F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(50F, 23F);
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.Text = "Lý do:";
            // 
            // xrLblLyDo
            // 
            this.xrLblLyDo.LocationFloat = new DevExpress.Utils.PointFloat(71.87487F, 236.0416F);
            this.xrLblLyDo.Name = "xrLblLyDo";
            this.xrLblLyDo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLblLyDo.SizeF = new System.Drawing.SizeF(565F, 48.25002F);
            this.xrLblLyDo.StylePriority.UseTextAlignment = false;
            this.xrLblLyDo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLblTotal,
            this.xrLabel5,
            this.lbKeToanTruong,
            this.lbKi,
            this.lbNgayThang,
            this.lbKi1,
            this.lbNguoiLap,
            this.lbKi2,
            this.lbGiamDoc});
            this.PageFooter.HeightF = 212.4583F;
            this.PageFooter.Name = "PageFooter";
            // 
            // xrLblTotal
            // 
            this.xrLblTotal.LocationFloat = new DevExpress.Utils.PointFloat(470.8334F, 9.999974F);
            this.xrLblTotal.Name = "xrLblTotal";
            this.xrLblTotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLblTotal.SizeF = new System.Drawing.SizeF(169.1665F, 23F);
            this.xrLblTotal.StylePriority.UseTextAlignment = false;
            this.xrLblTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel5
            // 
            this.xrLabel5.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(389.5833F, 9.999974F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(81.25015F, 23.00002F);
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.Text = "Thành Tiền:";
            // 
            // lbKeToanTruong
            // 
            this.lbKeToanTruong.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbKeToanTruong.LocationFloat = new DevExpress.Utils.PointFloat(270.8331F, 148.8333F);
            this.lbKeToanTruong.Name = "lbKeToanTruong";
            this.lbKeToanTruong.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbKeToanTruong.SizeF = new System.Drawing.SizeF(120.8334F, 23.00002F);
            this.lbKeToanTruong.StylePriority.UseFont = false;
            this.lbKeToanTruong.StylePriority.UseTextAlignment = false;
            this.lbKeToanTruong.Text = "Kế toán trưởng";
            this.lbKeToanTruong.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lbKi
            // 
            this.lbKi.Font = new System.Drawing.Font("Times New Roman", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbKi.LocationFloat = new DevExpress.Utils.PointFloat(21.87487F, 173.8333F);
            this.lbKi.Name = "lbKi";
            this.lbKi.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbKi.SizeF = new System.Drawing.SizeF(120.8333F, 23F);
            this.lbKi.StylePriority.UseFont = false;
            this.lbKi.StylePriority.UseTextAlignment = false;
            this.lbKi.Text = "(Kí ghi rỏ họ tên)";
            this.lbKi.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lbNgayThang
            // 
            this.lbNgayThang.Font = new System.Drawing.Font("Times New Roman", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNgayThang.LocationFloat = new DevExpress.Utils.PointFloat(470.8333F, 99.87501F);
            this.lbNgayThang.Name = "lbNgayThang";
            this.lbNgayThang.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbNgayThang.SizeF = new System.Drawing.SizeF(166.0416F, 22.99995F);
            this.lbNgayThang.StylePriority.UseFont = false;
            this.lbNgayThang.Text = "Ngày... Tháng...Năm...";
            // 
            // lbKi1
            // 
            this.lbKi1.Font = new System.Drawing.Font("Times New Roman", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbKi1.LocationFloat = new DevExpress.Utils.PointFloat(270.8331F, 173.8333F);
            this.lbKi1.Name = "lbKi1";
            this.lbKi1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbKi1.SizeF = new System.Drawing.SizeF(120.8334F, 23F);
            this.lbKi1.StylePriority.UseFont = false;
            this.lbKi1.StylePriority.UseTextAlignment = false;
            this.lbKi1.Text = "(Kí ghi rỏ họ tên)";
            this.lbKi1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lbNguoiLap
            // 
            this.lbNguoiLap.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNguoiLap.LocationFloat = new DevExpress.Utils.PointFloat(21.87487F, 148.8333F);
            this.lbNguoiLap.Name = "lbNguoiLap";
            this.lbNguoiLap.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbNguoiLap.SizeF = new System.Drawing.SizeF(120.8333F, 23.00003F);
            this.lbNguoiLap.StylePriority.UseFont = false;
            this.lbNguoiLap.StylePriority.UseTextAlignment = false;
            this.lbNguoiLap.Text = "Người lập";
            this.lbNguoiLap.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lbKi2
            // 
            this.lbKi2.Font = new System.Drawing.Font("Times New Roman", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbKi2.LocationFloat = new DevExpress.Utils.PointFloat(498.958F, 173.8333F);
            this.lbKi2.Name = "lbKi2";
            this.lbKi2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbKi2.SizeF = new System.Drawing.SizeF(121.8751F, 23F);
            this.lbKi2.StylePriority.UseFont = false;
            this.lbKi2.StylePriority.UseTextAlignment = false;
            this.lbKi2.Text = "(Kí ghi rỏ họ tên)";
            this.lbKi2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lbGiamDoc
            // 
            this.lbGiamDoc.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbGiamDoc.LocationFloat = new DevExpress.Utils.PointFloat(498.958F, 148.8333F);
            this.lbGiamDoc.Name = "lbGiamDoc";
            this.lbGiamDoc.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lbGiamDoc.SizeF = new System.Drawing.SizeF(121.8751F, 23.00003F);
            this.lbGiamDoc.StylePriority.UseFont = false;
            this.lbGiamDoc.StylePriority.UseTextAlignment = false;
            this.lbGiamDoc.Text = "Giám đốc";
            this.lbGiamDoc.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // PrinterStockExport
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.PageHeader,
            this.PageFooter});
            this.Margins = new System.Drawing.Printing.Margins(100, 100, 57, 100);
            this.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.Version = "14.1";
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resTENMATHANG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCalcEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSpinEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.WinControlContainer winControlContainer1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewOrder;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn22;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn25;
        public DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit resTENMATHANG;
        private DevExpress.XtraEditors.Repository.RepositoryItemCalcEdit repositoryItemCalcEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        public DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.XRLabel lbDienThoai;
        private DevExpress.XtraReports.UI.XRLabel lbBaoCaoDoanhThu;
        private DevExpress.XtraReports.UI.XRLabel lbFax;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.XRLabel xrLblEmployeeName;
        private DevExpress.XtraReports.UI.XRLabel xrLabel6;
        private DevExpress.XtraReports.UI.XRLabel xrLblAddressName;
        private DevExpress.XtraReports.UI.XRLabel xrLabel8;
        private DevExpress.XtraReports.UI.XRLabel xrLblOrderExportID;
        private DevExpress.XtraReports.UI.XRPictureBox xrPictureBox1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.XRLabel xrLblLyDo;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.XRLabel xrLblTotal;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
        private DevExpress.XtraReports.UI.XRLabel lbKeToanTruong;
        private DevExpress.XtraReports.UI.XRLabel lbKi;
        private DevExpress.XtraReports.UI.XRLabel lbNgayThang;
        private DevExpress.XtraReports.UI.XRLabel lbKi1;
        private DevExpress.XtraReports.UI.XRLabel lbNguoiLap;
        private DevExpress.XtraReports.UI.XRLabel lbKi2;
        private DevExpress.XtraReports.UI.XRLabel lbGiamDoc;

    }
}
