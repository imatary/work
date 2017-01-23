using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using BarcodeShipping.Services;
using DevExpress.XtraEditors;
using Lib.Core.Helper;

namespace OQC
{
    public partial class FormQA : Form
    {
        private readonly IqcService _iqcService = new IqcService();
        private readonly OQCService _oqcService;
        private readonly ModelService _modelService;
        private DateTime _dateTimeCheck;
        string modelID = null;
        public FormQA()
        {
            _oqcService = new OQCService();
            _modelService = new ModelService();
            InitializeComponent();
            lblVersion.Text = StringHelper.GetRunningVersion();
            Ultils.RegisterInStartup(true, Application.ExecutablePath);
            txtBoxID.Focus();
        }

        private void FormQA_Load(object sender, EventArgs e)
        {
            lblOperatorName.Text = Program.CurrentUser.OperatorName;
            lblLineID.Text = string.Format("LINE {0}", Program.CurrentUser.LineID);
        }
        private void txtMacAddress_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(txtMacAddress.Text))
                {
                    SetErrorStatus("NG", "Mac Address không được để trống!");
                    Ultils.EditTextErrorNoMessage(txtMacAddress);
                }
                else
                {
                    if (txtMacAddress.Text.Length <= 2)
                    {
                        SetErrorStatus("NG", "Mac Address Error!\nKhông đúng định dạng.\nVui lòng thử lại!");
                        txtMacAddress.SelectAll();
                        Ultils.EditTextErrorNoMessage(txtMacAddress);
                    }
                    else
                    {
                        txtBoxID.Focus();
                        SetDefaultStatus("N/A", "no results");
                    }

                }
            }
            if (e.KeyCode == Keys.Tab)
            {
                if (string.IsNullOrEmpty(txtMacAddress.Text))
                {
                    SetErrorStatus("NG", "Mac Address không được để trống!");
                    Ultils.EditTextErrorNoMessage(txtMacAddress);
                }
            }
        }
        private void txtBoxID_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (string.IsNullOrEmpty(txtBoxID.Text))
                {
                    SetErrorStatus("NG", "Box ID không được để trống!");
                    Ultils.EditTextErrorNoMessage(txtBoxID);
                }
                else
                {
                    string strBoxId = txtBoxID.Text;
                    if (strBoxId.Length >= 3)
                    {
                        if(strBoxId.Length > 10)
                        {
                            SetErrorStatus("NG", "BOX không được dài quá 10 ký tự!");
                            Ultils.EditTextErrorNoMessage(txtBoxID);
                            Ultils.EditTextErrorNoMessage(txtBoxID);
                        }
                        else
                        {
                            if (strBoxId.Substring(0, 3).ToUpper() != "F00")
                            {
                                SetErrorStatus("NG", "BOX ID phải bắt đầu bằng F00!");
                                Ultils.EditTextErrorNoMessage(txtBoxID);
                                txtBoxID.SelectAll();
                            }
                            else
                            {
                                SetDefaultStatus("N/A", "no results");
                                txtBoxID.Enabled = false;
                                txtProductionID.Focus();
                            }
                        } 
                    }
                    else
                    {
                        SetErrorStatus("NG", "BOX ID không đúng định đạng!");
                        Ultils.EditTextErrorNoMessage(txtBoxID);
                    }
                }
            }
        }
        private void txtProductionID_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _dateTimeCheck = DateTime.Now;
                string productionId = txtProductionID.Text.Trim();
                if (string.IsNullOrEmpty(productionId))
                {
                    SetErrorStatus("NG", $"Production ID không được để trống!");
                    Ultils.EditTextErrorNoMessage(txtProductionID);
                }
                else
                {
                    
                    if (productionId.Length <= 10)
                    {
                        SetErrorStatus("NG", $"Error!\nPCB không đúng định dạng!");
                        txtProductionID.SelectAll();
                        Ultils.EditTextErrorNoMessage(txtProductionID);
                    }
                    else
                    {
                        //var curentModel=_modelService.GetModelLikeName()
                        foreach (var item in _modelService.GetModels())
                        {
                            if (productionId.Contains(item.ModelName.ToUpper()))
                            {
                                lblQuantityModel.Visible = true;
                                lblQuantityModel.Text = $"/{item.Quantity}";
                                tableLayoutPanelModel.Visible = true;
                                lblCurentModel.Text = item.ModelName;
                                lblSerialNo.Text = item.SerialNo;
                                lblCustomerName.Text = $"Barcode {item.CustomerName}";
                                modelID = item.ModelID;
                                break;
                            }
                        }

                        if (Program.CurrentUser.OperationID == 1)
                        {
                            var production = _oqcService.GetLogByProductionId(productionId);
                            if (production != null)
                            {
                                SetErrorStatus("NG",
                                    $"PCB [{txtProductionID.Text}] đã có trong hệ thống. Vui lòng kiểm tra lại\n" +
                                    $"Box ID: {production.BoxID}");
                                txtProductionID.ResetText();
                                Ultils.EditTextErrorNoMessage(txtProductionID);
                            }
                            else
                            {
                                SetErrorStatus("N/A", "no results");
                                InsertLog(txtBoxID.Text.Trim());
                            }
                        }
                        else if (Program.CurrentUser.OperationID >= 2)
                        {
                            SetErrorStatus("N/A", "no results");
                            InsertLog(txtBoxID.Text.Trim());
                        }
                    }
                }
            }
            if (e.KeyCode == Keys.Tab)
            {
                if (string.IsNullOrEmpty(txtProductionID.Text))
                {
                    SetErrorStatus("NG", $"Production ID không được để trống!");
                    Ultils.EditTextErrorNoMessage(txtProductionID);
                }
            }
        } 
        private void txtProductionID_EditValueChanged(object sender, EventArgs e)
        {
            Ultils.SetColorDefaultTextControl(txtProductionID);
            if (!string.IsNullOrEmpty(txtProductionID.Text))
            {
                txtProductionID.Properties.Buttons[0].Visible = true;
            }
        }
        private void txtMacAddress_EditValueChanged(object sender, EventArgs e)
        {
            Ultils.SetColorDefaultTextControl(txtMacAddress);
        }
        private void txtBoxID_EditValueChanged(object sender, EventArgs e)
        {
            Ultils.SetColorDefaultTextControl(txtBoxID);
            if (!string.IsNullOrEmpty(txtBoxID.Text))
            {
                txtBoxID.Properties.Buttons[0].Visible = true;
            }
        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.Caption == "#")
            {
                e.DisplayText = (e.ListSourceRowIndex + 1).ToString(CultureInfo.InvariantCulture);
            }
        }

        /// <summary>
        /// Insert Log
        /// </summary>
        /// <param name="boxId"></param>
        private void InsertLog(string boxId)
        {
            if (!string.IsNullOrEmpty(txtProductionID.Text.Trim())
                || !string.IsNullOrEmpty(txtBoxID.Text.Trim()))
            {
                int lineId = Program.CurrentUser.LineID;
                int operationId = Program.CurrentUser.OperationID;
                string operatorId = Program.CurrentUser.OperatorCode;
                string productionId = txtProductionID.Text.Trim();

                string status = null;
                bool judge = false;
                if (checkPASS.Checked == true)
                {
                    status = "P";
                    judge = true;

                }
                if (checkNG.Checked == true)
                {
                    status = "F";
                    judge = false;
                }

                var logs = _oqcService.GetLogsByBoxId(boxId).ToList();

                if (operationId == 1)
                {
                    // Nếu Box có dữ liệu của PCB
                    if (logs.Any())
                    {
                        var log = logs.SingleOrDefault(l => l.ProductionID == productionId);
                        // Nếu PCB mới bắn vào chưa có trong Box
                        if (log == null)
                        {
                            var model = _modelService.GetModelById(logs.FirstOrDefault().ModelID);
                            // Nếu Production ID, có Model giống với Model hiện tại
                            if (productionId.Contains(model.ModelName) && productionId.Contains(model.SerialNo))
                            {
                                string tmp = lblQuantityModel.Text.Replace("/", "");
                                int countPcbInBox = int.Parse(lblCountPCB.Text);
                                int quantity = int.Parse(tmp);

                                if (logs.Count == quantity)
                                {
                                    SetErrorStatus("NG", $"Box [{txtBoxID.Text}] đã đủ số lượng. Vui lòng kiểm tra lại!");
                                    Ultils.EditTextErrorNoMessage(txtBoxID);
                                    txtBoxID.Enabled = true;
                                    txtBoxID.Focus();
                                    txtBoxID.ResetText();
                                }
                                else
                                {
                                    try
                                    {
                                        _iqcService.InsertLogs(productionId, lineId, txtMacAddress.Text, boxId, modelID, "N/T", 1, operatorId, false, "IT", StringHelper.GetInfo(), "tmp");

                                        if (!_iqcService.CheckResultExits(productionId, operationId))
                                        {
                                            _iqcService.InsertResult(productionId, operationId, judge, operatorId, _dateTimeCheck);
                                        }
                                        else
                                        {
                                            _iqcService.UpdateResult(productionId, operationId, judge, operatorId);
                                        }
                                        Ultils.CreateFileLog(lblCurentModel.Text, productionId, status, Program.CurrentUser.ProcessID, _dateTimeCheck);
                                        //Ultils.CreateFileLogDirModelName(lblCurentModel.Text, productionId, status, Program.CurrentUser.ProcessID, _dateTimeCheck);
                                        logs = _oqcService.GetLogsByBoxId(boxId).ToList();
                                        gridControlData.Refresh();
                                        gridControlData.DataSource = logs;
                                        lblCountPCB.Text = logs.Count.ToString(CultureInfo.InvariantCulture);

                                        SetSuccessStatus("PASS", $"Thành công!\nPCB [{txtProductionID.Text}]");
                                        txtProductionID.ResetText();
                                        txtProductionID.Focus();
                                    }
                                    catch (Exception ex)
                                    {
                                        SetErrorStatus("NG", "Model chưa có trong hệ thống!\nVui lòng nhập model này vào, và thử lại. \n" + ex.Message);
                                        txtProductionID.ResetText();
                                        txtProductionID.Focus();
                                    }
                                }
                            }
                            else
                            {
                                SetErrorStatus("NG", $"Sai Model: {lblCurentModel.Text} !\nPCB [{productionId}] này khác với các PCB trong Box [{boxId}].\nVui lòng kiểm tra lại!");
                                txtProductionID.ResetText();
                                txtProductionID.Focus();
                                Ultils.EditTextErrorNoMessage(txtProductionID);

                                logs = _oqcService.GetLogsByBoxId(boxId).ToList();
                                gridControlData.Refresh();
                                gridControlData.DataSource = logs;
                                lblCountPCB.Text = logs.Count.ToString(CultureInfo.InvariantCulture);
                                
                            }
                        }
                        // Nếu có rồi thì thống báo lỗi
                        else
                        {
                            SetErrorStatus("NG", $"PCB [{txtProductionID.Text}] này đã có trong Box rồi.\nVui lòng kiểm tra lại");
                            txtProductionID.ResetText();
                            txtProductionID.Focus();
                            gridControlData.Refresh();
                            gridControlData.DataSource = logs;
                            lblCountPCB.Text = logs.Count.ToString(CultureInfo.InvariantCulture);
                        }
                    }
                    // Nếu Box chưa có dữ liệu gì, thực hiện insert
                    else
                    {
                        try
                        {
                            _iqcService.InsertLogs(productionId, lineId, txtMacAddress.Text, boxId, modelID, "N/T", 1, operatorId, false, "IT", StringHelper.GetInfo(), "tmp");

                            if (!_iqcService.CheckResultExits(txtProductionID.Text, operationId))
                            {
                                _iqcService.InsertResult(productionId, operationId, judge, operatorId, _dateTimeCheck);
                            }
                            else
                            {
                                _iqcService.UpdateResult(productionId, operationId, judge, operatorId);
                            }
                            Ultils.CreateFileLog(lblCurentModel.Text, productionId, status, Program.CurrentUser.ProcessID, _dateTimeCheck);
                            //Ultils.CreateFileLogDirModelName(lblCurentModel.Text, productionId, status, Program.CurrentUser.ProcessID, _dateTimeCheck);
                            logs = _oqcService.GetLogsByBoxId(boxId).ToList();
                            gridControlData.Refresh();
                            gridControlData.DataSource = logs;
                            lblCountPCB.Text = logs.Count.ToString(CultureInfo.InvariantCulture);

                            SetSuccessStatus("PASS", string.Format("Thêm thành công!\nPCB [{0}]", productionId));
                            txtProductionID.ResetText();
                            txtProductionID.Focus();
                            //ResetControls();
                        }
                        catch (Exception ex)
                        {
                            SetErrorStatus("NG", "Error Insert! \n" + ex.Message);
                            //ResetControls();
                            txtProductionID.ResetText();
                            txtProductionID.Focus();
                        }
                    }
                }
                else if (operationId >= 2)
                {
                    _iqcService.UpdateLogs(productionId, lineId, txtMacAddress.Text, boxId, modelID, null, operatorId, "tmp");
                    _iqcService.InsertResult(productionId, operationId, judge, operatorId, _dateTimeCheck);

                    logs = _oqcService.GetLogsByBoxId(boxId).ToList();
                    gridControlData.Refresh();
                    gridControlData.DataSource = logs;
                    lblCountPCB.Text = logs.Count.ToString(CultureInfo.InvariantCulture);

                    SetSuccessStatus("PASS", string.Format("Thành công!\nPCB [{0}] vừa được bắn lại lần {1}", productionId, operationId));
                    txtProductionID.ResetText();
                    txtProductionID.Focus();
                }
            }
            else
            {
                SetErrorStatus("NG", "Vui lòng nhập đủ thông tin!");
                txtProductionID.Focus();
                txtProductionID.SelectAll();
            }

        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Control | Keys.Shift | Keys.L:
                    btnLogOut.PerformClick();
                    break;
                case Keys.Control | Keys.F:
                    btnSearchPCB.PerformClick();
                    break;

            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        /// <summary>
        /// Reset controls
        /// </summary>
        private void ResetControls()
        {
            txtProductionID.Focus();
            txtProductionID.Text = string.Empty;
            //txtMacAddress.Text = string.Empty;
            txtBoxID.Text = string.Empty;

            txtProductionID.Properties.Buttons[0].Visible = false;
            txtBoxID.Properties.Buttons[0].Visible = false;
        }

        /// <summary>
        /// Error
        /// </summary>
        /// <param name="visible"></param>
        /// <param name="status"></param>
        /// <param name="messageInfo"></param>
        private void SetErrorStatus(string status, string messageInfo)
        {
            lblStatus.Appearance.BackColor = Color.DarkRed;
            lblStatusMessage.Appearance.BackColor = Color.DarkRed;

            lblStatus.Text = status;
            lblStatusMessage.Text = messageInfo;
        }

        /// <summary>
        /// Success
        /// </summary>
        /// <param name="visible"></param>
        /// <param name="status"></param>
        /// <param name="messageInfo"></param>
        private void SetSuccessStatus(string status, string messageInfo)
        {
            lblStatus.Appearance.BackColor = Color.DarkGreen;
            lblStatusMessage.Appearance.BackColor = Color.DarkGreen;

            lblStatus.Text = status;
            lblStatusMessage.Text = messageInfo;
        }

        private void SetDefaultStatus(string status, string messageInfo)
        {
            lblStatus.Appearance.BackColor = Color.White;
            lblStatusMessage.Appearance.BackColor = Color.White;

            lblStatus.Text = status;
            lblStatusMessage.Text = messageInfo;
        }

        /// <summary>
        /// Log Out
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Hide();
            Program.CurrentUser = null;
            var logIn = new FormQALogin();
            logIn.ShowDialog();
        }

        /// <summary>
        /// Closing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormQA_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                dynamic mboxResult = XtraMessageBox.Show("Bạn có thực sự muốn đóng hay không!",
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

        private void btnSearchPCB_Click(object sender, EventArgs e)
        {
            var search = new FormSearchPCB();
            search.ShowDialog();
            btnReset.PerformClick();
        }

        private void txtProductionID_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 0)
            {
                txtProductionID.Properties.Buttons[0].Visible = false;
                txtProductionID.ResetText();
            }
        }
        private void txtBoxID_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 0)
            {
                txtBoxID.Properties.Buttons[0].Visible = false;
                txtBoxID.ResetText();
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtBoxID.Enabled = true;
            txtBoxID.ResetText();
            txtBoxID.Focus();

            txtProductionID.ResetText();

            SetDefaultStatus("N/A", "no results");

            lblCurentModel.Text = "N/A";
            lblSerialNo.Text = "N/A";

            lblCountPCB.Text = "0";
            lblQuantityModel.Text = "/0";

            gridControlData.DataSource = null;
            gridControlData.Refresh();
        }

        //private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        //{
        //    if (e.Column.Caption == "#")
        //    {
        //        e.DisplayText = (e.ListSourceRowIndex + 1).ToString(CultureInfo.InvariantCulture);
        //    }
        //}
    }
}
