using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace IndicateReort
{
    public class Test : Form
    {
        delegate void StringParameterDelegate(string value);
        Label statusIndicator;
        Label counter;
        Button button;

        /// <summary>
        /// Lock around target and currentCount
        /// </summary>
        readonly object stateLock = new object();
        int target;
        int currentCount;
        private TableLayoutPanel tableLayoutPanel5;
        private DevExpress.XtraEditors.TextEdit textEditOvertime;
        private DevExpress.XtraEditors.TextEdit textEditTime16_17;
        private DevExpress.XtraEditors.TextEdit textEditTime14_16;
        private DevExpress.XtraEditors.TextEdit textEditTime13_14;
        private DevExpress.XtraEditors.TextEdit textEditTime12_13;
        private DevExpress.XtraEditors.TextEdit textEditTime9_11;
        private DevExpress.XtraEditors.TextEdit textEditTime9_9_30;
        private Label lblOvertime;
        private Label label17;
        private Label label13;
        private Label label12;
        private Label label11;
        private Label label18;
        private Label label19;
        private Label ThucTe_8;
        private Label label20;
        private Label ThucTe_9;
        private Label ThucTe_940;
        private Label ThucTe_12;
        private Label ThucTe_13;
        private Label label32;
        private Label label33;
        private Label label34;
        private Label label35;
        private Label ThucTe_14;
        private Label ThucTe_16;
        private Label ThucTe_Overtime;
        private Label ChenhLech8;
        private Label ChenhLech9;
        private Label ChenhLech940;
        private Label ChenhLech12;
        private Label ChenhLech13;
        private Label ChenhLech14;
        private Label ChenhLech16;
        private Label ChenhLechOvertime;
        private DevExpress.XtraEditors.TextEdit textEditTime8_9;

        Random rng = new Random();

        public Test()
        {
            Size = new Size(180, 120);
            Text = "Test";

            Label lbl = new Label();
            lbl.Text = "Status:";
            lbl.Size = new Size(50, 20);
            lbl.Location = new Point(10, 10);
            Controls.Add(lbl);

            lbl = new Label();
            lbl.Text = "Count:";
            lbl.Size = new Size(50, 20);
            lbl.Location = new Point(10, 34);
            Controls.Add(lbl);

            statusIndicator = new Label();
            statusIndicator.Size = new Size(100, 20);
            statusIndicator.Location = new Point(70, 10);
            Controls.Add(statusIndicator);

            counter = new Label();
            counter.Size = new Size(100, 20);
            counter.Location = new Point(70, 34);
            Controls.Add(counter);

            button = new Button();
            button.Text = "Go";
            button.Size = new Size(50, 20);
            button.Location = new Point(10, 58);
            Controls.Add(button);
            button.Click += new EventHandler(StartThread);

            lock (stateLock)
            {
                target = rng.Next(100);
            }
            Thread t = new Thread(new ThreadStart(ThreadJob));
            t.IsBackground = true;
            t.Start();
        
        }

        void StartThread(object sender, EventArgs e)
        {
            button.Enabled = false;
            lock (stateLock)
            {
                target = rng.Next(100);
            }
            Thread t = new Thread(new ThreadStart(ThreadJob));
            t.IsBackground = true;
            t.Start();
        }

        void ThreadJob()
        {
            MethodInvoker updateCounterDelegate = new MethodInvoker(UpdateCount);
            int localTarget;
            lock (stateLock)
            {
                localTarget = target;
            }
            UpdateStatus("Starting");

            lock (stateLock)
            {
                currentCount = 0;
            }
            Invoke(updateCounterDelegate);
            // Pause before starting
            Thread.Sleep(500);
            UpdateStatus("Counting");
            for (int i = 0; i < localTarget; i++)
            {
                lock (stateLock)
                {
                    currentCount = i;
                }
                // Synchronously show the counter
                Invoke(updateCounterDelegate);
                Thread.Sleep(100);
            }
            UpdateStatus("Finished");
            Invoke(new MethodInvoker(EnableButton));
        }

        void UpdateStatus(string value)
        {
            if (InvokeRequired)
            {
                // We're not in the UI thread, so we need to call BeginInvoke
                BeginInvoke(new StringParameterDelegate(UpdateStatus), new object[] { value });
                return;
            }
            // Must be on the UI thread if we've got this far
            statusIndicator.Text = value;
        }

        void UpdateCount()
        {
            int tmpCount;
            lock (stateLock)
            {
                tmpCount = currentCount;
            }
            counter.Text = tmpCount.ToString();
        }

        void EnableButton()
        {
            button.Enabled = true;
        }

        private void InitializeComponent()
        {
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.textEditOvertime = new DevExpress.XtraEditors.TextEdit();
            this.textEditTime16_17 = new DevExpress.XtraEditors.TextEdit();
            this.textEditTime14_16 = new DevExpress.XtraEditors.TextEdit();
            this.textEditTime13_14 = new DevExpress.XtraEditors.TextEdit();
            this.textEditTime12_13 = new DevExpress.XtraEditors.TextEdit();
            this.textEditTime9_11 = new DevExpress.XtraEditors.TextEdit();
            this.textEditTime9_9_30 = new DevExpress.XtraEditors.TextEdit();
            this.lblOvertime = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.ThucTe_8 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.ThucTe_9 = new System.Windows.Forms.Label();
            this.ThucTe_940 = new System.Windows.Forms.Label();
            this.ThucTe_12 = new System.Windows.Forms.Label();
            this.ThucTe_13 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.ThucTe_14 = new System.Windows.Forms.Label();
            this.ThucTe_16 = new System.Windows.Forms.Label();
            this.ThucTe_Overtime = new System.Windows.Forms.Label();
            this.ChenhLech8 = new System.Windows.Forms.Label();
            this.ChenhLech9 = new System.Windows.Forms.Label();
            this.ChenhLech940 = new System.Windows.Forms.Label();
            this.ChenhLech12 = new System.Windows.Forms.Label();
            this.ChenhLech13 = new System.Windows.Forms.Label();
            this.ChenhLech14 = new System.Windows.Forms.Label();
            this.ChenhLech16 = new System.Windows.Forms.Label();
            this.ChenhLechOvertime = new System.Windows.Forms.Label();
            this.textEditTime8_9 = new DevExpress.XtraEditors.TextEdit();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditOvertime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditTime16_17.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditTime14_16.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditTime13_14.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditTime12_13.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditTime9_11.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditTime9_9_30.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditTime8_9.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel5.ColumnCount = 4;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel5.Controls.Add(this.textEditOvertime, 1, 8);
            this.tableLayoutPanel5.Controls.Add(this.textEditTime16_17, 1, 7);
            this.tableLayoutPanel5.Controls.Add(this.textEditTime14_16, 1, 6);
            this.tableLayoutPanel5.Controls.Add(this.textEditTime13_14, 1, 5);
            this.tableLayoutPanel5.Controls.Add(this.textEditTime12_13, 1, 4);
            this.tableLayoutPanel5.Controls.Add(this.textEditTime9_11, 1, 3);
            this.tableLayoutPanel5.Controls.Add(this.textEditTime9_9_30, 1, 2);
            this.tableLayoutPanel5.Controls.Add(this.lblOvertime, 0, 8);
            this.tableLayoutPanel5.Controls.Add(this.label17, 3, 0);
            this.tableLayoutPanel5.Controls.Add(this.label13, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.label12, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.label11, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.label18, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.label19, 0, 2);
            this.tableLayoutPanel5.Controls.Add(this.ThucTe_8, 2, 1);
            this.tableLayoutPanel5.Controls.Add(this.label20, 0, 3);
            this.tableLayoutPanel5.Controls.Add(this.ThucTe_9, 2, 2);
            this.tableLayoutPanel5.Controls.Add(this.ThucTe_940, 2, 3);
            this.tableLayoutPanel5.Controls.Add(this.ThucTe_12, 2, 4);
            this.tableLayoutPanel5.Controls.Add(this.ThucTe_13, 2, 5);
            this.tableLayoutPanel5.Controls.Add(this.label32, 0, 4);
            this.tableLayoutPanel5.Controls.Add(this.label33, 0, 5);
            this.tableLayoutPanel5.Controls.Add(this.label34, 0, 6);
            this.tableLayoutPanel5.Controls.Add(this.label35, 0, 7);
            this.tableLayoutPanel5.Controls.Add(this.ThucTe_14, 2, 6);
            this.tableLayoutPanel5.Controls.Add(this.ThucTe_16, 2, 7);
            this.tableLayoutPanel5.Controls.Add(this.ThucTe_Overtime, 2, 8);
            this.tableLayoutPanel5.Controls.Add(this.ChenhLech8, 3, 1);
            this.tableLayoutPanel5.Controls.Add(this.ChenhLech9, 3, 2);
            this.tableLayoutPanel5.Controls.Add(this.ChenhLech940, 3, 3);
            this.tableLayoutPanel5.Controls.Add(this.ChenhLech12, 3, 4);
            this.tableLayoutPanel5.Controls.Add(this.ChenhLech13, 3, 5);
            this.tableLayoutPanel5.Controls.Add(this.ChenhLech14, 3, 6);
            this.tableLayoutPanel5.Controls.Add(this.ChenhLech16, 3, 7);
            this.tableLayoutPanel5.Controls.Add(this.ChenhLechOvertime, 3, 8);
            this.tableLayoutPanel5.Controls.Add(this.textEditTime8_9, 1, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 9;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 41F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(634, 575);
            this.tableLayoutPanel5.TabIndex = 6;
            // 
            // textEditOvertime
            // 
            this.textEditOvertime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textEditOvertime.Location = new System.Drawing.Point(256, 247);
            this.textEditOvertime.Name = "textEditOvertime";
            this.textEditOvertime.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.textEditOvertime.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.textEditOvertime.Properties.Appearance.Options.UseFont = true;
            this.textEditOvertime.Properties.Appearance.Options.UseForeColor = true;
            this.textEditOvertime.Properties.Appearance.Options.UseTextOptions = true;
            this.textEditOvertime.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.textEditOvertime.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.textEditOvertime.Properties.NullText = "0";
            this.textEditOvertime.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textEditOvertime.Size = new System.Drawing.Size(119, 24);
            this.textEditOvertime.TabIndex = 43;
            // 
            // textEditTime16_17
            // 
            this.textEditTime16_17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textEditTime16_17.EditValue = "89/750";
            this.textEditTime16_17.Location = new System.Drawing.Point(256, 218);
            this.textEditTime16_17.Name = "textEditTime16_17";
            this.textEditTime16_17.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.textEditTime16_17.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.textEditTime16_17.Properties.Appearance.Options.UseFont = true;
            this.textEditTime16_17.Properties.Appearance.Options.UseForeColor = true;
            this.textEditTime16_17.Properties.Appearance.Options.UseTextOptions = true;
            this.textEditTime16_17.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.textEditTime16_17.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.textEditTime16_17.Properties.NullText = "0";
            this.textEditTime16_17.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textEditTime16_17.Size = new System.Drawing.Size(119, 24);
            this.textEditTime16_17.TabIndex = 42;
            // 
            // textEditTime14_16
            // 
            this.textEditTime14_16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textEditTime14_16.EditValue = "97/661";
            this.textEditTime14_16.Location = new System.Drawing.Point(256, 190);
            this.textEditTime14_16.Name = "textEditTime14_16";
            this.textEditTime14_16.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.textEditTime14_16.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.textEditTime14_16.Properties.Appearance.Options.UseFont = true;
            this.textEditTime14_16.Properties.Appearance.Options.UseForeColor = true;
            this.textEditTime14_16.Properties.Appearance.Options.UseTextOptions = true;
            this.textEditTime14_16.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.textEditTime14_16.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.textEditTime14_16.Properties.NullText = "0";
            this.textEditTime14_16.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textEditTime14_16.Size = new System.Drawing.Size(119, 24);
            this.textEditTime14_16.TabIndex = 41;
            // 
            // textEditTime13_14
            // 
            this.textEditTime13_14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textEditTime13_14.EditValue = "129/564";
            this.textEditTime13_14.Location = new System.Drawing.Point(256, 162);
            this.textEditTime13_14.Name = "textEditTime13_14";
            this.textEditTime13_14.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.textEditTime13_14.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.textEditTime13_14.Properties.Appearance.Options.UseFont = true;
            this.textEditTime13_14.Properties.Appearance.Options.UseForeColor = true;
            this.textEditTime13_14.Properties.Appearance.Options.UseTextOptions = true;
            this.textEditTime13_14.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.textEditTime13_14.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.textEditTime13_14.Properties.NullText = "0";
            this.textEditTime13_14.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textEditTime13_14.Size = new System.Drawing.Size(119, 24);
            this.textEditTime13_14.TabIndex = 40;
            // 
            // textEditTime12_13
            // 
            this.textEditTime12_13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textEditTime12_13.EditValue = "97/435";
            this.textEditTime12_13.Location = new System.Drawing.Point(256, 131);
            this.textEditTime12_13.Name = "textEditTime12_13";
            this.textEditTime12_13.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.textEditTime12_13.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.textEditTime12_13.Properties.Appearance.Options.UseFont = true;
            this.textEditTime12_13.Properties.Appearance.Options.UseForeColor = true;
            this.textEditTime12_13.Properties.Appearance.Options.UseTextOptions = true;
            this.textEditTime12_13.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.textEditTime12_13.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.textEditTime12_13.Properties.NullText = "0";
            this.textEditTime12_13.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textEditTime12_13.Size = new System.Drawing.Size(119, 24);
            this.textEditTime12_13.TabIndex = 39;
            // 
            // textEditTime9_11
            // 
            this.textEditTime9_11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textEditTime9_11.EditValue = "145/300";
            this.textEditTime9_11.Location = new System.Drawing.Point(256, 103);
            this.textEditTime9_11.Name = "textEditTime9_11";
            this.textEditTime9_11.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.textEditTime9_11.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.textEditTime9_11.Properties.Appearance.Options.UseFont = true;
            this.textEditTime9_11.Properties.Appearance.Options.UseForeColor = true;
            this.textEditTime9_11.Properties.Appearance.Options.UseTextOptions = true;
            this.textEditTime9_11.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.textEditTime9_11.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.textEditTime9_11.Properties.NullText = "0";
            this.textEditTime9_11.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textEditTime9_11.Size = new System.Drawing.Size(119, 24);
            this.textEditTime9_11.TabIndex = 38;
            // 
            // textEditTime9_9_30
            // 
            this.textEditTime9_9_30.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textEditTime9_9_30.EditValue = "80/155";
            this.textEditTime9_9_30.Location = new System.Drawing.Point(256, 74);
            this.textEditTime9_9_30.Name = "textEditTime9_9_30";
            this.textEditTime9_9_30.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.textEditTime9_9_30.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.textEditTime9_9_30.Properties.Appearance.Options.UseFont = true;
            this.textEditTime9_9_30.Properties.Appearance.Options.UseForeColor = true;
            this.textEditTime9_9_30.Properties.Appearance.Options.UseTextOptions = true;
            this.textEditTime9_9_30.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.textEditTime9_9_30.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.textEditTime9_9_30.Properties.NullText = "0";
            this.textEditTime9_9_30.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textEditTime9_9_30.Size = new System.Drawing.Size(119, 24);
            this.textEditTime9_9_30.TabIndex = 37;
            // 
            // lblOvertime
            // 
            this.lblOvertime.AutoSize = true;
            this.lblOvertime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOvertime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOvertime.Location = new System.Drawing.Point(4, 244);
            this.lblOvertime.Name = "lblOvertime";
            this.lblOvertime.Size = new System.Drawing.Size(245, 330);
            this.lblOvertime.TabIndex = 21;
            this.lblOvertime.Text = "Overtime";
            this.lblOvertime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(508, 1);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(122, 41);
            this.label17.TabIndex = 3;
            this.label17.Text = "Chênh lệch";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(382, 1);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(119, 41);
            this.label13.TabIndex = 2;
            this.label13.Text = "Thực tế";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(256, 1);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(119, 41);
            this.label12.TabIndex = 1;
            this.label12.Text = "Kế hoạch";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(4, 1);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(245, 41);
            this.label11.TabIndex = 0;
            this.label11.Text = "Thời gian";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(4, 43);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(245, 27);
            this.label18.TabIndex = 4;
            this.label18.Text = "8:05 ~ 9:00";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(4, 71);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(245, 28);
            this.label19.TabIndex = 5;
            this.label19.Text = "9:00 ~ 9:50";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ThucTe_8
            // 
            this.ThucTe_8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ThucTe_8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ThucTe_8.ForeColor = System.Drawing.Color.Blue;
            this.ThucTe_8.Location = new System.Drawing.Point(382, 43);
            this.ThucTe_8.Name = "ThucTe_8";
            this.ThucTe_8.Size = new System.Drawing.Size(119, 27);
            this.ThucTe_8.TabIndex = 7;
            this.ThucTe_8.Text = "0";
            this.ThucTe_8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(4, 100);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(245, 27);
            this.label20.TabIndex = 8;
            this.label20.Text = "10:00 ~ 11:45";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ThucTe_9
            // 
            this.ThucTe_9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ThucTe_9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ThucTe_9.ForeColor = System.Drawing.Color.Blue;
            this.ThucTe_9.Location = new System.Drawing.Point(382, 71);
            this.ThucTe_9.Name = "ThucTe_9";
            this.ThucTe_9.Size = new System.Drawing.Size(119, 28);
            this.ThucTe_9.TabIndex = 10;
            this.ThucTe_9.Text = "0";
            this.ThucTe_9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ThucTe_940
            // 
            this.ThucTe_940.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ThucTe_940.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ThucTe_940.ForeColor = System.Drawing.Color.Blue;
            this.ThucTe_940.Location = new System.Drawing.Point(382, 100);
            this.ThucTe_940.Name = "ThucTe_940";
            this.ThucTe_940.Size = new System.Drawing.Size(119, 27);
            this.ThucTe_940.TabIndex = 12;
            this.ThucTe_940.Text = "0";
            this.ThucTe_940.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ThucTe_12
            // 
            this.ThucTe_12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ThucTe_12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ThucTe_12.ForeColor = System.Drawing.Color.Blue;
            this.ThucTe_12.Location = new System.Drawing.Point(382, 128);
            this.ThucTe_12.Name = "ThucTe_12";
            this.ThucTe_12.Size = new System.Drawing.Size(119, 30);
            this.ThucTe_12.TabIndex = 14;
            this.ThucTe_12.Text = "0";
            this.ThucTe_12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ThucTe_13
            // 
            this.ThucTe_13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ThucTe_13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ThucTe_13.ForeColor = System.Drawing.Color.Blue;
            this.ThucTe_13.Location = new System.Drawing.Point(382, 159);
            this.ThucTe_13.Name = "ThucTe_13";
            this.ThucTe_13.Size = new System.Drawing.Size(119, 27);
            this.ThucTe_13.TabIndex = 16;
            this.ThucTe_13.Text = "0";
            this.ThucTe_13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label32.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(4, 128);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(245, 30);
            this.label32.TabIndex = 17;
            this.label32.Text = "12:30~ 13:30";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.Location = new System.Drawing.Point(4, 159);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(245, 27);
            this.label33.TabIndex = 18;
            this.label33.Text = "13:30 ~ 14:50";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.Location = new System.Drawing.Point(4, 187);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(245, 27);
            this.label34.TabIndex = 19;
            this.label34.Text = "14:50 ~ 16:00";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label35.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.Location = new System.Drawing.Point(4, 215);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(245, 28);
            this.label35.TabIndex = 20;
            this.label35.Text = "16:00 ~ 16:55";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ThucTe_14
            // 
            this.ThucTe_14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ThucTe_14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ThucTe_14.ForeColor = System.Drawing.Color.Blue;
            this.ThucTe_14.Location = new System.Drawing.Point(382, 187);
            this.ThucTe_14.Name = "ThucTe_14";
            this.ThucTe_14.Size = new System.Drawing.Size(119, 27);
            this.ThucTe_14.TabIndex = 24;
            this.ThucTe_14.Text = "0";
            this.ThucTe_14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ThucTe_16
            // 
            this.ThucTe_16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ThucTe_16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ThucTe_16.ForeColor = System.Drawing.Color.Blue;
            this.ThucTe_16.Location = new System.Drawing.Point(382, 215);
            this.ThucTe_16.Name = "ThucTe_16";
            this.ThucTe_16.Size = new System.Drawing.Size(119, 28);
            this.ThucTe_16.TabIndex = 25;
            this.ThucTe_16.Text = "0";
            this.ThucTe_16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ThucTe_Overtime
            // 
            this.ThucTe_Overtime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ThucTe_Overtime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ThucTe_Overtime.ForeColor = System.Drawing.Color.Blue;
            this.ThucTe_Overtime.Location = new System.Drawing.Point(382, 244);
            this.ThucTe_Overtime.Name = "ThucTe_Overtime";
            this.ThucTe_Overtime.Size = new System.Drawing.Size(119, 330);
            this.ThucTe_Overtime.TabIndex = 26;
            this.ThucTe_Overtime.Text = "0";
            this.ThucTe_Overtime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ChenhLech8
            // 
            this.ChenhLech8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChenhLech8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChenhLech8.ForeColor = System.Drawing.Color.Blue;
            this.ChenhLech8.Location = new System.Drawing.Point(508, 43);
            this.ChenhLech8.Name = "ChenhLech8";
            this.ChenhLech8.Size = new System.Drawing.Size(122, 27);
            this.ChenhLech8.TabIndex = 28;
            this.ChenhLech8.Text = "0";
            this.ChenhLech8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ChenhLech9
            // 
            this.ChenhLech9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChenhLech9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChenhLech9.ForeColor = System.Drawing.Color.Blue;
            this.ChenhLech9.Location = new System.Drawing.Point(508, 71);
            this.ChenhLech9.Name = "ChenhLech9";
            this.ChenhLech9.Size = new System.Drawing.Size(122, 28);
            this.ChenhLech9.TabIndex = 29;
            this.ChenhLech9.Text = "0";
            this.ChenhLech9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ChenhLech940
            // 
            this.ChenhLech940.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChenhLech940.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChenhLech940.ForeColor = System.Drawing.Color.Blue;
            this.ChenhLech940.Location = new System.Drawing.Point(508, 100);
            this.ChenhLech940.Name = "ChenhLech940";
            this.ChenhLech940.Size = new System.Drawing.Size(122, 27);
            this.ChenhLech940.TabIndex = 30;
            this.ChenhLech940.Text = "0";
            this.ChenhLech940.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ChenhLech12
            // 
            this.ChenhLech12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChenhLech12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChenhLech12.ForeColor = System.Drawing.Color.Blue;
            this.ChenhLech12.Location = new System.Drawing.Point(508, 128);
            this.ChenhLech12.Name = "ChenhLech12";
            this.ChenhLech12.Size = new System.Drawing.Size(122, 30);
            this.ChenhLech12.TabIndex = 31;
            this.ChenhLech12.Text = "0";
            this.ChenhLech12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ChenhLech13
            // 
            this.ChenhLech13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChenhLech13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChenhLech13.ForeColor = System.Drawing.Color.Blue;
            this.ChenhLech13.Location = new System.Drawing.Point(508, 159);
            this.ChenhLech13.Name = "ChenhLech13";
            this.ChenhLech13.Size = new System.Drawing.Size(122, 27);
            this.ChenhLech13.TabIndex = 32;
            this.ChenhLech13.Text = "0";
            this.ChenhLech13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ChenhLech14
            // 
            this.ChenhLech14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChenhLech14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChenhLech14.ForeColor = System.Drawing.Color.Blue;
            this.ChenhLech14.Location = new System.Drawing.Point(508, 187);
            this.ChenhLech14.Name = "ChenhLech14";
            this.ChenhLech14.Size = new System.Drawing.Size(122, 27);
            this.ChenhLech14.TabIndex = 33;
            this.ChenhLech14.Text = "0";
            this.ChenhLech14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ChenhLech16
            // 
            this.ChenhLech16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChenhLech16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChenhLech16.ForeColor = System.Drawing.Color.Blue;
            this.ChenhLech16.Location = new System.Drawing.Point(508, 215);
            this.ChenhLech16.Name = "ChenhLech16";
            this.ChenhLech16.Size = new System.Drawing.Size(122, 28);
            this.ChenhLech16.TabIndex = 34;
            this.ChenhLech16.Text = "0";
            this.ChenhLech16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ChenhLechOvertime
            // 
            this.ChenhLechOvertime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChenhLechOvertime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChenhLechOvertime.ForeColor = System.Drawing.Color.Blue;
            this.ChenhLechOvertime.Location = new System.Drawing.Point(508, 244);
            this.ChenhLechOvertime.Name = "ChenhLechOvertime";
            this.ChenhLechOvertime.Size = new System.Drawing.Size(122, 330);
            this.ChenhLechOvertime.TabIndex = 35;
            this.ChenhLechOvertime.Text = "0";
            this.ChenhLechOvertime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textEditTime8_9
            // 
            this.textEditTime8_9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textEditTime8_9.EditValue = "75/75";
            this.textEditTime8_9.Location = new System.Drawing.Point(256, 46);
            this.textEditTime8_9.Name = "textEditTime8_9";
            this.textEditTime8_9.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.textEditTime8_9.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.textEditTime8_9.Properties.Appearance.Options.UseFont = true;
            this.textEditTime8_9.Properties.Appearance.Options.UseForeColor = true;
            this.textEditTime8_9.Properties.Appearance.Options.UseTextOptions = true;
            this.textEditTime8_9.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.textEditTime8_9.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.textEditTime8_9.Properties.NullText = "0";
            this.textEditTime8_9.Size = new System.Drawing.Size(119, 24);
            this.textEditTime8_9.TabIndex = 36;
            // 
            // Test
            // 
            this.ClientSize = new System.Drawing.Size(634, 575);
            this.Controls.Add(this.tableLayoutPanel5);
            this.Name = "Test";
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEditOvertime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditTime16_17.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditTime14_16.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditTime13_14.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditTime12_13.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditTime9_11.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditTime9_9_30.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditTime8_9.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        //static void Main()
        //{
        //    Application.Run(new Test());
        //}
    }
}