namespace FCT_HFT1024_V2
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnComRead = new System.Windows.Forms.Button();
            this.btnProcess = new System.Windows.Forms.Button();
            this.txtBarcodeLength = new DevComponents.Editors.IntegerInput();
            this.cboWindows = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.cboComRead = new DevComponents.DotNetBar.Controls.ComboBoxEx();
            this.lblOutputLog = new System.Windows.Forms.Label();
            this.lblInputLog = new System.Windows.Forms.Label();
            this.txtOutputLog = new System.Windows.Forms.TextBox();
            this.txtInputLog = new System.Windows.Forms.TextBox();
            this.txtFileExtension = new System.Windows.Forms.TextBox();
            this.txtStationNO = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSaveChanged = new System.Windows.Forms.Button();
            this.ckhAllowsWriteCom = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.checkBox1 = new DevComponents.DotNetBar.Controls.CheckBoxX();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBarcodeLength)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Process:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Controls.Add(this.ckhAllowsWriteCom);
            this.groupBox2.Controls.Add(this.btnComRead);
            this.groupBox2.Controls.Add(this.btnProcess);
            this.groupBox2.Controls.Add(this.txtBarcodeLength);
            this.groupBox2.Controls.Add(this.cboWindows);
            this.groupBox2.Controls.Add(this.cboComRead);
            this.groupBox2.Controls.Add(this.lblOutputLog);
            this.groupBox2.Controls.Add(this.lblInputLog);
            this.groupBox2.Controls.Add(this.txtOutputLog);
            this.groupBox2.Controls.Add(this.txtInputLog);
            this.groupBox2.Controls.Add(this.txtFileExtension);
            this.groupBox2.Controls.Add(this.txtStationNO);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(15, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(380, 275);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Input Configs";
            // 
            // btnComRead
            // 
            this.btnComRead.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnComRead.FlatAppearance.BorderSize = 0;
            this.btnComRead.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnComRead.Image = global::FCT_HFT1024_V2.Properties.Resources.refresh_16;
            this.btnComRead.Location = new System.Drawing.Point(239, 20);
            this.btnComRead.Name = "btnComRead";
            this.btnComRead.Size = new System.Drawing.Size(20, 22);
            this.btnComRead.TabIndex = 31;
            this.btnComRead.UseVisualStyleBackColor = true;
            this.btnComRead.Click += new System.EventHandler(this.btnComRead_Click);
            // 
            // btnProcess
            // 
            this.btnProcess.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProcess.FlatAppearance.BorderSize = 0;
            this.btnProcess.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProcess.Image = global::FCT_HFT1024_V2.Properties.Resources.refresh_16;
            this.btnProcess.Location = new System.Drawing.Point(324, 45);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(20, 22);
            this.btnProcess.TabIndex = 30;
            this.btnProcess.UseVisualStyleBackColor = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // txtBarcodeLength
            // 
            // 
            // 
            // 
            this.txtBarcodeLength.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtBarcodeLength.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtBarcodeLength.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtBarcodeLength.Location = new System.Drawing.Point(107, 73);
            this.txtBarcodeLength.MaxValue = 100;
            this.txtBarcodeLength.MinValue = 0;
            this.txtBarcodeLength.Name = "txtBarcodeLength";
            this.txtBarcodeLength.ShowUpDown = true;
            this.txtBarcodeLength.Size = new System.Drawing.Size(100, 20);
            this.txtBarcodeLength.TabIndex = 29;
            this.txtBarcodeLength.Value = 10;
            // 
            // cboWindows
            // 
            this.cboWindows.DisplayMember = "Text";
            this.cboWindows.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboWindows.FormattingEnabled = true;
            this.cboWindows.ItemHeight = 14;
            this.cboWindows.Location = new System.Drawing.Point(107, 47);
            this.cboWindows.Name = "cboWindows";
            this.cboWindows.Size = new System.Drawing.Size(216, 20);
            this.cboWindows.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboWindows.TabIndex = 28;
            // 
            // cboComRead
            // 
            this.cboComRead.DisplayMember = "Text";
            this.cboComRead.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cboComRead.FormattingEnabled = true;
            this.cboComRead.ItemHeight = 14;
            this.cboComRead.Location = new System.Drawing.Point(107, 20);
            this.cboComRead.Name = "cboComRead";
            this.cboComRead.Size = new System.Drawing.Size(126, 20);
            this.cboComRead.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.cboComRead.TabIndex = 27;
            // 
            // lblOutputLog
            // 
            this.lblOutputLog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblOutputLog.Image = global::FCT_HFT1024_V2.Properties.Resources.folder_saved_search_16;
            this.lblOutputLog.Location = new System.Drawing.Point(328, 177);
            this.lblOutputLog.Name = "lblOutputLog";
            this.lblOutputLog.Size = new System.Drawing.Size(18, 23);
            this.lblOutputLog.TabIndex = 25;
            this.lblOutputLog.Click += new System.EventHandler(this.lblOutputLog_Click);
            // 
            // lblInputLog
            // 
            this.lblInputLog.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblInputLog.Image = global::FCT_HFT1024_V2.Properties.Resources.folder_saved_search_16;
            this.lblInputLog.Location = new System.Drawing.Point(327, 149);
            this.lblInputLog.Name = "lblInputLog";
            this.lblInputLog.Size = new System.Drawing.Size(18, 23);
            this.lblInputLog.TabIndex = 25;
            this.lblInputLog.Click += new System.EventHandler(this.lblInputLog_Click);
            // 
            // txtOutputLog
            // 
            this.txtOutputLog.Location = new System.Drawing.Point(107, 177);
            this.txtOutputLog.Name = "txtOutputLog";
            this.txtOutputLog.ReadOnly = true;
            this.txtOutputLog.Size = new System.Drawing.Size(216, 20);
            this.txtOutputLog.TabIndex = 24;
            // 
            // txtInputLog
            // 
            this.txtInputLog.Location = new System.Drawing.Point(107, 151);
            this.txtInputLog.Name = "txtInputLog";
            this.txtInputLog.ReadOnly = true;
            this.txtInputLog.Size = new System.Drawing.Size(216, 20);
            this.txtInputLog.TabIndex = 24;
            // 
            // txtFileExtension
            // 
            this.txtFileExtension.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFileExtension.Location = new System.Drawing.Point(107, 125);
            this.txtFileExtension.Name = "txtFileExtension";
            this.txtFileExtension.Size = new System.Drawing.Size(100, 20);
            this.txtFileExtension.TabIndex = 23;
            this.txtFileExtension.Text = "*.TXT";
            // 
            // txtStationNO
            // 
            this.txtStationNO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtStationNO.Location = new System.Drawing.Point(107, 99);
            this.txtStationNO.Name = "txtStationNO";
            this.txtStationNO.Size = new System.Drawing.Size(100, 20);
            this.txtStationNO.TabIndex = 23;
            this.txtStationNO.Text = "FCT_FUJ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 180);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 21;
            this.label6.Text = "Output Log:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 128);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "File Extension:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(46, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Input Log:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Station NO:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(41, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Com Read:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Barcode length:";
            // 
            // btnSaveChanged
            // 
            this.btnSaveChanged.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSaveChanged.Image = global::FCT_HFT1024_V2.Properties.Resources._1479564278_Save_as;
            this.btnSaveChanged.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSaveChanged.Location = new System.Drawing.Point(122, 293);
            this.btnSaveChanged.Name = "btnSaveChanged";
            this.btnSaveChanged.Size = new System.Drawing.Size(62, 26);
            this.btnSaveChanged.TabIndex = 23;
            this.btnSaveChanged.Text = "Lưu";
            this.btnSaveChanged.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveChanged.UseVisualStyleBackColor = true;
            this.btnSaveChanged.Click += new System.EventHandler(this.btnSaveChanged_Click);
            // 
            // ckhAllowsWriteCom
            // 
            // 
            // 
            // 
            this.ckhAllowsWriteCom.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ckhAllowsWriteCom.Location = new System.Drawing.Point(107, 226);
            this.ckhAllowsWriteCom.Name = "ckhAllowsWriteCom";
            this.ckhAllowsWriteCom.Size = new System.Drawing.Size(216, 23);
            this.ckhAllowsWriteCom.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ckhAllowsWriteCom.TabIndex = 32;
            this.ckhAllowsWriteCom.Text = "Allows recording of data to com";
            // 
            // checkBox1
            // 
            // 
            // 
            // 
            this.checkBox1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.checkBox1.Location = new System.Drawing.Point(107, 204);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(216, 23);
            this.checkBox1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.checkBox1.TabIndex = 33;
            this.checkBox1.Text = "Skip wait logs - Create log always";
            // 
            // FormConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(410, 326);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnSaveChanged);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormConfig";
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtBarcodeLength)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label4;
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
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboComRead;
        private System.Windows.Forms.Label label2;
        private DevComponents.DotNetBar.Controls.ComboBoxEx cboWindows;
        private DevComponents.Editors.IntegerInput txtBarcodeLength;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnProcess;
        private System.Windows.Forms.Button btnComRead;
        private DevComponents.DotNetBar.Controls.CheckBoxX checkBox1;
        private DevComponents.DotNetBar.Controls.CheckBoxX ckhAllowsWriteCom;
    }
}