using DevExpress.XtraEditors;
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

namespace Mango_CTMS
{
    public partial class FormMain_old1 : Form
    {
        private bool _mBDirty;
        private FileSystemWatcher _mWatcher;
        private bool _mBIsWatching;
        private string _modelId;
        private string _productionId;
        private string _status;
        private string _boardState;
        private int _pass;
        private int _ng;
        private int _total;
        private string _messageError;
        private string _result;
        private string backup_log_folder = @"C:\backup_log\";

        delegate void SetCallBack(string text);

        private string _dateCheck;
        private readonly CommunicationManager _comRead;
        private readonly CommunicationManager _comWrite;
        private readonly INSPECTION_STATIONS_Service _inspectionStationsService;
        private readonly SCANNING_LOGS_Service _scanningLogsService;
        private readonly INSPECTION_PROCESSES_Service _inspectionProcessesService;
        private readonly INSPECTION_PROCEDURE_DESIGNERS_Service _inspectionProcessesDesignersService;
        private readonly WORK_ORDER_ITEMS_Service _workOrderItemService;

        private SCANNING_LOGS _scanningLogs;
        private INSPECTION_PROCESSES _inspectionProcesses;
        private WORK_ORDER_ITEMS _workOrderItems;

        public FormMain_old1()
        {
            InitializeComponent();
            backgroundWorker1.WorkerReportsProgress = true;
            _mBDirty = false;
            _mBIsWatching = false;
            lblVersion.Text = StringHelper.GetRunningVersion();
            Ultils.RegisterInStartup(true, Application.ExecutablePath);
            _comRead = new CommunicationManager();
            _comWrite = new CommunicationManager();
            _inspectionStationsService = new INSPECTION_STATIONS_Service();
            _scanningLogsService = new SCANNING_LOGS_Service();
            _inspectionProcessesService = new INSPECTION_PROCESSES_Service();
            _inspectionProcessesDesignersService = new INSPECTION_PROCEDURE_DESIGNERS_Service();
            _workOrderItemService = new WORK_ORDER_ITEMS_Service();
            LoadDataGridLookUpEditINSPECTION_STATIONS();
            GetPortNames();
        }

        /// <summary>
        /// Form load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormMain_Load(object sender, EventArgs e)
        {
            RefreshWindows();
            string valueComRead = Properties.Settings.Default["ValueComRead"].ToString();
            string valueComWrite = Properties.Settings.Default["ValueComWrite"].ToString();
            string processName = Properties.Settings.Default["CurentProcess"].ToString();
            string path = Properties.Settings.Default["Folder"].ToString();
            string stationNo = Properties.Settings.Default["StationNo"].ToString();
            bool comRead = (bool) Properties.Settings.Default["COMRead"];
            bool comWrite = (bool) Properties.Settings.Default["COMWrite"];
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
            if (path != "")
            {
                txtPath.Text = path;
            }
            if (stationNo != "")
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
        /// <param name="state"></param>
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
            List<ItemDetail> items = new List<ItemDetail> {item};

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
            cboWindows.Properties.DataSource = list;
        }

        /// <summary>
        /// List Ports Name
        /// </summary>
        private void GetPortNames()
        {
            gridLookUpEditComWrite.Properties.DataSource = _comWrite.SetPortNameValues();
            gridLookUpEditComWrite.Properties.PopupFormWidth = 160;

            gridLookUpEditComRead.Properties.DataSource = _comRead.SetPortNameValues();
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
                _comWrite.PortName = portName;
            }
            _comWrite.Parity = "None";
            _comWrite.StopBits = "One";
            _comWrite.DataBits = "8";
            _comWrite.BaudRate = "9600";
            _comWrite.DisplayWindow = null;
            _comWrite.OpenPort();
        }

