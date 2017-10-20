using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using UMC.OQC.Barcode;
using UMC.OQC.Models;
using UMC.PVS.RULES;

namespace NichiconSystem
{
    public partial class FormMain : Form
    {
        Models_BUS models_BUS = null;
        BARCODE_RULE_ITEMS_BUS _RULE_ITEMS_BUS=null;
        NICHICON_BUS NICHICON_BUS = null;

        BARCODE_RULE_ITEMS rule_items = null;
        Models model = null;
        string process = null;
        bool writeLog = false;
        public FormMain()
        {
            InitializeComponent();
            
            _RULE_ITEMS_BUS = new BARCODE_RULE_ITEMS_BUS();
            models_BUS = new Models_BUS();
            NICHICON_BUS = new NICHICON_BUS();
            Display();
        }

        /// <summary>
        /// 
        /// </summary>
        void Display()
        {
            lblRunVersion.Text = Ultils.GetRunningVersion();
            lblCurrentUser.Text = Program.CurrentUser.NAME;
            dataGridView1.AutoGenerateColumns = false;
            // get models
            var models = models_BUS.GetAll("Nichicon");
            cboModels.DisplayMember = "ModelName";
            cboModels.ValueMember = "ModelID";
            cboModels.DataSource = models;

            // Ứng dụng MES
            var processValue = Ultils.GetValueRegistryKey("Process");
            if (processValue != null)
                process = processValue.ToString();

            // cho phép ghi log
            var writeLogData = Ultils.GetValueRegistryKey("WriteLog");
            if (writeLogData != null)
                writeLog = bool.Parse(writeLogData.ToString());

            cboModels.SelectedIndex = -1;
        }

        /// <summary>
        /// Thông báo lỗi
        /// </summary>
        /// <param name="status"></param>
        /// <param name="message"></param>
        void DisplayMessage(string status, string message)
        {
            Color backColor = new Color();
            Color foreColor = new Color();

            switch (status)
            {
                case "OK":
                    backColor = Color.DarkGreen;
                    foreColor = Color.White;
                    break;
                case "NG":
                    backColor = Color.DarkRed;
                    foreColor = Color.White;
                    break;
                case "WARNING":
                    backColor = Color.DarkOrange;
                    foreColor = Color.White;
                    break;
                default:
                    backColor = Color.White;
                    foreColor = Color.FromArgb(192, 64, 0);
                    break;
            }
            lblStatus.Text = status;
            lblStatus.BackColor = backColor;
            lblStatus.ForeColor = foreColor;

            lblMessge.Text = message;
            lblMessge.BackColor = backColor;
            lblMessge.ForeColor = foreColor;
        }

        private void chkOK_CheckedChanged(object sender, EventArgs e)
        {
            if (chkOK.Checked == true)
            {
                if (!Ultils.IsNullOrEmpty(cboModels))
                {
                    DisplayMessage("NG", "Vui lòng chọn Model");
                    chkOK.Checked = false;
                    return;
                }
                if (!Ultils.IsNullOrEmpty(txtBoxID))
                {
                    DisplayMessage("NG", "Vui lòng nhập vào BoxID");
                    chkOK.Checked = false;
                    return;
                }

                chkNG.Checked = false;
                cboModels.Enabled = false;
                txtBoxID.Enabled = false;

                txtBarcode.Enabled = true;
                txtBarcode.Focus();
            }
        }

        private void chkNG_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNG.Checked == true)
            {
                chkOK.Checked = false;

                txtBarcode.Enabled = true;
                txtBarcode.Focus();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBoxID_TextChanged(object sender, EventArgs e)
        {
            if (Ultils.IsNullOrEmpty(txtBoxID))
            {
                DisplayMessage("N/A", "no results");
            }
        }
        private void txtBarcode_TextChanged(object sender, EventArgs e)
        {
            if (Ultils.IsNullOrEmpty(txtBoxID))
            {
                DisplayMessage("N/A", "no results");
            }
        }

        private void cboModels_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cboModels.SelectedIndex;
            if (index >= 0)
            {
                string value = cboModels.SelectedValue.ToString();
                model = models_BUS.Get(value);
                lblQuantity.Text = string.Format("0/{0}", model.Quantity);

                rule_items = _RULE_ITEMS_BUS.Get(model.ModelName);
                if (rule_items != null)
                {
                    lblCurrentModel.Text = rule_items.RULE_NAME;
                    lblCurrentItem.Text = rule_items.CONTENT;
                }
                txtBoxID.Focus();
            }
            if(index < 0)
            {
                lblQuantity.Text = "0/0";
                lblCurrentModel.Text = "N/A";
                lblCurrentItem.Text = "N/A";
            }
        }

