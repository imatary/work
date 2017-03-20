using DevExpress.XtraBars.Docking2010.Views.WindowsUI;
using DevExpress.XtraEditors;
using DevExpress.XtraTab;
using DevExpress.XtraTab.ViewInfo;
using EducationSkills.Modules;
using System;
using System.Collections.Generic;
using System.Drawing;
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

        public void AddTabPage(object userControl, string text, ActionType tabPageType, Bitmap smallimage)
        {
            try
            {
                var formShow = ((UserControl)userControl);
                XtraTabPage tabPage = new XtraTabPage();
                tabPage.Text = text;
                tabPage.Name = formShow.Name;

                tabPage.Tag = tabPageType;
                if (smallimage != null)
                    tabPage.Image = smallimage;

                formShow.Dock = DockStyle.Fill;
                tabPage.Controls.Add(formShow);

                var check = xtraTabControlMain.TabPages.SingleOrDefault(f => f.Name == formShow.Name);

                if (check == null)
                {
                    xtraTabControlMain.TabPages.Add(tabPage);
                }
                else
                {
                    xtraTabControlMain.SelectedTabPage = check;
                    return;
                }
                xtraTabControlMain.TabPages.Add(tabPage);
                xtraTabControlMain.SelectedTabPage = tabPage;
                xtraTabControlMain.SelectedTabPage.AutoScroll = true;

            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
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
            AddTabPage(new UserControlSkillMap(), "Báo cáo Skills Map", ActionType.Default, null);
        }

        private void barButtonItemCheckSolder_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddTabPage(new UserControlReportsSolder(), "Báo cáo kiểm tra Hàn", ActionType.Default, null);
        }
        private void barButtonItemReportsEye_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddTabPage(new UserControlReportsEye(), "Báo cáo kiểm tra Mắt", ActionType.Default, null);
        }
        private void barButtonItemOlympic_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }

        private void barButtonItemSubjects_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddTabPage(new UserControlSubjects(), "Môn học", ActionType.Default, null);
        }

        private void barButtonItemEmployess_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            AddTabPage(new UserControlEmployees(), "Danh sách Nhân viên", ActionType.Default, null);
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
