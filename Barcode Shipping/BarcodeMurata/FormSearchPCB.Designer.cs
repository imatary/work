namespace BarcodeMurata
{
    partial class FormSearchPCB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSearchPCB));
            this.splashScreenManager2 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::BarcodeMurata.WaitFormSearch), true, true);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelSupport = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelPEIT = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelDessignBy = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelName = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.comboBoxEditSearchByKey = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.txtSearchPCB = new DevExpress.XtraEditors.TextEdit();
            this.gridControlData = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnCounter = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnOperatorCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnBox = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnProductID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnMacAddress = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnQuantity = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnDateCheck = new DevExpress.XtraGrid.Columns.GridColumn();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditSearchByKey.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchPCB.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // splashScreenManager2
            // 
            this.splashScreenManager2.ClosingDelay = 500;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelSupport,
            this.toolStripStatusLabelPEIT,
            this.toolStripStatusLabel3,
            this.toolStripStatusLabelDessignBy,
            this.toolStripStatusLabelName});
            this.statusStrip1.Location = new System.Drawing.Point(0, 577);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(844, 24);
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
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.pictureBox1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(844, 94);
            this.panelControl1.TabIndex = 4;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 28F, System.Drawing.FontStyle.Bold);
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl1.Location = new System.Drawing.Point(198, 0);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(646, 94);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Search PCB";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Image = global::BarcodeMurata.Properties.Resources.umc;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(198, 94);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Office2003;
            this.panelControl2.Controls.Add(this.comboBoxEditSearchByKey);
            this.panelControl2.Controls.Add(this.btnSearch);
            this.panelControl2.Controls.Add(this.txtSearchPCB);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 94);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(844, 55);
            this.panelControl2.TabIndex = 5;
            // 
            // comboBoxEditSearchByKey
            // 
            this.comboBoxEditSearchByKey.EditValue = "Production ID";
            this.comboBoxEditSearchByKey.Location = new System.Drawing.Point(109, 15);
            this.comboBoxEditSearchByKey.Name = "comboBoxEditSearchByKey";
            this.comboBoxEditSearchByKey.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.comboBoxEditSearchByKey.Properties.Appearance.Options.UseFont = true;
            this.comboBoxEditSearchByKey.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEditSearchByKey.Properties.Items.AddRange(new object[] {
            "Production ID",
            "Box ID"});
            this.comboBoxEditSearchByKey.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.comboBoxEditSearchByKey.Size = new System.Drawing.Size(148, 26);
            this.comboBoxEditSearchByKey.TabIndex = 3;
            // 
            // btnSearch
            // 
            this.btnSearch.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnSearch.Appearance.Options.UseFont = true;
            this.btnSearch.Image = ((System.Drawing.Image)(resources.GetObject("btnSearch.Image")));
            this.btnSearch.Location = new System.Drawing.Point(581, 13);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(108, 28);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtSearchPCB
            // 
            this.txtSearchPCB.Location = new System.Drawing.Point(263, 14);
            this.txtSearchPCB.Name = "txtSearchPCB";
            this.txtSearchPCB.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtSearchPCB.Properties.Appearance.Options.UseFont = true;
            this.txtSearchPCB.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtSearchPCB.Properties.NullValuePrompt = "Enter the ID";
            this.txtSearchPCB.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtSearchPCB.Size = new System.Drawing.Size(312, 28);
            this.txtSearchPCB.TabIndex = 0;
            this.txtSearchPCB.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtSearchPCB_PreviewKeyDown);
            // 
            // gridControlData
            // 
            this.gridControlData.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControlData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlData.Location = new System.Drawing.Point(0, 149);
            this.gridControlData.MainView = this.gridView1;
            this.gridControlData.Name = "gridControlData";
            this.gridControlData.Size = new System.Drawing.Size(844, 428);
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
            this.gridColumnBox,
            this.gridColumnProductID,
            this.gridColumnMacAddress,
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
            this.gridColumnCounter.Name = "gridColumnCounter";
            this.gridColumnCounter.Visible = true;
            this.gridColumnCounter.VisibleIndex = 0;
            this.gridColumnCounter.Width = 27;
            // 
            // gridColumnOperatorCode
            // 
            this.gridColumnOperatorCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumnOperatorCode.AppearanceHeader.Options.UseFont = true;
            this.gridColumnOperatorCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnOperatorCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnOperatorCode.Caption = "Operator";
            this.gridColumnOperatorCode.FieldName = "OperatorCode";
            this.gridColumnOperatorCode.Name = "gridColumnOperatorCode";
            this.gridColumnOperatorCode.Visible = true;
            this.gridColumnOperatorCode.VisibleIndex = 1;
            this.gridColumnOperatorCode.Width = 100;
            // 
            // gridColumnBox
            // 
            this.gridColumnBox.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.5F, System.Drawing.FontStyle.Bold);
            this.gridColumnBox.AppearanceHeader.Options.UseFont = true;
            this.gridColumnBox.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnBox.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnBox.Caption = "Box";
            this.gridColumnBox.FieldName = "BoxID";
            this.gridColumnBox.Name = "gridColumnBox";
            this.gridColumnBox.Visible = true;
            this.gridColumnBox.VisibleIndex = 2;
            this.gridColumnBox.Width = 120;
            // 
            // gridColumnProductID
            // 
            this.gridColumnProductID.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumnProductID.AppearanceHeader.Options.UseFont = true;
            this.gridColumnProductID.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnProductID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnProductID.Caption = "Production ID";
            this.gridColumnProductID.FieldName = "ProductionID";
            this.gridColumnProductID.Name = "gridColumnProductID";
            this.gridColumnProductID.Visible = true;
            this.gridColumnProductID.VisibleIndex = 3;
            this.gridColumnProductID.Width = 100;
            // 
            // gridColumnMacAddress
            // 
            this.gridColumnMacAddress.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridColumnMacAddress.AppearanceHeader.Options.UseFont = true;
            this.gridColumnMacAddress.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumnMacAddress.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumnMacAddress.Caption = "Mac Address";
            this.gridColumnMacAddress.FieldName = "MacAddress";
            this.gridColumnMacAddress.Name = "gridColumnMacAddress";
            this.gridColumnMacAddress.Visible = true;
            this.gridColumnMacAddress.VisibleIndex = 4;
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
            this.gridColumnQuantity.Name = "gridColumnQuantity";
            this.gridColumnQuantity.Visible = true;
            this.gridColumnQuantity.VisibleIndex = 5;
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
            this.gridColumnDateCheck.Name = "gridColumnDateCheck";
            this.gridColumnDateCheck.Visible = true;
            this.gridColumnDateCheck.VisibleIndex = 6;
            this.gridColumnDateCheck.Width = 120;
            // 
            // FormSearchPCB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 601);
            this.Controls.Add(this.gridControlData);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.statusStrip1);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(860, 640);
            this.Name = "FormSearchPCB";
            this.ShowInTaskbar = false;
            this.Text = "FormSearchPCB";
            this.Load += new System.EventHandler(this.FormSearchPCB_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEditSearchByKey.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchPCB.Properties)).EndInit();
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
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.GridControl gridControlData;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCounter;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnOperatorCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnBox;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnProductID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnMacAddress;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnQuantity;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnDateCheck;
        private DevExpress.XtraEditors.TextEdit txtSearchPCB;
        private DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEditSearchByKey;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager2;
    }
}