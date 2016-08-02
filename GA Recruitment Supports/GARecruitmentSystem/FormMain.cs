using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using Lib.Core.Helpers;

namespace GARecruitmentSystem
{
    public partial class FormMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FormMain()
        {
            InitializeComponent();
            barHeaderItemVersion.Caption = StringHelper.GetRunningVersion();
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

        private void barButtonItemInputScore_ItemClick(object sender, ItemClickEventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            var scores = new FormScores();
            OpenForm(scores, xtraTabControlMain);
            splashScreenManager1.CloseWaitForm();
        }

        private void xtraTabControlMain_Click(object sender, EventArgs e)
        {

        }
    }
}