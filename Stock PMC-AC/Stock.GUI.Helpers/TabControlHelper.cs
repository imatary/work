using System.Collections.Generic;

namespace  Stock.GUI.Helpers
{
    public static class TabControlHelper
    {
        /// <summary>
        /// Close current tabpage
        /// </summary>
        /// <param name="parent">Parent control</param>
        public static void CloseCurrentTabPage(System.Windows.Forms.Control parent)
        {
            var tabPage = parent as DevExpress.XtraTab.XtraTabPage;
            if (tabPage != null)
            {
                var tabControl = tabPage.Parent as DevExpress.XtraTab.XtraTabControl;
                if (tabControl != null) 
                    tabControl.TabPages.Remove(tabPage);
            }
        }

        /// <summary>
        /// Close all tabpage
        /// </summary>
        /// <param name="tabControl">Tab control</param>
        public static void CloseAllTabPage(DevExpress.XtraTab.XtraTabControl tabControl)
        {
            var tabPages = new List<DevExpress.XtraTab.XtraTabPage>();

            foreach (DevExpress.XtraTab.XtraTabPage tabPage in tabControl.TabPages)
            {
                tabPages.Add(tabPage);
            }

            foreach (DevExpress.XtraTab.XtraTabPage tabPage in tabPages)
            {
                tabControl.TabPages.Remove(tabPage);
            }
        }
    }
}
