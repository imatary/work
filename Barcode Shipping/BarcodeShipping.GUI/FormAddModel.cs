﻿using System;
using System.Windows.Forms;
using BarcodeShipping.Services;
using Lib.Core.Helper;


namespace BarcodeShipping.GUI
{
    public partial class FormAddModel : Form
    {
        private readonly ModelService _modelService;
        private string FujiXerox = "FujiXerox";
        public FormAddModel(string modelId, string modelName, string operatorCode)
        {
            InitializeComponent();
            _modelService = new ModelService();
            if (!string.IsNullOrEmpty(modelName) && !string.IsNullOrEmpty(operatorCode))
            {
                lblModelID.Text = modelId;
                txtModelID.Text = modelName;
                txtOperatorCode.Text = operatorCode;
                txtQuantity.Focus();
            }
            else if (string.IsNullOrEmpty(modelName) && !string.IsNullOrEmpty(operatorCode))
            {
                txtOperatorCode.Text = operatorCode;
                txtQuantity.Focus();
            }
        }

        private void FormAddModel_Load(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Lưu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtModelID.Text))
            {
                Ultils.SetColorErrorTextControl(txtModelID, "Model");
            }
            else if(string.IsNullOrEmpty(txtQuantity.Text))
            {
                Ultils.SetColorErrorTextControl(txtQuantity, "Quantity");
            }
            else if (string.IsNullOrEmpty(txtOperatorCode.Text))
            {
                Ultils.SetColorErrorTextControl(txtOperatorCode, "Operator");
            }
            else if (string.IsNullOrEmpty(txtSerialNo.Text))
            {
                Ultils.SetColorErrorTextControl(txtSerialNo, "Serial No");
            }
            else
            {
                try
                {
                    _modelService.InsertModel(lblModelID.Text, txtOperatorCode.Text, int.Parse(txtQuantity.Text), txtSerialNo.Text);
                    MessageBoxHelper.ShowMessageBoxSuccess("Thành công!");
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBoxHelper.ShowMessageBoxError(ex.Message);
                }
            } 
        }

        private void txtModelID_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(txtModelID.Text))
                {
                    Ultils.TextControlNotNull(txtModelID, "Model");
                }
                else
                {
                    var model = _modelService.GetModelByName(txtModelID.Text, FujiXerox);
                    if(model != null)
                    {
                        Ultils.SetColorErrorTextControl(txtModelID, "Model này đã được tạo rồi. Vui lòng kiểm tra lại!");
                        
                    }
                    else
                    {
                        txtQuantity.Focus();
                    }
                }
            }
            if (e.KeyCode == Keys.Tab)
            {
                if (string.IsNullOrEmpty(txtModelID.Text))
                {
                    Ultils.TextControlNotNull(txtModelID, "Model");
                }
            }
        }

        private void txtQuantity_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(txtQuantity.Text))
                {
                    Ultils.TextControlNotNull(txtQuantity, "Quantity");
                }
                else
                {
                    txtOperatorCode.Focus();
                }
            }
            if (e.KeyCode == Keys.Tab)
            {
                if (string.IsNullOrEmpty(txtQuantity.Text))
                {
                    Ultils.TextControlNotNull(txtQuantity, "Quantity");
                }
            }
        }

        private void txtOperatorCode_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(txtOperatorCode.Text))
                {
                    Ultils.TextControlNotNull(txtOperatorCode, "Operator");
                }
                else
                {
                    txtSerialNo.Focus();
                }
            }
            if (e.KeyCode == Keys.Tab)
            {
                if (string.IsNullOrEmpty(txtOperatorCode.Text))
                {
                    Ultils.TextControlNotNull(txtOperatorCode, "Operator");
                }
                txtSerialNo.Focus();
            }
        }

        private void txtSerialNo_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(txtSerialNo.Text))
                {
                    Ultils.TextControlNotNull(txtSerialNo, "Serial No");
                }
                else
                {
                    btnSave.Focus();
                }
            }
            if (e.KeyCode == Keys.Tab)
            {
                if (string.IsNullOrEmpty(txtSerialNo.Text))
                {
                    Ultils.TextControlNotNull(txtSerialNo, "Serial No");
                }
                btnSave.Focus();
            }
        }
        private void txtModelID_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void txtModelID_EditValueChanged(object sender, EventArgs e)
        {
            Ultils.SetColorDefaultTextControl(txtModelID);
        }

        private void txtQuantity_EditValueChanged(object sender, EventArgs e)
        {
            Ultils.SetColorDefaultTextControl(txtQuantity);
        }

        private void txtOperatorCode_EditValueChanged(object sender, EventArgs e)
        {
            Ultils.SetColorDefaultTextControl(txtOperatorCode);
        }

        private void txtSerialNo_EditValueChanged(object sender, EventArgs e)
        {
            Ultils.SetColorDefaultTextControl(txtSerialNo);
        }

        
    }
}
