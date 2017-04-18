﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Sockets;
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
        //delegate void SetTextCallback(string text);
        //delegate void SetTextCallback(Form f, Control ctrl, string text);
        string stationNo = "", fileExtension = "", inputLog = "", outputLog = "";
        string fileLastWriteTime = "", dateCheck = "", boardNo = "", productId = "", boardState = "";

        bool startWatching = false, RunTaks = false;
        int pass = 0, ng = 0, total = 0;
        FileSystemWatcher fileWatcher;

        public FormMain()
        {
            InitializeComponent();
            BinDataToControls();
            LoadModels();
            Ultils.RegisterInStartup(true, Application.ExecutablePath);
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
        //public static void SetText(Form form, Control ctrl, string text)
        //{
        //    // InvokeRequired required compares the thread ID of the 
        //    // calling thread to the thread ID of the creating thread. 
        //    // If these threads are different, it returns true. 
        //    if (ctrl.InvokeRequired)
        //    {
        //        SetTextCallback d = new SetTextCallback(SetText);
        //        form.Invoke(d, new object[] { form, ctrl, text });
        //    }
        //    else
        //    {
        //        ctrl.Text = text;
        //    }
        //}

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
                System.Diagnostics.Debugger.Log(0, "1", "\n OnClientConnection: Socket has been closed\n");
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
                System.Text.Decoder d = System.Text.Encoding.UTF8.GetDecoder();
                int charLen = d.GetChars(socketData.dataBuffer,
                                         0, iRx, chars, 0);
                System.String szData = new System.String(chars);
                //lblBarcode.Text = szData;

                // Continue the waiting for data on the Socket
                WaitForData(socketData.m_currentSocket);
            }
            catch (ObjectDisposedException)
            {
                System.Diagnostics.Debugger.Log(0, "1", "\nOnDataReceived: Socket has been closed\n");
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
            if(value != "")
                return value;
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
            if (RunTaks)
            {
                if(ModelName(fileLastWriteTime) == productId)
                {
                    boardState = GetState(fileLastWriteTime);
                    List<Item> items = new List<Item>();
                    if (boardState == "P")
                    {
                        ActiveWindows(this.Text);
                        pass = pass + 1;
                        total = pass + ng;

                        Ultils.CreateFileLog(productId, boardNo, boardState, stationNo, dateCheck);

                        lblPASS.Text = pass.ToString();
                        lblNG.Text = ng.ToString();
                        lblTOTAL.Text = total.ToString();

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

                        txtBarcode.ResetText();
                        txtBarcode.Focus();
                    }
                }
                else
                {
                    ActiveWindows(this.Text);
                    ErrorMessage("NG", $"Sai Model. Vui lòng chọn lại Model cho chính xác!" +
                        $"\nModel: {ModelName(fileLastWriteTime)}" +
                        $"\nBoard No: {boardNo}");

                    txtBarcode.ResetText();
                    txtBarcode.Focus();
                }
                
                RunTaks = false;
            }
        }

        private void cboModels_SelectedIndexChanged(object sender, EventArgs e)
        {
            productId = cboModels.Text;
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
                    int port = System.Convert.ToInt32(portStr);
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
        }

        private void txtBarcode_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    boardNo = txtBarcode.Text.Trim();
                    productId = cboModels.Text;
                    dateCheck = DateTime.Now.ToString("yyMMddHHmmss");

                    ActiveWindows(lblProcessName.Text);

                    Object objData = txtBarcode.Text;
                    byte[] byData = System.Text.Encoding.ASCII.GetBytes(objData.ToString());
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
                catch (SocketException se)
                {
                    MessageBox.Show(se.Message);
                }
            }
        }

        /// <summary>
        /// Active Windows Title
        /// </summary>
        /// <param name="title"></param>
        private void ActiveWindows(string title)
        {
            int iHandle2 = NativeWin32.FindWindow(null, title);
            NativeWin32.SetForegroundWindow(iHandle2);
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