namespace BarcodeShipping.GUI
{
    partial class FormQALogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormQALogin));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblOperatorID = new DevExpress.XtraEditors.LabelControl();
            this.lblLineID = new DevExpress.XtraEditors.LabelControl();
            this.lblOperationID = new DevExpress.XtraEditors.LabelControl();
            this.txtOperatorID = new DevExpress.XtraEditors.TextEdit();
            this.txtLineID = new DevExpress.XtraEditors.TextEdit();
            this.txtOperationID = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnLogin = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOperatorID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLineID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOperationID.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(13, 62);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(304, 147);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Login Infomation";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel1.Controls.Add(this.lblOperatorID, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblLineID, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblOperationID, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtOperatorID, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtLineID, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtOperationID, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 19);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24.8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 24F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.68376F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(298, 125);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblOperatorID
            // 
            this.lblOperatorID.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblOperatorID.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblOperatorID.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblOperatorID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOperatorID.Location = new System.Drawing.Point(3, 23);
            this.lblOperatorID.Name = "lblOperatorID";
            this.lblOperatorID.Size = new System.Drawing.Size(83, 25);
            this.lblOperatorID.TabIndex = 0;
            this.lblOperatorID.Text = "Operator ID:";
            // 
            // lblLineID
            // 
            this.lblLineID.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblLineID.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblLineID.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblLineID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLineID.Location = new System.Drawing.Point(3, 54);
            this.lblLineID.Name = "lblLineID";
            this.lblLineID.Size = new System.Drawing.Size(83, 24);
            this.lblLineID.TabIndex = 0;
            this.lblLineID.Text = "Line ID:";
            // 
            // lblOperationID
            // 
            this.lblOperationID.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.lblOperationID.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblOperationID.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblOperationID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOperationID.Location = new System.Drawing.Point(3, 84);
            this.lblOperationID.Name = "lblOperationID";
            this.lblOperationID.Size = new System.Drawing.Size(83, 24);
            this.lblOperationID.TabIndex = 0;
            this.lblOperationID.Text = "Operation ID:";
            // 
            // txtOperatorID
            // 
            this.txtOperatorID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOperatorID.Location = new System.Drawing.Point(92, 23);
            this.txtOperatorID.Name = "txtOperatorID";
            this.txtOperatorID.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txtOperatorID.Properties.Appearance.Options.UseFont = true;
            this.txtOperatorID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtOperatorID.Properties.NullValuePrompt = "Operator ID";
            this.txtOperatorID.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtOperatorID.Size = new System.Drawing.Size(203, 26);
            this.txtOperatorID.TabIndex = 1;
            this.txtOperatorID.EditValueChanged += new System.EventHandler(this.txtOperatorID_EditValueChanged);
            this.txtOperatorID.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtOperatorID_PreviewKeyDown);
            this.txtOperatorID.Validating += new System.ComponentModel.CancelEventHandler(this.txtOperatorID_Validating);
            // 
            // txtLineID
            // 
            this.txtLineID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLineID.Location = new System.Drawing.Point(92, 54);
            this.txtLineID.Name = "txtLineID";
            this.txtLineID.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txtLineID.Properties.Appearance.Options.UseFont = true;
            this.txtLineID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtLineID.Properties.Mask.EditMask = "n";
            this.txtLineID.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtLineID.Properties.NullValuePrompt = "Line ID";
            this.txtLineID.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtLineID.Size = new System.Drawing.Size(203, 26);
            this.txtLineID.TabIndex = 2;
            this.txtLineID.EditValueChanged += new System.EventHandler(this.txtLineID_EditValueChanged);
            this.txtLineID.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtLineID_PreviewKeyDown);
            // 
            // txtOperationID
            // 
            this.txtOperationID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtOperationID.Location = new System.Drawing.Point(92, 84);
            this.txtOperationID.Name = "txtOperationID";
            this.txtOperationID.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txtOperationID.Properties.Appearance.Options.UseFont = true;
            this.txtOperationID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtOperationID.Properties.Mask.EditMask = "n";
            this.txtOperationID.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtOperationID.Properties.NullValuePrompt = "Operation ID";
            this.txtOperationID.Properties.NullValuePromptShowForEmptyValue = true;
            this.txtOperationID.Size = new System.Drawing.Size(203, 26);
            this.txtOperationID.TabIndex = 3;
            this.txtOperationID.EditValueChanged += new System.EventHandler(this.txtOperationID_EditValueChanged);
            this.txtOperationID.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtOperationID_PreviewKeyDown);
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Location = new System.Drawing.Point(98, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(121, 33);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "QA Login";
            // 
            // btnLogin
            // 
            this.btnLogin.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnLogin.Appearance.Options.UseFont = true;
            this.btnLogin.Image = ((System.Drawing.Image)(resources.GetObject("btnLogin.Image")));
            this.btnLogin.Location = new System.Drawing.Point(207, 215);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(110, 31);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Login (Ctrl+L)";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // FormQALogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 258);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormQALogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QA Login";
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtOperatorID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLineID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOperationID.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnLogin;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.LabelControl lblOperatorID;
        private DevExpress.XtraEditors.LabelControl lblLineID;
        private DevExpress.XtraEditors.LabelControl lblOperationID;
        private DevExpress.XtraEditors.TextEdit txtOperatorID;
        private DevExpress.XtraEditors.TextEdit txtLineID;
        private DevExpress.XtraEditors.TextEdit txtOperationID;
    }
}