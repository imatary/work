using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Windows.Forms;
using Lib.Core;
using Lib.Services;

namespace HondaLookSupports
{
    public partial class FormConfigs : Form
    {
        //private readonly INSPECTION_STATIONS_Service _inspectionStationsService;
        public FormConfigs()
        {
            InitializeComponent();
            //_inspectionStationsService = new INSPECTION_STATIONS_Service();

            //LoadDataGridLookUpEditINSPECTION_STATIONS();
            RefreshWindows();
            LoadSetting();
        }

        private void btnSaveChanged_Click(object sender, EventArgs e)
        {
            string dirLog = txtFolderLogs.Text.Trim();
            string dirOutLog = txtFolderOutLog.Text.Trim();
            string processName = gridLookUpProcess.EditValue.ToString();
            string stationNo = txtStationNo.Text;
            string barcodeLength = txtBarcodeLength.Text;


            if (dirLog.Length > 0)
                SettingConfiguration.F_UpdateKey("PathInput", dirLog);
            if (dirOutLog.Length > 0)
                SettingConfiguration.F_UpdateKey("PathOutput", dirOutLog);
            if (processName.Length > 0)
                SettingConfiguration.F_UpdateKey("ProcessName", processName);
            if (stationNo.Length > 0)
                SettingConfiguration.F_UpdateKey("StationNo", stationNo);
            if (barcodeLength.Length > 1)
                SettingConfiguration.F_UpdateKey("BarcodeLength", barcodeLength);


            MessageBox.Show("Cập nhật cấu hình thành công. Chương trình sẽ tự động tắt, vui lòng chạy lại!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            Application.Exit();
        }

        private void txtFolderLogs_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if(e.Button.Index==0)
            {
                var dialogResult = folderLogsBrowserDialog.ShowDialog();
                if(dialogResult == DialogResult.OK)
                {
                    txtFolderLogs.Text = folderLogsBrowserDialog.SelectedPath;
                }
            }
        }

        private void txtFolderOutLog_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 0)
            {
                var dialogResult = folderOutLogBrowserDialog.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    txtFolderLogs.Text = folderOutLogBrowserDialog.SelectedPath;
                }
            }
        }

        private void gridLookUpProcess_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                RefreshWindows();
            }
            
        }

        private void gridLookUpStation_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if(e.Button.Index == 1)
            {
                //LoadDataGridLookUpEditINSPECTION_STATIONS();
            }
        }

        /// <summary>
        /// Refresh the combobox list with all the top level windows running on desktop.
        /// </summary>
        private void RefreshWindows()
        {
            gridLookUpProcess.Refresh();
            GetTaskWindows();
            //GetPortNames();
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
            gridLookUpProcess.Properties.DataSource = list;
        }

        /// <summary>
        /// 
        /// </summary>
        //private void LoadDataGridLookUpEditINSPECTION_STATIONS()
        //{
        //    var items = _inspectionStationsService.Get_INSPECTION_STATIONS();

        //    gridLookUpStation.Properties.DisplayMember = "STATION_NO";
        //    gridLookUpStation.Properties.ValueMember = "STATION_NO";
        //    gridLookUpStation.Properties.PopupFormWidth = 300;
        //    gridLookUpStation.Properties.DataSource = items;
        //}

        private void LoadSetting()
        {
            string processName = ConfigurationManager.AppSettings["ProcessName"];
            string stationNo = ConfigurationManager.AppSettings["StationNo"];
            string pathInput = ConfigurationManager.AppSettings["PathInput"];
            string pathOutput = ConfigurationManager.AppSettings["PathOutput"];
            string barcodeLength = ConfigurationManager.AppSettings["BarcodeLength"];

            if (!string.IsNullOrEmpty(processName))
                gridLookUpProcess.EditValue = processName;

            if (!string.IsNullOrEmpty(stationNo))
                txtStationNo.Text = stationNo;

            if (!string.IsNullOrEmpty(pathInput))
                txtFolderLogs.Text = pathInput;

            if (!string.IsNullOrEmpty(pathOutput))
                txtFolderOutLog.Text = pathOutput;

            if (!string.IsNullOrEmpty(barcodeLength))
                txtBarcodeLength.Text = barcodeLength;
        }
    }
}
