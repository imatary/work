namespace CartonLabel.GUI
{
    partial class FormInput
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormInput));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.textEditPoNo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.gridLookUpEditPartNo = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.dateEditDelivery = new DevExpress.XtraEditors.DateEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.textEditPOQuantity = new DevExpress.XtraEditors.TextEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnPreview = new DevExpress.XtraEditors.SimpleButton();
            this.textEditShippingQuantity = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.textEditPoNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEditPartNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDelivery.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDelivery.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditPOQuantity.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditShippingQuantity.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Location = new System.Drawing.Point(33, 25);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(18, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "PO:";
            // 
            // textEditPoNo
            // 
            this.textEditPoNo.EditValue = "";
            this.textEditPoNo.Location = new System.Drawing.Point(142, 22);
            this.textEditPoNo.Name = "textEditPoNo";
            this.textEditPoNo.Properties.NullValuePrompt = "PO No";
            this.textEditPoNo.Properties.NullValuePromptShowForEmptyValue = true;
            this.textEditPoNo.Size = new System.Drawing.Size(218, 20);
            this.textEditPoNo.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Location = new System.Drawing.Point(33, 51);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(44, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Part No:";
            // 
            // gridLookUpEditPartNo
            // 
            this.gridLookUpEditPartNo.EditValue = "";
            this.gridLookUpEditPartNo.Location = new System.Drawing.Point(142, 48);
            this.gridLookUpEditPartNo.Name = "gridLookUpEditPartNo";
            this.gridLookUpEditPartNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.gridLookUpEditPartNo.Properties.Appearance.Options.UseFont = true;
            this.gridLookUpEditPartNo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, DevExpress.XtraEditors.ImageLocation.MiddleCenter, global::CartonLabel.GUI.Properties.Resources.add_16, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, "", null, null, true)});
            this.gridLookUpEditPartNo.Properties.NullText = "";
            this.gridLookUpEditPartNo.Properties.NullValuePrompt = "Part No";
            this.gridLookUpEditPartNo.Properties.NullValuePromptShowForEmptyValue = true;
            this.gridLookUpEditPartNo.Properties.View = this.gridLookUpEdit1View;
            this.gridLookUpEditPartNo.Size = new System.Drawing.Size(218, 22);
            this.gridLookUpEditPartNo.TabIndex = 2;
            this.gridLookUpEditPartNo.ButtonPressed += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.gridLookUpEditPartNo_ButtonPressed);
            this.gridLookUpEditPartNo.EditValueChanged += new System.EventHandler(this.gridLookUpEditPartNo_EditValueChanged);
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Part No";
            this.gridColumn1.FieldName = "PartNoValue";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Des";
            this.gridColumn2.FieldName = "Description";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Location = new System.Drawing.Point(33, 129);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(80, 13);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Delivery Date:";
            // 
            // dateEditDelivery
            // 
            this.dateEditDelivery.EditValue = "";
            this.dateEditDelivery.Location = new System.Drawing.Point(142, 126);
            this.dateEditDelivery.Name = "dateEditDelivery";
            this.dateEditDelivery.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditDelivery.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEditDelivery.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.TouchUI;
            this.dateEditDelivery.Properties.DisplayFormat.FormatString = "yyyy/MM/dd";
            this.dateEditDelivery.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dateEditDelivery.Properties.ShowWeekNumbers = true;
            this.dateEditDelivery.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.False;
            this.dateEditDelivery.Size = new System.Drawing.Size(218, 20);
            this.dateEditDelivery.TabIndex = 4;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl4.Location = new System.Drawing.Point(33, 103);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(70, 13);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "PO Quantity:";
            // 
            // textEditPOQuantity
            // 
            this.textEditPOQuantity.Location = new System.Drawing.Point(142, 100);
            this.textEditPOQuantity.Name = "textEditPOQuantity";
            this.textEditPOQuantity.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.textEditPOQuantity.Properties.Mask.EditMask = "n0";
            this.textEditPOQuantity.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.textEditPOQuantity.Properties.NullValuePrompt = "PO Quantity";
            this.textEditPOQuantity.Properties.NullValuePromptShowForEmptyValue = true;
            this.textEditPOQuantity.Size = new System.Drawing.Size(218, 20);
            this.textEditPOQuantity.TabIndex = 3;
            // 
            // panelControl1
            // 
            this.panelControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.panelControl1.Appearance.Options.UseBackColor = true;
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.btnClose);
            this.panelControl1.Controls.Add(this.btnPreview);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.dateEditDelivery);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.gridLookUpEditPartNo);
            this.panelControl1.Controls.Add(this.labelControl3);
            this.panelControl1.Controls.Add(this.textEditShippingQuantity);
            this.panelControl1.Controls.Add(this.labelControl5);
            this.panelControl1.Controls.Add(this.textEditPOQuantity);
            this.panelControl1.Controls.Add(this.labelControl4);
            this.panelControl1.Controls.Add(this.textEditPoNo);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(377, 214);
            this.panelControl1.TabIndex = 7;
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnClose.Image = global::CartonLabel.GUI.Properties.Resources.delete_16;
            this.btnClose.Location = new System.Drawing.Point(276, 161);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(86, 28);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Cancel (Esc)";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPreview.Image = global::CartonLabel.GUI.Properties.Resources.Apple_88_16;
            this.btnPreview.Location = new System.Drawing.Point(160, 161);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(110, 28);
            this.btnPreview.TabIndex = 5;
            this.btnPreview.Text = "Preview (Ctrl+P)";
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // textEditShippingQuantity
            // 
            this.textEditShippingQuantity.Location = new System.Drawing.Point(142, 74);
            this.textEditShippingQuantity.Name = "textEditShippingQuantity";
            this.textEditShippingQuantity.Properties.Mask.EditMask = "n0";
            this.textEditShippingQuantity.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.textEditShippingQuantity.Properties.NullValuePrompt = "Shipping Quantity";
            this.textEditShippingQuantity.Properties.NullValuePromptShowForEmptyValue = true;
            this.textEditShippingQuantity.Size = new System.Drawing.Size(218, 20);
            this.textEditShippingQuantity.TabIndex = 3;
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl5.Location = new System.Drawing.Point(33, 77);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(103, 13);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "Shipping Quantity:";
            // 
            // FormInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(377, 214);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormInput";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CARTON LABEL";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormInput_FormClosing);
            this.Load += new System.EventHandler(this.FormInput_Load);
            ((System.ComponentModel.ISupportInitialize)(this.textEditPoNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEditPartNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDelivery.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEditDelivery.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditPOQuantity.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditShippingQuantity.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit textEditPoNo;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.GridLookUpEdit gridLookUpEditPartNo;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.DateEdit dateEditDelivery;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit textEditPOQuantity;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnPreview;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraEditors.TextEdit textEditShippingQuantity;
        private DevExpress.XtraEditors.LabelControl labelControl5;
    }
}