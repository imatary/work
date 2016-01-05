using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using Stock.GUI.Forms;
using Stock.GUI.Helper;
using Stock.GUI.Properties;
using Stock.Services;

namespace Stock.GUI
{
    public partial class FormMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        private readonly ItemService _itemService;
        public FormMain()
        {
            InitializeComponent();
            _itemService = new ItemService();
        }

        public void SetVisibleRibbonByUserName(string userName)
        {
            if (Program.CurrentUser.IsAdmin == true)
            {
                SetVisibleRibbon(true);
            }
            else
            {
                SetVisibleRibbon(false);

                for (int page = 0; page < ribbon.Pages.Count; page++)
                {
                    for (int group = 0; group < ribbon.Pages[page].Groups.Count; group++)
                    {
                        for (int itemLink = 0; itemLink < ribbon.Pages[page].Groups[group].ItemLinks.Count; itemLink++)
                        {
                            string pageName = ribbon.Pages[page].Name;
                            string pageGroupName = ribbon.Pages[page].Groups[group].Name;
                            string controlName = ribbon.Pages[page].Groups[group].ItemLinks[itemLink].Item.Name;

                            foreach (var item in _itemService.GetItemsByUserName(userName))
                            {
                                if (pageName == item.PageID)
                                {
                                    ribbon.Pages[page].Visible = true;
                                    if (pageGroupName == item.PageGroup)
                                    {
                                        ribbon.Pages[page].Groups[group].Visible = true;

                                        if (controlName == item.ItemID)
                                        {
                                            ribbon.Pages[page].Groups[group].ItemLinks[itemLink].Visible = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        public void SetVisibleRibbon(bool enable)
        {
            for (int i = 0; i < ribbon.Pages.Count; i++)  // duyêt tất cả page trên menu
            {
                //var page = new Page()
                //{
                //    PageID = ribbon.Pages[i].Name,
                //    PageName = ribbon.Pages[i].Text,
                //    Position = i,
                //    Visible = ribbon.Pages[i].Visible,
                //};
                //try
                //{
                //    if (_pageService.CheckPageIdExit(page.PageID))
                //    {
                //        _pageService.Add(page);
                //    }
                //}
                //catch (Exception ex)
                //{
                //    XtraMessageBox.Show(ex.Message);
                //}
                ribbon.Pages[i].Visible = enable; // cho ẩn tất cả
                for (int j = 0; j < ribbon.Pages[i].Groups.Count; j++)  // duyet trong group
                {
                    ribbon.Pages[i].Groups[j].Visible = enable; // cho tat cac cac group ẩn hết
                    for (int k = 0; k < ribbon.Pages[i].Groups[j].ItemLinks.Count; k++) // duyet tat ca cac Item trong group
                    {
                        ribbon.Pages[i].Groups[j].ItemLinks[k].Visible = enable;  // cho ẩn tất cả item

                        //var itemInPage = new Item()
                        //{
                        //    ItemID = ribbon.Pages[i].Groups[j].ItemLinks[k].Item.Name,
                        //    ItemName = ribbon.Pages[i].Groups[j].ItemLinks[k].Item.Caption,
                        //    Position = k,
                        //    Visible = ribbon.Pages[i].Groups[j].ItemLinks[k].Visible,
                        //    PageID = ribbon.Pages[i].Name,
                        //    PageGroup = ribbon.Pages[i].Groups[j].Name,
                        //};

                        //try
                        //{
                        //    if (_itemService.CheckItemIdExit(itemInPage.ItemID))
                        //    {
                        //        _itemService.Add(itemInPage);
                        //    }
                            
                        //}
                        //catch (Exception ex)
                        //{
                        //    XtraMessageBox.Show(ex.Message);
                        //}
                    }
                }

            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            SetVisibleRibbonByUserName(Program.CurrentUser.Username);
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
        public static void CloseCurrentForm(Control parent)
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
            DialogResult result = MessageBox.Show(Resources.MessageBoxColseForm, Resources.MessageBoxTitle, buttons, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void bbiUnit_ItemClick(object sender, ItemClickEventArgs e)
        {
            splashScreenOpenForm.ShowWaitForm();
            var unit = new FormUnits();
            OpenForm(unit, xtraTabControlMain);
            splashScreenOpenForm.CloseWaitForm();
        }

        private void bbiStock_ItemClick(object sender, ItemClickEventArgs e)
        {
            splashScreenOpenForm.ShowWaitForm();
            var stock = new FormStocks();
            OpenForm(stock, xtraTabControlMain);
            splashScreenOpenForm.CloseWaitForm();
        }

        private void bbiProductGroups_ItemClick(object sender, ItemClickEventArgs e)
        {
            splashScreenOpenForm.ShowWaitForm();
            var productGroup = new FormProductGroups();
            OpenForm(productGroup, xtraTabControlMain);
            splashScreenOpenForm.CloseWaitForm();
        }

        /// <summary>
        /// Đăng xuất
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbiLogOut_ItemClick(object sender, ItemClickEventArgs e)
        {
            Program.CurrentUser = null;
            if (Program.CurrentUser == null)
            {
                var login = new FormLogin();
                Dispose();
                login.ShowDialog();
            }
            else
            {
                MessageBoxHelper.ShowMessageBoxError("Lỗi khi đăng xuất tài khoản");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void xtraTabControlMain_CloseButtonClick_1(object sender, EventArgs e)
        {
            var arg = e as DevExpress.XtraTab.ViewInfo.ClosePageButtonEventArgs;
            if (arg != null)
            {
                var xtraTabPage = arg.Page as DevExpress.XtraTab.XtraTabPage;
                if (xtraTabPage != null)
                    xtraTabPage.Dispose();
            }
        }

        /// <summary>
        /// Department
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbiDepartment_ItemClick(object sender, ItemClickEventArgs e)
        {
            splashScreenOpenForm.ShowWaitForm();
            var department = new FormDepartments();
            OpenForm(department, xtraTabControlMain);
            splashScreenOpenForm.CloseWaitForm();
        }

        /// <summary>
        /// Products
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbiProducts_ItemClick(object sender, ItemClickEventArgs e)
        {
            splashScreenOpenForm.ShowWaitForm();
            var product = new FormProducts();
            OpenForm(product, xtraTabControlMain);
            splashScreenOpenForm.CloseWaitForm();
        }

        /// <summary>
        /// Receipt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbiReceiptManager_ItemClick(object sender, ItemClickEventArgs e)
        {
            splashScreenOpenForm.ShowWaitForm();
            var receipt = new FormReceipt();
            OpenForm(receipt, xtraTabControlMain);
            splashScreenOpenForm.CloseWaitForm();
        }


        /// <summary>
        /// Issue
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbiIssueManager_ItemClick(object sender, ItemClickEventArgs e)
        {
            splashScreenOpenForm.ShowWaitForm();
            var issue = new FormIssue();
            OpenForm(issue, xtraTabControlMain);
            splashScreenOpenForm.CloseWaitForm();
        }

        private void bbiReportManager_ItemClick(object sender, ItemClickEventArgs e)
        {
            splashScreenOpenForm.ShowWaitForm();
            var reports = new FormReports();
            OpenForm(reports, xtraTabControlMain);
            splashScreenOpenForm.CloseWaitForm();
        }
    }
}