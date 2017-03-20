namespace EducationSkills.Modules
{
    partial class UserControlReportsEye
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserControlReportsEye));
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnExportToExel = new DevExpress.XtraEditors.SimpleButton();
            this.btnRefesh = new DevExpress.XtraEditors.SimpleButton();
            this.btnFind = new DevExpress.XtraEditors.SimpleButton();
            this.txtDept = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::EducationSkills.ShowWait), true, true, typeof(System.Windows.Forms.UserControl));
            this.gridStaffCode = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridFullName = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridDeptCode = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridCapDo = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridLevelDateI = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridLevelII = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridLevelDateII = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridLevelIII = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridLevelDateIII = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridCertifiedTrainer = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridTrainingDate = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridTestDate = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridTestDateActual = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridTestResult = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridNumberTest = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn();
            this.gridBand6 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand4 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand5 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand3 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.gridBand2 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.bandedGridView1 = new DevExpress.XtraGrid.Views.BandedGrid.BandedGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDept.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnExportToExel);
            this.groupBox1.Controls.Add(this.btnRefesh);
            this.groupBox1.Controls.Add(this.btnFind);
            this.groupBox1.Controls.Add(this.txtDept);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(876, 103);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Options";
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
            this.btnRefesh.Text = "Refesh";
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
            this.txtDept.Properties.NullValuePrompt = "Select Dept";
            this.txtDept.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtDept.Properties.ValueMember = "DeptCode";
            this.txtDept.Properties.View = this.gridLookUpEdit1View;
            this.txtDept.Size = new System.Drawing.Size(271, 28);
            this.txtDept.TabIndex = 5;
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
            gridLevelNode1.RelationName = "Level1";
            this.gridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl1.Location = new System.Drawing.Point(10, 113);
            this.gridControl1.MainView = this.bandedGridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(876, 444);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.UseEmbeddedNavigator = true;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.bandedGridView1});
            // 
            // splashScreenManager1
            // 
            this.splashScreenManager1.ClosingDelay = 500;
            // 
            // gridStaffCode
            // 
            this.gridStaffCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridStaffCode.AppearanceHeader.Options.UseFont = true;
            this.gridStaffCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gridStaffCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridStaffCode.Caption = "Code";
            this.gridStaffCode.FieldName = "StaffCode";
            this.gridStaffCode.MinWidth = 80;
            this.gridStaffCode.Name = "gridStaffCode";
            this.gridStaffCode.Visible = true;
            this.gridStaffCode.Width = 80;
            // 
            // gridFullName
            // 
            this.gridFullName.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridFullName.AppearanceHeader.Options.UseFont = true;
            this.gridFullName.AppearanceHeader.Options.UseTextOptions = true;
            this.gridFullName.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridFullName.Caption = "Họ & Tên";
            this.gridFullName.FieldName = "FullName";
            this.gridFullName.MinWidth = 100;
            this.gridFullName.Name = "gridFullName";
            this.gridFullName.Visible = true;
            this.gridFullName.Width = 150;
            // 
            // gridDeptCode
            // 
            this.gridDeptCode.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridDeptCode.AppearanceHeader.Options.UseFont = true;
            this.gridDeptCode.AppearanceHeader.Options.UseTextOptions = true;
            this.gridDeptCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridDeptCode.Caption = "Bộ phận";
            this.gridDeptCode.FieldName = "DeptCode";
            this.gridDeptCode.MinWidth = 80;
            this.gridDeptCode.Name = "gridDeptCode";
            this.gridDeptCode.Visible = true;
            this.gridDeptCode.Width = 80;
            // 
            // gridCapDo
            // 
            this.gridCapDo.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridCapDo.AppearanceHeader.Options.UseFont = true;
            this.gridCapDo.AppearanceHeader.Options.UseTextOptions = true;
            this.gridCapDo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridCapDo.Caption = "Cấp độ";
            this.gridCapDo.FieldName = "CapDo";
            this.gridCapDo.MinWidth = 100;
            this.gridCapDo.Name = "gridCapDo";
            this.gridCapDo.Visible = true;
            this.gridCapDo.Width = 100;
            // 
            // gridLevelDateI
            // 
            this.gridLevelDateI.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridLevelDateI.AppearanceHeader.Options.UseFont = true;
            this.gridLevelDateI.AppearanceHeader.Options.UseTextOptions = true;
            this.gridLevelDateI.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridLevelDateI.Caption = "Ngày cấp";
            this.gridLevelDateI.FieldName = "NgayCap";
            this.gridLevelDateI.MinWidth = 100;
            this.gridLevelDateI.Name = "gridLevelDateI";
            this.gridLevelDateI.Visible = true;
            this.gridLevelDateI.Width = 100;
            // 
            // gridLevelII
            // 
            this.gridLevelII.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridLevelII.AppearanceHeader.Options.UseFont = true;
            this.gridLevelII.AppearanceHeader.Options.UseTextOptions = true;
            this.gridLevelII.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridLevelII.Caption = "Cấp độ";
            this.gridLevelII.FieldName = "NangCap";
            this.gridLevelII.MinWidth = 100;
            this.gridLevelII.Name = "gridLevelII";
            this.gridLevelII.Visible = true;
            this.gridLevelII.Width = 100;
            // 
            // gridLevelDateII
            // 
            this.gridLevelDateII.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridLevelDateII.AppearanceHeader.Options.UseFont = true;
            this.gridLevelDateII.AppearanceHeader.Options.UseTextOptions = true;
            this.gridLevelDateII.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridLevelDateII.Caption = "Ngày cấp";
            this.gridLevelDateII.FieldName = "NgayNangCap";
            this.gridLevelDateII.MinWidth = 100;
            this.gridLevelDateII.Name = "gridLevelDateII";
            this.gridLevelDateII.Visible = true;
            this.gridLevelDateII.Width = 100;
            // 
            // gridLevelIII
            // 
            this.gridLevelIII.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridLevelIII.AppearanceHeader.Options.UseFont = true;
            this.gridLevelIII.AppearanceHeader.Options.UseTextOptions = true;
            this.gridLevelIII.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridLevelIII.Caption = "Cấp độ";
            this.gridLevelIII.FieldName = "LoaiChuyenDoi";
            this.gridLevelIII.MinWidth = 100;
            this.gridLevelIII.Name = "gridLevelIII";
            this.gridLevelIII.Visible = true;
            this.gridLevelIII.Width = 100;
            // 
            // gridLevelDateIII
            // 
            this.gridLevelDateIII.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridLevelDateIII.AppearanceHeader.Options.UseFont = true;
            this.gridLevelDateIII.AppearanceHeader.Options.UseTextOptions = true;
            this.gridLevelDateIII.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridLevelDateIII.Caption = "Ngày cấp";
            this.gridLevelDateIII.FieldName = "NgayChuyenDoi";
            this.gridLevelDateIII.Name = "gridLevelDateIII";
            this.gridLevelDateIII.Visible = true;
            this.gridLevelDateIII.Width = 100;
            // 
            // gridCertifiedTrainer
            // 
            this.gridCertifiedTrainer.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridCertifiedTrainer.AppearanceHeader.Options.UseFont = true;
            this.gridCertifiedTrainer.AppearanceHeader.Options.UseTextOptions = true;
            this.gridCertifiedTrainer.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridCertifiedTrainer.Caption = "Cấp độ";
            this.gridCertifiedTrainer.FieldName = "CNNguoiDaoTao";
            this.gridCertifiedTrainer.MinWidth = 100;
            this.gridCertifiedTrainer.Name = "gridCertifiedTrainer";
            this.gridCertifiedTrainer.Visible = true;
            this.gridCertifiedTrainer.Width = 109;
            // 
            // gridTrainingDate
            // 
            this.gridTrainingDate.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridTrainingDate.AppearanceHeader.Options.UseFont = true;
            this.gridTrainingDate.AppearanceHeader.Options.UseTextOptions = true;
            this.gridTrainingDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridTrainingDate.Caption = "Thời gian xác thực";
            this.gridTrainingDate.FieldName = "NgayCNNguoiDaoTao";
            this.gridTrainingDate.MinWidth = 100;
            this.gridTrainingDate.Name = "gridTrainingDate";
            this.gridTrainingDate.Visible = true;
            this.gridTrainingDate.Width = 113;
            // 
            // gridTestDate
            // 
            this.gridTestDate.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridTestDate.AppearanceHeader.Options.UseFont = true;
            this.gridTestDate.AppearanceHeader.Options.UseTextOptions = true;
            this.gridTestDate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridTestDate.Caption = "Ngày thi";
            this.gridTestDate.FieldName = "NgayThi";
            this.gridTestDate.MinWidth = 100;
            this.gridTestDate.Name = "gridTestDate";
            this.gridTestDate.Visible = true;
            this.gridTestDate.Width = 100;
            // 
            // gridTestDateActual
            // 
            this.gridTestDateActual.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridTestDateActual.AppearanceHeader.Options.UseFont = true;
            this.gridTestDateActual.AppearanceHeader.Options.UseTextOptions = true;
            this.gridTestDateActual.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridTestDateActual.Caption = "Ngày thi thực tế";
            this.gridTestDateActual.FieldName = "NgayThiThucTe";
            this.gridTestDateActual.MinWidth = 100;
            this.gridTestDateActual.Name = "gridTestDateActual";
            this.gridTestDateActual.Visible = true;
            this.gridTestDateActual.Width = 111;
            // 
            // gridTestResult
            // 
            this.gridTestResult.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridTestResult.AppearanceHeader.Options.UseFont = true;
            this.gridTestResult.AppearanceHeader.Options.UseTextOptions = true;
            this.gridTestResult.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridTestResult.Caption = "Kết quả thi";
            this.gridTestResult.FieldName = "KetQuaThi";
            this.gridTestResult.MinWidth = 100;
            this.gridTestResult.Name = "gridTestResult";
            this.gridTestResult.Visible = true;
            this.gridTestResult.Width = 100;
            // 
            // gridNumberTest
            // 
            this.gridNumberTest.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridNumberTest.AppearanceHeader.Options.UseFont = true;
            this.gridNumberTest.AppearanceHeader.Options.UseTextOptions = true;
            this.gridNumberTest.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridNumberTest.Caption = "Số lần thi";
            this.gridNumberTest.FieldName = "Solanthi";
            this.gridNumberTest.MinWidth = 100;
            this.gridNumberTest.Name = "gridNumberTest";
            this.gridNumberTest.Visible = true;
            this.gridNumberTest.Width = 100;
            // 
            // gridBand6
            // 
            this.gridBand6.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridBand6.AppearanceHeader.Options.UseFont = true;
            this.gridBand6.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand6.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand6.Caption = "Kết quả";
            this.gridBand6.Columns.Add(this.gridTestDate);
            this.gridBand6.Columns.Add(this.gridTestResult);
            this.gridBand6.Columns.Add(this.gridNumberTest);
            this.gridBand6.Name = "gridBand6";
            this.gridBand6.VisibleIndex = 5;
            this.gridBand6.Width = 300;
            // 
            // gridBand4
            // 
            this.gridBand4.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridBand4.AppearanceHeader.Options.UseFont = true;
            this.gridBand4.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand4.Caption = "Cấp độ III";
            this.gridBand4.Columns.Add(this.gridLevelIII);
            this.gridBand4.Columns.Add(this.gridLevelDateIII);
            this.gridBand4.Name = "gridBand4";
            this.gridBand4.VisibleIndex = 4;
            this.gridBand4.Width = 200;
            // 
            // gridBand5
            // 
            this.gridBand5.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridBand5.AppearanceHeader.Options.UseFont = true;
            this.gridBand5.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand5.Caption = "Cấp độ II";
            this.gridBand5.Columns.Add(this.gridLevelII);
            this.gridBand5.Columns.Add(this.gridLevelDateII);
            this.gridBand5.Name = "gridBand5";
            this.gridBand5.VisibleIndex = 3;
            this.gridBand5.Width = 200;
            // 
            // gridBand1
            // 
            this.gridBand1.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridBand1.AppearanceHeader.Options.UseFont = true;
            this.gridBand1.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand1.Caption = "Cấp độ I";
            this.gridBand1.Columns.Add(this.gridCapDo);
            this.gridBand1.Columns.Add(this.gridLevelDateI);
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.VisibleIndex = 2;
            this.gridBand1.Width = 200;
            // 
            // gridBand3
            // 
            this.gridBand3.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridBand3.AppearanceHeader.Options.UseFont = true;
            this.gridBand3.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand3.Caption = "Cấp độ hiện tại";
            this.gridBand3.Columns.Add(this.gridCertifiedTrainer);
            this.gridBand3.Columns.Add(this.gridTrainingDate);
            this.gridBand3.Columns.Add(this.gridTestDateActual);
            this.gridBand3.Name = "gridBand3";
            this.gridBand3.VisibleIndex = 1;
            this.gridBand3.Width = 333;
            // 
            // gridBand2
            // 
            this.gridBand2.AppearanceHeader.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gridBand2.AppearanceHeader.Options.UseFont = true;
            this.gridBand2.AppearanceHeader.Options.UseTextOptions = true;
            this.gridBand2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridBand2.Caption = "Thông tin";
            this.gridBand2.Columns.Add(this.gridStaffCode);
            this.gridBand2.Columns.Add(this.gridFullName);
            this.gridBand2.Columns.Add(this.gridDeptCode);
            this.gridBand2.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.gridBand2.Name = "gridBand2";
            this.gridBand2.VisibleIndex = 0;
            this.gridBand2.Width = 310;
            // 
            // bandedGridView1
            // 
            this.bandedGridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand2,
            this.gridBand3,
            this.gridBand1,
            this.gridBand5,
            this.gridBand4,
            this.gridBand6});
            this.bandedGridView1.Columns.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn[] {
            this.gridStaffCode,
            this.gridFullName,
            this.gridDeptCode,
            this.gridCapDo,
            this.gridLevelDateI,
            this.gridLevelII,
            this.gridLevelDateII,
            this.gridLevelIII,
            this.gridLevelDateIII,
            this.gridCertifiedTrainer,
            this.gridTrainingDate,
            this.gridTestDate,
            this.gridTestDateActual,
            this.gridTestResult,
            this.gridNumberTest});
            this.bandedGridView1.GridControl = this.gridControl1;
            this.bandedGridView1.Name = "bandedGridView1";
            this.bandedGridView1.OptionsBehavior.AllowIncrementalSearch = true;
            this.bandedGridView1.OptionsDetail.EnableDetailToolTip = true;
            this.bandedGridView1.OptionsFind.AlwaysVisible = true;
            this.bandedGridView1.OptionsFind.FindDelay = 10000;
            this.bandedGridView1.OptionsFind.FindNullPrompt = "Nhập từ khóa cần tìm kiếm...";
            this.bandedGridView1.OptionsFind.SearchInPreview = true;
            this.bandedGridView1.OptionsSelection.InvertSelection = true;
            this.bandedGridView1.OptionsView.ColumnAutoWidth = false;
            this.bandedGridView1.OptionsView.ShowAutoFilterRow = true;
            this.bandedGridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridStaffCode, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // UserControlReportsEye
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.groupBox1);
            this.Name = "UserControlReportsEye";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(896, 567);
            this.Load += new System.EventHandler(this.UserControlReportsEye_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtDept.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandedGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraEditors.SimpleButton btnExportToExel;
        private DevExpress.XtraEditors.SimpleButton btnRefesh;
        private DevExpress.XtraEditors.SimpleButton btnFind;
        private DevExpress.XtraEditors.GridLookUpEdit txtDept;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridView bandedGridView1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand2;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridStaffCode;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridFullName;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridDeptCode;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand3;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridCertifiedTrainer;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridTrainingDate;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridTestDateActual;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridCapDo;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridLevelDateI;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand5;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridLevelII;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridLevelDateII;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand4;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridLevelIII;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridLevelDateIII;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand6;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridTestDate;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridTestResult;
        private DevExpress.XtraGrid.Views.BandedGrid.BandedGridColumn gridNumberTest;
    }
}
