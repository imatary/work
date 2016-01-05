namespace Stock.GUI.Partners
{
    partial class FormUpdateEmployee
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
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl16 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.txtEmployeeName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtEmployeeCode = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.txtEmployeeID = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.gridLookUpEdit1 = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnDepartmentID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnDepartmentName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl19 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl17 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl18 = new DevExpress.XtraEditors.LabelControl();
            this.txtAddress = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtEmail = new DevExpress.XtraEditors.TextEdit();
            this.txtPhone = new DevExpress.XtraEditors.TextEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtMoblie = new DevExpress.XtraEditors.TextEdit();
            this.checkActive = new DevExpress.XtraEditors.CheckEdit();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtPosition = new DevExpress.XtraEditors.TextEdit();
            this.labelControl20 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmployeeName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmployeeCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmployeeID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMoblie.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkActive.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPosition.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Image = global::Stock.GUI.Properties.Resources.delete_16;
            this.btnClose.Location = new System.Drawing.Point(462, 326);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 28);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Đóng (Esc)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::Stock.GUI.Properties.Resources.database_save;
            this.btnSave.Location = new System.Drawing.Point(364, 326);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(92, 28);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Lưu (Ctrl+S)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.labelControl16);
            this.groupControl1.Controls.Add(this.labelControl10);
            this.groupControl1.Controls.Add(this.labelControl15);
            this.groupControl1.Controls.Add(this.txtEmployeeName);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.txtEmployeeCode);
            this.groupControl1.Controls.Add(this.labelControl6);
            this.groupControl1.Controls.Add(this.txtEmployeeID);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(10, 10);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(3, 3, 3, 20);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Padding = new System.Windows.Forms.Padding(8);
            this.groupControl1.Size = new System.Drawing.Size(541, 112);
            this.groupControl1.TabIndex = 2;
            this.groupControl1.Text = "THÔNG TIN CƠ BẢN";
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
            // labelControl10
            // 
            this.labelControl10.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl10.Location = new System.Drawing.Point(300, 50);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(14, 13);
            this.labelControl10.TabIndex = 2;
            this.labelControl10.Text = "(*)";
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
            // txtEmployeeName
            // 
            this.txtEmployeeName.Location = new System.Drawing.Point(98, 75);
            this.txtEmployeeName.Name = "txtEmployeeName";
            this.txtEmployeeName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtEmployeeName.Properties.NullValuePrompt = "Tên Nhân Viên";
            this.txtEmployeeName.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtEmployeeName.Size = new System.Drawing.Size(430, 22);
            this.txtEmployeeName.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(23, 78);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(18, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Tên";
            // 
            // txtEmployeeCode
            // 
            this.txtEmployeeCode.Location = new System.Drawing.Point(331, 49);
            this.txtEmployeeCode.Name = "txtEmployeeCode";
            this.txtEmployeeCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtEmployeeCode.Properties.NullValuePrompt = "Mã Code của Nhân viên";
            this.txtEmployeeCode.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtEmployeeCode.Size = new System.Drawing.Size(197, 22);
            this.txtEmployeeCode.TabIndex = 2;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(269, 52);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(25, 13);
            this.labelControl6.TabIndex = 0;
            this.labelControl6.Text = "Code";
            // 
            // txtEmployeeID
            // 
            this.txtEmployeeID.Enabled = false;
            this.txtEmployeeID.Location = new System.Drawing.Point(98, 49);
            this.txtEmployeeID.Name = "txtEmployeeID";
            this.txtEmployeeID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtEmployeeID.Properties.NullValuePrompt = "Mã Nhân Viên";
            this.txtEmployeeID.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtEmployeeID.Size = new System.Drawing.Size(155, 22);
            this.txtEmployeeID.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(23, 52);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(14, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Mã";
            // 
            // gridLookUpEdit1
            // 
            this.gridLookUpEdit1.EditValue = "";
            this.gridLookUpEdit1.Location = new System.Drawing.Point(98, 128);
            this.gridLookUpEdit1.Name = "gridLookUpEdit1";
            this.gridLookUpEdit1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.gridLookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "btnShowAddArea", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::Stock.GUI.Properties.Resources.add_16, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.gridLookUpEdit1.Properties.NullText = "";
            this.gridLookUpEdit1.Properties.NullValuePrompt = "Chọn Bộ Phận cho Nhân viên";
            this.gridLookUpEdit1.Properties.NullValuePromptShowForEmptyValue = true;
            this.gridLookUpEdit1.Properties.SuppressMouseEventOnOuterMouseClick = true;
            this.gridLookUpEdit1.Properties.View = this.gridLookUpEdit1View;
            this.gridLookUpEdit1.Properties.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.gridLookUpEdit1_Properties_ButtonPressed);
            this.gridLookUpEdit1.Size = new System.Drawing.Size(430, 24);
            this.gridLookUpEdit1.TabIndex = 9;
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnDepartmentID,
            this.gridColumnDepartmentName,
            this.gridColumnDescription});
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumnDepartmentID
            // 
            this.gridColumnDepartmentID.Caption = "Mã";
            this.gridColumnDepartmentID.FieldName = "DepartmentID";
            this.gridColumnDepartmentID.Name = "gridColumnDepartmentID";
            this.gridColumnDepartmentID.Visible = true;
            this.gridColumnDepartmentID.VisibleIndex = 0;
            this.gridColumnDepartmentID.Width = 80;
            // 
            // gridColumnDepartmentName
            // 
            this.gridColumnDepartmentName.Caption = "Tên";
            this.gridColumnDepartmentName.FieldName = "DepartmentName";
            this.gridColumnDepartmentName.MinWidth = 40;
            this.gridColumnDepartmentName.Name = "gridColumnDepartmentName";
            this.gridColumnDepartmentName.Visible = true;
            this.gridColumnDepartmentName.VisibleIndex = 1;
            this.gridColumnDepartmentName.Width = 130;
            // 
            // gridColumnDescription
            // 
            this.gridColumnDescription.Caption = "Ghi chú";
            this.gridColumnDescription.FieldName = "Description";
            this.gridColumnDescription.MinWidth = 50;
            this.gridColumnDescription.Name = "gridColumnDescription";
            this.gridColumnDescription.Visible = true;
            this.gridColumnDescription.VisibleIndex = 2;
            this.gridColumnDescription.Width = 174;
            // 
            // labelControl19
            // 
            this.labelControl19.Location = new System.Drawing.Point(118, 164);
            this.labelControl19.Name = "labelControl19";
            this.labelControl19.Size = new System.Drawing.Size(210, 13);
            this.labelControl19.TabIndex = 3;
            this.labelControl19.Text = "Vui lòng nhập vào những thông tin bắt buộc";
            // 
            // labelControl17
            // 
            this.labelControl17.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl17.Location = new System.Drawing.Point(279, 303);
            this.labelControl17.Name = "labelControl17";
            this.labelControl17.Size = new System.Drawing.Size(14, 13);
            this.labelControl17.TabIndex = 2;
            this.labelControl17.Text = "(*)";
            // 
            // labelControl18
            // 
            this.labelControl18.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl18.Location = new System.Drawing.Point(98, 164);
            this.labelControl18.Name = "labelControl18";
            this.labelControl18.Size = new System.Drawing.Size(14, 13);
            this.labelControl18.TabIndex = 2;
            this.labelControl18.Text = "(*)";
            // 
            // txtAddress
            // 
            this.txtAddress.EditValue = "";
            this.txtAddress.Location = new System.Drawing.Point(98, 24);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtAddress.Properties.NullValuePrompt = "Địa chỉ của Nhân viên";
            this.txtAddress.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtAddress.Size = new System.Drawing.Size(430, 22);
            this.txtAddress.TabIndex = 4;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(23, 27);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(34, 13);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "Địa Chỉ";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(98, 76);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtEmail.Properties.NullValuePrompt = "Email của nhân viên";
            this.txtEmail.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtEmail.Size = new System.Drawing.Size(430, 22);
            this.txtEmail.TabIndex = 6;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(98, 102);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtPhone.Properties.NullValuePrompt = "Số điện thoại của nhân viên";
            this.txtPhone.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtPhone.Size = new System.Drawing.Size(155, 22);
            this.txtPhone.TabIndex = 7;
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(269, 105);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(36, 13);
            this.labelControl8.TabIndex = 0;
            this.labelControl8.Text = "Di động";
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(23, 79);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(24, 13);
            this.labelControl9.TabIndex = 0;
            this.labelControl9.Text = "Email";
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(23, 105);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(49, 13);
            this.labelControl7.TabIndex = 0;
            this.labelControl7.Text = "Điện thoại";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(23, 132);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(39, 13);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Bộ Phận";
            // 
            // txtMoblie
            // 
            this.txtMoblie.Location = new System.Drawing.Point(331, 102);
            this.txtMoblie.Name = "txtMoblie";
            this.txtMoblie.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtMoblie.Properties.NullValuePrompt = "Số điện thoại di động";
            this.txtMoblie.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtMoblie.Size = new System.Drawing.Size(197, 22);
            this.txtMoblie.TabIndex = 8;
            // 
            // checkActive
            // 
            this.checkActive.EditValue = true;
            this.checkActive.Location = new System.Drawing.Point(10, 330);
            this.checkActive.Name = "checkActive";
            this.checkActive.Properties.Caption = "Còn quản lý";
            this.checkActive.Size = new System.Drawing.Size(132, 19);
            this.checkActive.TabIndex = 10;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.labelControl5);
            this.groupControl2.Controls.Add(this.txtPosition);
            this.groupControl2.Controls.Add(this.labelControl20);
            this.groupControl2.Controls.Add(this.gridLookUpEdit1);
            this.groupControl2.Controls.Add(this.labelControl18);
            this.groupControl2.Controls.Add(this.labelControl19);
            this.groupControl2.Controls.Add(this.txtAddress);
            this.groupControl2.Controls.Add(this.labelControl4);
            this.groupControl2.Controls.Add(this.txtEmail);
            this.groupControl2.Controls.Add(this.labelControl9);
            this.groupControl2.Controls.Add(this.txtPhone);
            this.groupControl2.Controls.Add(this.labelControl3);
            this.groupControl2.Controls.Add(this.labelControl7);
            this.groupControl2.Controls.Add(this.txtMoblie);
            this.groupControl2.Controls.Add(this.labelControl8);
            this.groupControl2.Location = new System.Drawing.Point(10, 128);
            this.groupControl2.Margin = new System.Windows.Forms.Padding(3, 20, 3, 3);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(542, 188);
            this.groupControl2.TabIndex = 25;
            this.groupControl2.Text = "QUẢN LÝ";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl5.Location = new System.Drawing.Point(68, 132);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(14, 13);
            this.labelControl5.TabIndex = 2;
            this.labelControl5.Text = "(*)";
            // 
            // txtPosition
            // 
            this.txtPosition.EditValue = "";
            this.txtPosition.Location = new System.Drawing.Point(98, 50);
            this.txtPosition.Name = "txtPosition";
            this.txtPosition.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtPosition.Properties.NullValuePrompt = "Chức vụ của nhân viên";
            this.txtPosition.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtPosition.Size = new System.Drawing.Size(430, 22);
            this.txtPosition.TabIndex = 5;
            // 
            // labelControl20
            // 
            this.labelControl20.Location = new System.Drawing.Point(23, 53);
            this.labelControl20.Name = "labelControl20";
            this.labelControl20.Size = new System.Drawing.Size(40, 13);
            this.labelControl20.TabIndex = 0;
            this.labelControl20.Text = "Chức vụ";
            // 
            // FormUpdateEmployee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 361);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.labelControl17);
            this.Controls.Add(this.checkActive);
            this.Controls.Add(this.groupControl1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormUpdateEmployee";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SỬA NHÂN VIÊN";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormUpdateEmployeee_FormClosing);
            this.Load += new System.EventHandler(this.FormUpdateEmployee_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormUpdateEmployee_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmployeeName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmployeeCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmployeeID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAddress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPhone.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtMoblie.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkActive.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPosition.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.CheckEdit checkActive;
        private DevExpress.XtraEditors.TextEdit txtEmployeeName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtEmployeeID;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtAddress;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtEmail;
        private DevExpress.XtraEditors.TextEdit txtPhone;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.TextEdit txtMoblie;
        private DevExpress.XtraEditors.LabelControl labelControl17;
        private DevExpress.XtraEditors.LabelControl labelControl16;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        private DevExpress.XtraEditors.LabelControl labelControl19;
        private DevExpress.XtraEditors.LabelControl labelControl18;
        private DevExpress.XtraEditors.GridLookUpEdit gridLookUpEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnDepartmentID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnDepartmentName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnDescription;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.TextEdit txtPosition;
        private DevExpress.XtraEditors.LabelControl labelControl20;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.TextEdit txtEmployeeCode;
        private DevExpress.XtraEditors.LabelControl labelControl6;
    }
}