using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Lib.Core;
using Lib.Core.Helpers;
using Lib.Data;
using Lib.Form.Controls;
using Lib.Services;

namespace HondaLookSupports
{
    public partial class FormMain : DevExpress.XtraEditors.XtraForm
    {
        private bool _mBDirty;
        private bool rdbDir = true;
        private bool subFolder = true;
        private FileSystemWatcher _mWatcher;
        private string _productionId, _modelId, _status, _boardState;
        private int _pass, _ng, _total;
        private string _messageError, _dateCheck, _dateCheck2, _timeCheck, _barcodeOld = "", _strTimeRun = "0";

        private string _processName = "", _sationNo = "", _path;
        //private WORK_ORDER_ITEMS _workOrderItems;
        //private SCANNING_LOGS _scanningLogs;
        //private readonly WORK_ORDER_ITEMS_Service _workOrderItemService;
        //private readonly SCANNING_LOGS_Service _scanningLogsService;
        private void FormMain_Load(object sender, EventArgs e)
        {
            _path = ConfigurationManager.AppSettings["PathInput"];
            _processName = ConfigurationManager.AppSettings["ProcessName"];
            if (checkStartWatching.Checked)
            {
                try
                {
                    _mWatcher = new FileSystemWatcher();
                    if (rdbDir)
                    {
                        _mWatcher.Filter = "*.txt";
                        _mWatcher.Path = _path + "\\";
                    }
                    else
                    {
                        _mWatcher.Filter = _path.Substring(_path.LastIndexOf('\\') + 1);
                        _mWatcher.Path = _path.Substring(0, _path.Length - _mWatcher.Filter.Length);
                    }
                    checkStartWatching.ForeColor = Color.DarkGreen;
                    checkStartWatching.Text = @"Stop Watching";
                    txtBarcode.Focus();
                    if (subFolder)
                    {
                        _mWatcher.IncludeSubdirectories = true;
                    }

                    _mWatcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                                             | NotifyFilters.FileName | NotifyFilters.DirectoryName;
                    _mWatcher.Created += new FileSystemEventHandler(OnChanged);
                    _mWatcher.Changed += new FileSystemEventHandler(OnChanged);
                    _mWatcher.EnableRaisingEvents = true;
                }
                catch (Exception)
                {
                    var configs = new FormConfigs();
                    configs.ShowDialog();
                    
                }
            }
        }

        public FormMain()
        {
            InitializeComponent();
            lblVersion.Text = StringHelper.GetRunningVersion();
            Ultils.RegisterInStartup(true, Application.ExecutablePath);

            //_workOrderItemService = new WORK_ORDER_ITEMS_Service();
            //_scanningLogsService = new SCANNING_LOGS_Service();
        }

        /// <summary>
        /// Start, Stop Watching
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkStartWatching_CheckedChanged(object sender, EventArgs e)
        {
            if (checkStartWatching.Checked)
            {
                _mWatcher = new FileSystemWatcher();
                if (rdbDir)
                {
                    _mWatcher.Filter = "*.txt";
                    _mWatcher.Path = _path + "\\";
                }
                else
                {
                    _mWatcher.Filter = _path.Substring(_path.LastIndexOf('\\') + 1);
                    _mWatcher.Path = _path.Substring(0, _path.Length - _mWatcher.Filter.Length);
                }
                checkStartWatching.ForeColor = Color.DarkGreen;
                checkStartWatching.Text = @"Stop Watching";
                txtBarcode.Focus();

                if (subFolder)
                {
                    _mWatcher.IncludeSubdirectories = true;
                }

                _mWatcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                                         | NotifyFilters.FileName | NotifyFilters.DirectoryName;
                _mWatcher.Created += new FileSystemEventHandler(OnChanged);
                _mWatcher.Changed += new FileSystemEventHandler(OnChanged);
                _mWatcher.EnableRaisingEvents = true;
            }
            else
            {
                _mWatcher.EnableRaisingEvents = false;
                _mWatcher.Dispose();
                checkStartWatching.ForeColor = Color.FromArgb(192, 64, 0);
                checkStartWatching.Text = @"Start Watching";
                txtBarcode.Focus();
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
                if (e.ChangeType == WatcherChangeTypes.Created || e.ChangeType == WatcherChangeTypes.Changed)
                {
                    ActiveFormByWindowsTitle(Text);
                    _mBDirty = true;
                }
            }
        }

