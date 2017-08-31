using Lib.Core;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;

namespace FCT_HFT1024_V2
{
    public partial class FormConfig : Form
    {
        string rootKey = "FCT Settings";
        public FormConfig()
        {
            InitializeComponent();
            GetTaskWindows();
            GetPortNames();
            BinDataToControls();
        }

        private void GetPortNames()
        {
            List<string> listCom = new List<string>();
            foreach (string s in SerialPort.GetPortNames())
            {
                listCom.Add(s);
            }

            cboComRead.DataSource = listCom;
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
            if (Ultils.GetValueRegistryKey(rootKey, "ComRead") != null)
            {
                cboComRead.Text = Ultils.GetValueRegistryKey(rootKey, "ComRead").ToString();
            }
            if (Ultils.GetValueRegistryKey(rootKey, "BarcodeLength") != null)
            {
                txtBarcodeLength.Value = int.Parse(Ultils.GetValueRegistryKey(rootKey, "BarcodeLength"));
            }
            if (Ultils.GetValueRegistryKey(rootKey, "Process") != null)
            {
                cboWindows.Text = Ultils.GetValueRegistryKey(rootKey, "Process").ToString();
            }
            if (Ultils.GetValueRegistryKey(rootKey, "StatioNO") != null)
            {
                txtStationNO.Text = Ultils.GetValueRegistryKey(rootKey, "StatioNO").ToString();
            }
            if (Ultils.GetValueRegistryKey(rootKey, "FileExtension") != null)
            {
                txtFileExtension.Text = Ultils.GetValueRegistryKey(rootKey, "FileExtension").ToString();
            }
            if (Ultils.GetValueRegistryKey(rootKey, "InputLog") != null)
            {
                txtInputLog.Text = Ultils.GetValueRegistryKey(rootKey, "InputLog").ToString();
            }
            if (Ultils.GetValueRegistryKey(rootKey, "OutputLog") != null)
            {
                txtOutputLog.Text = Ultils.GetValueRegistryKey(rootKey, "OutputLog").ToString();
            }
            if (Ultils.GetValueRegistryKey(rootKey, "SkipWaitLogs") != null)
            {
                checkBox1.Checked = bool.Parse(Ultils.GetValueRegistryKey(rootKey, "SkipWaitLogs"));
            }
            if (Ultils.GetValueRegistryKey(rootKey, "AllowsWrite") != null)
            {
                ckhAllowsWriteCom.Checked = bool.Parse(Ultils.GetValueRegistryKey(rootKey, "AllowsWrite"));
            }
        }
        private void btnSaveChanged_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cboComRead.Text))
            {
                MessageBox.Show("Vui lòng chọn cổng COM!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboComRead.Focus();
                return;
            }
            if (string.IsNullOrEmpty(cboWindows.Text))
            {
                MessageBox.Show("Vui lòng chọn Process!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboWindows.Focus();
                return;
            }
            if (txtBarcodeLength.Value < 0 || txtBarcodeLength.Value > 100)
            {
                MessageBox.Show("Vui lòng nhập lại barcode lengh!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBarcodeLength.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtStationNO.Text))
            {
                MessageBox.Show("Vui lòng nhập vào tên trạm!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtStationNO.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtFileExtension.Text))
            {
                MessageBox.Show("Vui lòng nhập vào định dạng file!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFileExtension.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtInputLog.Text))
            {
                MessageBox.Show("Vui lòng chọn chọn đường dẫn file LOG!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblInputLog.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtOutputLog.Text))
            {
                MessageBox.Show("Vui lòng chọn chọn đường dẫn file LOG!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblOutputLog.Focus();
                return;
            }
            else
            {
                //if(cboWindows.Text.Length > 7)
                //{
                //    Ultils.WriteRegistry(rootKey, "Process", cboWindows.Text.Substring(0, 7));
                //}
                //else
                //{
                //    Ultils.WriteRegistry(rootKey, "Process", cboWindows.Text);
                //}
                Ultils.WriteRegistry(rootKey, "ComRead", cboComRead.SelectedValue.ToString());
                Ultils.WriteRegistry(rootKey, "BarcodeLength", txtBarcodeLength.Value.ToString());
                Ultils.WriteRegistry(rootKey, "Process", cboWindows.Text);
                Ultils.WriteRegistry(rootKey, "StationNO", txtStationNO.Text);
                Ultils.WriteRegistry(rootKey, "FileExtension", txtFileExtension.Text);
                Ultils.WriteRegistry(rootKey, "InputLog", txtInputLog.Text);
                Ultils.WriteRegistry(rootKey, "OutputLog", txtOutputLog.Text);
                Ultils.WriteRegistry(rootKey, "SkipWaitLogs", checkBox1.Checked.ToString());
                Ultils.WriteRegistry(rootKey, "AllowsWrite", ckhAllowsWriteCom.Checked.ToString());

                MessageBox.Show("Save success!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
         }

        private void lblInputLog_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog inputLog = new FolderBrowserDialog();
            DialogResult open = inputLog.ShowDialog();
            if (open == DialogResult.OK)
            {
                txtInputLog.Text = inputLog.SelectedPath;
                if (string.IsNullOrEmpty(txtStationNO.Text))
                {
                    btnSaveChanged.Focus();
                }
                else
                {
                    lblInputLog.Focus();
                }
            }
        }

        private void lblOutputLog_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog outputLog = new FolderBrowserDialog();
            DialogResult open = outputLog.ShowDialog();
            if (open == DialogResult.OK)
            {
                txtOutputLog.Text = outputLog.SelectedPath;
                if (string.IsNullOrEmpty(txtStationNO.Text))
                {
                    btnSaveChanged.Focus();
                }
                else
                {
                    lblOutputLog.Focus();
                }
            }
        }

        private void btnProcess_Click(object sender, EventArgs e)
        {
            GetTaskWindows();
        }

        private void btnComRead_Click(object sender, EventArgs e)
        {
            GetPortNames();
        }
    }
}
