using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraBars.ToastNotifications;
using DevExpress.XtraEditors;
using Stock.Data;
using Stock.GUI.Helpers;
using Stock.GUI.Partners;
using Stock.GUI.Properties;
using Stock.GUI.Reports;
using Stock.GUI.Sys;
using Stock.GUI.Warehouse;
using Stock.Services;

namespace Stock.GUI
{
    public partial class FormMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly WaitDialogFormHelper _waitDialog = new WaitDialogFormHelper();
        private readonly InventoryService _inventoryService;
        public FormMain()
        {
            InitializeComponent();
            _inventoryService = new InventoryService();
            GetCurrentEmployeeName();
            //AddMessageForNotifications();
        }

        private void GetCurrentEmployeeName()
        {
            if (Program.CurrentUser != null)
            {
                string employeeId = Program.CurrentUser.EmployeeID;
                using (var context=new StockACEntities())
                {
                    var employee = context.Employees.FirstOrDefault(e => e.EmployeeID == employeeId);
                    if (employee != null)
                    {
                        barItemUserName.Caption = employee.EmployeeName;
                    }
                } 
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            foreach (DevExpress.Skins.SkinContainer skin in DevExpress.Skins.SkinManager.Default.Skins)
            {
                BarCheckItem item = ribbon.Items.CreateCheckItem(skin.SkinName, false);
                item.Tag = skin.SkinName;
                item.ItemClick += OnPaintStyleClick;
                barSubItem1.ItemLinks.Add(item);
                DevExpress.LookAndFeel.UserLookAndFeel.Default.SkinName = "DevExpress Style";
            }
        }

        #region TabControl
        /// <summary>
        /// 
        /// </summary>
        /// <param name="frm"></param>
        /// <param name="xTabControl"></param>
        private void OpenForm(XtraForm frm, DevExpress.XtraTab.XtraTabControl xTabControl)
        {
            foreach (DevExpress.XtraTab.XtraTabPage tab in xtraTabControlMain.TabPages)
            {
                if (tab.Text == frm.Text)
                {
                    xtraTabControlMain.SelectedTabPage = tab;
                    return;
                }
            }

            var xTabPage = new DevExpress.XtraTab.XtraTabPage { Text = frm.Text };
            xTabControl.TabPages.Add(xTabPage);
            xTabControl.SelectedTabPage = xTabPage;
            frm.WindowState = FormWindowState.Maximized;
            frm.FormBorderStyle = FormBorderStyle.None;
            frm.TopLevel = false;
            frm.Parent = xTabPage;
            frm.Show();
            frm.Dock = DockStyle.Fill;
        }

        /// <summary>
        /// 
        /// </summary>
        private void CloseAllForm()
        {
            var collection = new List<DevExpress.XtraTab.XtraTabPage>();

            foreach (DevExpress.XtraTab.XtraTabPage tab in xtraTabControlMain.TabPages)
            {
                collection.Add(tab);
            }

            foreach (DevExpress.XtraTab.XtraTabPage tab in collection)
            {
                xtraTabControlMain.TabPages.Remove(tab);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent"></param>
        public static void CloseCurrentForm(System.Windows.Forms.Control parent)
        {
            var tabPage = parent as DevExpress.XtraTab.XtraTabPage;
            if (tabPage != null)
            {
                var tabControl = tabPage.Parent as DevExpress.XtraTab.XtraTabControl;
                if (tabControl != null)
                    tabControl.TabPages.Remove(tabPage);
            }
        }

        private void xtraTabControlMain_CloseButtonClick(object sender, EventArgs e)
        {
            //var tabControl = sender as DevExpress.XtraTab.XtraTabControl;
            var arg = e as DevExpress.XtraTab.ViewInfo.ClosePageButtonEventArgs;
            if (arg != null)
            {
                var xtraTabPage = arg.Page as DevExpress.XtraTab.XtraTabPage;
                if (xtraTabPage != null)
                    xtraTabPage.Dispose();
            }
        }
        #endregion

        #region Theme

        void OnPaintStyleClick(object sender, ItemClickEventArgs e)
        {
            defaultLookAndFeel1.LookAndFeel.SetSkinStyle(e.Item.Tag.ToString());
            SaveSkin(e.Item.Tag.ToString());
        }
        public void SaveSkin(string name)
        {
            Configuration configuration = ConfigurationManager.OpenExeConfiguration("SettingSkin.config");
            if (!File.Exists("SettingSkin.config"))
            {
                configuration.AppSettings.Settings.Add("Skin", name);
                configuration.Save();
            }
            else
            {
                //configuration.AppSettings.Settings["Skin"].Value = name;
                configuration.Save();
            }
        }
        #endregion
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            const MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result = MessageBox.Show(Resources.MessageEdit, Resources.MessageBoxTitleHelper, buttons, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.ExitThread();
        }

        /// <summary>
        /// Khu Vực
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemKhuVuc_ItemClick(object sender, ItemClickEventArgs e)
        {
            _waitDialog.CreateWaitDialog();
            _waitDialog.SetWaitDialogCaption("Chương trình đang tải dữ liệu. Vui lòng chờ...");
            var area=new FormArea();
            OpenForm(area, xtraTabControlMain);
            _waitDialog.CloseWait();
        }

        /// <summary>
        /// Khách Hàng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemCustomer_ItemClick(object sender, ItemClickEventArgs e)
        {
            //_waitDialog.CreateWaitDialog();
            //_waitDialog.SetWaitDialogCaption("Chương trình đang tải dữ liệu.\n Vui lòng chờ trong giây lát!"); 
            //var customer=new FormCustomer();
            //OpenForm(customer, xtraTabControlMain);
            //_waitDialog.CloseWait();
            XtraMessageBox.Show("Chức năng đang phát triển", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Nhà Cung Cấp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemSuppliers_ItemClick(object sender, ItemClickEventArgs e)
        {
            _waitDialog.CreateWaitDialog();
            _waitDialog.SetWaitDialogCaption("Chương trình đang tải dữ liệu. Vui lòng chờ...");
            var suppliers = new FormSuppliers();
            OpenForm(suppliers, xtraTabControlMain);
            _waitDialog.CloseWait();
        }

        /// <summary>
        /// Đơn Vị
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemUnit_ItemClick(object sender, ItemClickEventArgs e)
        {
            _waitDialog.CreateWaitDialog();
            _waitDialog.SetWaitDialogCaption("Chương trình đang tải dữ liệu. Vui lòng chờ...");
            var unit = new FormUnit();
            OpenForm(unit, xtraTabControlMain);
            _waitDialog.CloseWait();
        }

        /// <summary>
        /// Nhóm Hàng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemProductGroup_ItemClick(object sender, ItemClickEventArgs e)
        {
            _waitDialog.CreateWaitDialog();
            _waitDialog.SetWaitDialogCaption("Chương trình đang tải dữ liệu. Vui lòng chờ...");
            var productGroup = new FormProductGroup();
            OpenForm(productGroup, xtraTabControlMain);
            _waitDialog.CloseWait();
        }

        /// <summary>
        /// Bộ Phận
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemDepartment_ItemClick(object sender, ItemClickEventArgs e)
        {
            _waitDialog.CreateWaitDialog();
            _waitDialog.SetWaitDialogCaption("Chương trình đang tải dữ liệu. Vui lòng chờ...");
            var department = new FormDepartments();
            OpenForm(department, xtraTabControlMain);
            _waitDialog.CloseWait();
        }

        /// <summary>
        /// Nhân Viên
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemEmployer_ItemClick(object sender, ItemClickEventArgs e)
        {
            _waitDialog.CreateWaitDialog();
            _waitDialog.SetWaitDialogCaption("Chương trình đang tải dữ liệu. Vui lòng chờ...");
            var employee = new FormEmployees();
            OpenForm(employee, xtraTabControlMain);
            _waitDialog.CloseWait();
        }

        /// <summary>
        /// Kho Hàng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemStock_ItemClick(object sender, ItemClickEventArgs e)
        {
            _waitDialog.CreateWaitDialog();
            _waitDialog.SetWaitDialogCaption("Chương trình đang tải dữ liệu. Vui lòng chờ...");
            var stock = new FormStock();
            OpenForm(stock, xtraTabControlMain);
            _waitDialog.CloseWait();
        }

        private void barButtonItemProduct_ItemClick(object sender, ItemClickEventArgs e)
        {
            _waitDialog.CreateWaitDialog();
            _waitDialog.SetWaitDialogCaption("Chương trình đang tải dữ liệu. Vui lòng chờ...");
            var product = new FormProduct();
            OpenForm(product, xtraTabControlMain);
            _waitDialog.CloseWait();
        }

        /// <summary>
        /// Nhập Hàng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemImport_ItemClick(object sender, ItemClickEventArgs e)
        {
            _waitDialog.CreateWaitDialog();
            _waitDialog.SetWaitDialogCaption("Chương trình đang tải dữ liệu. Vui lòng chờ...");
            var stockImport = new FormStockImport();
            OpenForm(stockImport, xtraTabControlMain);
            _waitDialog.CloseWait();
        }

        /// <summary>
        /// Xuất Kho
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemExport_ItemClick(object sender, ItemClickEventArgs e)
        {
            _waitDialog.CreateWaitDialog();
            _waitDialog.SetWaitDialogCaption("Chương trình đang tải dữ liệu. Vui lòng chờ...");
            var stockExport = new FormStockExport();
            OpenForm(stockExport, xtraTabControlMain);
            _waitDialog.CloseWait();
        }

        /// <summary>
        /// Tồn Kho
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemInventory_ItemClick(object sender, ItemClickEventArgs e)
        {
            _waitDialog.CreateWaitDialog();
            _waitDialog.SetWaitDialogCaption("Chương trình đang tải dữ liệu. Vui lòng chờ...");
            var inventory = new FormInventory();
            OpenForm(inventory, xtraTabControlMain);
            _waitDialog.CloseWait();
        }

        /// <summary>
        /// Báo Cáo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemReports_ItemClick(object sender, ItemClickEventArgs e)
        {
            _waitDialog.CreateWaitDialog();
            _waitDialog.SetWaitDialogCaption("Chương trình đang tải dữ liệu. Vui lòng chờ...");
            var reports = new FormReports();
            OpenForm(reports, xtraTabControlMain);
            _waitDialog.CloseWait();
        }

        /// <summary>
        /// Nhật ký hệ thống
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemSystemLog_ItemClick(object sender, ItemClickEventArgs e)
        {
            _waitDialog.CreateWaitDialog();
            _waitDialog.SetWaitDialogCaption("Chương trình đang tải dữ liệu. Vui lòng chờ...");
            var sysLog = new FormSysLog();
            OpenForm(sysLog, xtraTabControlMain);
            _waitDialog.CloseWait();
        }

        /// <summary>
        /// Thay đổi mật khẩu đăng nhập
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemChangePassword_ItemClick(object sender, ItemClickEventArgs e)
        {
            var changePassword = new FormChangePassword();
            changePassword.ShowDialog();
        }

        /// <summary>
        /// Thoát
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Sao lưu CSDL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemBackUp_ItemClick(object sender, ItemClickEventArgs e)
        {
            var backUp = new FormBackupDatabase();
            backUp.ShowDialog();
        }

        /// <summary>
        /// Phục hồi CSDL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemRestore_ItemClick(object sender, ItemClickEventArgs e)
        {
            var restore = new FormRestoreDatabase();
            restore.ShowDialog();
        }

        /// <summary>
        /// danh sách quản lý
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemManagers_ItemClick(object sender, ItemClickEventArgs e)
        {
            _waitDialog.CreateWaitDialog();
            _waitDialog.SetWaitDialogCaption("Chương trình đang tải dữ liệu. Vui lòng chờ...");
            var managers = new FormManagers();
            OpenForm(managers, xtraTabControlMain);
            _waitDialog.CloseWait();
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            var add = new FormAddUserLogin();
            add.ShowDialog();
        }

        /// <summary>
        /// Đăng Xuất
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemLogOut_ItemClick(object sender, ItemClickEventArgs e)
        {
            Program.CurrentUser = null;
            if (Program.CurrentUser == null)
            {
                var login = new FormLogin();
                Hide();
                login.ShowDialog();
                //FormMain_FormClosing(sender, null);
            }
            else
            {
                XtraMessageBox.Show("Lỗi khi đăng xuất tài khoản", "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        /// <summary>
        /// Thông Tin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemInfo_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraMessageBox.Show("Chúng tôi đang phát triển chức năng này!", "Thông Báo", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            barButtonItemInfo.Enabled = false;
        }

        /// <summary>
        /// Quyền
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemRole_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraMessageBox.Show("Chúng tôi đang phát triển chức năng này!", "Thông Báo", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            barButtonItemRole.Enabled = false;
            //ShowControlsForm show=new ShowControlsForm(this);
            //show.Show();
        }

        /// <summary>
        /// In mã vạch
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemBarcode_ItemClick(object sender, ItemClickEventArgs e)
        {
            //XtraMessageBox.Show("Chúng tôi đang phát triển chức năng này!", "Thông Báo", MessageBoxButtons.OK,
            //    MessageBoxIcon.Information);
            //barButtonItemBarcode.Enabled = false;
            _waitDialog.CreateWaitDialog();
            _waitDialog.SetWaitDialogCaption("Chương trình đang tải dữ liệu. Vui lòng chờ...");
            var barcode = new FormBarcode();
            OpenForm(barcode, xtraTabControlMain);
            _waitDialog.CloseWait();
        }

        /// <summary>
        /// Chuyển Kho
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemTransferStock_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraMessageBox.Show("Chúng tôi đang phát triển chức năng này!", "Thông Báo", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            barButtonItemTransferStock.Enabled = false;
        }

        /// <summary>
        /// Kiểm Kê
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemCheckInventory_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraMessageBox.Show("Chúng tôi đang phát triển chức năng này!", "Thông Báo", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            barButtonItemCheckInventory.Enabled = false;
        }

        /// <summary>
        /// Hướng dẫn sử dụng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemGUI_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraMessageBox.Show("Chúng tôi đang phát triển chức năng này!", "Thông Báo", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            barButtonItemGUI.Enabled = false;
        }

        /// <summary>
        /// Liên Hệ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemContact_ItemClick(object sender, ItemClickEventArgs e)
        {
            XtraMessageBox.Show("Chúng tôi đang phát triển chức năng này!", "Thông Báo", MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            barButtonItemContact.Enabled = false;
        }

        /// <summary>
        /// Notify
        /// </summary>
        private void AddMessageForNotifications()
        {
            var inventories = _inventoryService.GetQuantityInventories();
            foreach (var inventory in inventories)
            {
                var toastNotification = new ToastNotification
                {
                    ID = inventory.ProductID,
                    Header = inventory.ProductID,
                    Body = "Sản phẩm: "+inventory.ProductID,     
                    Body2 = "Tồn số lượng là: " + inventory.QuantityInventory,
                    Template = ToastNotificationTemplate.ImageAndText04,
                    //Image = Resources.umc,
                    Duration = ToastNotificationDuration.Default,
                    Sound = ToastNotificationSound.SMS
                };
                toastNotificationsManager1.Notifications.Add(toastNotification);
                toastNotificationsManager1.ShowNotification(toastNotification);
            }
            
            
        }

        private void toastNotificationsManager1_TimedOut(object sender, ToastNotificationEventArgs e)
        {
            toastNotificationsManager1.ShowNotification(e.NotificationID);
        }

        private void toastNotificationsManager1_Activated(object sender, ToastNotificationEventArgs e)
        {

        }

        private void timerCheckInventry_Tick(object sender, EventArgs e)
        {
            AddMessageForNotifications();
        }
    }
}