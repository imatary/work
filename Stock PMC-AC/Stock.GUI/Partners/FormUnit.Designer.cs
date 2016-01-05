namespace Stock.GUI.Partners
{
    partial class FormUnit
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
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barButtonItemAdd = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemUpdate = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemDelete = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemRefesh = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemPrint = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemExportToExel = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemClose = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnUnitID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnUnitName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnActive = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
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
            this.barButtonItem1,
            this.barButtonItemAdd,
            this.barButtonItemUpdate,
            this.barButtonItemDelete,
            this.barButtonItemRefesh,
            this.barButtonItemPrint,
            this.barButtonItemExportToExel,
            this.barButtonItemClose});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 16;
            // 
            // bar2
            // 
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.FloatLocation = new System.Drawing.Point(236, 133);
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItemAdd, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItemUpdate, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItemDelete, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItemRefesh, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItemPrint, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItemExportToExel, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItemClose, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // barButtonItemAdd
            // 
            this.barButtonItemAdd.Caption = "Thêm";
            this.barButtonItemAdd.Glyph = global::Stock.GUI.Properties.Resources.add_16;
            this.barButtonItemAdd.Id = 4;
            this.barButtonItemAdd.LargeGlyph = global::Stock.GUI.Properties.Resources.pesmission_32;
            this.barButtonItemAdd.Name = "barButtonItemAdd";
            this.barButtonItemAdd.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemAdd_ItemClick);
            // 
            // barButtonItemUpdate
            // 
            this.barButtonItemUpdate.Caption = "Sửa";
            this.barButtonItemUpdate.Enabled = false;
            this.barButtonItemUpdate.Glyph = global::Stock.GUI.Properties.Resources.page_white_edit_16;
            this.barButtonItemUpdate.Id = 6;
            this.barButtonItemUpdate.Name = "barButtonItemUpdate";
            this.barButtonItemUpdate.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemUpdate_ItemClick);
            // 
            // barButtonItemDelete
            // 
            this.barButtonItemDelete.Caption = "Xóa";
            this.barButtonItemDelete.Enabled = false;
            this.barButtonItemDelete.Glyph = global::Stock.GUI.Properties.Resources.trash_16_1;
            this.barButtonItemDelete.Id = 7;
            this.barButtonItemDelete.Name = "barButtonItemDelete";
            this.barButtonItemDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemDelete_ItemClick);
            // 
            // barButtonItemRefesh
            // 
            this.barButtonItemRefesh.Caption = "Nạp Lại";
            this.barButtonItemRefesh.Glyph = global::Stock.GUI.Properties.Resources.table_refresh_16;
            this.barButtonItemRefesh.Id = 10;
            this.barButtonItemRefesh.Name = "barButtonItemRefesh";
            this.barButtonItemRefesh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemRefesh_ItemClick);
            // 
            // barButtonItemPrint
            // 
            this.barButtonItemPrint.Caption = "In";
            this.barButtonItemPrint.Glyph = global::Stock.GUI.Properties.Resources.print_16;
            this.barButtonItemPrint.Id = 11;
            this.barButtonItemPrint.LargeGlyph = global::Stock.GUI.Properties.Resources.print_16;
            this.barButtonItemPrint.Name = "barButtonItemPrint";
            this.barButtonItemPrint.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemPrint_ItemClick);
            // 
            // barButtonItemExportToExel
            // 
            this.barButtonItemExportToExel.Caption = "Xuất ra Exel";
            this.barButtonItemExportToExel.Glyph = global::Stock.GUI.Properties.Resources.export_excel_16;
            this.barButtonItemExportToExel.Id = 12;
            this.barButtonItemExportToExel.Name = "barButtonItemExportToExel";
            this.barButtonItemExportToExel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemExportToExel_ItemClick);
            // 
            // barButtonItemClose
            // 
            this.barButtonItemClose.Caption = "Đóng";
            this.barButtonItemClose.Glyph = global::Stock.GUI.Properties.Resources.delete_16;
            this.barButtonItemClose.Id = 13;
            this.barButtonItemClose.Name = "barButtonItemClose";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(889, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 674);
            this.barDockControlBottom.Size = new System.Drawing.Size(889, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 650);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(889, 24);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 650);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Thêm";
            this.barButtonItem1.Glyph = global::Stock.GUI.Properties.Resources.add_16;
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.LargeGlyph = global::Stock.GUI.Properties.Resources.add_16;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // gridControl1
            // 
            this.gridControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 24);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(889, 650);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.UseEmbeddedNavigator = true;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnUnitID,
            this.gridColumnUnitName,
            this.gridColumnCreatedDate,
            this.gridColumnDescription,
            this.gridColumnActive});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsPrint.PrintPreview = true;
            this.gridView1.OptionsSelection.CheckBoxSelectorColumnWidth = 35;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView1.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsSelection.ShowCheckBoxSelectorInPrintExport = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // gridColumnUnitID
            // 
            this.gridColumnUnitID.Caption = "Mã";
            this.gridColumnUnitID.FieldName = "UnitID";
            this.gridColumnUnitID.Name = "gridColumnUnitID";
            this.gridColumnUnitID.OptionsColumn.AllowEdit = false;
            this.gridColumnUnitID.OptionsColumn.ReadOnly = true;
            this.gridColumnUnitID.OptionsEditForm.CaptionLocation = DevExpress.XtraGrid.EditForm.EditFormColumnCaptionLocation.Near;
            this.gridColumnUnitID.OptionsEditForm.ColumnSpan = 6;
            this.gridColumnUnitID.OptionsEditForm.UseEditorColRowSpan = false;
            this.gridColumnUnitID.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumnUnitID.OptionsEditForm.VisibleIndex = 1;
            this.gridColumnUnitID.Visible = true;
            this.gridColumnUnitID.VisibleIndex = 1;
            this.gridColumnUnitID.Width = 126;
            // 
            // gridColumnUnitName
            // 
            this.gridColumnUnitName.Caption = "Tên";
            this.gridColumnUnitName.FieldName = "UnitName";
            this.gridColumnUnitName.MinWidth = 50;
            this.gridColumnUnitName.Name = "gridColumnUnitName";
            this.gridColumnUnitName.OptionsColumn.AllowEdit = false;
            this.gridColumnUnitName.OptionsColumn.ReadOnly = true;
            this.gridColumnUnitName.OptionsEditForm.ColumnSpan = 6;
            this.gridColumnUnitName.OptionsEditForm.UseEditorColRowSpan = false;
            this.gridColumnUnitName.OptionsEditForm.VisibleIndex = 2;
            this.gridColumnUnitName.Visible = true;
            this.gridColumnUnitName.VisibleIndex = 2;
            this.gridColumnUnitName.Width = 210;
            // 
            // gridColumnCreatedDate
            // 
            this.gridColumnCreatedDate.Caption = "Ngày tạo";
            this.gridColumnCreatedDate.FieldName = "CreatedDate";
            this.gridColumnCreatedDate.Name = "gridColumnCreatedDate";
            this.gridColumnCreatedDate.OptionsColumn.AllowEdit = false;
            this.gridColumnCreatedDate.OptionsColumn.ReadOnly = true;
            this.gridColumnCreatedDate.OptionsEditForm.ColumnSpan = 6;
            this.gridColumnCreatedDate.OptionsEditForm.UseEditorColRowSpan = false;
            this.gridColumnCreatedDate.OptionsEditForm.VisibleIndex = 3;
            this.gridColumnCreatedDate.Visible = true;
            this.gridColumnCreatedDate.VisibleIndex = 3;
            this.gridColumnCreatedDate.Width = 100;
            // 
            // gridColumnDescription
            // 
            this.gridColumnDescription.Caption = "Chi Chú";
            this.gridColumnDescription.FieldName = "Description";
            this.gridColumnDescription.MinWidth = 150;
            this.gridColumnDescription.Name = "gridColumnDescription";
            this.gridColumnDescription.OptionsColumn.AllowEdit = false;
            this.gridColumnDescription.OptionsColumn.ReadOnly = true;
            this.gridColumnDescription.OptionsEditForm.ColumnSpan = 6;
            this.gridColumnDescription.OptionsEditForm.RowSpan = 3;
            this.gridColumnDescription.OptionsEditForm.UseEditorColRowSpan = false;
            this.gridColumnDescription.OptionsEditForm.VisibleIndex = 4;
            this.gridColumnDescription.Visible = true;
            this.gridColumnDescription.VisibleIndex = 4;
            this.gridColumnDescription.Width = 295;
            // 
            // gridColumnActive
            // 
            this.gridColumnActive.Caption = "Trạng Thái";
            this.gridColumnActive.FieldName = "IsActive";
            this.gridColumnActive.Name = "gridColumnActive";
            this.gridColumnActive.Visible = true;
            this.gridColumnActive.VisibleIndex = 5;
            // 
            // FormUnit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 674);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "FormUnit";
            this.Text = "Đơn Vị Tính";
            this.Load += new System.EventHandler(this.FormUnit_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormUnit_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barButtonItemAdd;
        private DevExpress.XtraBars.BarButtonItem barButtonItemUpdate;
        private DevExpress.XtraBars.BarButtonItem barButtonItemDelete;
        private DevExpress.XtraBars.BarButtonItem barButtonItemRefesh;
        private DevExpress.XtraBars.BarButtonItem barButtonItemPrint;
        private DevExpress.XtraBars.BarButtonItem barButtonItemExportToExel;
        private DevExpress.XtraBars.BarButtonItem barButtonItemClose;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnUnitID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnUnitName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnDescription;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnActive;
    }
}