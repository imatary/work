using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Lib.Core;
using Lib.Form.Controls;
using MetroFramework;
using MetroFramework.Controls;
using MetroFramework.Forms;

namespace HondaLookSupports
{
    public partial class FormMain : MetroForm
    {
        public FormMain()
        {
            InitializeComponent();
            txtBarcode.Focus();
            metroTabControl1.SelectedIndex = 0;
            LoadSetting();

        }

        private string _messageText;

        private void FormMain_Activated(object sender, EventArgs e)
        {
            txtBarcode.Focus();
            RefeshSettings();
        }

        /// <summary>
        /// Active form
        /// </summary>
        /// <param name="windowsTitle"></param>
        private void ActiveFormByWindowsTitle(string windowsTitle)
        {
            int iHandle = NativeWin32.FindWindow(null, windowsTitle);
            NativeWin32.SetForegroundWindow(iHandle);
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
            List<string> list = new List<string>();
            while (nChildHandle != 0)
            {
                //If the child window is this (SendKeys) application then ignore it.
                if (nChildHandle == Handle.ToInt32())
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
                            list.Add(sWinTitle);
                        }
                    }
                }
                // Look for the next child.
                nChildHandle = NativeWin32.GetWindow(nChildHandle, NativeWin32.GW_HWNDNEXT);
            }
            cboWindows.DataSource = list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="status"></param>
        private void SetStatusDefault(string status)
        {
            if (lblState.InvokeRequired)
            {
                lblState.Invoke(new Action<string>(SetStatusDefault), status);
                return;
            }
            lblState.Text = status;
            lblState.ForeColor = Color.FromArgb(64, 64, 64);
            lblState.BackColor = Color.White;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="status"></param>
        private void SetMessageDefault(string status)
        {
            if (lblMessage.InvokeRequired)
            {
                lblMessage.Invoke(new Action<string>(SetMessageDefault), status);
                return;
            }
            lblMessage.Text = status;
            lblMessage.ForeColor = Color.White;
            lblMessage.BackColor = SystemColors.ControlDark;
        }

        private void SetColorWaterMark(MetroTextBox textbox, string messageText)
        {
            textbox.WaterMark = messageText;
            textbox.WaterMarkColor = Color.Crimson;
            txtBarcode.Focus();
        }
        private void SetColorWaterMarkDefault(MetroTextBox textbox)
        {
            textbox.WaterMark = "Input barcode here";
            textbox.WaterMarkColor = Color.FromArgb(109, 109, 109);
            txtBarcode.Focus();
        }

        //protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        //{
        //    switch (keyData)
        //    {
        //        //case Keys.Enter:
        //        //{
        //        //    txtBarcode.Focus();
        //        //    return true;
        //        //}
        //    }
        //    return base.ProcessCmdKey(ref msg, keyData);
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isNow"></param>
        private void SetWithError(bool isNow)
        {
            txtBarcode.WithError = isNow;
        }

        /// <summary>
        /// 
        /// </summary>
        private void RefeshSettings()
        {
            GetTaskWindows();
        }

        private void LoadSetting()
        {
            string processName = ConfigurationManager.AppSettings["ProcessName"];
            string stationNo = ConfigurationManager.AppSettings["StationNo"];
            string pathInput = ConfigurationManager.AppSettings["PathInput"];
            string pathOutput = ConfigurationManager.AppSettings["PathOutput"];
            //if (!string.IsNullOrEmpty(processName))
            //    cboWindows.SelectedText = processName;

            //if (!string.IsNullOrEmpty(stationNo))
            //    cboStationNo.SelectedValue = stationNo;

            if (!string.IsNullOrEmpty(pathInput))
                txtDirFolderLog.Text = pathInput;

            if (!string.IsNullOrEmpty(pathOutput))
                txtDirFolderOutLog.Text = pathOutput;

        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void txtBarcode_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string boardNo = txtBarcode.Text;
                _messageText = "Vui lòng bắn vào barcode cần kiểm tra!";
                if (string.IsNullOrEmpty(boardNo))
                {
                    SetWithError(true);
                    SetColorWaterMark(txtBarcode, _messageText);
                }
                else
                {
                    string windowsTile = ConfigurationManager.AppSettings["ProcessName"];
                    ActiveFormByWindowsTitle(windowsTile);
                    MessageBox.Show(windowsTile);
                }
            }
        }

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBarcode.Text))
            {
                SetWithError(false);
                SetStatusDefault("N/A");
                SetMessageDefault("no results");
            }
        }


        private void btnDirFolderLog_Click(object sender, EventArgs e)
        {
            DialogResult resDialog = folderBrowserDialog1.ShowDialog();
            if (resDialog == DialogResult.OK)
            {
                txtDirFolderLog.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnDirFolderOutLog_Click(object sender, EventArgs e)
        {
            DialogResult resDialog = folderBrowserDialog1.ShowDialog();
            if (resDialog == DialogResult.OK)
            {
                txtDirFolderOutLog.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btnSaveChanged_Click(object sender, EventArgs e)
        {
            string dirLog = txtDirFolderLog.Text.Trim();
            string dirOutLog = txtDirFolderOutLog.Text.Trim();
            string processName = cboWindows.Text;
            string stationNo = cboStationNo.Text;


            if (dirLog.Length > 0)
                SettingConfiguration.F_UpdateKey("PathInput", dirLog);
            if (dirOutLog.Length > 0)
                SettingConfiguration.F_UpdateKey("PathOutput", dirOutLog);
            if(processName.Length > 0)
                SettingConfiguration.F_UpdateKey("ProcessName", processName);
            if (stationNo.Length > 0)
                SettingConfiguration.F_UpdateKey("StationNo", stationNo);

            MessageBox.Show("Save success!");
            LoadSetting();
            RefeshSettings();
        }

        private void btnRefesh_Click(object sender, EventArgs e)
        {
            RefeshSettings();
        }

        private void metroTabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (metroTabControl1.SelectedIndex == 0)
            {
                txtBarcode.Focus();
            }
            else if(metroTabControl1.SelectedIndex==1)
            {
                RefeshSettings();
                LoadSetting();
            }
        }

        private void btnWatching_Click(object sender, EventArgs e)
        {
            if (txtBarcode.CustomButton.StyleManager.Style == MetroColorStyle.Blue)
            {
                txtBarcode.CustomButton.StyleManager.Style = MetroColorStyle.Orange;
                if (string.IsNullOrEmpty(txtBarcode.Text))
                {
                    _messageText = "Vui lòng bắn vào barcode cần kiểm tra!";
                    SetColorWaterMark(txtBarcode, _messageText);
                    CheckTextBoxNullValue.SetColorErrorMessage(lblState, "NG");
                    CheckTextBoxNullValue.SetLabelBackColorErrorMessage(lblMessage, _messageText);
                    txtBarcode.Focus();
                }
            }
            else
            {
                SetColorWaterMarkDefault(txtBarcode);
                SetStatusDefault("N/A");
                SetMessageDefault("no results");
                txtBarcode.CustomButton.StyleManager.Style = MetroColorStyle.Blue;
                txtBarcode.WithError = false;
                txtBarcode.ResetText();
                txtBarcode.Focus();
            }
        }

        
    }
}
