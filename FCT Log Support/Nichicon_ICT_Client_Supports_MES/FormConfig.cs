using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Nichicon_ICT_Client_Supports_MES
{
    public partial class FormConfig : Form
    {
        public FormConfig()
        {
            InitializeComponent();
            GetTaskWindows();
            txtIPAddress.Text = Ultils.GetIP();
        }

        /// <summary>
        /// 
        /// </summary>
        private void GetTaskWindows()
        {
            // Get the desktopwindow handle
            int nDeshWndHandle = NativeWin32.GetDesktopWindow();
            // Get the first child window
            int nChildHandle = NativeWin32.GetWindow(nDeshWndHandle, NativeWin32.GW_CHILD);
            while (nChildHandle != 0)
            {
                //If the child window is this (SendKeys) application then ignore it.
                if (nChildHandle == this.Handle.ToInt32())
                {
                    nChildHandle = NativeWin32.GetWindow(nChildHandle, NativeWin32.GW_HWNDNEXT);
                }

                // Get only visible windows
                if (NativeWin32.IsWindowVisible(nChildHandle) != 0)
                {
                    StringBuilder sbTitle = new StringBuilder(1024);
                    // Read the Title bar text on the windows to put in combobox
                    NativeWin32.GetWindowText(nChildHandle, sbTitle, sbTitle.Capacity);
                    string sWinTitle = sbTitle.ToString();
                    {
                        if (sWinTitle.Length > 0)
                        {
                            cboWindows.Items.Add(sWinTitle);
                        }
                    }
                }
                // Look for the next child.
                nChildHandle = NativeWin32.GetWindow(nChildHandle, NativeWin32.GW_HWNDNEXT);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        private void BinDataToControls()
        {
            if (Ultils.GetValueRegistryKey("IPAddress") != null)
            {
                txtIPAddress.Text = Ultils.GetValueRegistryKey("IPAddress").ToString();
            }

            if (Ultils.GetValueRegistryKey("Port") != null)
            {
                txtPort.Text = Ultils.GetValueRegistryKey("Port").ToString();
            }
            if (Ultils.GetValueRegistryKey("Process") != null)
            {
                cboWindows.Text = Ultils.GetValueRegistryKey("Process").ToString();
            }
        }

        private void FormConfig_Load(object sender, EventArgs e)
        {
            BinDataToControls();
        }

        private void btnSaveChanged_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIPAddress.Text))
            {
                MessageBox.Show("Vui lòng nhập vào Server IP Address!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtIPAddress.Focus();
            }
            else if (string.IsNullOrEmpty(txtPort.Text))
            {
                MessageBox.Show("Vui lòng nhập vào Server port!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPort.Focus();
            }
            else if (string.IsNullOrEmpty(cboWindows.Text))
            {
                MessageBox.Show("Vui lòng chọn Process!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboWindows.Focus();
            }
            else
            {
                Ultils.WriteRegistry("IPAddress", txtIPAddress.Text);
                Ultils.WriteRegistry("Port", txtPort.Text);
                Ultils.WriteRegistry("Process", cboWindows.Text);

                MessageBox.Show("Save success!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
         }
    }
}