        private void txtBoxID_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!Ultils.IsNullOrEmpty(txtBarcode))
                {
                    string boxId = txtBoxID.Text.Trim();
                    if(boxId.Length > 5)
                    {
                        if (boxId.StartsWith("F00"))
                        {
                            lblQuantity.Text = string.Format("0/{0}", model.Quantity);
                            dataGridView1.DataSource = null;
                            chkOK.Checked = true;
                        }
                        else
                        {
                            DisplayMessage("NG", "BoxID phải bắt đầu với ký tự 'F00'. Vui lòng nhập lại!");
                            return;
                        }
                    }
                    else
                    {
                        DisplayMessage("NG", "BoxID không đúng định dạng. Vui lòng nhập lại!");
                        return;
                    }
                }
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                DialogResult dialogResult = MessageBox.Show("Bạn có thực sự muốn đóng hay không!",
                    @"THÔNG BÁO",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    Application.ExitThread();
                }
            }
        }

        private void txtBarcode_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!Ultils.IsNullOrEmpty(txtBarcode))
                {
                    DisplayMessage("NG", "Vui lòng bắn vào Barcode");
                    return;
                }
                else
                {
                    DateTime dateServer = NICHICON_BUS.GetDateTimeFormSqlServer();
                    string boardNo = txtBarcode.Text.Trim();
                    string boxId = txtBoxID.Text.Trim();

                    if (boardNo.Length == rule_items.LENGTH)
                    {
                        string key = boardNo.Substring(0, rule_items.CONTENT_LENGTH);
                        if (key == rule_items.CONTENT)
                        {
                            string checkExists = NICHICON_BUS.CheckBoardNOExists(boardNo);
                            if(checkExists == null)
                            {
                                var barcode = new NICHICON()
                                {
                                    ProductionID = boardNo,
                                    LineID = 0,
                                    BoxID = boxId,
                                    ModelID = model.ModelID,
                                    ModelName = model.ModelName,
                                    DateCheck = dateServer.Date,
                                    TimeCheck = dateServer.ToShortTimeString(),
                                    OperatorCode = Program.CurrentUser.ID,
                                    OperatorName = Program.CurrentUser.NAME,
                                    JudgeResult = chkOK.Checked == true ? "OK" : "NG"
                                };
                                List<NICHICON> data = new List<NICHICON>();
                                data = NICHICON_BUS.GetAll(boxId);
                                if (data.Count > 0)
                                {
                                    if (data.Count >= model.Quantity)
                                    {
                                        txtBoxID.Enabled = true;
                                        txtBoxID.ResetText();
                                        txtBoxID.Focus();
                                        DisplayMessage("WARNING", $"Thùng [{boxId}] đã đầy. Vui lòng lấy thùng khác!");
                                        return;
                                    }

                                    string old_key = data[0].ProductionID.Substring(0, rule_items.CONTENT_LENGTH);
                                    if (old_key == key)
                                    {
                                        try
                                        {
                                            int result = NICHICON_BUS.Add(barcode);
                                            if (result > 0)
                                            {
                                                data = NICHICON_BUS.GetAll(boxId);
                                                txtBarcode.ResetText();
                                                txtBarcode.Focus();

                                                var app = Process.GetProcesses().Where(p => p.MainWindowTitle == process).FirstOrDefault();
                                                // Gửi dữ liệu sang phần mềm khác
                                                if (app != null)
                                                {
                                                    ActiveWindows(process);
                                                    SendKeys.Send(boardNo);
                                                    Thread.Sleep(150);
                                                    SendKeys.Send("{ENTER}");
                                                }

                                                DisplayMessage("OK", $"Lưu thành công [{boardNo}]!");
                                                if (writeLog == true)
                                                {
                                                    string status = chkOK.Checked == true ? "P" : "F";
                                                    Ultils.CreateFileLog(model.ModelName, boardNo, status, "VI_NIC", dateServer);
                                                }

                                                Thread.Sleep(250);
                                                ActiveWindows(this.Text);
                                            }

                                        }
                                        catch (Exception ex)
                                        {
                                            txtBarcode.ResetText();
                                            txtBarcode.Focus();

                                            DisplayMessage("NG", "Lỗi!" + ex.Message + "\nVui lòng kiểm tra và bắn lại!");
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        txtBarcode.ResetText();
                                        txtBarcode.Focus();
                                        DisplayMessage("NG", "Model khác với model trong thùng. Vui lòng kiểm tra và bắn lại!");
                                        return;
                                    }
                                }
                                // Nếu chưa có thì thêm vào CSDL
                                else
                                {
                                    try
                                    {
                                        int result = NICHICON_BUS.Add(barcode);
                                        if (result > 0)
                                        {
                                            data = NICHICON_BUS.GetAll(boxId);
                                            txtBarcode.ResetText();
                                            txtBarcode.Focus();


                                            var app = Process.GetProcesses().Where(p => p.MainWindowTitle == process).FirstOrDefault();
                                            // Gửi dữ liệu sang phần mềm khác
                                            if (app != null)
                                            {
                                                ActiveWindows(process);
                                                SendKeys.Send(boardNo);
                                                Thread.Sleep(150);
                                                SendKeys.Send("{ENTER}");
                                            }

                                            DisplayMessage("OK", $"Lưu thành công [{boardNo}]!");

                                            if (writeLog == true)
                                            {
                                                string status = chkOK.Checked == true ? "P" : "F";
                                                Ultils.CreateFileLog(model.ModelName, boardNo, status, "VI_NIC", dateServer);
                                            }

                                            Thread.Sleep(250);
                                            ActiveWindows(this.Text);
                                        }

                                    }
                                    catch (Exception ex)
                                    {
                                        txtBarcode.ResetText();
                                        txtBarcode.Focus();

                                        DisplayMessage("NG", "Lỗi!" + ex.Message +"\nVui lòng kiểm tra và bắn lại!");
                                        return;
                                    }
                                }

                                int count = data.Count;
                                if(data.Count == model.Quantity)
                                {
                                    txtBoxID.Enabled = true;
                                    txtBoxID.ResetText();
                                    txtBoxID.Focus();
                                    DisplayMessage("WARNING", $"Thùng [{boxId}] đã đầy. Vui lòng lấy thùng khác!");
                                    return;
                                }

                                lblQuantity.Text = $"{count}/{model.Quantity}";

                                // Tải dữ liệu lên Gridview
                                dataGridView1.DataSource = data;
                            }
                            else
                            {
                                txtBarcode.ResetText();
                                txtBarcode.Focus();
                                DisplayMessage("NG", $"Board [{boardNo}] đã được bắn trước đó. Vui lòng kiểm tra và bắn lại!");
                                return;
                            }
                        }
                        else
                        {
                            txtBarcode.ResetText();
                            txtBarcode.Focus();
                            DisplayMessage("NG", "Sai Model. Vui lòng kiểm tra và bắn lại!");
                            return;
                        }
                    }
                    else
                    {
                        txtBarcode.ResetText();
                        txtBarcode.Focus();
                        DisplayMessage("NG", "Barcode không đúng định dạng. Vui lòng kiểm tra và bắn lại!");
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// Active Windows Title
        /// </summary>
        /// <param name="title"></param>
        private void ActiveWindows(string title)
        {
            int iHandle2 = NativeWin32.FindWindow(null, title);
            NativeWin32.SetForegroundWindow(iHandle2);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cboModels.Enabled = true;
            cboModels.SelectedIndex = -1;

            txtBoxID.Enabled = true;
            txtBoxID.ResetText();

            txtBarcode.ResetText();
            txtBarcode.Enabled = false;

            lblQuantity.Text = string.Format("0/0");
            lblCurrentModel.Text = "N/A";
            lblCurrentItem.Text = "N/A";

            chkOK.Checked = false;
            chkNG.Checked = false;

            model = new Models();
            dataGridView1.DataSource = null;

            DisplayMessage("N/A", "no results");

            cboModels.Focus();
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            new FormConfig().ShowDialog();

            var processValue = Ultils.GetValueRegistryKey("Process");
            if (processValue != null)
                process = processValue.ToString();
        }
    }
}
