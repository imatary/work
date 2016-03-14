namespace BarcodeShipping.GUI
{
    partial class FormAddPO
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddPO));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtQtyPO = new DevExpress.XtraEditors.TextEdit();
            this.txtPO = new DevExpress.XtraEditors.TextEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.txtModelID = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQtyPO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtModelID.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtQtyPO);
            this.groupBox1.Controls.Add(this.txtPO);
            this.groupBox1.Controls.Add(this.labelControl7);
            this.groupBox1.Controls.Add(this.txtModelID);
            this.groupBox1.Controls.Add(this.labelControl3);
            this.groupBox1.Controls.Add(this.labelControl8);
            this.groupBox1.Controls.Add(this.labelControl6);
            this.groupBox1.Controls.Add(this.labelControl5);
            this.groupBox1.Controls.Add(this.labelControl2);
            this.groupBox1.Controls.Add(this.labelControl4);
            this.groupBox1.Controls.Add(this.labelControl1);
            this.groupBox1.Location = new System.Drawing.Point(12, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(349, 156);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "PO Infomation";
            // 
            // txtQtyPO
            // 
            this.txtQtyPO.Location = new System.Drawing.Point(112, 97);
            this.txtQtyPO.Name = "txtQtyPO";
            this.txtQtyPO.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txtQtyPO.Properties.Appearance.Options.UseFont = true;
            this.txtQtyPO.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtQtyPO.Properties.Mask.EditMask = "n";
            this.txtQtyPO.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtQtyPO.Size = new System.Drawing.Size(203, 26);
            this.txtQtyPO.TabIndex = 10;
            this.txtQtyPO.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtQtyPO_PreviewKeyDown);
            // 
            // txtPO
            // 
            this.txtPO.Location = new System.Drawing.Point(112, 65);
            this.txtPO.Name = "txtPO";
            this.txtPO.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txtPO.Properties.Appearance.Options.UseFont = true;
            this.txtPO.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtPO.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPO.Size = new System.Drawing.Size(203, 26);
            this.txtPO.TabIndex = 10;
            this.txtPO.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtPO_PreviewKeyDown);
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl7.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelControl7.Location = new System.Drawing.Point(86, 98);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(20, 16);
            this.labelControl7.TabIndex = 9;
            this.labelControl7.Text = "(*)";
            // 
            // txtModelID
            // 
            this.txtModelID.Location = new System.Drawing.Point(112, 33);
            this.txtModelID.Name = "txtModelID";
            this.txtModelID.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.txtModelID.Properties.Appearance.Options.UseFont = true;
            this.txtModelID.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.txtModelID.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtModelID.Size = new System.Drawing.Size(203, 26);
            this.txtModelID.TabIndex = 10;
            this.txtModelID.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtModelID_PreviewKeyDown);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelControl3.Location = new System.Drawing.Point(86, 69);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(20, 16);
            this.labelControl3.TabIndex = 9;
            this.labelControl3.Text = "(*)";
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl8.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelControl8.Location = new System.Drawing.Point(112, 129);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(16, 16);
            this.labelControl8.TabIndex = 8;
            this.labelControl8.Text = "(*)";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.labelControl6.Location = new System.Drawing.Point(18, 101);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(48, 18);
            this.labelControl6.TabIndex = 6;
            this.labelControl6.Text = "Qty PO";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl5.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelControl5.Location = new System.Drawing.Point(86, 37);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(20, 16);
            this.labelControl5.TabIndex = 9;
            this.labelControl5.Text = "(*)";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.labelControl2.Location = new System.Drawing.Point(18, 69);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(19, 18);
            this.labelControl2.TabIndex = 6;
            this.labelControl2.Text = "PO";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Location = new System.Drawing.Point(134, 129);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(92, 16);
            this.labelControl4.TabIndex = 7;
            this.labelControl4.Text = "Required value";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.labelControl1.Location = new System.Drawing.Point(18, 37);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(38, 18);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "Model";
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(251, 211);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 28);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save (Ctrl+S)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FormAddPO
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 254);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAddPO";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "PO";
            this.Load += new System.EventHandler(this.FormAddPO_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtQtyPO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtModelID.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtModelID;
        private DevExpress.XtraEditors.TextEdit txtQtyPO;
        private DevExpress.XtraEditors.TextEdit txtPO;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl2;
    }
}