namespace EducationSkills
{
    partial class FormAddOlympic
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddOlympic));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtSearchKey = new DevExpress.XtraEditors.ButtonEdit();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.lblCode = new DevExpress.XtraEditors.LabelControl();
            this.lblFullName = new DevExpress.XtraEditors.LabelControl();
            this.lblBirthDate = new DevExpress.XtraEditors.LabelControl();
            this.lblSex = new DevExpress.XtraEditors.LabelControl();
            this.lblDeptCode = new DevExpress.XtraEditors.LabelControl();
            this.lblPosName = new DevExpress.XtraEditors.LabelControl();
            this.lblEntryDate = new DevExpress.XtraEditors.LabelControl();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.txtTestContent = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtTestNumber = new DevExpress.XtraEditors.SpinEdit();
            this.txtTestDate = new DevExpress.XtraEditors.DateEdit();
            this.txtTestResults = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::EducationSkills.ShowWait), true, true);
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchKey.Properties)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTestContent.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTestNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTestDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTestDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTestResults.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtSearchKey);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(545, 73);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tìm kiếm mã nhân viên";
            // 
            // txtSearchKey
            // 
            this.txtSearchKey.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchKey.Location = new System.Drawing.Point(125, 19);
            this.txtSearchKey.Name = "txtSearchKey";
            this.txtSearchKey.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchKey.Properties.Appearance.Options.UseFont = true;
            this.txtSearchKey.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            serializableAppearanceObject1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            serializableAppearanceObject1.Options.UseFont = true;
            serializableAppearanceObject2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            serializableAppearanceObject2.Options.UseFont = true;
            serializableAppearanceObject3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            serializableAppearanceObject3.Options.UseFont = true;
            serializableAppearanceObject4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            serializableAppearanceObject4.Options.UseFont = true;
            this.txtSearchKey.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Tìm", 50, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleLeft, ((System.Drawing.Image)(resources.GetObject("txtSearchKey.Properties.Buttons"))), "", new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, true)});
            this.txtSearchKey.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtSearchKey.Properties.NullValuePrompt = "Nhập vào mã nhân viên";
            this.txtSearchKey.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtSearchKey.Size = new System.Drawing.Size(321, 28);
            this.txtSearchKey.TabIndex = 11;
            this.txtSearchKey.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.txtSearchKey_ButtonPressed);
            this.txtSearchKey.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtSearchKey_PreviewKeyDown);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel1);
            this.groupBox2.Location = new System.Drawing.Point(12, 91);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(545, 316);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Thông tin nhân viên";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 22.26345F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 77.73655F));
            this.tableLayoutPanel1.Controls.Add(this.labelControl1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelControl7, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.labelControl2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelControl6, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.labelControl3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelControl5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelControl4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblCode, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblFullName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblBirthDate, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblSex, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblDeptCode, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblPosName, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.lblEntryDate, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.txtTestContent, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.txtTestNumber, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.txtTestDate, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.txtTestResults, 1, 10);
            this.tableLayoutPanel1.Controls.Add(this.labelControl8, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.labelControl9, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.labelControl10, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.labelControl11, 0, 10);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 11;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.090909F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.76431F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.76431F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.76431F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.10101F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(539, 297);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Options.UseTextOptions = true;
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl1.Location = new System.Drawing.Point(3, 3);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(113, 20);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Code:";
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Options.UseTextOptions = true;
            this.labelControl7.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl7.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl7.Location = new System.Drawing.Point(3, 159);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(113, 20);
            this.labelControl7.TabIndex = 7;
            this.labelControl7.Text = "Ngày vào làm:";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Options.UseTextOptions = true;
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl2.Location = new System.Drawing.Point(3, 29);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(113, 20);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Họ && Tên:";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Options.UseTextOptions = true;
            this.labelControl6.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl6.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl6.Location = new System.Drawing.Point(3, 133);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(113, 20);
            this.labelControl6.TabIndex = 6;
            this.labelControl6.Text = "Chức vụ:";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Options.UseTextOptions = true;
            this.labelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl3.Location = new System.Drawing.Point(3, 55);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(113, 20);
            this.labelControl3.TabIndex = 3;
            this.labelControl3.Text = "Ngày sinh:";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Options.UseTextOptions = true;
            this.labelControl5.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl5.Location = new System.Drawing.Point(3, 107);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(113, 20);
            this.labelControl5.TabIndex = 5;
            this.labelControl5.Text = "Bộ phận:";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Options.UseTextOptions = true;
            this.labelControl4.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl4.Location = new System.Drawing.Point(3, 81);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(113, 20);
            this.labelControl4.TabIndex = 4;
            this.labelControl4.Text = "Giới tính:";
            // 
            // lblCode
            // 
            this.lblCode.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCode.Appearance.Options.UseFont = true;
            this.lblCode.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCode.Location = new System.Drawing.Point(122, 3);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(414, 20);
            this.lblCode.TabIndex = 8;
            this.lblCode.Text = "[N/A]";
            // 
            // lblFullName
            // 
            this.lblFullName.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFullName.Appearance.Options.UseFont = true;
            this.lblFullName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblFullName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblFullName.Location = new System.Drawing.Point(122, 29);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(414, 20);
            this.lblFullName.TabIndex = 8;
            this.lblFullName.Text = "[N/A]";
            // 
            // lblBirthDate
            // 
            this.lblBirthDate.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBirthDate.Appearance.Options.UseFont = true;
            this.lblBirthDate.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblBirthDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBirthDate.Location = new System.Drawing.Point(122, 55);
            this.lblBirthDate.Name = "lblBirthDate";
            this.lblBirthDate.Size = new System.Drawing.Size(414, 20);
            this.lblBirthDate.TabIndex = 8;
            this.lblBirthDate.Text = "[N/A]";
            // 
            // lblSex
            // 
            this.lblSex.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSex.Appearance.Options.UseFont = true;
            this.lblSex.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblSex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblSex.Location = new System.Drawing.Point(122, 81);
            this.lblSex.Name = "lblSex";
            this.lblSex.Size = new System.Drawing.Size(414, 20);
            this.lblSex.TabIndex = 8;
            this.lblSex.Text = "[N/A]";
            // 
            // lblDeptCode
            // 
            this.lblDeptCode.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDeptCode.Appearance.Options.UseFont = true;
            this.lblDeptCode.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblDeptCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblDeptCode.Location = new System.Drawing.Point(122, 107);
            this.lblDeptCode.Name = "lblDeptCode";
            this.lblDeptCode.Size = new System.Drawing.Size(414, 20);
            this.lblDeptCode.TabIndex = 8;
            this.lblDeptCode.Text = "[N/A]";
            // 
            // lblPosName
            // 
            this.lblPosName.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPosName.Appearance.Options.UseFont = true;
            this.lblPosName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblPosName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPosName.Location = new System.Drawing.Point(122, 133);
            this.lblPosName.Name = "lblPosName";
            this.lblPosName.Size = new System.Drawing.Size(414, 20);
            this.lblPosName.TabIndex = 8;
            this.lblPosName.Text = "[N/A]";
            // 
            // lblEntryDate
            // 
            this.lblEntryDate.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEntryDate.Appearance.Options.UseFont = true;
            this.lblEntryDate.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblEntryDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblEntryDate.Location = new System.Drawing.Point(122, 159);
            this.lblEntryDate.Name = "lblEntryDate";
            this.lblEntryDate.Size = new System.Drawing.Size(414, 20);
            this.lblEntryDate.TabIndex = 8;
            this.lblEntryDate.Text = "[N/A]";
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(137, 413);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(96, 28);
            this.simpleButton1.TabIndex = 2;
            this.simpleButton1.Text = "Lưu";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // txtTestContent
            // 
            this.txtTestContent.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtTestContent.Location = new System.Drawing.Point(122, 185);
            this.txtTestContent.Name = "txtTestContent";
            this.txtTestContent.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTestContent.Properties.Appearance.Options.UseFont = true;
            this.txtTestContent.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtTestContent.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtTestContent.Properties.Items.AddRange(new object[] {
            "Olympic Hàn",
            "Olympic KTM",
            "Olympic Cắm tay"});
            this.txtTestContent.Properties.NullValuePrompt = "Chọn một nội dung thi";
            this.txtTestContent.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtTestContent.Size = new System.Drawing.Size(321, 24);
            this.txtTestContent.TabIndex = 9;
            // 
            // txtTestNumber
            // 
            this.txtTestNumber.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtTestNumber.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtTestNumber.Location = new System.Drawing.Point(122, 213);
            this.txtTestNumber.Name = "txtTestNumber";
            this.txtTestNumber.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTestNumber.Properties.Appearance.Options.UseFont = true;
            this.txtTestNumber.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtTestNumber.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtTestNumber.Properties.MaxValue = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.txtTestNumber.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtTestNumber.Properties.NullValuePrompt = "ex: 1";
            this.txtTestNumber.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtTestNumber.Size = new System.Drawing.Size(111, 24);
            this.txtTestNumber.TabIndex = 10;
            // 
            // txtTestDate
            // 
            this.txtTestDate.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtTestDate.EditValue = null;
            this.txtTestDate.Location = new System.Drawing.Point(122, 241);
            this.txtTestDate.Name = "txtTestDate";
            this.txtTestDate.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTestDate.Properties.Appearance.Options.UseFont = true;
            this.txtTestDate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtTestDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtTestDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtTestDate.Properties.NullValuePrompt = "Nhập ngày thi";
            this.txtTestDate.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtTestDate.Size = new System.Drawing.Size(221, 24);
            this.txtTestDate.TabIndex = 11;
            // 
            // txtTestResults
            // 
            this.txtTestResults.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtTestResults.Location = new System.Drawing.Point(122, 269);
            this.txtTestResults.Name = "txtTestResults";
            this.txtTestResults.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTestResults.Properties.Appearance.Options.UseFont = true;
            this.txtTestResults.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtTestResults.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtTestResults.Properties.Items.AddRange(new object[] {
            "Giải Nhất",
            "Giải Nhì",
            "Giải Ba"});
            this.txtTestResults.Properties.NullValuePrompt = "Chọn một thành tích";
            this.txtTestResults.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtTestResults.Size = new System.Drawing.Size(321, 24);
            this.txtTestResults.TabIndex = 12;
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Options.UseTextOptions = true;
            this.labelControl8.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl8.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl8.Location = new System.Drawing.Point(3, 185);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(113, 22);
            this.labelControl8.TabIndex = 7;
            this.labelControl8.Text = "Nội dung thi Olympic:";
            // 
            // labelControl9
            // 
            this.labelControl9.Appearance.Options.UseTextOptions = true;
            this.labelControl9.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl9.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl9.Location = new System.Drawing.Point(3, 213);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(113, 22);
            this.labelControl9.TabIndex = 7;
            this.labelControl9.Text = "Lần tổ chức:";
            // 
            // labelControl10
            // 
            this.labelControl10.Appearance.Options.UseTextOptions = true;
            this.labelControl10.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl10.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl10.Location = new System.Drawing.Point(3, 241);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(113, 22);
            this.labelControl10.TabIndex = 7;
            this.labelControl10.Text = "Ngày thi:";
            // 
            // labelControl11
            // 
            this.labelControl11.Appearance.Options.UseTextOptions = true;
            this.labelControl11.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl11.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl11.Location = new System.Drawing.Point(3, 269);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(113, 25);
            this.labelControl11.TabIndex = 7;
            this.labelControl11.Text = "Thành tích:";
            // 
            // splashScreenManager1
            // 
            this.splashScreenManager1.ClosingDelay = 500;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(125, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(336, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Note: Nhập vào mã nhân viên, sau đó gõ ENTER hoặc nhấn nút Tìm";
            // 
            // FormAddOlympic
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 449);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAddOlympic";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Olympic";
            this.Load += new System.EventHandler(this.FormAddOlympic_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearchKey.Properties)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTestContent.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTestNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTestDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTestDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTestResults.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.ButtonEdit txtSearchKey;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl lblCode;
        private DevExpress.XtraEditors.LabelControl lblFullName;
        private DevExpress.XtraEditors.LabelControl lblBirthDate;
        private DevExpress.XtraEditors.LabelControl lblSex;
        private DevExpress.XtraEditors.LabelControl lblDeptCode;
        private DevExpress.XtraEditors.LabelControl lblPosName;
        private DevExpress.XtraEditors.LabelControl lblEntryDate;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.ComboBoxEdit txtTestContent;
        private DevExpress.XtraEditors.SpinEdit txtTestNumber;
        private DevExpress.XtraEditors.DateEdit txtTestDate;
        private DevExpress.XtraEditors.ComboBoxEdit txtTestResults;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        private System.Windows.Forms.Label label1;
    }
}