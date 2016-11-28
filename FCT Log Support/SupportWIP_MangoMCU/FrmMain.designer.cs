namespace SupportWIP_MangoMCU
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.timer1 = new System.Windows.Forms.Timer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Tbx_Login = new System.Windows.Forms.TextBox();
            this.Chb_EnableEdit = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.Lbl_Timer = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.Btn_AutoRun = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Btn_ResetTotal = new System.Windows.Forms.Button();
            this.Tbx_BarCode = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.Tbx_Total = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.Tbx_NG = new System.Windows.Forms.Button();
            this.Tbx_Pass = new System.Windows.Forms.Button();
            this.Panel_Result = new System.Windows.Forms.Panel();
            this.Lbl_Result = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.Btn_Search = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.Tbx_Search = new System.Windows.Forms.TextBox();
            this.Btn_Save = new System.Windows.Forms.Button();
            this.DGV_Model = new System.Windows.Forms.DataGridView();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.Btn_SearchStation = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Tbx_SearchStation = new System.Windows.Forms.TextBox();
            this.Btn_SaveStation = new System.Windows.Forms.Button();
            this.DGV_Station = new System.Windows.Forms.DataGridView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.Lbl_PathFolderOutput = new System.Windows.Forms.Label();
            this.Lbl_PathFolderInput = new System.Windows.Forms.Label();
            this.Btn_SavePath = new System.Windows.Forms.Button();
            this.Btn_OpenFolderOutput = new System.Windows.Forms.Button();
            this.Btn_OpenFolderInput = new System.Windows.Forms.Button();
            this.folderBrowserDialog_FolderInput = new System.Windows.Forms.FolderBrowserDialog();
            this.folderBrowserDialog_FolderOutput = new System.Windows.Forms.FolderBrowserDialog();
            this.tmrEditNotify = new System.Windows.Forms.Timer();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.Panel_Result.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Model)).BeginInit();
            this.tabPage4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Station)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Tbx_Login);
            this.groupBox2.Controls.Add(this.Chb_EnableEdit);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.Lbl_Timer);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 334);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(621, 37);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // Tbx_Login
            // 
            this.Tbx_Login.Location = new System.Drawing.Point(172, 13);
            this.Tbx_Login.Name = "Tbx_Login";
            this.Tbx_Login.PasswordChar = '*';
            this.Tbx_Login.Size = new System.Drawing.Size(10, 20);
            this.Tbx_Login.TabIndex = 23;
            this.Tbx_Login.Visible = false;
            this.Tbx_Login.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Tbx_Login_KeyDown);
            // 
            // Chb_EnableEdit
            // 
            this.Chb_EnableEdit.AutoSize = true;
            this.Chb_EnableEdit.Location = new System.Drawing.Point(145, 16);
            this.Chb_EnableEdit.Name = "Chb_EnableEdit";
            this.Chb_EnableEdit.Size = new System.Drawing.Size(15, 14);
            this.Chb_EnableEdit.TabIndex = 22;
            this.Chb_EnableEdit.UseVisualStyleBackColor = true;
            this.Chb_EnableEdit.CheckedChanged += new System.EventHandler(this.Chb_EnableEdit_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Blue;
            this.label10.Location = new System.Drawing.Point(418, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(201, 15);
            this.label10.TabIndex = 21;
            this.label10.Text = "Support by Mr Duong: 2022(PE-PE)";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(3, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "© Copyright";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(67, 13);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 17);
            this.label8.TabIndex = 17;
            this.label8.Text = "UMCVN";
            // 
            // Lbl_Timer
            // 
            this.Lbl_Timer.AutoSize = true;
            this.Lbl_Timer.ForeColor = System.Drawing.Color.Red;
            this.Lbl_Timer.Location = new System.Drawing.Point(217, 17);
            this.Lbl_Timer.Name = "Lbl_Timer";
            this.Lbl_Timer.Size = new System.Drawing.Size(0, 13);
            this.Lbl_Timer.TabIndex = 17;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(621, 334);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(3, 16);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(615, 315);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Transparent;
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(607, 286);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Logs";
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.LightGray;
            this.groupBox4.Controls.Add(this.Btn_AutoRun);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(4, 38);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(269, 246);
            this.groupBox4.TabIndex = 25;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "INPUT";
            // 
            // Btn_AutoRun
            // 
            this.Btn_AutoRun.BackColor = System.Drawing.Color.Blue;
            this.Btn_AutoRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_AutoRun.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Btn_AutoRun.Location = new System.Drawing.Point(52, 132);
            this.Btn_AutoRun.Name = "Btn_AutoRun";
            this.Btn_AutoRun.Size = new System.Drawing.Size(166, 55);
            this.Btn_AutoRun.TabIndex = 31;
            this.Btn_AutoRun.Text = "Start Scan";
            this.Btn_AutoRun.UseVisualStyleBackColor = false;
            this.Btn_AutoRun.Click += new System.EventHandler(this.Btn_AutoRun_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(9, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 15);
            this.label3.TabIndex = 27;
            this.label3.Text = "Station:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(12, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(0, 22);
            this.label4.TabIndex = 26;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.LightGray;
            this.groupBox3.Controls.Add(this.Btn_ResetTotal);
            this.groupBox3.Controls.Add(this.Tbx_BarCode);
            this.groupBox3.Controls.Add(this.button6);
            this.groupBox3.Controls.Add(this.button5);
            this.groupBox3.Controls.Add(this.Tbx_Total);
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Controls.Add(this.Tbx_NG);
            this.groupBox3.Controls.Add(this.Tbx_Pass);
            this.groupBox3.Controls.Add(this.Panel_Result);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(279, 38);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(324, 246);
            this.groupBox3.TabIndex = 25;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "OUTPUT";
            // 
            // Btn_ResetTotal
            // 
            this.Btn_ResetTotal.BackColor = System.Drawing.Color.Blue;
            this.Btn_ResetTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_ResetTotal.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Btn_ResetTotal.Location = new System.Drawing.Point(274, 216);
            this.Btn_ResetTotal.Name = "Btn_ResetTotal";
            this.Btn_ResetTotal.Size = new System.Drawing.Size(45, 25);
            this.Btn_ResetTotal.TabIndex = 31;
            this.Btn_ResetTotal.Text = "Reset";
            this.Btn_ResetTotal.UseVisualStyleBackColor = false;
            this.Btn_ResetTotal.Click += new System.EventHandler(this.Btn_ResetTotal_Click);
            // 
            // Tbx_BarCode
            // 
            this.Tbx_BarCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tbx_BarCode.ForeColor = System.Drawing.Color.Lime;
            this.Tbx_BarCode.Location = new System.Drawing.Point(7, 25);
            this.Tbx_BarCode.Name = "Tbx_BarCode";
            this.Tbx_BarCode.Size = new System.Drawing.Size(310, 23);
            this.Tbx_BarCode.TabIndex = 32;
            this.Tbx_BarCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.DarkGray;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(164, 169);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(66, 45);
            this.button6.TabIndex = 31;
            this.button6.Text = "TOTAL";
            this.button6.UseVisualStyleBackColor = false;
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.DarkGray;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.Color.Red;
            this.button5.Location = new System.Drawing.Point(164, 116);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(66, 47);
            this.button5.TabIndex = 31;
            this.button5.Text = "NG";
            this.button5.UseVisualStyleBackColor = false;
            // 
            // Tbx_Total
            // 
            this.Tbx_Total.BackColor = System.Drawing.Color.DarkGray;
            this.Tbx_Total.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tbx_Total.Location = new System.Drawing.Point(229, 169);
            this.Tbx_Total.Name = "Tbx_Total";
            this.Tbx_Total.Size = new System.Drawing.Size(89, 45);
            this.Tbx_Total.TabIndex = 31;
            this.Tbx_Total.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Tbx_Total.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.DarkGray;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.Blue;
            this.button4.Location = new System.Drawing.Point(164, 60);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(66, 48);
            this.button4.TabIndex = 31;
            this.button4.Text = "PASS";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // Tbx_NG
            // 
            this.Tbx_NG.BackColor = System.Drawing.Color.DarkGray;
            this.Tbx_NG.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tbx_NG.ForeColor = System.Drawing.Color.Red;
            this.Tbx_NG.Location = new System.Drawing.Point(229, 116);
            this.Tbx_NG.Name = "Tbx_NG";
            this.Tbx_NG.Size = new System.Drawing.Size(89, 47);
            this.Tbx_NG.TabIndex = 31;
            this.Tbx_NG.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Tbx_NG.UseVisualStyleBackColor = false;
            // 
            // Tbx_Pass
            // 
            this.Tbx_Pass.BackColor = System.Drawing.Color.DarkGray;
            this.Tbx_Pass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tbx_Pass.ForeColor = System.Drawing.Color.Blue;
            this.Tbx_Pass.Location = new System.Drawing.Point(229, 60);
            this.Tbx_Pass.Name = "Tbx_Pass";
            this.Tbx_Pass.Size = new System.Drawing.Size(89, 48);
            this.Tbx_Pass.TabIndex = 31;
            this.Tbx_Pass.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.Tbx_Pass.UseVisualStyleBackColor = false;
            // 
            // Panel_Result
            // 
            this.Panel_Result.BackColor = System.Drawing.Color.Blue;
            this.Panel_Result.Controls.Add(this.Lbl_Result);
            this.Panel_Result.Location = new System.Drawing.Point(7, 60);
            this.Panel_Result.Name = "Panel_Result";
            this.Panel_Result.Size = new System.Drawing.Size(151, 154);
            this.Panel_Result.TabIndex = 27;
            // 
            // Lbl_Result
            // 
            this.Lbl_Result.AutoSize = true;
            this.Lbl_Result.BackColor = System.Drawing.Color.Blue;
            this.Lbl_Result.Font = new System.Drawing.Font("Arial Narrow", 35F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_Result.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.Lbl_Result.Location = new System.Drawing.Point(3, 49);
            this.Lbl_Result.Name = "Lbl_Result";
            this.Lbl_Result.Size = new System.Drawing.Size(0, 55);
            this.Lbl_Result.TabIndex = 27;
            this.Lbl_Result.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 22F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(194, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 36);
            this.label1.TabIndex = 17;
            this.label1.Text = "FUJIXEROX";
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.LightGray;
            this.tabPage1.Controls.Add(this.Btn_Search);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.Tbx_Search);
            this.tabPage1.Controls.Add(this.Btn_Save);
            this.tabPage1.Controls.Add(this.DGV_Model);
            this.tabPage1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(607, 286);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Model";
            // 
            // Btn_Search
            // 
            this.Btn_Search.BackColor = System.Drawing.Color.Blue;
            this.Btn_Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Search.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Btn_Search.Location = new System.Drawing.Point(3, 3);
            this.Btn_Search.Name = "Btn_Search";
            this.Btn_Search.Size = new System.Drawing.Size(10, 10);
            this.Btn_Search.TabIndex = 20;
            this.Btn_Search.Text = "SEARCH";
            this.Btn_Search.UseVisualStyleBackColor = false;
            this.Btn_Search.Visible = false;
            this.Btn_Search.Click += new System.EventHandler(this.Btn_Search_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Blue;
            this.label6.Location = new System.Drawing.Point(7, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(57, 17);
            this.label6.TabIndex = 19;
            this.label6.Text = "Search:";
            // 
            // Tbx_Search
            // 
            this.Tbx_Search.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tbx_Search.Location = new System.Drawing.Point(79, 21);
            this.Tbx_Search.Name = "Tbx_Search";
            this.Tbx_Search.Size = new System.Drawing.Size(355, 23);
            this.Tbx_Search.TabIndex = 18;
            this.Tbx_Search.TextChanged += new System.EventHandler(this.Tbx_Search_TextChanged);
            // 
            // Btn_Save
            // 
            this.Btn_Save.BackColor = System.Drawing.Color.Blue;
            this.Btn_Save.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Save.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Btn_Save.Location = new System.Drawing.Point(514, 159);
            this.Btn_Save.Name = "Btn_Save";
            this.Btn_Save.Size = new System.Drawing.Size(87, 46);
            this.Btn_Save.TabIndex = 15;
            this.Btn_Save.Text = "SAVE";
            this.Btn_Save.UseVisualStyleBackColor = false;
            this.Btn_Save.Click += new System.EventHandler(this.Btn_Save_Click);
            // 
            // DGV_Model
            // 
            this.DGV_Model.BackgroundColor = System.Drawing.Color.LightGray;
            this.DGV_Model.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DGV_Model.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Model.Location = new System.Drawing.Point(6, 53);
            this.DGV_Model.Name = "DGV_Model";
            this.DGV_Model.Size = new System.Drawing.Size(502, 224);
            this.DGV_Model.TabIndex = 14;
            // 
            // tabPage4
            // 
            this.tabPage4.BackColor = System.Drawing.Color.LightGray;
            this.tabPage4.Controls.Add(this.Btn_SearchStation);
            this.tabPage4.Controls.Add(this.label2);
            this.tabPage4.Controls.Add(this.Tbx_SearchStation);
            this.tabPage4.Controls.Add(this.Btn_SaveStation);
            this.tabPage4.Controls.Add(this.DGV_Station);
            this.tabPage4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(607, 286);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Station";
            // 
            // Btn_SearchStation
            // 
            this.Btn_SearchStation.BackColor = System.Drawing.Color.Blue;
            this.Btn_SearchStation.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_SearchStation.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Btn_SearchStation.Location = new System.Drawing.Point(3, 3);
            this.Btn_SearchStation.Name = "Btn_SearchStation";
            this.Btn_SearchStation.Size = new System.Drawing.Size(10, 11);
            this.Btn_SearchStation.TabIndex = 25;
            this.Btn_SearchStation.Text = "SEARCH";
            this.Btn_SearchStation.UseVisualStyleBackColor = false;
            this.Btn_SearchStation.Visible = false;
            this.Btn_SearchStation.Click += new System.EventHandler(this.Btn_SearchStation_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(5, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 17);
            this.label2.TabIndex = 24;
            this.label2.Text = "Search:";
            // 
            // Tbx_SearchStation
            // 
            this.Tbx_SearchStation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tbx_SearchStation.Location = new System.Drawing.Point(79, 20);
            this.Tbx_SearchStation.Name = "Tbx_SearchStation";
            this.Tbx_SearchStation.Size = new System.Drawing.Size(355, 23);
            this.Tbx_SearchStation.TabIndex = 23;
            this.Tbx_SearchStation.TextChanged += new System.EventHandler(this.Tbx_SearchStation_TextChanged);
            // 
            // Btn_SaveStation
            // 
            this.Btn_SaveStation.BackColor = System.Drawing.Color.Blue;
            this.Btn_SaveStation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_SaveStation.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Btn_SaveStation.Location = new System.Drawing.Point(512, 159);
            this.Btn_SaveStation.Name = "Btn_SaveStation";
            this.Btn_SaveStation.Size = new System.Drawing.Size(89, 46);
            this.Btn_SaveStation.TabIndex = 22;
            this.Btn_SaveStation.Text = "SAVE";
            this.Btn_SaveStation.UseVisualStyleBackColor = false;
            this.Btn_SaveStation.Click += new System.EventHandler(this.Btn_SaveStation_Click);
            // 
            // DGV_Station
            // 
            this.DGV_Station.BackgroundColor = System.Drawing.Color.LightGray;
            this.DGV_Station.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.DGV_Station.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Station.Location = new System.Drawing.Point(6, 52);
            this.DGV_Station.Name = "DGV_Station";
            this.DGV_Station.Size = new System.Drawing.Size(500, 228);
            this.DGV_Station.TabIndex = 21;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.LightGray;
            this.tabPage3.Controls.Add(this.Lbl_PathFolderOutput);
            this.tabPage3.Controls.Add(this.Lbl_PathFolderInput);
            this.tabPage3.Controls.Add(this.Btn_SavePath);
            this.tabPage3.Controls.Add(this.Btn_OpenFolderOutput);
            this.tabPage3.Controls.Add(this.Btn_OpenFolderInput);
            this.tabPage3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(607, 286);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Config path";
            // 
            // Lbl_PathFolderOutput
            // 
            this.Lbl_PathFolderOutput.AutoSize = true;
            this.Lbl_PathFolderOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_PathFolderOutput.ForeColor = System.Drawing.Color.Blue;
            this.Lbl_PathFolderOutput.Location = new System.Drawing.Point(208, 180);
            this.Lbl_PathFolderOutput.Name = "Lbl_PathFolderOutput";
            this.Lbl_PathFolderOutput.Size = new System.Drawing.Size(0, 16);
            this.Lbl_PathFolderOutput.TabIndex = 22;
            // 
            // Lbl_PathFolderInput
            // 
            this.Lbl_PathFolderInput.AutoSize = true;
            this.Lbl_PathFolderInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lbl_PathFolderInput.ForeColor = System.Drawing.Color.Blue;
            this.Lbl_PathFolderInput.Location = new System.Drawing.Point(208, 80);
            this.Lbl_PathFolderInput.Name = "Lbl_PathFolderInput";
            this.Lbl_PathFolderInput.Size = new System.Drawing.Size(0, 16);
            this.Lbl_PathFolderInput.TabIndex = 22;
            // 
            // Btn_SavePath
            // 
            this.Btn_SavePath.BackColor = System.Drawing.Color.Blue;
            this.Btn_SavePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_SavePath.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Btn_SavePath.Location = new System.Drawing.Point(236, 221);
            this.Btn_SavePath.Name = "Btn_SavePath";
            this.Btn_SavePath.Size = new System.Drawing.Size(122, 51);
            this.Btn_SavePath.TabIndex = 21;
            this.Btn_SavePath.Text = "SAVE";
            this.Btn_SavePath.UseVisualStyleBackColor = false;
            this.Btn_SavePath.Click += new System.EventHandler(this.Btn_SavePath_Click);
            // 
            // Btn_OpenFolderOutput
            // 
            this.Btn_OpenFolderOutput.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Btn_OpenFolderOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_OpenFolderOutput.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Btn_OpenFolderOutput.Location = new System.Drawing.Point(200, 121);
            this.Btn_OpenFolderOutput.Name = "Btn_OpenFolderOutput";
            this.Btn_OpenFolderOutput.Size = new System.Drawing.Size(194, 45);
            this.Btn_OpenFolderOutput.TabIndex = 21;
            this.Btn_OpenFolderOutput.Text = "Choose folder Output";
            this.Btn_OpenFolderOutput.UseVisualStyleBackColor = false;
            this.Btn_OpenFolderOutput.Click += new System.EventHandler(this.Btn_OpenFolderOutput_Click);
            // 
            // Btn_OpenFolderInput
            // 
            this.Btn_OpenFolderInput.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.Btn_OpenFolderInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_OpenFolderInput.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.Btn_OpenFolderInput.Location = new System.Drawing.Point(200, 20);
            this.Btn_OpenFolderInput.Name = "Btn_OpenFolderInput";
            this.Btn_OpenFolderInput.Size = new System.Drawing.Size(194, 45);
            this.Btn_OpenFolderInput.TabIndex = 21;
            this.Btn_OpenFolderInput.Text = "Choose folder Input";
            this.Btn_OpenFolderInput.UseVisualStyleBackColor = false;
            this.Btn_OpenFolderInput.Click += new System.EventHandler(this.Btn_OpenFolderInput_Click);
            // 
            // tmrEditNotify
            // 
            this.tmrEditNotify.Tick += new System.EventHandler(this.tmrEditNotify_Tick);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 371);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Support WIP";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.Panel_Result.ResumeLayout(false);
            this.Panel_Result.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Model)).EndInit();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Station)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.TabControl tabControl1;
        public System.Windows.Forms.TabPage tabPage2;
        public System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button Btn_Search;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Tbx_Search;
        private System.Windows.Forms.Button Btn_Save;
        private System.Windows.Forms.DataGridView DGV_Model;
        private System.Windows.Forms.Label Lbl_Timer;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog_FolderInput;
        private System.Windows.Forms.Button Btn_OpenFolderOutput;
        private System.Windows.Forms.Button Btn_OpenFolderInput;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog_FolderOutput;
        private System.Windows.Forms.Label Lbl_PathFolderOutput;
        private System.Windows.Forms.Label Lbl_PathFolderInput;
        private System.Windows.Forms.Button Btn_SavePath;
        private System.Windows.Forms.GroupBox groupBox3;
        public System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button Btn_SearchStation;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Tbx_SearchStation;
        private System.Windows.Forms.Button Btn_SaveStation;
        private System.Windows.Forms.DataGridView DGV_Station;
        private System.Windows.Forms.Timer tmrEditNotify;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button Btn_AutoRun;
        //private App_Helpers.MultiColumnComboBox Cbx_Station;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel Panel_Result;
        private System.Windows.Forms.Label Lbl_Result;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button Tbx_Pass;
        private System.Windows.Forms.Button Tbx_Total;
        private System.Windows.Forms.Button Tbx_NG;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox Tbx_BarCode;
        //private App_Helpers.MultiColumnComboBox Cbx_Models;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button Btn_ResetTotal;
        public System.Windows.Forms.CheckBox Chb_EnableEdit;
        private System.Windows.Forms.TextBox Tbx_Login;
    }
}