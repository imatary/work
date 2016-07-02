using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using BarcodeShipping.Services;
using DevExpress.XtraEditors;
using OQC.Helper;

namespace OQC
{
    public partial class FormQA : Form
    {
        private readonly IqcService _iqcService = new IqcService();
        private readonly OQCService _oqcService;
        private readonly ModelService _modelService;
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
                if (string.IsNullOrEmpty(txtProductionID.Text))
                {
                    Ultils.TextControlNotNull(txtProductionID, "Production ID");
                }
                else
                {
                    foreach (var item in _modelService.GetModels())
                    {
                        if (txtProductionID.Text.Trim().Contains(item.SerialNo) && txtProductionID.Text.Contains(item.ModelID))
                        {
                            lblQuantityModel.Visible = true;
                            lblQuantityModel.Text = $"/{item.Quantity}";
                            tableLayoutPanelModel.Visible = true;
                            lblCurentModel.Text = item.ModelID;
                            lblSerialNo.Text = item.SerialNo;
                            break;
                        }
                    }
                    var production = _oqcService.GetLogByProductionId(txtProductionID.Text.Trim());
                    if (production != null)
                    {
                        //SetErrorStatus(true, "NG", $"Error!\nProduction ID[{txtProductionID.Text.Trim()}]\nĐã có trong hệ thống.\nVui lòng kiểm tra lại!");
                        SetErrorStatus(true, "NG",
                            $"PCB [{txtProductionID.Text}] đã có trong hệ thống.\nVui lòng kiểm tra lại\n" +
                            $"Box ID: {production.BoxID} \n" +
                            $"Operator: {production.OperatorCode} \n" +
                            $"Date Check: {production.DateCheck} \n");
                        txtProductionID.SelectAll();
                        Ultils.EditTextErrorNoMessage(txtProductionID);
                    }
                    else
                    {
                        txtMacAddress.Focus();
                        SetErrorStatus(false, "OK", null);
                    }
                }
            }
            if (e.KeyCode == Keys.Tab)
            {
                if (string.IsNullOrEmpty(txtProductionID.Text))
                {
                    Ultils.TextControlNotNull(txtProductionID, "Production ID");
                }
            }
        }
        private void txtMacAddress_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(txtMacAddress.Text))
                {
                    Ultils.TextControlNotNull(txtMacAddress, "Mac Address");
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
                        SetErrorStatus(false, "OK", null);
                    }
                    
                }
            }
            if (e.KeyCode == Keys.Tab)
            {
                if (string.IsNullOrEmpty(txtMacAddress.Text))
                {
                    Ultils.TextControlNotNull(txtMacAddress, "Mac Address");
                }
            }
        }
        private void txtJudge_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(txtJudge.Text))
                {
                    Ultils.TextControlNotNull(txtJudge, "Judge");
                }
                else
                {
                    if (txtJudge.Text.Trim() == "1" || txtJudge.Text.Trim() == "0")
                    {
                        txtBoxID.Focus();
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
                    Ultils.TextControlNotNull(txtJudge, "Judge");
                }
            }
        }
        private void txtBoxID_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (string.IsNullOrEmpty(txtBoxID.Text))
                {
                    Ultils.TextControlNotNull(txtBoxID, "Box");
                }
                else
                {
                    string strBoxId = txtBoxID.Text;
                    if (strBoxId.Length >= 3)
                    {
                        if (strBoxId.Substring(0, 3).ToUpper() != "F00")
                        {
                            Ultils.EditTextErrorMessage(txtBoxID, "BOX ID phải bắt đầu bằng F00");
                            txtBoxID.SelectAll();
                        }
                        else
                        {
                            InsertLog(txtBoxID.Text);
                        }
                    }
                    else
                    {
                        Ultils.EditTextErrorMessage(txtBoxID, "BOX ID không đúng!");
                        txtBoxID.SelectAll();
                    }
                }
            }
        }

        private void txtProductionID_EditValueChanged(object sender, EventArgs e)
        {
            Ultils.SetColorDefaultTextControl(txtProductionID);
        }
        private void txtMacAddress_EditValueChanged(object sender, EventArgs e)
        {
            Ultils.SetColorDefaultTextControl(txtMacAddress);
        }
        private void txtJudge_EditValueChanged(object sender, EventArgs e)
        {
            Ultils.SetColorDefaultTextControl(txtJudge);
        }
        private void txtBoxID_EditValueChanged(object sender, EventArgs e)
        {
            Ultils.SetColorDefaultTextControl(txtBoxID);
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
                bool judge = txtJudge.Text.Trim() == "1";

                if (operationId == 1)
                {
                        var logs = _oqcService.GetLogsByBoxId(boxId).ToList();
                        // Nếu Box có dữ liệu của PCB
                        if (logs.Any())
                        {
                            var log = logs.FirstOrDefault(l => l.ProductionID == txtProductionID.Text);
                            // Nếu PCB mới bắn vào chưa có trong Box
                            if (log == null)
                            {
                                    if (!CheckProductionId(txtProductionID.Text, lblCurentModel.Text, lblSerialNo.Text))
                                    {
                                        SetErrorStatus(true, "NG", $"Error {lblCurentModel.Text} !\nPCB [{txtProductionID.Text}]\nnày khác với các PCB trong Box [{boxId}].\nVui lòng kiểm tra lại!");
                                        txtProductionID.SelectAll();
                                        Ultils.EditTextErrorNoMessage(txtProductionID);
                                        txtJudge.ResetText();
                                        txtMacAddress.ResetText();
                                        txtBoxID.ResetText();
                                    }
                                    else
                                    {
                                        string tmp = lblQuantityModel.Text.Replace("/", "");
                                        int countPcbInBox = int.Parse(lblCountPCB.Text);
                                        int quantity = int.Parse(tmp);

                                        if (countPcbInBox == quantity)
                                        {
                                            SetErrorStatus(true, "NG", "Thùng đã đủ số lượng, vui lòng kiểm tra lại!");
                                            ResetControls();
                                        }
                                        else
                                        {
                                            try
                                            {
                                                _iqcService.InsertLogs(txtProductionID.Text, lineId, txtMacAddress.Text, boxId, null, null, 1, operatorId);

                                                if (!_iqcService.CheckResultExits(txtProductionID.Text, operationId))
                                                {
                                                    _iqcService.InsertResult(txtProductionID.Text, operationId, judge, operatorId);
                                                }
                                                else
                                                {
                                                    _iqcService.UpdateResult(txtProductionID.Text, operationId, judge, operatorId);
                                                }
                                                var refeshData = _oqcService.GetLogsByBoxId(boxId).ToList();
                                                gridControlData.Refresh();
                                                gridControlData.DataSource = refeshData;
                                                lblCountPCB.Text = refeshData.Count.ToString(CultureInfo.InvariantCulture);

                                                SetSuccessStatus(true, "PASS", string.Format("Thêm thành công!\nPCB [{0}]", txtProductionID.Text));
                                                ResetControls();
                                            }
                                            catch (Exception ex)
                                            {
                                                SetErrorStatus(true, "NG", "Error Insert! \n" + ex.Message);
                                                ResetControls();
                                            }
                                        }
                                    }
                            }
                            // Nếu có rồi thì thống báo lỗi
                            else
                            {
                                SetErrorStatus(true, "NG", $"PCB [{txtProductionID.Text}] này đã có trong Box rồi.\nVui lòng kiểm tra lại");
                                ResetControls();
                                var refeshData = _oqcService.GetLogsByBoxId(boxId);
                                gridControlData.Refresh();
                                gridControlData.DataSource = refeshData;
                            }
                        }
                        // Nếu Box chưa có dữ liệu gì, thực hiện insert
                        else
                        {
                            try
                            {
                                _iqcService.InsertLogs(txtProductionID.Text, lineId, txtMacAddress.Text, boxId, null, null, 1, operatorId);

                                if (!_iqcService.CheckResultExits(txtProductionID.Text, operationId))
                                {
                                    _iqcService.InsertResult(txtProductionID.Text, operationId, judge, operatorId);
                                }
                                else
                                {
                                    _iqcService.UpdateResult(txtProductionID.Text, operationId, judge, operatorId);
                                }
                                var refeshData = _oqcService.GetLogsByBoxId(boxId).ToList();
                                gridControlData.Refresh();
                                gridControlData.DataSource = refeshData;
                                lblCountPCB.Text = refeshData.Count.ToString(CultureInfo.InvariantCulture);

                                SetSuccessStatus(true, "PASS", string.Format("Thêm thành công!\nPCB [{0}]", txtProductionID.Text));
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
                    _iqcService.UpdateLogs(txtProductionID.Text, lineId, txtMacAddress.Text, boxId, null, null, 1, operatorId);
                    _iqcService.InsertResult(txtProductionID.Text, operationId, judge, operatorId);

                    var refeshData = _oqcService.GetLogsByBoxId(boxId).ToList();
                    gridControlData.Refresh();
                    gridControlData.DataSource = refeshData;
                    lblCountPCB.Text = refeshData.Count.ToString(CultureInfo.InvariantCulture);

                    SetSuccessStatus(true, "PASS", string.Format("Thành công!\nPCB [{0}] vừa được bắn lại lần {1}", txtProductionID.Text, operationId));
                    ResetControls();
                }
            }
            else
            {
                SetErrorStatus(true, "NG", "Vui lòng nhập đủ thông tin!");
                txtProductionID.Focus();
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
            txtMacAddress.Text = string.Empty;
            txtJudge.Text = string.Empty;
            txtBoxID.Text = string.Empty;
        }

        /// <summary>
        /// Kiểm tra key Model
        /// </summary>
        /// <param name="productionId"></param>
        /// <param name="model"></param>
        /// <param name="serialNo"></param>
        /// <returns></returns>
        private bool CheckProductionId(string productionId, string model, string serialNo)
        {
            if (productionId != null)
            {
                if (productionId.Contains(model) && productionId.Contains(serialNo))
                {
                    return true;
                }
                return false;
            }
            return false;
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
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            var action=new FormAction();
            action.ShowDialog();
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
