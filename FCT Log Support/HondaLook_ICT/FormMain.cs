using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using HondaLook_ICT.Data;
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
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace HondaLook_ICT
{
    public partial class FormMain : Form
    {
        string processNo = "", inputLog = "", extentionInputLog = "",
            outputLog = "", barcodeLength = "", stationNo = "",
            barcode_no = "", product_id = "", dateFormat = "",
            boardState = "", pathFileChanged = "";
        bool startWatching = false, RunTaks = false;
        int pass = 0, ng = 0, total = 0;

        FileSystemWatcher fileWatcher;
        private List<SCANNING_LOGS> scanningLogs = new List<SCANNING_LOGS>();
        private List<ItemDetail> itemDetails;
        public FormMain()
        {
            InitializeComponent();
            LoadConfigs();
            LoadModels();
            Ultils.RegisterInStartup(true, Application.ExecutablePath);
            lblVersion.Text = StringHelper.GetRunningVersion();
        }

        /// <summary>
        /// 
        /// </summary>
        private void LoadModels()
        {
            using (var context=new SupportsMESDbContext())
            {
                var models = context.HD_Models.ToList();
                txtModels.Properties.ValueMember = "ID";
                txtModels.Properties.DisplayMember = "ModelName";
                
                txtModels.Properties.DataSource = models;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private void LoadConfigs()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + @"Configs\Settings.txt";
            processNo = Ultils.GetLine(path, 2);
            inputLog = Ultils.GetLine(path, 4);
            extentionInputLog = Ultils.GetLine(path, 6);
            outputLog = Ultils.GetLine(path, 8);
            barcodeLength = Ultils.GetLine(path, 10);
            stationNo = Ultils.GetLine(path, 12);

            if (StringHelper.IsEmptyOrNull(processNo) ||
                StringHelper.IsEmptyOrNull(inputLog) ||
                StringHelper.IsEmptyOrNull(extentionInputLog) ||
                StringHelper.IsEmptyOrNull(outputLog) ||
                StringHelper.IsEmptyOrNull(barcodeLength) ||
                StringHelper.IsEmptyOrNull(stationNo)
                )
            {
                btnStart.PerformClick();
            }
            else
            {
                XtraMessageBox.Show("Error Message!", "Vui lòng kiểm tra lại file cài đặt!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                var config = new FormConfigs();
                config.ShowDialog();
                LoadConfigs();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="visible"></param>
        private void VisibleBarcodeControl(bool visible, bool enableModel)
        {
            txtBarcode.Visible = visible;
            txtModels.Enabled = enableModel;
            if (visible == true)
            {
                txtBarcode.ResetText();
                txtBarcode.Focus();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private string GetState(string path)
        {
            string state = "";
            string value = Ultils.GetLine(path, 2);
            //string[] tokens = str.Split(new[] { "," }, StringSplitOptions.None);
            string[] array = value.Split(',');
            string logState = Regex.Replace(array[1], "[^A-Za-z0-9 ]", "").Replace(" ", "");

            if (logState == "GO")
            {
                pass = pass + 1;
                state = "P";
            }
            else if (logState == "NG")
            {
                ng = ng + 1;
                state = "F";
            }
            total = pass + ng;

            return state;
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
        private void lblConfigs_Click(object sender, EventArgs e)
        {
            var config = new FormConfigs();
            config.ShowDialog();
            LoadConfigs();
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
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (CheckTextBoxNullValue.ValidationTextEditNullValue(txtModels))
            {
                if (startWatching)
                {
                    startWatching = false;
                    fileWatcher.EnableRaisingEvents = false;
                    fileWatcher.Dispose();
                    btnStart.Appearance.BackColor = Color.DarkGreen;
                    btnStart.Text = "Start";
                    VisibleBarcodeControl(false, true);
                }
                else
                {
                    startWatching = true;

                    btnStart.Appearance.BackColor = Color.DarkRed;
                    btnStart.Text = "Stop";
                    VisibleBarcodeControl(true, false);

                    // Config file watching
                    fileWatcher = new FileSystemWatcher();
                    fileWatcher.IncludeSubdirectories = true;
                    if (extentionInputLog.Contains("*"))
                    {
                        fileWatcher.Filter = extentionInputLog;
                    }
                    else
                    {
                        fileWatcher.Filter = "*" + extentionInputLog;
                    }

                    fileWatcher.Path = inputLog + "\\";

                    fileWatcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.CreationTime
                                         | NotifyFilters.FileName | NotifyFilters.DirectoryName;
                    fileWatcher.Created += new FileSystemEventHandler(OnFileChanged);
                    fileWatcher.Changed += new FileSystemEventHandler(OnFileChanged);
                    fileWatcher.EnableRaisingEvents = true;
                } 
            }
            else
            {
                MessageHelpers.SetErrorStatus(true, "NG", "Vui lòng chọn Model!", lblStatus, lblMessageInfo);
                return;
            }
        }

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
                    pathFileChanged = e.FullPath;
                    RunTaks = true;
                }
            }
        }
        private void timerEditNotify_Tick(object sender, EventArgs e)
        {
            if (RunTaks)
            {
                boardState = GetState(pathFileChanged);
                itemDetails = new List<ItemDetail>();
                foreach (var item in scanningLogs)
                {
                    // Create Log
                    Ultils.CreateFileLog(product_id, item.BOARD_NO, boardState, stationNo, dateFormat);

                    ItemDetail itemCheck = new ItemDetail()
                    {
                        BOARD_NO = item.BOARD_NO,
                        ProductID = product_id,
                        STATION_NO = stationNo,
                        DATE_CHECK = DateTime.Now.ToShortDateString(),
                        TIME_CHECK = DateTime.Now.ToShortTimeString(),
                        STATE = boardState,
                    };
                    itemDetails.Add(itemCheck);
                }
                ActiveFormByWindowsTitle(Text);
                gridControl1.DataSource = itemDetails;

                // Show
                lblPASS.Text = pass.ToString();
                lblNG.Text = ng.ToString();
                lblTotal.Text = total.ToString();

                MessageHelpers.SetSuccessStatus(true, "OK", $"Board [{barcode_no}] OK!", lblStatus, lblMessageInfo);

                // Reset TextBarcode
                txtBarcode.ResetText();
                txtBarcode.Focus();

                RunTaks = false;
            }
        }
        private void txtModels_EditValueChanged(object sender, EventArgs e)
        {
            if (StringHelper.IsEmptyOrNull(txtModels.Text))
            {
                MessageHelpers.SetDefaultStatusColorOrange(true, "N/A", "no results", lblStatus, lblMessageInfo);
                CheckTextBoxNullValue.SetColorDefaultTextControl(txtModels);
                btnStart.Focus();
            }
        }
        private void txtModels_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                new FormAddModel().ShowDialog();
                LoadModels();
            }
        }
        private void gridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.Column.FieldName == "STATE")
            {
                for (int i = 0; i < View.DataRowCount; i++)
                {
                    if (View.GetRowCellValue(i, View.Columns["STATE"]) != null)
                    {
                        string value = View.GetRowCellValue(i, View.Columns["STATE"]).ToString();
                        if (value == "P")
                        {
                            e.Appearance.BackColor = Color.Green;
                            e.Appearance.BackColor2 = Color.DarkGreen;
                            e.Appearance.ForeColor = Color.White;

                        }
                        else if (value == "F")
                        {
                            e.Appearance.BackColor = Color.Red;
                            e.Appearance.BackColor2 = Color.DarkRed;
                            e.Appearance.ForeColor = Color.White;
                        }
                    }
                }
                
            }
        }
        private void txtBarcode_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                barcode_no = txtBarcode.Text.Trim();
                if(barcode_no.Contains("-"))
                {
                    string[] array = barcode_no.Split('-');
                    barcode_no = array[0];
                    txtBarcode.Text = barcode_no;
                }
                product_id = txtModels.EditValue.ToString();
                dateFormat = DateTime.Now.ToString("yyMMddHHmmss");

                if (CheckTextBoxNullValue.ValidationTextEditNullValue(txtBarcode))
                {
                    int lengthSerial;
                    if(StringHelper.IsEmptyOrNull(barcodeLength))
                    {
                        lengthSerial = int.Parse(barcodeLength);
                        if(barcode_no.Length >= lengthSerial)
                        {
                            ActiveFormByWindowsTitle(processNo);
                            try
                            {
                                scanningLogs = new SCANNING_LOGS_Service().Get_SCANNING_LOGS(barcode_no, product_id);
                            }
                            catch (Exception ex)
                            {
                                MessageHelpers.SetErrorStatus(true, "NG", ex.Message, lblStatus, lblMessageInfo);
                            }
                        }
                        else
                        {
                            MessageHelpers.SetErrorStatus(true, "NG", $"Barcode[{barcode_no}] không đúng định dạng. Vui lòng kiểm tra lại!", lblStatus, lblMessageInfo);
                            CheckTextBoxNullValue.SetColorErrorTextControl(txtBarcode);
                            return;
                        }
                    }
                    else
                    {
                        MessageHelpers.SetErrorStatus(true, "NG", $"Vui lòng kiểm tra lại cài đặt độ dài của Barcode!", lblStatus, lblMessageInfo);
                        return;
                    }
                }
                else
                {
                    MessageHelpers.SetErrorStatus(true, "NG", "Không được để trống. Vui lòng bắn vào serial!", lblStatus, lblMessageInfo);
                    return;
                }
            }
        }
        private void txtBarcode_EditValueChanged(object sender, EventArgs e)
        {
            if (StringHelper.IsEmptyOrNull(txtBarcode.Text))
            {
                MessageHelpers.SetDefaultStatusColorOrange(true, "N/A", "no results", lblStatus, lblMessageInfo);
                CheckTextBoxNullValue.SetColorDefaultTextControl(txtBarcode);
            }
        }
    }
}
