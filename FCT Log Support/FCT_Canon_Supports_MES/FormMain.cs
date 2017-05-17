using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Windows.Forms;

namespace FCT_Canon_Supports_MES
{
    public partial class FormMain : Form
    {
        string processName = "";
        string stationNo = "", fileExtension = "", inputLog = "", outputLog = "", serial = "", fullPath = "";
        string dateCheck = "", boardNo = "", productId = "", boardState = "";

        bool startWatching = false, RunTaks = false, checkLength = false, runTimer1 = false, runTimer2 = false;
        int pass = 0, ng = 0, total = 0, columnCount = 0, barcodeLength = 0, countLine=0;

        public FormMain()
        {
            InitializeComponent();
            BinDataToControls();
            LoadModels();
            Ultils.RegisterInStartup(true, Application.ExecutablePath);
            lblVersion.Text = Ultils.GetRunningVersion();
        }
        /// <summary>
        /// 
        /// </summary>
        private void BinDataToControls()
        {
            bool IsEmpty = false;

            if (Ultils.GetValueRegistryKey("Process") != null)
            {
                processName = Ultils.GetValueRegistryKey("Process").ToString();
            }
            else
            {
                IsEmpty = true;
            }
            if (Ultils.GetValueRegistryKey("StationNO") != null)
            {
                stationNo = Ultils.GetValueRegistryKey("StationNO").ToString();
            }
            else
            {
                IsEmpty = true;
            }
            if (Ultils.GetValueRegistryKey("FileExtension") != null)
            {
                fileExtension = Ultils.GetValueRegistryKey("FileExtension").ToString();
            }
            else
            {
                IsEmpty = true;
            }
            if (Ultils.GetValueRegistryKey("InputLog") != null)
            {
                inputLog = Ultils.GetValueRegistryKey("InputLog").ToString();
            }
            else
            {
                IsEmpty = true;
            }
            if (Ultils.GetValueRegistryKey("OutputLog") != null)
            {
                outputLog = Ultils.GetValueRegistryKey("OutputLog").ToString();
            }
            else
            {
                IsEmpty = true;
            }
            if (Ultils.GetValueRegistryKey("BarcodeLength") != null)
            {
                barcodeLength = int.Parse(Ultils.GetValueRegistryKey("BarcodeLength").ToString());
            }
            else
            {
                IsEmpty = true;
            }
            if (Ultils.GetValueRegistryKey("ColumnCount") != null)
            {
                columnCount = int.Parse(Ultils.GetValueRegistryKey("ColumnCount").ToString());
            }
            else
            {
                IsEmpty = true;
            }

            if (IsEmpty == true)
            {
                new FormConfig().ShowDialog();
                BinDataToControls();
                new FormMain().ShowDialog();
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private string GetState(string path)
        {
            string value = "";
            var lastLine = Ultils.GetLastLine(path);
            string[] array = lastLine.Split(',');
            if (array.Count() == columnCount)
            {
                string strTmp = array.Last();
                if (strTmp == "1")
                {
                    value = "P";
                }
                if(strTmp==""|| strTmp == null)
                {
                    value = "F";
                }
            }


            return value;
        }

        private string GetBoardNoLastLine(string path)
        {
            string value = "";
            var lastLine = Ultils.GetLastLine(path);
            string[] array = lastLine.Split(',');
            if(array.Count() == columnCount)
            {
                value = array[1];
            }
            

            return value;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (checkLength == true)
            {
                ActiveProcess(this.Text);
                serial = "";
                checkLength = false;
            }
            else
            {
                if (RunTaks)
                {
                    ActiveProcess(this.Text);
                    boardNo = GetBoardNoLastLine(fullPath);
                    boardState = GetState(fullPath);
                    if (boardNo.Length == barcodeLength)
                    {
                        dateCheck = DateTime.Now.ToString("yyMMddHHmmss");
                        productId = cboModels.Text;

                        List<Item> items = new List<Item>();
                        Ultils.CreateFileLog(productId, boardNo, boardState, stationNo, dateCheck);
                        Item item = new Item()
                        {
                            BoardNo = boardNo,
                            ProductId = productId,
                            Date = DateTime.Now.ToShortDateString(),
                            Time = DateTime.Now.ToShortTimeString(),
                            State = boardState,
                        };

                        items.Add(item);
                        dataGridView1.AutoGenerateColumns = false;
                        dataGridView1.DataSource = items;
                        if (boardState == "P")
                        {
                            ActiveProcess(this.Text);
                            pass = pass + 1;

                            SuccessMessage("OK", $"Board [{boardNo}] OK!");
                        }
                        if (boardState == "F")
                        {
                            ActiveProcess(this.Text);
                            ErrorMessage("NG", $"Board [{boardNo}] NG!");
                            ng = ng + 1;
                        }
                    }
                    else
                    {
                        ActiveProcess(this.Text);
                        ErrorMessage("NG", $"Board length [{boardNo}] NG!");
                    }

                    total = pass + ng;
                    lblPASS.Text = pass.ToString();
                    lblNG.Text = ng.ToString();
                    lblTOTAL.Text = total.ToString();
                    ActiveProcessContains(processName);

                    RunTaks = false;
                }
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if (RunTaks == false)
            {
                try
                {
                    if (cboModels.Text != "")
                    {
                        fullPath = Ultils.FullPath(cboModels.Text);

                        if (fullPath.Length > 10)
                        {
                            int current = int.Parse(lblCount.Text);
                            int actual = actual = Ultils.CountLine(fullPath); ;
                            if (actual > current)
                            {
                                lblCount.Text = actual.ToString();
                                countLine++;
                                if (countLine > 1)
                                {
                                    RunTaks = true;
                                }
                            }
                        }
                    }
                }
                catch (Exception)
                {

                }
                
            }
        }

        private void cboModels_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboModels.SelectedValue != null)
            {
                productId = cboModels.SelectedValue.ToString();
            }
            
        }

        private void lblConfigs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new FormConfig().ShowDialog();
            BinDataToControls();
        }

