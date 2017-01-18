using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Lib.Core.Helper;
using DevExpress.XtraGrid.Views.Grid;
using NichiconSystem.Data;

namespace NichiconSystem
{
    public partial class FormMain : Form
    {
        private readonly NichiconDbContext _context;
        private Model _model;
        private DateTime _dateTimeCheck;
        string modelID = "";
        string serialNo = "";
        public FormMain()
        {
            InitializeComponent();
            _context = new NichiconDbContext();
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
            var models = _context.Set<Model>().OrderByDescending(m => m.ModelName).ToList();
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
                    _model = _context.Models.SingleOrDefault(m => m.ModelID == txtModelUMC.EditValue.ToString());
                    if (_model != null)
                    {
                        lblQuantityModel.Visible = true;
                        lblQuantityModel.Text = $"/{_model.Quantity}";
                        tableLayoutPanelModel.Visible = true;
                        lblCurentModel.Text = _model.ModelName;
                        lblSerialNo.Text = _model.SerialNo;
                        modelID = _model.ModelID;

                        // Enable = true
                        txtBoxID.Enabled = true;
                        checkPASS.Enabled = true;
                        checkNG.Enabled = true;
                        txtProductID.Enabled = true;
                        txtBoxID.Focus();
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
                            InsertLog(txtBoxID.Text.Trim());
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

                                EnableBoxIDWidthModel(false);
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
                var model = _context.Models.SingleOrDefault(m => m.ModelID == modelName);
                if (model != null)
                {
                    lblQuantityModel.Visible = true;
                    lblQuantityModel.Text = $"/{model.Quantity}";
                    tableLayoutPanelModel.Visible = true;
                    lblCurentModel.Text = model.ModelName;
                    lblSerialNo.Text = model.SerialNo;
                    modelID = model.ModelID;

                    modelName = model.ModelName.Trim();
                    serialNo = model.SerialNo.Trim();

                    // Enable = true
                    txtBoxID.Enabled = true;
                    checkPASS.Enabled = true;
                    checkNG.Enabled = true;
                    txtProductID.Enabled = true;
                    txtBoxID.Focus();

                }
                else
                {
                    SetErrorStatus("NG", $"Sai Model. Vui lòng kiểm tra lại!");
                    Ultils.EditTextErrorNoMessage(txtModelUMC);
                }
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
            else if(e.Button.Index == 2)
            {
                var addModel = new FormAddModel();
                addModel.ShowDialog();

                LoadGridLookupEditModel();
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
                var logs = _context.Set<Nichicon>().Where(n => n.BoxID == boxId).ToList();
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
                                EnableBoxIDWidthModel(true);
                                txtProductID.ResetText();
                            }
                            else
                            {
                                try
                                {
                                    // Insert
                                    Add(productionId, lineId, boxId, modelID, txtModelUMC.Text, operatorId, judge);

                                    Ultils.CreateFileLog(lblCurentModel.Text, productionId, status, Program.CurrentUser.ProcessID, _dateTimeCheck);
                                    Ultils.CreateFileLogDirModelName(lblCurentModel.Text, productionId, status, Program.CurrentUser.ProcessID, _dateTimeCheck);
                                    logs = _context.Set<Nichicon>().Where(n => n.BoxID == boxId).ToList();
                                    gridControlData.Refresh();
                                    gridControlData.DataSource = logs;
                                    lblCountPCB.Text = logs.Count.ToString(CultureInfo.InvariantCulture);

                                    SetSuccessStatus("OK", $"Thành công!\nPCB [{txtProductID.Text}]");
                                    ResetControls();
                                    if (logs.Count() == quantity)
                                    {
                                        SetErrorStatus("NG", $"Box [{txtBoxID.Text}] đã đủ số lượng. Vui lòng lấy box mới!");
                                        Ultils.EditTextErrorNoMessage(txtBoxID);
                                        EnableBoxIDWidthModel(true);


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
                            logs = _context.Set<Nichicon>().Where(n => n.BoxID == boxId).ToList();
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
                        // Insert
                        Add(productionId, lineId, boxId, modelID, txtModelUMC.Text, operatorId, judge);

                        Ultils.CreateFileLog(lblCurentModel.Text, productionId, status, Program.CurrentUser.ProcessID, _dateTimeCheck);
                        Ultils.CreateFileLogDirModelName(lblCurentModel.Text, productionId, status, Program.CurrentUser.ProcessID, _dateTimeCheck);
                        logs = _context.Set<Nichicon>().Where(n => n.BoxID == boxId).ToList();
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
            else
            {
                SetErrorStatus("NG", "Vui lòng nhập đủ thông tin!");
                EnableBoxIDWidthModel(true);
                txtBoxID.Focus();
            }
        }

        private void Add(string id, int lineId, string boxId, 
            string modelId, string modelName, string operatorCode, bool judgeResult)
        {
            var nichicon = new Nichicon()
            {
                ProductionID = id,
                LineID = lineId,
                BoxID = boxId,
                ModelID = modelId,
                ModelName = modelName,
                OperatorCode = operatorCode,
                JudgeResult = judgeResult
            };

            try
            {
                _context.Nichicon.Add(nichicon);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inresrt!\n {ex.Message}", "Error Insert!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
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
        /// Start Insert Enable Controls
        /// </summary>
        /// <param name="enable"></param>
        private void EnableBoxIDWidthModel(bool enable)
        {
            txtModelUMC.Enabled = enable;
            txtBoxID.Enabled = enable;
        }

        /// <summary>
        /// Reset controls
        /// </summary>
        private void ResetControls()
        {
            txtProductID.Focus();
            txtProductID.Text = string.Empty;
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
            var search = new FormSearchPCB();
            search.ShowDialog();
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
            EnableBoxIDWidthModel(true);
            txtBoxID.ResetText();
            txtProductID.ResetText();
            txtProductID.Enabled = false;
            txtModelUMC.Focus();

            lblCountPCB.Text = "0";
            lblQuantityModel.Text = "/0";
            tableLayoutPanelModel.Visible = false;

            SetDefaultStatus("N/A", "no results");
        }
    }
}
