using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using BarcodeShipping.Data;
using BarcodeShipping.Services;
using DevExpress.XtraEditors;
using Lib.Core.Helper;
using System.Threading;

namespace BarcodeShipping.GUI
{
    public partial class FormMainV2 : Form
    {
        private IqcService _iqcService = new IqcService();
        private List<Shipping> _shippings = new List<Shipping>();
        private readonly List<Shipping> _pcbError = new List<Shipping>();
        private readonly OQCService _oqcService;
        private readonly ModelService _modelService;
        private Model _currentModel;
        private PackingPO _currentPo = new PackingPO();
        private string FujiXerox = "FujiXerox";
        private int quantityPO = 0;
        public FormMainV2()
        {
            InitializeComponent();
            _oqcService = new OQCService();
            _modelService = new ModelService();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //LoadGridLookupEditModel();
        }

        /// <summary>
        /// Get all PCB in Box
        /// </summary>
        private void GetAll(string boxId)
        {
            if (!_iqcService.CheckBoxExits(boxId))
            {
                splashScreenManager1.ShowWaitForm();
                var logs = _oqcService.GetLogsByBoxId(boxId).ToList();
                if (logs.Any())
                { 
                    foreach (var log in logs)
                    {
                        var shipping = new Shipping()
                        {
                            Operator = txtOperatorCode.Text,
                            Model = _currentModel.ModelID,
                            WorkingOder = txtWorkingOrder.Text,
                            Quantity = 1,
                            BoxID = txtBoxID.Text,
                            ProductID = log.ProductionID,
                            PO_NO = txtPO.Text,
                            MacAddress = log.MacAddress,
                            DateCheck = DateTime.Now.Date
                        };

                        if (_iqcService.GetShippingById(log.ProductionID) == null)
                        {
                            if (CheckModels(shipping.ProductID))
                            {
                                _shippings.Add(shipping);
                            }
                            else
                            {
                                _pcbError.Add(shipping);
                            }
                        }
                        else
                        {
                            MessageBoxHelper.ShowMessageBoxError($"{log.ProductionID} đã được xuất trước đó. Vui lòng kiểm tra lại!");
                            txtBoxID.Focus();
                            break;
                        }
                    }
                    if (_pcbError.Any())
                    {
                        gridControlData.DataSource = _shippings;
                        splashScreenManager1.CloseWaitForm();
                        MessageBoxHelper.ShowMessageBoxError($"Box [{boxId}] có {logs.Count} PCB\n" +
                                                             $"Có {_pcbError.Count} PCB không dành cho Model [{txtModel.Text}].\n" +
                                                             "Vui lòng kiểm tra lại!");
                        //EnableTextControls(false);
                        //VisibleControlAddPcb(true);
                        txtBoxID.SelectAll();
                        txtBoxID.Focus();
                    }
                    else
                    {
                        GetQtyPoAndRemainsByWorkingOderAndPoNo(_currentModel.ModelID, txtPO.EditValue.ToString());
                        lblCountPCB.Text = _shippings.Count.ToString(CultureInfo.InvariantCulture);
                        lblRemains.Text = (_currentPo.QuantityRemain - _shippings.Count).ToString(CultureInfo.InvariantCulture);
                        Thread.Sleep(200);
                        // Nếu số lượng đủ thì thực hiện lưu vào csdl
                        if (_shippings.Count == _currentModel.Quantity)
                        {
                            gridControlData.DataSource = _shippings;
                            splashScreenManager1.CloseWaitForm();
                            splashScreenManager2.ShowWaitForm();
                            foreach (var log in _shippings)
                            {
                                _iqcService.InsertShipping(txtOperatorCode.Text, _currentModel.ModelID, txtWorkingOrder.Text, 1, txtPO.Text, txtBoxID.Text, log.ProductID, log.MacAddress);
                            }
                            _iqcService.UpdateRemainsForPo(_currentPo.PO_NO, _currentPo.ModelID, int.Parse(lblRemains.Text));
                            splashScreenManager2.CloseWaitForm();
                            InsertOrUpdatePo(_currentModel.ModelID, _currentModel.ModelName, txtPO.Text);
                            gridControlData.DataSource = null;
                            _shippings = new List<Shipping>();
                            txtModel.Focus();
                            txtModel.ResetText();
                            txtBoxID.ResetText();
                            lblCountPCB.Text = @"0";
                        }
                        else
                        {
                            if (_shippings.Count > _currentModel.Quantity)
                            {
                                int count = _shippings.Count - _currentModel.Quantity;
                                gridControlData.Refresh();
                                gridControlData.DataSource = _shippings;
                                splashScreenManager1.CloseWaitForm();
                                MessageBoxHelper.ShowMessageBoxError($"Vui lòng kiểm tra lại Box [{boxId}]\n." +
                                                                     $"Số lượng lớn hơn quy định {count} PCB!");
                                txtBoxID.SelectAll();

                            }
                            else
                            {
                                gridControlData.Refresh();
                                gridControlData.DataSource = _shippings;
                                splashScreenManager1.CloseWaitForm();
                                MessageBoxHelper.ShowMessageBoxWaring($"Số lượng trong Box [{boxId}] chưa đủ. Vui lòng nhập thêm!");
                                VisibleControlAddPcb(true);
                                EnableTextControls(false);
                            }
                        } 
                    }

                }
                else
                {
                    splashScreenManager1.CloseWaitForm();
                    if (XtraMessageBox.Show("Vui lòng bắn từng PCB vào Box [" + boxId + "]!", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
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
                Ultils.EditTextErrorMessage(txtBoxID, $"Box [{boxId}] đã được nhập trước đó. Vui lòng kiểm tra lại!");
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
            string addPcb = txtAddPCB.Text.Trim();
            if (!string.IsNullOrEmpty(addPcb))
            {
                if (_iqcService.CheckPcbExitsOnBoxOrShipCurrent(addPcb, _shippings))
                {
                    var ship = _iqcService.GetShippingById(addPcb);
                    if (ship == null)
                    {
                        var shipping = new Shipping()
                        {
                            ID = Guid.NewGuid(),
                            Operator = txtOperatorCode.Text,
                            Model = _currentModel.ModelID,
                            WorkingOder = txtWorkingOrder.Text,
                            Quantity = 1,
                            BoxID = boxid,
                            ProductID = addPcb,
                            PO_NO = txtPO.Text,
                            MacAddress = txtAddPCB.Text,
                            DateCheck = DateTime.Now,
                        };
                        _shippings.Add(shipping);

                        gridControlData.DataSource = _shippings;
                        lblCountPCB.Text = _shippings.Count.ToString(CultureInfo.InvariantCulture);
                        lblRemains.Text = (int.Parse(lblRemains.Text) - 1).ToString(CultureInfo.InvariantCulture);

                        if (_shippings.Count == _currentModel.Quantity)
                        {
                            gridControlData.DataSource = _shippings;
                            InsertOrUpdatePo(_currentModel.ModelID, _currentModel.ModelName, txtPO.Text);
                            splashScreenManager2.ShowWaitForm();
                            foreach (var log in _shippings)
                            {
                                _iqcService.InsertShipping(txtOperatorCode.Text, _currentModel.ModelID, txtWorkingOrder.Text, 1, txtPO.Text, txtBoxID.Text, log.ProductID, log.MacAddress);
                            }
                            _iqcService.UpdateRemainsForPo(_currentPo.PO_NO, _currentPo.ModelID, int.Parse(lblRemains.Text));
                            splashScreenManager2.CloseWaitForm();

                            EnableTextControls(true);
                            VisibleControlAddPcb(false);
                            txtBoxID.ResetText();
                            txtBoxID.Focus();
                            lblCountPCB.Text = @"0";
                            gridControlData.DataSource = null;
                            _shippings = new List<Shipping>();
                        }
                    }
                    else
                    {
                        gridControlData.Refresh();
                        gridControlData.DataSource = _shippings;
                        MessageBoxHelper.ShowMessageBoxError($"PCB {txtAddPCB.Text} đã được xuất trước đó.\n" +
                                                             $"Box: {ship.BoxID}\n" +
                                                             $"Ngày xuất: {ship.DateCheck}");
                        txtAddPCB.SelectAll();
                    }
                }
                else
                {
                    gridControlData.Refresh();
                    gridControlData.DataSource = _shippings;
                    MessageBoxHelper.ShowMessageBoxError($"PCB {txtAddPCB.Text} đã được nhập trong Box rồi. Vui lòng kiểm tra lại!");
                    txtAddPCB.SelectAll();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelId"></param>
        /// <param name="poNo"></param>
        private void InsertOrUpdatePo(string modelId, string modelName, string poNo)
        {
            if (_currentPo.QuantityRemain <= _currentModel.Quantity || _currentPo.QuantityRemain <= 0)
            {
                if (XtraMessageBox.Show(
                    $"Bạn có muốn nhập thêm QTY PO cho PO [{poNo}] này không?",
                    "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    var addPo = new FormAddPO(modelId, modelName, poNo);
                    addPo.ShowDialog();
                    txtBoxID.Focus();
                    GetQtyPoAndRemainsByWorkingOderAndPoNo(modelId, poNo);
                }
                else
                {
                    txtBoxID.Focus();
                    txtBoxID.SelectAll();
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
        /// Reset Default Controls
        /// </summary>
        private void ResetControls()
        {
            txtOperatorCode.Focus();
            txtOperatorCode.Text = string.Empty;
            txtModel.Text = string.Empty;
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
        /// <param name="productionId"></param>
        /// <returns></returns>
        private bool CheckModels(string productionId)
        {
            if (productionId != null)
            {
                if (productionId.Contains(_currentModel.SerialNo) && productionId.Contains(_currentModel.ModelName))
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
            if(e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(txtOperatorCode.Text))
                {
                    Ultils.TextControlNotNull(txtOperatorCode, "Operator code");
                }
                else
                {
                    txtWorkingOrder.Focus();
                }  
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
        }
        private void txtPO_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
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
        }
        private void txtModel_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(txtModel.Text))
                {
                    Ultils.TextControlNotNull(txtModel, "Model");
                }
                else if (string.IsNullOrEmpty(txtPO.Text))
                {
                    Ultils.TextControlNotNull(txtPO, "PO");
                }
                else
                {
                    string input = txtModel.Text.Trim();
                    string po_no = txtPO.Text.Trim();

                    if (input.Length > 6 && input.Substring(0, 3) == "3N4")
                    {
                        input = input.Remove(0, 3);
                        string[] array = input.Split(separator: new[] { " " }, count: 4, options: StringSplitOptions.None);
                        string model = $"{array[0]} {array[1]}";

                        _currentModel = _modelService.GetModelByName(model, FujiXerox);

                        if (_currentModel != null)
                        {
                            lblQuantityModel.Text = $"/{_currentModel.Quantity}";

                            if (!string.IsNullOrEmpty(po_no))
                            {
                                if (!GetQtyPoAndRemainsByWorkingOderAndPoNo(_currentModel.ModelID, po_no))
                                {
                                    _iqcService.InsertPo(_currentModel.ModelID, po_no, quantityPO, txtOperatorCode.Text);
                                    GetQtyPoAndRemainsByWorkingOderAndPoNo(_currentModel.ModelID, po_no);
                                }
                                else
                                {
                                    InsertOrUpdatePo(_currentModel.ModelID, model, po_no);
                                }
                                txtModel.Text = model;
                                txtBoxID.Focus();
                            }
                            else
                            {
                                Ultils.EditTextErrorMessage(txtModel, "PO NO không được để trống. Vui lòng bắn nhập vào PO NO!");
                            }
                        }
                        else
                        {
                            Ultils.EditTextErrorMessage(txtModel, "Model không tồn tại. Vui lòng kiểm tra lại!");
                            txtModel.ResetText();
                            txtModel.Focus();
                        }
                    }
                    else
                    {
                        Ultils.EditTextErrorMessage(txtModel, "Model không đúng định dạng. Vui lòng bắn lại!");
                    }
                }
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
        private void txtModel_EditValueChanged(object sender, EventArgs e)
        {
            Ultils.SetColorDefaultTextControl(txtModel);
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
                    txtBoxID.SelectAll();
                }
            }
        }

        private void txtModel_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtModel.Text))
            {
                Ultils.TextControlNotNull(txtModel, "Model");
            }
            else if (string.IsNullOrEmpty(txtPO.Text))
            {
                Ultils.TextControlNotNull(txtPO, "PO");
            }
            else
            {
                string input = txtModel.Text.Trim();
                string po_no = txtPO.Text.Trim();

                if (input.Length > 6 && input.Substring(0, 3) == "3N4")
                {
                    input = input.Remove(0, 3);
                    string[] array = input.Split(separator: new[] { " " }, count: 4, options: StringSplitOptions.None);
                    string model = $"{array[0]} {array[1]}";

                    _currentModel = _modelService.GetModelByName(model, FujiXerox);

                    if (_currentModel != null)
                    {
                        lblQuantityModel.Text = $"/{_currentModel.Quantity}";

                        if (!string.IsNullOrEmpty(po_no))
                        {
                            if (!GetQtyPoAndRemainsByWorkingOderAndPoNo(_currentModel.ModelID, po_no))
                            {
                                _iqcService.InsertPo(_currentModel.ModelID, po_no, quantityPO, txtOperatorCode.Text);
                                GetQtyPoAndRemainsByWorkingOderAndPoNo(_currentModel.ModelID, po_no);
                            }
                            else
                            {
                                InsertOrUpdatePo(_currentModel.ModelID, model, po_no);
                            }
                            txtModel.Text = model;
                            txtBoxID.Focus();
                        }
                        else
                        {
                            Ultils.EditTextErrorMessage(txtModel, "PO NO không được để trống. Vui lòng bắn nhập vào PO NO!");
                        }
                    }
                    else
                    {
                        Ultils.EditTextErrorMessage(txtModel, "Model không tồn tại. Vui lòng kiểm tra lại!");
                        txtModel.ResetText();
                        txtModel.Focus();
                    }
                }
                else
                {
                    Ultils.EditTextErrorMessage(txtModel, "Model không đúng định dạng. Vui lòng bắn lại!");
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
            var saveFileDialog1 = new SaveFileDialog
            {
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
        #region Control validate
        

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
                if(strPo.Contains(" "))
                {
                    string[] input = strPo.Split(separator: new[] { " " }, count: 4, options: StringSplitOptions.None);
                    string po_no = input[0];
                    string remains = input[1];

                    if (po_no.Length >= 3)
                    {
                        if (po_no.Substring(0, 3).ToUpper() != "3N3")
                        {
                            Ultils.EditTextErrorMessage(txtPO, "PO phải bắt đầu bằng 3N3");
                            txtPO.SelectAll();
                        }
                        else
                        {
                            txtPO.Text = po_no;
                            lblQtyPO.Text = remains;
                            quantityPO = Convert.ToInt32(remains);
                            txtModel.Focus();
                        }
                    }
                    else
                    {
                        Ultils.EditTextErrorMessage(txtPO, "PO NO không đúng!");
                    }
                }
                else
                {
                    Ultils.EditTextErrorMessage(txtPO, "PO NO không đúng định dạng!");
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
                else if (string.IsNullOrEmpty(txtWorkingOrder.Text))
                {
                    Ultils.TextControlNotNull(txtWorkingOrder, "Working oder");
                }
                else if (string.IsNullOrEmpty(txtPO.Text))
                {
                    Ultils.TextControlNotNull(txtWorkingOrder, "PO");
                }
                else if (string.IsNullOrEmpty(txtModel.Text))
                {
                    Ultils.TextControlNotNull(txtModel, "Model");
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
                string productionId = txtAddPCB.Text.Trim();
                if (CheckModels(productionId))
                {
                    AddPcbToBox(txtBoxID.Text.Trim());
                }
                else
                {
                    Ultils.EditTextErrorMessage(txtAddPCB, string.Format("PCB [{1}] này không giành cho Model [{0}] {2}", txtModel.Text, txtAddPCB.Text, _currentModel.SerialNo));
                    txtAddPCB.SelectAll();
                }

            }
        }
        #endregion  

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
        private void btnVersionOld_Click(object sender, EventArgs e)
        {
            var old = new FormMain();
            old.ShowDialog();

            ResetControls();
            VisibleControlAddPcb(false);
            _currentModel = new Model();
            _currentPo = new PackingPO();
        }

        
    }
}
