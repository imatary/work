namespace EducationSkills
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
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barButtonItemEmployess = new DevExpress.XtraBars.BarButtonItem();
            this.btnReportSkillMap = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItemUsername = new DevExpress.XtraBars.BarStaticItem();
            this.barButtonItemCheckSolder = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemReportsEye = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemSubjects = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemChangePassword = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItemVersion = new DevExpress.XtraBars.BarStaticItem();
            this.barButtonItemOlympic = new DevExpress.XtraBars.BarButtonItem();
            this.barHeaderItem1 = new DevExpress.XtraBars.BarHeaderItem();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem2 = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem3 = new DevExpress.XtraBars.BarStaticItem();
            this.ribbonPageReport = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup7 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageLists = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup6 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.btnReportCheckEye = new DevExpress.XtraBars.BarButtonItem();
            this.btnReportCheckSolder = new DevExpress.XtraBars.BarButtonItem();
            this.xtraTabControlMain = new DevExpress.XtraTab.XtraTabControl();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlMain)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.barButtonItemEmployess,
            this.btnReportSkillMap,
            this.barStaticItemUsername,
            this.barButtonItemCheckSolder,
            this.barButtonItemReportsEye,
            this.barButtonItemSubjects,
            this.barButtonItemChangePassword,
            this.barStaticItemVersion,
            this.barButtonItemOlympic,
            this.barHeaderItem1,
            this.barStaticItem1,
            this.barStaticItem2,
            this.barStaticItem3});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 22;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPageReport,
            this.ribbonPageLists,
            this.ribbonPage1});
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbonControl1.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.True;
            this.ribbonControl1.ShowDisplayOptionsMenuButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbonControl1.ShowToolbarCustomizeItem = false;
            this.ribbonControl1.Size = new System.Drawing.Size(998, 150);
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
            this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
            // 
            // barButtonItemEmployess
            // 
            this.barButtonItemEmployess.Caption = "Danh sách nhân viên";
            this.barButtonItemEmployess.Id = 5;
            this.barButtonItemEmployess.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItemEmployess.ImageOptions.Image")));
            this.barButtonItemEmployess.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItemEmployess.ImageOptions.LargeImage")));
            this.barButtonItemEmployess.Name = "barButtonItemEmployess";
            this.barButtonItemEmployess.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemEmployess_ItemClick);
            // 
            // btnReportSkillMap
            // 
            this.btnReportSkillMap.Caption = "Báo cáo Skills Map";
            this.btnReportSkillMap.Id = 7;
            this.btnReportSkillMap.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnReportSkillMap.ImageOptions.Image")));
            this.btnReportSkillMap.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnReportSkillMap.ImageOptions.LargeImage")));
            this.btnReportSkillMap.Name = "btnReportSkillMap";
            this.btnReportSkillMap.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnReportSkillMap_ItemClick);
            // 
            // barStaticItemUsername
            // 
            this.barStaticItemUsername.Caption = "guest";
            this.barStaticItemUsername.Id = 9;
            this.barStaticItemUsername.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barStaticItemUsername.ImageOptions.Image")));
            this.barStaticItemUsername.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barStaticItemUsername.ImageOptions.LargeImage")));
            this.barStaticItemUsername.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barStaticItemUsername.ItemAppearance.Normal.Options.UseFont = true;
            this.barStaticItemUsername.Name = "barStaticItemUsername";
            this.barStaticItemUsername.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barButtonItemCheckSolder
            // 
            this.barButtonItemCheckSolder.Caption = "Báo cáo kiểm tra Hàn";
            this.barButtonItemCheckSolder.Id = 10;
            this.barButtonItemCheckSolder.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItemCheckSolder.ImageOptions.Image")));
            this.barButtonItemCheckSolder.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItemCheckSolder.ImageOptions.LargeImage")));
            this.barButtonItemCheckSolder.Name = "barButtonItemCheckSolder";
            this.barButtonItemCheckSolder.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemCheckSolder_ItemClick);
            // 
            // barButtonItemReportsEye
            // 
            this.barButtonItemReportsEye.Caption = "Báo cáo kiểm tra Mắt";
            this.barButtonItemReportsEye.Id = 11;
            this.barButtonItemReportsEye.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItemReportsEye.ImageOptions.Image")));
            this.barButtonItemReportsEye.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItemReportsEye.ImageOptions.LargeImage")));
            this.barButtonItemReportsEye.Name = "barButtonItemReportsEye";
            this.barButtonItemReportsEye.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemReportsEye_ItemClick);
            // 
            // barButtonItemSubjects
            // 
            this.barButtonItemSubjects.Caption = "Danh sách môn học";
            this.barButtonItemSubjects.Id = 12;
            this.barButtonItemSubjects.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItemSubjects.ImageOptions.Image")));
            this.barButtonItemSubjects.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItemSubjects.ImageOptions.LargeImage")));
            this.barButtonItemSubjects.Name = "barButtonItemSubjects";
            this.barButtonItemSubjects.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemSubjects_ItemClick);
            // 
            // barButtonItemChangePassword
            // 
            this.barButtonItemChangePassword.Caption = "Thay đổi mật khẩu đăng nhập";
            this.barButtonItemChangePassword.Id = 13;
            this.barButtonItemChangePassword.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItemChangePassword.ImageOptions.Image")));
            this.barButtonItemChangePassword.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItemChangePassword.ImageOptions.LargeImage")));
            this.barButtonItemChangePassword.Name = "barButtonItemChangePassword";
            // 
            // barStaticItemVersion
            // 
            this.barStaticItemVersion.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barStaticItemVersion.Caption = "0";
            this.barStaticItemVersion.Id = 16;
            this.barStaticItemVersion.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barStaticItemVersion.ImageOptions.Image")));
            this.barStaticItemVersion.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barStaticItemVersion.ImageOptions.LargeImage")));
            this.barStaticItemVersion.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barStaticItemVersion.ItemAppearance.Normal.ForeColor = System.Drawing.Color.White;
            this.barStaticItemVersion.ItemAppearance.Normal.Options.UseFont = true;
            this.barStaticItemVersion.ItemAppearance.Normal.Options.UseForeColor = true;
            this.barStaticItemVersion.Name = "barStaticItemVersion";
            this.barStaticItemVersion.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barButtonItemOlympic
            // 
            this.barButtonItemOlympic.Caption = "Olympic && Meister";
            this.barButtonItemOlympic.Id = 17;
            this.barButtonItemOlympic.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItemOlympic.ImageOptions.Image")));
            this.barButtonItemOlympic.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItemOlympic.ImageOptions.LargeImage")));
            this.barButtonItemOlympic.Name = "barButtonItemOlympic";
            this.barButtonItemOlympic.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemOlympic_ItemClick);
            // 
            // barHeaderItem1
            // 
            this.barHeaderItem1.Caption = "|";
            this.barHeaderItem1.Id = 18;
            this.barHeaderItem1.Name = "barHeaderItem1";
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = "Supports: PE-IT";
            this.barStaticItem1.Id = 19;
            this.barStaticItem1.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barStaticItem1.ItemAppearance.Normal.Options.UseFont = true;
            this.barStaticItem1.Name = "barStaticItem1";
            this.barStaticItem1.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barStaticItem2
            // 
            this.barStaticItem2.Caption = "|";
            this.barStaticItem2.Id = 20;
            this.barStaticItem2.Name = "barStaticItem2";
            this.barStaticItem2.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barStaticItem3
            // 
            this.barStaticItem3.Caption = "by: Phạm Văn Cương";
            this.barStaticItem3.Id = 21;
            this.barStaticItem3.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barStaticItem3.ItemAppearance.Normal.Options.UseFont = true;
            this.barStaticItem3.Name = "barStaticItem3";
            this.barStaticItem3.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // ribbonPageReport
            // 
            this.ribbonPageReport.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup3,
            this.ribbonPageGroup5,
            this.ribbonPageGroup7});
            this.ribbonPageReport.Image = ((System.Drawing.Image)(resources.GetObject("ribbonPageReport.Image")));
            this.ribbonPageReport.Name = "ribbonPageReport";
            this.ribbonPageReport.Text = "Báo cáo";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.Glyph = ((System.Drawing.Image)(resources.GetObject("ribbonPageGroup1.Glyph")));
            this.ribbonPageGroup1.ItemLinks.Add(this.btnReportSkillMap);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.ItemLinks.Add(this.barButtonItemCheckSolder);
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.ShowCaptionButton = false;
            // 
            // ribbonPageGroup5
            // 
            this.ribbonPageGroup5.ItemLinks.Add(this.barButtonItemReportsEye);
            this.ribbonPageGroup5.Name = "ribbonPageGroup5";
            this.ribbonPageGroup5.ShowCaptionButton = false;
            // 
            // ribbonPageGroup7
            // 
            this.ribbonPageGroup7.ItemLinks.Add(this.barButtonItemOlympic);
            this.ribbonPageGroup7.Name = "ribbonPageGroup7";
            this.ribbonPageGroup7.ShowCaptionButton = false;
            // 
            // ribbonPageLists
            // 
            this.ribbonPageLists.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup4,
            this.ribbonPageGroup2});
            this.ribbonPageLists.Image = ((System.Drawing.Image)(resources.GetObject("ribbonPageLists.Image")));
            this.ribbonPageLists.ImageToTextIndent = 2;
            this.ribbonPageLists.Name = "ribbonPageLists";
            this.ribbonPageLists.Text = "Danh sách";
            // 
            // ribbonPageGroup4
            // 
            this.ribbonPageGroup4.ItemLinks.Add(this.barButtonItemEmployess);
            this.ribbonPageGroup4.Name = "ribbonPageGroup4";
            this.ribbonPageGroup4.ShowCaptionButton = false;
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItemSubjects);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.ShowCaptionButton = false;
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup6});
            this.ribbonPage1.Image = ((System.Drawing.Image)(resources.GetObject("ribbonPage1.Image")));
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Cấu hình";
            // 
            // ribbonPageGroup6
            // 
            this.ribbonPageGroup6.ItemLinks.Add(this.barButtonItemChangePassword);
            this.ribbonPageGroup6.Name = "ribbonPageGroup6";
            this.ribbonPageGroup6.ShowCaptionButton = false;
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.ItemLinks.Add(this.barStaticItemUsername);
            this.ribbonStatusBar1.ItemLinks.Add(this.barStaticItemVersion);
            this.ribbonStatusBar1.ItemLinks.Add(this.barHeaderItem1);
            this.ribbonStatusBar1.ItemLinks.Add(this.barStaticItem1);
            this.ribbonStatusBar1.ItemLinks.Add(this.barStaticItem2);
            this.ribbonStatusBar1.ItemLinks.Add(this.barStaticItem3);
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 776);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(998, 23);
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "ribbonPage2";
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2013";
            // 
            // btnReportCheckEye
            // 
            this.btnReportCheckEye.Caption = "Báo cáo kiểm tra mắt";
            this.btnReportCheckEye.Id = 4;
            this.btnReportCheckEye.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnReportCheckEye.ImageOptions.Image")));
            this.btnReportCheckEye.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnReportCheckEye.ImageOptions.LargeImage")));
            this.btnReportCheckEye.Name = "btnReportCheckEye";
            // 
            // btnReportCheckSolder
            // 
            this.btnReportCheckSolder.Caption = "Báo cáo kiểm tra hàn";
            this.btnReportCheckSolder.Id = 3;
            this.btnReportCheckSolder.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnReportCheckSolder.ImageOptions.Image")));
            this.btnReportCheckSolder.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnReportCheckSolder.ImageOptions.LargeImage")));
            this.btnReportCheckSolder.Name = "btnReportCheckSolder";
            // 
            // xtraTabControlMain
            // 
            this.xtraTabControlMain.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InActiveTabPageHeaderAndOnMouseHover;
            this.xtraTabControlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControlMain.HeaderButtons = ((DevExpress.XtraTab.TabButtons)((DevExpress.XtraTab.TabButtons.Prev | DevExpress.XtraTab.TabButtons.Next)));
            this.xtraTabControlMain.HeaderButtonsShowMode = DevExpress.XtraTab.TabButtonShowMode.Always;
            this.xtraTabControlMain.Location = new System.Drawing.Point(0, 150);
            this.xtraTabControlMain.Name = "xtraTabControlMain";
            this.xtraTabControlMain.Size = new System.Drawing.Size(998, 626);
            this.xtraTabControlMain.TabIndex = 2;
            this.xtraTabControlMain.CloseButtonClick += new System.EventHandler(this.xtraTabControlMain_CloseButtonClick);
            this.xtraTabControlMain.MouseLeave += new System.EventHandler(this.xtraTabControlMain_MouseLeave);
            this.xtraTabControlMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.xtraTabControlMain_MouseMove);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 799);
            this.Controls.Add(this.xtraTabControlMain);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Ribbon = this.ribbonControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar1;
            this.Text = "Education Skills";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPageReport;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPageLists;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraBars.BarButtonItem barButtonItemEmployess;
        private DevExpress.XtraBars.BarButtonItem btnReportSkillMap;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.BarStaticItem barStaticItemUsername;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.BarButtonItem btnReportCheckEye;
        private DevExpress.XtraBars.BarButtonItem btnReportCheckSolder;
        private DevExpress.XtraBars.BarButtonItem barButtonItemCheckSolder;
        private DevExpress.XtraBars.BarButtonItem barButtonItemReportsEye;
        private DevExpress.XtraBars.BarButtonItem barButtonItemSubjects;
        private DevExpress.XtraBars.BarButtonItem barButtonItemChangePassword;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup6;
        private DevExpress.XtraBars.BarStaticItem barStaticItemVersion;
        private DevExpress.XtraBars.BarButtonItem barButtonItemOlympic;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup7;
        private DevExpress.XtraTab.XtraTabControl xtraTabControlMain;
        private DevExpress.XtraBars.BarHeaderItem barHeaderItem1;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarStaticItem barStaticItem2;
        private DevExpress.XtraBars.BarStaticItem barStaticItem3;
    }
}