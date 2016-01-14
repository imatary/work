using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using BarcodeShipping.Data;
using BarcodeShipping.GUI.Helper;
using BarcodeShipping.Services;
using DevExpress.XtraEditors;

namespace BarcodeShipping.GUI
{
    public partial class FormMain : Form
    {
        private IqcService _iqcService = new IqcService();
        private List<Shipping> _shippings = new List<Shipping>();
        private readonly List<Shipping> _pcbError = new List<Shipping>();
        private Model _currentModel;
        private PackingPO _currentPo = new PackingPO();
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            LoadGridLookupEditModel();
        }

        /// <summary>
        /// Get all PCB in Box
        /// </summary>
        private void GetAll(string boxId)
        {
            if (!_iqcService.CheckBoxExits(boxId))
            {
                splashScreenManager1.ShowWaitForm();
                var logs = _iqcService.GetLogs(boxId).ToList();
                if (logs.Any())
                {
                    foreach (var log in logs)
                    {
                        var shipping = new Shipping()
                        {
                            Operator = txtOperatorCode.Text,
                            Model = gridLookUpEditModelID.Text,
                            WorkingOder = txtWorkingOrder.Text,
                            Quantity = 1,
                            BoxID = txtBoxID.Text,
                            ProductID = log.ProductionID,
                            PO_NO = txtPO.Text,
                            MacAddress = log.MacAddress,
                            DateCheck = DateTime.Now.Date
                        };

                        if (CheckModels(shipping.ProductID))
                        {
                            _shippings.Add(shipping);
                        }
                        else
                        {
                            _pcbError.Add(shipping);
                        }
                    }

                    lblCountPCB.Text = _shippings.Count.ToString(CultureInfo.InvariantCulture);

                    if (_shippings.Count > _currentPo.QuantityRemain)
                    {
                        splashScreenManager1.CloseWaitForm();
                        if (MessageBox.Show(string.Format(
                            "Số lượng trong thùng [{0}] lớn hơn số Remains. " +
                            "\nBạn cần nhập thêm số lượng hoặc chọn Xuất lẻ (Retail Products) thùng này?" +
                            "\nChọn 'YES' để nhập thêm Quantity PO." +
                            "\nChọn 'NO' để bật form xuất lẻ (Retail Products).", boxId),
                            @"THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                        {
                            var addPo = new FormAddPO(gridLookUpEditModelID.Text, txtPO.Text);
                            addPo.ShowDialog();
                            txtBoxID.Focus();
                            txtBoxID.SelectAll();
                            GetQtyPoAndRemainsByWorkingOderAndPoNo(gridLookUpEditModelID.Text, txtPO.Text);
                            _shippings = new List<Shipping>();
                        }
                        else
                        {
                            btnXuatLe.Focus();
                            btnXuatLe.PerformClick();
                        }
                    }
                    else
                    {
                        lblRemains.Text = (_currentPo.QuantityRemain - _shippings.Count).ToString(CultureInfo.InvariantCulture);
                        lblCountPCB.Text = _shippings.Count.ToString(CultureInfo.InvariantCulture);
                        if (_pcbError.Any())
                        {
                            gridControlData.DataSource = _shippings;
                            splashScreenManager1.CloseWaitForm();
                            MessageBoxHelper.ShowMessageBoxError(string.Format("Box [{0}] có {1} PCB\n" +
                                                                               "Có {3} PCB không dành cho Model [{2}].\n" +
                                                                               "Vui lòng kiểm tra lại!", boxId,
                                logs.Count, gridLookUpEditModelID.Text, _pcbError.Count));
                            EnableTextControls(false);
                            VisibleControlAddPcb(true);
                        }
                        else
                        {
                            // Nếu số lượng đủ thì thực hiện lưu vào csdl
                            if (_shippings.Count == _currentModel.Quantity)
                            {
                                lblCountPCB.Text = _shippings.Count.ToString(CultureInfo.InvariantCulture);
                                gridControlData.DataSource = _shippings;
                                splashScreenManager1.CloseWaitForm();
                                //MessageBoxHelper.ShowMessageBoxInfo(string.Format("Thùng [{0}] đã đủ số lượng. Click 'OK' để lưu dữ liệu.", boxId));
                                splashScreenManager2.ShowWaitForm();
                                foreach (var log in _shippings)
                                {
                                    _iqcService.InsertShipping(txtOperatorCode.Text, gridLookUpEditModelID.Text,
                                        txtWorkingOrder.Text, 1, txtPO.Text, txtBoxID.Text, log.ProductID,
                                        log.MacAddress);
                                }
                                _iqcService.UpdateRemainsForPo(_currentPo.PO_NO, _currentPo.ModelID,
                                    int.Parse(lblRemains.Text));
                                splashScreenManager2.CloseWaitForm();
                                txtBoxID.Text = string.Empty;
                                lblCountPCB.Text = @"0";
                                gridControlData.DataSource = null;
                                _shippings = new List<Shipping>();

                                InsertOrUpdatePo(gridLookUpEditModelID.Text, txtPO.Text);
                            }
                            else
                            {
                                if (_shippings.Count > _currentModel.Quantity)
                                {
                                    int count = _shippings.Count - _currentModel.Quantity;
                                    gridControlData.Refresh();
                                    gridControlData.DataSource = _shippings;
                                    splashScreenManager1.CloseWaitForm();
                                    MessageBoxHelper.ShowMessageBoxError(
                                        string.Format("Vui lòng kiểm tra lại Box [{0}]\n" +
                                                      "Số lượng lớn hơn quy định {1} PCB!", boxId, count));
                                    txtBoxID.SelectAll();

                                }
                                else
                                {
                                    gridControlData.Refresh();
                                    gridControlData.DataSource = _shippings;
                                    splashScreenManager1.CloseWaitForm();
                                    MessageBoxHelper.ShowMessageBoxWaring(
                                        string.Format("Số lượng trong Box [{0}] chưa đủ. Vui lòng nhập thêm!", boxId));
                                    VisibleControlAddPcb(true);
                                    EnableTextControls(false);
                                }
                            }
                        }
                    }
                }
                else
                {
                    splashScreenManager1.CloseWaitForm();
                    if (MessageBox.Show(@"Không tìm thấy PCB nào trong Box [" + boxId + @"]." +
                                        @"\nVui lòng kiểm tra lại và bắn từng bản.", @"THÔNG BÁO",
                                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        EnableTextControls(false);
                        VisibleControlAddPcb(true);
                        txtAddPCB.Focus();
                    }
                    else
                    {
                        DialogResult = DialogResult.No;
                        txtBoxID.SelectAll();
                    }
                }
            }
            else
            {
                Ultils.EditTextErrorMessage(txtBoxID, string.Format("Box [{0}] đã được nhập trước đó. Vui lòng kiểm tra lại!", boxId));
                txtBoxID.Text = string.Empty;
            }

        }

        /// <summary>
        /// Add PCB into Box
        /// </summary>
        /// <param name="boxid"></param>
        private void AddPcbToBox(string boxid)
        {
            gridControlData.DataSource = null;
            if (!string.IsNullOrEmpty(txtAddPCB.Text))
            {
                if (_iqcService.CheckPcbExitsOnBoxOrShip(txtAddPCB.Text, _shippings))
                {
                    var shippings = _iqcService.GetShippings();
                    if (_iqcService.CheckPcbExitsOnBoxOrShip(txtAddPCB.Text, shippings))
                    {
                        var shipping = new Shipping()
                        {
                            ID = Guid.NewGuid(),
                            Operator = txtOperatorCode.Text,
                            Model = gridLookUpEditModelID.Text,
                            WorkingOder = txtWorkingOrder.Text,
                            Quantity = 1,
                            BoxID = boxid,
                            ProductID = txtAddPCB.Text,
                            PO_NO = txtPO.Text,
                            MacAddress = txtAddPCB.Text,
                            DateCheck = DateTime.Now,
                        };
                        _shippings.Add(shipping);
                        gridControlData.DataSource = _shippings;
                        lblCountPCB.Text = _shippings.Count.ToString(CultureInfo.InvariantCulture);
                        lblRemains.Text = (int.Parse(lblRemains.Text) - 1).ToString(CultureInfo.InvariantCulture);

                        txtAddPCB.Text = string.Empty;

                        if (_shippings.Count == _currentModel.Quantity)
                        {
                            gridControlData.DataSource = _shippings;
                            MessageBoxHelper.ShowMessageBoxInfo(
                                string.Format("Thùng [{0}] đã đủ số lượng. Click 'OK' để lưu dữ liệu.", boxid));
                            foreach (var log in _shippings)
                            {
                                _iqcService.InsertShipping(txtOperatorCode.Text, gridLookUpEditModelID.Text,
                                    txtWorkingOrder.Text, 1, txtPO.Text, txtBoxID.Text, log.ProductID,
                                    log.MacAddress);
                            }
                            _iqcService.UpdateRemainsForPo(_currentPo.PO_NO, _currentPo.ModelID,
                                int.Parse(lblRemains.Text));
                            EnableTextControls(true);
                            VisibleControlAddPcb(false);
                            txtBoxID.ResetText();
                            txtBoxID.Focus();
                            lblCountPCB.Text = @"0";
                            gridControlData.DataSource = null;
                            _shippings = new List<Shipping>();

                            InsertOrUpdatePo(gridLookUpEditModelID.Text, txtPO.Text);
                        }
                    }
                    else
                    {
                        var shipping = shippings.FirstOrDefault(s => s.ProductID == txtAddPCB.Text);
                        gridControlData.DataSource = _shippings;
                        if (shipping != null)
                        {
                            MessageBoxHelper.ShowMessageBoxError(string.Format("PCB {0} đã được xuất trước đó.\n" +
                                                                 "Box: {1}\n" +
                                                                 "Ngày xuất: {2}", txtAddPCB.Text, shipping.BoxID, shipping.DateCheck));
                            txtAddPCB.SelectAll();
                        }

                    }
                }
                else
                {
                    gridControlData.DataSource = _shippings;
                    MessageBoxHelper.ShowMessageBoxError(string.Format("PCB {0} đã được nhập trong Box rồi. Vui lòng kiểm tra lại!", txtAddPCB.Text));
                    txtAddPCB.SelectAll();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelId"></param>
        /// <param name="poNo"></param>
        private void InsertOrUpdatePo(string modelId, string poNo)
        {
            if (_currentPo.QuantityRemain <= _currentModel.Quantity || _currentPo.QuantityRemain <= 0)
            {
                if (MessageBox.Show(string.Format("Remains hiện đang gần hết. Bạn có muốn nhập thêm số lượng cho PO [{0}] này không?", poNo),
                    @"THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    var addPo = new FormAddPO(modelId, poNo);
                    addPo.ShowDialog();
                    txtBoxID.Focus();
                    GetQtyPoAndRemainsByWorkingOderAndPoNo(modelId, poNo);
                }
                else
                {
                    if (_currentPo.QuantityPO == 0)
                    {
                        gridLookUpEditModelID.EditValue = null;
                        gridLookUpEditModelID.ResetText();
                        txtPO.ResetText();
                        txtWorkingOrder.ResetText();

                        gridLookUpEditModelID.Focus();
                    }
                    else
                    {
                        txtBoxID.Focus();
                        txtBoxID.SelectAll();
                    }
                }
            }
            else
            {
                txtBoxID.SelectAll();
                txtBoxID.Focus();
            }
        }

        /// <summary>
        /// Trả về QtyPO và Remains theo workingOder và PoNo
        /// </summary>
        /// <param name="modelNo">Model</param>
        /// <param name="poNo">PO</param>
        private bool GetQtyPoAndRemainsByWorkingOderAndPoNo(string modelNo, string poNo)
        {
            _iqcService = new IqcService();
            _currentPo = _iqcService.GetPoByModelAndPoNo(modelNo, poNo);
            if (_currentPo != null)
            {
                lblQtyPO.Text = _currentPo.QuantityPO.ToString(CultureInfo.InvariantCulture);
                lblRemains.Text = _currentPo.QuantityRemain.ToString(CultureInfo.InvariantCulture);

                return true;
            }
            return false;
        }

        /// <summary>
        /// Load Model for gridlookUp
        /// </summary>
        public void LoadGridLookupEditModel()
        {
            gridLookUpEditModelID.Properties.View.OptionsBehavior.AutoPopulateColumns = false;
            gridLookUpEditModelID.Properties.View.BestFitColumns();
            gridLookUpEditModelID.Properties.DataSource = _iqcService.GetModels();
        }

        /// <summary>
        /// Reset Default Controls
        /// </summary>
        private void ResetControls()
        {
            txtOperatorCode.Focus();
            txtOperatorCode.Text = string.Empty;
            gridLookUpEditModelID.Text = string.Empty;
            txtWorkingOrder.Text = string.Empty;
            txtPO.Text = string.Empty;
            txtBoxID.Text = string.Empty;
            gridControlData.DataSource = null;
            lblCountPCB.Text = @"0";
            lblQtyPO.Text = @"0";
            lblRemains.Text = @"0";
            lblQuantityModel.Text = @"/0";
            _shippings = new List<Shipping>();
        }

        /// <summary>
        /// Enable Controls
        /// </summary>
        /// <param name="enable"></param>
        private void EnableTextControls(bool enable)
        {
            txtOperatorCode.Enabled = enable;
            gridLookUpEditModelID.Enabled = enable;
            txtWorkingOrder.Enabled = enable;
            txtPO.Enabled = enable;
            txtBoxID.Enabled = enable;
        }

        /// <summary>
        /// Visible Control AddPCB
        /// </summary>
        /// <param name="visible"></param>
        private void VisibleControlAddPcb(bool visible)
        {
            txtAddPCB.ResetText();
            txtAddPCB.Focus();
            lblAddPCB.Visible = visible;
            txtAddPCB.Visible = visible;
        }

        /// <summary>
        /// Kiểm tra
        /// </summary>
        /// <param name="modelId"></param>
        /// <returns></returns>
        private bool CheckModels(string modelId)
        {
            if (modelId != null)
            {
                string key = string.Format("{0}_{1}", _currentModel.SerialNo, _currentModel.ModelID);
                if (modelId.Contains(key))
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        /// <summary>
        /// Hot key
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Control | Keys.F:
                    {
                        btnSearch.PerformClick();
                        return true;
                    }

                case Keys.Control | Keys.E:
                    {
                        btnExportToExel.PerformClick();
                        return true;
                    }
                case Keys.Control | Keys.R:
                    {
                        btnClear.PerformClick();
                        return true;
                    }
                case Keys.Escape:
                    {
                        Close();
                        return true;
                    }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void txtOperatorCode_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(txtOperatorCode.Text))
                {
                    Ultils.TextControlNotNull(txtOperatorCode, "Operator code");
                }
                else
                {
                    gridLookUpEditModelID.Focus();
                }
            }
            if (e.KeyCode == Keys.Tab)
            {
                if (string.IsNullOrEmpty(txtOperatorCode.Text))
                {
                    Ultils.TextControlNotNull(txtOperatorCode, "Operator code");
                }
                else
                {
                    gridLookUpEditModelID.Enabled = true;
                }
            }
        }
        private void gridLookUpEditModelID_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                GridLookUpModel_PreviewKeyDown();
            }
            if (e.KeyCode == Keys.Tab)
            {
                GridLookUpModel_PreviewKeyDown();
            }
        }
        private void txtWorkingOrder_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(txtWorkingOrder.Text))
                {
                    Ultils.TextControlNotNull(txtWorkingOrder, "Working Oder");
                }
                else
                {
                    txtPO.Focus();
                }
            }
            if (e.KeyCode == Keys.Tab)
            {
                if (string.IsNullOrEmpty(txtWorkingOrder.Text))
                {
                    Ultils.TextControlNotNull(txtWorkingOrder, "Working Oder");
                }
            }
        }
        private void txtPO_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                EditTextPO_PreviewKeyDown();
            }
            if (e.KeyCode == Keys.Tab)
            {
                EditTextPO_PreviewKeyDown();
            }
        }
        private void txtBoxID_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                EditTextBox_PreviewKeyDown();
            }
            if (e.KeyCode == Keys.Tab)
            {
                EditTextBox_PreviewKeyDown();
            }
        }
        private void txtAddPCB_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                EditTextAddPCB_PreviewKeyDown();
            }
            if (e.KeyCode == Keys.Tab)
            {
                EditTextAddPCB_PreviewKeyDown();
            }
        }


        private void txtOperatorCode_EditValueChanged(object sender, EventArgs e)
        {
            Ultils.SetColorDefaultTextControl(txtOperatorCode);
        }
        private void gridLookUpEditModelID_EditValueChanged(object sender, EventArgs e)
        {
            Ultils.SetColorDefaultGridLookUpEdit(gridLookUpEditModelID);
        }
        private void txtWorkingOrder_EditValueChanged(object sender, EventArgs e)
        {
            Ultils.SetColorDefaultTextControl(txtWorkingOrder);
        }
        private void txtPO_EditValueChanged(object sender, EventArgs e)
        {
            Ultils.SetColorDefaultTextControl(txtPO);
        }
        private void txtBoxID_EditValueChanged(object sender, EventArgs e)
        {
            Ultils.SetColorDefaultTextControl(txtBoxID);
        }
        private void txtAddPCB_EditValueChanged(object sender, EventArgs e)
        {
            Ultils.SetColorDefaultTextControl(txtAddPCB);
        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.Caption == @"#")
            {
                e.DisplayText = (e.ListSourceRowIndex + 1).ToString(CultureInfo.InvariantCulture);
            }
        }

        /// <summary>
        /// PO Validating
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPO_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string strLength = txtPO.Text;
            if (strLength.Length >= 3)
            {
                if (strLength.Substring(0, 3).ToUpper() != "3N3")
                {
                    Ultils.EditTextErrorMessage(txtPO, "PO phải bắt đầu bằng 3N3");
                    txtPO.SelectAll();
                }
            }
        }

        /// <summary>
        /// Box Validating
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBoxID_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string strLength = txtBoxID.Text;
            if (strLength.Length >= 3)
            {
                if (strLength.Substring(0, 3).ToUpper() != "F00")
                {
                    Ultils.EditTextErrorMessage(txtBoxID, "BOX ID phải bắt đầu bằng F00");
                    txtPO.SelectAll();
                }
            }
        }

        /// <summary>
        /// Button Export Exel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportToExel_Click(object sender, EventArgs e)
        {
            var exportToExel = new ExportToExel();
            exportToExel.ShowDialog();

            txtOperatorCode.Focus();
        }

        /// <summary>
        /// Button Search
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            var search = new Search();
            search.ShowDialog();

            txtOperatorCode.Focus();
        }

        /// <summary>
        /// Buton Clear
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetControls();
            EnableTextControls(true);
            VisibleControlAddPcb(false);
        }

        private void btnExportCurrentBox_Click(object sender, EventArgs e)
        {
            var date = DateTime.Now;
            var saveFileDialog1 = new SaveFileDialog
            {
                FileName = string.Format("{3}-{0}-{1}-{2}", date.Day, date.Month, date.Year, txtBoxID.Text),
                Filter = @"Exel|*.xls",
                Title = @"Save exel file",
                OverwritePrompt = true,
            };
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                gridControlData.ExportToXls(saveFileDialog1.FileName);
                txtOperatorCode.Focus();
            }
        }

        private void gridLookUpEditModelID_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                var addModel = new FormAddModel(null, txtOperatorCode.Text);
                addModel.ShowDialog();
                LoadGridLookupEditModel();
            }
        }

        //private void panelControlStatus_Paint(object sender, PaintEventArgs e)
        //{
        //    ControlPaint.DrawBorder(e.Graphics, panelControlStatus.ClientRectangle, Color.DarkOrange,ButtonBorderStyle.Dotted);
        //}

        #region Control validate
        /// <summary>
        /// Model
        /// </summary>
        private void GridLookUpModel_PreviewKeyDown()
        {
            if (string.IsNullOrEmpty(gridLookUpEditModelID.Text))
            {
                Ultils.GridLookUpEditControlNotNull(gridLookUpEditModelID, "Model");
            }
            else
            {
                if (_iqcService.CheckModelIdExits(gridLookUpEditModelID.Text))
                {
                    _currentModel = _iqcService.GetModels().FirstOrDefault(c => c.ModelID == gridLookUpEditModelID.Text);
                    if (_currentModel != null)
                    {
                        lblQuantityModel.Text = string.Format("/{0}", _currentModel.Quantity);
                    }
                    txtWorkingOrder.Focus();
                }
                else
                {
                    Ultils.GridLookUpEditNoMessage(gridLookUpEditModelID);
                    if (XtraMessageBox.Show("Model [" + gridLookUpEditModelID.Text + "] chưa có trong hệ thống.\nBạn có muốn thêm mới Model?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        var addModel = new FormAddModel(gridLookUpEditModelID.Text, txtOperatorCode.Text);
                        addModel.ShowDialog();
                        LoadGridLookupEditModel();
                    }
                    else
                    {
                        DialogResult = DialogResult.No;
                        gridLookUpEditModelID.SelectAll();
                    }

                }
            }
        }

        /// <summary>
        /// PO
        /// </summary>
        private void EditTextPO_PreviewKeyDown()
        {
            if (string.IsNullOrEmpty(txtPO.Text))
            {
                Ultils.TextControlNotNull(txtPO, "PO");
            }
            else
            {
                string strPo = txtPO.Text;
                int index = strPo.IndexOf(' ');
                string removePo = index >= 0 ? strPo.Remove(index) : txtPO.Text;

                if (removePo.Length >= 3)
                {
                    if (removePo.Substring(0, 3).ToUpper() != "3N3")
                    {
                        Ultils.EditTextErrorMessage(txtPO, "PO phải bắt đầu bằng 3N3");
                        txtPO.SelectAll();
                    }
                    else
                    {
                        if (!GetQtyPoAndRemainsByWorkingOderAndPoNo(gridLookUpEditModelID.Text, removePo))
                        {
                            if (XtraMessageBox.Show(string.Format("Chưa tạo QTY PO và Remains cho Model [{0}] và PO [{1}] này.\nBạn có muốn thêm mới không?", gridLookUpEditModelID.Text, removePo), "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                            {
                                var addPo = new FormAddPO(gridLookUpEditModelID.Text, removePo);
                                addPo.ShowDialog();
                                txtPO.Text = removePo;
                                GetQtyPoAndRemainsByWorkingOderAndPoNo(gridLookUpEditModelID.Text, removePo);
                                txtBoxID.Focus();
                            }
                            else
                            {
                                DialogResult = DialogResult.No;
                                txtPO.SelectAll();
                            }
                        }
                        else
                        {
                            InsertOrUpdatePo(gridLookUpEditModelID.Text, removePo);
                            txtPO.Text = removePo;
                        }
                    }
                }
                else
                {
                    Ultils.EditTextErrorMessage(txtPO, "PO NO không đúng!");
                }
            }
        }

        /// <summary>
        /// BOX
        /// </summary>
        private void EditTextBox_PreviewKeyDown()
        {
            if (string.IsNullOrEmpty(txtBoxID.Text))
            {
                Ultils.TextControlNotNull(txtBoxID, "Box");
            }
            else
            {
                if (string.IsNullOrEmpty(txtOperatorCode.Text))
                {
                    Ultils.TextControlNotNull(txtOperatorCode, "Operator code");
                }
                else if (string.IsNullOrEmpty(gridLookUpEditModelID.Text))
                {
                    Ultils.GridLookUpEditControlNotNull(gridLookUpEditModelID, "Model");
                }
                else if (string.IsNullOrEmpty(txtWorkingOrder.Text))
                {
                    Ultils.TextControlNotNull(txtWorkingOrder, "Working oder");
                }
                else if (string.IsNullOrEmpty(txtPO.Text))
                {
                    Ultils.TextControlNotNull(txtWorkingOrder, "PO");
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
                            GetAll(strBoxId);
                        }
                    }
                    else
                    {
                        Ultils.EditTextErrorMessage(txtBoxID, "BOX ID ngắn quá!");
                        txtBoxID.SelectAll();
                    }

                }
            }

        }

        /// <summary>
        /// Add PCB
        /// </summary>
        private void EditTextAddPCB_PreviewKeyDown()
        {
            if (string.IsNullOrEmpty(txtAddPCB.Text))
            {
                Ultils.TextControlNotNull(txtAddPCB, "Add PCB");
            }
            else
            {
                string modelId = txtAddPCB.Text;
                if (CheckModels(modelId))
                {
                    AddPcbToBox(txtBoxID.Text);
                }
                else
                {
                    Ultils.EditTextErrorMessage(txtAddPCB, string.Format("PCB [{1}] này không giành cho Model [{0}] {2}", gridLookUpEditModelID.Text, txtAddPCB.Text, _currentModel.SerialNo));
                    txtAddPCB.SelectAll();
                }

            }
        }
        #endregion  

        private void gridLookUpEditModelID_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(gridLookUpEditModelID.Text))
            {
                txtWorkingOrder.Focus();
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnXuatLe_Click(object sender, EventArgs e)
        {
            var xuatLe = new RetailProducts();
            xuatLe.ShowDialog();

            ResetControls();
            VisibleControlAddPcb(false);
            _currentModel = new Model();
            _currentPo = new PackingPO();
        }


    }
}
