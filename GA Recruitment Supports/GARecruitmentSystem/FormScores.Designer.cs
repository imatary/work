namespace GARecruitmentSystem
{
    partial class FormScores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormScores));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barButtonItemAddScores = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.bandedGridView1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.gridColumnFullName = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumnBirthday = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumnPI_SumPear = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumnPI_SumEven = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumnPII_SumEven = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumnPII_SumPear = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumnTotalPear = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumnEven = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumnPercent = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumnDifference = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumnKetQua = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumnScorePicture = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumnPercentPicture = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumnKetQuaPicture = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumnScoreEye = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridColumnKetQuaEye = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand4 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand5 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand6 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar2});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItemAddScores,
            this.barButtonItem2});
            this.barManager1.MainMenu = this.bar2;
            this.barManager1.MaxItemId = 3;
            // 
            // bar2
            // 
            this.bar2.BarAppearance.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.bar2.BarAppearance.Normal.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.bar2.BarAppearance.Normal.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.bar2.BarAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 8.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bar2.BarAppearance.Normal.Options.UseBackColor = true;
            this.bar2.BarAppearance.Normal.Options.UseBorderColor = true;
            this.bar2.BarAppearance.Normal.Options.UseFont = true;
            this.bar2.BarName = "Main menu";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 0;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItemAddScores, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph),
            new DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, this.barButtonItem2, "", true, true, true, 0, null, DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph)});
            this.bar2.OptionsBar.MinHeight = 36;
            this.bar2.OptionsBar.UseWholeRow = true;
            this.bar2.Text = "Main menu";
            // 
            // barButtonItemAddScores
            // 
            this.barButtonItemAddScores.Caption = "Thêm";
            this.barButtonItemAddScores.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItemAddScores.Glyph")));
            this.barButtonItemAddScores.Id = 0;
            this.barButtonItemAddScores.ImageUri.Uri = "Add";
            this.barButtonItemAddScores.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.barButtonItemAddScores.ItemAppearance.Normal.Options.UseFont = true;
            this.barButtonItemAddScores.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItemAddScores.LargeGlyph")));
            this.barButtonItemAddScores.Name = "barButtonItemAddScores";
            this.barButtonItemAddScores.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItemAddScores_ItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Sửa";
            this.barButtonItem2.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.Glyph")));
            this.barButtonItem2.Id = 2;
            this.barButtonItem2.ItemAppearance.Normal.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.barButtonItem2.ItemAppearance.Normal.Options.UseFont = true;
            this.barButtonItem2.LargeGlyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.LargeGlyph")));
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Size = new System.Drawing.Size(969, 36);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 527);
            this.barDockControlBottom.Size = new System.Drawing.Size(969, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 36);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 491);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(969, 36);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 491);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 36);
            this.gridControl1.MainView = this.bandedGridView1;
            this.gridControl1.MenuManager = this.barManager1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(969, 491);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.UseEmbeddedNavigator = true;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.bandedGridView1});
            // 
            // bandedGridView1
            // 
            this.bandedGridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1,
            this.gridBand3,
            this.gridBand2,
            this.gridBand4,
            this.gridBand5,
            this.gridBand6});
            this.bandedGridView1.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.gridColumnFullName,
            this.gridColumnBirthday,
            this.gridColumnPI_SumPear,
            this.gridColumnPI_SumEven,
            this.gridColumnPII_SumPear,
            this.gridColumnPII_SumEven,
            this.gridColumnTotalPear,
            this.gridColumnEven,
            this.gridColumnPercent,
            this.gridColumnDifference,
            this.gridColumnKetQua,
            this.gridColumnScorePicture,
            this.gridColumnPercentPicture,
            this.gridColumnKetQuaPicture,
            this.gridColumnScoreEye,
            this.gridColumnKetQuaEye});
            this.bandedGridView1.GridControl = this.gridControl1;
            this.bandedGridView1.Name = "bandedGridView1";
            this.bandedGridView1.OptionsFind.AlwaysVisible = true;
            this.bandedGridView1.OptionsFind.FindDelay = 10000;
            this.bandedGridView1.OptionsFind.FindNullPrompt = "Nhập vào từ khóa cần tìm...";
            this.bandedGridView1.OptionsFind.ShowClearButton = false;
            this.bandedGridView1.OptionsFind.ShowFindButton = false;
            // 
            // gridColumnFullName
            // 
            this.gridColumnFullName.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnFullName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnFullName.Caption = "Họ & Tên";
            this.gridColumnFullName.FieldName = "FullName";
            this.gridColumnFullName.Name = "gridColumnFullName";
            this.gridColumnFullName.Visible = true;
            this.gridColumnFullName.Width = 151;
            // 
            // gridColumnBirthday
            // 
            this.gridColumnBirthday.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnBirthday.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnBirthday.Caption = "Ngày sinh";
            this.gridColumnBirthday.FieldName = "Birthday";
            this.gridColumnBirthday.Name = "gridColumnBirthday";
            this.gridColumnBirthday.Visible = true;
            this.gridColumnBirthday.Width = 83;
            // 
            // gridColumnPI_SumPear
            // 
            this.gridColumnPI_SumPear.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnPI_SumPear.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnPI_SumPear.Caption = "Kết quả 1";
            this.gridColumnPI_SumPear.FieldName = "PI_SumPear";
            this.gridColumnPI_SumPear.Name = "gridColumnPI_SumPear";
            this.gridColumnPI_SumPear.Visible = true;
            this.gridColumnPI_SumPear.Width = 63;
            // 
            // gridColumnPI_SumEven
            // 
            this.gridColumnPI_SumEven.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnPI_SumEven.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnPI_SumEven.Caption = "Kết quả 2";
            this.gridColumnPI_SumEven.FieldName = "PI_SumEven";
            this.gridColumnPI_SumEven.Name = "gridColumnPI_SumEven";
            this.gridColumnPI_SumEven.Visible = true;
            this.gridColumnPI_SumEven.Width = 76;
            // 
            // gridColumnPII_SumEven
            // 
            this.gridColumnPII_SumEven.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnPII_SumEven.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnPII_SumEven.Caption = "Kết quả 2";
            this.gridColumnPII_SumEven.FieldName = "PII_SumEven";
            this.gridColumnPII_SumEven.Name = "gridColumnPII_SumEven";
            this.gridColumnPII_SumEven.Visible = true;
            this.gridColumnPII_SumEven.Width = 73;
            // 
            // gridColumnPII_SumPear
            // 
            this.gridColumnPII_SumPear.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnPII_SumPear.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnPII_SumPear.Caption = "Kết quả 1";
            this.gridColumnPII_SumPear.Name = "gridColumnPII_SumPear";
            this.gridColumnPII_SumPear.Visible = true;
            this.gridColumnPII_SumPear.Width = 61;
            // 
            // gridColumnTotalPear
            // 
            this.gridColumnTotalPear.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnTotalPear.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnTotalPear.Caption = "Tổng điểm 1";
            this.gridColumnTotalPear.Name = "gridColumnTotalPear";
            this.gridColumnTotalPear.Visible = true;
            this.gridColumnTotalPear.Width = 68;
            // 
            // gridColumnEven
            // 
            this.gridColumnEven.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnEven.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnEven.Caption = "Tổng điểm 2";
            this.gridColumnEven.Name = "gridColumnEven";
            this.gridColumnEven.Visible = true;
            this.gridColumnEven.Width = 68;
            // 
            // gridColumnPercent
            // 
            this.gridColumnPercent.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnPercent.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnPercent.Caption = "% Đạt được";
            this.gridColumnPercent.Name = "gridColumnPercent";
            this.gridColumnPercent.Visible = true;
            this.gridColumnPercent.Width = 69;
            // 
            // gridColumnDifference
            // 
            this.gridColumnDifference.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnDifference.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnDifference.Caption = "Chênh lệnh";
            this.gridColumnDifference.Name = "gridColumnDifference";
            this.gridColumnDifference.Visible = true;
            this.gridColumnDifference.Width = 80;
            // 
            // gridColumnKetQua
            // 
            this.gridColumnKetQua.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnKetQua.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnKetQua.Caption = "OK/NG";
            this.gridColumnKetQua.Name = "gridColumnKetQua";
            this.gridColumnKetQua.Visible = true;
            this.gridColumnKetQua.Width = 92;
            // 
            // gridColumnScorePicture
            // 
            this.gridColumnScorePicture.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnScorePicture.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnScorePicture.Caption = "Điểm";
            this.gridColumnScorePicture.FieldName = "ScorePicture";
            this.gridColumnScorePicture.Name = "gridColumnScorePicture";
            this.gridColumnScorePicture.Visible = true;
            // 
            // gridColumnPercentPicture
            // 
            this.gridColumnPercentPicture.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnPercentPicture.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnPercentPicture.Caption = "% Đạt được";
            this.gridColumnPercentPicture.FieldName = "PercentPicture";
            this.gridColumnPercentPicture.Name = "gridColumnPercentPicture";
            this.gridColumnPercentPicture.Visible = true;
            // 
            // gridColumnKetQuaPicture
            // 
            this.gridColumnKetQuaPicture.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnKetQuaPicture.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnKetQuaPicture.Caption = "OK/NG";
            this.gridColumnKetQuaPicture.FieldName = "KetQuaPicture";
            this.gridColumnKetQuaPicture.Name = "gridColumnKetQuaPicture";
            this.gridColumnKetQuaPicture.Visible = true;
            // 
            // gridColumnScoreEye
            // 
            this.gridColumnScoreEye.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnScoreEye.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnScoreEye.Caption = "Điểm mắt";
            this.gridColumnScoreEye.FieldName = "ScoreEye";
            this.gridColumnScoreEye.Name = "gridColumnScoreEye";
            this.gridColumnScoreEye.Visible = true;
            // 
            // gridColumnKetQuaEye
            // 
            this.gridColumnKetQuaEye.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnKetQuaEye.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnKetQuaEye.Caption = "OK/NG";
            this.gridColumnKetQuaEye.FieldName = "KetQuaEye";
            this.gridColumnKetQuaEye.Name = "gridColumnKetQuaEye";
            this.gridColumnKetQuaEye.Visible = true;
            // 
            // gridBand1
            // 
            this.gridBand1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand1.Columns.Add(this.gridColumnFullName);
            this.gridBand1.Columns.Add(this.gridColumnBirthday);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.VisibleIndex = 0;
            this.gridBand1.Width = 234;
            // 
            // gridBand3
            // 
            this.gridBand3.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridBand3.AppearanceHeader.Options.UseFont = true;
            this.gridBand3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand3.Caption = "PHẦN I";
            this.gridBand3.Columns.Add(this.gridColumnPI_SumPear);
            this.gridBand3.Columns.Add(this.gridColumnPII_SumEven);
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.VisibleIndex = 1;
            this.gridBand3.Width = 136;
            // 
            // gridBand2
            // 
            this.gridBand2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridBand2.AppearanceHeader.Options.UseFont = true;
            this.gridBand2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand2.Caption = "PHẦN II";
            this.gridBand2.Columns.Add(this.gridColumnPII_SumPear);
            this.gridBand2.Columns.Add(this.gridColumnPI_SumEven);
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.VisibleIndex = 2;
            this.gridBand2.Width = 137;
            // 
            // gridBand4
            // 
            this.gridBand4.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridBand4.AppearanceHeader.Options.UseFont = true;
            this.gridBand4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand4.Caption = "KẾT QUẢ BÀI THI CỘNG DỒN";
            this.gridBand4.Columns.Add(this.gridColumnTotalPear);
            this.gridBand4.Columns.Add(this.gridColumnEven);
            this.gridBand4.Columns.Add(this.gridColumnPercent);
            this.gridBand4.Columns.Add(this.gridColumnDifference);
            this.gridBand4.Columns.Add(this.gridColumnKetQua);
            this.gridBand4.Name = "gridBand4";
            this.gridBand4.VisibleIndex = 3;
            this.gridBand4.Width = 377;
            // 
            // gridBand5
            // 
            this.gridBand5.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridBand5.AppearanceHeader.Options.UseFont = true;
            this.gridBand5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand5.Caption = "KẾT QUẢ BÀI HÌNH";
            this.gridBand5.Columns.Add(this.gridColumnScorePicture);
            this.gridBand5.Columns.Add(this.gridColumnPercentPicture);
            this.gridBand5.Columns.Add(this.gridColumnKetQuaPicture);
            this.gridBand5.Name = "gridBand5";
            this.gridBand5.VisibleIndex = 4;
            this.gridBand5.Width = 225;
            // 
            // gridBand6
            // 
            this.gridBand6.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridBand6.AppearanceHeader.Options.UseFont = true;
            this.gridBand6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand6.Caption = "KẾT QUẢ MẮT";
            this.gridBand6.Columns.Add(this.gridColumnScoreEye);
            this.gridBand6.Columns.Add(this.gridColumnKetQuaEye);
            this.gridBand6.Name = "gridBand6";
            this.gridBand6.VisibleIndex = 5;
            this.gridBand6.Width = 150;
            // 
            // FormScores
            // 
            this.Appearance.BackColor = System.Drawing.Color.White;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(969, 527);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormScores";
            this.Text = "Điểm của ứng viên";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem barButtonItemAddScores;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bandedGridView1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumnFullName;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumnBirthday;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumnPI_SumPear;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumnPII_SumEven;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumnPII_SumPear;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumnPI_SumEven;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumnTotalPear;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumnEven;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumnPercent;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumnDifference;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumnKetQua;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand4;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand5;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumnScorePicture;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumnPercentPicture;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumnKetQuaPicture;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand6;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumnScoreEye;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridColumnKetQuaEye;
    }
}