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
            this.barButtonItemKhuVuc = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemCustomer = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemSuppliers = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemClose = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemInfo = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemRole = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemChangePassword = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemSystemLog = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemBackUp = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemRestore = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemStock = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemUnit = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemProductGroup = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemProduct = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemBarcode = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem10 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemDepartment = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemEmployer = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemImport = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemExport = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemInventory = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemReports = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemTransferStock = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemCheckInventory = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemGUI = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemContact = new DevExpress.XtraBars.BarButtonItem();
            this.barHeaderItem1 = new DevExpress.XtraBars.BarHeaderItem();
            this.barHeaderItem2 = new DevExpress.XtraBars.BarHeaderItem();
            this.barSubItem1 = new DevExpress.XtraBars.BarSubItem();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.barItemUserName = new DevExpress.XtraBars.BarStaticItem();
            this.barButtonItemManagers = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemLogOut = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPageSystem = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupSystem = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupSecurity = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupDatabase = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageCategories = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupCategories = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupStock = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupOrganize = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageStock = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupManagerStock = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroupAddOn = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageHelp = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupHelp = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.xtraTabControlMain = new DevExpress.XtraTab.XtraTabControl();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.toastNotificationsManager1 = new DevExpress.XtraBars.ToastNotifications.ToastNotificationsManager(this.components);
            this.timerCheckInventry = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toastNotificationsManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ApplicationIcon = global::Stock.GUI.Properties.Resources.home_obj;
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.barButtonItemKhuVuc,
            this.barButtonItemCustomer,
            this.barButtonItemSuppliers,
            this.barButtonItemClose,
            this.barButtonItemInfo,
            this.barButtonItemRole,
            this.barButtonItemChangePassword,
            this.barButtonItemSystemLog,
            this.barButtonItemBackUp,
            this.barButtonItemRestore,
            this.barButtonItem4,
            this.barButtonItemStock,
            this.barButtonItemUnit,
            this.barButtonItemProductGroup,
            this.barButtonItemProduct,
            this.barButtonItemBarcode,
            this.barButtonItem10,
            this.barButtonItemDepartment,
            this.barButtonItemEmployer,
            this.barButtonItemImport,
            this.barButtonItemExport,
            this.barButtonItemInventory,
            this.barButtonItemReports,
            this.barButtonItemTransferStock,
            this.barButtonItemCheckInventory,
            this.barButtonItemGUI,
            this.barButtonItemContact,
            this.barHeaderItem1,
            this.barHeaderItem2,
            this.barSubItem1,
            this.barStaticItem1,
            this.barItemUserName,
            this.barButtonItemManagers,
            this.barButtonItem1,
            this.barButtonItemLogOut});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 46;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPageSystem,
            this.ribbonPageCategories,
            this.ribbonPageStock,
            this.ribbonPageHelp});
            this.ribbon.Size = new System.Drawing.Size(990, 144);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            this.ribbon.Toolbar.ItemLinks.Add(this.barSubItem1);
            // 
            // barButtonItemKhuVuc
            // 
            this.barButtonItemKhuVuc.Caption = "Khu Vực";
            this.barButtonItemKhuVuc.Id = 1;
            this.barButtonItemKhuVuc.LargeGlyph = global::Stock.GUI.Properties.Resources.Location_Area_Flat_32;
            this.barButtonItemKhuVuc.Name = "barButtonItemKhuVuc";
            this.barButtonItemKhuVuc.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemKhuVuc_ItemClick);
            // 
            // barButtonItemCustomer
            // 
            this.barButtonItemCustomer.Caption = "Khách Hàng";
            this.barButtonItemCustomer.Enabled = false;
            this.barButtonItemCustomer.Id = 2;
            this.barButtonItemCustomer.LargeGlyph = global::Stock.GUI.Properties.Resources.pesmission_32;
            this.barButtonItemCustomer.Name = "barButtonItemCustomer";
            this.barButtonItemCustomer.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barButtonItemCustomer.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemCustomer_ItemClick);
            // 
            // barButtonItemSuppliers
            // 
            this.barButtonItemSuppliers.Caption = "Nhà Phân Phối";
            this.barButtonItemSuppliers.Id = 3;
            this.barButtonItemSuppliers.LargeGlyph = global::Stock.GUI.Properties.Resources.distributor_32;
            this.barButtonItemSuppliers.Name = "barButtonItemSuppliers";
            this.barButtonItemSuppliers.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemSuppliers_ItemClick);
            // 
            // barButtonItemClose
            // 
            this.barButtonItemClose.Caption = "Kết thúc";
            this.barButtonItemClose.Id = 4;
            this.barButtonItemClose.LargeGlyph = global::Stock.GUI.Properties.Resources.exit_32;
            this.barButtonItemClose.Name = "barButtonItemClose";
            this.barButtonItemClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemClose_ItemClick);
            // 
            // barButtonItemInfo
            // 
            this.barButtonItemInfo.Caption = "Thông tin";
            this.barButtonItemInfo.Id = 5;
            this.barButtonItemInfo.LargeGlyph = global::Stock.GUI.Properties.Resources.info_sign_32;
            this.barButtonItemInfo.Name = "barButtonItemInfo";
            this.barButtonItemInfo.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemInfo_ItemClick);
            // 
            // barButtonItemRole
            // 
            this.barButtonItemRole.Caption = "Phân Quyền";
            this.barButtonItemRole.Id = 6;
            this.barButtonItemRole.LargeGlyph = global::Stock.GUI.Properties.Resources.pesmission_system_32;
            this.barButtonItemRole.Name = "barButtonItemRole";
            this.barButtonItemRole.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemRole_ItemClick);
            // 
            // barButtonItemChangePassword
            // 
            this.barButtonItemChangePassword.Caption = "Thay Đổi Mật Khẩu";
            this.barButtonItemChangePassword.Id = 7;
            this.barButtonItemChangePassword.LargeGlyph = global::Stock.GUI.Properties.Resources.login_manager;
            this.barButtonItemChangePassword.Name = "barButtonItemChangePassword";
            this.barButtonItemChangePassword.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemChangePassword_ItemClick);
            // 
            // barButtonItemSystemLog
            // 
            this.barButtonItemSystemLog.Caption = "Nhật Ký Hệ Thống";
            this.barButtonItemSystemLog.Id = 8;
            this.barButtonItemSystemLog.LargeGlyph = global::Stock.GUI.Properties.Resources.sys_log_32;
            this.barButtonItemSystemLog.Name = "barButtonItemSystemLog";
            this.barButtonItemSystemLog.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemSystemLog_ItemClick);
            // 
            // barButtonItemBackUp
            // 
            this.barButtonItemBackUp.Caption = "Sao Lưu CSDL";
            this.barButtonItemBackUp.Id = 9;
            this.barButtonItemBackUp.LargeGlyph = global::Stock.GUI.Properties.Resources.database_save_2_32;
            this.barButtonItemBackUp.Name = "barButtonItemBackUp";
            this.barButtonItemBackUp.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemBackUp_ItemClick);
            // 
            // barButtonItemRestore
            // 
            this.barButtonItemRestore.Caption = "Phục Hồi CSDL";
            this.barButtonItemRestore.Id = 10;
            this.barButtonItemRestore.LargeGlyph = global::Stock.GUI.Properties.Resources.database_refresh;
            this.barButtonItemRestore.Name = "barButtonItemRestore";
            this.barButtonItemRestore.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemRestore_ItemClick);
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "barButtonItem4";
            this.barButtonItem4.Id = 12;
            this.barButtonItem4.Name = "barButtonItem4";
            // 
            // barButtonItemStock
            // 
            this.barButtonItemStock.Caption = "Kho Hàng";
            this.barButtonItemStock.Id = 13;
            this.barButtonItemStock.LargeGlyph = global::Stock.GUI.Properties.Resources.stock_home;
            this.barButtonItemStock.Name = "barButtonItemStock";
            this.barButtonItemStock.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemStock_ItemClick);
            // 
            // barButtonItemUnit
            // 
            this.barButtonItemUnit.Caption = "Đơn Vị Tính";
            this.barButtonItemUnit.Id = 14;
            this.barButtonItemUnit.LargeGlyph = global::Stock.GUI.Properties.Resources.Calculator_32;
            this.barButtonItemUnit.Name = "barButtonItemUnit";
            this.barButtonItemUnit.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemUnit_ItemClick);
            // 
            // barButtonItemProductGroup
            // 
            this.barButtonItemProductGroup.Caption = "Nhóm Hàng";
            this.barButtonItemProductGroup.Id = 15;
            this.barButtonItemProductGroup.LargeGlyph = global::Stock.GUI.Properties.Resources.Product_documentation_32;
            this.barButtonItemProductGroup.Name = "barButtonItemProductGroup";
            this.barButtonItemProductGroup.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemProductGroup_ItemClick);
            // 
            // barButtonItemProduct
            // 
            this.barButtonItemProduct.Caption = "Hàng Hóa";
            this.barButtonItemProduct.Id = 16;
            this.barButtonItemProduct.LargeGlyph = global::Stock.GUI.Properties.Resources.Download_Crate;
            this.barButtonItemProduct.Name = "barButtonItemProduct";
            this.barButtonItemProduct.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemProduct_ItemClick);
            // 
            // barButtonItemBarcode
            // 
            this.barButtonItemBarcode.Caption = "In Mã Vạch";
            this.barButtonItemBarcode.Id = 17;
            this.barButtonItemBarcode.LargeGlyph = global::Stock.GUI.Properties.Resources.Barcode_Scanner_32;
            this.barButtonItemBarcode.Name = "barButtonItemBarcode";
            this.barButtonItemBarcode.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemBarcode_ItemClick);
            // 
            // barButtonItem10
            // 
            this.barButtonItem10.Caption = "barButtonItem10";
            this.barButtonItem10.Id = 18;
            this.barButtonItem10.Name = "barButtonItem10";
            // 
            // barButtonItemDepartment
            // 
            this.barButtonItemDepartment.Caption = "Bộ Phận";
            this.barButtonItemDepartment.Id = 19;
            this.barButtonItemDepartment.LargeGlyph = global::Stock.GUI.Properties.Resources.Manager;
            this.barButtonItemDepartment.Name = "barButtonItemDepartment";
            this.barButtonItemDepartment.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemDepartment_ItemClick);
            // 
            // barButtonItemEmployer
            // 
            this.barButtonItemEmployer.Caption = "Nhân Viên";
            this.barButtonItemEmployer.Id = 20;
            this.barButtonItemEmployer.LargeGlyph = global::Stock.GUI.Properties.Resources.employee_32;
            this.barButtonItemEmployer.Name = "barButtonItemEmployer";
            this.barButtonItemEmployer.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemEmployer_ItemClick);
            // 
            // barButtonItemImport
            // 
            this.barButtonItemImport.Caption = "Nhập Kho";
            this.barButtonItemImport.Id = 21;
            this.barButtonItemImport.LargeGlyph = global::Stock.GUI.Properties.Resources.database_add;
            this.barButtonItemImport.Name = "barButtonItemImport";
            this.barButtonItemImport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemImport_ItemClick);
            // 
            // barButtonItemExport
            // 
            this.barButtonItemExport.Caption = "Xuất Kho";
            this.barButtonItemExport.Id = 22;
            this.barButtonItemExport.LargeGlyph = global::Stock.GUI.Properties.Resources.database_go_32;
            this.barButtonItemExport.Name = "barButtonItemExport";
            this.barButtonItemExport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemExport_ItemClick);
            // 
            // barButtonItemInventory
            // 
            this.barButtonItemInventory.Caption = "Tồn Kho";
            this.barButtonItemInventory.Id = 23;
            this.barButtonItemInventory.LargeGlyph = global::Stock.GUI.Properties.Resources.database_save_2_32;
            this.barButtonItemInventory.Name = "barButtonItemInventory";
            this.barButtonItemInventory.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemInventory_ItemClick);
            // 
            // barButtonItemReports
            // 
            this.barButtonItemReports.Caption = "Báo Cáo";
            this.barButtonItemReports.Id = 24;
            this.barButtonItemReports.LargeGlyph = global::Stock.GUI.Properties.Resources.custom_reports;
            this.barButtonItemReports.Name = "barButtonItemReports";
            this.barButtonItemReports.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemReports_ItemClick);
            // 
            // barButtonItemTransferStock
            // 
            this.barButtonItemTransferStock.Caption = "Chuyển Kho";
            this.barButtonItemTransferStock.Id = 25;
            this.barButtonItemTransferStock.LargeGlyph = global::Stock.GUI.Properties.Resources.database_refresh_32;
            this.barButtonItemTransferStock.Name = "barButtonItemTransferStock";
            this.barButtonItemTransferStock.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemTransferStock_ItemClick);
            // 
            // barButtonItemCheckInventory
            // 
            this.barButtonItemCheckInventory.Caption = "Kiểm Kê";
            this.barButtonItemCheckInventory.Id = 26;
            this.barButtonItemCheckInventory.LargeGlyph = global::Stock.GUI.Properties.Resources.inventory_32;
            this.barButtonItemCheckInventory.Name = "barButtonItemCheckInventory";
            this.barButtonItemCheckInventory.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemCheckInventory_ItemClick);
            // 
            // barButtonItemGUI
            // 
            this.barButtonItemGUI.Caption = "Hướng Dẫn Dử Dụng";
            this.barButtonItemGUI.Id = 27;
            this.barButtonItemGUI.LargeGlyph = global::Stock.GUI.Properties.Resources.Help_book_32;
            this.barButtonItemGUI.Name = "barButtonItemGUI";
            this.barButtonItemGUI.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemGUI_ItemClick);
            // 
            // barButtonItemContact
            // 
            this.barButtonItemContact.Caption = "Liên Hệ";
            this.barButtonItemContact.Id = 28;
            this.barButtonItemContact.LargeGlyph = global::Stock.GUI.Properties.Resources.kontact_summary;
            this.barButtonItemContact.Name = "barButtonItemContact";
            this.barButtonItemContact.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemContact_ItemClick);
            // 
            // barHeaderItem1
            // 
            this.barHeaderItem1.Caption = "Phầm Mềm Quản Lý Kho PMC-AC";
            this.barHeaderItem1.Id = 29;
            this.barHeaderItem1.Name = "barHeaderItem1";
            // 
            // barHeaderItem2
            // 
            this.barHeaderItem2.Caption = "barHeaderItem2";
            this.barHeaderItem2.Id = 32;
            this.barHeaderItem2.Name = "barHeaderItem2";
            // 
            // barSubItem1
            // 
            this.barSubItem1.Caption = "barSubItem1";
            this.barSubItem1.Glyph = global::Stock.GUI.Properties.Resources.emblem_art_color_16;
            this.barSubItem1.Id = 38;
            this.barSubItem1.Name = "barSubItem1";
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = "|";
            this.barStaticItem1.Id = 40;
            this.barStaticItem1.Name = "barStaticItem1";
            this.barStaticItem1.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barItemUserName
            // 
            this.barItemUserName.Caption = "Tên đăng nhập";
            this.barItemUserName.Glyph = global::Stock.GUI.Properties.Resources.Manager;
            this.barItemUserName.Id = 42;
            this.barItemUserName.Name = "barItemUserName";
            this.barItemUserName.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barButtonItemManagers
            // 
            this.barButtonItemManagers.Caption = "Danh Sách Quản Lý";
            this.barButtonItemManagers.Id = 43;
            this.barButtonItemManagers.LargeGlyph = global::Stock.GUI.Properties.Resources.pesmission_32;
            this.barButtonItemManagers.Name = "barButtonItemManagers";
            this.barButtonItemManagers.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemManagers_ItemClick);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Thêm Người Dùng";
            this.barButtonItem1.Id = 44;
            this.barButtonItem1.LargeGlyph = global::Stock.GUI.Properties.Resources.Manager;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // barButtonItemLogOut
            // 
            this.barButtonItemLogOut.Caption = "Đăng Xuất";
            this.barButtonItemLogOut.Id = 45;
            this.barButtonItemLogOut.LargeGlyph = global::Stock.GUI.Properties.Resources.Gnome_Application_Exit_32;
            this.barButtonItemLogOut.Name = "barButtonItemLogOut";
            this.barButtonItemLogOut.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemLogOut_ItemClick);
            // 
            // ribbonPageSystem
            // 
            this.ribbonPageSystem.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroupSystem,
            this.ribbonPageGroupSecurity,
            this.ribbonPageGroupDatabase});
            this.ribbonPageSystem.MergeOrder = 2;
            this.ribbonPageSystem.Name = "ribbonPageSystem";
            this.ribbonPageSystem.Text = "Hệ Thống";
            // 
            // ribbonPageGroupSystem
            // 
            this.ribbonPageGroupSystem.ItemLinks.Add(this.barButtonItemClose);
            this.ribbonPageGroupSystem.ItemLinks.Add(this.barButtonItemLogOut);
            this.ribbonPageGroupSystem.ItemLinks.Add(this.barButtonItemInfo);
            this.ribbonPageGroupSystem.Name = "ribbonPageGroupSystem";
            this.ribbonPageGroupSystem.ShowCaptionButton = false;
            this.ribbonPageGroupSystem.Text = "Quản Lý Hệ Thống";
            // 
            // ribbonPageGroupSecurity
            // 
            this.ribbonPageGroupSecurity.ItemLinks.Add(this.barButtonItemRole);
            this.ribbonPageGroupSecurity.ItemLinks.Add(this.barButtonItemManagers);
            this.ribbonPageGroupSecurity.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroupSecurity.ItemLinks.Add(this.barButtonItemChangePassword);
            this.ribbonPageGroupSecurity.ItemLinks.Add(this.barButtonItemSystemLog);
            this.ribbonPageGroupSecurity.Name = "ribbonPageGroupSecurity";
            this.ribbonPageGroupSecurity.ShowCaptionButton = false;
            this.ribbonPageGroupSecurity.Text = "Bảo Mật";
            // 
            // ribbonPageGroupDatabase
            // 
            this.ribbonPageGroupDatabase.ItemLinks.Add(this.barButtonItemBackUp);
            this.ribbonPageGroupDatabase.ItemLinks.Add(this.barButtonItemRestore);
            this.ribbonPageGroupDatabase.Name = "ribbonPageGroupDatabase";
            this.ribbonPageGroupDatabase.ShowCaptionButton = false;
            this.ribbonPageGroupDatabase.Text = "Dữ Liệu";
            // 
            // ribbonPageCategories
            // 
            this.ribbonPageCategories.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroupCategories,
            this.ribbonPageGroupStock,
            this.ribbonPageGroupOrganize});
            this.ribbonPageCategories.MergeOrder = 1;
            this.ribbonPageCategories.Name = "ribbonPageCategories";
            this.ribbonPageCategories.Text = "Danh Mục";
            // 
            // ribbonPageGroupCategories
            // 
            this.ribbonPageGroupCategories.ItemLinks.Add(this.barButtonItemKhuVuc);
            this.ribbonPageGroupCategories.ItemLinks.Add(this.barButtonItemCustomer);
            this.ribbonPageGroupCategories.ItemLinks.Add(this.barButtonItemSuppliers);
            this.ribbonPageGroupCategories.MergeOrder = 1;
            this.ribbonPageGroupCategories.Name = "ribbonPageGroupCategories";
            this.ribbonPageGroupCategories.ShowCaptionButton = false;
            this.ribbonPageGroupCategories.Text = "Quản Lý Danh Mục";
            // 
            // ribbonPageGroupStock
            // 
            this.ribbonPageGroupStock.ItemLinks.Add(this.barButtonItemStock);
            this.ribbonPageGroupStock.ItemLinks.Add(this.barButtonItemUnit);
            this.ribbonPageGroupStock.ItemLinks.Add(this.barButtonItemProductGroup);
            this.ribbonPageGroupStock.ItemLinks.Add(this.barButtonItemProduct);
            this.ribbonPageGroupStock.ItemLinks.Add(this.barButtonItemBarcode);
            this.ribbonPageGroupStock.Name = "ribbonPageGroupStock";
            this.ribbonPageGroupStock.ShowCaptionButton = false;
            this.ribbonPageGroupStock.Text = "Quản Lý Kho Hàng";
            // 
            // ribbonPageGroupOrganize
            // 
            this.ribbonPageGroupOrganize.ItemLinks.Add(this.barButtonItemDepartment);
            this.ribbonPageGroupOrganize.ItemLinks.Add(this.barButtonItemEmployer);
            this.ribbonPageGroupOrganize.Name = "ribbonPageGroupOrganize";
            this.ribbonPageGroupOrganize.ShowCaptionButton = false;
            this.ribbonPageGroupOrganize.Text = "Tổ Chức";
            // 
            // ribbonPageStock
            // 
            this.ribbonPageStock.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroupManagerStock,
            this.ribbonPageGroupAddOn});
            this.ribbonPageStock.Name = "ribbonPageStock";
            this.ribbonPageStock.Text = "Kho Hàng";
            // 
            // ribbonPageGroupManagerStock
            // 
            this.ribbonPageGroupManagerStock.ItemLinks.Add(this.barButtonItemImport);
            this.ribbonPageGroupManagerStock.ItemLinks.Add(this.barButtonItemExport);
            this.ribbonPageGroupManagerStock.ItemLinks.Add(this.barButtonItemInventory);
            this.ribbonPageGroupManagerStock.ItemLinks.Add(this.barButtonItemReports);
            this.ribbonPageGroupManagerStock.Name = "ribbonPageGroupManagerStock";
            this.ribbonPageGroupManagerStock.ShowCaptionButton = false;
            this.ribbonPageGroupManagerStock.Text = "Quản Lý Kho";
            // 
            // ribbonPageGroupAddOn
            // 
            this.ribbonPageGroupAddOn.ItemLinks.Add(this.barButtonItemTransferStock);
            this.ribbonPageGroupAddOn.ItemLinks.Add(this.barButtonItemCheckInventory);
            this.ribbonPageGroupAddOn.Name = "ribbonPageGroupAddOn";
            this.ribbonPageGroupAddOn.ShowCaptionButton = false;
            this.ribbonPageGroupAddOn.Text = "Tiện Ích";
            // 
            // ribbonPageHelp
            // 
            this.ribbonPageHelp.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroupHelp});
            this.ribbonPageHelp.Name = "ribbonPageHelp";
            this.ribbonPageHelp.Text = "Trợ Giúp";
            // 
            // ribbonPageGroupHelp
            // 
            this.ribbonPageGroupHelp.ItemLinks.Add(this.barButtonItemGUI);
            this.ribbonPageGroupHelp.ItemLinks.Add(this.barButtonItemContact);
            this.ribbonPageGroupHelp.Name = "ribbonPageGroupHelp";
            this.ribbonPageGroupHelp.Text = "Trợ Giúp";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.barHeaderItem1);
            this.ribbonStatusBar.ItemLinks.Add(this.barStaticItem1);
            this.ribbonStatusBar.ItemLinks.Add(this.barItemUserName);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 828);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(990, 31);
            // 
            // xtraTabControlMain
            // 
            this.xtraTabControlMain.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InActiveTabPageAndTabControlHeader;
            this.xtraTabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControlMain.Location = new System.Drawing.Point(0, 144);
            this.xtraTabControlMain.Name = "xtraTabControlMain";
            this.xtraTabControlMain.Padding = new System.Windows.Forms.Padding(0, 15, 0, 0);
            this.xtraTabControlMain.Size = new System.Drawing.Size(990, 684);
            this.xtraTabControlMain.TabIndex = 5;
            this.xtraTabControlMain.CloseButtonClick += new System.EventHandler(this.xtraTabControlMain_CloseButtonClick);
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.TouchUIMode = DevExpress.LookAndFeel.TouchUIMode.False;
            // 
            // toastNotificationsManager1
            // 
            this.toastNotificationsManager1.ApplicationIconPath = "../Resources/favicon.ico";
            this.toastNotificationsManager1.ApplicationId = "3b0f4419-0f8e-4939-a4f1-22fb838f369d";
            this.toastNotificationsManager1.ApplicationName = "Stock.GUI";
            this.toastNotificationsManager1.CreateApplicationShortcut = DevExpress.Utils.DefaultBoolean.True;
            this.toastNotificationsManager1.Activated += new System.EventHandler<DevExpress.XtraBars.ToastNotifications.ToastNotificationEventArgs>(this.toastNotificationsManager1_Activated);
            this.toastNotificationsManager1.TimedOut += new System.EventHandler<DevExpress.XtraBars.ToastNotifications.ToastNotificationEventArgs>(this.toastNotificationsManager1_TimedOut);
            // 
            // timerCheckInventry
            // 
            this.timerCheckInventry.Enabled = true;
            this.timerCheckInventry.Tick += new System.EventHandler(this.timerCheckInventry_Tick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 859);
            this.Controls.Add(this.xtraTabControlMain);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(902, 716);
            this.Name = "FormMain";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "QUẢN LÝ KHO PMC-AC";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toastNotificationsManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPageSystem;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupSystem;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPageCategories;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupCategories;
        private DevExpress.XtraBars.BarButtonItem barButtonItemKhuVuc;
        private DevExpress.XtraTab.XtraTabControl xtraTabControlMain;
        private DevExpress.XtraBars.BarButtonItem barButtonItemCustomer;
        private DevExpress.XtraBars.BarButtonItem barButtonItemSuppliers;
        private DevExpress.XtraBars.BarButtonItem barButtonItemClose;
        private DevExpress.XtraBars.BarButtonItem barButtonItemInfo;
        private DevExpress.XtraBars.BarButtonItem barButtonItemRole;
        private DevExpress.XtraBars.BarButtonItem barButtonItemChangePassword;
        private DevExpress.XtraBars.BarButtonItem barButtonItemSystemLog;
        private DevExpress.XtraBars.BarButtonItem barButtonItemBackUp;
        private DevExpress.XtraBars.BarButtonItem barButtonItemRestore;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupSecurity;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupDatabase;
        private DevExpress.XtraBars.BarButtonItem barButtonItemStock;
        private DevExpress.XtraBars.BarButtonItem barButtonItemUnit;
        private DevExpress.XtraBars.BarButtonItem barButtonItemProductGroup;
        private DevExpress.XtraBars.BarButtonItem barButtonItemProduct;
        private DevExpress.XtraBars.BarButtonItem barButtonItemBarcode;
        private DevExpress.XtraBars.BarButtonItem barButtonItem10;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupStock;
        private DevExpress.XtraBars.BarButtonItem barButtonItemDepartment;
        private DevExpress.XtraBars.BarButtonItem barButtonItemEmployer;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupOrganize;
        private DevExpress.XtraBars.BarButtonItem barButtonItemImport;
        private DevExpress.XtraBars.BarButtonItem barButtonItemExport;
        private DevExpress.XtraBars.BarButtonItem barButtonItemInventory;
        private DevExpress.XtraBars.BarButtonItem barButtonItemReports;
        private DevExpress.XtraBars.BarButtonItem barButtonItemTransferStock;
        private DevExpress.XtraBars.BarButtonItem barButtonItemCheckInventory;
        private DevExpress.XtraBars.BarButtonItem barButtonItemGUI;
        private DevExpress.XtraBars.BarButtonItem barButtonItemContact;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupManagerStock;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupAddOn;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPageHelp;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupHelp;
        private DevExpress.XtraBars.BarHeaderItem barHeaderItem1;
        private DevExpress.XtraBars.BarHeaderItem barHeaderItem2;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraBars.BarSubItem barSubItem1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPageStock;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarStaticItem barItemUserName;
        private DevExpress.XtraBars.BarButtonItem barButtonItemManagers;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItemLogOut;
        private DevExpress.XtraBars.ToastNotifications.ToastNotificationsManager toastNotificationsManager1;
        private System.Windows.Forms.Timer timerCheckInventry;
    }
}