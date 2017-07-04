using System;
using System.ComponentModel;
using System.Windows.Forms;
using BarcodeShipping.Data;
using Lib.Core.Helper;

namespace MurataSystem
{
    public partial class FormLogin : Form
    {
        private mst_operator _operator;
        public FormLogin()
        {
            InitializeComponent();
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
                    btnLogin.Focus();
                }
            }

        }
        private void txtOperatorID_EditValueChanged(object sender, EventArgs e)
        {
            Ultils.SetColorDefaultTextControl(txtOperatorID);
            if (!string.IsNullOrEmpty(txtOperatorID.Text))
            {
                txtOperatorID.Properties.Buttons[0].Visible = true;
            }
        }

        private void txtOperatorID_Validating(object sender, CancelEventArgs e)
        {
            string operatorCode = txtOperatorID.Text;
            if (!string.IsNullOrEmpty(operatorCode))
            {
                if (_operator == null)
                {
                    Ultils.EditTextErrorMessage(txtOperatorID, "Opeator code không tồn tại trong hệ thống!");
                }
                else
                {
                    btnLogin.Focus();
                }
            }
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtOperatorID.Text))
            {
                Ultils.TextControlNotNull(txtOperatorID, "Operator ID");
            }
            else
            {
                var user = new User()
                {
                    OperatorCode = _operator.OperatorID,
                    OperatorName = _operator.OperatorName,
                    LineID = 1,
                    OperationID = 1,
                    ProcessID = null,
                    CheckItemOnWIP = false,
                };
                Program.CurrentUser = user;
                Hide();
                if (Program.CurrentUser != null)
                {
                    var qa = new FormMurata();
                    qa.ShowDialog();
                }
                
            }
        }

        private void txtOperatorID_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 0)
            {
                txtOperatorID.ResetText();
                txtOperatorID.Properties.Buttons[0].Visible = false;
            }     
        }
    }
}
