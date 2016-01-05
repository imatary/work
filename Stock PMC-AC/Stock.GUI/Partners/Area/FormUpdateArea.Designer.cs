namespace Stock.GUI.Partners
{
    partial class FormUpdateArea
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
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtAreaName = new DevExpress.XtraEditors.TextEdit();
            this.txtAreaID = new DevExpress.XtraEditors.TextEdit();
            this.txtDescription = new DevExpress.XtraEditors.MemoEdit();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAreaName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAreaID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.groupControl1.CaptionLocation = DevExpress.Utils.Locations.Top;
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.labelControl2);
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.txtAreaName);
            this.groupControl1.Controls.Add(this.txtAreaID);
            this.groupControl1.Controls.Add(this.txtDescription);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(6, 6);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(377, 189);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.TabStop = true;
            this.groupControl1.Text = "THÔNG TIN KHU VỰC";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(44, 100);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(35, 13);
            this.labelControl3.TabIndex = 1;
            this.labelControl3.Text = "Ghi chú";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(44, 74);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(18, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "Tên";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(44, 44);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(14, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Mã";
            // 
            // txtAreaName
            // 
            this.txtAreaName.Location = new System.Drawing.Point(113, 67);
            this.txtAreaName.Name = "txtAreaName";
            this.txtAreaName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtAreaName.Properties.NullValuePrompt = "Tên khu vực";
            this.txtAreaName.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtAreaName.Size = new System.Drawing.Size(240, 22);
            this.txtAreaName.TabIndex = 1;
            this.txtAreaName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAreaName_KeyDown);
            // 
            // txtAreaID
            // 
            this.txtAreaID.Enabled = false;
            this.txtAreaID.Location = new System.Drawing.Point(113, 41);
            this.txtAreaID.Name = "txtAreaID";
            this.txtAreaID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtAreaID.Properties.NullValuePrompt = "Mã khu vực";
            this.txtAreaID.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtAreaID.Size = new System.Drawing.Size(240, 22);
            this.txtAreaID.TabIndex = 0;
            this.txtAreaID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAreaID_KeyDown);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(113, 93);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtDescription.Properties.NullValuePrompt = "Ghi chú";
            this.txtDescription.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtDescription.Size = new System.Drawing.Size(240, 81);
            this.txtDescription.TabIndex = 2;
            this.txtDescription.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDescription_KeyDown);
            // 
            // btnClose
            // 
            this.btnClose.Image = global::Stock.GUI.Properties.Resources.f_cross_256_16;
            this.btnClose.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnClose.Location = new System.Drawing.Point(293, 213);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(90, 28);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Đóng (Esc)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::Stock.GUI.Properties.Resources.database_save;
            this.btnSave.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(193, 213);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 28);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Lưu (Ctrl+S)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FormUpdateArea
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 251);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupControl1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormUpdateArea";
            this.Padding = new System.Windows.Forms.Padding(6);
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sửa Khu Vực";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormUpdateArea_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormUpdateArea_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtAreaName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAreaID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtAreaName;
        private DevExpress.XtraEditors.TextEdit txtAreaID;
        private DevExpress.XtraEditors.MemoEdit txtDescription;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnClose;
    }
}