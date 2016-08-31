using Lib.Core.Helpers;
using Lib.Data;
using Lib.Forms.Controls;
using Lib.Services;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FCT_HFT1024_DB
{
    public partial class FormMain : Form
    {
        private StringBuilder m_Sb;
        private bool m_bDirty;
        private FileSystemWatcher m_Watcher;
        private bool m_bIsWatching;
        private string fileName = null;
        private string modelId = null;
        private string productionId = null;
        private string status = null;
        private int pass = 0;
        private int ng = 0;
        private int total = 0;

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
            RegisterInStartup(true);

            _inspectionStationsService = new INSPECTION_STATIONS_Service();
            _scanningLogsService = new SCANNING_LOGS_Service();
            _inspectionProcessesService = new INSPECTION_PROCESSES_Service();
            _inspectionProcessesDesignersService = new INSPECTION_PROCEDURE_DESIGNERS_Service();
            _workOrderItemService = new WORK_ORDER_ITEMS_Service();

            LoadDataGridLookUpEditINSPECTION_STATIONS();
        }

        private void LoadDataGridLookUpEditINSPECTION_STATIONS()
        {
            var items = _inspectionStationsService.Get_INSPECTION_STATIONS();

            gridLookUpEditProcessID.Properties.DisplayMember = "STATION_NO";
            gridLookUpEditProcessID.Properties.ValueMember = "STATION_NO";
            gridLookUpEditProcessID.Properties.PopupFormWidth = 300;
            gridLookUpEditProcessID.Properties.DataSource = items;
        }

        private void RegisterInStartup(bool isChecked)
        {
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (isChecked)
            {
                registryKey.SetValue("ApplicationName", Application.ExecutablePath);
            }
            else
            {
                registryKey.DeleteValue("ApplicationName");
            }
        }

        /// <summary>
        /// create log
        /// </summary>
        /// <param name="modelId"></param>
        /// <param name="productionId"></param>
        /// <param name="status"></param>
        /// <param name="process"></param>
        private static void CreateFileLog(string modelId, string productionId, string status, string process)
        {
            string dateTime = DateTime.Now.ToString("yyMMddHHmmss");
            string fileName = $"{dateTime}_{productionId}.txt";
            string folderRoot = @"C:\LOGPROCESS\";

            bool exists = Directory.Exists(folderRoot);
            if (!exists)
                Directory.CreateDirectory(folderRoot);

            string path = folderRoot + fileName;
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
                using (TextWriter tw = new StreamWriter(path))
                {
                    tw.WriteLine($"{modelId}|{productionId}|{dateTime}|{status}|{process}");
                    tw.Close();
                }
            }
            else if (File.Exists(path))
            {
                using (TextWriter tw = new StreamWriter(path))
                {
                    tw.WriteLine($"{modelId}|{productionId}|{dateTime}|{status}|{process}");
                    tw.Close();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="boardNo"></param>
        /// <param name="productId"></param>
        /// <param name="stationNo"></param>
        private void LoadData(string boardNo, string productId, string stationNo)
        {
            ItemDetail item = new ItemDetail()
            {
                BOARD_NO = boardNo,
                ProductID = productId,
                STATION_NO = stationNo,
                DATE_CHECK = DateTime.Now.Day.ToString(),
                TIME_CHECK = DateTime.Now.TimeOfDay.ToString()
            };
            List<ItemDetail> items = new List<ItemDetail>();
            items.Add(item);

            gridControl1.Refresh();
            gridControl1.DataSource = items;
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
        private void btnWatchFile_Click(object sender, EventArgs e)
        {
            bool isVaild = true;
            if (!CheckTextBoxNullValue.ValidationTextEditNullValue(gridLookUpEditProcessID))
            {
                dxErrorProvider1.SetError(gridLookUpEditProcessID, null);
                SetErrorStatus(true, "NG", "Please select a 'Station No'!");
                isVaild = false;
            }
            else if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtPath))
            {
                dxErrorProvider1.SetError(txtPath, null);
                SetErrorStatus(true, "NG", "Please select a 'File/Directory'!");
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
                string[] strSpit;
                fileName = Path.GetFileNameWithoutExtension(e.FullPath);
                if (fileName.Contains("ERROR"))
                {
                    return;
                }
                else if (fileName.Length <= 32)
                {
                    return;
                }
                else
                {
                    if (fileName.Contains("="))
                    {
                        fileName = fileName.Replace("=", "_");
                        strSpit = fileName.Split('_');
                    }
                    else
                    {
                        strSpit = fileName.Split('_');
                    }

                    string strStatus = strSpit[3];

                    if (strStatus == "PASS")
                    {
                        status = "P";
                        lblPass.Text = (pass = pass + 1).ToString();
                    }
                    else if (strStatus == "FAIL")
                    {
                        status = "F";
                        lblNG.Text = (ng = ng + 1).ToString();
                    }
                    string stationNo = gridLookUpEditProcessID.EditValue.ToString();
                    CreateFileLog(modelId, $"{productionId}_{modelId}", status, stationNo);
                    LoadData(productionId, modelId, stationNo);

                    lblTotal.Text = (total = pass + ng).ToString();
                    
                    this.TopMost = true;
                    txtBarcode.Focus();
                }
                //MessageBox.Show("Test");
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
                //ListViewItem listItems = new ListViewItem((count++).ToString());
                //listView1.BeginUpdate();
                //listItems.SubItems.Add($"{productionId}_{modelId}");
                //listItems.SubItems.Add(modelId);
                //listItems.SubItems.Add(DateTime.Now.ToLongDateString());
                //listItems.SubItems.Add(DateTime.Now.ToLongTimeString());
                //listItems.SubItems.Add(status);

                //listView1.Items.Add(listItems);
                //listView1.EndUpdate();
                m_bDirty = false;
            }
        }

        private void SetDefaultStatus(bool visible, string status, string messageInfo)
        {
            lblStatus.Visible = visible;
            lblMessage.Visible = visible;

            lblStatus.Appearance.ForeColor = Color.DarkOrange;
            lblStatus.Appearance.BackColor = Color.DarkGray;

            lblMessage.Appearance.ForeColor = Color.DarkOrange;
            lblMessage.Appearance.BackColor = Color.DarkGray;

            lblStatus.Text = status;
            lblMessage.Text = messageInfo;
        }

        private void SetErrorStatus(bool visible, string status, string messageInfo)
        {
            lblStatus.Visible = visible;
            lblMessage.Visible = visible;

            lblStatus.Appearance.ForeColor = Color.Yellow;
            lblStatus.Appearance.BackColor = Color.DarkRed;

            lblMessage.Appearance.ForeColor = Color.White;
            lblMessage.Appearance.BackColor = Color.DarkRed;

            lblStatus.Text = status;
            lblMessage.Text = messageInfo;
        }
        /// <summary>
        /// Success
        /// </summary>
        /// <param name="visible"></param>
        /// <param name="status"></param>
        /// <param name="messageInfo"></param>
        private void SetSuccessStatus(bool visible, string status, string messageInfo)
        {
            lblStatus.Visible = visible;
            lblMessage.Visible = visible;

            lblStatus.Appearance.ForeColor = Color.Yellow;
            lblStatus.Appearance.BackColor = Color.DarkGreen;

            lblMessage.Appearance.ForeColor = Color.DarkOrange;
            lblMessage.Appearance.BackColor = Color.DarkGreen;

            lblStatus.Text = status;
            lblMessage.Text = messageInfo;
        }

        private void txtPath_EditValueChanged(object sender, EventArgs e)
        {
            if (txtPath.Text.Contains(@":\"))
            {
                if (Directory.Exists(txtPath.Text))
                {
                    SetDefaultStatus(true, "N/A", "N/A");
                    CheckTextBoxNullValue.SetColorDefaultTextControl(txtPath);
                }
                else
                {
                    SetErrorStatus(true, "NG", "'File/Directory' not exits. Please try again!");
                    CheckTextBoxNullValue.SetColorErrorTextControl(txtPath);
                }
            }
            else
            {
                SetErrorStatus(true, "NG", "'File/Directory' invaild. Please try again!");
                CheckTextBoxNullValue.SetColorErrorTextControl(txtPath);
            }
        }

        private void gridLookUpEditProcessID_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1 ,gridLookUpEditProcessID);
        }

        private void txtBarcode_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1, txtBarcode);
        }

        private void txtBarcode_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode==Keys.Enter || e.KeyCode == Keys.Tab)
            {
                string boardNo = txtBarcode.Text;
                string set_station_no = gridLookUpEditProcessID.EditValue.ToString();

                if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtBarcode))
                {
                    dxErrorProvider1.SetError(gridLookUpEditProcessID, null);
                    SetErrorStatus(true, "NG", "Please input a barcode!");
                }
                else if (boardNo.Length <= 5)
                {
                    SetErrorStatus(true, "NG", "'Board No' invaild. Please try again!");
                    CheckTextBoxNullValue.SetColorErrorTextControl(txtBarcode);
                    txtBarcode.SelectAll();
                }
                else
                {
                    SetDefaultStatus(true, "N/A", "N/A");
                    CheckTextBoxNullValue.SetColorDefaultTextControl(txtBarcode);

                    var boards = _scanningLogsService.Get_SCANNING_LOGS(boardNo);
                    if (boards.Any())
                    {
                        var board = boards.FirstOrDefault();
                        var process_No = _inspectionProcessesService.GET_INSPECTION_PROCESSES_BY_PRODUCT_ID(board.PRODUCT_ID);
                        if (process_No != null)
                        {
                            //trạng thái bản mạch hiện tại
                            var curentStationNo = _workOrderItemService.Get_WORK_ORDER_ITEMS_By_BoardNo(boardNo);

                            // nếu đã đã chạy qua các bước, với trạng thái là Finished
                            // thì thông báo cho người dùng biết
                            if (curentStationNo.IS_FINISHED == true)
                            {
                                SetErrorStatus(true, "NG", $"Board '{boardNo}' is finished!");
                                CheckTextBoxNullValue.SetColorErrorTextControl(txtBarcode);
                                txtBarcode.SelectAll();
                                return;
                            }
                            // Nếu tên giống nhau, thì thông báo đã chạy qua công đoạn này rồi
                            else if(curentStationNo.STATION_NO == set_station_no)
                            {
                                SetErrorStatus(true, "NG", $"Board '{boardNo}' is pass '{set_station_no}'!");
                                CheckTextBoxNullValue.SetColorErrorTextControl(txtBarcode);
                                txtBarcode.SelectAll();
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
                                    SetErrorStatus(true, "NG", $"Board '{boardNo}' station '{set_station_no}' not invaild!");
                                    CheckTextBoxNullValue.SetColorErrorTextControl(txtBarcode);
                                    txtBarcode.SelectAll();
                                    return;
                                }
                                // nếu hợp lệ thực hiện tiếp
                                else 
                                {
                                    // Khi hai giá trị bằng nhau => ICT_FUJ
                                    if(curentStationNo.PROCEDURE_INDEX < (process_by_station_no.INDEX - 1))
                                    {
                                        SetErrorStatus(true, "NG", $"Board '{boardNo}' skip stations!");
                                        CheckTextBoxNullValue.SetColorErrorTextControl(txtBarcode);
                                        txtBarcode.SelectAll();
                                        return;
                                    }
                                    // Nếu Index Board > Set Index 
                                    else if(curentStationNo.PROCEDURE_INDEX > process_by_station_no.INDEX)
                                    {
                                        // transferred to the next station.
                                        SetErrorStatus(true, "NG", $"Board '{boardNo}' transferred to the next station!");
                                        CheckTextBoxNullValue.SetColorErrorTextControl(txtBarcode);
                                        txtBarcode.SelectAll();
                                        return;
                                    }
                                    else if (curentStationNo.PROCEDURE_INDEX == (process_by_station_no.INDEX - 1))
                                    {
                                        // Thực hiện gửi dữ liệu đi
                                        int iHandle = NativeWin32.FindWindow(null, "HFT1024_PE_251exe *32");
                                        NativeWin32.SetForegroundWindow(iHandle);
                                        SendKeys.Send(boardNo);
                                        //SendKeys.SendWait(textToSend);
                                        SendKeys.SendWait("{ENTER}");

                                        productionId = boardNo;
                                        modelId = board.PRODUCT_ID;


                                        this.TopMost = false;
                                        txtBarcode.ResetText();
                                        txtBarcode.Focus();
                                    }
                                }
                            }
                        }
                        else
                        {
                            SetErrorStatus(true, "NG", $"Station No '{set_station_no}' invaild!");
                            CheckTextBoxNullValue.SetColorErrorTextControl(txtBarcode);
                            txtBarcode.SelectAll();
                        }
                    }
                    else
                    {
                        SetErrorStatus(true, "NG", $"Board '{boardNo}' not initialized!");
                        CheckTextBoxNullValue.SetColorErrorTextControl(txtBarcode);
                        txtBarcode.SelectAll();
                    }
                }
            }     
        }
    }
}
