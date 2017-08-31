namespace VI_FujiXerox
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtOperationID = new DevComponents.Editors.IntegerInput();
            this.txtLineID = new DevComponents.Editors.IntegerInput();
            this.txtOperatorID = new DevComponents.Editors.IntegerInput();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOperationID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLineID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOperatorID)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtOperationID);
            this.groupBox1.Controls.Add(this.txtLineID);
            this.groupBox1.Controls.Add(this.txtOperatorID);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(270, 122);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Login Information";
            // 
            // txtOperationID
            // 
            // 
            // 
            // 
            this.txtOperationID.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtOperationID.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtOperationID.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtOperationID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOperationID.Location = new System.Drawing.Point(98, 85);
            this.txtOperationID.MaxValue = 3;
            this.txtOperationID.MinValue = 0;
            this.txtOperationID.Name = "txtOperationID";
            this.txtOperationID.ShowUpDown = true;
            this.txtOperationID.Size = new System.Drawing.Size(80, 22);
            this.txtOperationID.TabIndex = 3;
            this.txtOperationID.ValueChanged += new System.EventHandler(this.txtOperationID_ValueChanged);
            this.txtOperationID.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtOperationID_PreviewKeyDown);
            // 
            // txtLineID
            // 
            // 
            // 
            // 
            this.txtLineID.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtLineID.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtLineID.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtLineID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLineID.Location = new System.Drawing.Point(98, 58);
            this.txtLineID.MaxValue = 100;
            this.txtLineID.MinValue = 0;
            this.txtLineID.Name = "txtLineID";
            this.txtLineID.ShowUpDown = true;
            this.txtLineID.Size = new System.Drawing.Size(80, 22);
            this.txtLineID.TabIndex = 2;
            this.txtLineID.ValueChanged += new System.EventHandler(this.txtLineID_ValueChanged);
            this.txtLineID.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtLineID_PreviewKeyDown);
            // 
            // txtOperatorID
            // 
            // 
            // 
            // 
            this.txtOperatorID.BackgroundStyle.Class = "DateTimeInputBackground";
            this.txtOperatorID.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtOperatorID.ButtonFreeText.Shortcut = DevComponents.DotNetBar.eShortcut.F2;
            this.txtOperatorID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOperatorID.Location = new System.Drawing.Point(98, 31);
            this.txtOperatorID.MaxValue = 99999;
            this.txtOperatorID.MinValue = 0;
            this.txtOperatorID.Name = "txtOperatorID";
            this.txtOperatorID.ShowUpDown = true;
            this.txtOperatorID.Size = new System.Drawing.Size(136, 22);
            this.txtOperatorID.TabIndex = 1;
            this.txtOperatorID.ValueChanged += new System.EventHandler(this.txtOperatorID_ValueChanged);
            this.txtOperatorID.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtOperatorID_PreviewKeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(22, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Operation ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Line ID:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Operator ID:";
            // 
            // btnLogin
            // 
            this.btnLogin.Image = global::VI_FujiXerox.Properties.Resources.ok_sign_16;
            this.btnLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogin.Location = new System.Drawing.Point(219, 187);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(63, 28);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Login";
            this.btnLogin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::VI_FujiXerox.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(110, 7);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(66, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.Icon = ((System.Drawing.Icon)(resources.GetObject("errorProvider1.Icon")));
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(294, 222);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form Login";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOperationID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLineID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtOperatorID)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevComponents.Editors.IntegerInput txtOperationID;
        private DevComponents.Editors.IntegerInput txtLineID;
        private DevComponents.Editors.IntegerInput txtOperatorID;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}

