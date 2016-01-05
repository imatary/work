namespace Stock.GUI.Partners
{
    partial class FormImportProductGroupFormExcel
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
            this.gridColumnProductGroupName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnDescription = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.panelControl1.Size = new System.Drawing.Size(627, 68);
            this.panelControl1.TabIndex = 0;
            // 
            // radioButtonUpdateIfDepartmentExits
            // 
            this.radioButtonUpdateIfDepartmentExits.AutoSize = true;
            this.radioButtonUpdateIfDepartmentExits.Location = new System.Drawing.Point(376, 36);
            this.radioButtonUpdateIfDepartmentExits.Name = "radioButtonUpdateIfDepartmentExits";
            this.radioButtonUpdateIfDepartmentExits.Size = new System.Drawing.Size(141, 17);
            this.radioButtonUpdateIfDepartmentExits.TabIndex = 4;
            this.radioButtonUpdateIfDepartmentExits.Text = "Cập nhập nếu đã tồn tại";
            this.radioButtonUpdateIfDepartmentExits.UseVisualStyleBackColor = true;
            // 
            // radioButtonIgnoreIfDepartmentExits
            // 
            this.radioButtonIgnoreIfDepartmentExits.AutoSize = true;
            this.radioButtonIgnoreIfDepartmentExits.Checked = true;
            this.radioButtonIgnoreIfDepartmentExits.Location = new System.Drawing.Point(376, 13);
            this.radioButtonIgnoreIfDepartmentExits.Name = "radioButtonIgnoreIfDepartmentExits";
            this.radioButtonIgnoreIfDepartmentExits.Size = new System.Drawing.Size(128, 17);
            this.radioButtonIgnoreIfDepartmentExits.TabIndex = 3;
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
            this.labelControl1.Size = new System.Drawing.Size(627, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "_________________________________________________________________________________" +
    "_______________________";
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
            this.panelControl2.Size = new System.Drawing.Size(627, 308);
            this.panelControl2.TabIndex = 1;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(15, 252);
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
            this.gridControl1.Size = new System.Drawing.Size(597, 231);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.UseEmbeddedNavigator = true;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnProductGroupName,
            this.gridColumnDescription});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // gridColumnProductGroupName
            // 
            this.gridColumnProductGroupName.Caption = "Tên";
            this.gridColumnProductGroupName.FieldName = "ProductGroupName";
            this.gridColumnProductGroupName.Name = "gridColumnProductGroupName";
            this.gridColumnProductGroupName.Visible = true;
            this.gridColumnProductGroupName.VisibleIndex = 0;
            this.gridColumnProductGroupName.Width = 230;
            // 
            // gridColumnDescription
            // 
            this.gridColumnDescription.Caption = "Ghi Chú";
            this.gridColumnDescription.FieldName = "Description";
            this.gridColumnDescription.Name = "gridColumnDescription";
            this.gridColumnDescription.Visible = true;
            this.gridColumnDescription.VisibleIndex = 1;
            this.gridColumnDescription.Width = 345;
            // 
            // textEditPathFileExel
            // 
            this.textEditPathFileExel.EditValue = "";
            this.textEditPathFileExel.Location = new System.Drawing.Point(15, 271);
            this.textEditPathFileExel.Name = "textEditPathFileExel";
            this.textEditPathFileExel.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Duyệt file", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleLeft, global::Stock.GUI.Properties.Resources.brower_excel_16, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject2, "", null, null, true)});
            this.textEditPathFileExel.Size = new System.Drawing.Size(596, 22);
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
            this.panelControl3.Location = new System.Drawing.Point(0, 376);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(627, 48);
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
            this.btnClose.Location = new System.Drawing.Point(523, 9);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(88, 28);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Hủy Bỏ (Esc)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSaveDataFormExel
            // 
            this.btnSaveDataFormExel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSaveDataFormExel.Image = global::Stock.GUI.Properties.Resources.database_save;
            this.btnSaveDataFormExel.Location = new System.Drawing.Point(415, 9);
            this.btnSaveDataFormExel.Name = "btnSaveDataFormExel";
            this.btnSaveDataFormExel.Size = new System.Drawing.Size(102, 28);
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
            this.labelControl2.Size = new System.Drawing.Size(627, 10);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "_________________________________________________________________________________" +
    "_______________________";
            // 
            // FormImportProductGroupFormExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 425);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(643, 464);
            this.MinimizeBox = false;
            this.Name = "FormImportProductGroupFormExcel";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm Nhóm Hàng Từ File Exel";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormImportProductGroupFormExcel_KeyDown);
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
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnProductGroupName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnDescription;
        private System.Windows.Forms.LinkLabel linkLabelAreaExcel;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private System.Windows.Forms.RadioButton radioButtonUpdateIfDepartmentExits;
        private System.Windows.Forms.RadioButton radioButtonIgnoreIfDepartmentExits;
    }
}