using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FCT_Canon_Supports_MES
{
    public partial class FormConfig : Form
    {
        public FormConfig()
        {
            InitializeComponent();
            GetTaskWindows();
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
            if (Ultils.GetValueRegistryKey("Process") != null)
            {
                cboWindows.Text = Ultils.GetValueRegistryKey("Process").ToString();
            }
            if (Ultils.GetValueRegistryKey("StatioNO") != null)
            {
                txtStationNO.Text = Ultils.GetValueRegistryKey("StatioNO").ToString();
            }
            if (Ultils.GetValueRegistryKey("FileExtension") != null)
            {
                txtFileExtension.Text = Ultils.GetValueRegistryKey("FileExtension").ToString();
            }
            if (Ultils.GetValueRegistryKey("InputLog") != null)
            {
                txtInputLog.Text = Ultils.GetValueRegistryKey("InputLog").ToString();
            }
            if (Ultils.GetValueRegistryKey("OutputLog") != null)
            {
                txtOutputLog.Text = Ultils.GetValueRegistryKey("OutputLog").ToString();
            }
            if (Ultils.GetValueRegistryKey("BarcodeLength") != null)
            {
                txtBarcodeLength.Text = Ultils.GetValueRegistryKey("BarcodeLength").ToString();
            }
            if (Ultils.GetValueRegistryKey("ColumnCount") != null)
            {
                txtColumnClount.Text = Ultils.GetValueRegistryKey("ColumnCount").ToString();
            }
        }

        private void FormConfig_Load(object sender, EventArgs e)
        {
            BinDataToControls();
        }

        private void btnSaveChanged_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cboWindows.Text))
            {
                MessageBox.Show("Vui lòng chọn Process!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboWindows.Focus();
            }
            else if (string.IsNullOrEmpty(txtStationNO.Text))
            {
                MessageBox.Show("Vui lòng nhập vào tên trạm!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtStationNO.Focus();
            }
            else if (string.IsNullOrEmpty(txtFileExtension.Text))
            {
                MessageBox.Show("Vui lòng nhập vào định dạng file!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFileExtension.Focus();
            }
            else if (string.IsNullOrEmpty(txtInputLog.Text))
            {
                MessageBox.Show("Vui lòng chọn đường dẫn file LOG!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblInputLog.Focus();
            }
            else if (string.IsNullOrEmpty(txtOutputLog.Text))
            {
                MessageBox.Show("Vui lòng chọn đường dẫn file LOG!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblOutputLog.Focus();
            }
            else if (string.IsNullOrEmpty(txtBarcodeLength.Text))
            {
                MessageBox.Show("Vui lòng nhập vào độ dài của barcode!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBarcodeLength.Focus();
            }
            else if (string.IsNullOrEmpty(txtColumnClount.Text))
            {
                MessageBox.Show("Vui lòng nhập column count!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtBarcodeLength.Focus();
            }
            else
            {
                Ultils.WriteRegistry("Process", cboWindows.Text.Substring(0, 7));
                Ultils.WriteRegistry("StationNO", txtStationNO.Text);
                Ultils.WriteRegistry("FileExtension", txtFileExtension.Text);
                Ultils.WriteRegistry("InputLog", txtInputLog.Text);
                Ultils.WriteRegistry("OutputLog", txtOutputLog.Text);
                Ultils.WriteRegistry("BarcodeLength", txtBarcodeLength.Text);
                Ultils.WriteRegistry("ColumnCount", txtColumnClount.Text);

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

        private void txtStationNO_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
