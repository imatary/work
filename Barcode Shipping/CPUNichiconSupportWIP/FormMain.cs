using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace CPUNichiconSupportWIP
{
    public partial class FormMain : Form
    {
        private bool m_bIsWatching;
        public bool m_bDirty;
        private FileSystemWatcher m_Watcher;
        string path = null;
        string stationNo = null;
        string fullPath = "";
        public FormMain()
        {
            InitializeComponent();
            Ultils.RegisterInStartup(true, Application.ExecutablePath);
            lblVersion.Text = Ultils.GetRunningVersion();
            m_bDirty = false;
            m_bIsWatching = false;
            LoadModels();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            path = Ultils.GetValueRegistryKey("PATH");
            stationNo = Ultils.GetValueRegistryKey("STATION_NO");

            if(string.IsNullOrEmpty(path))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtPath, "Field required!");
                txtPath.Focus();
            }
            else
            {
                txtPath.Text = path;
            }
            if (string.IsNullOrEmpty(stationNo))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtStationNO, "Field required!");
                txtStationNO.Focus();
            }
            else
            {
                txtStationNO.Text = stationNo;
            }
            if (string.IsNullOrEmpty(cboModel.SelectedText))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboModel, "Field required!");
                cboModel.Focus();
            }
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string value = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            if (value != null)
            {
                if (value == "PASS")
                {
                    dataGridView1.Columns[e.ColumnIndex].DefaultCellStyle.BackColor = Color.Green;
                    dataGridView1.Columns[e.ColumnIndex].DefaultCellStyle.ForeColor = Color.White;
                }
                else if (value == "FAIL")
                {
                    dataGridView1.Columns[e.ColumnIndex].DefaultCellStyle.BackColor = Color.Red;
                    dataGridView1.Columns[e.ColumnIndex].DefaultCellStyle.ForeColor = Color.White;
                }
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            DialogResult open = folderBrowserDialog1.ShowDialog();
            if (open == DialogResult.OK)
            {
                txtPath.Text = folderBrowserDialog1.SelectedPath;
                if (string.IsNullOrEmpty(txtStationNO.Text))
                {
                    txtStationNO.Focus();
                }
                else
                {
                    btnBrowse.Focus();
                }
            }
        }

        private void btnStartWatch_Click(object sender, EventArgs e)
        {
            bool isVaild = true;
            if (string.IsNullOrEmpty(txtStationNO.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(txtStationNO, "Field required!");
                txtStationNO.Focus();
                isVaild = false;
            }
            else if (string.IsNullOrEmpty(txtPath.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(panel4, "Field required!");
                txtPath.Focus();
                isVaild = false;
            }
            else if (string.IsNullOrEmpty(cboModel.Text))
            {
                errorProvider1.Clear();
                errorProvider1.SetError(cboModel, "Field required!");
                cboModel.Focus();
                isVaild = false;
            }
            else if (isVaild == true)
            {
                Ultils.WriteRegistryKey(txtStationNO.Text, txtPath.Text);
                if (m_bIsWatching)
                {
                    m_bIsWatching = false;
                    m_Watcher.EnableRaisingEvents = false;
                    m_Watcher.Dispose();
                    txtStationNO.Enabled = true;
                    panel4.Enabled = true;
                    cboModel.Enabled = true;
                    btnStartWatch.BackColor = Color.Green;
                    btnStartWatch.Text = "Start Watching";
                    lblConnected.Visible = false;
                    lblAdd.Enabled = true;
                    CloseConnection(fullPath);
                    DefaultMessage();
                }
                else
                {
                    if (CheckConnection(fullPath) == true)
                    {
                        DefaultMessage();

                        lblAdd.Enabled = false;
                        m_bIsWatching = true;
                        txtStationNO.Enabled = false;
                        panel4.Enabled = false;
                        cboModel.Enabled = false;

                        btnStartWatch.BackColor = Color.Red;
                        btnStartWatch.Text = "Stop Watching";

                        m_Watcher = new FileSystemWatcher();
                        m_Watcher.IncludeSubdirectories = true;

                        string path = Ultils.GetValueRegistryKey("PATH").ToString() + "\\";

                        m_Watcher.Filter = cboModel.Text + ".mdb";
                        m_Watcher.Path = path;


                        m_Watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                                         | NotifyFilters.FileName | NotifyFilters.DirectoryName | NotifyFilters.LastAccess;
                        m_Watcher.Changed += new FileSystemEventHandler(OnChanged);
                        m_Watcher.Created += new FileSystemEventHandler(OnChanged);
                        m_Watcher.EnableRaisingEvents = true;
                    }
                    else
                    {
                        fullPath = "";
                        string message = "Kết nối đến database thất bại. Vui lòng kiểm tra lại đường dẫn và thử lại.\nNếu vẫn không được, liên hệ với phòng IT để được hỗ trợ!";
                        ErrorMessage("NG", message);
                        errorProvider1.Clear();
                        errorProvider1.SetError(panel4, message);
                        txtPath.Focus();
                        CloseConnection(fullPath);
                    }  
                }
            }
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            if (!m_bDirty)
            {
                if (e.ChangeType == WatcherChangeTypes.Changed || e.ChangeType==WatcherChangeTypes.Created)
                {
                    //fullPath = e.FullPath;
                    m_bDirty = true;
                }
            }
        }

        /// <summary>
        /// Hot key
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Shift | Keys.F2:
                    {
                        panel4.Enabled = true;
                        txtStationNO.Enabled = true;
                        
                        return true;
                    }
                case Keys.Shift | Keys.F3:
                    {
                        panel4.Enabled = false;
                        txtStationNO.Enabled = false;

                        return true;
                    }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        int pass = 0, total = 0, ng = 0;

        private void txtPath_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPath.Text))
            {
                Ultils.WriteRegistryKey(txtStationNO.Text, txtPath.Text);
                errorProvider1.Clear();
            }
        }

        private void txtStationNO_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtStationNO.Text))
            {
                Ultils.WriteRegistryKey(txtStationNO.Text, txtPath.Text);
                errorProvider1.Clear();
            }
        }

        private void cboModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            fullPath = path + "\\" + cboModel.SelectedValue + ".mdb";
            errorProvider1.Clear();
        }

        /// <summary>
        /// 
        /// </summary>
        private void RunWorkingDatabase(string fullPath)
        {
            
            //string strSQL = $"SELECT TOP 1 *  FROM PTS_HEADER  WHERE EndDateTime >= #1/7/2017# ORDER BY EndDateTime DESC";
            string strSQL = $"SELECT TOP 1 *  FROM PTS_HEADER  WHERE EndDateTime >= #{DateTime.Now.Date}# ORDER BY EndDateTime DESC";

            OleDbConnection myConn = OpenConnection(fullPath);
            OleDbDataAdapter myCmd = new OleDbDataAdapter(strSQL, myConn);
            DataSet dtSet = new DataSet();
            myCmd.Fill(dtSet, "PTS_HEADER");
            DataTable dTable = dtSet.Tables[0];
            List<Item> items = new List<Item>();
            if (dTable.Rows.Count > 0)
            {
                var item = new Item()
                {
                    BoardNo = dTable.Rows[0]["Serial"].ToString(),
                    Model = dTable.Rows[0]["Model"].ToString(),
                    Result = int.Parse(dTable.Rows[0]["Result"].ToString()),
                    EndDateTime = DateTime.Parse(dTable.Rows[0]["EndDateTime"].ToString())
                };

                if (item != null)
                {
                    if(item.Model == cboModel.SelectedValue.ToString())
                    {
                        items.Add(item);
                        dataGridView1.AutoGenerateColumns = false;
                        dataGridView1.DataSource = items;

                        if (item.Result == 1)
                        {
                            pass = pass + 1;
                            lblPASS.Text = pass.ToString();
                            SuccessMessage("OK", $"Board [{item.BoardNo}] OK!");
                        }
                        if (item.Result == 0)
                        {
                            ng = ng + 1;
                            lblNG.Text = ng.ToString();
                            ErrorMessage("NG", $"Board [{item.BoardNo}] NG!");
                        }
                        total = pass + ng;
                        lblTotal.Text = total.ToString();

                        lblAdd.Enabled = true;
                        
                        Ultils.CreateFileLog(item.Model, item.BoardNo, item.Status, stationNo, DateTime.Now.ToString("yyMMddHHmmss"));
                    }
                    else
                    {
                        ErrorMessage("NG", $"Sai Model. Vui lòng chọn lại Model cho chính xác." +
                            $"\nBoard [{item.BoardNo}] NG!" +
                            $"\nModel: {item.Model}");
                    }
                }
                
            }
            else
            {
                lblStatusMessage.Visible = true;
                lblStatusMessage.Text = "Check local format time!";
                ErrorMessage("NG", "Check local format time!");
            }
            CloseConnection(fullPath);
        }

        /// <summary>
        /// 
        /// </summary>
        private void LoadModels()
        {
            List<string> listModels = new List<string>();
            if (Ultils.GetValueRegistryKey("Models") != null)
            {
                string[] models = Ultils.GetValueRegistryKey("Models").Split(';');

                foreach (var item in models)
                {
                    listModels.Add(item);
                }
                cboModel.DataSource = listModels;
            }
            else
            {
                string[] models = {
                "ZSFLA18GA",
                "ZSFLA18HA",
                "ZSFLA18ZA",
                "ZSFLA32GA",
                "ZSFLA32HA",
                "ZSFLB06GA",
                "ZSFLB06HA",
                "ZSFLC15GA",
                "ZSFLC15HA",
                "ZSFLD22_REV5",
                "ZSFLD22IO",
                "ZSSFE08",
                "ZSSFE09"
                };

                foreach (var item in models)
                {
                    Ultils.WriteRegistry("Models", item);
                    listModels.Add(item);
                }
                cboModel.DataSource = listModels;
            }
        }

        private void lblAdd_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new FormAddModel().ShowDialog();

            LoadModels();
        }

        /// <summary>
        /// Kiểm tra kết nối
        /// </summary>
        /// <returns></returns>
        private bool CheckConnection(string pathFile)
        {
            try
            {
                string strConnection = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={pathFile};Locale Identifier=1033;Jet OLEDB:Engine Type=5;Persist Security Info=True";
                OleDbConnection myConn = new OleDbConnection(strConnection);

                if (myConn.State == ConnectionState.Closed)
                {
                    myConn.Open();
                    lblConnected.Visible = true;
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }

        /// <summary>
        /// Mở kết nối đến database
        /// </summary>
        /// <param name="pathDb"></param>
        /// <returns></returns>
        private OleDbConnection OpenConnection(string pathDb)
        {
            try
            {
                string strDSN = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = {pathDb}";
                OleDbConnection myConn = new OleDbConnection(strDSN);

                if (myConn.State == ConnectionState.Closed)
                {
                    myConn.Open();
                    return myConn;
                }

                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Đóng kết nối
        /// </summary>
        /// <param name="pathDb"></param>
        /// <returns></returns>
        private void CloseConnection(string pathDb)
        {
            try
            {
                string strDSN = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = {pathDb}";
                OleDbConnection myConn = new OleDbConnection(strDSN);

                if (myConn.State == ConnectionState.Open)
                {
                    myConn.Dispose();
                    myConn.Close();
                    fullPath = "";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void tmrEditNotify_Tick(object sender, EventArgs e)
        {
            if (m_bDirty)
            {
                RunWorkingDatabase(fullPath);
                m_bDirty = false;
            }
        }
        private void SuccessMessage(string str_status, string str_message)
        {
            lblStatus.Text = str_status;
            lblStatus.BackColor = Color.DarkGreen;

            lblMessage.Text = str_message;
            lblMessage.BackColor = Color.DarkGreen;
        }
        private void ErrorMessage(string str_status, string str_message)
        {
            lblStatus.Text = str_status;
            lblStatus.BackColor = Color.DarkRed;

            lblMessage.Text = str_message;
            lblMessage.BackColor = Color.DarkRed;
        }
        private void DefaultMessage()
        {
            lblStatus.Text = @"[N\A]";
            lblStatus.BackColor = Color.FromArgb(255, 128, 0);

            lblMessage.Text = "no results";
            lblMessage.BackColor = Color.FromArgb(255, 128, 0);
        }

    }
}
