using Lib.Core;
using Lib.Form.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HondaLook_ICT
{
    public partial class FormConfigs : Form
    {
        public FormConfigs()
        {
            InitializeComponent();
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
                            list.Add(sWinTitle);
                        }
                    }
                }
                // Look for the next child.
                nChildHandle = NativeWin32.GetWindow(nChildHandle, NativeWin32.GW_HWNDNEXT);
            }
            txtProcessName.Properties.DataSource = list;
        }

        /// <summary>
        /// 
        /// </summary>
        private void LoadDataToControls()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"Configs\Settings.txt";
            txtProcessName.EditValue = Ultils.GetLine(path, 2);
            txtInputLog.Text = Ultils.GetLine(path, 4);
            txtExtensionInputLog.Text = Ultils.GetLine(path, 6);
            txtOutputLog.Text = Ultils.GetLine(path, 8);
            txtBarcodeLength.Text = Ultils.GetLine(path, 10);
            txtStationNo.Text = Ultils.GetLine(path, 12);
        }

        private void FormConfigs_Load(object sender, EventArgs e)
        {
            GetTaskWindows();
            LoadDataToControls();
        }

        private void txtProcessName_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                GetTaskWindows();
            }
        }

        private void txtInputLog_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 0)
            {
                FolderBrowserDialog openFile = new FolderBrowserDialog();
                var dialogResult = openFile.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    txtInputLog.Text = openFile.SelectedPath;
                    txtExtensionInputLog.Focus();
                    //txtExtensionInputLog.Text = Path.GetExtension(openFile.FileName);
                    //txtOutputLog.Focus();
                }
            }
        }

        private void txtOutputLog_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 0)
            {
                FolderBrowserDialog folderBrowser = new FolderBrowserDialog();
                var dialogResult = folderBrowser.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    txtOutputLog.Text = folderBrowser.SelectedPath;
                }
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"Configs\Settings.txt";
            if (!CheckTextBoxNullValue.CheckEditValueWithShowMessageError(txtProcessName, "Vui lòng chọn!"))
            {
                return;
            }
            else
            {
                Ultils.SetLine(path, 2, txtProcessName.EditValue.ToString());
                Ultils.SetLine(path, 4, txtInputLog.Text);
                Ultils.SetLine(path, 6, txtExtensionInputLog.Text);
                Ultils.SetLine(path, 8, txtOutputLog.Text);
                Ultils.SetLine(path, 10, txtBarcodeLength.Text);
                Ultils.SetLine(path, 12, txtStationNo.Text);
                MessageBox.Show("Lưu thành công!");
            }
        }

        private void txtProcessName_EditValueChanged(object sender, EventArgs e)
        {
            if (CheckTextBoxNullValue.ValidationTextEditNullValue(txtProcessName))
            {
                CheckTextBoxNullValue.SetColorDefaultTextControl(txtProcessName);
            }
        }

        
    }
}
