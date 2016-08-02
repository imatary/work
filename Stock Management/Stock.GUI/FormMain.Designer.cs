namespace Stock.GUI
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.backstageViewControl1 = new DevExpress.XtraBars.Ribbon.BackstageViewControl();
            this.backstageViewClientControl1 = new DevExpress.XtraBars.Ribbon.BackstageViewClientControl();
            this.backstageViewTabItem1 = new DevExpress.XtraBars.Ribbon.BackstageViewTabItem();
            this.bbiLogOut = new DevExpress.XtraBars.BarButtonItem();
            this.bbiExit = new DevExpress.XtraBars.BarButtonItem();
            this.bbiUsers = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSetPermission = new DevExpress.XtraBars.BarButtonItem();
            this.bbiListPermission = new DevExpress.XtraBars.BarButtonItem();
            this.bbiChangePassword = new DevExpress.XtraBars.BarButtonItem();
            this.bbiConfigDatabase = new DevExpress.XtraBars.BarButtonItem();
            this.bbiBackupDatabase = new DevExpress.XtraBars.BarButtonItem();
            this.bbiRestoreDatabase = new DevExpress.XtraBars.BarButtonItem();
            this.bbiSystemHistory = new DevExpress.XtraBars.BarButtonItem();
            this.bbiStock = new DevExpress.XtraBars.BarButtonItem();
            this.bbiUnit = new DevExpress.XtraBars.BarButtonItem();
            this.bbiProductGroups = new DevExpress.XtraBars.BarButtonItem();
            this.bbiProducts = new DevExpress.XtraBars.BarButtonItem();
            this.bbiBarcodePrint = new DevExpress.XtraBars.BarButtonItem();
            this.bbiDepartment = new DevExpress.XtraBars.BarButtonItem();
            this.bbiReceiptManager = new DevExpress.XtraBars.BarButtonItem();
            this.bbiIssueManager = new DevExpress.XtraBars.BarButtonItem();
            this.bbiInventoryStock = new DevExpress.XtraBars.BarButtonItem();
            this.bbiReportManager = new DevExpress.XtraBars.BarButtonItem();
            this.bbiTranferStock = new DevExpress.XtraBars.BarButtonItem();
            this.bbiInventoryManager = new DevExpress.XtraBars.BarButtonItem();
            this.bbiHelp = new DevExpress.XtraBars.BarButtonItem();
            this.bbiInfo = new DevExpress.XtraBars.BarButtonItem();
            this.PageSystem = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.PageGroupSystem = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.PageGroupSystemSecurity = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.PageGroupDatabase = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.PageCategory = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.PageGroupStockCategory = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.PageGroupOrganize = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.PageStock = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.PageGroupStockManager = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.PageGroupAddOns = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.PageHelp = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.PageGroupHelp = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.xtraTabControlMain = new DevExpress.XtraTab.XtraTabControl();
            this.splashScreenOpenForm = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::Stock.GUI.WaitFormData), true, true);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backstageViewControl1)).BeginInit();
            this.backstageViewControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlMain)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ApplicationButtonDropDownControl = this.xtraTabControlMain;
            this.ribbon.ApplicationIcon = ((System.Drawing.Bitmap)(resources.GetObject("ribbon.ApplicationIcon")));
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.bbiLogOut,
            this.bbiExit,
            this.bbiUsers,
            this.bbiSetPermission,
            this.bbiListPermission,
            this.bbiChangePassword,
            this.bbiConfigDatabase,
            this.bbiBackupDatabase,
            this.bbiRestoreDatabase,
            this.bbiSystemHistory,
            this.bbiStock,
            this.bbiUnit,
            this.bbiProductGroups,
            this.bbiProducts,
            this.bbiBarcodePrint,
            this.bbiDepartment,
            this.bbiReceiptManager,
            this.bbiIssueManager,
            this.bbiInventoryStock,
            this.bbiReportManager,
            this.bbiTranferStock,
            this.bbiInventoryManager,
            this.bbiHelp,
            this.bbiInfo});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 26;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.PageSystem,
            this.PageCategory,
            this.PageStock,
            this.PageHelp});
            this.ribbon.Size = new System.Drawing.Size(916, 143);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            // 
            // backstageViewControl1
            // 
            this.backstageViewControl1.ColorScheme = DevExpress.XtraBars.Ribbon.RibbonControlColorScheme.Yellow;
            this.backstageViewControl1.Controls.Add(this.backstageViewClientControl1);
            this.backstageViewControl1.Items.Add(this.backstageViewTabItem1);
            this.backstageViewControl1.Location = new System.Drawing.Point(72, 216);
            this.backstageViewControl1.Name = "backstageViewControl1";
            this.backstageViewControl1.SelectedTab = null;
            this.backstageViewControl1.Size = new System.Drawing.Size(480, 150);
            this.backstageViewControl1.TabIndex = 5;
            // 
            // backstageViewClientControl1
            // 
            this.backstageViewClientControl1.Location = new System.Drawing.Point(188, 0);
            this.backstageViewClientControl1.Name = "backstageViewClientControl1";
            this.backstageViewClientControl1.Size = new System.Drawing.Size(292, 150);
            this.backstageViewClientControl1.TabIndex = 0;
            // 
            // backstageViewTabItem1
            // 
            this.backstageViewTabItem1.Caption = "backstageViewTabItem1";
            this.backstageViewTabItem1.ContentControl = this.backstageViewClientControl1;
            this.backstageViewTabItem1.Name = "backstageViewTabItem1";
            this.backstageViewTabItem1.Selected = false;
            // 
            // bbiLogOut
            // 
            this.bbiLogOut.Caption = "Đăng Nhập Lại";
            this.bbiLogOut.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiLogOut.Glyph")));
            this.bbiLogOut.Id = 1;
            this.bbiLogOut.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiLogOut.LargeGlyph")));
            this.bbiLogOut.Name = "bbiLogOut";
            this.bbiLogOut.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            this.bbiLogOut.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiLogOut_ItemClick);
            // 
            // bbiExit
            // 
            this.bbiExit.Caption = "Thoát";
            this.bbiExit.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiExit.Glyph")));
            this.bbiExit.Id = 2;
            this.bbiExit.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiExit.LargeGlyph")));
            this.bbiExit.Name = "bbiExit";
            this.bbiExit.Tag = "SystemExit";
            this.bbiExit.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // bbiUsers
            // 
            this.bbiUsers.Caption = "Người Dùng";
            this.bbiUsers.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiUsers.Glyph")));
            this.bbiUsers.Id = 3;
            this.bbiUsers.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiUsers.LargeGlyph")));
            this.bbiUsers.Name = "bbiUsers";
            this.bbiUsers.Tag = "SystemUsers";
            this.bbiUsers.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiUsers_ItemClick);
            // 
            // bbiSetPermission
            // 
            this.bbiSetPermission.Caption = "Phân Quyền";
            this.bbiSetPermission.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiSetPermission.Glyph")));
            this.bbiSetPermission.Id = 4;
            this.bbiSetPermission.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiSetPermission.LargeGlyph")));
            this.bbiSetPermission.Name = "bbiSetPermission";
            this.bbiSetPermission.Tag = "SystemSetPermission";
            // 
            // bbiListPermission
            // 
            this.bbiListPermission.Caption = "Danh Sách Quyền";
            this.bbiListPermission.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiListPermission.Glyph")));
            this.bbiListPermission.Id = 5;
            this.bbiListPermission.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiListPermission.LargeGlyph")));
            this.bbiListPermission.Name = "bbiListPermission";
            this.bbiListPermission.Tag = "SystemListPermission";
            // 
            // bbiChangePassword
            // 
            this.bbiChangePassword.Caption = "Thay Đổi Mật Khẩu";
            this.bbiChangePassword.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiChangePassword.Glyph")));
            this.bbiChangePassword.Id = 6;
            this.bbiChangePassword.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiChangePassword.LargeGlyph")));
            this.bbiChangePassword.Name = "bbiChangePassword";
            this.bbiChangePassword.Tag = "SystemChangePassword";
            // 
            // bbiConfigDatabase
            // 
            this.bbiConfigDatabase.Caption = "Cấu Hình Kết Nối";
            this.bbiConfigDatabase.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiConfigDatabase.Glyph")));
            this.bbiConfigDatabase.Id = 7;
            this.bbiConfigDatabase.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiConfigDatabase.LargeGlyph")));
            this.bbiConfigDatabase.Name = "bbiConfigDatabase";
            this.bbiConfigDatabase.Tag = "SystemConfigDatabase";
            // 
            // bbiBackupDatabase
            // 
            this.bbiBackupDatabase.Caption = "Sao Lưu CSDL";
            this.bbiBackupDatabase.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiBackupDatabase.Glyph")));
            this.bbiBackupDatabase.Id = 8;
            this.bbiBackupDatabase.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiBackupDatabase.LargeGlyph")));
            this.bbiBackupDatabase.Name = "bbiBackupDatabase";
            this.bbiBackupDatabase.Tag = "SystemBackupDatabase";
            // 
            // bbiRestoreDatabase
            // 
            this.bbiRestoreDatabase.Caption = "Phục Hồi CSDL";
            this.bbiRestoreDatabase.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiRestoreDatabase.Glyph")));
            this.bbiRestoreDatabase.Id = 9;
            this.bbiRestoreDatabase.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiRestoreDatabase.LargeGlyph")));
            this.bbiRestoreDatabase.Name = "bbiRestoreDatabase";
            this.bbiRestoreDatabase.Tag = "SystemRestoreDatabase";
            // 
            // bbiSystemHistory
            // 
            this.bbiSystemHistory.Caption = "Nhật Ký Hệ Thống";
            this.bbiSystemHistory.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiSystemHistory.Glyph")));
            this.bbiSystemHistory.Id = 10;
            this.bbiSystemHistory.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiSystemHistory.LargeGlyph")));
            this.bbiSystemHistory.Name = "bbiSystemHistory";
            this.bbiSystemHistory.Tag = "SystemHistory";
            // 
            // bbiStock
            // 
            this.bbiStock.Caption = "Kho Hàng";
            this.bbiStock.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiStock.Glyph")));
            this.bbiStock.Id = 11;
            this.bbiStock.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiStock.LargeGlyph")));
            this.bbiStock.Name = "bbiStock";
            this.bbiStock.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiStock_ItemClick);
            // 
            // bbiUnit
            // 
            this.bbiUnit.Caption = "Đơn Vị Tính";
            this.bbiUnit.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiUnit.Glyph")));
            this.bbiUnit.Id = 12;
            this.bbiUnit.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiUnit.LargeGlyph")));
            this.bbiUnit.Name = "bbiUnit";
            this.bbiUnit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiUnit_ItemClick);
            // 
            // bbiProductGroups
            // 
            this.bbiProductGroups.Caption = "Nhóm Hàng";
            this.bbiProductGroups.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiProductGroups.Glyph")));
            this.bbiProductGroups.Id = 13;
            this.bbiProductGroups.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiProductGroups.LargeGlyph")));
            this.bbiProductGroups.Name = "bbiProductGroups";
            this.bbiProductGroups.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiProductGroups_ItemClick);
            // 
            // bbiProducts
            // 
            this.bbiProducts.Caption = "Hàng Hóa";
            this.bbiProducts.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiProducts.Glyph")));
            this.bbiProducts.Id = 14;
            this.bbiProducts.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiProducts.LargeGlyph")));
            this.bbiProducts.Name = "bbiProducts";
            this.bbiProducts.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiProducts_ItemClick);
            // 
            // bbiBarcodePrint
            // 
            this.bbiBarcodePrint.Caption = "In Mã Vạch";
            this.bbiBarcodePrint.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiBarcodePrint.Glyph")));
            this.bbiBarcodePrint.Id = 15;
            this.bbiBarcodePrint.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiBarcodePrint.LargeGlyph")));
            this.bbiBarcodePrint.Name = "bbiBarcodePrint";
            // 
            // bbiDepartment
            // 
            this.bbiDepartment.Caption = "Bộ Phận";
            this.bbiDepartment.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiDepartment.Glyph")));
            this.bbiDepartment.Id = 17;
            this.bbiDepartment.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiDepartment.LargeGlyph")));
            this.bbiDepartment.LargeWidth = 80;
            this.bbiDepartment.Name = "bbiDepartment";
            this.bbiDepartment.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiDepartment_ItemClick);
            // 
            // bbiReceiptManager
            // 
            this.bbiReceiptManager.Caption = "Nhập Kho";
            this.bbiReceiptManager.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiReceiptManager.Glyph")));
            this.bbiReceiptManager.Id = 18;
            this.bbiReceiptManager.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiReceiptManager.LargeGlyph")));
            this.bbiReceiptManager.Name = "bbiReceiptManager";
            this.bbiReceiptManager.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiReceiptManager_ItemClick);
            // 
            // bbiIssueManager
            // 
            this.bbiIssueManager.Caption = "Xuất Kho";
            this.bbiIssueManager.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiIssueManager.Glyph")));
            this.bbiIssueManager.Id = 19;
            this.bbiIssueManager.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiIssueManager.LargeGlyph")));
            this.bbiIssueManager.Name = "bbiIssueManager";
            this.bbiIssueManager.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiIssueManager_ItemClick);
            // 
            // bbiInventoryStock
            // 
            this.bbiInventoryStock.Caption = "Tồn Kho";
            this.bbiInventoryStock.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiInventoryStock.Glyph")));
            this.bbiInventoryStock.Id = 20;
            this.bbiInventoryStock.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiInventoryStock.LargeGlyph")));
            this.bbiInventoryStock.Name = "bbiInventoryStock";
            // 
            // bbiReportManager
            // 
            this.bbiReportManager.Caption = "Báo Cáo";
            this.bbiReportManager.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiReportManager.Glyph")));
            this.bbiReportManager.Id = 21;
            this.bbiReportManager.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiReportManager.LargeGlyph")));
            this.bbiReportManager.Name = "bbiReportManager";
            this.bbiReportManager.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.bbiReportManager_ItemClick);
            // 
            // bbiTranferStock
            // 
            this.bbiTranferStock.Caption = "Chuyển Kho";
            this.bbiTranferStock.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiTranferStock.Glyph")));
            this.bbiTranferStock.Id = 22;
            this.bbiTranferStock.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiTranferStock.LargeGlyph")));
            this.bbiTranferStock.Name = "bbiTranferStock";
            // 
            // bbiInventoryManager
            // 
            this.bbiInventoryManager.Caption = "Kiểm Kê";
            this.bbiInventoryManager.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiInventoryManager.Glyph")));
            this.bbiInventoryManager.Id = 23;
            this.bbiInventoryManager.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiInventoryManager.LargeGlyph")));
            this.bbiInventoryManager.Name = "bbiInventoryManager";
            // 
            // bbiHelp
            // 
            this.bbiHelp.Caption = "Trợ Giúp";
            this.bbiHelp.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiHelp.Glyph")));
            this.bbiHelp.Id = 24;
            this.bbiHelp.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiHelp.LargeGlyph")));
            this.bbiHelp.Name = "bbiHelp";
            // 
            // bbiInfo
            // 
            this.bbiInfo.Caption = "Thông Tin";
            this.bbiInfo.Glyph = ((System.Drawing.Image)(resources.GetObject("bbiInfo.Glyph")));
            this.bbiInfo.Id = 25;
            this.bbiInfo.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("bbiInfo.LargeGlyph")));
            this.bbiInfo.Name = "bbiInfo";
            // 
            // PageSystem
            // 
            this.PageSystem.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.PageGroupSystem,
            this.PageGroupSystemSecurity,
            this.PageGroupDatabase});
            this.PageSystem.Name = "PageSystem";
            this.PageSystem.Tag = "P_System";
            this.PageSystem.Text = "Hệ Thống";
            // 
            // PageGroupSystem
            // 
            this.PageGroupSystem.ItemLinks.Add(this.bbiExit);
            this.PageGroupSystem.ItemLinks.Add(this.bbiLogOut);
            this.PageGroupSystem.ItemLinks.Add(this.bbiSystemHistory);
            this.PageGroupSystem.Name = "PageGroupSystem";
            this.PageGroupSystem.Tag = "PG_System";
            this.PageGroupSystem.Text = "Quản Lý Hệ Thống";
            // 
            // PageGroupSystemSecurity
            // 
            this.PageGroupSystemSecurity.ItemLinks.Add(this.bbiUsers);
            this.PageGroupSystemSecurity.ItemLinks.Add(this.bbiChangePassword);
            this.PageGroupSystemSecurity.ItemLinks.Add(this.bbiSetPermission);
            this.PageGroupSystemSecurity.ItemLinks.Add(this.bbiListPermission);
            this.PageGroupSystemSecurity.Name = "PageGroupSystemSecurity";
            this.PageGroupSystemSecurity.Tag = "PG_Security";
            this.PageGroupSystemSecurity.Text = "Bảo Mật";
            // 
            // PageGroupDatabase
            // 
            this.PageGroupDatabase.ItemLinks.Add(this.bbiConfigDatabase);
            this.PageGroupDatabase.ItemLinks.Add(this.bbiBackupDatabase);
            this.PageGroupDatabase.ItemLinks.Add(this.bbiRestoreDatabase);
            this.PageGroupDatabase.Name = "PageGroupDatabase";
            this.PageGroupDatabase.Tag = "PG_Database";
            this.PageGroupDatabase.Text = "Dữ Liệu";
            // 
            // PageCategory
            // 
            this.PageCategory.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.PageGroupStockCategory,
            this.PageGroupOrganize});
            this.PageCategory.Name = "PageCategory";
            this.PageCategory.Tag = "P_Category";
            this.PageCategory.Text = "Danh Mục";
            // 
            // PageGroupStockCategory
            // 
            this.PageGroupStockCategory.ItemLinks.Add(this.bbiStock);
            this.PageGroupStockCategory.ItemLinks.Add(this.bbiUnit);
            this.PageGroupStockCategory.ItemLinks.Add(this.bbiProductGroups);
            this.PageGroupStockCategory.ItemLinks.Add(this.bbiProducts);
            this.PageGroupStockCategory.ItemLinks.Add(this.bbiBarcodePrint);
            this.PageGroupStockCategory.Name = "PageGroupStockCategory";
            this.PageGroupStockCategory.Text = "Quản Lý Kho Hàng";
            // 
            // PageGroupOrganize
            // 
            this.PageGroupOrganize.ItemLinks.Add(this.bbiDepartment);
            this.PageGroupOrganize.Name = "PageGroupOrganize";
            this.PageGroupOrganize.Text = "Tổ Chức";
            // 
            // PageStock
            // 
            this.PageStock.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.PageGroupStockManager,
            this.PageGroupAddOns});
            this.PageStock.Name = "PageStock";
            this.PageStock.Tag = "P_Stock";
            this.PageStock.Text = "Kho Hàng";
            // 
            // PageGroupStockManager
            // 
            this.PageGroupStockManager.ItemLinks.Add(this.bbiReceiptManager);
            this.PageGroupStockManager.ItemLinks.Add(this.bbiIssueManager);
            this.PageGroupStockManager.ItemLinks.Add(this.bbiInventoryStock);
            this.PageGroupStockManager.ItemLinks.Add(this.bbiReportManager);
            this.PageGroupStockManager.Name = "PageGroupStockManager";
            this.PageGroupStockManager.Text = "Quản Lý Kho Hàng";
            // 
            // PageGroupAddOns
            // 
            this.PageGroupAddOns.ItemLinks.Add(this.bbiTranferStock);
            this.PageGroupAddOns.ItemLinks.Add(this.bbiInventoryManager);
            this.PageGroupAddOns.Name = "PageGroupAddOns";
            this.PageGroupAddOns.Text = "Tiện Ích";
            // 
            // PageHelp
            // 
            this.PageHelp.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.PageGroupHelp});
            this.PageHelp.Name = "PageHelp";
            this.PageHelp.Tag = "P_Help";
            this.PageHelp.Text = "Trợ Giúp";
            // 
            // PageGroupHelp
            // 
            this.PageGroupHelp.ItemLinks.Add(this.bbiHelp);
            this.PageGroupHelp.ItemLinks.Add(this.bbiInfo);
            this.PageGroupHelp.Name = "PageGroupHelp";
            this.PageGroupHelp.Text = "Hướng Dẫn";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 608);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(916, 31);
            // 
            // xtraTabControlMain
            // 
            this.xtraTabControlMain.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InActiveTabPageAndTabControlHeader;
            this.xtraTabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControlMain.Location = new System.Drawing.Point(0, 143);
            this.xtraTabControlMain.Name = "xtraTabControlMain";
            this.xtraTabControlMain.Size = new System.Drawing.Size(916, 465);
            this.xtraTabControlMain.TabIndex = 2;
            this.xtraTabControlMain.CloseButtonClick += new System.EventHandler(this.xtraTabControlMain_CloseButtonClick_1);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 639);
            this.Controls.Add(this.xtraTabControlMain);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.backstageViewControl1);
            this.Controls.Add(this.ribbon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Quản Lý Kho";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backstageViewControl1)).EndInit();
            this.backstageViewControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage PageSystem;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup PageGroupSystem;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.Ribbon.RibbonPage PageCategory;
        private DevExpress.XtraBars.Ribbon.RibbonPage PageStock;
        private DevExpress.XtraBars.BarButtonItem bbiLogOut;
        private DevExpress.XtraBars.BarButtonItem bbiExit;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup PageGroupSystemSecurity;
        private DevExpress.XtraBars.BarButtonItem bbiUsers;
        private DevExpress.XtraBars.BarButtonItem bbiSetPermission;
        private DevExpress.XtraBars.BarButtonItem bbiListPermission;
        private DevExpress.XtraBars.BarButtonItem bbiChangePassword;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup PageGroupDatabase;
        private DevExpress.XtraBars.BarButtonItem bbiConfigDatabase;
        private DevExpress.XtraBars.BarButtonItem bbiBackupDatabase;
        private DevExpress.XtraBars.BarButtonItem bbiRestoreDatabase;
        private DevExpress.XtraBars.Ribbon.RibbonPage PageHelp;
        private DevExpress.XtraBars.BarButtonItem bbiSystemHistory;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup PageGroupStockCategory;
        private DevExpress.XtraBars.BarButtonItem bbiStock;
        private DevExpress.XtraBars.BarButtonItem bbiUnit;
        private DevExpress.XtraBars.BarButtonItem bbiProductGroups;
        private DevExpress.XtraBars.BarButtonItem bbiProducts;
        private DevExpress.XtraBars.BarButtonItem bbiBarcodePrint;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup PageGroupOrganize;
        private DevExpress.XtraBars.BarButtonItem bbiDepartment;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup PageGroupStockManager;
        private DevExpress.XtraBars.BarButtonItem bbiReceiptManager;
        private DevExpress.XtraBars.BarButtonItem bbiIssueManager;
        private DevExpress.XtraBars.BarButtonItem bbiInventoryStock;
        private DevExpress.XtraBars.BarButtonItem bbiReportManager;
        private DevExpress.XtraBars.BarButtonItem bbiTranferStock;
        private DevExpress.XtraBars.BarButtonItem bbiInventoryManager;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup PageGroupAddOns;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraTab.XtraTabControl xtraTabControlMain;
        private DevExpress.XtraBars.Ribbon.BackstageViewControl backstageViewControl1;
        private DevExpress.XtraBars.Ribbon.BackstageViewClientControl backstageViewClientControl1;
        private DevExpress.XtraBars.Ribbon.BackstageViewTabItem backstageViewTabItem1;
        private DevExpress.XtraBars.BarButtonItem bbiHelp;
        private DevExpress.XtraBars.BarButtonItem bbiInfo;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup PageGroupHelp;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenOpenForm;
    }
}