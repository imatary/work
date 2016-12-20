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
        }

        private void FormQA_Load(object sender, EventArgs e)
        {
            lblOperatorName.Text = Program.CurrentUser.OperatorName;
            lblLineID.Text = string.Format("LINE {0}", Program.CurrentUser.LineID);
        }
        private void txtProductionID_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _dateTimeCheck = DateTime.Now;
                if (string.IsNullOrEmpty(txtProductionID.Text))
                {
                    SetErrorStatus(true, "NG", $"Production ID không được để trống!");
                    Ultils.EditTextErrorNoMessage(txtProductionID);
                }
                else
                {
                    string productionId = txtProductionID.Text.Trim();
                    if (productionId.Length <= 10)
                    {
                        SetErrorStatus(true, "NG", $"Error!\nPCB không đúng định dạng!");
                        txtProductionID.SelectAll();
                        Ultils.EditTextErrorNoMessage(txtProductionID);
                    }
                    else
                    {
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
                                SetErrorStatus(true, "NG",
                                    $"PCB [{txtProductionID.Text}] đã có trong hệ thống. Vui lòng kiểm tra lại\n" +
                                    $"Box ID: {production.BoxID}");
                                txtProductionID.ResetText();
                                Ultils.EditTextErrorNoMessage(txtProductionID);
                            }
                            else
                            {
                                txtJudge.Focus();
                                SetErrorStatus(false, null, null);
                            }
                        }
                        else if (Program.CurrentUser.OperationID >= 2)
                        {
                            txtJudge.Focus();
                            SetErrorStatus(false, null, null);
                        }
                    }
                }
            }
            if (e.KeyCode == Keys.Tab)
            {
                if (string.IsNullOrEmpty(txtProductionID.Text))
                {
                    SetErrorStatus(true, "NG", $"Production ID không được để trống!");
                    Ultils.EditTextErrorNoMessage(txtProductionID);
                }
            }
        }
        private void txtMacAddress_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(txtMacAddress.Text))
                {
                    SetErrorStatus(true, "NG", "Mac Address không được để trống!");
                    Ultils.EditTextErrorNoMessage(txtMacAddress);
                }
                else
                {
                    if (txtMacAddress.Text.Length <= 2)
                    {
                        SetErrorStatus(true, "NG", "Mac Address Error!\nKhông đúng định dạng.\nVui lòng thử lại!");
                        txtMacAddress.SelectAll();
                        Ultils.EditTextErrorNoMessage(txtMacAddress);
                    }
                    else
                    {
                        txtJudge.Focus();
                        SetErrorStatus(false, null, null);
                    }

                }
            }
            if (e.KeyCode == Keys.Tab)
            {
                if (string.IsNullOrEmpty(txtMacAddress.Text))
                {
                    SetErrorStatus(true, "NG", "Mac Address không được để trống!");
                    Ultils.EditTextErrorNoMessage(txtMacAddress);
                }
            }
        }
        private void txtJudge_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(txtJudge.Text))
                {
                    SetErrorStatus(true, "NG", "Judge không được để trống!");
                    Ultils.EditTextErrorNoMessage(txtJudge);
                }
                else
                {
                    if (txtJudge.Text.Trim() == "1" || txtJudge.Text.Trim() == "0")
                    {
                        txtBoxID.Focus();
                        SetErrorStatus(false, null, null);
                    }
                    else
                    {
                        SetErrorStatus(true, "NG", "Judge Error!\nKhông đúng định dạng.\nVui lòng thử lại!\nChỉ chấp nhận giá trị: 1 hoặc 0 ");
                        txtJudge.SelectAll();
                        Ultils.EditTextErrorNoMessage(txtJudge);
                    }
                }
            }
            if (e.KeyCode == Keys.Tab)
            {
                if (string.IsNullOrEmpty(txtJudge.Text))
                {
                    SetErrorStatus(true, "NG", "Judge không được để trống!");
                    Ultils.EditTextErrorNoMessage(txtJudge);
                }
            }
        }
        private void txtBoxID_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (string.IsNullOrEmpty(txtBoxID.Text))
                {
                    SetErrorStatus(true, "NG", "Box ID không được để trống!");
                    Ultils.EditTextErrorNoMessage(txtBoxID);
                }
                else
                {
                    string strBoxId = txtBoxID.Text;
                    if (strBoxId.Length >= 3)
                    {
                        if (strBoxId.Substring(0, 3).ToUpper() != "F00")
                        {
                            SetErrorStatus(true, "NG", "BOX ID phải bắt đầu bằng F00!");
                            Ultils.EditTextErrorNoMessage(txtBoxID);
                            txtBoxID.SelectAll();
                        }
                        else
                        {
                            SetErrorStatus(false, null, null);
                            InsertLog(txtBoxID.Text);
                        }
                    }
                    else
                    {
                        SetErrorStatus(true, "NG", "BOX ID không đúng định đạng!");
                        Ultils.EditTextErrorNoMessage(txtBoxID);
                    }
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
        private void txtJudge_EditValueChanged(object sender, EventArgs e)
        {
            Ultils.SetColorDefaultTextControl(txtJudge);
            if (!string.IsNullOrEmpty(txtJudge.Text))
            {
                txtJudge.Properties.Buttons[0].Visible = true;
            }
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
                || !string.IsNullOrEmpty(txtMacAddress.Text.Trim())
                || !string.IsNullOrEmpty(txtJudge.Text.Trim()))
            {
                int lineId = Program.CurrentUser.LineID;
                int operationId = Program.CurrentUser.OperationID;
                string operatorId = Program.CurrentUser.OperatorCode;
                string productionId = txtProductionID.Text.Trim();

                bool judge = txtJudge.Text.Trim() == "1";
                string status = null;
                if (txtJudge.Text.Trim() == "1")
                {
                    status = "P";
                }
                else
                {
                    status = "F";
                }
                string modelName = null;
                string serialNo = null;
                if (!string.IsNullOrEmpty(lblCurentModel.Text))
                {
                    modelName = lblCurentModel.Text;
                    serialNo = lblSerialNo.Text;
                }
                else
                {
                    modelName = "#N/T";
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
                            //var model = _modelService.GetModelById(logs.FirstOrDefault().ModelID);
                            // Nếu Production ID, có Model giống với Model hiện tại
                            if (productionId.Contains(modelName) && productionId.Contains(serialNo))
                            {
                                string tmp = lblQuantityModel.Text.Replace("/", "");
                                int countPcbInBox = int.Parse(lblCountPCB.Text);
                                int quantity = int.Parse(tmp);

                                if (logs.Count == quantity)
                                {
                                    SetErrorStatus(true, "NG", $"Box [{txtBoxID.Text}] đã đủ số lượng. Vui lòng kiểm tra lại!");
                                    Ultils.EditTextErrorNoMessage(txtBoxID);
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
                                        Ultils.CreateFileLogDirModelName(lblCurentModel.Text, productionId, status, Program.CurrentUser.ProcessID, _dateTimeCheck);
                                        logs = _oqcService.GetLogsByBoxId(boxId).ToList();
                                        gridControlData.Refresh();
                                        gridControlData.DataSource = logs;
                                        lblCountPCB.Text = logs.Count.ToString(CultureInfo.InvariantCulture);

                                        SetSuccessStatus(true, "PASS", $"Thành công!\nPCB [{txtProductionID.Text}]");
                                        ResetControls();
                                    }
                                    catch (Exception ex)
                                    {
                                        SetErrorStatus(true, "NG", "Model chưa có trong hệ thống!\nVui lòng nhập model này vào, và thử lại. \n" + ex.Message);
                                        ResetControls();
                                    }
                                }
                            }
                            else
                            {
                                SetErrorStatus(true, "NG", $"Sai Model: {lblCurentModel.Text} !\nPCB [{productionId}] này khác với các PCB trong Box [{boxId}].\nVui lòng kiểm tra lại!");
                                Ultils.EditTextErrorNoMessage(txtProductionID);
                                ResetControls();

                                logs = _oqcService.GetLogsByBoxId(boxId).ToList();
                                gridControlData.Refresh();
                                gridControlData.DataSource = logs;
                                lblCountPCB.Text = logs.Count.ToString(CultureInfo.InvariantCulture);
                            }
                        }
                        // Nếu có rồi thì thống báo lỗi
                        else
                        {
                            SetErrorStatus(true, "NG", $"PCB [{txtProductionID.Text}] này đã có trong Box rồi.\nVui lòng kiểm tra lại");
                            ResetControls();
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
                            Ultils.CreateFileLogDirModelName(lblCurentModel.Text, productionId, status, Program.CurrentUser.ProcessID, _dateTimeCheck);
                            logs = _oqcService.GetLogsByBoxId(boxId).ToList();
                            gridControlData.Refresh();
                            gridControlData.DataSource = logs;
                            lblCountPCB.Text = logs.Count.ToString(CultureInfo.InvariantCulture);

                            SetSuccessStatus(true, "PASS", string.Format("Thêm thành công!\nPCB [{0}]", productionId));
                            ResetControls();
                        }
                        catch (Exception ex)
                        {
                            SetErrorStatus(true, "NG", "Error Insert! \n" + ex.Message);
                            ResetControls();
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

                    SetSuccessStatus(true, "PASS", string.Format("Thành công!\nPCB [{0}] vừa được bắn lại lần {1}", productionId, operationId));
                    ResetControls();
                }
            }
            else
            {
                SetErrorStatus(true, "NG", "Vui lòng nhập đủ thông tin!");
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
            txtJudge.Text = string.Empty;
            txtBoxID.Text = string.Empty;

            txtProductionID.Properties.Buttons[0].Visible = false;
            txtJudge.Properties.Buttons[0].Visible = false;
            txtBoxID.Properties.Buttons[0].Visible = false;
        }

        /// <summary>
        /// Error
        /// </summary>
        /// <param name="visible"></param>
        /// <param name="status"></param>
        /// <param name="messageInfo"></param>
        private void SetErrorStatus(bool visible, string status, string messageInfo)
        {
            lblStatus.Visible = visible;
            lblStatusMessage.Visible = visible;

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
        private void SetSuccessStatus(bool visible, string status, string messageInfo)
        {
            lblStatus.Visible = visible;
            lblStatusMessage.Visible = visible;

            lblStatus.Appearance.BackColor = Color.DarkGreen;
            lblStatusMessage.Appearance.BackColor = Color.DarkGreen;

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
            txtProductionID.Focus();
            txtProductionID.SelectAll();
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            var action = new FormAction();
            action.ShowDialog();
            txtProductionID.Focus();
            txtProductionID.SelectAll();
        }
        private void txtProductionID_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 0)
            {
                txtProductionID.Properties.Buttons[0].Visible = false;
                txtProductionID.ResetText();
            }
        }

        private void txtJudge_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 0)
            {
                txtJudge.Properties.Buttons[0].Visible = false;
                txtJudge.ResetText();
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

        //private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        //{
        //    if (e.Column.Caption == "#")
        //    {
        //        e.DisplayText = (e.ListSourceRowIndex + 1).ToString(CultureInfo.InvariantCulture);
        //    }
        //}
    }
}
