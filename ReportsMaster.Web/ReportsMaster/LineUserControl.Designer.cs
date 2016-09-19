namespace ReportsMaster
{
    partial class LineUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblLineName = new DevExpress.XtraEditors.LabelControl();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblPause = new DevExpress.XtraEditors.LabelControl();
            this.lblRun = new DevExpress.XtraEditors.LabelControl();
            this.lblStop = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblComment = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lblPerson = new DevExpress.XtraEditors.LabelControl();
            this.lblPlan = new DevExpress.XtraEditors.LabelControl();
            this.lblActual = new DevExpress.XtraEditors.LabelControl();
            this.lblBalenced = new DevExpress.XtraEditors.LabelControl();
            this.lblModel = new DevExpress.XtraEditors.LabelControl();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblLineName
            // 
            this.lblLineName.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLineName.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblLineName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblLineName.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblLineName.LineVisible = true;
            this.lblLineName.Location = new System.Drawing.Point(15, 10);
            this.lblLineName.Name = "lblLineName";
            this.lblLineName.Size = new System.Drawing.Size(801, 55);
            this.lblLineName.TabIndex = 0;
            this.lblLineName.Text = "Waiting...";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panelControl2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox1.Font = new System.Drawing.Font("Arial Rounded MT Bold", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(670, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(131, 200);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Trạng thái Line";
            // 
            // panelControl2
            // 
            this.panelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl2.AutoSize = true;
            this.panelControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl2.Controls.Add(this.tableLayoutPanel1);
            this.panelControl2.Location = new System.Drawing.Point(16, 20);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(94, 174);
            this.panelControl2.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lblPause, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblRun, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblStop, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelControl1, 0, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(94, 174);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblPause
            // 
            this.lblPause.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.lblPause.Appearance.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
            this.lblPause.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblPause.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblPause.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblPause.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lblPause.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPause.Location = new System.Drawing.Point(3, 3);
            this.lblPause.Name = "lblPause";
            this.lblPause.Size = new System.Drawing.Size(88, 46);
            this.lblPause.TabIndex = 0;
            // 
            // lblRun
            // 
            this.lblRun.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblRun.Appearance.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
            this.lblRun.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblRun.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblRun.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblRun.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lblRun.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblRun.Location = new System.Drawing.Point(3, 55);
            this.lblRun.Name = "lblRun";
            this.lblRun.Size = new System.Drawing.Size(88, 46);
            this.lblRun.TabIndex = 1;
            // 
            // lblStop
            // 
            this.lblStop.Appearance.BackColor = System.Drawing.Color.Maroon;
            this.lblStop.Appearance.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
            this.lblStop.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblStop.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblStop.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblStop.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblStop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblStop.Location = new System.Drawing.Point(3, 107);
            this.lblStop.Name = "lblStop";
            this.lblStop.Size = new System.Drawing.Size(88, 46);
            this.lblStop.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 100F);
            this.labelControl1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl1.Location = new System.Drawing.Point(3, 159);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(88, 12);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "|";
            // 
            // panelControl1
            // 
            this.panelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl1.Controls.Add(this.panelControl3);
            this.panelControl1.Controls.Add(this.groupBox1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(15, 65);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(801, 200);
            this.panelControl1.TabIndex = 1;
            // 
            // panelControl3
            // 
            this.panelControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.panelControl3.Controls.Add(this.tableLayoutPanel2);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(0, 0);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.panelControl3.Size = new System.Drawing.Size(670, 200);
            this.panelControl3.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20.03035F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.29135F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.24638F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.21739F));
            this.tableLayoutPanel2.Controls.Add(this.lblComment, 5, 1);
            this.tableLayoutPanel2.Controls.Add(this.labelControl7, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelControl6, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelControl5, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelControl4, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelControl3, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelControl2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblPerson, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblPlan, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblActual, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblBalenced, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblModel, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35.71429F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 64.28571F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(660, 197);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // lblComment
            // 
            this.lblComment.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComment.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblComment.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.lblComment.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblComment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblComment.Location = new System.Drawing.Point(495, 74);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(161, 119);
            this.lblComment.TabIndex = 11;
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl7.Appearance.ForeColor = System.Drawing.Color.Teal;
            this.labelControl7.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl7.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.labelControl7.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl7.Location = new System.Drawing.Point(495, 4);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(161, 63);
            this.labelControl7.TabIndex = 5;
            this.labelControl7.Text = "Comment";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Appearance.ForeColor = System.Drawing.Color.Teal;
            this.labelControl6.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl6.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.labelControl6.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl6.Location = new System.Drawing.Point(382, 4);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(106, 63);
            this.labelControl6.TabIndex = 4;
            this.labelControl6.Text = "% Đạt được";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl5.Appearance.ForeColor = System.Drawing.Color.Teal;
            this.labelControl5.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl5.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.labelControl5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl5.Location = new System.Drawing.Point(303, 4);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(72, 63);
            this.labelControl5.TabIndex = 3;
            this.labelControl5.Text = "Thực tế";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.ForeColor = System.Drawing.Color.Teal;
            this.labelControl4.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl4.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl4.Location = new System.Drawing.Point(222, 4);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(74, 63);
            this.labelControl4.TabIndex = 2;
            this.labelControl4.Text = "Kế hoạch";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.Teal;
            this.labelControl3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl3.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl3.Location = new System.Drawing.Point(90, 4);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(125, 63);
            this.labelControl3.TabIndex = 1;
            this.labelControl3.Text = "Model";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.Teal;
            this.labelControl2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.labelControl2.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl2.Location = new System.Drawing.Point(4, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(79, 63);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Số người";
            // 
            // lblPerson
            // 
            this.lblPerson.Appearance.Font = new System.Drawing.Font("Arial Black", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPerson.Appearance.ForeColor = System.Drawing.Color.Maroon;
            this.lblPerson.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblPerson.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblPerson.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblPerson.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPerson.Location = new System.Drawing.Point(4, 74);
            this.lblPerson.Name = "lblPerson";
            this.lblPerson.Size = new System.Drawing.Size(79, 119);
            this.lblPerson.TabIndex = 6;
            this.lblPerson.Text = "0";
            // 
            // lblPlan
            // 
            this.lblPlan.Appearance.Font = new System.Drawing.Font("Arial Black", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlan.Appearance.ForeColor = System.Drawing.Color.Maroon;
            this.lblPlan.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblPlan.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblPlan.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblPlan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPlan.Location = new System.Drawing.Point(222, 74);
            this.lblPlan.Name = "lblPlan";
            this.lblPlan.Size = new System.Drawing.Size(74, 119);
            this.lblPlan.TabIndex = 7;
            this.lblPlan.Text = "0";
            // 
            // lblActual
            // 
            this.lblActual.Appearance.Font = new System.Drawing.Font("Arial Black", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActual.Appearance.ForeColor = System.Drawing.Color.Maroon;
            this.lblActual.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblActual.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblActual.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblActual.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblActual.Location = new System.Drawing.Point(303, 74);
            this.lblActual.Name = "lblActual";
            this.lblActual.Size = new System.Drawing.Size(72, 119);
            this.lblActual.TabIndex = 8;
            this.lblActual.Text = "0";
            // 
            // lblBalenced
            // 
            this.lblBalenced.Appearance.Font = new System.Drawing.Font("Arial Black", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBalenced.Appearance.ForeColor = System.Drawing.Color.Maroon;
            this.lblBalenced.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblBalenced.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblBalenced.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblBalenced.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBalenced.Location = new System.Drawing.Point(382, 74);
            this.lblBalenced.Name = "lblBalenced";
            this.lblBalenced.Size = new System.Drawing.Size(106, 119);
            this.lblBalenced.TabIndex = 9;
            this.lblBalenced.Text = "0";
            // 
            // lblModel
            // 
            this.lblModel.Appearance.Font = new System.Drawing.Font("Arial Rounded MT Bold", 18.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModel.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lblModel.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblModel.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblModel.Location = new System.Drawing.Point(90, 74);
            this.lblModel.Name = "lblModel";
            this.lblModel.Size = new System.Drawing.Size(125, 119);
            this.lblModel.TabIndex = 10;
            this.lblModel.Text = "N/A";
            // 
            // LineUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.lblLineName);
            this.Name = "LineUserControl";
            this.Padding = new System.Windows.Forms.Padding(15, 10, 15, 10);
            this.Size = new System.Drawing.Size(831, 275);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        public DevExpress.XtraEditors.LabelControl lblLineName;
        public DevExpress.XtraEditors.LabelControl lblPause;
        public DevExpress.XtraEditors.LabelControl lblRun;
        public DevExpress.XtraEditors.LabelControl lblStop;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        public DevExpress.XtraEditors.LabelControl lblPerson;
        public DevExpress.XtraEditors.LabelControl lblPlan;
        public DevExpress.XtraEditors.LabelControl lblActual;
        public DevExpress.XtraEditors.LabelControl lblBalenced;
        public DevExpress.XtraEditors.LabelControl lblModel;
        public DevExpress.XtraEditors.LabelControl lblComment;
    }
}