        private void lblConfigs_Click(object sender, EventArgs e)
        {
            new FormConfig().ShowDialog();
            BinDataToControls();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(processName))
            {
                MessageBox.Show("Vui lòng chọn Process!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (string.IsNullOrEmpty(cboModels.Text))
            {
                MessageBox.Show("Vui lòng chọn một Model!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cboModels.Focus();
            }
            else
            {
                if (startWatching == true)
                {
                    btnStart.BackColor = Color.Green;
                    btnStart.Text = "Start Read Log";
                    timer2.Enabled = false;
                    if (startWatching == true)
                    {
                        startWatching = false;
                        //    fileWatcher.EnableRaisingEvents = false;
                        //    fileWatcher.Dispose();
                    }

                    DefaultMessage();
                    cboModels.Enabled = true;
                    lblReload.Enabled = true;
                    lblAddModel.Enabled = true;
                    lblRefesh.Enabled = true;
                    lblConfigs.Enabled = true; 
                }
                else
                {
                    try
                    {
                        btnStart.BackColor = Color.DarkRed;
                        btnStart.Text = "Stop Read Log";
                        cboModels.Enabled = false;
                        lblReload.Enabled = false;
                        lblAddModel.Enabled = false;
                        lblConfigs.Enabled = false;

                        lblRefesh.Enabled = false;

                        timer2.Enabled = true;

                        if (startWatching == false)
                        {
                            startWatching = true;

                            //    // Config file watching
                            //    fileWatcher = new FileSystemWatcher();
                            //    fileWatcher.IncludeSubdirectories = true;
                            //    if (fileExtension.Contains("*"))
                            //    {
                            //        fileWatcher.Filter = fileExtension;
                            //    }
                            //    else
                            //    {
                            //        fileWatcher.Filter = "*" + fileExtension;
                            //    }

                            //    fileWatcher.Path = inputLog + "\\";
                            //    fileWatcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.CreationTime
                            //                         | NotifyFilters.FileName | NotifyFilters.DirectoryName;
                            //    fileWatcher.Created += new FileSystemEventHandler(OnFileChanged);
                            //    fileWatcher.Changed += new FileSystemEventHandler(OnFileChanged);
                            //    fileWatcher.EnableRaisingEvents = true;
                        }

                        ActiveProcessContains(processName);
                    }
                    catch (SocketException se)
                    {
                        MessageBox.Show(se.Message);
                    }
                }
                
            }
        }

        private void txtBarcode_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (boardNo != null || boardNo != "")
                    {
                        productId = cboModels.Text;
                        dateCheck = DateTime.Now.ToString("yyMMddHHmmss");
                        ActiveProcess(processName);

                    }
                    else
                    {
                        ErrorMessage("NG", "Vui lòng bắn vào barcode");
                    }

                }
                catch (SocketException se)
                {
                    MessageBox.Show(se.Message);
                }
            }
        }

        /// <summary>
        /// Active Windows Title
        /// </summary>
        /// <param name="title"></param>
        private void ActiveProcessContains(string title)
        {
            Process[] processes = Process.GetProcesses();
            int windowHandle = 0;
            foreach (Process p in processes)
            {
                if (p.MainWindowTitle.Contains(title))
                {
                    windowHandle = (int)p.MainWindowHandle;
                    break;
                }
                
            }
            NativeWin32.SetForegroundWindow(windowHandle);
        }
        private void ActiveProcess(string title)
        {
            int windowHandle = NativeWin32.FindWindow(null, title);
            NativeWin32.SetForegroundWindow(windowHandle);
        }
        private void lblRefesh_Click(object sender, EventArgs e)
        {
            new FormConfig().ShowDialog();
            BinDataToControls();
        }
        /// <summary>
        /// 
        /// </summary>
        private void LoadModels()
        {
            List<string> lists = new List<string>();
            if (Ultils.GetValueRegistryKey("Models") != null)
            {
                string[] models = Ultils.GetValueRegistryKey("Models").Split(';');               
                foreach (var item in models)
                {
                    lists.Add(item);
                }

            }
            else
            {
                string[] models = {
                "RM2-8419",
                "RM2-8420"
                };

                foreach (var item in models)
                {
                    lists.Add(item);
                    Ultils.WriteRegistryArray("Models", item);
                }
            }

            cboModels.DataSource = lists.ToList();
        }
        private void lblReload_Click(object sender, EventArgs e)
        {
            LoadModels();
        }

        private void lblAddModel_Click(object sender, EventArgs e)
        {
            new FormAddModel().ShowDialog();
            LoadModels();
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

            dateCheck = "";
            boardNo = "";
            productId = "";
            boardState = "";
        }
    }
}
