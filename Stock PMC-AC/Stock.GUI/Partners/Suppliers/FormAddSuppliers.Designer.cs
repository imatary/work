namespace Stock.GUI.Partners
{
    partial class FormAddSuppliers
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gridLookUpEdit1 = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl19 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl17 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl18 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.txtAddress = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtSupplierName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtPepoleContact = new DevExpress.XtraEditors.TextEdit();
            this.txtAccountNumber = new DevExpress.XtraEditors.TextEdit();
            this.txtEmail = new DevExpress.XtraEditors.TextEdit();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.txtPhone = new DevExpress.XtraEditors.TextEdit();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.txtTaxCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl13 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.txtSupplierID = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtPositions = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtBank = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtWebsite = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtMoblie = new DevExpress.XtraEditors.TextEdit();
            this.txtFax = new DevExpress.XtraEditors.TextEdit();
            this.checkActive = new DevExpress.XtraEditors.CheckEdit();
            this.areaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSupplierName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPepoleContact.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccountNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaxCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSupplierID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPositions.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBank.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWebsite.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMoblie.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFax.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.areaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Image = global::Stock.GUI.Properties.Resources.delete_16;
            this.btnClose.Location = new System.Drawing.Point(507, 309);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 28);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "Đóng (Esc)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::Stock.GUI.Properties.Resources.database_save;
            this.btnSave.Location = new System.Drawing.Point(389, 309);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(112, 28);
            this.btnSave.TabIndex = 16;
            this.btnSave.Text = "Lưu (Ctrl+S)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.gridLookUpEdit1);
            this.groupControl1.Controls.Add(this.labelControl19);
            this.groupControl1.Controls.Add(this.labelControl17);
            this.groupControl1.Controls.Add(this.labelControl18);
            this.groupControl1.Controls.Add(this.labelControl16);
            this.groupControl1.Controls.Add(this.labelControl15);
            this.groupControl1.Controls.Add(this.txtAddress);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.txtSupplierName);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.txtPepoleContact);
            this.groupControl1.Controls.Add(this.txtAccountNumber);
            this.groupControl1.Controls.Add(this.txtEmail);
            this.groupControl1.Controls.Add(this.labelControl14);
            this.groupControl1.Controls.Add(this.txtPhone);
            this.groupControl1.Controls.Add(this.labelControl12);
            this.groupControl1.Controls.Add(this.txtTaxCode);
            this.groupControl1.Controls.Add(this.labelControl13);
            this.groupControl1.Controls.Add(this.labelControl10);
            this.groupControl1.Controls.Add(this.labelControl11);
            this.groupControl1.Controls.Add(this.labelControl8);
            this.groupControl1.Controls.Add(this.labelControl9);
            this.groupControl1.Controls.Add(this.txtSupplierID);
            this.groupControl1.Controls.Add(this.labelControl7);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.txtPositions);
            this.groupControl1.Controls.Add(this.labelControl5);
            this.groupControl1.Controls.Add(this.txtBank);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.txtWebsite);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.txtMoblie);
            this.groupControl1.Controls.Add(this.txtFax);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(10, 10);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Padding = new System.Windows.Forms.Padding(8);
            this.groupControl1.Size = new System.Drawing.Size(587, 293);
            this.groupControl1.TabIndex = 2;
            this.groupControl1.Text = "THÔNG TIN CHUNG";
            // 
            // gridLookUpEdit1
            // 
            this.gridLookUpEdit1.EditValue = "";
            this.gridLookUpEdit1.Location = new System.Drawing.Point(350, 47);
            this.gridLookUpEdit1.Name = "gridLookUpEdit1";
            this.gridLookUpEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.gridLookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "btnShowAddArea", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::Stock.GUI.Properties.Resources.add_16, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.gridLookUpEdit1.Properties.NullText = "";
            this.gridLookUpEdit1.Properties.NullValuePrompt = "Chọn Khu vực";
            this.gridLookUpEdit1.Properties.NullValuePromptShowForEmptyValue = true;
            this.gridLookUpEdit1.Properties.SuppressMouseEventOnOuterMouseClick = true;
            this.gridLookUpEdit1.Properties.View = this.gridLookUpEdit1View;
            this.gridLookUpEdit1.Properties.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.gridLookUpEdit1_Properties_ButtonPressed);
            this.gridLookUpEdit1.Size = new System.Drawing.Size(218, 24);
            this.gridLookUpEdit1.TabIndex = 2;
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Mã";
            this.gridColumn1.FieldName = "AreaID";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            this.gridColumn1.Width = 80;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Tên";
            this.gridColumn2.FieldName = "AreaName";
            this.gridColumn2.MinWidth = 40;
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            this.gridColumn2.Width = 130;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Ghi chú";
            this.gridColumn3.FieldName = "Description";
            this.gridColumn3.MinWidth = 50;
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            this.gridColumn3.Width = 174;
            // 
            // labelControl19
            // 
            this.labelControl19.Location = new System.Drawing.Point(119, 267);
            this.labelControl19.Name = "labelControl19";
            this.labelControl19.Size = new System.Drawing.Size(210, 13);
            this.labelControl19.TabIndex = 3;
            this.labelControl19.Text = "Vui lòng nhập vào những thông tin bắt buộc";
            // 
            // labelControl17
            // 
            this.labelControl17.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl17.Location = new System.Drawing.Point(334, 50);
            this.labelControl17.Name = "labelControl17";
            this.labelControl17.Size = new System.Drawing.Size(14, 13);
            this.labelControl17.TabIndex = 2;
            this.labelControl17.Text = "(*)";
            // 
            // labelControl18
            // 
            this.labelControl18.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl18.Location = new System.Drawing.Point(98, 267);
            this.labelControl18.Name = "labelControl18";
            this.labelControl18.Size = new System.Drawing.Size(14, 13);
            this.labelControl18.TabIndex = 2;
            this.labelControl18.Text = "(*)";
            // 
            // labelControl16
            // 
            this.labelControl16.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl16.Location = new System.Drawing.Point(47, 78);
            this.labelControl16.Name = "labelControl16";
            this.labelControl16.Size = new System.Drawing.Size(14, 13);
            this.labelControl16.TabIndex = 2;
            this.labelControl16.Text = "(*)";
            // 
            // labelControl15
            // 
            this.labelControl15.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl15.Location = new System.Drawing.Point(44, 50);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(14, 13);
            this.labelControl15.TabIndex = 2;
            this.labelControl15.Text = "(*)";
            // 
            // txtAddress
            // 
            this.txtAddress.EditValue = "";
            this.txtAddress.Location = new System.Drawing.Point(98, 101);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtAddress.Properties.NullValuePrompt = "Địa chỉ nhà cung cấp";
            this.txtAddress.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtAddress.Size = new System.Drawing.Size(470, 22);
            this.txtAddress.TabIndex = 4;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(23, 104);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(32, 13);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Địa chỉ";
            // 
            // txtSupplierName
            // 
            this.txtSupplierName.Location = new System.Drawing.Point(98, 75);
            this.txtSupplierName.Name = "txtSupplierName";
            this.txtSupplierName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtSupplierName.Properties.NullValuePrompt = "Tên nhà cung cấp";
            this.txtSupplierName.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtSupplierName.Size = new System.Drawing.Size(470, 22);
            this.txtSupplierName.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(23, 78);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(18, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Tên";
            // 
            // txtPepoleContact
            // 
            this.txtPepoleContact.Location = new System.Drawing.Point(98, 232);
            this.txtPepoleContact.Name = "txtPepoleContact";
            this.txtPepoleContact.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtPepoleContact.Properties.NullValuePrompt = "Người liên hệ";
            this.txtPepoleContact.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtPepoleContact.Size = new System.Drawing.Size(175, 22);
            this.txtPepoleContact.TabIndex = 13;
            // 
            // txtAccountNumber
            // 
            this.txtAccountNumber.Location = new System.Drawing.Point(98, 206);
            this.txtAccountNumber.Name = "txtAccountNumber";
            this.txtAccountNumber.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtAccountNumber.Properties.NullValuePrompt = "Tài khoản ngân hàng";
            this.txtAccountNumber.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtAccountNumber.Size = new System.Drawing.Size(175, 22);
            this.txtAccountNumber.TabIndex = 11;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(98, 180);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtEmail.Properties.NullValuePrompt = "Email nhà cung cấp";
            this.txtEmail.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtEmail.Size = new System.Drawing.Size(175, 22);
            this.txtEmail.TabIndex = 9;
            // 
            // labelControl14
            // 
            this.labelControl14.Location = new System.Drawing.Point(289, 235);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(40, 13);
            this.labelControl14.TabIndex = 0;
            this.labelControl14.Text = "Chức vụ";
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(98, 154);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtPhone.Properties.NullValuePrompt = "Số điện thoại của nhà cung cấp";
            this.txtPhone.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtPhone.Size = new System.Drawing.Size(175, 22);
            this.txtPhone.TabIndex = 7;
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(289, 209);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(52, 13);
            this.labelControl12.TabIndex = 0;
            this.labelControl12.Text = "Ngân hàng";
            // 
            // txtTaxCode
            // 
            this.txtTaxCode.Location = new System.Drawing.Point(98, 128);
            this.txtTaxCode.Name = "txtTaxCode";
            this.txtTaxCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtTaxCode.Properties.NullValuePrompt = "Mã số thuế của nhà cung cấp";
            this.txtTaxCode.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtTaxCode.Size = new System.Drawing.Size(175, 22);
            this.txtTaxCode.TabIndex = 5;
            // 
            // labelControl13
            // 
            this.labelControl13.Location = new System.Drawing.Point(23, 235);
            this.labelControl13.Name = "labelControl13";
            this.labelControl13.Size = new System.Drawing.Size(62, 13);
            this.labelControl13.TabIndex = 0;
            this.labelControl13.Text = "Người liên hệ";
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(289, 183);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(39, 13);
            this.labelControl10.TabIndex = 0;
            this.labelControl10.Text = "Website";
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(23, 209);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(46, 13);
            this.labelControl11.TabIndex = 0;
            this.labelControl11.Text = "Tài khoản";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(289, 157);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(30, 13);
            this.labelControl8.TabIndex = 0;
            this.labelControl8.Text = "Moblie";
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(23, 183);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(24, 13);
            this.labelControl9.TabIndex = 0;
            this.labelControl9.Text = "Email";
            // 
            // txtSupplierID
            // 
            this.txtSupplierID.Location = new System.Drawing.Point(98, 49);
            this.txtSupplierID.Name = "txtSupplierID";
            this.txtSupplierID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtSupplierID.Properties.NullValuePrompt = "Mã nhà cung cấp";
            this.txtSupplierID.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtSupplierID.Size = new System.Drawing.Size(175, 22);
            this.txtSupplierID.TabIndex = 1;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(23, 157);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(49, 13);
            this.labelControl7.TabIndex = 0;
            this.labelControl7.Text = "Điện thoại";
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(289, 131);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(18, 13);
            this.labelControl6.TabIndex = 0;
            this.labelControl6.Text = "Fax";
            // 
            // txtPositions
            // 
            this.txtPositions.Location = new System.Drawing.Point(350, 232);
            this.txtPositions.Name = "txtPositions";
            this.txtPositions.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtPositions.Properties.NullValuePrompt = "Chức vụ của người liên hệ";
            this.txtPositions.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtPositions.Size = new System.Drawing.Size(218, 22);
            this.txtPositions.TabIndex = 14;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(23, 131);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(53, 13);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "Mã số thuế";
            // 
            // txtBank
            // 
            this.txtBank.Location = new System.Drawing.Point(350, 206);
            this.txtBank.Name = "txtBank";
            this.txtBank.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtBank.Properties.NullValuePrompt = "Ngân hàng";
            this.txtBank.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtBank.Size = new System.Drawing.Size(218, 22);
            this.txtBank.TabIndex = 12;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(289, 52);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(39, 13);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Khu Vực";
            // 
            // txtWebsite
            // 
            this.txtWebsite.Location = new System.Drawing.Point(350, 180);
            this.txtWebsite.Name = "txtWebsite";
            this.txtWebsite.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtWebsite.Properties.NullValuePrompt = "Website nhà cung cấp";
            this.txtWebsite.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtWebsite.Size = new System.Drawing.Size(218, 22);
            this.txtWebsite.TabIndex = 10;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(23, 52);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(14, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Mã";
            // 
            // txtMoblie
            // 
            this.txtMoblie.Location = new System.Drawing.Point(350, 154);
            this.txtMoblie.Name = "txtMoblie";
            this.txtMoblie.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtMoblie.Properties.NullValuePrompt = "Số điện thoại di động";
            this.txtMoblie.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtMoblie.Size = new System.Drawing.Size(218, 22);
            this.txtMoblie.TabIndex = 8;
            // 
            // txtFax
            // 
            this.txtFax.Location = new System.Drawing.Point(350, 128);
            this.txtFax.Name = "txtFax";
            this.txtFax.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtFax.Properties.NullValuePrompt = "Số Fax";
            this.txtFax.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtFax.Size = new System.Drawing.Size(218, 22);
            this.txtFax.TabIndex = 6;
            // 
            // checkActive
            // 
            this.checkActive.EditValue = true;
            this.checkActive.Location = new System.Drawing.Point(10, 313);
            this.checkActive.Name = "checkActive";
            this.checkActive.Properties.Caption = "Còn quản lý";
            this.checkActive.Size = new System.Drawing.Size(132, 19);
            this.checkActive.TabIndex = 15;
            // 
            // areaBindingSource
            // 
            this.areaBindingSource.DataSource = typeof(Stock.Data.Area);
            // 
            // FormAddSuppliers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 349);
            this.Controls.Add(this.checkActive);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAddSuppliers";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "THÊM NHÀ CUNG CẤP";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAddSuppliers_FormClosing);
            this.Load += new System.EventHandler(this.FormAddSuppliers_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormAddSuppliers_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSupplierName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPepoleContact.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAccountNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTaxCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSupplierID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPositions.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBank.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtWebsite.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMoblie.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFax.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.areaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.CheckEdit checkActive;
        private DevExpress.XtraEditors.TextEdit txtSupplierName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtSupplierID;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtAddress;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtTaxCode;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtFax;
        private DevExpress.XtraEditors.TextEdit txtPepoleContact;
        private DevExpress.XtraEditors.TextEdit txtAccountNumber;
        private DevExpress.XtraEditors.TextEdit txtEmail;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private DevExpress.XtraEditors.TextEdit txtPhone;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.LabelControl labelControl13;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit txtPositions;
        private DevExpress.XtraEditors.TextEdit txtBank;
        private DevExpress.XtraEditors.TextEdit txtWebsite;
        private DevExpress.XtraEditors.TextEdit txtMoblie;
        private DevExpress.XtraEditors.LabelControl labelControl17;
        private DevExpress.XtraEditors.LabelControl labelControl16;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        private DevExpress.XtraEditors.LabelControl labelControl19;
        private DevExpress.XtraEditors.LabelControl labelControl18;
        private DevExpress.XtraEditors.GridLookUpEdit gridLookUpEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private System.Windows.Forms.BindingSource areaBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
    }
}