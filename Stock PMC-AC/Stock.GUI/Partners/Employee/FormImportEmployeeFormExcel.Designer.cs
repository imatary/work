namespace Stock.GUI.Partners
{
    partial class FormImportEmployeeFormExcel
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.radioButtonUpdateIfDepartmentExits = new System.Windows.Forms.RadioButton();
            this.radioButtonIgnoreIfDepartmentExits = new System.Windows.Forms.RadioButton();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnDepartmentID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.textEditPathFileExel = new DevExpress.XtraEditors.ButtonEdit();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.linkLabelAreaExcel = new System.Windows.Forms.LinkLabel();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnSaveDataFormExel = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditPathFileExel.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.radioButtonUpdateIfDepartmentExits);
            this.panelControl1.Controls.Add(this.radioButtonIgnoreIfDepartmentExits);
            this.panelControl1.Controls.Add(this.labelControl5);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(651, 68);
            this.panelControl1.TabIndex = 0;
            // 
            // radioButtonUpdateIfDepartmentExits
            // 
            this.radioButtonUpdateIfDepartmentExits.AutoSize = true;
            this.radioButtonUpdateIfDepartmentExits.Location = new System.Drawing.Point(402, 36);
            this.radioButtonUpdateIfDepartmentExits.Name = "radioButtonUpdateIfDepartmentExits";
            this.radioButtonUpdateIfDepartmentExits.Size = new System.Drawing.Size(141, 17);
            this.radioButtonUpdateIfDepartmentExits.TabIndex = 6;
            this.radioButtonUpdateIfDepartmentExits.Text = "Cập nhập nếu đã tồn tại";
            this.radioButtonUpdateIfDepartmentExits.UseVisualStyleBackColor = true;
            // 
            // radioButtonIgnoreIfDepartmentExits
            // 
            this.radioButtonIgnoreIfDepartmentExits.AutoSize = true;
            this.radioButtonIgnoreIfDepartmentExits.Checked = true;
            this.radioButtonIgnoreIfDepartmentExits.Location = new System.Drawing.Point(402, 13);
            this.radioButtonIgnoreIfDepartmentExits.Name = "radioButtonIgnoreIfDepartmentExits";
            this.radioButtonIgnoreIfDepartmentExits.Size = new System.Drawing.Size(128, 17);
            this.radioButtonIgnoreIfDepartmentExits.TabIndex = 5;
            this.radioButtonIgnoreIfDepartmentExits.TabStop = true;
            this.radioButtonIgnoreIfDepartmentExits.Text = "Bỏ qua nếu đã tồn tại";
            this.radioButtonIgnoreIfDepartmentExits.UseVisualStyleBackColor = true;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(29, 33);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(109, 13);
            this.labelControl5.TabIndex = 2;
            this.labelControl5.Text = "Chỉ hỗ trợ tập tin Excel";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl4.Location = new System.Drawing.Point(16, 13);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(122, 14);
            this.labelControl4.TabIndex = 1;
            this.labelControl4.Text = "Chọn tập tin nguồn";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Silver;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.labelControl1.Location = new System.Drawing.Point(0, 55);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(651, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "_________________________________________________________________________________" +
    "____________________________";
            // 
            // panelControl2
            // 
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.labelControl3);
            this.panelControl2.Controls.Add(this.gridControl1);
            this.panelControl2.Controls.Add(this.textEditPathFileExel);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl2.Location = new System.Drawing.Point(0, 68);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Padding = new System.Windows.Forms.Padding(15);
            this.panelControl2.Size = new System.Drawing.Size(651, 362);
            this.panelControl2.TabIndex = 1;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(15, 303);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(80, 13);
            this.labelControl3.TabIndex = 1;
            this.labelControl3.Text = "Chọn đường dẫn";
            // 
            // gridControl1
            // 
            this.gridControl1.Cursor = System.Windows.Forms.Cursors.Default;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.gridControl1.Location = new System.Drawing.Point(15, 15);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(621, 282);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.UseEmbeddedNavigator = true;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnDepartmentID,
            this.gridColumnCode,
            this.gridColumn1,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn9});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupCount = 1;
            this.gridView1.Name = "gridView1";
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumnDepartmentID, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumnDepartmentID
            // 
            this.gridColumnDepartmentID.Caption = "Bộ Phận";
            this.gridColumnDepartmentID.FieldName = "DepartmentName";
            this.gridColumnDepartmentID.Name = "gridColumnDepartmentID";
            this.gridColumnDepartmentID.Visible = true;
            this.gridColumnDepartmentID.VisibleIndex = 0;
            this.gridColumnDepartmentID.Width = 230;
            // 
            // gridColumnCode
            // 
            this.gridColumnCode.Caption = "Code";
            this.gridColumnCode.FieldName = "EmployeeCode";
            this.gridColumnCode.Name = "gridColumnCode";
            this.gridColumnCode.Visible = true;
            this.gridColumnCode.VisibleIndex = 0;
            this.gridColumnCode.Width = 83;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Tên";
            this.gridColumn1.FieldName = "EmployeeName";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            this.gridColumn1.Width = 118;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Địa Chỉ";
            this.gridColumn3.FieldName = "Address";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 4;
            this.gridColumn3.Width = 38;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Điện thoại";
            this.gridColumn4.FieldName = "HomeTell";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            this.gridColumn4.Width = 62;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Di Động";
            this.gridColumn5.FieldName = "Mobile";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            this.gridColumn5.Width = 38;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "FAX";
            this.gridColumn6.FieldName = "Fax";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 6;
            this.gridColumn6.Width = 38;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Email";
            this.gridColumn7.FieldName = "Email";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 2;
            this.gridColumn7.Width = 99;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Ghi Chú";
            this.gridColumn9.FieldName = "Note";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 7;
            this.gridColumn9.Width = 51;
            // 
            // textEditPathFileExel
            // 
            this.textEditPathFileExel.EditValue = "";
            this.textEditPathFileExel.Location = new System.Drawing.Point(15, 322);
            this.textEditPathFileExel.Name = "textEditPathFileExel";
            this.textEditPathFileExel.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Duyệt file", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleLeft, global::Stock.GUI.Properties.Resources.brower_excel_16, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.textEditPathFileExel.Size = new System.Drawing.Size(621, 22);
            this.textEditPathFileExel.TabIndex = 2;
            this.textEditPathFileExel.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.textEditPathFileExel_ButtonPressed);
            // 
            // panelControl3
            // 
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl3.Controls.Add(this.linkLabelAreaExcel);
            this.panelControl3.Controls.Add(this.btnClose);
            this.panelControl3.Controls.Add(this.btnSaveDataFormExel);
            this.panelControl3.Controls.Add(this.labelControl2);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl3.Location = new System.Drawing.Point(0, 430);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(651, 48);
            this.panelControl3.TabIndex = 2;
            // 
            // linkLabelAreaExcel
            // 
            this.linkLabelAreaExcel.AutoSize = true;
            this.linkLabelAreaExcel.Font = new System.Drawing.Font("Tahoma", 9F);
            this.linkLabelAreaExcel.Location = new System.Drawing.Point(12, 15);
            this.linkLabelAreaExcel.Name = "linkLabelAreaExcel";
            this.linkLabelAreaExcel.Size = new System.Drawing.Size(107, 14);
            this.linkLabelAreaExcel.TabIndex = 3;
            this.linkLabelAreaExcel.TabStop = true;
            this.linkLabelAreaExcel.Text = "Tập Tin Excel Mẫu";
            this.linkLabelAreaExcel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelAreaExcel_LinkClicked);
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Image = global::Stock.GUI.Properties.Resources.delete_16;
            this.btnClose.Location = new System.Drawing.Point(536, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 28);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Hủy Bỏ (Esc)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSaveDataFormExel
            // 
            this.btnSaveDataFormExel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveDataFormExel.Image = global::Stock.GUI.Properties.Resources.database_save;
            this.btnSaveDataFormExel.Location = new System.Drawing.Point(429, 9);
            this.btnSaveDataFormExel.Name = "btnSaveDataFormExel";
            this.btnSaveDataFormExel.Size = new System.Drawing.Size(101, 28);
            this.btnSaveDataFormExel.TabIndex = 2;
            this.btnSaveDataFormExel.Text = "Lưu (Ctrl+S)";
            this.btnSaveDataFormExel.Click += new System.EventHandler(this.btnSaveDataFormExel_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.Silver;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl2.Location = new System.Drawing.Point(0, 0);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.ShowToolTips = false;
            this.labelControl2.Size = new System.Drawing.Size(651, 10);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "_________________________________________________________________________________" +
    "__________________________";
            // 
            // FormImportEmployeeFormExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(651, 477);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormImportEmployeeFormExcel";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm Nhân Viên Từ File Exel";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormImportEmployeeFormExcel_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditPathFileExel.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnSaveDataFormExel;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.ButtonEdit textEditPathFileExel;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnDepartmentID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCode;
        private System.Windows.Forms.LinkLabel linkLabelAreaExcel;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private System.Windows.Forms.RadioButton radioButtonUpdateIfDepartmentExits;
        private System.Windows.Forms.RadioButton radioButtonIgnoreIfDepartmentExits;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
    }
}