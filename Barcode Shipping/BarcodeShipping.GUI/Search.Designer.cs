namespace BarcodeShipping.GUI
{
    partial class Search
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Search));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelSupport = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelPEIT = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelDessignBy = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelName = new System.Windows.Forms.ToolStripStatusLabel();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::BarcodeShipping.GUI.WaitLoadData), true, true);
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.btnDelBox = new DevExpress.XtraEditors.SimpleButton();
            this.btnExports = new DevExpress.XtraEditors.SimpleButton();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.comboBoxEditSearchByKey = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtSearch = new DevExpress.XtraEditors.TextEdit();
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
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditSearchByKey.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
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
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Location = new System.Drawing.Point(12, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(92, 33);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Search";
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.panelControl2.Controls.Add(this.btnDelBox);
            this.panelControl2.Controls.Add(this.btnExports);
            this.panelControl2.Controls.Add(this.btnSearch);
            this.panelControl2.Controls.Add(this.comboBoxEditSearchByKey);
            this.panelControl2.Controls.Add(this.txtSearch);
            this.panelControl2.Controls.Add(this.labelControl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 0);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(884, 63);
            this.panelControl2.TabIndex = 7;
            // 
            // btnDelBox
            // 
            this.btnDelBox.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnDelBox.Appearance.Options.UseFont = true;
            this.btnDelBox.Enabled = false;
            this.btnDelBox.Image = ((System.Drawing.Image)(resources.GetObject("btnDelBox.Image")));
            this.btnDelBox.Location = new System.Drawing.Point(746, 22);
            this.btnDelBox.Name = "btnDelBox";
            this.btnDelBox.Size = new System.Drawing.Size(97, 27);
            this.btnDelBox.TabIndex = 5;
            this.btnDelBox.Text = "Del Box";
            this.btnDelBox.Click += new System.EventHandler(this.btnDelBox_Click);
            // 
            // btnExports
            // 
            this.btnExports.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnExports.Appearance.Options.UseFont = true;
            this.btnExports.Enabled = false;
            this.btnExports.Image = ((System.Drawing.Image)(resources.GetObject("btnExports.Image")));
            this.btnExports.Location = new System.Drawing.Point(619, 22);
            this.btnExports.Name = "btnExports";
            this.btnExports.Size = new System.Drawing.Size(120, 27);
            this.btnExports.TabIndex = 4;
            this.btnExports.Text = "Export Exels";
            this.btnExports.Click += new System.EventHandler(this.btnExports_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnSearch.Appearance.Options.UseFont = true;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(511, 22);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(102, 27);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // comboBoxEditSearchByKey
            // 
            this.comboBoxEditSearchByKey.EditValue = "Production ID";
            this.comboBoxEditSearchByKey.Location = new System.Drawing.Point(366, 22);
            this.comboBoxEditSearchByKey.Name = "comboBoxEditSearchByKey";
            this.comboBoxEditSearchByKey.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.comboBoxEditSearchByKey.Properties.Appearance.Options.UseFont = true;
            this.comboBoxEditSearchByKey.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditSearchByKey.Properties.Items.AddRange(new object[] {
            "Production ID",
            "PO NO",
            "Box ID"});
            this.comboBoxEditSearchByKey.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEditSearchByKey.Size = new System.Drawing.Size(139, 26);
            this.comboBoxEditSearchByKey.TabIndex = 2;
            this.comboBoxEditSearchByKey.SelectedValueChanged += new System.EventHandler(this.comboBoxEditSearchByKey_SelectedValueChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(110, 22);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtSearch.Properties.Appearance.Options.UseFont = true;
            this.txtSearch.Size = new System.Drawing.Size(250, 26);
            this.txtSearch.TabIndex = 1;
            // 
            // gridControlData
            // 
            this.gridControlData.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControlData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlData.Location = new System.Drawing.Point(0, 63);
            this.gridControlData.MainView = this.gridView1;
            this.gridControlData.Name = "gridControlData";
            this.gridControlData.Size = new System.Drawing.Size(884, 554);
            this.gridControlData.TabIndex = 8;
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
            this.gridColumnCounter.Width = 28;
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
            this.gridColumnOperatorCode.Width = 70;
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
            this.gridColumnModel.Width = 95;
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
            this.gridColumnWorkingOder.Width = 100;
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
            this.gridColumnBox.Width = 100;
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
            this.gridColumnDateCheck.Width = 100;
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 641);
            this.Controls.Add(this.gridControlData);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.statusStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(900, 680);
            this.Name = "Search";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Search";
            this.Load += new System.EventHandler(this.Search_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditSearchByKey.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
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
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtSearch;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditSearchByKey;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPO_NO;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnDateCheck;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnProductID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnBox;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnWorkingOder;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnModel;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnOperatorCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCounter;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.GridControl gridControlData;
        private DevExpress.XtraEditors.SimpleButton btnExports;
        private DevExpress.XtraEditors.SimpleButton btnDelBox;
    }
}