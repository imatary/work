using System;
using System.ComponentModel;
using System.Windows.Forms;
using BarcodeShipping.Data;
using BarcodeShipping.Services;
using OQC.Helper;

namespace OQC
{
    public partial class FormQALogin : Form
    {
        private readonly OQCService _oqcService;
        private mst_operator _operator;
        public FormQALogin()
        {
            InitializeComponent();
            _oqcService = new OQCService();
        }

        private void txtOperatorID_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(txtOperatorID.Text))
                {
                    Ultils.TextControlNotNull(txtOperatorID, "Operator ID");
                }
                else
                {
                    txtLineID.Focus();
                }
            }
            if (e.KeyCode == Keys.Tab)
            {
                if (string.IsNullOrEmpty(txtOperatorID.Text))
                {
                    Ultils.TextControlNotNull(txtOperatorID, "Operator ID");
                }
                else
                {
                    txtLineID.Focus();
                }
            }

        }
        private void txtLineID_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(txtLineID.Text))
                {
                    Ultils.TextControlNotNull(txtLineID, "Line");
                }
                else
                {
                    int line = int.Parse(txtLineID.Text.Trim());
                    if (line > 20)
                    {
                        Ultils.EditTextErrorMessage(txtLineID, "Line error!");
                    }
                    else
                    {
                        txtOperationID.Focus();
                    }
                }
            }
            if (e.KeyCode == Keys.Tab)
            {
                if (string.IsNullOrEmpty(txtLineID.Text))
                {
                    Ultils.TextControlNotNull(txtLineID, "Line");
                }
                else
                {
                    int line = int.Parse(txtLineID.Text.Trim());
                    if (line > 20)
                    {
                        Ultils.EditTextErrorMessage(txtLineID, "Line error!");
                    }
                    else
                    {
                        txtOperationID.Focus();
                    }
                }
            }
        }
        private void txtOperationID_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(txtOperationID.Text))
                {
                    Ultils.TextControlNotNull(txtOperationID, "Operation ID");
                }
                else
                {
                    int op = int.Parse(txtOperationID.Text.Trim());
                    if (op > 3)
                    {
                        Ultils.EditTextErrorMessage(txtOperationID, "OperationID error!");
                    }
                    else
                    {
                        btnLogin.PerformClick();
                    }
                }
            }
            if (e.KeyCode == Keys.Tab)
            {
                if (string.IsNullOrEmpty(txtOperationID.Text))
                {
                    Ultils.TextControlNotNull(txtOperationID, "OperationID");
                }
                else
                {
                    int op = int.Parse(txtOperationID.Text.Trim());
                    if (op > 3)
                    {
                        Ultils.EditTextErrorMessage(txtOperationID, "OperationID error!");
                    }
                    else
                    {
                        btnLogin.PerformClick();
                    }
                }
            }
        }

        private void txtOperatorID_EditValueChanged(object sender, EventArgs e)
        {
            Ultils.SetColorDefaultTextControl(txtOperationID);
        }

        private void txtLineID_EditValueChanged(object sender, EventArgs e)
        {
            Ultils.SetColorDefaultTextControl(txtLineID);
        }

        private void txtOperationID_EditValueChanged(object sender, EventArgs e)
        {
            Ultils.SetColorDefaultTextControl(txtOperationID);
        }

        private void txtOperatorID_Validating(object sender, CancelEventArgs e)
        {
            string operatorCode = txtOperatorID.Text;
            if (string.IsNullOrEmpty(operatorCode))
            {
                Ultils.TextControlNotNull(txtOperatorID, "Operator");
                txtOperatorID.SelectAll();
            }
            else
            {
                _operator = _oqcService.GetOperatorByCode(operatorCode);
                if (_operator == null)
                {
                    Ultils.EditTextErrorMessage(txtOperatorID, "Opeator code không tồn tại trong hệ thống!");
                }
                else
                {
                    txtLineID.Focus();
                }
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtOperatorID.Text))
            {
                Ultils.TextControlNotNull(txtOperatorID, "Operator ID");
            }
            else if (string.IsNullOrEmpty(txtLineID.Text))
            {
                Ultils.TextControlNotNull(txtLineID, "Line ID");
            }
            else if (string.IsNullOrEmpty(txtOperationID.Text))
            {
                Ultils.TextControlNotNull(txtOperationID, "Operation ID");
            }
            else
            {
                var user = new User()
                {
                    OperatorCode = _operator.OperatorID,
                    OperatorName = _operator.OperatorName,
                    LineID = int.Parse(txtLineID.EditValue.ToString()),
                    OperationID = int.Parse(txtOperationID.EditValue.ToString())
                };

                Program.CurrentUser = user;
                Hide();
                if (Program.CurrentUser != null)
                {
                    //var qa = new FormQA();
                    var qa = new FormQA();
                    qa.ShowDialog();
                }
                
            }
        }
    }
}
