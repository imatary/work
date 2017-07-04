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

        bool startWatching = false, RunTaks = false, checkLength = false, skipWaitLogs = false;
        int pass = 0, ng = 0, total = 0;
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
        public bool ControlInvokeRequired(Control c, Action a)
        {
            if (c.InvokeRequired)
                c.Invoke(new MethodInvoker(delegate { a(); }));
            else
                return false;

            return true;
        }
        public void UpdateClientConnect(string valuess)
        {
            //Check if invoke requied if so return - as i will be recalled in correct thread
            if (ControlInvokeRequired(txtClientConnect, () => UpdateClientConnect(valuess)))
                return;
            txtClientConnect.Text = valuess;
            //txtBarcode.BackColor = c;
        }
        private void UpdateControls(bool listening)
        {
            btnStart.Enabled = !listening;
            btnStop.Enabled = listening;
        }
        // This is the call back function, which will be invoked when a client is connected
        public void OnClientConnect(IAsyncResult asyn)
        {
            try
            {
                // Here we complete/end the BeginAccept() asynchronous call
                // by calling EndAccept() - which returns the reference to
                // a new Socket object
                m_workerSocket[m_clientCount] = m_mainSocket.EndAccept(asyn);
                // Let the worker Socket do the further processing for the 
                // just connected client
                WaitForData(m_workerSocket[m_clientCount]);
                // Now increment the client count
                ++m_clientCount;
                // Display this client connection as a status message on the GUI	
                String client = String.Format("Client # {0} connected", m_clientCount);
                UpdateClientConnect(client);

                // Since the main Socket is now free, it can go back and wait for
                // other clients who are attempting to connect
                m_mainSocket.BeginAccept(new AsyncCallback(OnClientConnect), null);
            }
            catch (ObjectDisposedException)
            {
                Debugger.Log(0, "1", "\n OnClientConnection: Socket has been closed\n");
            }
            catch (SocketException se)
            {
                //ThreadHelper.SetText(this, textBox1, "This text was set safely.");

                ErrorMessage("NG", se.Message);
            }
        }
        public class SocketPacket
        {
            public Socket m_currentSocket;
            public byte[] dataBuffer = new byte[1];
        }
        // Start waiting for data from the client
        public void WaitForData(Socket soc)
        {
            try
            {
                if (pfnWorkerCallBack == null)
                {
                    // Specify the call back function which is to be 
                    // invoked when there is any write activity by the 
                    // connected client
                    pfnWorkerCallBack = new AsyncCallback(OnDataReceived);
                }
                SocketPacket theSocPkt = new SocketPacket();
                theSocPkt.m_currentSocket = soc;
                // Start receiving any data written by the connected client
                // asynchronously
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
        public void OnDataReceived(IAsyncResult asyn)
        {
            try
            {
                SocketPacket socketData = (SocketPacket)asyn.AsyncState;

                int iRx = 0;
                // Complete the BeginReceive() asynchronous call by EndReceive() method
                // which will return the number of characters written to the stream 
                // by the client
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

                // Continue the waiting for data on the Socket
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
        }

        /// <summary>
        /// 
        /// </summary>
        private void BinDataToControls()
        {
            if (Ultils.GetValueRegistryKey("IPAddress") != null)
            {
                lblIPAddress.Text = Ultils.GetValueRegistryKey("IPAddress").ToString();
            }

            if (Ultils.GetValueRegistryKey("Port") != null)
            {
                lblPort.Text = Ultils.GetValueRegistryKey("Port").ToString();
            }
            if (Ultils.GetValueRegistryKey("Process") != null)
            {
                lblProcessName.Text = Ultils.GetValueRegistryKey("Process").ToString();
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
        private string GetState(string path)
        {
            string state = "";
            string content = Ultils.GetLine(path, 1);
            string[] array = content.Split(',');
            string value = array[9];
            if (value == "CP=OK")
            {
                state = "P";
            }
            else if (value == "CP=NG")
            {
                state = "F";
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
            string content = Ultils.GetLine(path, 1);
            string[] array = content.Split(',');
            value = array[1];
            value = Regex.Replace(value, "[^A-Za-z0-9]", "");
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
                    if(boardNo!=null || boardNo != "")
                    {
                        if (ModelName(fileLastWriteTime) == productId)
                        {
                            boardState = GetState(fileLastWriteTime);
                            List<Item> items = new List<Item>();
                            Ultils.CreateFileLog(productId, boardNo, boardState, stationNo, dateCheck);
                            Item item = new Item()
                            {
                                BoardNo = boardNo,
                                ProductId = productId,
                                Date = DateTime.Now.ToShortDateString(),
                                Time = DateTime.Now.ToShortTimeString(),
                                State = boardState,
                            };

                            items.Add(item);
                            dataGridView1.AutoGenerateColumns = false;
                            dataGridView1.DataSource = items;
                            if (boardState == "P")
                            {
                                ActiveWindows(Text);
                                //this.TopMost = true;
                                pass = pass + 1;

                                SuccessMessage("OK", $"Board [{boardNo}] OK!");

                                txtBarcode.Enabled = true;
                                lblReset.Enabled = true;
                                txtBarcode.ResetText();
                                txtBarcode.Focus();
                            }
                            if (boardState == "F")
                            {
                                ErrorMessage("NG", $"Board [{boardNo}] NG!");
                                lblReset.Enabled = true;
                                ng = ng + 1;
                            }
                            //
                            total = pass + ng;
                            lblPASS.Text = pass.ToString();
                            lblNG.Text = ng.ToString();
                            lblTOTAL.Text = total.ToString();
                        }
                        else
                        {
                            ActiveWindows(Text);
                            //this.TopMost = true;
                            ErrorMessage("NG", $"Sai Model. Vui lòng chọn lại Model cho chính xác!" +
                                $"\nModel: {ModelName(fileLastWriteTime)}" +
                                $"\nBoard No: {boardNo}");

                            txtBarcode.Enabled = true;
                            txtBarcode.ResetText();
                            txtBarcode.Focus();
                            checkLength = false;
                            serial = "";
                        }
                    }
                    else
                    {
                        ActiveWindows(Text);
                        //this.TopMost = true;
                        ErrorMessage("NG", $" Vui lòng bắn vào Serial!");

                        txtBarcode.Enabled = true;
                        txtBarcode.Focus();
                        checkLength = false;
                        serial = "";
                    }
                    RunTaks = false;
                }
            }
        }

        private void cboModels_SelectedIndexChanged(object sender, EventArgs e)
        {
            productId = cboModels.Text;
        }

        private void lblReset_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            boardNo = "";
            txtBarcode.Enabled = true;
            txtBarcode.ResetText();
            txtBarcode.Focus();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblIPAddress.Text) || lblIPAddress.Text == "None")
            {
                MessageBox.Show("Vui lòng nhập vào Server IP Address!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (string.IsNullOrEmpty(lblPort.Text) || lblPort.Text == "None")
            {
                MessageBox.Show("Vui lòng nhập vào Server port!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (string.IsNullOrEmpty(lblProcessName.Text) || lblProcessName.Text == "None")
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
                    string portStr = lblPort.Text;
                    int port = Convert.ToInt32(portStr);
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
                    panelBarcode.Visible = true;
                    txtBarcode.Focus();
                    cboModels.Enabled = false;
                    lblReload.Enabled = false;
                    lblAddModel.Enabled = false;

                    lblRefesh.Enabled = false;
                    lblReset.Enabled = true;

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
            if (startWatching == true)
            {
                startWatching = false;
                fileWatcher.EnableRaisingEvents = false;
                fileWatcher.Dispose();
            }

            DefaultMessage();
            CloseSockets();
            UpdateControls(false);
            panelBarcode.Visible = false;
            cboModels.Enabled = true;
            lblReload.Enabled = true;
            lblAddModel.Enabled = true;
            lblRefesh.Enabled = true;
            lblReset.Enabled = false;
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
                        if (boardNo != null || boardNo != "")
                        {
                            productId = cboModels.Text;
                            dateCheck = DateTime.Now.ToString("yyMMddHHmmss");
                            txtBarcode.Enabled = false;
                            lblReset.Enabled = true;

                            //this.TopMost = false;
                            ActiveProcess(lblProcessName.Text);
                            dataGridView1.DataSource = null;

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
            if (Ultils.GetValueRegistryKey("Models") != null)
            {
                string[] models = Ultils.GetValueRegistryKey("Models").Split(';');

                foreach (var item in models)
                {
                    cboModels.Items.Add(item);
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
                "ZSFLE09IA"
                };

                foreach (var item in models)
                {
                    cboModels.Items.Add(item);
                    Ultils.WriteRegistryArray("Models", item);
                }
            }
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
