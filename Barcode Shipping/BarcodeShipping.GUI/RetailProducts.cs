using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using BarcodeShipping.Data;
using BarcodeShipping.Services;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Base;
using Lib.Core.Helper;

namespace BarcodeShipping.GUI
{
    public partial class RetailProducts : Form
    {
        private readonly IqcService _iqcService = new IqcService();
        private List<Shipping> _shippings = new List<Shipping>();
        private Model _currentModel;
        private PackingPO _currentPo;
        private readonly ModelService _modelService;
        public RetailProducts()
        {
            InitializeComponent();
            _modelService = new ModelService();
        }

        private void RetailProducts_FormClosing(object sender, FormClosingEventArgs e)
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
                    Hide();
                }
            }
        }

        private void RetailProducts_Load(object sender, EventArgs e)
        {
            LoadGridLookupEditModel();
            EnabledButonSave(false);
        }

        private void gridView1_CustomColumnDisplayText(object sender, CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.Caption == @"#")
            {
                e.DisplayText = (e.ListSourceRowIndex + 1).ToString(CultureInfo.InvariantCulture);
            }
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


        /// <summary>
        /// Trả về QtyPO và Remains theo workingOder và PoNo
        /// </summary>
        /// <param name="modelNo">Model</param>
        /// <param name="poNo">PO</param>
        private bool GetQtyPoAndRemainsByWorkingOderAndPoNo(string modelNo, string poNo)
        {
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
            gridLookUpEditModelID.Properties.DataSource = _modelService.GetModels();
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
        private void VisibleControlAddPCB(bool visible)
        {
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
                if (modelId.Contains(_currentModel.SerialNo))
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        /// <summary>
        /// Enable Button
        /// </summary>
        /// <param name="enabled"></param>
        private void EnabledButonSave(bool enabled)
        {
            btnSave.Enabled = enabled;
            btnSaveAndClose.Enabled = enabled;
        }

        /// <summary>
        /// Lưu dữ liệu
        /// </summary>
        private void SaveData()
        {
            splashScreenManagerSaveData.ShowWaitForm();
            foreach (var log in _shippings)
            {
                _iqcService.InsertShipping(txtOperatorCode.Text, gridLookUpEditModelID.Text, txtWorkingOrder.Text, 1, txtPO.Text, txtBoxID.Text, log.ProductID, log.MacAddress);
            }
            // cập nhật lại số lượng Remains
            _iqcService.UpdateRemainsForPo(_currentPo.PO_NO, _currentPo.ModelID, int.Parse(lblRemains.Text));
            
            _shippings = new List<Shipping>();
            gridControlData.DataSource = null;
            EnableTextControls(true);
            VisibleControlAddPCB(false);
            EnabledButonSave(false);
            ResetControls();
            splashScreenManagerSaveData.CloseWaitForm();
        }

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
                var curentModel = _modelService.GetModelById(gridLookUpEditModelID.Text);
                if (curentModel != null)
                {
                    _currentModel = curentModel;
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
                string removePo = null;

                int index = strPo.IndexOf(' ');
                removePo = index >= 0 ? strPo.Remove(index) : txtPO.Text;
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
                                var addPo = new FormAddPO(gridLookUpEditModelID.EditValue.ToString(), gridLookUpEditModelID.Text, removePo);
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
                            if (_currentPo.QuantityRemain <= 0)
                            {
                                MessageBoxHelper.ShowMessageBoxWaring("PO đã được nhập đủ. Vui lòng nhập PO khác!");
                                gridLookUpEditModelID.Focus();
                                txtPO.ResetText();
                                lblQtyPO.Text = "0";
                                lblRemains.Text = "0";
                                lblQuantityModel.Text = "/0";
                            }
                            else
                            {
                                txtPO.Text = removePo;
                                Ultils.SetColorDefaultTextControl(txtPO);
                                txtBoxID.Focus();
                            }
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
                            EnableTextControls(false);
                            VisibleControlAddPCB(true);
                            txtAddPCB.Focus();
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
                    if (_currentPo.QuantityRemain <= 0)
                    {
                        MessageBoxHelper.ShowMessageBoxWaring("PO đã được nhập đủ, bạn không thể tiếp tục. Vui lòng nhập PO khác!");
                        gridLookUpEditModelID.Focus();
                        txtPO.ResetText();
                        lblQtyPO.Text = "0";
                        lblRemains.Text = "0";
                        lblQuantityModel.Text = "/0";
                    }
                    else
                    {
                        AddPcbToBox(txtBoxID.Text);
                    }
                }
                else
                {
                    Ultils.EditTextErrorMessage(txtAddPCB, string.Format("PCB [{1}] này không giành cho Model [{0}] {2}", gridLookUpEditModelID.Text, txtAddPCB.Text, _currentModel.SerialNo));
                    txtAddPCB.SelectAll();
                }

            }
        }
        #endregion 


        /// <summary>
        /// Add PCB into Box
        /// </summary>
        /// <param name="boxid"></param>
        private void AddPcbToBox(string boxid)
        {
            splashScreenLoadData.ShowWaitForm();
            gridControlData.DataSource = null;
            if (!string.IsNullOrEmpty(txtAddPCB.Text))
            {
                if (_iqcService.CheckPcbExitsOnBoxOrShip(txtAddPCB.Text, _shippings))
                {
                    var shippings = _iqcService.GetShippingById(txtAddPCB.Text.Trim());
                    if (shippings == null)
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
                            MacAddress = txtAddPCB.Text,
                            DateCheck = DateTime.Now,
                        };

                        if (_currentPo.QuantityRemain <= 0)
                        {
                            MessageBox.Show(@"Không thể nhập thêm cho PO này. Remain = 0\nVui lòng lưu lại dữ liệu!", @"Error Remains!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            ResetControls();

                        }
                        else
                        {
                            _shippings.Add(shipping);
                            gridControlData.DataSource = _shippings;
                            lblCountPCB.Text = _shippings.Count.ToString(CultureInfo.InvariantCulture);
                            lblRemains.Text = (int.Parse(lblRemains.Text) - 1).ToString(CultureInfo.InvariantCulture);
                            EnabledButonSave(true);
                            splashScreenLoadData.CloseWaitForm();
                            txtAddPCB.Text = string.Empty;
                        }
                    }
                    else
                    {
                        gridControlData.Refresh();
                        gridControlData.DataSource = _shippings;
                        splashScreenLoadData.CloseWaitForm();
                        MessageBoxHelper.ShowMessageBoxError($"PCB {txtAddPCB.Text} đã được xuất trước đó.\n" +
                                                             $"Box: {shippings.BoxID}\nN" +
                                                             $"Ngày xuất: {shippings.DateCheck}");
                        txtAddPCB.SelectAll();
                    }
                }
                else
                {
                    gridControlData.Refresh();
                    gridControlData.DataSource = _shippings;
                    splashScreenLoadData.CloseWaitForm();
                    MessageBoxHelper.ShowMessageBoxError($"PCB {txtAddPCB.Text} đã được nhập trong Box rồi. Vui lòng kiểm tra lại!");
                    txtAddPCB.SelectAll();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void btnSaveAndClose_Click(object sender, EventArgs e)
        {
            SaveData();
            Close();
        }
    }
}
