using System;
using System.ComponentModel;
using System.Windows.Forms;
using BarcodeShipping.Data;
using BarcodeShipping.Services;
using Microsoft.Win32;
using Lib.Core.Helper;

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
            LoadRegistry();
            RegisterInStartup(true);
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
                        if (string.IsNullOrEmpty(txtProcess.Text.Trim()))
                        {
                            txtProcess.Focus();
                        }
                        else
                        {
                            btnLogin.Focus();
                        }
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
            dxErrorProvider1.ClearErrors();
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
        private void txtLineID_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtLineID.Text))
            {
                dxErrorProvider1.SetError(txtLineID, "Error! Line value required.");
                Ultils.EditTextErrorNoMessage(txtLineID);
            }
            else
            {
                int value = 0;
                if(!int.TryParse(txtLineID.Text, out value))
                {
                    dxErrorProvider1.SetError(txtLineID, "Error! Line value faild.");
                    Ultils.EditTextErrorNoMessage(txtLineID);
                }
                else
                {
                    if(value > 20)
                    {
                        dxErrorProvider1.SetError(txtLineID, "Error! Line value faild.");
                        Ultils.EditTextErrorNoMessage(txtLineID);
                    }
                    else
                    {
                        txtOperationID.Focus();
                    }
                }
            }
        }

        private void txtOperationID_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtOperationID.Text))
            {
                dxErrorProvider1.SetError(txtOperationID, "Error! Operation value required.");
                Ultils.EditTextErrorNoMessage(txtOperationID);
            }
            else
            {
                int value = 0;
                if (!int.TryParse(txtOperationID.Text, out value))
                {
                    dxErrorProvider1.SetError(txtOperationID, "Error! Line value faild.");
                    Ultils.EditTextErrorNoMessage(txtOperationID);
                }
                else
                {
                    if (value > 3)
                    {
                        dxErrorProvider1.SetError(txtOperationID, "Error! Operation value faild.");
                        Ultils.EditTextErrorNoMessage(txtOperationID);
                    }
                    else
                    {
                        txtProcess.Focus();
                    }
                }
            }
        }
        private void txtProcess_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtProcess.Text))
            {
                dxErrorProvider1.SetError(txtProcess, "Error! Process value required.");
                Ultils.EditTextErrorNoMessage(txtProcess);
            }
            else
            {
                btnLogin.PerformClick();
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
                    OperationID = int.Parse(txtOperationID.EditValue.ToString()),
                    ProcessID = txtProcess.Text,
                };
                SaveRegistry();
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


        /// <summary>
        /// Lưu Mật Khẩu Và Tên Đăng nhập
        /// </summary>
        private void SaveRegistry()
        {
            //if (chkRemember.Checked)
            //{

            //    Registry.SetValue(@"HKEY_CURRENT_USER\Software\StockManager\SaveUserAndPassword", "IsRemember", "1");
            //    Registry.SetValue(@"HKEY_CURRENT_USER\Software\StockManager\SaveUserAndPassword", "Username", txtUsername.Text);
            //    Registry.SetValue(@"HKEY_CURRENT_USER\Software\StockManager\SaveUserAndPassword", "Password", txtPassword.Text);
            //}
            //else
            //{
            Registry.SetValue(@"HKEY_CURRENT_USER\Software\BarcodeSystem\ProcessValue", "ProcessName", txtProcess.Text);
                //Registry.SetValue(@"HKEY_CURRENT_USER\Software\StockManager\SaveUserAndPassword", "Username", "");
                //Registry.SetValue(@"HKEY_CURRENT_USER\Software\StockManager\SaveUserAndPassword", "Password", "");
            //}
        }

        private void LoadRegistry()
        {
            //txtUsername.Text = (string)(Registry.GetValue(@"HKEY_CURRENT_USER\Software\StockManager\SaveUserAndPassword", "Username", null));
            txtProcess.Text = (string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\BarcodeSystem\ProcessValue", "ProcessName", null);

            //if ((string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\StockManager\SaveUserAndPassword", "IsRemember", null) == "1")
            //{
            //    chkRemember.Checked = true;
            //}
            //if ((string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\StockManager\SaveUserAndPassword", "IsRemember", null) == "0")
            //{
            //    chkRemember.Checked = false;
            //}
        }

        private void txtProcess_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (string.IsNullOrEmpty(txtProcess.Text))
                {
                    dxErrorProvider1.SetError(txtProcess, "Error! Process value required.");
                    Ultils.EditTextErrorNoMessage(txtProcess);
                }
                else
                {
                    btnLogin.PerformClick();
                }
            }
        }

        

        private void RegisterInStartup(bool isChecked)
        {
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey
                    ("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (isChecked)
            {
                registryKey.SetValue("ApplicationName", Application.ExecutablePath);
            }
            else
            {
                registryKey.DeleteValue("ApplicationName");
            }
        }
    }
}
