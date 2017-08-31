using System;
using System.Windows.Forms;
using UMC.Entities;
using UMC.Services;

namespace VI_FujiXerox
{
    public partial class FormLogin : Form
    {
        private mst_operatorService mst_OperatorService;
        int operatorId = 0;
        int lineId = 0;
        int operationId = 0;
        public FormLogin()
        {
            InitializeComponent();

            mst_OperatorService = new mst_operatorService();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            operatorId = txtOperatorID.Value;
            operationId = txtOperationID.Value;
            lineId = txtLineID.Value;
            if(operatorId <= 0)
            {
                SetErrorToControls(errorProvider1, txtOperatorID, "Vui lòng nhập vào Operator ID!");
                return;
            }
            if(operationId <= 0)
            {
                SetErrorToControls(errorProvider1, txtOperationID, "Vui lòng nhập vào Operation ID!");
                return;        
            }
            if(lineId <= 0)
            {
                SetErrorToControls(errorProvider1, txtLineID, "Vui lòng nhập vào Line ID!");
                return;
            }

            var checkExists = mst_OperatorService.GetSingle(operatorId.ToString());
            var user = new Login()
            {
                OperatorCode = checkExists.OperatorID,
                OperatorName = checkExists.OperatorName,
                LineID = lineId,
                OperationID = operationId,
                ProcessID = "VI_FUJ",
            };

            Program.CurrentUser = user;
            Hide();
            if (Program.CurrentUser != null)
            {
                var qa = new FormMain();
                qa.ShowDialog();
            }
        }

        private void txtOperatorID_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                operatorId = txtOperatorID.Value;
                if(operatorId > 0)
                {
                    var checkExists = mst_OperatorService.GetSingle(operatorId.ToString());
                    if (checkExists != null)
                    {
                        txtLineID.Focus();
                    }
                    else
                    {
                        SetErrorToControls(errorProvider1, txtOperatorID, "Operator ID không tồn tại. Vui lòng kiểm tra lại!");
                    }
                }
                else
                {
                    SetErrorToControls(errorProvider1, txtOperatorID, "Vui lòng nhập vào Operator ID!");
                }
            }
        }

        private void txtLineID_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                lineId = txtLineID.Value;
                if(lineId > 0)
                {
                    txtOperationID.Focus();
                }
                else
                {
                    SetErrorToControls(errorProvider1, txtLineID, "Vui lòng nhập vào Line ID!");
                }
            }
        }

        private void txtOperationID_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                operationId = txtOperationID.Value;
                if (operationId > 0)
                {
                    btnLogin.Focus();
                    btnLogin.PerformClick();
                }
                else
                {
                    SetErrorToControls(errorProvider1, txtOperationID, "Vui lòng nhập vào Operation ID!");
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="errorProvider"></param>
        /// <param name="control"></param>
        /// <param name="message"></param>
        private void SetErrorToControls(ErrorProvider errorProvider, Control control, string message)
        {
            errorProvider.SetError(control, message);
            control.Focus();
        }

        private void txtOperatorID_ValueChanged(object sender, EventArgs e)
        {
            operatorId = txtOperatorID.Value;
            if(operatorId > 0)
            {
                errorProvider1.Clear();
            }
        }

        private void txtLineID_ValueChanged(object sender, EventArgs e)
        {
            lineId = txtLineID.Value;
            if(lineId > 0)
            {
                errorProvider1.Clear();
            }
        }

        private void txtOperationID_ValueChanged(object sender, EventArgs e)
        {
            operationId = txtOperationID.Value;
            if (operationId > 0)
            {
                errorProvider1.Clear();
            }
        }
    }
}