        /// <summary>
        /// Cấu hình cổng COM đọc
        /// </summary>
        private void ConfigComRead()
        {
            string portName = gridLookUpEditComRead.EditValue.ToString();
            if (portName != "")
            {
                _comRead.PortName = portName;
            }
            _comRead.Parity = "None";
            _comRead.StopBits = "One";
            _comRead.DataBits = "8";
            _comRead.BaudRate = "9600";
            _comRead.DisplayWindow = null;
            _comRead.OpenPort();
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
                }}
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
                if (_mBIsWatching)
                {
                    _mBIsWatching = false;
                    _mWatcher.EnableRaisingEvents = false;
                    _mWatcher.Dispose();
                    btnWatchFile.Appearance.BackColor = Color.LightSkyBlue;
                    btnWatchFile.Text = @"Start Watching";
                    EnableControls(true);
                    txtBarcode.Visible = false;

                    CancelAsyncBackgroundWorker();
                }
                else
                {
                    _mBIsWatching = true;

                    if (!backgroundWorker1.IsBusy)
                    {
                        backgroundWorker1.RunWorkerAsync();
                    }

                    if (checkComWrite.Checked)
                    {
                        // Cấu hình COM PORT
                        ConfigComWrite();
                    }

                    if (checkComRead.Checked)
                    {
                        ConfigComRead();
                    }

                    btnWatchFile.ForeColor = Color.White;
                    btnWatchFile.Appearance.BackColor = Color.DarkRed;
                    btnWatchFile.Font = new Font(btnWatchFile.Font, FontStyle.Bold);

                    btnWatchFile.Text = @"Stop Watching";
                    EnableControls(false);
                    txtBarcode.Visible = true;
                    txtBarcode.Focus();

                    _mWatcher = new FileSystemWatcher();
                    if (rdbDir.Checked)
                    {
                        _mWatcher.Filter = "*.txt";
                        _mWatcher.Path = txtPath.Text + "\\";
                    }
                    else
                    {
                        _mWatcher.Filter = txtPath.Text.Substring(txtPath.Text.LastIndexOf('\\') + 1);
                        _mWatcher.Path = txtPath.Text.Substring(0, txtPath.Text.Length - _mWatcher.Filter.Length);
                    }

                    if (chkSubFolder.Checked)
                    {
                        _mWatcher.IncludeSubdirectories = true;
                    }

                    _mWatcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                                             | NotifyFilters.FileName | NotifyFilters.DirectoryName;
                    _mWatcher.Created += new FileSystemEventHandler(OnChanged);
                    _mWatcher.Changed += new FileSystemEventHandler(OnChanged);
                    //m_Watcher.Deleted += new FileSystemEventHandler(OnChanged);
                    _mWatcher.Renamed += new RenamedEventHandler(OnRenamed);
                    _mWatcher.EnableRaisingEvents = true;
                }
            }
        }

        /// <summary>
        /// Chờ sự thay đổi trong folder
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            if (!_mBDirty)
            {
                if (e.ChangeType == WatcherChangeTypes.Deleted || e.ChangeType == WatcherChangeTypes.Renamed)
                {
                    return;
                }
                if (e.FullPath.Contains("Mango_CTMS"))
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
                            _boardState = "FAILD";
                            _ng = _ng + 1;
                        }
                        else if (data == "PASS")
                        {
                            _status = "P";
                            _boardState = "OK";
                            _pass = _pass + 1;
                        }

                        _total = _pass + _ng;
                    }
                    else
                    {
                        Thread.Sleep(1000);
                        File.Copy(e.FullPath, fullPath);

                        var data = Ultils.ReadLogTxt(fullPath).LastOrDefault();

                        if (data == "FAIL")
                        {
                            _status = "F";
                            _boardState = "FAILD";
                            _ng = _ng + 1;
                        }
                        else if (data == "PASS")
                        {
                            _status = "P";
                            _boardState = "OK";
                            _pass = _pass + 1;
                        }

                        _total = _pass + _ng;
                    }

                    Ultils.CreateFileLog(_modelId, _productionId, _status, gridLookUpEditProcessID.EditValue.ToString(), _dateCheck);

                    if (!backgroundWorker1.IsBusy)
                    {
                        backgroundWorker1.RunWorkerAsync();
                    }

                    ActiveFormByWindowsTitle(cboWindows.EditValue.ToString());
                }
                else
                {
                    return;
                }
                _mBDirty = true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnRenamed(object sender, RenamedEventArgs e)
        {
            if (!_mBDirty)
            {
                _mBDirty = true;
                if (rdbFile.Checked)
                {
                    _mWatcher.Filter = e.Name;
                    _mWatcher.Path = e.FullPath.Substring(0, e.FullPath.Length - _mWatcher.Filter.Length);
                }
            }
        }

        private void rdbFile_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbFile.Checked)
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmrEditNotify_Tick(object sender, EventArgs e)
        {
            if (_mBDirty)
            {
                ActiveFormByWindowsTitle(Text);

                lblPass.Text = _pass.ToString();
                lblNG.Text = _ng.ToString();
                lblTotal.Text = _total.ToString();
                LoadData(_productionId, _modelId, gridLookUpEditProcessID.EditValue.ToString(), _boardState);
                _mBDirty = false;
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
            string strcomWrite = gridLookUpEditComWrite.EditValue.ToString();
            if (!string.IsNullOrEmpty(strcomWrite))
            {
                SaveSettings("ValueComWrite", strcomWrite);
            }
        }

        private void gridLookUpEditComRead_EditValueChanged(object sender, EventArgs e)
        {
            string strcomRead = gridLookUpEditComRead.EditValue.ToString();
            if (!string.IsNullOrEmpty(strcomRead))
            {
                SaveSettings("ValueComRead", strcomRead);
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
                    MessageHelpers.SetErrorStatus(true, "NG", "'File/Directory' not exits. Please try again!", lblStatus,
                        lblMessage);
                    CheckTextBoxNullValue.SetColorErrorTextControl(txtPath);
                }
            }
            else
            {
                MessageHelpers.SetErrorStatus(true, "NG", "'File/Directory' invaild. Please try again!", lblStatus,
                    lblMessage);
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
            GridView gridView = sender as GridView;
            if (e.Column.FieldName == "STATE")
            {
                string value = gridView.GetRowCellDisplayText(e.RowHandle,
                    gridView.Columns.ColumnByName("gridColumnSTATE"));
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

        private void gridLookUpEditSerialPort_ButtonPressed(object sender,
            DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
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
            lblNG.Text = @"0";
            lblPass.Text = @"0";
            lblTotal.Text = @"0";
            var allText = GetValueWindowText.GetAllTextFromWindowByTitle(cboWindows.EditValue.ToString());
            Ultils.WriteFile(allText);
            MessageBox.Show("Ghi OK");
        }

        /// <summary>
        /// Save value setting
        /// </summary>
        /// <param name="settingName"></param>
        /// <param name="value"></param>
        private void SaveSettings(string settingName, object value)
        {
            Properties.Settings.Default[settingName] = value;
            Properties.Settings.Default.Save(); // Saves settings in application configuration file
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBarcode_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                CancelAsyncBackgroundWorker();

                // Active form
                ActiveFormByWindowsTitle(cboWindows.EditValue.ToString());

                string boardNo = txtBarcode.Text;
                _dateCheck = Ultils.GetNetworkDateTime().ToString("yyMMddHHmmss") != ""
                    ? Ultils.GetNetworkDateTime().ToString("yyMMddHHmmss")
                    : DateTime.Now.ToString("yyMMddHHmmss");

                if (boardNo.Contains("="))
                {
                    boardNo = boardNo.Replace("=", "_");
                }

                string setStationNo = gridLookUpEditProcessID.EditValue.ToString();

                if (txtBarcode.Text.Length <= 10)
                {
                    CancelAsyncBackgroundWorker();
                    MessageHelpers.SetDefaultStatus(true, "N/A", "Waiting...", lblStatus, lblMessage);
                    if (!backgroundWorker1.IsBusy)
                    {
                        backgroundWorker1.RunWorkerAsync();
                    }
                }
                else
                {
                    _scanningLogs = _scanningLogsService.Get_SCANNING_LOGS(boardNo).FirstOrDefault();

                    if (_scanningLogs != null)
                    {
                        _inspectionProcesses =
                            _inspectionProcessesService.GET_INSPECTION_PROCESSES_BY_PRODUCT_ID(_scanningLogs.PRODUCT_ID);
                        if (_inspectionProcesses != null)
                        {
                            //trạng thái bản mạch hiện tại
                            _workOrderItems = _workOrderItemService.Get_WORK_ORDER_ITEMS_By_BoardNo(boardNo);
                            if (_workOrderItems != null)
                            {
                                // nếu đã đã chạy qua các bước, với trạng thái là Finished
                                // thì thông báo cho người dùng biết
                                if (_workOrderItems.IS_FINISHED)
                                {
                                    CancelAsyncBackgroundWorker();
                                    _messageError = $"Board '{boardNo}' is finished!";
                                    MessageHelpers.SetErrorStatus(true, "NG", _messageError, lblStatus, lblMessage);
                                    CheckTextBoxNullValue.SetColorErrorTextControl(txtBarcode);

                                    Reset(_messageError);
                                }
                                // Kiểm tra nếu trạng thái bản mạch hiện tại bị NG
                                // mà khác với với trạm được cài đặt "FCT" thì thông báo lỗi
                                else if (_workOrderItems.STATION_NO != setStationNo && _workOrderItems.BOARD_STATE == 2)
                                {
                                    CancelAsyncBackgroundWorker();
                                    _messageError = $"Board '{boardNo}' bị 'NG' tại trạm trước đó!";
                                    MessageHelpers.SetErrorStatus(true, "NG", _messageError, lblStatus, lblMessage);
                                    CheckTextBoxNullValue.SetColorErrorTextControl(txtBarcode);

                                    Reset(_messageError);
                                }
                                // Nếu tên giống nhau, thì thông báo đã chạy qua công đoạn này rồi
                                else if (_workOrderItems.STATION_NO == setStationNo && _workOrderItems.BOARD_STATE == 1)
                                {
                                    Excute(boardNo, _scanningLogs.PRODUCT_ID);
                                }
                                else
                                {
                                    var processDesigner =
                                        _inspectionProcessesDesignersService
                                            .GET_INSPECTION_PROCEDURE_DESIGNERS_BY_PROCESS_NO(
                                                _inspectionProcesses.PROCESS_NO);
                                    // Set station no
                                    var processByStationNo =
                                        processDesigner.FirstOrDefault(item => item.STATION_NO == setStationNo);
                                    // Nếu trong process_Designer không có STATION_NO giống với 
                                    // station_no curent thì thông báo cho người dùng biết
                                    if (processByStationNo == null)
                                    {
                                        CancelAsyncBackgroundWorker();
                                        _messageError = $"Board '{boardNo}' station '{setStationNo}' not invaild!";
                                        MessageHelpers.SetErrorStatus(true, "NG", _messageError, lblStatus, lblMessage);
                                        CheckTextBoxNullValue.SetColorErrorTextControl(txtBarcode);

                                        Reset(_messageError);
                                    }
                                    // nếu hợp lệ thực hiện tiếp
                                    else
                                    {
                                        // Khi hai giá trị bằng nhau => ICT_FUJ
                                        if (_workOrderItems.PROCEDURE_INDEX < (processByStationNo.INDEX - 1))
                                        {
                                            CancelAsyncBackgroundWorker();
                                            _messageError = $"Board '{boardNo}' bỏ qua công đoạn ''!";
                                            MessageHelpers.SetErrorStatus(true, "NG", _messageError, lblStatus,
                                                lblMessage);
                                            CheckTextBoxNullValue.SetColorErrorTextControl(txtBarcode);

                                            Reset(_messageError);
                                        }
                                        //// Nếu Index Board > Set Index 
                                        else if (_workOrderItems.PROCEDURE_INDEX > processByStationNo.INDEX)
                                        {
                                            CancelAsyncBackgroundWorker();
                                            // transferred to the next station.
                                            _messageError = $"Board '{boardNo}' transferred to the next station!";
                                            MessageHelpers.SetErrorStatus(true, "NG", _messageError, lblStatus,
                                                lblMessage);
                                            CheckTextBoxNullValue.SetColorErrorTextControl(txtBarcode);

                                            Reset(_messageError);
                                        }
                                        else if (_workOrderItems.PROCEDURE_INDEX == (processByStationNo.INDEX - 1))
                                        {
                                            Excute(boardNo, _scanningLogs.PRODUCT_ID);
                                        }
                                        else if (_workOrderItems.BOARD_STATE == 2)
                                        {
                                            Excute(boardNo, _scanningLogs.PRODUCT_ID);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                CancelAsyncBackgroundWorker();
                                _messageError = $"Không tìm thấy trạm với tên {setStationNo}!";
                                MessageHelpers.SetErrorStatus(true, "NG", _messageError, lblStatus, lblMessage);
                                CheckTextBoxNullValue.SetColorErrorTextControl(txtBarcode);

                                Reset(_messageError);
                            }
                        }
                        else
                        {
                            CancelAsyncBackgroundWorker();

                            _messageError = $"Station No '{setStationNo}' không hợp lệ!";
                            MessageHelpers.SetErrorStatus(true, "NG", _messageError, lblStatus, lblMessage);
                            CheckTextBoxNullValue.SetColorErrorTextControl(txtBarcode);

                            Reset(_messageError);
                        }
                    }
                    else
                    {
                        CancelAsyncBackgroundWorker();
                        _messageError = $"Board '{boardNo}' chưa được khởi tạo. Vui lòng kiểm tra lại!";
                        MessageHelpers.SetErrorStatus(true, "NG", _messageError, lblStatus, lblMessage);
                        CheckTextBoxNullValue.SetColorErrorTextControl(txtBarcode);

                        Reset(_messageError);
                    }

                    if (!backgroundWorker1.IsBusy)
                    {
                        backgroundWorker1.RunWorkerAsync();
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void CancelAsyncBackgroundWorker()
        {
            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.CancelAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        private void Reset(string message)
        {
            _result = "";
            //backgroundWorker1.ReportProgress(0, "NG");
            var errorForm = new FormError(message);
            errorForm.ShowDialog();
            // Active Form
            ActiveFormByWindowsTitle(cboWindows.EditValue.ToString());
            SendKeys.Send("^{A}");
            SendKeys.SendWait("{BS}");
            //txtBarcode.Text = string.Empty;
            //txtBarcode.Focus();
            if (!backgroundWorker1.IsBusy)
            {
                backgroundWorker1.RunWorkerAsync();
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="t"></param>
        private void SetText(string t)
        {
            if (txtBarcode.InvokeRequired)
            {
                SetCallBack d = SetText;
                Invoke(d, t);
            }
            else
            {
                txtBarcode.Text = t;
            }
        }

        /// <summary>
        /// Thực hiện lệnh gửi đi
        /// </summary>
        /// <param name="boardNo"></param>
        /// <param name="productId"></param>
        private void Excute(string boardNo, string productId)
        {

            CancelAsyncBackgroundWorker();

            txtBarcode.ResetText();
            txtBarcode.Focus();
            _productionId = boardNo;
            _modelId = productId;
            _result = "";
            MessageHelpers.SetSuccessStatus(true, "OK", $"Board '{boardNo}' OK!", lblStatus, lblMessage);
            // Thực hiện gửi dữ liệu đi

            //_serial = boardNo.Split(new[] { "_" }, 4, StringSplitOptions.None);
            //_maxaddress = boardNo.Split(new[] { "." }, 4, StringSplitOptions.None);

            //SendKeys.Send("{TAB}");
            //SendKeys.Send("{ENTER}");
            //SendKeys.Send(_serial[0]);
            //SendKeys.Send("{ENTER}");

            //SendKeys.Send(_maxaddress[1]);
            //SendKeys.Send("{ENTER}");

            if (checkComWrite.Checked)
            {
                // Start machine FCT Check
                Thread.Sleep(200);
                _comWrite.WriteData("S");
            }

            ActiveFormByWindowsTitle(cboWindows.EditValue.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            while (backgroundWorker1.CancellationPending == false)
            {
                Thread.Sleep(500);
                var allText = GetValueWindowText.GetAllTextFromWindowByTitle(cboWindows.EditValue.ToString());

                //var broad_id_first = allText.Split(new[] {"labelControl1"}, 4, StringSplitOptions.None);
                //var broad_id_last = broad_id_first[1].Split(new[] {"123456789"}, 4, StringSplitOptions.None);
                // Lấy giá trị serial
                var broad_id_first = allText.Split(new[] { "S/N" }, 4, StringSplitOptions.None);
                var broad_id_last = broad_id_first[1].Split(new[] { "NVM " }, 4, StringSplitOptions.None);

                _result = $"{broad_id_last[0]}";
                if (_result.Length > 10)
                {
                    _workOrderItems = _workOrderItemService.Get_WORK_ORDER_ITEMS_LIKE_BoardNo(_result);

                    if (_workOrderItems != null)
                    {
                        if (!_workOrderItems.IS_FINISHED)
                        {
                            backgroundWorker1.ReportProgress(0, _workOrderItems.BOARD_NO);
                        }
                    }
                    else
                    {
                        backgroundWorker1.ReportProgress(0, _result);
                    }

                }

                if (backgroundWorker1.CancellationPending)
                {
                    backgroundWorker1.ReportProgress(0, null);
                }
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            ActiveFormByWindowsTitle(Text);

            if (_result != "")
            {
                SetText(e.UserState as string);
                SendKeys.SendWait("{ENTER}");
            }
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
    }
}
