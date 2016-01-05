namespace Stock.GUI.Forms
{
    partial class FormUnits
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormUnits));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bbiAddUnit = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEditUnit = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDeleteUnit = new DevExpress.XtraBars.BarButtonItem();
            this.bbiRefeshUnit = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPrinterUnit = new DevExpress.XtraBars.BarButtonItem();
            this.bbiColseFormUnit = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.gridControlUnits = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnUnitID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnUnitName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCreatedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnModifyBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnModifyLast = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlUnits)).BeginInit();
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
            this.bbiAddUnit,
            this.bbiDeleteUnit,
            this.bbiEditUnit,
            this.bbiRefeshUnit,
            this.bbiPrinterUnit,
            this.bbiColseFormUnit});
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiAddUnit, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiEditUnit, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiDeleteUnit, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiRefeshUnit, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiPrinterUnit, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiColseFormUnit, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // bbiAddUnit
            // 
            this.bbiAddUnit.Caption = "Thêm (Ctrl+N)";
            this.bbiAddUnit.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiAddUnit.Glyph")));
            this.bbiAddUnit.Id = 2;
            this.bbiAddUnit.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiAddUnit.LargeGlyph")));
            this.bbiAddUnit.Name = "bbiAddUnit";
            this.bbiAddUnit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiAddUnit_ItemClick);
            // 
            // bbiEditUnit
            // 
            this.bbiEditUnit.Caption = "Sửa (Ctrl+E)";
            this.bbiEditUnit.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiEditUnit.Glyph")));
            this.bbiEditUnit.Id = 4;
            this.bbiEditUnit.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiEditUnit.LargeGlyph")));
            this.bbiEditUnit.Name = "bbiEditUnit";
            this.bbiEditUnit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiEditUnit_ItemClick);
            // 
            // bbiDeleteUnit
            // 
            this.bbiDeleteUnit.Caption = "Xóa (Ctrl+D)";
            this.bbiDeleteUnit.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiDeleteUnit.Glyph")));
            this.bbiDeleteUnit.Id = 3;
            this.bbiDeleteUnit.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiDeleteUnit.LargeGlyph")));
            this.bbiDeleteUnit.Name = "bbiDeleteUnit";
            this.bbiDeleteUnit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiDeleteUnit_ItemClick);
            // 
            // bbiRefeshUnit
            // 
            this.bbiRefeshUnit.Caption = "Nạp Lại (F5)";
            this.bbiRefeshUnit.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiRefeshUnit.Glyph")));
            this.bbiRefeshUnit.Id = 5;
            this.bbiRefeshUnit.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiRefeshUnit.LargeGlyph")));
            this.bbiRefeshUnit.Name = "bbiRefeshUnit";
            this.bbiRefeshUnit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiRefeshUnit_ItemClick);
            // 
            // bbiPrinterUnit
            // 
            this.bbiPrinterUnit.Caption = "In (Ctrl+P)";
            this.bbiPrinterUnit.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiPrinterUnit.Glyph")));
            this.bbiPrinterUnit.Id = 6;
            this.bbiPrinterUnit.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiPrinterUnit.LargeGlyph")));
            this.bbiPrinterUnit.Name = "bbiPrinterUnit";
            // 
            // bbiColseFormUnit
            // 
            this.bbiColseFormUnit.Caption = "Đóng (Esc)";
            this.bbiColseFormUnit.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiColseFormUnit.Glyph")));
            this.bbiColseFormUnit.Id = 7;
            this.bbiColseFormUnit.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiColseFormUnit.LargeGlyph")));
            this.bbiColseFormUnit.Name = "bbiColseFormUnit";
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
            // gridControlUnits
            // 
            this.gridControlUnits.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControlUnits.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlUnits.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridControlUnits.Location = new System.Drawing.Point(0, 55);
            this.gridControlUnits.MainView = this.gridView1;
            this.gridControlUnits.MenuManager = this.barManager1;
            this.gridControlUnits.Name = "gridControlUnits";
            this.gridControlUnits.Size = new System.Drawing.Size(566, 316);
            this.gridControlUnits.TabIndex = 4;
            this.gridControlUnits.UseEmbeddedNavigator = true;
            this.gridControlUnits.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnUnitID,
            this.gridColumnUnitName,
            this.gridColumnCreatedBy,
            this.gridColumnModifyBy,
            this.gridColumnModifyLast});
            this.gridView1.GridControl = this.gridControlUnits;
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
            // gridColumnUnitID
            // 
            this.gridColumnUnitID.Caption = "Mã Đơn Vị";
            this.gridColumnUnitID.FieldName = "UnitID";
            this.gridColumnUnitID.Name = "gridColumnUnitID";
            this.gridColumnUnitID.Visible = true;
            this.gridColumnUnitID.VisibleIndex = 1;
            this.gridColumnUnitID.Width = 124;
            // 
            // gridColumnUnitName
            // 
            this.gridColumnUnitName.Caption = "Tên Đơn Vị";
            this.gridColumnUnitName.FieldName = "UnitName";
            this.gridColumnUnitName.Name = "gridColumnUnitName";
            this.gridColumnUnitName.Visible = true;
            this.gridColumnUnitName.VisibleIndex = 2;
            this.gridColumnUnitName.Width = 156;
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
            this.gridColumnModifyLast.FieldName = "ModifyLast";
            this.gridColumnModifyLast.Name = "gridColumnModifyLast";
            this.gridColumnModifyLast.Visible = true;
            this.gridColumnModifyLast.VisibleIndex = 5;
            this.gridColumnModifyLast.Width = 158;
            // 
            // FormUnits
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 371);
            this.Controls.Add(this.gridControlUnits);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "FormUnits";
            this.Text = "Đơn Vị Tính";
            this.Load += new System.EventHandler(this.FormUnits_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlUnits)).EndInit();
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
        private DevExpress.XtraBars.BarButtonItem bbiAddUnit;
        private DevExpress.XtraBars.BarButtonItem bbiDeleteUnit;
        private DevExpress.XtraBars.BarButtonItem bbiEditUnit;
        private DevExpress.XtraBars.BarButtonItem bbiRefeshUnit;
        private DevExpress.XtraBars.BarButtonItem bbiPrinterUnit;
        private DevExpress.XtraBars.BarButtonItem bbiColseFormUnit;
        private DevExpress.XtraGrid.GridControl gridControlUnits;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnUnitID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnUnitName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCreatedBy;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnModifyBy;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnModifyLast;

    }
}