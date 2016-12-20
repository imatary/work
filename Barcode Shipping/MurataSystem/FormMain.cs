﻿using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using BarcodeShipping.Services;
using DevExpress.XtraEditors;
using Lib.Core.Helper;
using BarcodeShipping.Data;
using DevExpress.XtraGrid.Views.Grid;

namespace MurataSystem
{
    public partial class FormMain : Form
    {
        private readonly IqcService _iqcService = new IqcService();
        private readonly OQCService _oqcService;
        private readonly ModelService _modelService;
        private readonly MurataService _murataService;
        private Model _model;
        private DateTime _dateTimeCheck;
        string modelID = "";
        string codeMurata = "";
        string serialNo = "";
        public FormMain()
        {
            _oqcService = new OQCService();
            _modelService = new ModelService();
            _murataService = new MurataService();
            InitializeComponent();
        }

        private void FormQA_Load(object sender, EventArgs e)
        {
            lblOperatorName.Text = Program.CurrentUser.OperatorName;
            lblLineID.Text = string.Format("LINE {0}", Program.CurrentUser.LineID);
            txtModelUMC.Focus();
            lblVersion.Text = StringHelper.GetRunningVersion();
            LoadGridLookupEditModel();
        }

        /// <summary>
        /// Load Model for gridlookUp
        /// </summary>
        public void LoadGridLookupEditModel()
        {
            string customerName = "Murata";
            var models = _modelService.GetModelsByCustomerName(customerName);
            txtModelUMC.Properties.View.OptionsBehavior.AutoPopulateColumns = false;
            txtModelUMC.Properties.DisplayMember = "ModelName";
            txtModelUMC.Properties.ValueMember = "ModelID";
            txtModelUMC.Properties.View.BestFitColumns();
            txtModelUMC.Properties.DataSource = models;
        }
        private void txtModelUMC_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string modelName = txtModelUMC.Text.Trim();
                if (!string.IsNullOrEmpty(modelName))
                {
                    _model = _modelService.GetModelByName(modelName, "MURATA");
                    if (_model != null)
                    {
                        lblQuantityModel.Visible = true;
                        lblQuantityModel.Text = $"/{_model.Quantity}";
                        tableLayoutPanelModel.Visible = true;
                        lblCurentModel.Text = _model.ModelName;
                        lblSerialNo.Text = _model.SerialNo;
                        lblCustomerName.Text = $"Barcode {_model.CustomerName}";
                        modelID = _model.ModelID;

                        if (_model.CheckWidthModelCus == true)
                        {
                            EnbaleCheckWidthModelCus(true);
                        }
                        else
                        {
                            EnbaleCheckWidthModelCus(false);
                            txtBoxID.Enabled = true;
                            checkPASS.Enabled = true;
                            checkNG.Enabled = true;
                            txtProductID.Enabled = true;
                            txtBoxID.Focus();
                        }
                    }
                    else
                    {
                        SetErrorStatus("NG", $"Sai Model. Vui lòng kiểm tra lại!");
                        Ultils.EditTextErrorNoMessage(txtModelUMC);
                    }
                }
                else
                {
                    SetErrorStatus("NG", $"Vui lòng nhập vào Model UMC trước!");
                    Ultils.EditTextErrorNoMessage(txtModelUMC);
                }
            }
        }

        private void txtModelCUS_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string labelMurata = txtModelCUS.Text.Trim();
                if (!string.IsNullOrEmpty(labelMurata))
                {
                    if(labelMurata.Length > 10)
                    {
                        if (labelMurata.Contains(codeMurata))
                        {
                            var murata = _murataService.GetProducts_Murata_by_ModelCustomer(labelMurata);
                            if (murata != null)
                            {
                                SetErrorStatus("NG", $"Label {labelMurata} đã tồn tại.\nLabel: {murata.ModelName}\nIn Box:{murata.BoxID}");
                                Ultils.EditTextErrorNoMessage(txtProductID);
                                txtModelCUS.ResetText();
                            }
                            else
                            {
                                InsertLog(txtBoxID.Text.Trim());
                            }
                        }
                        else
                        {
                            SetErrorStatus("NG", $"Sai Label. Vui lòng kiểm tra và bắn lại!");
                            Ultils.EditTextErrorNoMessage(txtModelCUS);
                        }
                    }
                    else
                    {
                        SetErrorStatus("NG", $"Sai Label. Vui lòng kiểm tra và bắn lại!");
                        Ultils.EditTextErrorNoMessage(txtModelUMC);
                    }
                }
                else
                {
                    SetErrorStatus("NG", $"Vui lòng nhập vào Label!");
                    Ultils.EditTextErrorNoMessage(txtModelUMC);
                }
            }
        }
        private void txtProductionID_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                _dateTimeCheck = DateTime.Now;
                if (string.IsNullOrEmpty(txtProductID.Text))
                {
                    SetErrorStatus("NG", $"Label không được để trống!");
                    Ultils.EditTextErrorNoMessage(txtProductID);
                }
                else
                {
                    string productionId = txtProductID.Text.Trim();
                    if (productionId.Length <= 16)
                    {
                        SetErrorStatus("NG", $"Error! Label không đúng định dạng!");
                        txtProductID.SelectAll();
                        Ultils.EditTextErrorNoMessage(txtProductID);
                    }
                    else
                    {
                        if(productionId.Contains(lblCurentModel.Text) && productionId.Contains(lblSerialNo.Text))
                        {
                            if (Program.CurrentUser.OperationID == 1)
                            {
                                var production = _oqcService.GetLogByProductionId(productionId);
                                if (production != null)
                                {
                                    SetErrorStatus("NG",
                                        $"PCB [{txtProductID.Text}] đã có trong hệ thống. Vui lòng kiểm tra lại\n" +
                                        $"Box ID: {production.BoxID}");
                                    txtProductID.ResetText();
                                    Ultils.EditTextErrorNoMessage(txtProductID);
                                }
                                else
                                {
                                    if (checkModelCUS.Checked == true)
                                    {
                                        txtModelCUS.Focus();
                                    }
                                    else
                                    {
                                        InsertLog(txtBoxID.Text.Trim());
                                    }
                                }
                            }
                            else if (Program.CurrentUser.OperationID >= 2)
                            {
                                InsertLog(txtBoxID.Text.Trim());
                            }
                        }
                        else
                        {
                            SetErrorStatus("NG", $"Sai Label. Vui lòng kiểm tra lại!");
                            Ultils.EditTextErrorNoMessage(txtProductID);
                        }
                        
                    }
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
                        if (strBoxId.Substring(0, 3).ToUpper() != "F00")
                        {
                            SetErrorStatus("NG", "BOX ID phải bắt đầu bằng F00!");
                            Ultils.EditTextErrorNoMessage(txtBoxID);
                            txtBoxID.SelectAll();
                        }
                        else
                        {
                            StartInsert(false);
                            txtProductID.Focus();
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
        

        private void txtProductionID_EditValueChanged(object sender, EventArgs e)
        {
            Ultils.SetColorDefaultTextControl(txtProductID);
            if (!string.IsNullOrEmpty(txtProductID.Text))
            {
                txtProductID.Properties.Buttons[0].Visible = true;
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
        private void txtModelUMC_EditValueChanged(object sender, EventArgs e)
        {
            Ultils.SetColorDefaultTextControl(txtModelUMC);
            string modelName = txtModelUMC.EditValue.ToString();
            if (!string.IsNullOrEmpty(modelName))
            {
                var model = _modelService.GetModelById(modelName);
                if (model != null)
                {
                    lblQuantityModel.Visible = true;
                    lblQuantityModel.Text = $"/{model.Quantity}";
                    tableLayoutPanelModel.Visible = true;
                    lblCurentModel.Text = model.ModelName;
                    lblSerialNo.Text = model.SerialNo;
                    lblCustomerName.Text = $"Barcode {model.CustomerName}";
                    modelID = model.ModelID;
                    
                    modelName = model.ModelName.Trim();
                    serialNo = model.SerialNo.Trim();
                    if (model.CheckWidthModelCus == true)
                    {
                        codeMurata = model.CodeMurata.Trim();

                        EnbaleCheckWidthModelCus(true);
                        txtBoxID.Enabled = true;
                        checkPASS.Enabled = true;
                        checkNG.Enabled = true;
                        txtProductID.Enabled = true;
                        txtBoxID.Focus();
                    }
                    else
                    {
                        EnbaleCheckWidthModelCus(false);
                        txtBoxID.Enabled = true;
                        checkPASS.Enabled = true;
                        checkNG.Enabled = true;
                        txtProductID.Enabled = true;
                        txtBoxID.Focus();
                    }
                }
                else
                {
                    SetErrorStatus("NG", $"Sai Model. Vui lòng kiểm tra lại!");
                    Ultils.EditTextErrorNoMessage(txtModelCUS);
                }
            }
        }
        private void txtModelCUS_EditValueChanged(object sender, EventArgs e)
        {
            Ultils.SetColorDefaultTextControl(txtModelCUS);
            if (!string.IsNullOrEmpty(txtModelCUS.Text))
            {
                txtModelCUS.Properties.Buttons[0].Visible = true;
            }
        }

        private void txtProductionID_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 0)
            {
                txtProductID.Properties.Buttons[0].Visible = false;
                txtProductID.ResetText();
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
        private void txtModelUMC_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                LoadGridLookupEditModel();
            }
        }
        private void txtModelCUS_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 0)
            {
                txtModelCUS.Properties.Buttons[0].Visible = false;
                txtModelCUS.ResetText();
            }
        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.Caption == "#")
            {
                e.DisplayText = (e.ListSourceRowIndex + 1).ToString(CultureInfo.InvariantCulture);
            }

            if (e.Column == gridColumn4)
            {
                if (e.DisplayText == "True")
                {
                    e.DisplayText = "OK";
                }
                if(e.DisplayText == "False")
                {
                    e.DisplayText = "NG";
                }
            }
                
        }

        /// <summary>
        /// Insert Log
        /// </summary>
        /// <param name="boxId"></param>
        private void InsertLog(string boxId)
        {
            if (!string.IsNullOrEmpty(txtProductID.Text.Trim())
                || !string.IsNullOrEmpty(txtBoxID.Text.Trim())
                || !string.IsNullOrEmpty(txtModelUMC.Text.Trim()))
            {
                int lineId = Program.CurrentUser.LineID;
                int operationId = Program.CurrentUser.OperationID;
                string operatorId = Program.CurrentUser.OperatorCode;
                string productionId = txtProductID.Text.Trim();

                string status = null;
                bool judge=false;
                if (checkPASS.Checked==true)
                {
                    status = "P";
                    judge = true;
                    
                }
                if(checkNG.Checked==true)
                {
                    status = "F";
                    judge = false;
                }
                var logs = _murataService.GetProducts_Murata_by_BoxId(boxId).ToList();
                if (operationId == 1)
                {
                    // Nếu Box có dữ liệu của PCB
                    if (logs.Any())
                    {
                        var log = logs.SingleOrDefault(l => l.ProductionID == productionId);
                        // Nếu PCB mới bắn vào chưa có trong Box
                        if (log == null)
                        {
                            var checkModelInBox = logs.FirstOrDefault();
                            // Nếu Production ID, có Model giống với Model hiện tại
                            if (productionId.Contains(checkModelInBox.ModelName))
                            {
                                string tmp = lblQuantityModel.Text.Replace("/", "");
                                int countPcbInBox = int.Parse(lblCountPCB.Text);
                                int quantity = int.Parse(tmp);

                                if (logs.Count == quantity)
                                {
                                    SetErrorStatus("NG", $"Box [{txtBoxID.Text}] đã đủ số lượng. Vui lòng kiểm tra lại!");
                                    Ultils.EditTextErrorNoMessage(txtBoxID);
                                    StartInsert(true);
                                    EnbaleCheckWidthModelCus(false);
                                    txtProductID.ResetText();
                                }
                                else
                                {
                                    try
                                    {
                                        _iqcService.InsertLogs(productionId, lineId, "N/A", boxId, modelID, "N/T", 1, operatorId, false, "IT", StringHelper.GetInfo(), txtModelCUS.Text.Trim());

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
                                        logs = _murataService.GetProducts_Murata_by_BoxId(boxId).ToList();
                                        gridControlData.Refresh();
                                        gridControlData.DataSource = logs;
                                        lblCountPCB.Text = logs.Count.ToString(CultureInfo.InvariantCulture);

                                        SetSuccessStatus("OK", $"Thành công!\nPCB [{txtProductID.Text}]");
                                        ResetControls();
                                        if(logs.Count() == quantity)
                                        {
                                            SetErrorStatus("NG", $"Box [{txtBoxID.Text}] đã đủ số lượng. Vui lòng lấy box mới!");
                                            Ultils.EditTextErrorNoMessage(txtBoxID);
                                            StartInsert(true);
                                            EnbaleCheckWidthModelCus(false);
                                            txtProductID.ResetText();
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        SetErrorStatus("NG", "Model chưa có trong hệ thống!\nVui lòng nhập model này vào, và thử lại. \n" + ex.Message);
                                        ResetControls();
                                    }
                                }
                            }
                            else
                            {                           
                                SetErrorStatus("NG", "Sai Model! Vui lòng kiểm tra và thử lại!");
                                Ultils.EditTextErrorNoMessage(txtProductID);
                                ResetControls();
                                logs = _murataService.GetProducts_Murata_by_BoxId(boxId).ToList();
                                gridControlData.Refresh();
                                gridControlData.DataSource = logs;
                                lblCountPCB.Text = logs.Count.ToString(CultureInfo.InvariantCulture);
                            }
                        }
                        // Nếu có rồi thì thống báo lỗi
                        else
                        {
                            SetErrorStatus("NG", $"PCB [{txtProductID.Text}] này đã có trong Box rồi.\nVui lòng kiểm tra lại");
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
                            _iqcService.InsertLogs(productionId, lineId, "N/A", boxId, modelID, "N/T", 1, operatorId, false, "IT", StringHelper.GetInfo(), txtModelCUS.Text.Trim());

                            if (!_iqcService.CheckResultExits(txtProductID.Text, operationId))
                            {
                                _iqcService.InsertResult(productionId, operationId, judge, operatorId, _dateTimeCheck);
                            }
                            else
                            {
                                _iqcService.UpdateResult(productionId, operationId, judge, operatorId);
                            }
                            Ultils.CreateFileLog(lblCurentModel.Text, productionId, status, Program.CurrentUser.ProcessID, _dateTimeCheck);
                            Ultils.CreateFileLogDirModelName(lblCurentModel.Text, productionId, status, Program.CurrentUser.ProcessID, _dateTimeCheck);
                            logs = _murataService.GetProducts_Murata_by_BoxId(boxId).ToList();
                            gridControlData.Refresh();
                            gridControlData.DataSource = logs;
                            lblCountPCB.Text = logs.Count.ToString(CultureInfo.InvariantCulture);

                            SetSuccessStatus("OK", string.Format("Thêm thành công!\nPCB [{0}]", productionId));
                            ResetControls();
                        }
                        catch (Exception ex)
                        {
                            SetErrorStatus("NG", "Error Insert! \n" + ex.Message);
                            ResetControls();
                        }
                    }
                }
                else if (operationId >= 2)
                {
                    _iqcService.UpdateLogs(productionId, lineId, "N/A", boxId, modelID, null, operatorId, txtModelCUS.Text.Trim());
                    _iqcService.InsertResult(productionId, operationId, judge, operatorId, _dateTimeCheck);

                    logs = _murataService.GetProducts_Murata_by_BoxId(boxId).ToList();
                    gridControlData.Refresh();
                    gridControlData.DataSource = logs;
                    lblCountPCB.Text = logs.Count.ToString(CultureInfo.InvariantCulture);

                    SetSuccessStatus("OK", string.Format("Thành công!\nPCB [{0}] vừa được bắn lại lần {1}", productionId, operationId));
                    ResetControls();
                }
            }
            else
            {
                SetErrorStatus("NG", "Vui lòng nhập đủ thông tin!");
                txtProductID.Focus();
                txtProductID.SelectAll();
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
        /// Enable
        /// </summary>
        /// <param name="enable"></param>
        private void EnbaleCheckWidthModelCus(bool enable)
        {
            checkModelCUS.Enabled = enable;
            checkModelCUS.Checked = enable;
            txtModelCUS.Enabled = enable;
            txtBoxID.Focus();
        }

        /// <summary>
        /// Start Insert Enable Controls
        /// </summary>
        /// <param name="enable"></param>
        private void StartInsert(bool enable)
        {
            txtModelUMC.Enabled = enable;
            checkModelCUS.Enabled = enable;
            txtModelCUS.Enabled = enable;
            txtBoxID.Enabled = enable;
        }

        /// <summary>
        /// Reset controls
        /// </summary>
        private void ResetControls()
        {
            txtProductID.Focus();
            txtProductID.Text = string.Empty;
            txtModelCUS.ResetText();

            txtModelCUS.Properties.Buttons[0].Visible = false;
            txtProductID.Properties.Buttons[0].Visible = false;
            //txtBoxID.Properties.Buttons[0].Visible = false;
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
            var logIn = new FormLogin();
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
            //var search = new FormSearchPCB();
            //search.ShowDialog();
            txtProductID.Focus();
            txtProductID.SelectAll();
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            //var action = new FormAction();
            //action.ShowDialog();
            txtProductID.Focus();
            txtProductID.SelectAll();
        }

        private void checkPASS_CheckedChanged(object sender, EventArgs e)
        {
            if (checkPASS.Checked == true)
            {
                checkNG.Checked = false;
            }
            else
            {
                checkNG.Checked = true;
            }
        }
        private void gridView1_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.Column.FieldName == "JudgeResult")
            {
                bool value = (bool) View.GetRowCellValue(e.RowHandle, View.Columns.ColumnByFieldName("JudgeResult"));
                if (value == true)
                {
                    e.Appearance.BackColor = Color.Green;
                    e.Appearance.BackColor2 = Color.DarkGreen;
                    e.Appearance.ForeColor = Color.White;
                }
                else if (value == false)
                {
                    e.Appearance.BackColor = Color.Red;
                    e.Appearance.BackColor2 = Color.DarkRed;
                    e.Appearance.ForeColor = Color.White;
                }
            }
        }

        private void checkNG_CheckedChanged(object sender, EventArgs e)
        {
            if (checkNG.Checked == true)
            {
                checkPASS.Checked = false;
            }
            else
            {
                checkPASS.Checked = true;
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            txtBoxID.ResetText();
            txtBoxID.Enabled = false;

            txtProductID.ResetText();
            txtProductID.Enabled = false;

            checkModelCUS.Checked = false;
            checkModelCUS.Enabled = false;

            txtModelCUS.ResetText();
            txtModelCUS.Enabled = false;

            txtModelUMC.Focus();

            lblCountPCB.Text = "0";
            lblQuantityModel.Text = "/0";
            tableLayoutPanelModel.Visible = false;

            SetDefaultStatus("N/A", "no results");
        }
    }
}
