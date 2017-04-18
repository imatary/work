﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Nichicon_ICT_Client_Supports_MES
{
    public partial class FormMain : Form
    {
        byte[] m_dataBuffer = new byte[1000];
        IAsyncResult m_result;
        public AsyncCallback m_pfnCallBack;
        public Socket m_clientSocket;
        private bool IsRun = false;
        delegate void SetTextCallback(string text);

        public FormMain()
        {
            InitializeComponent();
            BinDataToControls();
        }

        public bool ControlInvokeRequired(Control c, Action a)
        {
            if (c.InvokeRequired) c.Invoke(new MethodInvoker(delegate { a(); }));
            else return false;

            return true;
        }
        public void UpdateBarcode(string valuess)
        {
            //Check if invoke requied if so return - as i will be recalled in correct thread
            if (ControlInvokeRequired(txtBarcode, () => UpdateBarcode(valuess)))
                return;
            txtBarcode.Text = valuess;
            //txtBarcode.BackColor = c;
        }

        /// <summary>
        /// 
        /// </summary>
        public void WaitForData()
        {
            try
            {
                if (m_pfnCallBack == null)
                {
                    m_pfnCallBack = new AsyncCallback(OnDataReceived);
                }
                SocketPacket theSocPkt = new SocketPacket();
                theSocPkt.thisSocket = m_clientSocket;
                // Start listening to the data asynchronously
                m_result = m_clientSocket.BeginReceive(theSocPkt.dataBuffer,
                                                        0, theSocPkt.dataBuffer.Length,
                                                        SocketFlags.None,
                                                        m_pfnCallBack,
                                                        theSocPkt);
            }
            catch (SocketException se)
            {
                MessageBox.Show(se.Message);
            }

        }
        /// <summary>
        /// 
        /// </summary>
        public class SocketPacket
        {
            public Socket thisSocket;
            public byte[] dataBuffer = new byte[1];
        }

        public void OnDataReceived(IAsyncResult asyn)
        {
            try
            {
                SocketPacket theSockId = (SocketPacket)asyn.AsyncState;
                int iRx = theSockId.thisSocket.EndReceive(asyn);
                char[] chars = new char[iRx + 1];
                System.Text.Decoder d = System.Text.Encoding.UTF8.GetDecoder();
                int charLen = d.GetChars(theSockId.dataBuffer, 0, iRx, chars, 0);
                System.String szData = new System.String(chars);
                UpdateBarcode(txtBarcode.Text + szData);
                ActiveWindows(lblProcessName.Text);
                WaitForData();
                IsRun = true;
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
        private void UpdateControls(bool connected)
        {
            btnConnected.Enabled = !connected;
            btnDisConnected.Enabled = connected;
            string connectStatus = connected ? "Connected" : "Not Connected";
            lblStatus.Text = connectStatus;
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
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblIPAddress.Text) || lblIPAddress.Text == "None")
            {
                MessageBox.Show("Vui lòng nhập vào Server IP Address!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblIPAddress.Focus();
            }
            else if (string.IsNullOrEmpty(lblPort.Text) || lblPort.Text == "None")
            {
                MessageBox.Show("Vui lòng nhập vào Server port!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblPort.Focus();
            }
            else if (string.IsNullOrEmpty(lblProcessName.Text) || lblProcessName.Text == "None")
            {
                MessageBox.Show("Vui lòng chọn Process!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblProcessName.Focus();
            }
            else
            {
                try
                {
                    UpdateControls(false);
                    // Create the socket instance
                    m_clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

                    // Cet the remote IP address
                    IPAddress ip = IPAddress.Parse(lblIPAddress.Text);
                    int iPortNo = System.Convert.ToInt16(lblPort.Text);
                    // Create the end point 
                    IPEndPoint ipEnd = new IPEndPoint(ip, iPortNo);
                    // Connect to the remote host
                    m_clientSocket.Connect(ipEnd);
                    if (m_clientSocket.Connected)
                    {
                        UpdateControls(true);
                        //Wait for data asynchronously 
                        WaitForData();
                    }
                }
                catch (SocketException se)
                {
                    string str;
                    str = "\nConnection failed, is the server running?\n" + se.Message;
                    MessageBox.Show(str);
                    UpdateControls(false);
                }
            }
        }

        private void btnDisConnected_Click(object sender, EventArgs e)
        {
            if (m_clientSocket != null)
            {
                m_clientSocket.Close();
                m_clientSocket = null;
                UpdateControls(false);
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (IsRun)
            {
                SendKeys.Send(txtBarcode.Text);
                Thread.Sleep(150);
                SendKeys.Send("{ENTER}");
                txtBarcode.ResetText();
                IsRun = false;
            }
        }

        private void lblConfigServer_Click(object sender, EventArgs e)
        {
            new FormConfig().ShowDialog();
            BinDataToControls();
        }
    }
}
