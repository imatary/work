namespace Stock.GUI.Forms
{
    partial class FormDepartments
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDepartments));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.bbiAddDepartment = new DevExpress.XtraBars.BarButtonItem();
            this.bbiEditDepartment = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDeleteDepartment = new DevExpress.XtraBars.BarButtonItem();
            this.bbiRefeshDepartment = new DevExpress.XtraBars.BarButtonItem();
            this.bbiPrinterDepartment = new DevExpress.XtraBars.BarButtonItem();
            this.bbiColseFormDepartment = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.gridControlDepartments = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnDepartmentID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnDepartmentName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCreatedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnModifyBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnModifyLast = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDepartments)).BeginInit();
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
            this.bbiAddDepartment,
            this.bbiDeleteDepartment,
            this.bbiEditDepartment,
            this.bbiRefeshDepartment,
            this.bbiPrinterDepartment,
            this.bbiColseFormDepartment});
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
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiAddDepartment, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiEditDepartment, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiDeleteDepartment, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiRefeshDepartment, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiPrinterDepartment, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.bbiColseFormDepartment, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.MultiLine = true;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // bbiAddDepartment
            // 
            this.bbiAddDepartment.Caption = "Thêm (Ctrl+N)";
            this.bbiAddDepartment.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiAddDepartment.Glyph")));
            this.bbiAddDepartment.Id = 2;
            this.bbiAddDepartment.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiAddDepartment.LargeGlyph")));
            this.bbiAddDepartment.Name = "bbiAddDepartment";
            this.bbiAddDepartment.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiAddDepartment_ItemClick);
            // 
            // bbiEditDepartment
            // 
            this.bbiEditDepartment.Caption = "Sửa (Ctrl+E)";
            this.bbiEditDepartment.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiEditDepartment.Glyph")));
            this.bbiEditDepartment.Id = 4;
            this.bbiEditDepartment.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiEditDepartment.LargeGlyph")));
            this.bbiEditDepartment.Name = "bbiEditDepartment";
            this.bbiEditDepartment.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiEditDepartment_ItemClick);
            // 
            // bbiDeleteDepartment
            // 
            this.bbiDeleteDepartment.Caption = "Xóa (Ctrl+D)";
            this.bbiDeleteDepartment.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiDeleteDepartment.Glyph")));
            this.bbiDeleteDepartment.Id = 3;
            this.bbiDeleteDepartment.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiDeleteDepartment.LargeGlyph")));
            this.bbiDeleteDepartment.Name = "bbiDeleteDepartment";
            this.bbiDeleteDepartment.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiDeleteDepartment_ItemClick);
            // 
            // bbiRefeshDepartment
            // 
            this.bbiRefeshDepartment.Caption = "Nạp Lại (F5)";
            this.bbiRefeshDepartment.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiRefeshDepartment.Glyph")));
            this.bbiRefeshDepartment.Id = 5;
            this.bbiRefeshDepartment.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiRefeshDepartment.LargeGlyph")));
            this.bbiRefeshDepartment.Name = "bbiRefeshDepartment";
            this.bbiRefeshDepartment.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiRefeshDepartment_ItemClick);
            // 
            // bbiPrinterDepartment
            // 
            this.bbiPrinterDepartment.Caption = "In (Ctrl+P)";
            this.bbiPrinterDepartment.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiPrinterDepartment.Glyph")));
            this.bbiPrinterDepartment.Id = 6;
            this.bbiPrinterDepartment.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiPrinterDepartment.LargeGlyph")));
            this.bbiPrinterDepartment.Name = "bbiPrinterDepartment";
            // 
            // bbiColseFormDepartment
            // 
            this.bbiColseFormDepartment.Caption = "Đóng (Esc)";
            this.bbiColseFormDepartment.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiColseFormDepartment.Glyph")));
            this.bbiColseFormDepartment.Id = 7;
            this.bbiColseFormDepartment.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiColseFormDepartment.LargeGlyph")));
            this.bbiColseFormDepartment.Name = "bbiColseFormDepartment";
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
            // gridControlDepartments
            // 
            this.gridControlDepartments.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControlDepartments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlDepartments.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridControlDepartments.Location = new System.Drawing.Point(0, 55);
            this.gridControlDepartments.MainView = this.gridView1;
            this.gridControlDepartments.MenuManager = this.barManager1;
            this.gridControlDepartments.Name = "gridControlDepartments";
            this.gridControlDepartments.Size = new System.Drawing.Size(566, 316);
            this.gridControlDepartments.TabIndex = 4;
            this.gridControlDepartments.UseEmbeddedNavigator = true;
            this.gridControlDepartments.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnDepartmentID,
            this.gridColumnDepartmentName,
            this.gridColumnCreatedBy,
            this.gridColumnModifyBy,
            this.gridColumnModifyLast});
            this.gridView1.GridControl = this.gridControlDepartments;
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
            // gridColumnDepartmentID
            // 
            this.gridColumnDepartmentID.Caption = "Mã Bộ Phận";
            this.gridColumnDepartmentID.FieldName = "DepartmentID";
            this.gridColumnDepartmentID.Name = "gridColumnDepartmentID";
            this.gridColumnDepartmentID.Visible = true;
            this.gridColumnDepartmentID.VisibleIndex = 1;
            this.gridColumnDepartmentID.Width = 124;
            // 
            // gridColumnDepartmentName
            // 
            this.gridColumnDepartmentName.Caption = "Tên Bộ Phận";
            this.gridColumnDepartmentName.FieldName = "DepartmentName";
            this.gridColumnDepartmentName.Name = "gridColumnDepartmentName";
            this.gridColumnDepartmentName.Visible = true;
            this.gridColumnDepartmentName.VisibleIndex = 2;
            this.gridColumnDepartmentName.Width = 156;
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
            // FormDepartments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 371);
            this.Controls.Add(this.gridControlDepartments);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "FormDepartments";
            this.Text = "Đơn Vị Tính";
            this.Load += new System.EventHandler(this.FormDepartments_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlDepartments)).EndInit();
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
        private DevExpress.XtraBars.BarButtonItem bbiAddDepartment;
        private DevExpress.XtraBars.BarButtonItem bbiDeleteDepartment;
        private DevExpress.XtraBars.BarButtonItem bbiEditDepartment;
        private DevExpress.XtraBars.BarButtonItem bbiRefeshDepartment;
        private DevExpress.XtraBars.BarButtonItem bbiPrinterDepartment;
        private DevExpress.XtraBars.BarButtonItem bbiColseFormDepartment;
        private DevExpress.XtraGrid.GridControl gridControlDepartments;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnDepartmentID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnDepartmentName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCreatedBy;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnModifyBy;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnModifyLast;
    }
}