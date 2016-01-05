namespace Stock.GUI.Partners
{
    partial class FormAddColor
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.colorEditColorCode = new DevExpress.XtraEditors.ColorEdit();
            this.txtColorName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtDescription = new DevExpress.XtraEditors.MemoEdit();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.checkEditIsActive = new DevExpress.XtraEditors.CheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorEditColorCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtColorName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditIsActive.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Controls.Add(this.colorEditColorCode);
            this.groupControl1.Controls.Add(this.txtColorName);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.txtDescription);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(8, 8);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(314, 165);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "THÔNG TIN CHUNG";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl4.Location = new System.Drawing.Point(47, 46);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(14, 13);
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "(*)";
            // 
            // colorEditColorCode
            // 
            this.colorEditColorCode.EditValue = System.Drawing.Color.Empty;
            this.colorEditColorCode.Location = new System.Drawing.Point(87, 67);
            this.colorEditColorCode.Name = "colorEditColorCode";
            this.colorEditColorCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.colorEditColorCode.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.colorEditColorCode.Size = new System.Drawing.Size(206, 22);
            this.colorEditColorCode.TabIndex = 2;
            // 
            // txtColorName
            // 
            this.txtColorName.Location = new System.Drawing.Point(87, 43);
            this.txtColorName.Name = "txtColorName";
            this.txtColorName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtColorName.Properties.NullValuePrompt = "Tên Màu";
            this.txtColorName.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtColorName.Size = new System.Drawing.Size(206, 22);
            this.txtColorName.TabIndex = 1;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(23, 96);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(29, 13);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Mô Tả";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(23, 70);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(37, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Mã Màu";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(23, 46);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(18, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Tên";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(87, 93);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtDescription.Properties.NullValuePrompt = "Mô tả về màu ";
            this.txtDescription.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtDescription.Properties.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtDescription.Size = new System.Drawing.Size(206, 57);
            this.txtDescription.TabIndex = 1;
            // 
            // btnClose
            // 
            this.btnClose.Image = global::Stock.GUI.Properties.Resources.delete_16;
            this.btnClose.Location = new System.Drawing.Point(229, 179);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(78, 28);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Đóng (Esc)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::Stock.GUI.Properties.Resources.database_save1;
            this.btnSave.Location = new System.Drawing.Point(137, 179);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 28);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Lưu (Ctrl+S)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // checkEditIsActive
            // 
            this.checkEditIsActive.EditValue = true;
            this.checkEditIsActive.Location = new System.Drawing.Point(8, 183);
            this.checkEditIsActive.Name = "checkEditIsActive";
            this.checkEditIsActive.Properties.Caption = "Trạng thái";
            this.checkEditIsActive.Size = new System.Drawing.Size(96, 19);
            this.checkEditIsActive.TabIndex = 2;
            // 
            // FormAddColor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 214);
            this.Controls.Add(this.checkEditIsActive);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAddColor";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Thêm Màu Sắc";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormAddColor_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorEditColorCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtColorName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.checkEditIsActive.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.ColorEdit colorEditColorCode;
        private DevExpress.XtraEditors.TextEdit txtColorName;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.MemoEdit txtDescription;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.CheckEdit checkEditIsActive;
        private DevExpress.XtraEditors.LabelControl labelControl4;

    }
}