using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.Win32;
using Lib.Forms.Helpers;

namespace GARecruitmentSystem
{
    public partial class FormLogin : XtraForm
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                dynamic mboxResult = XtraMessageBox.Show("Are you want colse this form?",
                    "Close",
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Are you want colse this form?", "Close", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.ExitThread();
            }
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtUsername))
            {
                dxErrorProvider1.SetError(txtUsername, "Vui lòng nhập vào tên đăng nhập của bạn!");
            }
            else if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtPassword))
            {
                dxErrorProvider1.SetError(txtUsername, "Vui lòng nhập vào mật khẩu của bạn!");
            }
            else
            {
                this.Hide();
                var formMain = new FormMain();
                formMain.Show();
            }
        }

        /// <summary>
        /// Lưu Mật Khẩu Và Tên Đăng nhập
        /// </summary>
        private void SaveRegistry()
        {
            if (chkRemember.Checked)
            {

                Registry.SetValue(@"HKEY_CURRENT_USER\Software\StockManager\SaveUserAndPassword", "IsRemember", "1");
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\StockManager\SaveUserAndPassword", "Username", txtUsername.Text);
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\StockManager\SaveUserAndPassword", "Password", txtPassword.Text);
            }
            else
            {
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\StockManager\SaveUserAndPassword", "IsRemember", "0");
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\StockManager\SaveUserAndPassword", "Username", "");
                Registry.SetValue(@"HKEY_CURRENT_USER\Software\StockManager\SaveUserAndPassword", "Password", "");
            }
        }

        private void LoadRegistry()
        {
            txtUsername.Text = (string)(Registry.GetValue(@"HKEY_CURRENT_USER\Software\StockManager\SaveUserAndPassword", "Username", null));
            txtPassword.Text = (string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\StockManager\SaveUserAndPassword", "Password", null);

            if ((string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\StockManager\SaveUserAndPassword", "IsRemember", null) == "1")
            {
                chkRemember.Checked = true;
            }
            if ((string)Registry.GetValue(@"HKEY_CURRENT_USER\Software\StockManager\SaveUserAndPassword", "IsRemember", null) == "0")
            {
                chkRemember.Checked = false;
            }
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            LoadRegistry();
            txtUsername.Focus();
        }

        private void txtUsername_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtUsername))
                {
                    dxErrorProvider1.SetError(txtUsername, "Please enter your username!");
                }
                else
                {
                    txtPassword.Focus();
                }
            }
        }
        private void txtPassword_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtPassword))
                {
                    dxErrorProvider1.SetError(txtPassword, "Please enter your password!");
                }
                else
                {
                    btnLogin.PerformClick();
                }
            }
        }
        private void txtUsername_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(txtUsername);
            dxErrorProvider1.ClearErrors();
        }
        private void txtPassword_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(txtPassword);
            dxErrorProvider1.ClearErrors();
        }
       
    }
}