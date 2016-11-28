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
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Mango_CTMS
{
    public partial class FormMain_old : Form
    {
        private bool _mBDirty;
        private FileSystemWatcher _mWatcher;
        private bool _mBIsWatching;
        private string _productionId, _modelId, _status, _boardState;
        private int _pass, _ng, _total;
        private string _messageError, _dateCheck, _timeCheck, _result, _barcodeOld = "", _strTimeRun = "0";

        string backup_log_folder = @"C:\backup_log\";
        private CommunicationManager com;
        private readonly INSPECTION_STATIONS_Service _inspectionStationsService;
        private readonly SCANNING_LOGS_Service _scanningLogsService;
        private readonly INSPECTION_PROCESSES_Service _inspectionProcessesService;
        private readonly INSPECTION_PROCEDURE_DESIGNERS_Service _inspectionProcessesDesignersService;
        private readonly WORK_ORDER_ITEMS_Service _workOrderItemService;

        private SCANNING_LOGS _scanningLogs;
        private INSPECTION_PROCESSES _inspectionProcesses;
        private WORK_ORDER_ITEMS _workOrderItems;
        private List<INSPECTION_PROCEDURE_DESIGNERS> _inspectionProcedureDesigners;

        public FormMain_old()
        {
            InitializeComponent();
            _mBDirty = false;
            _mBIsWatching = false;
            lblVersion.Text = StringHelper.GetRunningVersion();
            Ultils.RegisterInStartup(true, Application.ExecutablePath);
            com = new CommunicationManager();
            _inspectionStationsService = new INSPECTION_STATIONS_Service();
            _scanningLogsService = new SCANNING_LOGS_Service();
            _inspectionProcessesService = new INSPECTION_PROCESSES_Service();
            _inspectionProcessesDesignersService = new INSPECTION_PROCEDURE_DESIGNERS_Service();
            _workOrderItemService = new WORK_ORDER_ITEMS_Service();

            LoadDataGridLookUpEditINSPECTION_STATIONS();
        }
        private void FormMain_Load(object sender, EventArgs e)
        {
            RefreshWindows();

            if (checkKeepProcess.Checked == true)
            {
                cboWindows.EditValue = Properties.Settings.Default["CurentProcess"].ToString();
            }
            if(checkPath.Checked == true)
            {
                txtPath.Text = Properties.Settings.Default["Folder"].ToString();
            }
            if (checkStationNo.Checked == true)
            {
                gridLookUpEditProcessID.EditValue = Properties.Settings.Default["StationNo"].ToString();
            }
        }

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
        private void LoadData(string boardNo, string productId, string stationNo, string boardSate)
        {
            ItemDetail item = new ItemDetail()
            {
                BOARD_NO = boardNo,
                ProductID = productId,
                STATION_NO = stationNo,
                DATE_CHECK = _dateCheck,
                TIME_CHECK = Ultils.GetNetworkDateTime().ToShortTimeString(),
                STATE = boardSate,
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
            LoadSerialPorts();
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
                    String sWinTitle = sbTitle.ToString();
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
        /// Load com port
        /// </summary>
        private void LoadSerialPorts()
        {
            List<string> listCom = new List<string>();
            foreach (string s in SerialPort.GetPortNames())
            {
                listCom.Add(s);
            }

            gridLookUpEditSerialPort.Properties.DataSource = listCom;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enable"></param>
        private void EnableControls(bool enable)
        {
            //rdbFile.Enabled = enable;
            //rdbDir.Enabled = enable;
            //chkSubFolder.Enabled = enable;
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
                        cboWindows.Enabled = true;
                        checkKeepProcess.Enabled = true;
                        checkEditSerialPort.Enabled = true;
                        gridLookUpEditSerialPort.Enabled = true;
                        return true;
                    }
                case Keys.Shift | Keys.F3:
                    {
                        cboWindows.Enabled = false;
                        checkKeepProcess.Enabled = false;
                        checkEditSerialPort.Enabled = false;
                        gridLookUpEditSerialPort.Enabled = false;
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
                if (_mBIsWatching)
                {
                    _mBIsWatching = false;
                    _mWatcher.EnableRaisingEvents = false;
                    _mWatcher.Dispose();
                    btnWatchFile.Appearance.BackColor = Color.LightSkyBlue;
                    btnWatchFile.Text = "Start Watching";
                    EnableControls(true);
                    txtBarcode.Visible = false;
                }
                else
                {
                    _mBIsWatching = true;
                    btnWatchFile.ForeColor = Color.White;
                    btnWatchFile.Appearance.BackColor = Color.DarkRed;
                    btnWatchFile.Font = new Font(btnWatchFile.Font, FontStyle.Bold);

                    btnWatchFile.Text = "Stop Watching";
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
        /// 
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
                else
                {
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
                            else if(data == "PASS")
                            {
                                _status = "P";
                                _boardState = "OK";
                                _pass = _pass + 1;
                            }

                            _total = _pass + _ng;
                            Ultils.CreateFileLog(_modelId, _productionId, _status, gridLookUpEditProcessID.EditValue.ToString(), _dateCheck);
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
                            else if(data == "PASS")
                            {
                                _status = "P";
                                _boardState = "OK";
                                _pass = _pass + 1;
                            }

                            _total = _pass + _ng;
                            Ultils.CreateFileLog(_modelId, _productionId, _status, gridLookUpEditProcessID.EditValue.ToString(), _dateCheck);     
                        }
                    }
                    else
                    {
                        return;
                    }
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            if (_mBDirty)
            {
                this.TopMost = true;
                int iHandle = NativeWin32.FindWindow(null, this.Text);
                NativeWin32.SetForegroundWindow(iHandle);

                lblPass.Text = _pass.ToString();
                lblNG.Text = _ng.ToString();
                lblTotal.Text = _total.ToString();
                LoadData(_productionId, _modelId, gridLookUpEditProcessID.EditValue.ToString(), _boardState);
                _mBDirty = false;
            }
        }

        private void txtPath_EditValueChanged(object sender, EventArgs e)
        {
            if (txtPath.Text.Contains(@":\"))
            {
                if (Directory.Exists(txtPath.Text))
                {
                    MessageHelpers.SetDefaultStatus(true, "N/A", "N/A", lblStatus, lblMessage);
                    CheckTextBoxNullValue.SetColorDefaultTextControl(txtPath);

                    if (checkPath.Checked == true)
                    {
                        Properties.Settings.Default["Folder"] = txtPath.Text;
                        Properties.Settings.Default.Save(); // Saves settings in application configuration file
                    }
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
            if (checkStationNo.Checked == true)
            {
                Properties.Settings.Default["StationNo"] = gridLookUpEditProcessID.EditValue.ToString();
                Properties.Settings.Default.Save(); // Saves settings in application configuration file
            }
        }

        private void txtBarcode_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(txtBarcode);
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
                string boardNo = txtBarcode.Text;
                _dateCheck = Ultils.GetNetworkDateTime().ToString("yyMMddHHmmss") != ""
                    ? Ultils.GetNetworkDateTime().ToString("yyMMddHHmmss")
                    : DateTime.Now.ToString("yyMMddHHmmss");

                _timeCheck = Ultils.GetNetworkDateTime().ToShortTimeString() != ""
                    ? Ultils.GetNetworkDateTime().ToShortTimeString()
                    : DateTime.Now.ToShortTimeString();

                if (boardNo.Contains("="))
                {
                    boardNo = boardNo.Replace("=", "_");
                }

                string setStationNo = gridLookUpEditProcessID.EditValue.ToString();

                if (txtBarcode.Text.Length <= 10)
                {
                    ActiveFormByWindowsTitle(cboWindows.EditValue.ToString());
                }
                else
                {
                    _scanningLogs = _scanningLogsService.Get_SCANNING_LOGS(boardNo).FirstOrDefault();

                    if (_scanningLogs != null)
                    {
                        _inspectionProcesses = _inspectionProcessesService.GET_INSPECTION_PROCESSES_BY_PRODUCT_ID(_scanningLogs.PRODUCT_ID);
                        if (_inspectionProcesses != null)
                        {
                            _inspectionProcedureDesigners = _inspectionProcessesDesignersService.GET_INSPECTION_PROCEDURE_DESIGNERS_BY_PROCESS_NO(_inspectionProcesses.PROCESS_NO);

                            //trạng thái bản mạch hiện tại
                            _workOrderItems = _workOrderItemService.Get_WORK_ORDER_ITEMS_By_BoardNo(boardNo);
                            if (_workOrderItems != null)
                            {
                                // nếu đã đã chạy qua các bước, với trạng thái là Finished
                                // thì thông báo cho người dùng biết
                                if (_workOrderItems.IS_FINISHED)
                                {
                                    //CancelAsyncBackgroundWorker();
                                    _messageError = $"Board '{boardNo}' is finished!";
                                    MessageHelpers.SetErrorStatus(true, "NG", _messageError, lblStatus, lblMessage);
                                    CheckTextBoxNullValue.SetColorErrorTextControl(txtBarcode);

                                    Reset(_messageError);
                                }
                                // Kiểm tra nếu trạng thái bản mạch hiện tại bị NG
                                // mà khác với với trạm được cài đặt "FCT" thì thông báo lỗi
                                else if (_workOrderItems.STATION_NO != setStationNo && _workOrderItems.BOARD_STATE == 2)
                                {
                                    //CancelAsyncBackgroundWorker();
                                    var stationName = _inspectionProcedureDesigners.FirstOrDefault(item => item.INDEX == _workOrderItems.PROCEDURE_INDEX);

                                    if (stationName != null)
                                        _messageError = $"Board '{boardNo}' bị 'NG' tại trạm trước {stationName.STATION_NO}!";

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

                                    // Set station no
                                    var processByStationNo = _inspectionProcedureDesigners.FirstOrDefault(item => item.STATION_NO == setStationNo);
                                    // Nếu trong process_Designer không có STATION_NO giống với 
                                    // station_no curent thì thông báo cho người dùng biết
                                    if (processByStationNo == null)
                                    {
                                        //CancelAsyncBackgroundWorker();
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
                                            //CancelAsyncBackgroundWorker();
                                            var stationName = _inspectionProcedureDesigners.FirstOrDefault(item => item.INDEX == _workOrderItems.PROCEDURE_INDEX);

                                            if (stationName != null)
                                                _messageError = $"Board '{boardNo}' bỏ qua công đoạn '{stationName.STATION_NO}'!";
                                            MessageHelpers.SetErrorStatus(true, "NG", _messageError, lblStatus, lblMessage);
                                            CheckTextBoxNullValue.SetColorErrorTextControl(txtBarcode);
                                            Reset(_messageError);
                                            //Excute(boardNo, _scanningLogs.PRODUCT_ID);
                                        }
                                        //// Nếu Index Board > Set Index 
                                        else if (_workOrderItems.PROCEDURE_INDEX > processByStationNo.INDEX)
                                        {
                                            //CancelAsyncBackgroundWorker();
                                            // transferred to the next station.
                                            var stationName = _inspectionProcedureDesigners.FirstOrDefault(item => item.INDEX == _workOrderItems.PROCEDURE_INDEX);

                                            if (stationName != null)
                                                _messageError = $"Board '{boardNo}' chuyển đến trạm '{stationName.STATION_NO}' để chạy tiếp!";
                                            MessageHelpers.SetErrorStatus(true, "NG", _messageError, lblStatus, lblMessage);
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
                                //CancelAsyncBackgroundWorker();
                                _messageError = $"Không tìm thấy trạm với tên {setStationNo}!";
                                MessageHelpers.SetErrorStatus(true, "NG", _messageError, lblStatus, lblMessage);
                                CheckTextBoxNullValue.SetColorErrorTextControl(txtBarcode);

                                Reset(_messageError);
                            }
                        }
                        else
                        {
                            //CancelAsyncBackgroundWorker();

                            _messageError = $"Station No '{setStationNo}' không hợp lệ!";
                            MessageHelpers.SetErrorStatus(true, "NG", _messageError, lblStatus, lblMessage);
                            CheckTextBoxNullValue.SetColorErrorTextControl(txtBarcode);

                            Reset(_messageError);
                        }
                    }
                    else
                    {
                        //CancelAsyncBackgroundWorker();
                        _messageError = $"Board '{boardNo}' chưa được khởi tạo. Vui lòng kiểm tra lại!";
                        MessageHelpers.SetErrorStatus(true, "NG", _messageError, lblStatus, lblMessage);
                        CheckTextBoxNullValue.SetColorErrorTextControl(txtBarcode);

                        Reset(_messageError);
                    }
                }
            }
        }

        /// <summary>
        /// Thực hiện lệnh gửi đi
        /// </summary>
        /// <param name="boardNo"></param>
        /// <param name="productId"></param>
        private void Excute(string boardNo, string productId)
        {
            //CancelAsyncBackgroundWorker();
            _barcodeOld = txtBarcode.Text;
            txtBarcode.ResetText();
            txtBarcode.Focus();
            _productionId = boardNo;
            _modelId = productId;
            _result = "";

            MessageHelpers.SetSuccessStatus(true, "OK", $"Board '{boardNo}' OK!", lblStatus, lblMessage);

            if (checkEditSerialPort.Checked)
            {
                // Start machine FCT Check
                Thread.Sleep(200);
                com.WriteData("S");
            }

            ActiveFormByWindowsTitle(cboWindows.EditValue.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        private void Reset(string message)
        {
            var errorForm = new FormError(message);
            errorForm.ShowDialog();
            // Active Form
            ActiveFormByWindowsTitle(cboWindows.EditValue.ToString());
            SendKeys.Send("^{A}");
            SendKeys.SendWait("{BS}");
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

        private void cboWindows_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cboWindows.EditValue.ToString()))
            {
                if (checkKeepProcess.Checked == true)
                {
                    Properties.Settings.Default["CurentProcess"] = cboWindows.EditValue.ToString();
                    Properties.Settings.Default.Save(); // Saves settings in application configuration file
                }
            }
            else
            {
                return;
            } 
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
            if (e.Button.Index == 1)
            {
                RefreshWindows();
            }
        }

        private void gridLookUpEditSerialPort_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(gridLookUpEditSerialPort.EditValue.ToString()))
            {
                if (checkEditSerialPort.Checked == true)
                {
                    Properties.Settings.Default["SerialPort"] = gridLookUpEditSerialPort.EditValue.ToString();
                    Properties.Settings.Default.Save(); // Saves settings in application configuration file
                }
            }
            else
            {
                return;
            }
        }
    }
}
