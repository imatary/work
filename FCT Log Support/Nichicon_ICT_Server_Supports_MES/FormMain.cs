using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Nichicon_ICT_Server_Supports_MES
{
    public partial class FormMain : Form
    {
        const int MAX_CLIENTS = 10;
        public AsyncCallback pfnWorkerCallBack;
        private Socket m_mainSocket;
        private Socket[] m_workerSocket = new Socket[10];
        private int m_clientCount = 0;
        string stationNo = "", fileExtension = "", inputLog = "", outputLog = "", serial = "";
        string fileLastWriteTime = "", dateCheck = "", boardNo = "", productId = "", boardState = "";
        string strIP = "", strPort = "", processName = "";
        string[] messageOK = null, messageNG = null;
        bool startWatching = false, RunTaks = false, checkLength = false, skipWaitLogs = false;
        int pass = 0, ng = 0, total = 0, barcodeLength = 10;
        FileSystemWatcher fileWatcher;

        public FormMain()
        {
            InitializeComponent();
            BinDataToControls();
            LoadModels();
            Ultils.RegisterInStartup(true, Application.ExecutablePath);
            lblVersion.Text = Ultils.GetRunningVersion();
            lblReset.Enabled = false;
        }

        private void UpdateControls(bool listening)
        {
            btnStart.Enabled = !listening;
            btnStop.Enabled = listening;
        }
        public void OnClientConnect(IAsyncResult asyn)
        {
            try
            {
                m_workerSocket[m_clientCount] = m_mainSocket.EndAccept(asyn);
                WaitForData(m_workerSocket[m_clientCount]);
                ++m_clientCount;
                String client = String.Format("Client # {0} connected", m_clientCount);
                lblClientConnected.Text = client;
                m_mainSocket.BeginAccept(new AsyncCallback(OnClientConnect), null);
            }
            catch (ObjectDisposedException)
            {
                Debugger.Log(0, "1", "\n OnClientConnection: Socket has been closed\n");
            }
            catch (SocketException se)
            {
                ErrorMessage("NG", se.Message);
            }
        }
        public class SocketPacket
        {
            public Socket m_currentSocket;
            public byte[] dataBuffer = new byte[1];
        }
        // Start waiting for data from the client
        /// <summary>
        /// 
        /// </summary>
        /// <param name="soc"></param>
        public void WaitForData(Socket soc)
        {
            try
            {
                if (pfnWorkerCallBack == null)
                {
                    pfnWorkerCallBack = new AsyncCallback(OnDataReceived);
                }
                SocketPacket theSocPkt = new SocketPacket();
                theSocPkt.m_currentSocket = soc;
                soc.BeginReceive(theSocPkt.dataBuffer, 0,
                                   theSocPkt.dataBuffer.Length,
                                   SocketFlags.None,
                                   pfnWorkerCallBack,
                                   theSocPkt);
            }
            catch (SocketException se)
            {
                ErrorMessage("NG", se.Message);
            }

        }
        // This the call back function which will be invoked when the socket
        // detects any client writing of data on the stream
        /// <summary>
        /// 
        /// </summary>
        /// <param name="asyn"></param>
        public void OnDataReceived(IAsyncResult asyn)
        {
            try
            {
                SocketPacket socketData = (SocketPacket)asyn.AsyncState;

                int iRx = 0;
                iRx = socketData.m_currentSocket.EndReceive(asyn);
                char[] chars = new char[iRx + 1];
                Decoder d = Encoding.UTF8.GetDecoder();
                int charLen = d.GetChars(socketData.dataBuffer, 0, iRx, chars, 0);
                System.String szData = new System.String(chars);
                serial = serial + szData;

                if (serial != null)
                {
                    checkLength = true;
                }
                WaitForData(socketData.m_currentSocket);
            }
            catch (ObjectDisposedException)
            {
                Debugger.Log(0, "1", "\nOnDataReceived: Socket has been closed\n");
            }
            catch (SocketException se)
            {
                ErrorMessage("NG", se.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        void CloseSockets()
        {
            if (m_mainSocket != null)
            {
                m_mainSocket.Close();
            }
            for (int i = 0; i < m_clientCount; i++)
            {
                if (m_workerSocket[i] != null)
                {
                    m_workerSocket[i].Close();
                    m_workerSocket[i] = null;
                }
            }
            m_clientCount = 0;
        }

        /// <summary>
        /// 
        /// </summary>
        private void BinDataToControls()
        {
            if (Ultils.GetValueRegistryKey("IPAddress") != null)
            {
                strIP= Ultils.GetValueRegistryKey("IPAddress").ToString();
            }

            if (Ultils.GetValueRegistryKey("Port") != null)
            {
                strPort = Ultils.GetValueRegistryKey("Port").ToString();
            }
            if (Ultils.GetValueRegistryKey("Process") != null)
            {
                processName = Ultils.GetValueRegistryKey("Process").ToString();
            }
            if (Ultils.GetValueRegistryKey("StationNO") != null)
            {
                stationNo = Ultils.GetValueRegistryKey("StationNO").ToString();
            }
            if (Ultils.GetValueRegistryKey("FileExtension") != null)
            {
                fileExtension = Ultils.GetValueRegistryKey("FileExtension").ToString();
            }
            if (Ultils.GetValueRegistryKey("InputLog") != null)
            {
                inputLog = Ultils.GetValueRegistryKey("InputLog").ToString();
            }
            if (Ultils.GetValueRegistryKey("OutputLog") != null)
            {
                outputLog = Ultils.GetValueRegistryKey("OutputLog").ToString();
            }
            if (Ultils.GetValueRegistryKey("SkipWaitLogs") != null)
            {
                skipWaitLogs = bool.Parse(Ultils.GetValueRegistryKey("SkipWaitLogs"));
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private string GetStateBoardOne(string path)
        {
            string state = "";
            string content = null;
            string value = "";
            if (fileExtension == "*.LOG")
            {
                content = Ultils.GetLine(path, 2);
                string[] array = content.Split(',');
                value = array[1];
                value = Regex.Replace(value, "[^A-Za-z0-9]", "");

                if (value == "GO")
                {
                    state = "P";
                }
                if (value == "NG")
                {
                    state = "F";
                }
            }
            if (fileExtension == "*.DAT")
            {
                content = Ultils.GetLine(path, 1);
                string[] array = content.Split(',');
                value = array[9];
                if (value == "CP=OK")
                {
                    state = "P";
                }
                if (value == "CP=NG")
                {
                    state = "F";
                }
            }
            return state;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private string GetStateBoardTwo(string path)
        {
            string state = "";
            string content = null;
            string value = "";
            if (fileExtension == "*.LOG")
            {
                content = Ultils.GetLine(path, 2);
                string[] array = content.Split(',');
                value = array[1];
                value = Regex.Replace(value, "[^A-Za-z0-9]", "");

                if (value == "GO")
                {
                    state = "P";
                }
                if (value == "NG")
                {
                    state = "F";
                }
            }
            if (fileExtension == "*.DAT")
            {
                content = Ultils.GetLine(path, 199);
                string[] array = content.Split(',');
                value = array[9];
                if (value == "CP=OK")
                {
                    state = "P";
                }
                if (value == "CP=NG")
                {
                    state = "F";
                }
            }
            return state;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private string ModelName(string path)
        {
            string value = "";
            string content = null;
            if(fileExtension == "*.LOG")
            {
                content = Ultils.GetLine(path, 2);
                string[] array = content.Split(',');
                value = array[0];
                value = Regex.Replace(value, "[^A-Za-z0-9]", "");
            }
            if(fileExtension == "*.DAT")
            {
                content = Ultils.GetLine(path, 1);
                string[] array = content.Split(',');
                value = array[1];
                value = Regex.Replace(value, "[^A-Za-z0-9]", "");
            }
            
            if (value != "")
            {
                if (value.Contains("-"))
                {
                    value = value.Replace("-", "").Replace(" ", "");
                }
                return value;
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnFileChanged(object sender, FileSystemEventArgs e)
        {
            if (!RunTaks)
            {
                if (e.ChangeType == WatcherChangeTypes.Created || e.ChangeType == WatcherChangeTypes.Changed)
                {
                    fileLastWriteTime = e.FullPath;
                    RunTaks = true;
                }
            }
        }

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBarcode.Text))
            {
                DefaultMessage();
            }
        }

        private void cboCheckSheet_CheckedChanged(object sender, EventArgs e)
        {
            //if(panelBarcode2.Visible == true)
            //{
            //    if (cboCheckTwoPcs.Checked == true)
            //    {
            //        panelBarcode2.Visible = true;
            //    }
            //    else
            //    {
            //        panelBarcode2.Visible = false;

            //    }
            //    txtBarcode.ResetText();
            //    txtBarcode.Focus();
            //}
        }

        private void lblConfigs_Click(object sender, EventArgs e)
        {
            new FormConfig().ShowDialog();
            BinDataToControls();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string data = string.Empty;
            int indexOfYourColumn = 4;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                data = row.Cells[indexOfYourColumn].Value.ToString();
                if (data == "F")
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                    row.DefaultCellStyle.ForeColor = Color.White;
                    row.Selected = true;
                }
                if(data== "P")
                {
                    row.DefaultCellStyle.BackColor = Color.Green;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            byte[] byData = Encoding.ASCII.GetBytes("StopWork");
            for (int i = 0; i < m_clientCount; i++)
            {
                if (m_workerSocket[i] != null)
                {
                    if (m_workerSocket[i].Connected)
                    {
                        m_workerSocket[i].Send(byData);
                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (checkLength == true)
            {
                ActiveWindows(this.Text);
                txtBarcode.Enabled = true;
                txtBarcode.ResetText();
                txtBarcode.Focus();
                serial = "";
                checkLength = false;
            }
            else
            {
                if (RunTaks)
                {
                    if (ModelName(fileLastWriteTime).Substring(0, productId.Length) == productId)
                    {
                        boardState = GetStateBoardOne(fileLastWriteTime);
                        List<Item> items = new List<Item>();

                        Item item = new Item()
                        {
                            BoardNo = boardNo,
                            ProductId = productId,
                            Date = DateTime.Now.ToShortDateString(),
                            Time = DateTime.Now.ToShortTimeString(),
                            State = boardState,
                        };
                        items.Add(item);

                        if (cboCheckTwoPcs.Checked == true)
                        {
                            string boardState2 = GetStateBoardTwo(fileLastWriteTime);
                            Item item2 = new Item()
                            {
                                BoardNo = txtBarcode2.Text,
                                ProductId = productId,
                                Date = DateTime.Now.ToShortDateString(),
                                Time = DateTime.Now.ToShortTimeString(),
                                State = boardState2,
                            };

                            items.Add(item2);
                        }

                        dataGridView1.DataSource = items;

                        string strOK = "", strNG = "";

                        foreach (var itemW in items)
                        {
                            Ultils.CreateFileLog(itemW.ProductId, itemW.BoardNo, itemW.State, stationNo, dateCheck);
                            if (itemW.State == "P")
                            {
                                pass = pass + 1;
                                strOK += $"Board [{itemW.BoardNo}] OK! \n";

                                txtBarcode.Enabled = true;
                                txtBarcode.ResetText();

                                if (cboCheckTwoPcs.Checked == true)
                                {
                                    txtBarcode2.ResetText();
                                    txtBarcode2.Enabled = true;
                                }
                                txtBarcode.Focus();
                            }
                            if (itemW.State == "F")
                            {
                                ng = ng + 1;
                                strNG += $"Board [{itemW.BoardNo}] NG! \n";
                            }
                        }

                        if (strOK != "")
                            SuccessMessage("OK", strOK);

                        if (strNG != "")
                            ErrorMessage("NG", strNG);

                        

                        lblReset.Enabled = true;
                        total = pass + ng;
                        lblPASS.Text = pass.ToString();
                        lblNG.Text = ng.ToString();
                        lblTOTAL.Text = total.ToString(); 
                    }
                    else
                    {
                        ErrorMessage("NG", $"Sai Model. Vui lòng chọn lại Model cho chính xác!" +
                            $"\nModel: {ModelName(fileLastWriteTime)}" +
                            $"\nBoard No: {boardNo}");

                        txtBarcode.Enabled = true;
                        txtBarcode.ResetText();
                        txtBarcode.Focus();
                        checkLength = false;
                        serial = "";
                    }

                    // TopMode this form
                    ActiveWindows(Text);
                    RunTaks = false;
                }
            }
        }

        private void cboModels_SelectedIndexChanged(object sender, EventArgs e)
        {
            productId = cboModels.Text;

            if(productId == "ZSBAF19IA")
            {
                if (cboCheckTwoPcs.Enabled == true)
                {
                    cboCheckTwoPcs.Enabled = false;
                }
                else
                {
                    cboCheckTwoPcs.Checked = true;
                    cboCheckTwoPcs.Enabled = true;
                }
            } 
        }

        private void lblReset_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            boardNo = "";
            if (cboCheckTwoPcs.Checked == false)
            {
                txtBarcode.Enabled = true;
                txtBarcode.ResetText();
                
            }
            else
            {
                txtBarcode.ResetText();
                txtBarcode2.ResetText();
                txtBarcode.Enabled = true;
                txtBarcode2.Enabled = true;
            }
            txtBarcode.Focus();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(strIP) || strIP == "")
            {
                MessageBox.Show("Vui lòng nhập vào Server IP Address!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (string.IsNullOrEmpty(strPort) || strPort == "")
            {
                MessageBox.Show("Vui lòng nhập vào Server port!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (string.IsNullOrEmpty(processName) || processName == "")
            {
                MessageBox.Show("Vui lòng chọn Process!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (string.IsNullOrEmpty(cboModels.Text))
            {
                MessageBox.Show("Vui lòng chọn một Model!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboModels.Focus();
            }
            else
            {
                try
                {
                    int port = Convert.ToInt32(strPort);
                    // Create the listening socket...
                    m_mainSocket = new Socket(AddressFamily.InterNetwork,
                                              SocketType.Stream,
                                              ProtocolType.Tcp);
                    IPEndPoint ipLocal = new IPEndPoint(IPAddress.Any, port);
                    // Bind to local IP Address...
                    m_mainSocket.Bind(ipLocal);
                    // Start listening...
                    m_mainSocket.Listen(4);
                    // Create the call back for any client connections...
                    m_mainSocket.BeginAccept(new AsyncCallback(OnClientConnect), null);

                    UpdateControls(true);
                    txtBarcode.Focus();
                    cboModels.Enabled = false;
                    lblReload.Enabled = false;
                    lblAddModel.Enabled = false;
                    lblConfigs.Enabled = false;
                    lblRefesh.Enabled = false;

                    lblReset.Enabled = true;

                    if(cboCheckTwoPcs.Checked == true)
                    {
                        panelBarcode.Visible = true;
                        panelBarcode2.Visible = true;
                        txtBarcode.Focus();
                    }
                    else
                    {
                        panelBarcode.Visible = true;
                    }
                    if (startWatching == false)
                    {
                        startWatching = true;
                        // Config file watching
                        fileWatcher = new FileSystemWatcher();
                        fileWatcher.IncludeSubdirectories = true;
                        if (fileExtension.Contains("*"))
                        {
                            fileWatcher.Filter = fileExtension;
                        }
                        else
                        {
                            fileWatcher.Filter = "*" + fileExtension;
                        }

                        fileWatcher.Path = inputLog + "\\";

                        fileWatcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.CreationTime
                                             | NotifyFilters.FileName | NotifyFilters.DirectoryName;
                        fileWatcher.Created += new FileSystemEventHandler(OnFileChanged);
                        fileWatcher.Changed += new FileSystemEventHandler(OnFileChanged);
                        fileWatcher.EnableRaisingEvents = true;
                    }

                }
                catch (SocketException se)
                {
                    MessageBox.Show(se.Message);
                }
            }
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            // Gửi sang client trạng thái Stop
            byte[] byData = Encoding.ASCII.GetBytes("StopWork");
            for (int i = 0; i < m_clientCount; i++)
            {
                if (m_workerSocket[i] != null)
                {
                    if (m_workerSocket[i].Connected)
                    {
                        m_workerSocket[i].Send(byData);
                    }
                }
            }

            if (startWatching == true)
            {
                startWatching = false;
                fileWatcher.EnableRaisingEvents = false;
                fileWatcher.Dispose();
            }

            if (cboCheckTwoPcs.Checked == true)
            {
                cboCheckTwoPcs.Checked = false;
                cboCheckTwoPcs.Enabled = false;
            }

            DefaultMessage();
            CloseSockets();
            UpdateControls(false);
            panelBarcode.Visible = false;
            panelBarcode2.Visible = false;

            lblConfigs.Enabled = true;
            cboModels.Enabled = true;
            lblReload.Enabled = true;
            lblAddModel.Enabled = true;
            lblRefesh.Enabled = true;
            lblReset.Enabled = false;
            

            cboModels.SelectedIndex = -1;

            lblClientConnected.Text = "| no client connect";

            txtBarcode2.Enabled = true;
            txtBarcode2.ResetText();

            txtBarcode.Enabled = true;
            txtBarcode.ResetText();
        }

        private void txtBarcode_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // nếu = false thì làm việc như bình thường, test log
                if (skipWaitLogs == false)
                {
                    try
                    {
                        boardNo = txtBarcode.Text.Trim();
                        if (boardNo != null && boardNo.Length >= 10)
                        {
                            productId = cboModels.Text;
                            dateCheck = DateTime.Now.ToString("yyMMddHHmmss");
                            txtBarcode.Enabled = false;
                            lblReset.Enabled = true;
                            //dataGridView1.DataSource = null;
                            byte[] byData = Encoding.ASCII.GetBytes(boardNo);
                            for (int i = 0; i < m_clientCount; i++)
                            {
                                if (m_workerSocket[i] != null)
                                {
                                    if (m_workerSocket[i].Connected)
                                    {
                                        m_workerSocket[i].Send(byData);
                                    }
                                }
                            }

                            if (cboCheckTwoPcs.Checked == false)
                            {
                                ActiveProcess(processName);
                            }
                            else
                            {
                                txtBarcode.Enabled = false;

                                txtBarcode2.ResetText();
                                txtBarcode2.Focus();
                            }
                            
                        }
                        else
                        {
                            ErrorMessage("NG", "Vui lòng bắn vào barcode");
                            txtBarcode.Focus();
                        }

                    }
                    catch (SocketException se)
                    {
                        MessageBox.Show(se.Message);
                    }
                }
                // nếu = true, thì tạo log luôn không cần chờ Log máy nữa
                else
                {
                    if (txtBarcode.Text != null)
                    {
                        Ultils.CreateFileLog(cboModels.Text, txtBarcode.Text, "P", stationNo, DateTime.Now.ToString("yyMMddHHmmss"));
                        txtBarcode.ResetText();
                        txtBarcode.Focus();
                    }
                }
            }
        }

        private void txtBarcode2_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cboCheckTwoPcs.Checked == true)
                {
                    string barcode2 = txtBarcode2.Text.Trim();
                    if(barcode2 != "" && barcode2.Length >= barcodeLength)
                    {
                        byte[] byData = Encoding.ASCII.GetBytes(barcode2);
                        for (int i = 0; i < m_clientCount; i++)
                        {
                            if (m_workerSocket[i] != null)
                            {
                                if (m_workerSocket[i].Connected)
                                {
                                    m_workerSocket[i].Send(byData);
                                }
                            }
                        }
                        txtBarcode2.Enabled = false;
                        ActiveProcess(processName);
                    }
                    else
                    {
                        ErrorMessage("NG", "Vui lòng bắn vào barcode");
                        txtBarcode2.Focus();
                    }
                }
            }
            
        }

        /// <summary>
        /// Active Windows Title
        /// </summary>
        /// <param name="title"></param>
        private void ActiveProcess(string title)
        {
            Process[] processes = Process.GetProcesses();
            int windowHandle = 0;
            foreach (Process p in processes)
            {
                if (p.MainWindowTitle.Contains(title))
                {
                    windowHandle = (int)p.MainWindowHandle;
                    break;
                }
                
            }
            NativeWin32.SetForegroundWindow(windowHandle);
        }
        private void ActiveWindows(string title)
        {
            int windowHandle = NativeWin32.FindWindow(null, title);
            NativeWin32.SetForegroundWindow(windowHandle);
        }
        private void lblRefesh_Click(object sender, EventArgs e)
        {
            new FormConfig().ShowDialog();
            BinDataToControls();
        }
        /// <summary>
        /// 
        /// </summary>
        private void LoadModels()
        {
            List<string> data = new List<string>();
            if (Ultils.GetValueRegistryKey("Models") != null)
            {
                string[] models = Ultils.GetValueRegistryKey("Models").Split(';');

                foreach (var item in models)
                {
                    data.Add(item);
                }
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
                "ZSFLD22IA",
                "ZSFLE08IA",
                "ZSFLE09IA",
                "ZSBAF19IA"
                };

                foreach (var item in models)
                {
                    data.Add(item);
                    Ultils.WriteRegistryArray("Models", item);
                }
            }

            cboModels.DataSource = data;
        }
        private void lblReload_Click(object sender, EventArgs e)
        {
            LoadModels();
        }

        private void lblAddModel_Click(object sender, EventArgs e)
        {
            new FormAddModel().ShowDialog();
            LoadModels();
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

            fileLastWriteTime = "";
            dateCheck = "";
            boardNo = "";
            productId = "";
            boardState = "";
        }
    }
}
