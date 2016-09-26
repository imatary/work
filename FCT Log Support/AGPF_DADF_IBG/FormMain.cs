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

namespace AGPF_DADF_IBG
{
    public partial class FormMain : Form
    {
        private StringBuilder m_Sb;
        private bool m_bDirty;
        private FileSystemWatcher m_Watcher;
        private bool m_bIsWatching;
        private string modelId = null;
        private string productionId = null;
        private string _status = null;
        private string boardState = null;
        private int pass = 0;
        private int ng = 0;
        private int total = 0;
        private string messageError = null;
        string backup_log_folder = @"C:\backup_log\";

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
                DATE_CHECK = DateTime.Now.ToShortDateString(),
                TIME_CHECK = DateTime.Now.ToShortTimeString(),
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
                        cboWindows.Visible = true;
                        checkKeepProcess.Visible = true;
                        return true;
                    }
                case Keys.Shift | Keys.F3:
                    {
                        cboWindows.Visible = false;
                        checkKeepProcess.Visible = false;
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
                }
                else
                {
                    m_bIsWatching = true;
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
                        m_Watcher.Filter = "*.csv";
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

                        var data = Ultils.ReadCsv(e.FullPath).Skip(1); // skip 1 headerlines

                        string[] _array = data.LastOrDefault();
                        if (string.IsNullOrEmpty(_array[3]))
                        {
                            return;
                        }
                        if (string.IsNullOrEmpty(_array[5]))
                        {
                            return;
                        }

                        if (_array[3] == "OK")
                        {
                            _status = "P";
                            boardState = "OK";
                            pass = pass + 1;
                            
                        }
                        if (_array[3] == "NG")
                        {
                            _status = "F";
                            boardState = "FAILD";
                            ng = ng + 1;
                        }
                        total = pass + ng;

                        Ultils.CreateFileLog(modelId, productionId, _status, gridLookUpEditProcessID.EditValue.ToString());

                    }
                    else
                    {
                        Thread.Sleep(1000);
                        File.Copy(e.FullPath, fullPath);
                        var data = Ultils.ReadCsv(e.FullPath).Skip(1); // skip 1 headerlines

                        string[] _array = data.LastOrDefault();
                        if (string.IsNullOrEmpty(_array[3]))
                        {
                            return;
                        }
                        if (string.IsNullOrEmpty(_array[5]))
                        {
                            return;
                        }

                        if (_array[3] == "OK")
                        {
                            _status = "P";
                            boardState = "OK";
                            pass = pass + 1;

                        }
                        if (_array[3] == "NG")
                        {
                            _status = "F";
                            boardState = "FAILD";
                            ng = ng + 1;
                        }
                        string stationNo = gridLookUpEditProcessID.EditValue.ToString();
                        total = pass + ng;
                        Ultils.CreateFileLog(modelId, productionId, _status, stationNo);                       
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
                this.TopMost = true;
                int iHandle = NativeWin32.FindWindow(null, "AGPF DADF IBG - Log for MES System");
                NativeWin32.SetForegroundWindow(iHandle);

                lblPass.Text = pass.ToString();
                lblNG.Text = ng.ToString();
                lblTotal.Text = total.ToString();
                LoadData(productionId, modelId, gridLookUpEditProcessID.EditValue.ToString(), boardState);
                m_bDirty = false;
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

        private void txtBarcode_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string boardNo = txtBarcode.Text;
                string set_station_no = gridLookUpEditProcessID.EditValue.ToString();

                if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtBarcode))
                {
                    MessageHelpers.SetErrorStatus(true, "NG", "Please input a barcode!", lblStatus, lblMessage);
                    return;
                }
                else if (txtBarcode.Text.Length <= 5)
                {
                    MessageHelpers.SetErrorStatus(true, "NG", "Board No invaild. Please try again!", lblStatus, lblMessage);
                    CheckTextBoxNullValue.SetColorErrorTextControl(txtBarcode);
                    return;
                }
                else
                {
                    MessageHelpers.SetDefaultStatus(true, "N/A", "N/A", lblStatus, lblMessage);
                    CheckTextBoxNullValue.SetColorDefaultTextControl(txtBarcode);

                    var boards = _scanningLogsService.Get_SCANNING_LOGS(boardNo).FirstOrDefault();

                    // nếu board đã được bắn vào trước đó
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
                                    // Thông tin lỗi
                                    messageError = $"Board '{boardNo}' is finished!";
                                    MessageHelpers.SetErrorStatus(true, "NG", messageError, lblStatus, lblMessage);
                                    CheckTextBoxNullValue.SetColorErrorTextControl(txtBarcode);
                                    var errorForm = new FormError(messageError);
                                    errorForm.ShowDialog();
                                    txtBarcode.Focus();
                                    return;
                                }
                                // Nếu tên giống nhau, thì thông báo đã chạy qua công đoạn này rồi
                                else if (curentStationNo.STATION_NO == set_station_no && curentStationNo.BOARD_STATE == 1)
                                {
                                    MessageHelpers.SetErrorStatus(true, "NG", $"Board '{boardNo}' is pass '{set_station_no}'!", lblStatus, lblMessage);
                                    CheckTextBoxNullValue.SetColorErrorTextControl(txtBarcode);
                                    var errorForm = new FormError($"Board '{boardNo}' is pass '{set_station_no}'!");
                                    errorForm.ShowDialog();
                                    txtBarcode.Focus();
                                    return;
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
                                        // Thông tin lỗi
                                        messageError = $"Board '{boardNo}' station '{set_station_no}' not invaild!";

                                        MessageHelpers.SetErrorStatus(true, "NG", messageError, lblStatus, lblMessage);
                                        CheckTextBoxNullValue.SetColorErrorTextControl(txtBarcode);
                                        var errorForm = new FormError(messageError);
                                        errorForm.ShowDialog();
                                        txtBarcode.Focus();
                                        return;
                                    }
                                    // nếu hợp lệ thực hiện tiếp
                                    else
                                    {
                                        // Khi hai giá trị bằng nhau => ICT_FUJ
                                        if (curentStationNo.PROCEDURE_INDEX < (process_by_station_no.INDEX - 1))
                                        {
                                            // Lấy tên trạm bị bỏ qua
                                            string station_skip = process_Designer.FirstOrDefault(item => item.INDEX == (process_by_station_no.INDEX - 1)).STATION_NO;

                                            // Thông tin lỗi
                                            messageError = $"Board '{boardNo}' skip station '{station_skip}'!";

                                            // Hiển thị thông báo cho người dùng
                                            MessageHelpers.SetErrorStatus(true, "NG", messageError, lblStatus, lblMessage);
                                            CheckTextBoxNullValue.SetColorErrorTextControl(txtBarcode);
                                            var errorForm = new FormError(messageError);
                                            errorForm.ShowDialog();
                                            txtBarcode.Focus();
                                            return;
                                        }
                                        //// Nếu Index Board > Set Index 
                                        else if (curentStationNo.PROCEDURE_INDEX > process_by_station_no.INDEX)
                                        {
                                            // Lấy tên trạm tiếp theo mà broad cần chạy qua.
                                            string station_skip = process_Designer.FirstOrDefault(item => item.INDEX == (curentStationNo.PROCEDURE_INDEX + 1)).STATION_NO;

                                            // Thông tin lỗi
                                            messageError = $"Board '{boardNo}' transferred to the next station '{station_skip}'!";

                                            // transferred to the next station.
                                            MessageHelpers.SetErrorStatus(true, "NG", messageError, lblStatus, lblMessage);
                                            CheckTextBoxNullValue.SetColorErrorTextControl(txtBarcode);
                                            var errorForm = new FormError(messageError);
                                            errorForm.ShowDialog();
                                            txtBarcode.Focus();
                                            return;
                                        }

                                        // Nếu trạm hiện tại mà giống với trạm cài đặt thì gửi dữ liệu đi
                                        else if (curentStationNo.PROCEDURE_INDEX == (process_by_station_no.INDEX - 1))
                                        {
                                            this.TopMost = false;
                                            txtBarcode.ResetText();
                                            txtBarcode.Focus();
                                            productionId = boardNo;
                                            modelId = boards.PRODUCT_ID;
                                            MessageHelpers.SetSuccessStatus(true, "OK", $"Board '{boardNo}' OK!", lblStatus, lblMessage);
                                            // Thực hiện gửi dữ liệu đi
                                            int iHandle = NativeWin32.FindWindow(null, cboWindows.EditValue.ToString());
                                            NativeWin32.SetForegroundWindow(iHandle);
                                            SendKeys.Send(boardNo);
                                            SendKeys.Send("{ENTER}");
                                        }
                                        // Nếu board này đã chạy rồi, với trạng thái là FAILD thì thực hiện chạy lại.
                                        else if (curentStationNo.BOARD_STATE == 2)
                                        {
                                            this.TopMost = false;
                                            txtBarcode.ResetText();
                                            txtBarcode.Focus();
                                            productionId = boardNo;
                                            modelId = boards.PRODUCT_ID;
                                            MessageHelpers.SetSuccessStatus(true, "OK", $"Board '{boardNo}' OK!", lblStatus, lblMessage);
                                            // Thực hiện gửi dữ liệu đi
                                            int iHandle = NativeWin32.FindWindow(null, cboWindows.EditValue.ToString());
                                            NativeWin32.SetForegroundWindow(iHandle);
                                            SendKeys.Send(boardNo);
                                            SendKeys.Send("{ENTER}");
                                        }
                                        else
                                        {
                                            // Thông tin lỗi
                                            messageError = $"Broad '{boardNo} lỗi không rõ nguyên nhân. Vui lòng liên hệ với bộ phần 'PE-IT' để được hỗ trợ!'";

                                            MessageHelpers.SetErrorStatus(true, "NG", messageError, lblStatus, lblMessage);
                                            CheckTextBoxNullValue.SetColorErrorTextControl(txtBarcode);
                                            var errorForm = new FormError(messageError);
                                            errorForm.ShowDialog();
                                            txtBarcode.Focus();
                                            return;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                // Thông tin lỗi
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
                            // Thông tin lỗi
                            messageError = $"Station No '{set_station_no}' invaild!";

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
                        // Thông tin lỗi
                        messageError = $"Board '{boardNo}' not initialized!";

                        MessageHelpers.SetErrorStatus(true, "NG", messageError, lblStatus, lblMessage);
                        CheckTextBoxNullValue.SetColorErrorTextControl(txtBarcode);
                        var errorForm = new FormError(messageError);
                        errorForm.ShowDialog();
                        return;
                    }

                }
            }
        }

        private void cboWindows_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cboWindows.Text))
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
    }
}
