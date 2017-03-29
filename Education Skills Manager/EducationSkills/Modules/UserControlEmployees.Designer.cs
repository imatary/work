namespace EducationSkills.Modules
{
    partial class UserControlEmployees
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlEmployees));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnTranfers = new DevExpress.XtraEditors.SimpleButton();
            this.btnImports = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefesh = new DevExpress.XtraEditors.SimpleButton();
            this.btnFind = new DevExpress.XtraEditors.SimpleButton();
            this.txtDept = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridStaffCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridFullName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridBirthDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridSex = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridEntryDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridDeptCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridPosName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::EducationSkills.ShowWait), true, true, typeof(System.Windows.Forms.UserControl));
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDept.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnTranfers);
            this.groupBox1.Controls.Add(this.btnImports);
            this.groupBox1.Controls.Add(this.btnRefesh);
            this.groupBox1.Controls.Add(this.btnFind);
            this.groupBox1.Controls.Add(this.txtDept);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(797, 81);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Options";
            // 
            // btnTranfers
            // 
            this.btnTranfers.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTranfers.Appearance.Options.UseFont = true;
            this.btnTranfers.Enabled = false;
            this.btnTranfers.Image = ((System.Drawing.Image)(resources.GetObject("btnTranfers.Image")));
            this.btnTranfers.Location = new System.Drawing.Point(98, 36);
            this.btnTranfers.Name = "btnTranfers";
            this.btnTranfers.Size = new System.Drawing.Size(146, 28);
            this.btnTranfers.TabIndex = 9;
            this.btnTranfers.Text = "Tranfer to Skills Map";
            this.btnTranfers.Click += new System.EventHandler(this.btnTranfers_Click);
            // 
            // btnImports
            // 
            this.btnImports.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImports.Appearance.Options.UseFont = true;
            this.btnImports.Image = ((System.Drawing.Image)(resources.GetObject("btnImports.Image")));
            this.btnImports.Location = new System.Drawing.Point(16, 36);
            this.btnImports.Name = "btnImports";
            this.btnImports.Size = new System.Drawing.Size(75, 28);
            this.btnImports.TabIndex = 8;
            this.btnImports.Text = "Imports";
            this.btnImports.Click += new System.EventHandler(this.btnImports_Click);
            // 
            // btnRefesh
            // 
            this.btnRefesh.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefesh.Appearance.Options.UseFont = true;
            this.btnRefesh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefesh.Image")));
            this.btnRefesh.Location = new System.Drawing.Point(649, 35);
            this.btnRefesh.Name = "btnRefesh";
            this.btnRefesh.Size = new System.Drawing.Size(79, 27);
            this.btnRefesh.TabIndex = 7;
            this.btnRefesh.Text = "Tải lại";
            this.btnRefesh.Click += new System.EventHandler(this.btnRefesh_Click);
            // 
            // btnFind
            // 
            this.btnFind.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFind.Appearance.Options.UseFont = true;
            this.btnFind.Image = ((System.Drawing.Image)(resources.GetObject("btnFind.Image")));
            this.btnFind.Location = new System.Drawing.Point(573, 34);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(70, 28);
            this.btnFind.TabIndex = 6;
            this.btnFind.Text = "Tìm";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // txtDept
            // 
            this.txtDept.Location = new System.Drawing.Point(348, 34);
            this.txtDept.Name = "txtDept";
            this.txtDept.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDept.Properties.Appearance.Options.UseFont = true;
            this.txtDept.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtDept.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDept.Properties.DisplayMember = "DeptCode";
            this.txtDept.Properties.NullText = "";
            this.txtDept.Properties.NullValuePrompt = "Select Dept";
            this.txtDept.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtDept.Properties.ValueMember = "DeptCode";
            this.txtDept.Properties.View = this.gridLookUpEdit1View;
            this.txtDept.Size = new System.Drawing.Size(219, 28);
            this.txtDept.TabIndex = 5;
            this.txtDept.EditValueChanged += new System.EventHandler(this.txtDept_EditValueChanged);
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1});
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridColumn1.AppearanceHeader.Options.UseFont = true;
            this.gridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridColumn1.Caption = "gridDeptCode";
            this.gridColumn1.FieldName = "DeptCode";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(10, 91);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(797, 402);
            this.gridControl1.TabIndex = 2;
            this.gridControl1.UseEmbeddedNavigator = true;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridStaffCode,
            this.gridFullName,
            this.gridBirthDate,
            this.gridSex,
            this.gridEntryDate,
            this.gridDeptCode,
            this.gridPosName});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFind.FindNullPrompt = "Nhập vào tên nhân viên cần tìm...";
            this.gridView1.OptionsSelection.CheckBoxSelectorColumnWidth = 30;
            this.gridView1.OptionsSelection.InvertSelection = true;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView1.OptionsSelection.ResetSelectionClickOutsideCheckboxSelector = true;
            this.gridView1.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridView1_RowCellClick);
            // 
            // gridStaffCode
            // 
            this.gridStaffCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridStaffCode.AppearanceHeader.Options.UseFont = true;
            this.gridStaffCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gridStaffCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridStaffCode.Caption = "Code";
            this.gridStaffCode.FieldName = "StaffCode";
            this.gridStaffCode.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridStaffCode.Name = "gridStaffCode";
            this.gridStaffCode.Visible = true;
            this.gridStaffCode.VisibleIndex = 1;
            this.gridStaffCode.Width = 74;
            // 
            // gridFullName
            // 
            this.gridFullName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridFullName.AppearanceHeader.Options.UseFont = true;
            this.gridFullName.AppearanceHeader.Options.UseTextOptions = true;
            this.gridFullName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridFullName.Caption = "Họ & Tên";
            this.gridFullName.FieldName = "FullName";
            this.gridFullName.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridFullName.Name = "gridFullName";
            this.gridFullName.Visible = true;
            this.gridFullName.VisibleIndex = 2;
            this.gridFullName.Width = 179;
            // 
            // gridBirthDate
            // 
            this.gridBirthDate.AppearanceCell.Options.UseTextOptions = true;
            this.gridBirthDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridBirthDate.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridBirthDate.AppearanceHeader.Options.UseFont = true;
            this.gridBirthDate.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBirthDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBirthDate.Caption = "Ngày sinh";
            this.gridBirthDate.FieldName = "BirthDate";
            this.gridBirthDate.Name = "gridBirthDate";
            this.gridBirthDate.Visible = true;
            this.gridBirthDate.VisibleIndex = 3;
            this.gridBirthDate.Width = 101;
            // 
            // gridSex
            // 
            this.gridSex.AppearanceCell.Options.UseTextOptions = true;
            this.gridSex.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridSex.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridSex.AppearanceHeader.Options.UseFont = true;
            this.gridSex.AppearanceHeader.Options.UseTextOptions = true;
            this.gridSex.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridSex.Caption = "Giới tính";
            this.gridSex.FieldName = "Sex";
            this.gridSex.Name = "gridSex";
            this.gridSex.Visible = true;
            this.gridSex.VisibleIndex = 4;
            this.gridSex.Width = 67;
            // 
            // gridEntryDate
            // 
            this.gridEntryDate.AppearanceCell.Options.UseTextOptions = true;
            this.gridEntryDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridEntryDate.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridEntryDate.AppearanceHeader.Options.UseFont = true;
            this.gridEntryDate.AppearanceHeader.Options.UseTextOptions = true;
            this.gridEntryDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridEntryDate.Caption = "Ngày vào làm";
            this.gridEntryDate.FieldName = "EntryDate";
            this.gridEntryDate.Name = "gridEntryDate";
            this.gridEntryDate.Visible = true;
            this.gridEntryDate.VisibleIndex = 5;
            this.gridEntryDate.Width = 94;
            // 
            // gridDeptCode
            // 
            this.gridDeptCode.AppearanceCell.Options.UseTextOptions = true;
            this.gridDeptCode.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridDeptCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridDeptCode.AppearanceHeader.Options.UseFont = true;
            this.gridDeptCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gridDeptCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridDeptCode.Caption = "Bộ phận";
            this.gridDeptCode.FieldName = "DeptCode";
            this.gridDeptCode.Name = "gridDeptCode";
            this.gridDeptCode.Visible = true;
            this.gridDeptCode.VisibleIndex = 6;
            this.gridDeptCode.Width = 95;
            // 
            // gridPosName
            // 
            this.gridPosName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridPosName.AppearanceHeader.Options.UseFont = true;
            this.gridPosName.AppearanceHeader.Options.UseTextOptions = true;
            this.gridPosName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridPosName.Caption = "Chức vụ";
            this.gridPosName.FieldName = "PosName";
            this.gridPosName.Name = "gridPosName";
            this.gridPosName.Visible = true;
            this.gridPosName.VisibleIndex = 7;
            this.gridPosName.Width = 134;
            // 
            // splashScreenManager1
            // 
            this.splashScreenManager1.ClosingDelay = 500;
            // 
            // UserControlEmployees
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.groupBox1);
            this.Name = "UserControlEmployees";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(817, 503);
            this.Load += new System.EventHandler(this.UserControlEmployees_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtDept.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.SimpleButton btnRefesh;
        private DevExpress.XtraEditors.SimpleButton btnFind;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.GridLookUpEdit txtDept;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        private DevExpress.XtraGrid.Columns.GridColumn gridStaffCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridFullName;
        private DevExpress.XtraGrid.Columns.GridColumn gridBirthDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridSex;
        private DevExpress.XtraGrid.Columns.GridColumn gridEntryDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridDeptCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridPosName;
        private DevExpress.XtraEditors.SimpleButton btnImports;
        private DevExpress.XtraEditors.SimpleButton btnTranfers;
    }
}
