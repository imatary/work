﻿using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Lib.Core;
using Lib.Core.Helpers;
using Lib.Data;
using Lib.Form.Controls;
using Lib.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Shanks_IB02
{
    public partial class FormMain : Form
    {
        private StringBuilder m_Sb;
        private bool m_bDirty;
        private FileSystemWatcher m_Watcher;
        private bool m_bIsWatching;
        private bool startRead;
        private string modelId = null;
        private string productionId = null;
        private string _status = null;
        private string boardState = null;
        private int pass = 0;
        private int ng = 0;
        private int total = 0;
        private string messageError = null;
        string[] serial, maxaddress;
        private string backup_log_folder = @"C:\backup_log\";
        static string barcode_old = null;
        delegate void SetCallBack(string text);

        private string dateCheck;
        private CommunicationManager comRead;
        private CommunicationManager comWrite;
        private readonly INSPECTION_STATIONS_Service _inspectionStationsService;
        private readonly SCANNING_LOGS_Service _scanningLogsService;
        private readonly INSPECTION_PROCESSES_Service _inspectionProcessesService;
        private readonly INSPECTION_PROCEDURE_DESIGNERS_Service _inspectionProcessesDesignersService;
        private readonly WORK_ORDER_ITEMS_Service _workOrderItemService;
        public FormMain()
        {
            InitializeComponent();
            m_Sb = new StringBuilder();
            m_bDirty = false;
            m_bIsWatching = false;
            lblVersion.Text = StringHelper.GetRunningVersion();
            Ultils.RegisterInStartup(true, Application.ExecutablePath);
            comRead = new CommunicationManager();
            comWrite = new CommunicationManager();
            _inspectionStationsService = new INSPECTION_STATIONS_Service();
            _scanningLogsService = new SCANNING_LOGS_Service();
            _inspectionProcessesService = new INSPECTION_PROCESSES_Service();
            _inspectionProcessesDesignersService = new INSPECTION_PROCEDURE_DESIGNERS_Service();
            _workOrderItemService = new WORK_ORDER_ITEMS_Service();
            LoadDataGridLookUpEditINSPECTION_STATIONS();
            GetPortNames();
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            RefreshWindows();
            string valueComRead = Properties.Settings.Default["ValueComRead"].ToString();
            string valueComWrite = Properties.Settings.Default["ValueComWrite"].ToString();
            string processName = Properties.Settings.Default["CurentProcess"].ToString();
            string path = Properties.Settings.Default["Folder"].ToString();
            string stationNo = Properties.Settings.Default["StationNo"].ToString();
            bool comRead = (bool) Properties.Settings.Default["COMRead"];
            bool comWrite = (bool)Properties.Settings.Default["COMWrite"];
            if (valueComWrite != "")
            {
                gridLookUpEditComWrite.EditValue = valueComWrite;
            }
            if (valueComRead != "")
            {
                gridLookUpEditComRead.EditValue = valueComRead;
            }
            if (processName != "")
            {
                cboWindows.EditValue = processName;
            }
            if(path != "")
            {
                txtPath.Text = path;
            }
            if(stationNo!= "")
            {
                gridLookUpEditProcessID.EditValue = stationNo;
            }
            // COM WRITE
            checkComWrite.Checked = comWrite;

            // COM READ
            checkComRead.Checked = comRead;
        }

        /// <summary>
        /// 
        /// </summary>
        private void LoadDataGridLookUpEditINSPECTION_STATIONS()
        {
            var items = _inspectionStationsService.Get_INSPECTION_STATIONS();

            gridLookUpEditProcessID.Properties.DisplayMember = "STATION_NO";
            gridLookUpEditProcessID.Properties.ValueMember = "STATION_NO";
            gridLookUpEditProcessID.Properties.PopupFormWidth = 300;
            gridLookUpEditProcessID.Properties.DataSource = items;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="boardNo"></param>
        /// <param name="productId"></param>
        /// <param name="stationNo"></param>
        private void LoadData(string boardNo, string productId, string stationNo, string state)
        {
            ItemDetail item = new ItemDetail()
            {
                BOARD_NO = boardNo,
                ProductID = productId,
                STATION_NO = stationNo,
                DATE_CHECK = DateTime.Now.ToShortDateString(),
                TIME_CHECK = DateTime.Now.ToShortTimeString(),
                STATE = state,
            };
            List<ItemDetail> items = new List<ItemDetail>();
            items.Add(item);

            gridControl1.DataSource = items.OrderByDescending(it => it.TIME_CHECK);
        }
        /// <summary>
        /// Refresh the combobox list with all the top level windows running on desktop.
        /// </summary>
        private void RefreshWindows()
        {
            cboWindows.Refresh();
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
            cboWindows.Properties.DataSource = list;
        }

        /// <summary>
        /// List Ports Name
        /// </summary>
        private void GetPortNames()
        {
            gridLookUpEditComWrite.Properties.DataSource = comWrite.SetPortNameValues();
            gridLookUpEditComWrite.Properties.PopupFormWidth = 160;

            gridLookUpEditComRead.Properties.DataSource = comRead.SetPortNameValues();
            gridLookUpEditComRead.Properties.PopupFormWidth = 160;
        }
        /// <summary>
        /// Cấu hình cổng COM ghi
        /// </summary>
        private void ConfigComWrite()
        {
            string portName = gridLookUpEditComWrite.EditValue.ToString();
            if (portName != "")
            {
                comWrite.PortName = portName;
            }
            comWrite.Parity = "None";
            comWrite.StopBits = "One";
            comWrite.DataBits = "8";
            comWrite.BaudRate = "9600";
            comWrite.DisplayWindow = null;
            comWrite.OpenPort();
        }

        /// <summary>
        /// Cấu hình cổng COM đọc
        /// </summary>
        private void ConfigComRead()
        {
            string portName = gridLookUpEditComRead.EditValue.ToString();
            if (portName != "")
            {
                comRead.PortName = portName;
            }
            comRead.Parity = "None";
            comRead.StopBits = "One";
            comRead.DataBits = "8";
            comRead.BaudRate = "9600";
            comRead.DisplayWindow = null;
            comRead.OpenPort();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enable"></param>
        private void EnableControls(bool enable)
        {
            gridLookUpEditProcessID.Enabled = enable;
            txtPath.Enabled = enable;
        }

        /// <summary>
        /// Hot key
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Shift | Keys.F2:
                    {
                        // COM WRITE
                        gridLookUpEditComWrite.Enabled = true;
                        checkComWrite.Enabled = true;

                        // COM READ
                        gridLookUpEditComRead.Enabled = true;
                        checkComRead.Enabled = true;

                        cboWindows.Enabled = true;
                        checkKeepProcess.Enabled = true;
                        return true;
                    }
                case Keys.Shift | Keys.F3:
                    {
                        // COM WRITE
                        gridLookUpEditComWrite.Enabled = false;
                        checkComWrite.Enabled = false;

                        // COM READ
                        gridLookUpEditComRead.Enabled = false;
                        checkComRead.Enabled = false;

                        cboWindows.Enabled = false;
                        checkKeepProcess.Enabled = false;
                        return true;
                    }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }


        private void btnWatchFile_Click(object sender, EventArgs e)
        {
            bool isVaild = true;
            if (!CheckTextBoxNullValue.ValidationTextEditNullValue(gridLookUpEditProcessID))
            {
                MessageHelpers.SetErrorStatus(true, "NG", "Please select a 'Station No'!", lblStatus, lblMessage);
                isVaild = false;
            }
            else if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtPath))
            {
                MessageHelpers.SetErrorStatus(true, "NG", "Please select a 'File/Directory'!", lblStatus, lblMessage);
                isVaild = false;
            }
            else if (isVaild)
            {
                if (m_bIsWatching)
                {
                    m_bIsWatching = false;
                    m_Watcher.EnableRaisingEvents = false;
                    m_Watcher.Dispose();
                    btnWatchFile.Appearance.BackColor = Color.LightSkyBlue;
                    btnWatchFile.Text = "Start Watching";
                    EnableControls(true);
                    txtBarcode.Visible = false;

                    StopTimerReadBarcode();
                    
                }
                else
                {
                    m_bIsWatching = true;

                    StartTimerReadBarcode();

                    if (checkComWrite.Checked == true)
                    {
                        // Cấu hình COM PORT
                        ConfigComWrite();
                    }

                    if(checkComRead.Checked == true)
                    {
                        ConfigComRead();
                    }

                    btnWatchFile.ForeColor = Color.White;
                    btnWatchFile.Appearance.BackColor = Color.DarkRed;
                    btnWatchFile.Font = new Font(btnWatchFile.Font, FontStyle.Bold);

                    btnWatchFile.Text = "Stop Watching";
                    EnableControls(false);
                    txtBarcode.Visible = true;
                    txtBarcode.Focus();

                    m_Watcher = new FileSystemWatcher();
                    if (rdbDir.Checked)
                    {
                        m_Watcher.Filter = "*.txt";
                        m_Watcher.Path = txtPath.Text + "\\";
                    }
                    else
                    {
                        m_Watcher.Filter = txtPath.Text.Substring(txtPath.Text.LastIndexOf('\\') + 1);
                        m_Watcher.Path = txtPath.Text.Substring(0, txtPath.Text.Length - m_Watcher.Filter.Length);
                    }

                    if (chkSubFolder.Checked)
                    {
                        m_Watcher.IncludeSubdirectories = true;
                    }

                    m_Watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                                         | NotifyFilters.FileName | NotifyFilters.DirectoryName;
                    m_Watcher.Created += new FileSystemEventHandler(OnChanged);
                    m_Watcher.Changed += new FileSystemEventHandler(OnChanged);
                    //m_Watcher.Deleted += new FileSystemEventHandler(OnChanged);
                    m_Watcher.Renamed += new RenamedEventHandler(OnRenamed);
                    m_Watcher.EnableRaisingEvents = true;
                }
            }
        }

        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            if (!m_bDirty)
            {
                if (e.ChangeType == WatcherChangeTypes.Deleted || e.ChangeType == WatcherChangeTypes.Renamed)
                {
                    return;
                }
                else
                {
                    if (e.FullPath.Contains("Shanks_IB02"))
                    {
                        // DO SOMETING LIKE MOVE, COPY, ETC
                        bool exists = Directory.Exists(backup_log_folder);
                        if (!exists)
                            Directory.CreateDirectory(backup_log_folder);

                        string fullPath = backup_log_folder + e.Name;

                        if (File.Exists(fullPath))
                        {
                            File.Delete(fullPath);
                            Thread.Sleep(1000);
                            File.Copy(e.FullPath, fullPath);

                            var data = Ultils.ReadLogTxt(fullPath).LastOrDefault();

                            if (data == "FAIL")
                            {
                                _status = "F";
                                boardState = "FAILD";
                                ng = ng + 1;
                            }
                            else if(data == "PASS")
                            {
                                _status = "P";
                                boardState = "OK";
                                pass = pass + 1;

                                // Đóng dấu tự động
                                if (checkComWrite.Checked == true)
                                {
                                    comWrite.WriteData("A");
                                }
                            }

                            total = pass + ng;
                            Ultils.CreateFileLog(modelId, productionId, _status, gridLookUpEditProcessID.EditValue.ToString(), dateCheck);
                        }
                        else
                        {
                            Thread.Sleep(1000);
                            File.Copy(e.FullPath, fullPath);

                            var data = Ultils.ReadLogTxt(fullPath).LastOrDefault();

                            if (data == "FAIL")
                            {
                                _status = "F";
                                boardState = "FAILD";
                                ng = ng + 1;
                            }
                            else if (data == "PASS")
                            {
                                _status = "P";
                                boardState = "OK";
                                pass = pass + 1;
                            }

                            total = pass + ng;
                            Ultils.CreateFileLog(modelId, productionId, _status, gridLookUpEditProcessID.EditValue.ToString(), dateCheck);
                        }
                    }
                    else
                    {
                        return;
                    }
                }

                m_bDirty = true;
            }
        }

        private void OnRenamed(object sender, RenamedEventArgs e)
        {
            if (!m_bDirty)
            {
                m_bDirty = true;
                if (rdbFile.Checked)
                {
                    m_Watcher.Filter = e.Name;
                    m_Watcher.Path = e.FullPath.Substring(0, e.FullPath.Length - m_Watcher.Filter.Length);
                }
            }
        }

        private void rdbFile_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbFile.Checked == true)
            {
                chkSubFolder.Enabled = false;
                chkSubFolder.Checked = false;
            }
        }

        private void rdbDir_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbDir.Checked == true)
            {
                chkSubFolder.Enabled = true;
                chkSubFolder.Checked = true;
            }
        }

        private void txtPath_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 0)
            {
                if (rdbDir.Checked)
                {
                    DialogResult resDialog = dlgOpenDir.ShowDialog();
                    if (resDialog.ToString() == "OK")
                    {
                        txtPath.Text = dlgOpenDir.SelectedPath;
                    }
                }
                else
                {
                    DialogResult resDialog = dlgOpenFile.ShowDialog();
                    if (resDialog.ToString() == "OK")
                    {
                        txtPath.Text = dlgOpenFile.FileName;
                    }
                }
            }
        }

        private void tmrEditNotify_Tick(object sender, EventArgs e)
        {
            if (m_bDirty)
            {
                //this.TopMost = true;
                int iHandle2 = NativeWin32.FindWindow(null, this.Text);
                NativeWin32.SetForegroundWindow(iHandle2);
                lblPass.Text = pass.ToString();
                lblNG.Text = ng.ToString();
                lblTotal.Text = total.ToString();
                LoadData(productionId, modelId, gridLookUpEditProcessID.EditValue.ToString(), boardState);
                m_bDirty = false;
            }
        }  
        private void txtBarcode_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string boardNo = txtBarcode.Text;
                dateCheck = Ultils.GetNetworkDateTime().ToString("yyMMddHHmmss");

                if (boardNo.Contains("="))
                {
                    boardNo = boardNo.Replace("=", "_");
                }

                string set_station_no = gridLookUpEditProcessID.EditValue.ToString();

                if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtBarcode))
                {
                    MessageHelpers.SetErrorStatus(true, "NG", "Please input a barcode!", lblStatus, lblMessage);
                    startRead = false;
                    return;
                }
                else if (txtBarcode.Text.Length <= 5)
                {
                    MessageHelpers.SetErrorStatus(true, "NG", $"Board No {boardNo} invaild. Please try again!", lblStatus, lblMessage);
                    CheckTextBoxNullValue.SetColorErrorTextControl(txtBarcode);
                    startRead = false;
                    return;
                }
                else
                {
                    MessageHelpers.SetDefaultStatus(true, "N/A", "N/A", lblStatus, lblMessage);
                    CheckTextBoxNullValue.SetColorDefaultTextControl(txtBarcode);

                    var boards = _scanningLogsService.Get_SCANNING_LOGS(boardNo).FirstOrDefault();

                    if (boards != null)
                    {
                        var process_No = _inspectionProcessesService.GET_INSPECTION_PROCESSES_BY_PRODUCT_ID(boards.PRODUCT_ID);
                        if (process_No != null)
                        {
                            //    //trạng thái bản mạch hiện tại
                            var curentStationNo = _workOrderItemService.Get_WORK_ORDER_ITEMS_By_BoardNo(boardNo);
                            if (curentStationNo != null)
                            {
                                // nếu đã đã chạy qua các bước, với trạng thái là Finished
                                // thì thông báo cho người dùng biết
                                if (curentStationNo.IS_FINISHED == true)
                                {
                                    messageError = $"Board '{boardNo}' is finished!";
                                    MessageHelpers.SetErrorStatus(true, "NG", messageError, lblStatus, lblMessage);
                                    CheckTextBoxNullValue.SetColorErrorTextControl(txtBarcode);
                                    startRead = false;
                                    var errorForm = new FormError(messageError);
                                    errorForm.ShowDialog();
                                    txtBarcode.Focus();
                                }
                                // Kiểm tra nếu trạng thái bản mạch hiện tại bị NG
                                // mà khác với với trạm được cài đặt "FCT" thì thông báo lỗi
                                else if (curentStationNo.STATION_NO != set_station_no && curentStationNo.BOARD_STATE == 2)
                                {
                                    messageError = $"Board '{boardNo}' bị 'NG' tại trạm '{set_station_no}'!";
                                    MessageHelpers.SetErrorStatus(true, "NG", messageError, lblStatus, lblMessage);
                                    CheckTextBoxNullValue.SetColorErrorTextControl(txtBarcode);
                                    startRead = false;
                                    var errorForm = new FormError(messageError);
                                    errorForm.ShowDialog();
                                    txtBarcode.Focus();
                                }
                                // Nếu tên giống nhau, thì thông báo đã chạy qua công đoạn này rồi
                                else if (curentStationNo.STATION_NO == set_station_no && curentStationNo.BOARD_STATE == 1)
                                {
                                    Excute(boardNo, boards.PRODUCT_ID);
                                }
                                else
                                {
                                    var process_Designer = _inspectionProcessesDesignersService.GET_INSPECTION_PROCEDURE_DESIGNERS_BY_PROCESS_NO(process_No.PROCESS_NO);
                                    // Set station no
                                    var process_by_station_no = process_Designer.FirstOrDefault(item => item.STATION_NO == set_station_no);
                                    // Nếu trong process_Designer không có STATION_NO giống với 
                                    // station_no curent thì thông báo cho người dùng biết
                                    if (process_by_station_no == null)
                                    {
                                        messageError = $"Board '{boardNo}' station '{set_station_no}' not invaild!";
                                        MessageHelpers.SetErrorStatus(true, "NG", messageError, lblStatus, lblMessage);
                                        CheckTextBoxNullValue.SetColorErrorTextControl(txtBarcode);
                                        startRead = false;
                                        var errorForm = new FormError(messageError);
                                        errorForm.ShowDialog();
                                        txtBarcode.Focus();
                                    }
                                    // nếu hợp lệ thực hiện tiếp
                                    else
                                    {
                                        // Khi hai giá trị bằng nhau => ICT_FUJ
                                        if (curentStationNo.PROCEDURE_INDEX < (process_by_station_no.INDEX - 1))
                                        {
                                            messageError = $"Board '{boardNo}' skip stations!";
                                            MessageHelpers.SetErrorStatus(true, "NG", messageError, lblStatus, lblMessage);
                                            CheckTextBoxNullValue.SetColorErrorTextControl(txtBarcode);
                                            startRead = false;
                                            var errorForm = new FormError(messageError);
                                            errorForm.ShowDialog();
                                            txtBarcode.Focus();
                                            return;
                                        }
                                        //// Nếu Index Board > Set Index 
                                        else if (curentStationNo.PROCEDURE_INDEX > process_by_station_no.INDEX)
                                        {
                                            // transferred to the next station.
                                            messageError = $"Board '{boardNo}' transferred to the next station!";
                                            MessageHelpers.SetErrorStatus(true, "NG", messageError, lblStatus, lblMessage);
                                            CheckTextBoxNullValue.SetColorErrorTextControl(txtBarcode);
                                            startRead = false;
                                            var errorForm = new FormError(messageError);
                                            errorForm.ShowDialog();
                                            txtBarcode.Focus();
                                            return;
                                        }
                                        else if (curentStationNo.PROCEDURE_INDEX == (process_by_station_no.INDEX - 1))
                                        {
                                            Excute(boardNo, boards.PRODUCT_ID);
                                        }
                                        else if(curentStationNo.BOARD_STATE == 2)
                                        {
                                            Excute(boardNo, boards.PRODUCT_ID);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                messageError = $"Station No '{curentStationNo.STATION_NO}' not found!";
                                MessageHelpers.SetErrorStatus(true, "NG", messageError, lblStatus, lblMessage);
                                CheckTextBoxNullValue.SetColorErrorTextControl(txtBarcode);
                                var errorForm = new FormError(messageError);
                                errorForm.ShowDialog();
                                txtBarcode.Focus();
                                return;
                            }
                        }
                        else
                        {
                            messageError = $"Station No '{set_station_no}' invaild!";
                            MessageHelpers.SetErrorStatus(true, "NG", messageError, lblStatus, lblMessage);
                            CheckTextBoxNullValue.SetColorErrorTextControl(txtBarcode);
                            var errorForm = new FormError(messageError);
                            errorForm.ShowDialog();
                            txtBarcode.Focus();
  
                        }
                    }
                    else
                    {
                        messageError = $"Board '{boardNo}' not initialized!";
                        MessageHelpers.SetErrorStatus(true, "NG", messageError, lblStatus, lblMessage);
                        CheckTextBoxNullValue.SetColorErrorTextControl(txtBarcode);
                        var errorForm = new FormError(messageError);
                        errorForm.ShowDialog();
                        txtBarcode.Focus();
                    }
                }
            }    
        }

        private void cboWindows_EditValueChanged(object sender, EventArgs e)
        {
            string processName = cboWindows.EditValue.ToString();
            if (!string.IsNullOrEmpty(processName))
            {
                SaveSettings("CurentProcess", processName);
            } 
        }
        private void gridLookUpEditSerialPort_EditValueChanged(object sender, EventArgs e)
        {
            string comWrite = gridLookUpEditComWrite.EditValue.ToString();
            if (!string.IsNullOrEmpty(comWrite))
            {
                SaveSettings("ValueComWrite", comWrite);
            }
        }
        private void gridLookUpEditComRead_EditValueChanged(object sender, EventArgs e)
        {
            string comRead = gridLookUpEditComRead.EditValue.ToString();
            if (!string.IsNullOrEmpty(comRead))
            {
                SaveSettings("ValueComRead", comRead);
            }
        }
        private void checkEditSerialPort_CheckedChanged(object sender, EventArgs e)
        {
            SaveSettings("COMWrite", checkComWrite.Checked);
        }
        private void checkComRead_CheckedChanged(object sender, EventArgs e)
        {
            SaveSettings("COMRead", checkComRead.Checked);
        }
        private void txtPath_EditValueChanged(object sender, EventArgs e)
        {
            if (txtPath.Text.Contains(@":\"))
            {
                if (Directory.Exists(txtPath.Text))
                {
                    MessageHelpers.SetDefaultStatus(true, "N/A", "N/A", lblStatus, lblMessage);
                    CheckTextBoxNullValue.SetColorDefaultTextControl(txtPath);
                    string path = txtPath.Text;
                    SaveSettings("Folder", path);
                }
                else
                {
                    MessageHelpers.SetErrorStatus(true, "NG", "'File/Directory' not exits. Please try again!", lblStatus, lblMessage);
                    CheckTextBoxNullValue.SetColorErrorTextControl(txtPath);
                }
            }
            else
            {
                MessageHelpers.SetErrorStatus(true, "NG", "'File/Directory' invaild. Please try again!", lblStatus, lblMessage);
                CheckTextBoxNullValue.SetColorErrorTextControl(txtPath);
            }
        }
        private void gridLookUpEditProcessID_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(gridLookUpEditProcessID);
            string stationNo = gridLookUpEditProcessID.EditValue.ToString();
            if (!string.IsNullOrEmpty(stationNo))
            {
                SaveSettings("StationNo", stationNo);
            }           
        }
        private void txtBarcode_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(txtBarcode);
        }
        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.Column.FieldName == "STATE")
            {
                string value = View.GetRowCellDisplayText(e.RowHandle, View.Columns.ColumnByName("gridColumnSTATE"));
                if (value == "OK")
                {
                    e.Appearance.BackColor = Color.Green;
                    e.Appearance.BackColor2 = Color.DarkGreen;
                    e.Appearance.ForeColor = Color.White;

                }
                else if (value == "FAILD")
                {
                    e.Appearance.BackColor = Color.Red;
                    e.Appearance.BackColor2 = Color.DarkRed;
                    e.Appearance.ForeColor = Color.White;
                }
            }
        }
        private void cboWindows_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                RefreshWindows();
            }
        }
        private void gridLookUpEditSerialPort_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if(e.Button.Index == 1)
            {
                RefreshWindows();
            }
        }
        private void gridLookUpEditComRead_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                RefreshWindows();
            }
        }
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                dynamic mboxResult = XtraMessageBox.Show("Bạn có thực sự muốn thoát hay không?",
                    @"THÔNG BÁO",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);
                if (mboxResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else if (mboxResult == DialogResult.Yes)
                {
                    e.Cancel = false;
                    Application.ExitThread();  
                }
            }
        }
        private void btnRefesh_Click(object sender, EventArgs e)
        {
            lblNG.Text = "0";
            lblPass.Text = "0";
            lblTotal.Text = "0";

            comRead.WriteData("OK");
        }

        /// <summary>
        /// Save value setting
        /// </summary>
        /// <param name="settingName"></param>
        /// <param name="value"></param>
        private void SaveSettings(string settingName, object value)
        {
            Properties.Settings.Default[settingName] = value;
            Properties.Settings.Default.Save();// Saves settings in application configuration file
        }

        private void timerReadCom_Tick(object sender, EventArgs e)
        {
            if (comRead.ReadComPort() != "")
            {
                if (comRead.ReadComPort().Length > 6)
                {
                    txtBarcode.Text = comRead.ReadComPort();
                    SendKeys.Send("{ENTER}");
                    comRead.WriteData("");
                }
            }
        }

        private void gridLookUpEditModel_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if(e.Button.Index==1)
            {

            }
        }

        /// <summary>
        /// STOP TIMER BARCODE
        /// </summary>
        private void StopTimerReadBarcode()
        {
            timerReadCom.Enabled = false;
            timerReadCom.Stop();

        }

        /// <summary>
        /// START TIMER BARCODE
        /// </summary>
        private void StartTimerReadBarcode()
        {
            timerReadCom.Enabled = true;
            timerReadCom.Start();

        }
        private void Excute(string boardNo, string product_id)
        {
            this.TopMost = false;

            StopTimerReadBarcode();

            txtBarcode.ResetText();
            txtBarcode.Focus();
            productionId = boardNo;
            modelId = product_id;
            MessageHelpers.SetSuccessStatus(true, "OK", $"Board '{boardNo}' OK!", lblStatus, lblMessage);
            // Thực hiện gửi dữ liệu đi
            int iHandle = NativeWin32.FindWindow(null, cboWindows.Text);
            NativeWin32.SetForegroundWindow(iHandle);

            serial = boardNo.Split(separator: new[] { "_" }, count: 4, options: StringSplitOptions.None);
            //maxaddress = boardNo.Split(separator: new[] { "." }, count: 4, options: StringSplitOptions.None);

            //SendKeys.Send("{TAB}");
            //SendKeys.Send("{ENTER}");
            SendKeys.Send(serial[0]);
            SendKeys.Send("{ENTER}");

            //SendKeys.Send(maxaddress[1]);
            //SendKeys.Send("{ENTER}");

            if (checkComWrite.Checked == true)
            {
                // Start machine FCT Check
                Thread.Sleep(200);
                comWrite.WriteData("S");
            }
        }
    }
}