        private void hyperlinkConfigs_Click(object sender, EventArgs e)
        {
            var configs = new FormConfigs();
            configs.ShowDialog();
            _processName = ConfigurationManager.AppSettings["ProcessName"];
            MessageBox.Show(_processName);

            Ultils.WriteFile(GetValueWindowText.GetAllTextFromWindowByTitle(_processName));
            MessageBox.Show("Write file OK");
        }

        private void txtBarcode_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBarcode.Text))
            {
                txtBarcode.Properties.Buttons[1].Visible = true;
                SetStatusDefault("N/A");
                SetMessageDefault("no results");

            }
            else
            {
                txtBarcode.Properties.Buttons[1].Visible = false;
            }
        }

        private void txtBarcode_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if(e.Button.Index == 1)
            {
                txtBarcode.ResetText();
                txtBarcode.Properties.Buttons[1].Visible = false;
            }
        }

        private void txtBarcode_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtBarcode))
                {
                    CheckTextBoxNullValue.SetBackColorErrorMessage(lblMessage, "Vui lòng bắn vào barcode cần kiểm tra!");
                    CheckTextBoxNullValue.SetColorErrorMessage(lblState, "NG");
                }
                else
                {
                    _processName= ConfigurationManager.AppSettings["ProcessName"];
                    _sationNo = ConfigurationManager.AppSettings["StationNo"];

                    string boardNo = txtBarcode.Text;
                    _dateCheck = Ultils.GetNetworkDateTime().ToString("yyMMddHHmmss") != ""
                        ? Ultils.GetNetworkDateTime().ToString("yyMMddHHmmss")
                        : DateTime.Now.ToString("yyMMddHHmmss");

                    _dateCheck2 = Ultils.GetNetworkDateTime().ToShortDateString() != ""
                        ? Ultils.GetNetworkDateTime().ToShortDateString()
                        : DateTime.Now.ToShortDateString();

                    _timeCheck = Ultils.GetNetworkDateTime().ToShortTimeString() != ""
                        ? Ultils.GetNetworkDateTime().ToShortTimeString()
                        : DateTime.Now.ToShortTimeString();

                    if (boardNo.Contains("="))
                    {
                        boardNo = boardNo.Replace("=", "_");
                    }

                    //_workOrderItems = _workOrderItemService.Get_WORK_ORDER_ITEMS_LIKE_BoardNo(boardNo);
                    //if (_workOrderItems != null)
                    //{
                    //    _productionId = _workOrderItems.BOARD_NO;
                    //    _scanningLogs = _scanningLogsService.Get_SCANNING_LOGS(_productionId).FirstOrDefault();
                    //    if (_scanningLogs != null)
                    //        _modelId = _scanningLogs.PRODUCT_ID;

                    //    ActiveFormByWindowsTitle(_processName);
                    //}
                    //else
                    //{
                    //    CheckTextBoxNullValue.SetBackColorErrorMessage(lblMessage, "Barcode chưa được khởi tạo!");
                    //    CheckTextBoxNullValue.SetColorErrorMessage(lblState, "NG");
                    //}
                }
            }
        }

        private void tmrEditNotify_Tick(object sender, EventArgs e)
        {
            if (_mBDirty)
            {
                ActiveFormByWindowsTitle(Text);

                lblPASS.Text = _pass.ToString();
                lblNG.Text = _ng.ToString();
                lblTotal.Text = _total.ToString();
                LoadData(_productionId, _modelId, _sationNo, _boardState);
                _mBDirty = false;
            }
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
            lblState.Appearance.ForeColor = Color.FromArgb(64, 64, 64);
            lblState.Appearance.BackColor = Color.White;
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
            lblMessage.Appearance.ForeColor = Color.White;
            lblMessage.Appearance.BackColor = Color.Gray;
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
                DATE_CHECK = _dateCheck2,
                TIME_CHECK = _timeCheck,
                STATE = state,
            };
            List<ItemDetail> items = new List<ItemDetail> { item };

            gridControl1.DataSource = items.OrderByDescending(it => it.TIME_CHECK);
        }
    }
}
