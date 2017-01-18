using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
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
        public FormMain()
        {
            InitializeComponent();
            Ultils.RegisterInStartup(true, Application.ExecutablePath);
            lblVersion.Text = Ultils.GetRunningVersion();
            m_bDirty = false;
            m_bIsWatching = false;
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            path = ConfigurationManager.AppSettings["PathInput"];
            stationNo = ConfigurationManager.AppSettings["StationNo"];

            if(path == "" || stationNo == "")
            {
                txtStationNO.Enabled = true;
                panel4.Enabled = true;
            }
            else
            {
                txtStationNO.Text = stationNo;
                txtPath.Text = path;
                btnStartWatch.PerformClick();
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
            DialogResult open = openFileDialog1.ShowDialog();
            if (open == DialogResult.OK)
            {
                txtPath.Text = openFileDialog1.FileName;
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
                isVaild = false;
            }
            else if (string.IsNullOrEmpty(txtPath.Text))
            {
                isVaild = false;
            }
            else if (isVaild == true)
            {
                if (path == "" || stationNo == "")
                {
                    SettingConfiguration.F_UpdateKey("PathInput", txtPath.Text);
                    SettingConfiguration.F_UpdateKey("StationNo", txtStationNO.Text);
                }

                if (m_bIsWatching)
                {
                    m_bIsWatching = false;
                    m_Watcher.EnableRaisingEvents = false;
                    m_Watcher.Dispose();

                    btnStartWatch.BackColor = Color.Green;
                    btnStartWatch.Text = "Start Watching";
                }
                else
                {
                    m_bIsWatching = true;
                    btnStartWatch.BackColor = Color.Red;
                    btnStartWatch.Text = "Stop Watching";

                    m_Watcher = new FileSystemWatcher();
                    string pathInput = ConfigurationManager.AppSettings["PathInput"];
                    m_Watcher.Filter = pathInput.Substring(pathInput.LastIndexOf('\\') + 1);
                    m_Watcher.Path = pathInput.Substring(0, pathInput.Length - m_Watcher.Filter.Length);

                    m_Watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                                     | NotifyFilters.FileName | NotifyFilters.DirectoryName | NotifyFilters.LastAccess;
                    m_Watcher.Changed += new FileSystemEventHandler(OnChanged);
                    m_Watcher.Created += new FileSystemEventHandler(OnChanged);
                    m_Watcher.EnableRaisingEvents = true;
                }
            }
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            if (!m_bDirty)
            {
                if (e.ChangeType == WatcherChangeTypes.Changed)
                {
                    //lblStatusMessage.Visible = false;
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

        private OleDbConnection GetConnection()
        {
            return null;
        }
        int pass = 0, total = 0, ng = 0;
        private void tmrEditNotify_Tick(object sender, EventArgs e)
        {
            if (m_bDirty)
            {
                string strDSN = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = {path}";
                string strSQL = $"SELECT TOP 1 *  FROM PTS_HEADER  WHERE EndDateTime >= #1/7/2017# ORDER BY EndDateTime DESC";
                //string strSQL = $"SELECT TOP 1 *  FROM PTS_HEADER  WHERE EndDateTime >= #{DateTime.Now.Date}# ORDER BY EndDateTime DESC";
                // create Objects of ADOConnection and ADOCommand  
                OleDbConnection myConn = new OleDbConnection(strDSN);
                OleDbDataAdapter myCmd = new OleDbDataAdapter(strSQL, myConn);
                myConn.Open();
                DataSet dtSet = new DataSet();
                myCmd.Fill(dtSet, "PTS_HEADER");
                DataTable dTable = dtSet.Tables[0];
                List<Item> items = new List<Item>();
                if (dTable.Rows.Count > 0)
                {
                    var item = new Item()
                    {
                            BoardNo = dTable.Rows[0]["Serial"].ToString(),
                            Result = int.Parse(dTable.Rows[0]["Result"].ToString()),
                            EndDateTime = DateTime.Parse(dTable.Rows[0]["EndDateTime"].ToString())
                    };

                    items.Add(item);
                    if (items.Any())
                    {
                        dataGridView1.AutoGenerateColumns = false;
                        dataGridView1.DataSource = items;

                        if (item.State == "PASS")
                        {
                            pass = pass + 1;
                            lblPASS.Text = pass.ToString();
                        }
                        else if (item.State == "FAIL")
                        {
                            ng = ng + 1;
                            lblNG.Text = ng.ToString();
                        }
                        total = pass + ng;
                        lblTotal.Text = total.ToString();
                    }
                    Ultils.CreateFileLog(item.Model, item.BoardNo, item.Status, stationNo, DateTime.Now.ToString("yyMMddHHmmss"));
                }
                else
                {
                    lblStatusMessage.Visible = true;
                    lblStatusMessage.Text = "Check local time";
                }
                myConn.Close();
                m_bDirty = false;
            }
        }
    }
}
