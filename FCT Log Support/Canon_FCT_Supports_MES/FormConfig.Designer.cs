﻿namespace Canon_FCT_Supports_MES
{
    partial class FormConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormConfig));
            this.label4 = new System.Windows.Forms.Label();
            this.cboWindows = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtBarcodeLength = new System.Windows.Forms.MaskedTextBox();
            this.lblOutputLog = new System.Windows.Forms.Label();
            this.lblInputLog = new System.Windows.Forms.Label();
            this.txtOutputLog = new System.Windows.Forms.TextBox();
            this.txtInputLog = new System.Windows.Forms.TextBox();
            this.txtFileExtension = new System.Windows.Forms.TextBox();
            this.txtStationNO = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSaveChanged = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtColumnClount = new System.Windows.Forms.MaskedTextBox();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Process:";
            // 
            // cboWindows
            // 
            this.cboWindows.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboWindows.FormattingEnabled = true;
            this.cboWindows.Location = new System.Drawing.Point(107, 19);
            this.cboWindows.Name = "cboWindows";
            this.cboWindows.Size = new System.Drawing.Size(240, 24);
            this.cboWindows.TabIndex = 22;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtColumnClount);
            this.groupBox2.Controls.Add(this.txtBarcodeLength);
            this.groupBox2.Controls.Add(this.lblOutputLog);
            this.groupBox2.Controls.Add(this.lblInputLog);
            this.groupBox2.Controls.Add(this.txtOutputLog);
            this.groupBox2.Controls.Add(this.txtInputLog);
            this.groupBox2.Controls.Add(this.txtFileExtension);
            this.groupBox2.Controls.Add(this.txtStationNO);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cboWindows);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(15, 21);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(380, 228);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Input Configs";
            // 
            // txtBarcodeLength
            // 
            this.txtBarcodeLength.Location = new System.Drawing.Point(107, 155);
            this.txtBarcodeLength.Name = "txtBarcodeLength";
            this.txtBarcodeLength.Size = new System.Drawing.Size(72, 20);
            this.txtBarcodeLength.TabIndex = 26;
            // 
            // lblOutputLog
            // 
            this.lblOutputLog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblOutputLog.Image = global::Canon_FCT_Supports_MES.Properties.Resources.folder_saved_search_16;
            this.lblOutputLog.Location = new System.Drawing.Point(329, 128);
            this.lblOutputLog.Name = "lblOutputLog";
            this.lblOutputLog.Size = new System.Drawing.Size(18, 23);
            this.lblOutputLog.TabIndex = 25;
            this.lblOutputLog.Click += new System.EventHandler(this.lblOutputLog_Click);
            // 
            // lblInputLog
            // 
            this.lblInputLog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblInputLog.Image = global::Canon_FCT_Supports_MES.Properties.Resources.folder_saved_search_16;
            this.lblInputLog.Location = new System.Drawing.Point(329, 99);
            this.lblInputLog.Name = "lblInputLog";
            this.lblInputLog.Size = new System.Drawing.Size(18, 23);
            this.lblInputLog.TabIndex = 25;
            this.lblInputLog.Click += new System.EventHandler(this.lblInputLog_Click);
            // 
            // txtOutputLog
            // 
            this.txtOutputLog.Location = new System.Drawing.Point(107, 128);
            this.txtOutputLog.Name = "txtOutputLog";
            this.txtOutputLog.ReadOnly = true;
            this.txtOutputLog.Size = new System.Drawing.Size(216, 20);
            this.txtOutputLog.TabIndex = 24;
            // 
            // txtInputLog
            // 
            this.txtInputLog.Location = new System.Drawing.Point(107, 102);
            this.txtInputLog.Name = "txtInputLog";
            this.txtInputLog.ReadOnly = true;
            this.txtInputLog.Size = new System.Drawing.Size(216, 20);
            this.txtInputLog.TabIndex = 24;
            // 
            // txtFileExtension
            // 
            this.txtFileExtension.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFileExtension.Location = new System.Drawing.Point(107, 76);
            this.txtFileExtension.Name = "txtFileExtension";
            this.txtFileExtension.Size = new System.Drawing.Size(100, 20);
            this.txtFileExtension.TabIndex = 23;
            this.txtFileExtension.Text = "*.LOG";
            // 
            // txtStationNO
            // 
            this.txtStationNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtStationNO.Location = new System.Drawing.Point(107, 50);
            this.txtStationNO.Name = "txtStationNO";
            this.txtStationNO.Size = new System.Drawing.Size(100, 20);
            this.txtStationNO.TabIndex = 23;
            this.txtStationNO.Text = "FCT_CAN";
            this.txtStationNO.TextChanged += new System.EventHandler(this.txtStationNO_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 158);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Barcode Length:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 131);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Output Log:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "File Extension:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(46, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Input Log:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Station NO:";
            // 
            // btnSaveChanged
            // 
            this.btnSaveChanged.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveChanged.Image = global::Canon_FCT_Supports_MES.Properties.Resources.Save;
            this.btnSaveChanged.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveChanged.Location = new System.Drawing.Point(122, 255);
            this.btnSaveChanged.Name = "btnSaveChanged";
            this.btnSaveChanged.Size = new System.Drawing.Size(62, 26);
            this.btnSaveChanged.TabIndex = 23;
            this.btnSaveChanged.Text = "Lưu";
            this.btnSaveChanged.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveChanged.UseVisualStyleBackColor = true;
            this.btnSaveChanged.Click += new System.EventHandler(this.btnSaveChanged_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Columns Count:";
            // 
            // txtColumnClount
            // 
            this.txtColumnClount.Location = new System.Drawing.Point(107, 181);
            this.txtColumnClount.Name = "txtColumnClount";
            this.txtColumnClount.Size = new System.Drawing.Size(72, 20);
            this.txtColumnClount.TabIndex = 26;
            this.txtColumnClount.Text = "175";
            // 
            // FormConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 285);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnSaveChanged);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormConfig";
            this.Load += new System.EventHandler(this.FormConfig_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboWindows;
        private System.Windows.Forms.Button btnSaveChanged;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtOutputLog;
        private System.Windows.Forms.TextBox txtInputLog;
        private System.Windows.Forms.TextBox txtStationNO;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblOutputLog;
        private System.Windows.Forms.Label lblInputLog;
        private System.Windows.Forms.TextBox txtFileExtension;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.MaskedTextBox txtBarcodeLength;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.MaskedTextBox txtColumnClount;
        private System.Windows.Forms.Label label3;
    }
}