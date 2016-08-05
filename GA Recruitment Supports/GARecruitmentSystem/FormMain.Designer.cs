namespace GARecruitmentSystem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barHeaderItem1 = new DevExpress.XtraBars.BarHeaderItem();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItemInputScore = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItem2 = new DevExpress.XtraBars.BarStaticItem();
            this.barHeaderItemVersion = new DevExpress.XtraBars.BarHeaderItem();
            this.barCurentUser = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem3 = new DevExpress.XtraBars.BarStaticItem();
            this.ribbonPageSystem = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroupSystem = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.xtraTabControlMain = new DevExpress.XtraTab.XtraTabControl();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::GARecruitmentSystem.FormWaiting.WaitFormLoadData), true, true);
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.barButtonItemResultInterview = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlMain)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ApplicationIcon = ((System.Drawing.Bitmap)(resources.GetObject("ribbon.ApplicationIcon")));
            this.ribbon.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ribbon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.barHeaderItem1,
            this.barStaticItem1,
            this.barButtonItem1,
            this.barButtonItemInputScore,
            this.barStaticItem2,
            this.barHeaderItemVersion,
            this.barCurentUser,
            this.barStaticItem3,
            this.barButtonItemResultInterview});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 15;
            this.ribbon.Name = "ribbon";
            this.ribbon.OptionsCustomizationForm.FormIcon = ((System.Drawing.Icon)(resources.GetObject("resource.FormIcon")));
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPageSystem});
            this.ribbon.ShowToolbarCustomizeItem = false;
            this.ribbon.Size = new System.Drawing.Size(916, 143);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            this.ribbon.Toolbar.ShowCustomizeItem = false;
            // 
            // barHeaderItem1
            // 
            this.barHeaderItem1.Caption = "Design by:";
            this.barHeaderItem1.Id = 1;
            this.barHeaderItem1.Name = "barHeaderItem1";
            this.barHeaderItem1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = "cuongpham@umcvn.com";
            this.barStaticItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("barStaticItem1.Glyph")));
            this.barStaticItem1.Id = 2;
            this.barStaticItem1.ItemAppearance.Disabled.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barStaticItem1.ItemAppearance.Disabled.Options.UseFont = true;
            this.barStaticItem1.ItemAppearance.Hovered.Font = new System.Drawing.Font("Tahoma", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barStaticItem1.ItemAppearance.Hovered.Options.UseFont = true;
            this.barStaticItem1.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barStaticItem1.ItemAppearance.Normal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.barStaticItem1.ItemAppearance.Normal.Options.UseFont = true;
            this.barStaticItem1.ItemAppearance.Normal.Options.UseForeColor = true;
            this.barStaticItem1.ItemAppearance.Pressed.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barStaticItem1.ItemAppearance.Pressed.Options.UseFont = true;
            this.barStaticItem1.Name = "barStaticItem1";
            this.barStaticItem1.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Ứng viên";
            this.barButtonItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.Glyph")));
            this.barButtonItem1.Id = 3;
            this.barButtonItem1.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.LargeGlyph")));
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItemInputScore
            // 
            this.barButtonItemInputScore.Caption = "Kết quả phỏng vấn";
            this.barButtonItemInputScore.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItemInputScore.Glyph")));
            this.barButtonItemInputScore.Id = 6;
            this.barButtonItemInputScore.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItemInputScore.LargeGlyph")));
            this.barButtonItemInputScore.Name = "barButtonItemInputScore";
            this.barButtonItemInputScore.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemInputScore_ItemClick);
            // 
            // barStaticItem2
            // 
            this.barStaticItem2.Caption = "| Version:";
            this.barStaticItem2.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.barStaticItem2.Id = 8;
            this.barStaticItem2.Name = "barStaticItem2";
            this.barStaticItem2.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barHeaderItemVersion
            // 
            this.barHeaderItemVersion.Caption = "0";
            this.barHeaderItemVersion.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.barHeaderItemVersion.Id = 9;
            this.barHeaderItemVersion.Name = "barHeaderItemVersion";
            this.barHeaderItemVersion.RibbonStyle = ((DevExpress.XtraBars.Ribbon.RibbonItemStyles)(((DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithText) 
            | DevExpress.XtraBars.Ribbon.RibbonItemStyles.SmallWithoutText)));
            // 
            // barCurentUser
            // 
            this.barCurentUser.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barCurentUser.Caption = "User ";
            this.barCurentUser.Id = 12;
            this.barCurentUser.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.barCurentUser.ItemAppearance.Normal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.barCurentUser.ItemAppearance.Normal.Options.UseFont = true;
            this.barCurentUser.ItemAppearance.Normal.Options.UseForeColor = true;
            this.barCurentUser.Name = "barCurentUser";
            this.barCurentUser.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barStaticItem3
            // 
            this.barStaticItem3.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barStaticItem3.Caption = "Curent User:";
            this.barStaticItem3.Glyph = ((System.Drawing.Image)(resources.GetObject("barStaticItem3.Glyph")));
            this.barStaticItem3.Id = 13;
            this.barStaticItem3.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barStaticItem3.LargeGlyph")));
            this.barStaticItem3.Name = "barStaticItem3";
            this.barStaticItem3.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // ribbonPageSystem
            // 
            this.ribbonPageSystem.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroupSystem,
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
            this.ribbonPageSystem.Name = "ribbonPageSystem";
            this.ribbonPageSystem.Text = "Quản lý thông tin";
            // 
            // ribbonPageGroupSystem
            // 
            this.ribbonPageGroupSystem.AllowTextClipping = false;
            this.ribbonPageGroupSystem.ItemLinks.Add(this.barButtonItem1);
            this.ribbonPageGroupSystem.Name = "ribbonPageGroupSystem";
            this.ribbonPageGroupSystem.ShowCaptionButton = false;
            this.ribbonPageGroupSystem.Text = "Ứng viên";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.AllowTextClipping = false;
            this.ribbonPageGroup1.ItemLinks.Add(this.barButtonItemInputScore);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.ShowCaptionButton = false;
            this.ribbonPageGroup1.Text = "Kết quả phỏng vấn";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.barHeaderItem1);
            this.ribbonStatusBar.ItemLinks.Add(this.barStaticItem1);
            this.ribbonStatusBar.ItemLinks.Add(this.barStaticItem2);
            this.ribbonStatusBar.ItemLinks.Add(this.barHeaderItemVersion);
            this.ribbonStatusBar.ItemLinks.Add(this.barStaticItem3);
            this.ribbonStatusBar.ItemLinks.Add(this.barCurentUser);
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
            this.xtraTabControlMain.CloseButtonClick += new System.EventHandler(this.xtraTabControlMain_CloseButtonClick);
            this.xtraTabControlMain.Click += new System.EventHandler(this.xtraTabControlMain_Click);
            // 
            // splashScreenManager1
            // 
            this.splashScreenManager1.ClosingDelay = 500;
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.AllowTextClipping = false;
            this.ribbonPageGroup2.ItemLinks.Add(this.barButtonItemResultInterview);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.ShowCaptionButton = false;
            this.ribbonPageGroup2.Text = "Lịch phỏng vấn & Kết quả phỏng vấn";
            // 
            // barButtonItemResultInterview
            // 
            this.barButtonItemResultInterview.Caption = "Lịch phỏng vấn Kết quả phỏng vấn";
            this.barButtonItemResultInterview.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItemResultInterview.Glyph")));
            this.barButtonItemResultInterview.Id = 14;
            this.barButtonItemResultInterview.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItemResultInterview.LargeGlyph")));
            this.barButtonItemResultInterview.Name = "barButtonItemResultInterview";
            this.barButtonItemResultInterview.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemResultInterview_ItemClick);
            // 
            // FormMain
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 639);
            this.Controls.Add(this.xtraTabControlMain);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(926, 640);
            this.Name = "FormMain";
            this.Ribbon = this.ribbon;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Quản lý thông tin tuyển dụng - GA";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControlMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPageSystem;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroupSystem;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarHeaderItem barHeaderItem1;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItemInputScore;
        private DevExpress.XtraTab.XtraTabControl xtraTabControlMain;
        private DevExpress.XtraBars.BarStaticItem barStaticItem2;
        private DevExpress.XtraBars.BarHeaderItem barHeaderItemVersion;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        private DevExpress.XtraBars.BarStaticItem barCurentUser;
        private DevExpress.XtraBars.BarStaticItem barStaticItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItemResultInterview;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
    }
}