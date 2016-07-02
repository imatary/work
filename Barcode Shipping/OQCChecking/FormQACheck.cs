using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using BarcodeShipping.Services;
using DevExpress.XtraEditors;
using OQCChecking.Helper;

namespace OQCChecking
{
    public partial class FormQACheck : Form
    {
        private readonly OQCService _oqcService;
        private readonly ModelService _modelService;
        private readonly IqcService _iqcService;
        public FormQACheck()
        {
            _iqcService = new IqcService();
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
                    var production = _oqcService.GetLogByProductionId(txtProductionID.Text);
                    if (production != null)
                    {
                        if (production.QA_Check == false)
                        {
                            txtJudge.Focus();
                            SetErrorStatus(false, "OK", null);
                        }
                        else
                        {
                            SetSuccessStatus(true, "OK",
                            $"PCB [{txtProductionID.Text}] đã được kiểm tra rồi.\n" +
                            $"Box ID: {production.BoxID} \n" +
                            $"Operator: {production.OperatorCode} \n" +
                            $"Date Check: {production.DateCheck} \n");
                            txtProductionID.SelectAll();
                            Ultils.EditTextErrorNoMessage(txtProductionID);
                        }
                    }
                    else
                    {
                        SetErrorStatus(true, "NG", $"Production ID[{txtProductionID.Text.Trim()}]\nChưa có trong hệ thống. Vui lòng kiểm tra lại!");
                        txtProductionID.SelectAll();
                        Ultils.EditTextErrorNoMessage(txtProductionID);
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
                    bool judge = txtJudge.Text.Trim() == "1";
                    if (strBoxId.Length >= 3)
                    {
                        if (strBoxId.Substring(0, 3).ToUpper() != "F00")
                        {
                            Ultils.EditTextErrorMessage(txtBoxID, "BOX ID phải bắt đầu bằng F00");
                            txtBoxID.SelectAll();
                        }
                        else
                        {
                            var currentBox = _oqcService.CheckBoxIdExits(txtBoxID.Text.Trim());
                            if (currentBox != null)
                            {
                                var production = _oqcService.GetLogByProductionId(txtProductionID.Text);
                                if (production.BoxID == txtBoxID.Text.Trim())
                                {
                                    string tmp = lblQuantityModel.Text.Replace("/", "");
                                    int countPcbInBox = int.Parse(lblCountPCB.Text);
                                    int quantity = int.Parse(tmp);

                                    if (countPcbInBox == quantity)
                                    {
                                        SetErrorStatus(true, "OK", "Thùng đã được kiểm tra xong. Vui lòng\nkiểm tra thùng khác!");
                                        txtProductionID.Focus();
                                        ResetControls();
                                    }
                                    else
                                    {
                                        try
                                        {
                                            _oqcService.UpdateOQCCheck(production, Program.CurrentUser.OperatorCode);
                                            if (txtJudge.Text.Trim() == "0")
                                            {
                                                _iqcService.UpdateResult(production.ProductionID, Program.CurrentUser.OperationID, judge, Program.CurrentUser.OperatorCode);
                                            }
                                            var logs = _oqcService.GetLogsByBoxId(txtBoxID.Text.Trim()).Where(l => l.QA_Check);
                                            gridControlData.DataSource = logs;
                                            lblCountPCB.Text = logs.Count().ToString();
                                            SetSuccessStatus(true, "OK", "Thành công!");
                                            ResetControls();
                                        }
                                        catch (Exception ex)
                                        {
                                            SetErrorStatus(true, "NG", $"Error update!\n {ex.Message}");
                                            txtBoxID.SelectAll();
                                            Ultils.EditTextErrorNoMessage(txtBoxID);
                                        }
                                    }  
                                }
                                else
                                {
                                    SetErrorStatus(true, "NG",
                                        $"PCB [{txtProductionID.Text}] không nằm\ntrong Box: {txtBoxID.Text} này.\n" +
                                        "Vui lòng kiểm tra lại.");
                                    txtBoxID.SelectAll();
                                    Ultils.EditTextErrorNoMessage(txtBoxID);
                                }
                            }
                            else
                            {
                                SetErrorStatus(true, "NG",
                                        $"Box [{txtBoxID.Text}] không tồn tại trong hệ thống.\n" +
                                        "Vui lòng kiểm tra lại.");
                                txtBoxID.SelectAll();
                                Ultils.EditTextErrorNoMessage(txtBoxID);
                            }
                            
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

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Control | Keys.Shift | Keys.L:
                    btnLogOut.PerformClick();
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

        private void gridControlData_Click(object sender, EventArgs e)
        {

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
