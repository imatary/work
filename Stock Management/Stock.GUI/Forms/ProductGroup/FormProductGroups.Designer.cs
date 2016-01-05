namespace Stock.GUI.Forms
{
    partial class FormProductGroups
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProductGroups));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bbiAddProductGroup = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEditProductGroup = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDeleteProductGroup = new DevExpress.XtraBars.BarButtonItem();
            this.bbiRefeshProductGroup = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPrinterProductGroup = new DevExpress.XtraBars.BarButtonItem();
            this.bbiColseFormProductGroup = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.gridControlProductGroups = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnProductGroupID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnProductGroupName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCreatedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnModifyBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnModifyLast = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlProductGroups)).BeginInit();
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
            this.bbiAddProductGroup,
            this.bbiDeleteProductGroup,
            this.bbiEditProductGroup,
            this.bbiRefeshProductGroup,
            this.bbiPrinterProductGroup,
            this.bbiColseFormProductGroup});
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiAddProductGroup, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiEditProductGroup, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiDeleteProductGroup, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiRefeshProductGroup, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiPrinterProductGroup, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiColseFormProductGroup, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // bbiAddProductGroup
            // 
            this.bbiAddProductGroup.Caption = "Thêm (Ctrl+N)";
            this.bbiAddProductGroup.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiAddProductGroup.Glyph")));
            this.bbiAddProductGroup.Id = 2;
            this.bbiAddProductGroup.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiAddProductGroup.LargeGlyph")));
            this.bbiAddProductGroup.Name = "bbiAddProductGroup";
            this.bbiAddProductGroup.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiAddProductGroup_ItemClick);
            // 
            // bbiEditProductGroup
            // 
            this.bbiEditProductGroup.Caption = "Sửa (Ctrl+E)";
            this.bbiEditProductGroup.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiEditProductGroup.Glyph")));
            this.bbiEditProductGroup.Id = 4;
            this.bbiEditProductGroup.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiEditProductGroup.LargeGlyph")));
            this.bbiEditProductGroup.Name = "bbiEditProductGroup";
            this.bbiEditProductGroup.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiEditProductGroup_ItemClick);
            // 
            // bbiDeleteProductGroup
            // 
            this.bbiDeleteProductGroup.Caption = "Xóa (Ctrl+D)";
            this.bbiDeleteProductGroup.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiDeleteProductGroup.Glyph")));
            this.bbiDeleteProductGroup.Id = 3;
            this.bbiDeleteProductGroup.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiDeleteProductGroup.LargeGlyph")));
            this.bbiDeleteProductGroup.Name = "bbiDeleteProductGroup";
            this.bbiDeleteProductGroup.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiDeleteProductGroup_ItemClick);
            // 
            // bbiRefeshProductGroup
            // 
            this.bbiRefeshProductGroup.Caption = "Nạp Lại (F5)";
            this.bbiRefeshProductGroup.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiRefeshProductGroup.Glyph")));
            this.bbiRefeshProductGroup.Id = 5;
            this.bbiRefeshProductGroup.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiRefeshProductGroup.LargeGlyph")));
            this.bbiRefeshProductGroup.Name = "bbiRefeshProductGroup";
            this.bbiRefeshProductGroup.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiRefeshProductGroup_ItemClick);
            // 
            // bbiPrinterProductGroup
            // 
            this.bbiPrinterProductGroup.Caption = "In (Ctrl+P)";
            this.bbiPrinterProductGroup.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiPrinterProductGroup.Glyph")));
            this.bbiPrinterProductGroup.Id = 6;
            this.bbiPrinterProductGroup.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiPrinterProductGroup.LargeGlyph")));
            this.bbiPrinterProductGroup.Name = "bbiPrinterProductGroup";
            // 
            // bbiColseFormProductGroup
            // 
            this.bbiColseFormProductGroup.Caption = "Đóng (Esc)";
            this.bbiColseFormProductGroup.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiColseFormProductGroup.Glyph")));
            this.bbiColseFormProductGroup.Id = 7;
            this.bbiColseFormProductGroup.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiColseFormProductGroup.LargeGlyph")));
            this.bbiColseFormProductGroup.Name = "bbiColseFormProductGroup";
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
            // gridControlProductGroups
            // 
            this.gridControlProductGroups.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControlProductGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlProductGroups.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridControlProductGroups.Location = new System.Drawing.Point(0, 55);
            this.gridControlProductGroups.MainView = this.gridView1;
            this.gridControlProductGroups.MenuManager = this.barManager1;
            this.gridControlProductGroups.Name = "gridControlProductGroups";
            this.gridControlProductGroups.Size = new System.Drawing.Size(566, 316);
            this.gridControlProductGroups.TabIndex = 4;
            this.gridControlProductGroups.UseEmbeddedNavigator = true;
            this.gridControlProductGroups.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnProductGroupID,
            this.gridColumnProductGroupName,
            this.gridColumnCreatedBy,
            this.gridColumnModifyBy,
            this.gridColumnModifyLast});
            this.gridView1.GridControl = this.gridControlProductGroups;
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
            // gridColumnProductGroupID
            // 
            this.gridColumnProductGroupID.Caption = "Mã Nhóm Hàng";
            this.gridColumnProductGroupID.FieldName = "ProductGroupID";
            this.gridColumnProductGroupID.Name = "gridColumnProductGroupID";
            this.gridColumnProductGroupID.Visible = true;
            this.gridColumnProductGroupID.VisibleIndex = 1;
            this.gridColumnProductGroupID.Width = 124;
            // 
            // gridColumnProductGroupName
            // 
            this.gridColumnProductGroupName.Caption = "Tên Nhóm Hàng";
            this.gridColumnProductGroupName.FieldName = "ProductGroupName";
            this.gridColumnProductGroupName.Name = "gridColumnProductGroupName";
            this.gridColumnProductGroupName.Visible = true;
            this.gridColumnProductGroupName.VisibleIndex = 2;
            this.gridColumnProductGroupName.Width = 156;
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
            this.gridColumnModifyLast.DisplayFormat.FormatString = "d";
            this.gridColumnModifyLast.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.gridColumnModifyLast.FieldName = "ModifyDate";
            this.gridColumnModifyLast.Name = "gridColumnModifyLast";
            this.gridColumnModifyLast.Visible = true;
            this.gridColumnModifyLast.VisibleIndex = 5;
            this.gridColumnModifyLast.Width = 158;
            // 
            // FormProductGroups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 371);
            this.Controls.Add(this.gridControlProductGroups);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "FormProductGroups";
            this.Text = "Nhóm Hàng";
            this.Load += new System.EventHandler(this.FormProductGroups_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlProductGroups)).EndInit();
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
        private DevExpress.XtraBars.BarButtonItem bbiAddProductGroup;
        private DevExpress.XtraBars.BarButtonItem bbiDeleteProductGroup;
        private DevExpress.XtraBars.BarButtonItem bbiEditProductGroup;
        private DevExpress.XtraBars.BarButtonItem bbiRefeshProductGroup;
        private DevExpress.XtraBars.BarButtonItem bbiPrinterProductGroup;
        private DevExpress.XtraBars.BarButtonItem bbiColseFormProductGroup;
        private DevExpress.XtraGrid.GridControl gridControlProductGroups;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnProductGroupID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnProductGroupName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCreatedBy;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnModifyBy;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnModifyLast;
    }
}