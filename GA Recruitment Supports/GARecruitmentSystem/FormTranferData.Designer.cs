using System;
using DevExpress.XtraBars;

namespace GARecruitmentSystem
{
    partial class FormTranferData
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTranferData));
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::GARecruitmentSystem.FormWaiting.WaitFormLoadData), true, true);
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.btnUpdate = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnExportExel = new DevExpress.XtraBars.BarButtonItem();
            this.btnPrint = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.btnRefesh = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.repositoryItemSearchControl1 = new DevExpress.XtraEditors.Repository.RepositoryItemSearchControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.txtSearchDate = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.bandedGridView1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridColumnSTT = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumnFullName = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumnBirthday = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumnSex = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumnHight = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumnSDT = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumnNS = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumnHKTT = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumnDT = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand4 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridColumnCMT = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumnNgayCap = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumnNoiCap = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand5 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridColumnStaffID = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumnStaffCode = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumnDept = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumnPosition = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand6 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridColumnNgayPV = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumnNguoiPV = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumnNgayDiLam = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumnID = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // splashScreenManager1
            // 
            this.splashScreenManager1.ClosingDelay = 500;
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
            this.btnUpdate,
            this.btnRefesh,
            this.btnDelete,
            this.barButtonItem1,
            this.btnExportExel,
            this.btnPrint});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 9;
            this.barManager1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemSearchControl1});
            // 
            // bar2
            // 
            this.bar2.BarAppearance.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.bar2.BarAppearance.Normal.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.bar2.BarAppearance.Normal.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.bar2.BarAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bar2.BarAppearance.Normal.Options.UseBackColor = true;
            this.bar2.BarAppearance.Normal.Options.UseBorderColor = true;
            this.bar2.BarAppearance.Normal.Options.UseFont = true;
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnUpdate, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnDelete, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnExportExel, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.btnPrint, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.MinHeight = 36;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Caption = "Sửa";
            this.btnUpdate.Glyph = ((System.Drawing.Image)(resources.GetObject("btnUpdate.Glyph")));
            this.btnUpdate.Id = 2;
            this.btnUpdate.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.ItemAppearance.Normal.Options.UseFont = true;
            this.btnUpdate.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnUpdate.LargeGlyph")));
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnUpdate_ItemClick);
            // 
            // btnDelete
            // 
            this.btnDelete.Caption = "Xóa";
            this.btnDelete.Glyph = ((System.Drawing.Image)(resources.GetObject("btnDelete.Glyph")));
            this.btnDelete.Id = 4;
            this.btnDelete.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.ItemAppearance.Normal.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.btnDelete.ItemAppearance.Normal.Options.UseFont = true;
            this.btnDelete.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnDelete.LargeGlyph")));
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDelete_ItemClick);
            // 
            // btnExportExel
            // 
            this.btnExportExel.Caption = "Xuất ra Exel";
            this.btnExportExel.Glyph = ((System.Drawing.Image)(resources.GetObject("btnExportExel.Glyph")));
            this.btnExportExel.Id = 6;
            this.btnExportExel.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportExel.ItemAppearance.Normal.Options.UseFont = true;
            this.btnExportExel.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnExportExel.LargeGlyph")));
            this.btnExportExel.Name = "btnExportExel";
            this.btnExportExel.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnExportExel_ItemClick);
            // 
            // btnPrint
            // 
            this.btnPrint.Caption = "Print";
            this.btnPrint.Glyph = ((System.Drawing.Image)(resources.GetObject("btnPrint.Glyph")));
            this.btnPrint.Id = 8;
            this.btnPrint.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.ItemAppearance.Normal.Options.UseFont = true;
            this.btnPrint.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnPrint.LargeGlyph")));
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPrint_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(969, 36);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 527);
            this.barDockControlBottom.Size = new System.Drawing.Size(969, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 36);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 491);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(969, 36);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 491);
            // 
            // btnRefesh
            // 
            this.btnRefesh.Caption = "Tải lại";
            this.btnRefesh.Glyph = ((System.Drawing.Image)(resources.GetObject("btnRefesh.Glyph")));
            this.btnRefesh.Id = 3;
            this.btnRefesh.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefesh.ItemAppearance.Normal.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.btnRefesh.ItemAppearance.Normal.Options.UseFont = true;
            this.btnRefesh.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("btnRefesh.LargeGlyph")));
            this.btnRefesh.Name = "btnRefesh";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Tìm kiếm";
            this.barButtonItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.Glyph")));
            this.barButtonItem1.Id = 5;
            this.barButtonItem1.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barButtonItem1.ItemAppearance.Normal.Options.UseFont = true;
            this.barButtonItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.LargeGlyph")));
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // repositoryItemSearchControl1
            // 
            this.repositoryItemSearchControl1.AutoHeight = false;
            this.repositoryItemSearchControl1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Repository.ClearButton(),
            new DevExpress.XtraEditors.Repository.SearchButton()});
            this.repositoryItemSearchControl1.Name = "repositoryItemSearchControl1";
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.btnSearch);
            this.panelControl1.Controls.Add(this.txtSearchDate);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 36);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(969, 76);
            this.panelControl1.TabIndex = 5;
            // 
            // btnSearch
            // 
            this.btnSearch.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.btnSearch.Appearance.Options.UseFont = true;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(610, 22);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(101, 28);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Tìm kiếm";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearchDate
            // 
            this.txtSearchDate.Location = new System.Drawing.Point(353, 22);
            this.txtSearchDate.MenuManager = this.barManager1;
            this.txtSearchDate.Name = "txtSearchDate";
            this.txtSearchDate.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtSearchDate.Properties.Appearance.Options.UseFont = true;
            this.txtSearchDate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtSearchDate.Properties.Mask.EditMask = "([012]?[1-9]|[123]0|31)/(0?[1-9]|1[012])/([123][0-9])?[0-9][0-9]";
            this.txtSearchDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.RegEx;
            this.txtSearchDate.Size = new System.Drawing.Size(260, 28);
            this.txtSearchDate.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Location = new System.Drawing.Point(274, 28);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(73, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Ngày đi làm";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 112);
            this.gridControl1.MainView = this.bandedGridView1;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(969, 415);
            this.gridControl1.TabIndex = 10;
            this.gridControl1.UseEmbeddedNavigator = true;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.bandedGridView1});
            this.gridControl1.DoubleClick += new System.EventHandler(this.bandedGridView1_DoubleClick);
            // 
            // bandedGridView1
            // 
            this.bandedGridView1.Appearance.BandPanel.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.bandedGridView1.Appearance.BandPanel.Options.UseBackColor = true;
            this.bandedGridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1,
            this.gridBand4,
            this.gridBand5,
            this.gridBand6});
            this.bandedGridView1.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.gridColumnID,
            this.gridColumnSTT,
            this.gridColumnFullName,
            this.gridColumnBirthday,
            this.gridColumnSex,
            this.gridColumnSDT,
            this.gridColumnNS,
            this.gridColumnHKTT,
            this.gridColumnDT,
            this.gridColumnHight,
            this.gridColumnCMT,
            this.gridColumnNgayCap,
            this.gridColumnNoiCap,
            this.gridColumnStaffID,
            this.gridColumnStaffCode,
            this.gridColumnDept,
            this.gridColumnPosition,
            this.gridColumnNgayPV,
            this.gridColumnNguoiPV,
            this.gridColumnNgayDiLam});
            this.bandedGridView1.GridControl = this.gridControl1;
            this.bandedGridView1.Name = "bandedGridView1";
            this.bandedGridView1.OptionsBehavior.Editable = false;
            this.bandedGridView1.OptionsFind.FindDelay = 10000;
            this.bandedGridView1.OptionsFind.FindNullPrompt = "Nhập vào từ khóa cần tìm...";
            this.bandedGridView1.OptionsFind.ShowFindButton = false;
            this.bandedGridView1.OptionsImageLoad.AnimationType = DevExpress.Utils.ImageContentAnimationType.Slide;
            this.bandedGridView1.OptionsImageLoad.AsyncLoad = true;
            this.bandedGridView1.OptionsPrint.PrintPreview = true;
            this.bandedGridView1.OptionsSelection.CheckBoxSelectorColumnWidth = 30;
            this.bandedGridView1.OptionsSelection.MultiSelect = true;
            this.bandedGridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.bandedGridView1.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
            this.bandedGridView1.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.bandedGridView1_RowClick);
            this.bandedGridView1.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.bandedGridView1_PopupMenuShowing);
            this.bandedGridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.bandedGridView1_CustomColumnDisplayText);
            // 
            // gridBand1
            // 
            this.gridBand1.AppearanceHeader.BackColor = System.Drawing.SystemColors.Highlight;
            this.gridBand1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridBand1.AppearanceHeader.Options.UseBackColor = true;
            this.gridBand1.AppearanceHeader.Options.UseFont = true;
            this.gridBand1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand1.Caption = "THÔNG TIN CÁ NHÂN";
            this.gridBand1.Columns.Add(this.gridColumnSTT);
            this.gridBand1.Columns.Add(this.gridColumnFullName);
            this.gridBand1.Columns.Add(this.gridColumnBirthday);
            this.gridBand1.Columns.Add(this.gridColumnSex);
            this.gridBand1.Columns.Add(this.gridColumnHight);
            this.gridBand1.Columns.Add(this.gridColumnSDT);
            this.gridBand1.Columns.Add(this.gridColumnNS);
            this.gridBand1.Columns.Add(this.gridColumnHKTT);
            this.gridBand1.Columns.Add(this.gridColumnDT);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.VisibleIndex = 0;
            this.gridBand1.Width = 724;
            // 
            // gridColumnSTT
            // 
            this.gridColumnSTT.Caption = "#";
            this.gridColumnSTT.Name = "gridColumnSTT";
            this.gridColumnSTT.Visible = true;
            this.gridColumnSTT.Width = 40;
            // 
            // gridColumnFullName
            // 
            this.gridColumnFullName.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnFullName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnFullName.Caption = "Họ & Tên";
            this.gridColumnFullName.FieldName = "FullName";
            this.gridColumnFullName.Name = "gridColumnFullName";
            this.gridColumnFullName.Visible = true;
            this.gridColumnFullName.Width = 151;
            // 
            // gridColumnBirthday
            // 
            this.gridColumnBirthday.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnBirthday.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnBirthday.Caption = "Ngày sinh";
            this.gridColumnBirthday.FieldName = "Birthday";
            this.gridColumnBirthday.Name = "gridColumnBirthday";
            this.gridColumnBirthday.Visible = true;
            this.gridColumnBirthday.Width = 83;
            // 
            // gridColumnSex
            // 
            this.gridColumnSex.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnSex.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnSex.Caption = "Giới tính";
            this.gridColumnSex.FieldName = "Sex";
            this.gridColumnSex.Name = "gridColumnSex";
            this.gridColumnSex.Visible = true;
            // 
            // gridColumnHight
            // 
            this.gridColumnHight.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnHight.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnHight.Caption = "Chiều cao";
            this.gridColumnHight.FieldName = "Hight";
            this.gridColumnHight.Name = "gridColumnHight";
            this.gridColumnHight.Visible = true;
            // 
            // gridColumnSDT
            // 
            this.gridColumnSDT.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnSDT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnSDT.Caption = "Số điện thoại";
            this.gridColumnSDT.FieldName = "PhoneNumber";
            this.gridColumnSDT.Name = "gridColumnSDT";
            this.gridColumnSDT.Visible = true;
            // 
            // gridColumnNS
            // 
            this.gridColumnNS.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnNS.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnNS.Caption = "Nơi sinh";
            this.gridColumnNS.FieldName = "NS";
            this.gridColumnNS.Name = "gridColumnNS";
            this.gridColumnNS.Visible = true;
            // 
            // gridColumnHKTT
            // 
            this.gridColumnHKTT.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnHKTT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnHKTT.Caption = "Hộ khẩu thường chú";
            this.gridColumnHKTT.FieldName = "HKTT";
            this.gridColumnHKTT.Name = "gridColumnHKTT";
            this.gridColumnHKTT.Visible = true;
            // 
            // gridColumnDT
            // 
            this.gridColumnDT.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnDT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnDT.Caption = "Dân tộc";
            this.gridColumnDT.FieldName = "DT";
            this.gridColumnDT.Name = "gridColumnDT";
            this.gridColumnDT.Visible = true;
            // 
            // gridBand4
            // 
            this.gridBand4.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridBand4.AppearanceHeader.Options.UseFont = true;
            this.gridBand4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand4.Caption = "CHỨNG MINH THƯ";
            this.gridBand4.Columns.Add(this.gridColumnCMT);
            this.gridBand4.Columns.Add(this.gridColumnNgayCap);
            this.gridBand4.Columns.Add(this.gridColumnNoiCap);
            this.gridBand4.Name = "gridBand4";
            this.gridBand4.VisibleIndex = 1;
            this.gridBand4.Width = 225;
            // 
            // gridColumnCMT
            // 
            this.gridColumnCMT.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnCMT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnCMT.Caption = "Số CMT";
            this.gridColumnCMT.FieldName = "CMT";
            this.gridColumnCMT.Name = "gridColumnCMT";
            this.gridColumnCMT.Visible = true;
            // 
            // gridColumnNgayCap
            // 
            this.gridColumnNgayCap.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnNgayCap.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnNgayCap.Caption = "Ngày cấp";
            this.gridColumnNgayCap.FieldName = "NgayCap";
            this.gridColumnNgayCap.Name = "gridColumnNgayCap";
            this.gridColumnNgayCap.Visible = true;
            // 
            // gridColumnNoiCap
            // 
            this.gridColumnNoiCap.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnNoiCap.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnNoiCap.Caption = "Nơi cấp";
            this.gridColumnNoiCap.FieldName = "NoiCap";
            this.gridColumnNoiCap.Name = "gridColumnNoiCap";
            this.gridColumnNoiCap.Visible = true;
            // 
            // gridBand5
            // 
            this.gridBand5.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridBand5.AppearanceHeader.Options.UseFont = true;
            this.gridBand5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand5.Caption = "THÔNG TIN THÊM";
            this.gridBand5.Columns.Add(this.gridColumnStaffID);
            this.gridBand5.Columns.Add(this.gridColumnStaffCode);
            this.gridBand5.Columns.Add(this.gridColumnDept);
            this.gridBand5.Columns.Add(this.gridColumnPosition);
            this.gridBand5.Name = "gridBand5";
            this.gridBand5.VisibleIndex = 2;
            this.gridBand5.Width = 300;
            // 
            // gridColumnStaffID
            // 
            this.gridColumnStaffID.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnStaffID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnStaffID.Caption = "ID";
            this.gridColumnStaffID.FieldName = "StaffID";
            this.gridColumnStaffID.Name = "gridColumnStaffID";
            this.gridColumnStaffID.Visible = true;
            // 
            // gridColumnStaffCode
            // 
            this.gridColumnStaffCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnStaffCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnStaffCode.Caption = "Code";
            this.gridColumnStaffCode.FieldName = "StaffCode";
            this.gridColumnStaffCode.Name = "gridColumnStaffCode";
            this.gridColumnStaffCode.Visible = true;
            // 
            // gridColumnDept
            // 
            this.gridColumnDept.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnDept.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnDept.Caption = "Bộ phận";
            this.gridColumnDept.FieldName = "Dept";
            this.gridColumnDept.Name = "gridColumnDept";
            this.gridColumnDept.Visible = true;
            // 
            // gridColumnPosition
            // 
            this.gridColumnPosition.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnPosition.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnPosition.Caption = "Vị trí";
            this.gridColumnPosition.FieldName = "Position";
            this.gridColumnPosition.Name = "gridColumnPosition";
            this.gridColumnPosition.Visible = true;
            // 
            // gridBand6
            // 
            this.gridBand6.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridBand6.AppearanceHeader.Options.UseFont = true;
            this.gridBand6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand6.Caption = "LỊCH HẸN";
            this.gridBand6.Columns.Add(this.gridColumnNgayPV);
            this.gridBand6.Columns.Add(this.gridColumnNguoiPV);
            this.gridBand6.Columns.Add(this.gridColumnNgayDiLam);
            this.gridBand6.Name = "gridBand6";
            this.gridBand6.VisibleIndex = 3;
            this.gridBand6.Width = 225;
            // 
            // gridColumnNgayPV
            // 
            this.gridColumnNgayPV.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnNgayPV.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnNgayPV.Caption = "Ngày phỏng vấn";
            this.gridColumnNgayPV.FieldName = "NgayPV";
            this.gridColumnNgayPV.Name = "gridColumnNgayPV";
            this.gridColumnNgayPV.Visible = true;
            // 
            // gridColumnNguoiPV
            // 
            this.gridColumnNguoiPV.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnNguoiPV.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnNguoiPV.Caption = "Người phỏng vấn";
            this.gridColumnNguoiPV.FieldName = "NguoiPV";
            this.gridColumnNguoiPV.Name = "gridColumnNguoiPV";
            this.gridColumnNguoiPV.Visible = true;
            // 
            // gridColumnNgayDiLam
            // 
            this.gridColumnNgayDiLam.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnNgayDiLam.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnNgayDiLam.Caption = "Ngay đi làm";
            this.gridColumnNgayDiLam.FieldName = "NgayDiLam";
            this.gridColumnNgayDiLam.Name = "gridColumnNgayDiLam";
            this.gridColumnNgayDiLam.Visible = true;
            // 
            // gridColumnID
            // 
            this.gridColumnID.Caption = "ID";
            this.gridColumnID.Name = "gridColumnID";
            // 
            // FormTranferData
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 527);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormTranferData";
            this.Text = "Đồng bộ dữ liệu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemSearchControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem btnUpdate;
        private DevExpress.XtraBars.BarButtonItem btnRefesh;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
        private BarButtonItem barButtonItem1;
        private BarButtonItem btnExportExel;
        private DevExpress.XtraEditors.Repository.RepositoryItemSearchControl repositoryItemSearchControl1;
        private BarButtonItem btnPrint;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bandedGridView1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumnSTT;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumnFullName;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumnBirthday;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumnSex;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumnHight;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumnSDT;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumnNS;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumnHKTT;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumnDT;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand4;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumnCMT;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumnNgayCap;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumnNoiCap;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand5;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumnStaffID;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumnStaffCode;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumnDept;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumnPosition;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand6;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumnNgayPV;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumnNguoiPV;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumnNgayDiLam;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumnID;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtSearchDate;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
    }
}