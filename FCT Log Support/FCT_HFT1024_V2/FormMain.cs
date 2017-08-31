using Lib.Core;
using Lib.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using UMC.Entities;
using UMC.Services;

namespace FCT_HFT1024_V2
{
    public partial class FormMain : Form
    {
        string stationNo = "", fileExtension = "", inputLog = "", outputLog = "";
        string fileLastWriteTime = "", dateCheck = "", boardNo = "", productId = "", boardState = "";
        string processName = "", comRead = "", message = "";
        string rootKey = "FCT Settings";
        bool startWatching = false, RunTaks = false, checkLength = false, skipWaitLogs = false, allowWrite = false;
        int pass = 0, ng = 0, total = 0, barcodeLength = 0;
        FileSystemWatcher fileWatcher;

        private SCANNING_LOGS_Service scanningLogService;
        private WORK_ORDER_ITEMS_Service workOrderItemsService;
        public FormMain()
        {
            InitializeComponent();
            BinDataToControls();
            Ultils.RegisterInStartup(true, Application.ExecutablePath);
            lblVersion.Text = StringHelper.GetRunningVersion();
            lblReset.Enabled = false;

            scanningLogService = new SCANNING_LOGS_Service();
            workOrderItemsService = new WORK_ORDER_ITEMS_Service();
        }


