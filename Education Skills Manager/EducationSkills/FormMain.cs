using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using DevExpress.XtraTab.ViewInfo;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace EducationSkills
{
    public partial class FormMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FormMain()
        {
            InitializeComponent();
            barStaticItemUsername.Caption = Program.CurrentUser.UserName;
            barStaticItemVersion.Caption = StringHelper.GetRunningVersion();
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                dynamic mboxResult = MessageBox.Show("Bạn có thực sự muốn đóng hay không?",
                    @"THÔNG BÁO",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);
                if (mboxResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else if (mboxResult == DialogResult.Yes)
                {
                    e.Cancel = false;
                    Application.ExitThread();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="frm"></param>
        /// <param name="xTabControl"></param>
        private void OpenForm(XtraForm frm, XtraTabControl xTabControl)
        {
            foreach (XtraTabPage page in xtraTabControlMain.TabPages)
            {
                if (page.Text == frm.Text)
                {
                    xtraTabControlMain.SelectedTabPage = page;
                    return;
                }
            }
            XtraTabPage page2 = new XtraTabPage
            {
                Text = frm.Text,
            };

            xTabControl.TabPages.Add(page2);
            xTabControl.SelectedTabPage = page2;
            frm.WindowState = FormWindowState.Maximized;
            //frm.FormBorderStyle = FormBorderStyle.None;
            frm.Dock = DockStyle.Fill;
            frm.TopLevel = false;
            frm.Parent = page2;
            frm.Show();
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parent"></param>
        public static void CloseCurrentForm(XtraTabControl parent)
        {
            //if (parent.TabPages.Any())
            //{

            //}
            //    XtraTabControl control = page.Parent as XtraTabControl;
            //    if (control != null)
            //    {
            //        control.TabPages.Remove(page);
            //    }
            
        }

        /// <summary>
        /// 
        /// </summary>
        private void CloseAllForm()
        {
            foreach (XtraTabPage page in xtraTabControlMain.TabPages.ToList())
            {
                this.xtraTabControlMain.TabPages.Remove(page);
            }
        }

        private void btnReportSkillMap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(new FormReportSkillMap(), this.xtraTabControlMain);
        }

        private void barButtonItemCheckSolder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(new FormReportSolder(), this.xtraTabControlMain);
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(new FormReportEye(), this.xtraTabControlMain);
        }

        private void barButtonItemOlympic_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(new FormOlympic(), this.xtraTabControlMain);
        }

        private void barButtonItemSubjects_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(new FormSubjects(), this.xtraTabControlMain);
        }

        private void barButtonItemEmployess_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenForm(new FormEmployess(), this.xtraTabControlMain);
        }

        private void xtraTabControlMain_CloseButtonClick(object sender, System.EventArgs e)
        {
            //CloseAllForm();
            CloseCurrentForm(this.xtraTabControlMain);
        }

        private void xtraTabControlMain_MouseMove(object sender, MouseEventArgs e)
        {
            //XtraTabControl tabControl = sender as XtraTabControl;
            //if (tabControl.TabPages.Any())
            //{
            //    XtraTabHitInfo hitInfo = tabControl.CalcHitInfo(e.Location);
            //    if (hitInfo.HitTest == XtraTabHitTest.PageHeader && hitInfo.Page == tabControl.SelectedTabPage)
            //    {
            //        tabControl.SelectedTabPage.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;
            //    }
            //    else
            //    {
            //        tabControl.SelectedTabPage.ShowCloseButton = DevExpress.Utils.DefaultBoolean.False;
            //    }
            //}  
        }

        private void xtraTabControlMain_MouseLeave(object sender, System.EventArgs e)
        {
            //if (xtraTabControlMain.TabPages.Any())
            //{
            //    xtraTabControlMain.SelectedTabPage.ShowCloseButton = DevExpress.Utils.DefaultBoolean.False;
            //} 
        }
    }
}
