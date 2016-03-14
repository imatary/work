namespace BarcodeShipping.GUI
{
    partial class ExportToExel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportToExel));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelSupport = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelPEIT = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelDessignBy = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelName = new System.Windows.Forms.ToolStripStatusLabel();
            this.gridControlData = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnCounter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnOperatorCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnModel = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnWorkingOder = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnBox = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnProductID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPO_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnDateCheck = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.btnExportToExel = new DevExpress.XtraEditors.SimpleButton();
            this.lblDateTo = new DevExpress.XtraEditors.LabelControl();
            this.dateEditTo = new DevExpress.XtraEditors.DateEdit();
            this.dateEditFrom = new DevExpress.XtraEditors.DateEdit();
            this.lblDateFrom = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::BarcodeShipping.GUI.WaitFormSearch), true, true);
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFrom.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelSupport,
            this.toolStripStatusLabelPEIT,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabelDessignBy,
            this.toolStripStatusLabelName});
            this.statusStrip1.Location = new System.Drawing.Point(0, 617);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(884, 24);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabelSupport
            // 
            this.toolStripStatusLabelSupport.Name = "toolStripStatusLabelSupport";
            this.toolStripStatusLabelSupport.Size = new System.Drawing.Size(52, 19);
            this.toolStripStatusLabelSupport.Text = "Support:";
            // 
            // toolStripStatusLabelPEIT
            // 
            this.toolStripStatusLabelPEIT.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabelPEIT.Name = "toolStripStatusLabelPEIT";
            this.toolStripStatusLabelPEIT.Size = new System.Drawing.Size(43, 19);
            this.toolStripStatusLabelPEIT.Text = "PE-IT";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(10, 19);
            this.toolStripStatusLabel3.Text = "|";
            // 
            // toolStripStatusLabelDessignBy
            // 
            this.toolStripStatusLabelDessignBy.Name = "toolStripStatusLabelDessignBy";
            this.toolStripStatusLabelDessignBy.Size = new System.Drawing.Size(62, 19);
            this.toolStripStatusLabelDessignBy.Text = "Design by:";
            // 
            // toolStripStatusLabelName
            // 
            this.toolStripStatusLabelName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripStatusLabelName.Name = "toolStripStatusLabelName";
            this.toolStripStatusLabelName.Size = new System.Drawing.Size(148, 19);
            this.toolStripStatusLabelName.Text = "cuongpham@umcvn.com";
            // 
            // gridControlData
            // 
            this.gridControlData.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControlData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlData.Location = new System.Drawing.Point(0, 96);
            this.gridControlData.MainView = this.gridView1;
            this.gridControlData.Name = "gridControlData";
            this.gridControlData.Size = new System.Drawing.Size(884, 521);
            this.gridControlData.TabIndex = 6;
            this.gridControlData.UseEmbeddedNavigator = true;
            this.gridControlData.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnCounter,
            this.gridColumnOperatorCode,
            this.gridColumnModel,
            this.gridColumnWorkingOder,
            this.gridColumnBox,
            this.gridColumnProductID,
            this.gridColumnPO_NO,
            this.gridColumnQuantity,
            this.gridColumnDateCheck});
            this.gridView1.GridControl = this.gridControlData;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridView1_CustomColumnDisplayText);
            // 
            // gridColumnCounter
            // 
            this.gridColumnCounter.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumnCounter.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnCounter.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumnCounter.AppearanceHeader.Options.UseFont = true;
            this.gridColumnCounter.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnCounter.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnCounter.Caption = "#";
            this.gridColumnCounter.FieldName = "Counter";
            this.gridColumnCounter.MinWidth = 28;
            this.gridColumnCounter.Name = "gridColumnCounter";
            this.gridColumnCounter.Visible = true;
            this.gridColumnCounter.VisibleIndex = 0;
            this.gridColumnCounter.Width = 29;
            // 
            // gridColumnOperatorCode
            // 
            this.gridColumnOperatorCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumnOperatorCode.AppearanceHeader.Options.UseFont = true;
            this.gridColumnOperatorCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnOperatorCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnOperatorCode.Caption = "Operator";
            this.gridColumnOperatorCode.FieldName = "Operator";
            this.gridColumnOperatorCode.MinWidth = 70;
            this.gridColumnOperatorCode.Name = "gridColumnOperatorCode";
            this.gridColumnOperatorCode.Visible = true;
            this.gridColumnOperatorCode.VisibleIndex = 1;
            this.gridColumnOperatorCode.Width = 73;
            // 
            // gridColumnModel
            // 
            this.gridColumnModel.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.5F, System.Drawing.FontStyle.Bold);
            this.gridColumnModel.AppearanceHeader.Options.UseFont = true;
            this.gridColumnModel.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnModel.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnModel.Caption = "Model";
            this.gridColumnModel.FieldName = "Model";
            this.gridColumnModel.MinWidth = 95;
            this.gridColumnModel.Name = "gridColumnModel";
            this.gridColumnModel.Visible = true;
            this.gridColumnModel.VisibleIndex = 2;
            this.gridColumnModel.Width = 99;
            // 
            // gridColumnWorkingOder
            // 
            this.gridColumnWorkingOder.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.5F, System.Drawing.FontStyle.Bold);
            this.gridColumnWorkingOder.AppearanceHeader.Options.UseFont = true;
            this.gridColumnWorkingOder.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnWorkingOder.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnWorkingOder.Caption = "Working Oder";
            this.gridColumnWorkingOder.FieldName = "WorkingOder";
            this.gridColumnWorkingOder.MinWidth = 100;
            this.gridColumnWorkingOder.Name = "gridColumnWorkingOder";
            this.gridColumnWorkingOder.Visible = true;
            this.gridColumnWorkingOder.VisibleIndex = 3;
            this.gridColumnWorkingOder.Width = 104;
            // 
            // gridColumnBox
            // 
            this.gridColumnBox.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.5F, System.Drawing.FontStyle.Bold);
            this.gridColumnBox.AppearanceHeader.Options.UseFont = true;
            this.gridColumnBox.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnBox.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnBox.Caption = "Box";
            this.gridColumnBox.FieldName = "BoxID";
            this.gridColumnBox.MinWidth = 100;
            this.gridColumnBox.Name = "gridColumnBox";
            this.gridColumnBox.Visible = true;
            this.gridColumnBox.VisibleIndex = 4;
            this.gridColumnBox.Width = 104;
            // 
            // gridColumnProductID
            // 
            this.gridColumnProductID.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumnProductID.AppearanceHeader.Options.UseFont = true;
            this.gridColumnProductID.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnProductID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnProductID.Caption = "Product ID";
            this.gridColumnProductID.FieldName = "ProductID";
            this.gridColumnProductID.MinWidth = 220;
            this.gridColumnProductID.Name = "gridColumnProductID";
            this.gridColumnProductID.Visible = true;
            this.gridColumnProductID.VisibleIndex = 5;
            this.gridColumnProductID.Width = 220;
            // 
            // gridColumnPO_NO
            // 
            this.gridColumnPO_NO.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumnPO_NO.AppearanceHeader.Options.UseFont = true;
            this.gridColumnPO_NO.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnPO_NO.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnPO_NO.Caption = "PO NO";
            this.gridColumnPO_NO.FieldName = "PO_NO";
            this.gridColumnPO_NO.MinWidth = 90;
            this.gridColumnPO_NO.Name = "gridColumnPO_NO";
            this.gridColumnPO_NO.Visible = true;
            this.gridColumnPO_NO.VisibleIndex = 6;
            this.gridColumnPO_NO.Width = 90;
            // 
            // gridColumnQuantity
            // 
            this.gridColumnQuantity.AppearanceCell.Options.UseTextOptions = true;
            this.gridColumnQuantity.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnQuantity.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumnQuantity.AppearanceHeader.Options.UseFont = true;
            this.gridColumnQuantity.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnQuantity.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnQuantity.Caption = "Quantity";
            this.gridColumnQuantity.FieldName = "Quantity";
            this.gridColumnQuantity.MinWidth = 65;
            this.gridColumnQuantity.Name = "gridColumnQuantity";
            this.gridColumnQuantity.Visible = true;
            this.gridColumnQuantity.VisibleIndex = 7;
            this.gridColumnQuantity.Width = 65;
            // 
            // gridColumnDateCheck
            // 
            this.gridColumnDateCheck.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumnDateCheck.AppearanceHeader.Options.UseFont = true;
            this.gridColumnDateCheck.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnDateCheck.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnDateCheck.Caption = "Date Check";
            this.gridColumnDateCheck.FieldName = "DateCheck";
            this.gridColumnDateCheck.MinWidth = 100;
            this.gridColumnDateCheck.Name = "gridColumnDateCheck";
            this.gridColumnDateCheck.Visible = true;
            this.gridColumnDateCheck.VisibleIndex = 8;
            this.gridColumnDateCheck.Width = 149;
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.panelControl2.Controls.Add(this.btnSearch);
            this.panelControl2.Controls.Add(this.btnExportToExel);
            this.panelControl2.Controls.Add(this.lblDateTo);
            this.panelControl2.Controls.Add(this.dateEditTo);
            this.panelControl2.Controls.Add(this.dateEditFrom);
            this.panelControl2.Controls.Add(this.lblDateFrom);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(884, 96);
            this.panelControl2.TabIndex = 5;
            // 
            // btnSearch
            // 
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(475, 60);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(63, 23);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnExportToExel
            // 
            this.btnExportToExel.Image = ((System.Drawing.Image)(resources.GetObject("btnExportToExel.Image")));
            this.btnExportToExel.Location = new System.Drawing.Point(544, 60);
            this.btnExportToExel.Name = "btnExportToExel";
            this.btnExportToExel.Size = new System.Drawing.Size(76, 23);
            this.btnExportToExel.TabIndex = 5;
            this.btnExportToExel.Text = "Exports";
            this.btnExportToExel.Click += new System.EventHandler(this.btnExportToExel_Click);
            // 
            // lblDateTo
            // 
            this.lblDateTo.Location = new System.Drawing.Point(274, 65);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(16, 13);
            this.lblDateTo.TabIndex = 3;
            this.lblDateTo.Text = "To:";
            // 
            // dateEditTo
            // 
            this.dateEditTo.EditValue = null;
            this.dateEditTo.Location = new System.Drawing.Point(296, 60);
            this.dateEditTo.Name = "dateEditTo";
            this.dateEditTo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.dateEditTo.Properties.Appearance.Options.UseFont = true;
            this.dateEditTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditTo.Size = new System.Drawing.Size(173, 22);
            this.dateEditTo.TabIndex = 4;
            this.dateEditTo.EditValueChanged += new System.EventHandler(this.dateEditTo_EditValueChanged);
            // 
            // dateEditFrom
            // 
            this.dateEditFrom.EditValue = null;
            this.dateEditFrom.Location = new System.Drawing.Point(95, 60);
            this.dateEditFrom.Name = "dateEditFrom";
            this.dateEditFrom.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.dateEditFrom.Properties.Appearance.Options.UseFont = true;
            this.dateEditFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditFrom.Size = new System.Drawing.Size(173, 22);
            this.dateEditFrom.TabIndex = 2;
            this.dateEditFrom.EditValueChanged += new System.EventHandler(this.dateEditFrom_EditValueChanged);
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblDateFrom.Location = new System.Drawing.Point(27, 63);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(62, 16);
            this.lblDateFrom.TabIndex = 1;
            this.lblDateFrom.Text = "Date from:";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Location = new System.Drawing.Point(27, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(201, 33);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Search by date";
            // 
            // ExportToExel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(884, 641);
            this.Controls.Add(this.gridControlData);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(900, 680);
            this.Name = "ExportToExel";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ExportToExel";
            this.Load += new System.EventHandler(this.ExportToExel_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditFrom.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelSupport;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelPEIT;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelDessignBy;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelName;
        private DevExpress.XtraGrid.GridControl gridControlData;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCounter;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnOperatorCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnModel;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnWorkingOder;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnBox;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnProductID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnDateCheck;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lblDateFrom;
        private DevExpress.XtraEditors.DateEdit dateEditFrom;
        private DevExpress.XtraEditors.LabelControl lblDateTo;
        private DevExpress.XtraEditors.DateEdit dateEditTo;
        private DevExpress.XtraEditors.SimpleButton btnExportToExel;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPO_NO;
    }
}