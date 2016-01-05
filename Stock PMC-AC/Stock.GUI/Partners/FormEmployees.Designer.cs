namespace Stock.GUI.Partners
{
    partial class FormEmployees
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
            this.barButtonItemImportEmploeeFormExcel = new DevExpress.XtraBars.BarButtonItem();
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
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.skinBarSubItem1 = new DevExpress.XtraBars.SkinBarSubItem();
            this.barToolbarsListItem1 = new DevExpress.XtraBars.BarToolbarsListItem();
            this.barDockingMenuItem1 = new DevExpress.XtraBars.BarDockingMenuItem();
            this.barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnEmployeeID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnEmployeeCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnEmployeeName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPhone = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnIsActive = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnDepartmentName = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.barButtonItem2,
            this.barButtonItem3,
            this.barButtonItem4,
            this.barButtonItemAdd,
            this.skinBarSubItem1,
            this.barButtonItemUpdate,
            this.barButtonItemDelete,
            this.barToolbarsListItem1,
            this.barDockingMenuItem1,
            this.barButtonItemRefesh,
            this.barButtonItemPrint,
            this.barButtonItemExportToExel,
            this.barButtonItemClose,
            this.barButtonItem5,
            this.barButtonItem6,
            this.barButtonItemImportEmploeeFormExcel});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 17;
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItemImportEmploeeFormExcel, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItemUpdate, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItemDelete, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItemRefesh, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItemPrint, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItemExportToExel, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
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
            // barButtonItemImportEmploeeFormExcel
            // 
            this.barButtonItemImportEmploeeFormExcel.Caption = "Nhập Từ Excel";
            this.barButtonItemImportEmploeeFormExcel.Glyph = global::Stock.GUI.Properties.Resources.page_excel;
            this.barButtonItemImportEmploeeFormExcel.Id = 16;
            this.barButtonItemImportEmploeeFormExcel.Name = "barButtonItemImportEmploeeFormExcel";
            this.barButtonItemImportEmploeeFormExcel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemImportEmploeeFormExcel_ItemClick);
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
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "barButtonItem2";
            this.barButtonItem2.Id = 1;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "barButtonItem3";
            this.barButtonItem3.Id = 2;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "barButtonItem4";
            this.barButtonItem4.Id = 3;
            this.barButtonItem4.Name = "barButtonItem4";
            // 
            // skinBarSubItem1
            // 
            this.skinBarSubItem1.Caption = "skinBarSubItem1";
            this.skinBarSubItem1.Id = 5;
            this.skinBarSubItem1.Name = "skinBarSubItem1";
            // 
            // barToolbarsListItem1
            // 
            this.barToolbarsListItem1.Caption = "barToolbarsListItem1";
            this.barToolbarsListItem1.Id = 8;
            this.barToolbarsListItem1.Name = "barToolbarsListItem1";
            // 
            // barDockingMenuItem1
            // 
            this.barDockingMenuItem1.Caption = "barDockingMenuItem1";
            this.barDockingMenuItem1.Id = 9;
            this.barDockingMenuItem1.Name = "barDockingMenuItem1";
            // 
            // barButtonItem5
            // 
            this.barButtonItem5.Caption = "barButtonItem5";
            this.barButtonItem5.Id = 14;
            this.barButtonItem5.Name = "barButtonItem5";
            // 
            // barButtonItem6
            // 
            this.barButtonItem6.Caption = "barButtonItem6";
            this.barButtonItem6.Id = 15;
            this.barButtonItem6.Name = "barButtonItem6";
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
            this.gridColumnEmployeeID,
            this.gridColumnEmployeeCode,
            this.gridColumnEmployeeName,
            this.gridColumnEmail,
            this.gridColumnPhone,
            this.gridColumnIsActive,
            this.gridColumnDepartmentName});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupCount = 1;
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Count, "DepartmentName", null, "({0})")});
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsFind.FindNullPrompt = "Nhập vào thông tin Nhân viên cần tìm...";
            this.gridView1.OptionsFind.SearchInPreview = true;
            this.gridView1.OptionsFind.ShowClearButton = false;
            this.gridView1.OptionsFind.ShowFindButton = false;
            this.gridView1.OptionsSelection.CheckBoxSelectorColumnWidth = 35;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView1.OptionsSelection.ResetSelectionClickOutsideCheckboxSelector = true;
            this.gridView1.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsSelection.ShowCheckBoxSelectorInPrintExport = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumnDepartmentName, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridView1_RowClick);
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // gridColumnEmployeeID
            // 
            this.gridColumnEmployeeID.Caption = "Mã";
            this.gridColumnEmployeeID.FieldName = "EmployeeID";
            this.gridColumnEmployeeID.Name = "gridColumnEmployeeID";
            this.gridColumnEmployeeID.OptionsColumn.AllowEdit = false;
            this.gridColumnEmployeeID.OptionsColumn.ReadOnly = true;
            this.gridColumnEmployeeID.OptionsEditForm.CaptionLocation = DevExpress.XtraGrid.EditForm.EditFormColumnCaptionLocation.Near;
            this.gridColumnEmployeeID.OptionsEditForm.ColumnSpan = 6;
            this.gridColumnEmployeeID.OptionsEditForm.UseEditorColRowSpan = false;
            this.gridColumnEmployeeID.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.True;
            this.gridColumnEmployeeID.OptionsEditForm.VisibleIndex = 1;
            this.gridColumnEmployeeID.Visible = true;
            this.gridColumnEmployeeID.VisibleIndex = 1;
            this.gridColumnEmployeeID.Width = 97;
            // 
            // gridColumnEmployeeCode
            // 
            this.gridColumnEmployeeCode.Caption = "Code";
            this.gridColumnEmployeeCode.FieldName = "EmployeeCode";
            this.gridColumnEmployeeCode.Name = "gridColumnEmployeeCode";
            this.gridColumnEmployeeCode.OptionsColumn.AllowEdit = false;
            this.gridColumnEmployeeCode.OptionsColumn.ReadOnly = true;
            this.gridColumnEmployeeCode.OptionsEditForm.ColumnSpan = 6;
            this.gridColumnEmployeeCode.OptionsEditForm.RowSpan = 3;
            this.gridColumnEmployeeCode.OptionsEditForm.UseEditorColRowSpan = false;
            this.gridColumnEmployeeCode.OptionsEditForm.VisibleIndex = 4;
            this.gridColumnEmployeeCode.Visible = true;
            this.gridColumnEmployeeCode.VisibleIndex = 3;
            this.gridColumnEmployeeCode.Width = 128;
            // 
            // gridColumnEmployeeName
            // 
            this.gridColumnEmployeeName.Caption = "Tên";
            this.gridColumnEmployeeName.FieldName = "EmployeeName";
            this.gridColumnEmployeeName.MinWidth = 60;
            this.gridColumnEmployeeName.Name = "gridColumnEmployeeName";
            this.gridColumnEmployeeName.OptionsColumn.AllowEdit = false;
            this.gridColumnEmployeeName.OptionsColumn.ReadOnly = true;
            this.gridColumnEmployeeName.OptionsEditForm.ColumnSpan = 6;
            this.gridColumnEmployeeName.OptionsEditForm.UseEditorColRowSpan = false;
            this.gridColumnEmployeeName.OptionsEditForm.VisibleIndex = 2;
            this.gridColumnEmployeeName.Visible = true;
            this.gridColumnEmployeeName.VisibleIndex = 2;
            this.gridColumnEmployeeName.Width = 244;
            // 
            // gridColumnEmail
            // 
            this.gridColumnEmail.Caption = "Email";
            this.gridColumnEmail.FieldName = "Email";
            this.gridColumnEmail.Name = "gridColumnEmail";
            this.gridColumnEmail.Visible = true;
            this.gridColumnEmail.VisibleIndex = 4;
            this.gridColumnEmail.Width = 150;
            // 
            // gridColumnPhone
            // 
            this.gridColumnPhone.Caption = "Số điện thoại";
            this.gridColumnPhone.FieldName = "HomeTell";
            this.gridColumnPhone.Name = "gridColumnPhone";
            this.gridColumnPhone.Visible = true;
            this.gridColumnPhone.VisibleIndex = 5;
            this.gridColumnPhone.Width = 133;
            // 
            // gridColumnIsActive
            // 
            this.gridColumnIsActive.Caption = "Trạng thái";
            this.gridColumnIsActive.FieldName = "IsActive";
            this.gridColumnIsActive.Name = "gridColumnIsActive";
            this.gridColumnIsActive.Visible = true;
            this.gridColumnIsActive.VisibleIndex = 6;
            this.gridColumnIsActive.Width = 119;
            // 
            // gridColumnDepartmentName
            // 
            this.gridColumnDepartmentName.Caption = "Bộ Phận";
            this.gridColumnDepartmentName.FieldName = "DepartmentName";
            this.gridColumnDepartmentName.Name = "gridColumnDepartmentName";
            this.gridColumnDepartmentName.Visible = true;
            this.gridColumnDepartmentName.VisibleIndex = 6;
            // 
            // FormEmployees
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
            this.Name = "FormEmployees";
            this.Text = "Nhân Viên";
            this.Load += new System.EventHandler(this.FormEmployees_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormEmployees_KeyDown);
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
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarButtonItem barButtonItemAdd;
        private DevExpress.XtraBars.BarButtonItem barButtonItemUpdate;
        private DevExpress.XtraBars.BarButtonItem barButtonItemDelete;
        private DevExpress.XtraBars.SkinBarSubItem skinBarSubItem1;
        private DevExpress.XtraBars.BarToolbarsListItem barToolbarsListItem1;
        private DevExpress.XtraBars.BarDockingMenuItem barDockingMenuItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItemRefesh;
        private DevExpress.XtraBars.BarButtonItem barButtonItemPrint;
        private DevExpress.XtraBars.BarButtonItem barButtonItemExportToExel;
        private DevExpress.XtraBars.BarButtonItem barButtonItemClose;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnEmployeeID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnEmployeeName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnEmployeeCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPhone;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnEmail;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnIsActive;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnDepartmentName;
        private DevExpress.XtraBars.BarButtonItem barButtonItemImportEmploeeFormExcel;

    }
}