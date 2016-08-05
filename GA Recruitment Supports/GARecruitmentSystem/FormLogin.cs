using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.Win32;
using Lib.Forms.Helpers;
using Lib.Services;

namespace GARecruitmentSystem
{
    public partial class FormLogin : XtraForm
    {
        private readonly UserService _userService; 

        public FormLogin()
        {
            InitializeComponent();
            _userService = new UserService();
        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                dynamic mboxResult = XtraMessageBox.Show("Bạn có chắc muốn thoát?",
                    "THÔNG BÁO",
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
            if (XtraMessageBox.Show("Bạn có chắc muốn thoát?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
                CheckTextBoxNullValue.ShowError(dxErrorProvider1, txtUsername, toolTipController1, "Vui lòng nhập vào 'Tên đăng nhập'!");
            }
            else if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtPassword))
            {
                CheckTextBoxNullValue.ShowError(dxErrorProvider1, txtUsername, toolTipController1, "Vui lòng nhập vào 'Mật khẩu'!");
            }
            else
            {
                var user = _userService.GetUserByUserName(txtUsername.Text.Trim());
                if (user != null)
                {
                    if(_userService.CheckLogin(txtUsername.Text.Trim(), txtPassword.Text.Trim()))
                    {
                        Program.CurentUser = user;

                        this.Hide();
                        var formMain = new FormMain();
                        formMain.Show();
                    }
                    else
                    {
                        CheckTextBoxNullValue.ShowError(dxErrorProvider1, txtUsername, toolTipController1, "Sai 'Mật khẩu'. Vui lòng thử lại!");
                    }
                }
                else
                {
                    CheckTextBoxNullValue.ShowError(dxErrorProvider1, txtUsername, toolTipController1, "'Tên đăng nhập' không tồn tại. Vui lòng thử lại!");
                }
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
                    CheckTextBoxNullValue.ShowError(dxErrorProvider1, txtUsername, toolTipController1, "Vui lòng nhập vào 'Tên đăng nhập'!");
                }
                else
                {
                    if (string.IsNullOrEmpty(txtPassword.Text.Trim()))
                    {
                        txtPassword.Focus();
                    }
                    else
                    {
                        btnLogin.Focus();
                    }
                }
            }
        }
        private void txtPassword_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!CheckTextBoxNullValue.ValidationTextEditNullValue(txtPassword))
                {
                    CheckTextBoxNullValue.ShowError(dxErrorProvider1, txtUsername, toolTipController1, "Vui lòng nhập vào 'Mật khẩu'!");
                }
                else
                {
                    btnLogin.PerformClick();
                }
            }
        }
        private void txtUsername_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1, txtUsername);
        }
        private void txtPassword_EditValueChanged(object sender, EventArgs e)
        {
            CheckTextBoxNullValue.SetColorDefaultTextControl(dxErrorProvider1, txtUsername);
        }
       
    }
}