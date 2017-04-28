namespace EducationSkills.Modules
{
    partial class UserControlManagerCertificates
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlManagerCertificates));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnExportToExel = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefesh = new DevExpress.XtraEditors.SimpleButton();
            this.btnFind = new DevExpress.XtraEditors.SimpleButton();
            this.txtDept = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridSTT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridStaffCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridFullName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridBirthDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridSex = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridEntryDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridPosName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridDeptCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridTrainingContent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridTrainingType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridStartDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridEndDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridCertificate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridDeadlineCertificate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::EducationSkills.ShowWait), true, true, typeof(System.Windows.Forms.UserControl));
            this.gridID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDept.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.btnExportToExel);
            this.groupBox1.Controls.Add(this.btnRefesh);
            this.groupBox1.Controls.Add(this.btnFind);
            this.groupBox1.Controls.Add(this.txtDept);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 100);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tùy chọn tìm kiếm";
            // 
            // btnAdd
            // 
            this.btnAdd.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Appearance.ForeColor = System.Drawing.Color.Green;
            this.btnAdd.Appearance.Options.UseFont = true;
            this.btnAdd.Appearance.Options.UseForeColor = true;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(17, 64);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(94, 28);
            this.btnAdd.TabIndex = 9;
            this.btnAdd.Text = "Thêm mới";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnExportToExel
            // 
            this.btnExportToExel.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportToExel.Appearance.Options.UseFont = true;
            this.btnExportToExel.Enabled = false;
            this.btnExportToExel.Image = ((System.Drawing.Image)(resources.GetObject("btnExportToExel.Image")));
            this.btnExportToExel.Location = new System.Drawing.Point(419, 65);
            this.btnExportToExel.Name = "btnExportToExel";
            this.btnExportToExel.Size = new System.Drawing.Size(109, 27);
            this.btnExportToExel.TabIndex = 8;
            this.btnExportToExel.Text = "Export to Exel";
            this.btnExportToExel.Click += new System.EventHandler(this.btnExportToExel_Click);
            // 
            // btnRefesh
            // 
            this.btnRefesh.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefesh.Appearance.Options.UseFont = true;
            this.btnRefesh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefesh.Image")));
            this.btnRefesh.Location = new System.Drawing.Point(334, 65);
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
            this.btnFind.Location = new System.Drawing.Point(257, 65);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(70, 28);
            this.btnFind.TabIndex = 6;
            this.btnFind.Text = "Tìm";
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // txtDept
            // 
            this.txtDept.Location = new System.Drawing.Point(257, 33);
            this.txtDept.Name = "txtDept";
            this.txtDept.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDept.Properties.Appearance.Options.UseFont = true;
            this.txtDept.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtDept.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDept.Properties.DisplayMember = "DeptCode";
            this.txtDept.Properties.NullText = "";
            this.txtDept.Properties.NullValuePrompt = "Chọn một bộ phận";
            this.txtDept.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtDept.Properties.ValueMember = "DeptCode";
            this.txtDept.Properties.View = this.gridLookUpEdit1View;
            this.txtDept.Size = new System.Drawing.Size(271, 28);
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
            this.gridColumn1.Caption = "Dept";
            this.gridColumn1.FieldName = "DeptCode";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(3, 103);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(776, 391);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.UseEmbeddedNavigator = true;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridSTT,
            this.gridStaffCode,
            this.gridFullName,
            this.gridBirthDate,
            this.gridSex,
            this.gridEntryDate,
            this.gridPosName,
            this.gridDeptCode,
            this.gridTrainingContent,
            this.gridTrainingType,
            this.gridStartDate,
            this.gridEndDate,
            this.gridCertificate,
            this.gridDeadlineCertificate,
            this.gridNote,
            this.gridID});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsFind.FindNullPrompt = "Nhập vào tên nhân viên cần tìm...";
            this.gridView1.OptionsSelection.CheckBoxSelectorColumnWidth = 30;
            this.gridView1.OptionsSelection.InvertSelection = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView1.OptionsSelection.ResetSelectionClickOutsideCheckboxSelector = true;
            this.gridView1.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridStaffCode, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.gridView1.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gridView1_PopupMenuShowing);
            this.gridView1.CustomColumnDisplayText += new DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventHandler(this.gridView1_CustomColumnDisplayText);
            // 
            // gridSTT
            // 
            this.gridSTT.AppearanceCell.Options.UseTextOptions = true;
            this.gridSTT.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridSTT.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridSTT.AppearanceHeader.Options.UseFont = true;
            this.gridSTT.AppearanceHeader.Options.UseTextOptions = true;
            this.gridSTT.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridSTT.Caption = "STT";
            this.gridSTT.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridSTT.MinWidth = 40;
            this.gridSTT.Name = "gridSTT";
            this.gridSTT.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False;
            this.gridSTT.OptionsColumn.FixedWidth = true;
            this.gridSTT.OptionsColumn.ReadOnly = true;
            this.gridSTT.OptionsFilter.AllowAutoFilter = false;
            this.gridSTT.OptionsFilter.AllowFilter = false;
            this.gridSTT.OptionsFilter.FilterBySortField = DevExpress.Utils.DefaultBoolean.False;
            this.gridSTT.Visible = true;
            this.gridSTT.VisibleIndex = 0;
            this.gridSTT.Width = 40;
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
            this.gridStaffCode.SortMode = DevExpress.XtraGrid.ColumnSortMode.Value;
            this.gridStaffCode.Visible = true;
            this.gridStaffCode.VisibleIndex = 1;
            this.gridStaffCode.Width = 70;
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
            this.gridFullName.MinWidth = 100;
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
            this.gridBirthDate.MinWidth = 80;
            this.gridBirthDate.Name = "gridBirthDate";
            this.gridBirthDate.Visible = true;
            this.gridBirthDate.VisibleIndex = 3;
            this.gridBirthDate.Width = 80;
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
            this.gridSex.MinWidth = 60;
            this.gridSex.Name = "gridSex";
            this.gridSex.Visible = true;
            this.gridSex.VisibleIndex = 4;
            this.gridSex.Width = 60;
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
            this.gridEntryDate.MinWidth = 90;
            this.gridEntryDate.Name = "gridEntryDate";
            this.gridEntryDate.Visible = true;
            this.gridEntryDate.VisibleIndex = 5;
            this.gridEntryDate.Width = 90;
            // 
            // gridPosName
            // 
            this.gridPosName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridPosName.AppearanceHeader.Options.UseFont = true;
            this.gridPosName.AppearanceHeader.Options.UseTextOptions = true;
            this.gridPosName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridPosName.Caption = "Chức vụ";
            this.gridPosName.FieldName = "PosName";
            this.gridPosName.MinWidth = 90;
            this.gridPosName.Name = "gridPosName";
            this.gridPosName.Visible = true;
            this.gridPosName.VisibleIndex = 6;
            this.gridPosName.Width = 90;
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
            this.gridDeptCode.MinWidth = 60;
            this.gridDeptCode.Name = "gridDeptCode";
            this.gridDeptCode.Visible = true;
            this.gridDeptCode.VisibleIndex = 7;
            this.gridDeptCode.Width = 60;
            // 
            // gridTrainingContent
            // 
            this.gridTrainingContent.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridTrainingContent.AppearanceHeader.Options.UseFont = true;
            this.gridTrainingContent.AppearanceHeader.Options.UseTextOptions = true;
            this.gridTrainingContent.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridTrainingContent.Caption = "Nội dung đào tạo";
            this.gridTrainingContent.FieldName = "TrainingContent";
            this.gridTrainingContent.MinWidth = 150;
            this.gridTrainingContent.Name = "gridTrainingContent";
            this.gridTrainingContent.Visible = true;
            this.gridTrainingContent.VisibleIndex = 8;
            this.gridTrainingContent.Width = 150;
            // 
            // gridTrainingType
            // 
            this.gridTrainingType.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridTrainingType.AppearanceHeader.Options.UseFont = true;
            this.gridTrainingType.AppearanceHeader.Options.UseTextOptions = true;
            this.gridTrainingType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridTrainingType.Caption = "Loại hình đào tạo";
            this.gridTrainingType.FieldName = "TrainingType";
            this.gridTrainingType.MinWidth = 150;
            this.gridTrainingType.Name = "gridTrainingType";
            this.gridTrainingType.Visible = true;
            this.gridTrainingType.VisibleIndex = 9;
            this.gridTrainingType.Width = 150;
            // 
            // gridStartDate
            // 
            this.gridStartDate.AppearanceCell.Options.UseTextOptions = true;
            this.gridStartDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridStartDate.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridStartDate.AppearanceHeader.Options.UseFont = true;
            this.gridStartDate.AppearanceHeader.Options.UseTextOptions = true;
            this.gridStartDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridStartDate.Caption = "Ngày bắt đầu";
            this.gridStartDate.FieldName = "TrainingStartDate";
            this.gridStartDate.MinWidth = 100;
            this.gridStartDate.Name = "gridStartDate";
            this.gridStartDate.Visible = true;
            this.gridStartDate.VisibleIndex = 10;
            this.gridStartDate.Width = 100;
            // 
            // gridEndDate
            // 
            this.gridEndDate.AppearanceCell.Options.UseTextOptions = true;
            this.gridEndDate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.gridEndDate.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridEndDate.AppearanceHeader.Options.UseFont = true;
            this.gridEndDate.AppearanceHeader.Options.UseTextOptions = true;
            this.gridEndDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridEndDate.Caption = "Ngày kết thúc";
            this.gridEndDate.FieldName = "TraingEndDate";
            this.gridEndDate.MinWidth = 100;
            this.gridEndDate.Name = "gridEndDate";
            this.gridEndDate.Visible = true;
            this.gridEndDate.VisibleIndex = 11;
            this.gridEndDate.Width = 100;
            // 
            // gridCertificate
            // 
            this.gridCertificate.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridCertificate.AppearanceHeader.Options.UseFont = true;
            this.gridCertificate.AppearanceHeader.Options.UseTextOptions = true;
            this.gridCertificate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridCertificate.Caption = "Chứng chỉ";
            this.gridCertificate.FieldName = "Certificate";
            this.gridCertificate.MinWidth = 100;
            this.gridCertificate.Name = "gridCertificate";
            this.gridCertificate.Visible = true;
            this.gridCertificate.VisibleIndex = 12;
            this.gridCertificate.Width = 100;
            // 
            // gridDeadlineCertificate
            // 
            this.gridDeadlineCertificate.AppearanceCell.Options.UseTextOptions = true;
            this.gridDeadlineCertificate.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridDeadlineCertificate.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridDeadlineCertificate.AppearanceHeader.Options.UseFont = true;
            this.gridDeadlineCertificate.AppearanceHeader.Options.UseTextOptions = true;
            this.gridDeadlineCertificate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridDeadlineCertificate.Caption = "Thời hạn";
            this.gridDeadlineCertificate.FieldName = "DeadlineCertificate";
            this.gridDeadlineCertificate.MinWidth = 100;
            this.gridDeadlineCertificate.Name = "gridDeadlineCertificate";
            this.gridDeadlineCertificate.Visible = true;
            this.gridDeadlineCertificate.VisibleIndex = 13;
            this.gridDeadlineCertificate.Width = 100;
            // 
            // gridNote
            // 
            this.gridNote.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridNote.AppearanceHeader.Options.UseFont = true;
            this.gridNote.AppearanceHeader.Options.UseTextOptions = true;
            this.gridNote.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridNote.Caption = "Ghi chú";
            this.gridNote.FieldName = "Note";
            this.gridNote.MinWidth = 100;
            this.gridNote.Name = "gridNote";
            this.gridNote.Visible = true;
            this.gridNote.VisibleIndex = 14;
            this.gridNote.Width = 100;
            // 
            // splashScreenManager1
            // 
            this.splashScreenManager1.ClosingDelay = 500;
            // 
            // gridID
            // 
            this.gridID.Caption = "ID";
            this.gridID.FieldName = "ID";
            this.gridID.Name = "gridID";
            // 
            // UserControlManagerCertificates
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.groupBox1);
            this.Name = "UserControlManagerCertificates";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(782, 497);
            this.Load += new System.EventHandler(this.UserControlOlympicMeister_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtDept.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.SimpleButton btnExportToExel;
        private DevExpress.XtraEditors.SimpleButton btnRefesh;
        private DevExpress.XtraEditors.SimpleButton btnFind;
        private DevExpress.XtraEditors.GridLookUpEdit txtDept;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridStaffCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridFullName;
        private DevExpress.XtraGrid.Columns.GridColumn gridBirthDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridSex;
        private DevExpress.XtraGrid.Columns.GridColumn gridEntryDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridDeptCode;
        private DevExpress.XtraGrid.Columns.GridColumn gridPosName;
        private DevExpress.XtraGrid.Columns.GridColumn gridTrainingContent;
        private DevExpress.XtraGrid.Columns.GridColumn gridTrainingType;
        private DevExpress.XtraGrid.Columns.GridColumn gridStartDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridEndDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridSTT;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        private DevExpress.XtraGrid.Columns.GridColumn gridCertificate;
        private DevExpress.XtraGrid.Columns.GridColumn gridDeadlineCertificate;
        private DevExpress.XtraGrid.Columns.GridColumn gridNote;
        private DevExpress.XtraGrid.Columns.GridColumn gridID;
    }
}