        /// <summary>
        /// 
        /// </summary>
        private void BinDataToControls()
        {
            if (Ultils.GetValueRegistryKey(rootKey, "ComRead") != null)
            {
                comRead = Ultils.GetValueRegistryKey(rootKey, "ComRead").ToString();
            }
            if (Ultils.GetValueRegistryKey(rootKey, "BarcodeLength") != null)
            {
                barcodeLength = int.Parse(Ultils.GetValueRegistryKey(rootKey, "BarcodeLength"));
            }

            if (Ultils.GetValueRegistryKey(rootKey, "Process") != null)
            {
                processName = Ultils.GetValueRegistryKey(rootKey, "Process").ToString();
            }
            if (Ultils.GetValueRegistryKey(rootKey, "StationNO") != null)
            {
                stationNo = Ultils.GetValueRegistryKey(rootKey, "StationNO").ToString();
            }
            if (Ultils.GetValueRegistryKey(rootKey, "FileExtension") != null)
            {
                fileExtension = Ultils.GetValueRegistryKey(rootKey, "FileExtension").ToString();
            }
            if (Ultils.GetValueRegistryKey(rootKey, "InputLog") != null)
            {
                inputLog = Ultils.GetValueRegistryKey(rootKey, "InputLog").ToString();
            }
            if (Ultils.GetValueRegistryKey(rootKey, "OutputLog") != null)
            {
                outputLog = Ultils.GetValueRegistryKey(rootKey, "OutputLog").ToString();
            }
            if (Ultils.GetValueRegistryKey(rootKey, "SkipWaitLogs") != null)
            {
                skipWaitLogs = bool.Parse(Ultils.GetValueRegistryKey(rootKey, "SkipWaitLogs"));
            }
            if (Ultils.GetValueRegistryKey(rootKey, "AllowsWrite") != null)
            {
                allowWrite = bool.Parse(Ultils.GetValueRegistryKey(rootKey, "AllowsWrite"));
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            dataGridView1.AutoGenerateColumns = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private string GetStateBoardOne(string path)
        {
            string state = "";
            string content = null;
            string value = "";
            if (fileExtension == "*.LOG")
            {
                content = Ultils.GetValueInLine(path, 2);
                string[] array = content.Split(',');
                value = array[1];
                value = Regex.Replace(value, "[^A-Za-z0-9]", "");

                if (value == "GO")
                {
                    state = "P";
                }
                if (value == "NG")
                {
                    state = "F";
                }
            }
            if (fileExtension == "*.DAT")
            {
                content = Ultils.GetValueInLine(path, 1);
                string[] array = content.Split(',');
                value = array[9];
                if (value == "CP=OK")
                {
                    state = "P";
                }
                if (value == "CP=NG")
                {
                    state = "F";
                }
            }
            return state;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        //private string ModelName(string path)
        //{
        //    string value = "";
        //    string content = null;
        //    if(fileExtension == "*.LOG")
        //    {
        //        content = Ultils.GetValueInLine(path, 2);
        //        string[] array = content.Split(',');
        //        value = array[0];
        //        value = Regex.Replace(value, "[^A-Za-z0-9]", "");
        //    }
        //    if(fileExtension == "*.DAT")
        //    {
        //        content = Ultils.GetValueInLine(path, 1);
        //        string[] array = content.Split(',');
        //        value = array[1];
        //        value = Regex.Replace(value, "[^A-Za-z0-9]", "");
        //    }
            
        //    if (value != "")
        //    {
        //        if (value.Contains("-"))
        //        {
        //            value = value.Replace("-", "").Replace(" ", "");
        //        }
        //        return value;
        //    }
        //    return null;
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnFileChanged(object sender, FileSystemEventArgs e)
        {
            if (!RunTaks)
            {
                if (e.ChangeType == WatcherChangeTypes.Created || e.ChangeType == WatcherChangeTypes.Changed)
                {
                    fileLastWriteTime = e.FullPath;
                    RunTaks = true;
                }
            }
        }

        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBarcode.Text))
            {
                DefaultMessage();
            }
        }
        private void lblConfigs_Click(object sender, EventArgs e)
        {
            new FormConfig().ShowDialog();
            BinDataToControls();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            string data = string.Empty;
            int indexOfYourColumn = 4;

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                data = row.Cells[indexOfYourColumn].Value.ToString();
                if (data == "F")
                {
                    row.DefaultCellStyle.BackColor = Color.Red;
                    row.DefaultCellStyle.ForeColor = Color.White;
                    row.Selected = true;
                }
                if(data== "P")
                {
                    row.DefaultCellStyle.BackColor = Color.Green;
                    row.DefaultCellStyle.ForeColor = Color.White;
                }
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (MessageBox.Show("Are you want exit?",
                       "Message",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (checkLength == true)
            {
                ActiveWindows(this.Text);
                txtBarcode.Enabled = true;
                txtBarcode.ResetText();
                txtBarcode.Focus();
                checkLength = false;
            }
            else
            {
                if (RunTaks)
                {
                    boardState = GetStateBoardOne(fileLastWriteTime);
                    List<Result> items = new List<Result>();

                    var item = new Result()
                    {
                        BoardNo = boardNo,
                        ProductId = productId,
                        Date = DateTime.Now.ToShortDateString(),
                        Time = DateTime.Now.ToShortTimeString(),
                        State = boardState,
                    };
                    items.Add(item);

                    string strOK = "", strNG = "";
                    foreach (var itemW in items)
                    {
                        Ultils.CreateFileLog(itemW.ProductId, itemW.BoardNo, itemW.State, stationNo, dateCheck);
                        if (itemW.State == "P")
                        {
                            pass = pass + 1;
                            strOK += $"Board [{itemW.BoardNo}] OK! \n";

                            txtBarcode.Enabled = true;
                            txtBarcode.ResetText();

                            txtBarcode.Focus();
                        }
                        if (itemW.State == "F")
                        {
                            ng = ng + 1;
                            strNG += $"Board [{itemW.BoardNo}] NG! \n";
                        }
                    }

                    if (strOK != "")
                        SuccessMessage("OK", strOK);

                    if (strNG != "")
                        ErrorMessage("NG", strNG);

                    dataGridView1.DataSource = items;

                    lblReset.Enabled = true;
                    total = pass + ng;
                    lblPASS.Text = pass.ToString();
                    lblNG.Text = ng.ToString();
                    lblTOTAL.Text = total.ToString();

                    // TopMode this form
                    ActiveWindows(Text);
                    RunTaks = false;
                }
            }
        }

        private void lblReset_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            boardNo = "";
            txtBarcode.Enabled = true;
            txtBarcode.ResetText();
            txtBarcode.Focus();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (comRead == "")
            {
                MessageBox.Show("Vui lòng chọn một cổng COM!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblConfigs_Click(sender, e);
                return;
            }
            if(barcodeLength <= 0)
            {
                MessageBox.Show("Vui lòng nhập vào độ dài của barcode!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblConfigs_Click(sender, e);
                return;
            }
            if (string.IsNullOrEmpty(processName))
            {
                MessageBox.Show("Vui lòng chọn Process!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblConfigs_Click(sender, e);
                return;
            }
            else
            {
                try
                {
                    btnStart.Enabled=false;
                    lblConfigs.Enabled = false;
                    lblRefesh.Enabled = false;
                    lblReset.Enabled = true;
                    panelBarcode.Visible = true;

                    if (startWatching == false)
                    {
                        startWatching = true;
                        // Config file watching
                        fileWatcher = new FileSystemWatcher();
                        fileWatcher.IncludeSubdirectories = true;
                        if (fileExtension.Contains("*"))
                        {
                            fileWatcher.Filter = fileExtension;
                        }
                        else
                        {
                            fileWatcher.Filter = "*" + fileExtension;
                        }

                        fileWatcher.Path = inputLog + "\\";

                        fileWatcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.CreationTime
                                             | NotifyFilters.FileName | NotifyFilters.DirectoryName;
                        fileWatcher.Created += new FileSystemEventHandler(OnFileChanged);
                        fileWatcher.Changed += new FileSystemEventHandler(OnFileChanged);
                        fileWatcher.EnableRaisingEvents = true;
                    }

                    txtBarcode.Focus();
                }
                catch (SocketException se)
                {
                    MessageBox.Show(se.Message);
                }
            }
        }
        private void btnStop_Click(object sender, EventArgs e)
        {

            if (startWatching == true)
            {
                startWatching = false;
                fileWatcher.EnableRaisingEvents = false;
                fileWatcher.Dispose();
            }
            btnStart.Enabled = true;
            DefaultMessage();
            panelBarcode.Visible = false;
            lblConfigs.Enabled = true;
            lblRefesh.Enabled = true;
            lblReset.Enabled = false;
            txtBarcode.Enabled = true;
            txtBarcode.ResetText();
        }

        private void txtBarcode_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // nếu = false thì làm việc như bình thường, test log
                if (skipWaitLogs == false)
                {
                    try
                    {
                        boardNo = txtBarcode.Text.Trim();
                        if (boardNo != null && boardNo.Length >= barcodeLength)
                        {
                            dateCheck = DateTime.Now.ToString("yyMMddHHmmss");
                            panelBarcode.Enabled = false;
                            lblReset.Enabled = true;
                            dataGridView1.DataSource = null;

                            var scanningLog = scanningLogService.GetSingle(boardNo);
                            // Chưa được khởi tạo trên hệ thống
                            if (scanningLog == null)
                            {
                                message = $"Board [{boardNo}] chưa được khởi tạo trên WIP. Vui lòng kiểm tra lại!";
                                new FormError(message).ShowDialog();
                                ErrorMessage("NG", message);

                                ResetBarcode();
                            }
                            // Nếu được khởi tạo rồi thì thực hiện các công việc tiếp theo
                            else
                            {
                                SuccessMessage("OK", scanningLog.BOARD_NO);
                                var workOrderItems = workOrderItemsService.GetSingle(scanningLog.BOARD_NO);
                                if (workOrderItems != null)
                                {
                                    if (workOrderItems.IS_FINISHED == true)
                                    {
                                        message = $"Board [{boardNo}] đã FINISHED trên WIP. Vui lòng kiểm tra lại!";
                                        ErrorMessage("NG", message);
                                        ResetBarcode();
                                        return;
                                    }
                                }


                                ActiveWindows(processName);
                            }
                        }
                        else
                        {
                            ErrorMessage("NG", "Vui lòng bắn lại barcode");
                            txtBarcode.SelectAll();
                            txtBarcode.Focus();
                        }

                    }
                    catch (SocketException se)
                    {
                        MessageBox.Show(se.Message);
                    }
                }
                // nếu = true, thì tạo log luôn không cần chờ Log máy nữa
                else
                {
                    if (txtBarcode.Text != null)
                    {
                        Ultils.CreateFileLog(null, txtBarcode.Text, "P", stationNo, DateTime.Now.ToString("yyMMddHHmmss"));
                        SuccessMessage("OK", "Create log success!");
                        txtBarcode.ResetText();
                        txtBarcode.Focus();
                    }
                }
            }
        }


        /// <summary>
        /// 
        /// </summary>
        private void ResetBarcode()
        {
            panelBarcode.Enabled = true;
            txtBarcode.ResetText();
            txtBarcode.Focus();
        }
        /// <summary>
        /// Active Windows Title
        /// </summary>
        /// <param name="title"></param>
        //private void ActiveProcess(string title)
        //{
        //    Process[] processes = Process.GetProcesses();
        //    int windowHandle = 0;
        //    foreach (Process p in processes)
        //    {
        //        if (p.MainWindowTitle.Contains(title))
        //        {
        //            windowHandle = (int)p.MainWindowHandle;
        //            break;
        //        }
                
        //    }
        //    NativeWin32.SetForegroundWindow(windowHandle);
        //}
        private void ActiveWindows(string title)
        {
            int windowHandle = NativeWin32.FindWindow(null, title);
            NativeWin32.SetForegroundWindow(windowHandle);
        }
        private void lblRefesh_Click(object sender, EventArgs e)
        {
            new FormConfig().ShowDialog();
            BinDataToControls();
        }

        private void SuccessMessage(string str_status, string str_message)
        {
            lblStatus.Text = str_status;
            lblStatus.BackColor = Color.DarkGreen;

            lblMessage.Text = str_message;
            lblMessage.BackColor = Color.DarkGreen;
        }
        private void ErrorMessage(string str_status, string str_message)
        {
            lblStatus.Text = str_status;
            lblStatus.BackColor = Color.DarkRed;

            lblMessage.Text = str_message;
            lblMessage.BackColor = Color.DarkRed;
        }
        private void DefaultMessage()
        {
            lblStatus.Text = @"[N\A]";
            lblStatus.BackColor = Color.FromArgb(255, 128, 0);

            lblMessage.Text = "no results";
            lblMessage.BackColor = Color.FromArgb(255, 128, 0);

            fileLastWriteTime = "";
            dateCheck = "";
            boardNo = "";
            productId = "";
            boardState = "";
        }
    }
}
