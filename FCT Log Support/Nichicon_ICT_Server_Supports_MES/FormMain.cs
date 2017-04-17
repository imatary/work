using System;
using System.Net;
using System.Net.Sockets;
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
        delegate void SetTextCallback(string text);

        public FormMain()
        {
            InitializeComponent();
            txtIPAddress.Text = Ultils.GetIP();
        }
        public bool ControlInvokeRequired(Control c, Action a)
        {
            if (c.InvokeRequired) c.Invoke(new MethodInvoker(delegate { a(); }));
            else return false;

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
                System.Diagnostics.Debugger.Log(0, "1", "\n OnClientConnection: Socket has been closed\n");
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message);
            }
        }
        public class SocketPacket
        {
            public System.Net.Sockets.Socket m_currentSocket;
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
                MessageBox.Show(se.Message);
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
                MessageBox.Show(se.Message);
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

        private void FormMain_Load(object sender, EventArgs e)
        {
            txtIPAddress.Text = Ultils.GetIP();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIPAddress.Text))
            {
                txtIPAddress.Focus();
            }
            else if (string.IsNullOrEmpty(txtPort.Text))
            {
                txtPort.Focus();
            }
            else
            {
                try
                {
                    string portStr = txtPort.Text;
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

                }
                catch (SocketException se)
                {
                    MessageBox.Show(se.Message);
                }
            }
        }

        

        private void btnStop_Click(object sender, EventArgs e)
        {
            CloseSockets();
            UpdateControls(false);
        }

        private void txtBarcode_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
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
    }
}
