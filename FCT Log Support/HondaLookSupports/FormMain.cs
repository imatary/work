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
using CsvHelper;
using System.Globalization;
using System.Text;

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
                catch (Exception ex)
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

            _path = FilePath();
            GetModels();

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
                    _mWatcher.Filter = "*.csv";
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

                _mWatcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.Size | NotifyFilters.CreationTime;
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
                // đường dẫn đến file LOG
                _path = FilePath();

                if (e.ChangeType == WatcherChangeTypes.Created || e.ChangeType == WatcherChangeTypes.Changed)
                {
                    _productionId = txtBarcode.Text;
                    _modelId = gridLookUpEditModel.EditValue.ToString();
                    _sationNo = ConfigurationManager.AppSettings["StationNo"];

                    // Working
                    _boardState = StateWorking(_path);

                    _dateCheck = DateTime.Now.ToString("yyMMddHHmmss");

                    if (_boardState == "P")
                    {
                        _pass = _pass + 1;
                    }
                    if(_boardState=="F")
                    {
                        _ng = _ng + 1;
                    }
                    _total = _pass + _ng;

                    ActiveFormByWindowsTitle(Text);
                    txtBarcode.ResetText();
                    txtBarcode.Enabled = true;

                    _mBDirty = true;
                }
            }
        }

        private void hyperlinkConfigs_Click(object sender, EventArgs e)
        {
            var configs = new FormConfigs();
            configs.ShowDialog();

            //_processName = ConfigurationManager.AppSettings["ProcessName"];
            //MessageBox.Show(_processName);

            //Ultils.WriteFile(GetValueWindowText.GetAllTextFromWindowByTitle(_processName));
            //MessageBox.Show("Write file OK");

            _path = ConfigurationManager.AppSettings["PathInput"];
            _processName = ConfigurationManager.AppSettings["ProcessName"];
            
        }

        private void gridLookUpEditModel_EditValueChanged(object sender, EventArgs e)
        {
            txtBarcode.ResetText();
            txtBarcode.Focus();
        }

        private void gridLookUpEditModel_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                var addModel = new FormAddModel();
                addModel.ShowDialog();

                GetModels();
            }
        }

        private void txtBarcode_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBarcode.Text))
            {
                txtBarcode.Properties.Buttons[1].Visible = true;
                SetStatusDefault("N/A");
                SetMessageDefault("no results");
                CheckTextBoxNullValue.SetColorDefaultTextControl(txtBarcode);
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
                _path = FilePath();

                if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtBarcode))
                {
                    CheckTextBoxNullValue.SetBackColorErrorMessage(lblMessage, "Vui lòng bắn vào barcode cần kiểm tra!");
                    CheckTextBoxNullValue.SetColorErrorMessage(lblState, "NG");
                    CheckTextBoxNullValue.SetColorErrorTextControl(txtBarcode);
                }
                else
                {
                    _processName= ConfigurationManager.AppSettings["ProcessName"];
                    _sationNo = ConfigurationManager.AppSettings["StationNo"];
                    int barcodeLength = Convert.ToInt32(ConfigurationManager.AppSettings["BarcodeLength"]);

                    
                    string boardNo = txtBarcode.Text;
                    if(boardNo.Length < barcodeLength)
                    {
                        CheckTextBoxNullValue.SetBackColorErrorMessage(lblMessage, "Barcode không đúng định dạng!");
                        CheckTextBoxNullValue.SetColorErrorMessage(lblState, "NG");
                        CheckTextBoxNullValue.SetColorErrorTextControl(txtBarcode);
                        
                    }
                    else
                    {
                        //MessageBox.Show(_processName);
                        if (boardNo.Contains("="))
                        {
                            boardNo = boardNo.Replace("=", "_");
                        }

                        //MessageBox.Show(_path);

                        txtBarcode.Enabled = false;
                        ActiveFormByWindowsTitle(_processName);
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
                // Create Log
                Ultils.CreateFileLog(_modelId, _productionId, _boardState, _sationNo, _dateCheck);

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
        /// <returns></returns>
        private string FilePath()
        {
            string fileLogName = $"\\LOG_{DateTime.Now.ToString("yyyyMMdd")}.csv";

            return ConfigurationManager.AppSettings["PathInput"] + fileLogName; 
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private string StateWorking(string path)
        {
            //path = @"C:\Users\cuong\Desktop\Record\LOG_20170211.csv";
            string status = "";
            using (var stream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (var reader = new StreamReader(stream))
            using (var csv = new CsvReader(reader))
            {
                ConfigureCsvReader(csv);
                var myClassMap = new MyClassMap();
                csv.Configuration.RegisterClassMap(myClassMap);

                var testProg = csv.GetRecords<MyClass>().Last(i => i.ColA == "TestProg");
                if (testProg.ColE == "Pass")
                {
                    var subProg = csv.GetRecords<MyClass>().Last(i => i.ColA == "SubProg" && i.ColC == "Cmd");
                    if (subProg.ColF == "Pass")
                    {
                        status = "P";
                    }
                    else if (testProg.ColE == "Fail")
                    {
                        status = "F";
                    }
                }
                else if (testProg.ColE == "Fail")
                {
                    status = "F";
                }
            }

            return status;
        }

        /// <summary>
        /// Cấu hình CSV Helper
        /// </summary>
        /// <param name="csvReader"></param>
        internal static void ConfigureCsvReader(CsvReader csvReader)
        {
            csvReader.Configuration.AllowComments = false;
            csvReader.Configuration.CountBytes = false;
            csvReader.Configuration.CultureInfo = CultureInfo.CurrentCulture;
            csvReader.Configuration.Delimiter = ",";
            csvReader.Configuration.DetectColumnCountChanges = true;
            csvReader.Configuration.Encoding = Encoding.UTF8;
            csvReader.Configuration.HasExcelSeparator = false;
            csvReader.Configuration.HasHeaderRecord = true;
            csvReader.Configuration.IgnoreBlankLines = true;
            csvReader.Configuration.IgnoreHeaderWhiteSpace = false;
            csvReader.Configuration.IgnorePrivateAccessor = true;
            csvReader.Configuration.IgnoreQuotes = false;
            csvReader.Configuration.IgnoreReadingExceptions = false;
            csvReader.Configuration.IgnoreReferences = true;
            csvReader.Configuration.IsHeaderCaseSensitive = true;
            csvReader.Configuration.SkipEmptyRecords = false;
            csvReader.Configuration.ThrowOnBadData = true;
            csvReader.Configuration.TrimFields = false;
            csvReader.Configuration.TrimHeaders = false;
            csvReader.Configuration.WillThrowOnMissingField = true;
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

        /// <summary>
        /// 
        /// </summary>
        private void GetModels()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"\Data\HondaLookModel.csv";
            using (var stream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (var reader = new StreamReader(stream))
            using (var csv = new CsvReader(reader))
            {
                ConfigureCsvReader(csv);
                var myClassMap = new MyClassMap();
                csv.Configuration.RegisterClassMap(myClassMap);

                var models = csv.GetRecords<Model>().OrderBy(i => i.ModelCode);
                gridLookUpEditModel.Properties.DisplayMember = "ModelName";
                gridLookUpEditModel.Properties.ValueMember = "ModelCode";
                gridLookUpEditModel.Properties.DataSource = models.ToList();
            }
        }

    }
}
