using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.Win32;
using Stock.Data;
using Stock.GUI.Properties;
using Stock.Services;

namespace Stock.GUI
{
    public partial class FormLogin : XtraForm
    {
        private readonly UserService _userService;
        private string _messageError;
        public FormLogin()
        {
            InitializeComponent();
            _userService = new UserService();
        }

        private void FormLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                dynamic mboxResult = XtraMessageBox.Show(Resources.MessageBoxColseForm,
                    Resources.MessageBoxTitle,
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
            if (XtraMessageBox.Show(Resources.MessageBoxColseForm, Resources.MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.ExitThread();
            }
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                SetColor(txtUsername);
                XtraMessageBox.Show(Resources.MessageBoxUserNameNotNull, Resources.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Focus();
            }
            else if (string.IsNullOrEmpty(txtPassword.Text))
            {
                SetColor(txtPassword);
                XtraMessageBox.Show(Resources.MessageBoxPasswordNotNull, Resources.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
            }
            else
            {
                int res = CheckLogin(txtUsername.Text, txtPassword.Text);
                if (res == 0)
                {
                    XtraMessageBox.Show(Resources.MessageBoxUsernameOrPasswordFaill, Resources.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    SetColor(txtPassword);
                    txtPassword.SelectAll();
                    txtPassword.Focus();
                }
                else if (res == 1)
                {
                    Hide();
                    SaveRegistry();
                    splashScreenCheckLogin.CloseWaitForm();
                    var formMain = new FormMain();
                    formMain.Show();
                }
                else if(res==2)
                {
                    splashScreenCheckLogin.CloseWaitForm();
                    XtraMessageBox.Show(Resources.MessageBoxUsernameNotActive, Resources.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if(res == 3)
                {
                    splashScreenCheckLogin.CloseWaitForm();
                    XtraMessageBox.Show(string.Format(Resources.MessageBoxUsernameNotExits, txtUsername.Text), Resources.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (res == 4)
                {
                    splashScreenCheckLogin.CloseWaitForm();
                    XtraMessageBox.Show(_messageError, Resources.MessageBoxTitle, MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
                else
                {
                    splashScreenCheckLogin.CloseWaitForm();
                    XtraMessageBox.Show("Lỗi không xác định. Vui lòng thử lại", Resources.MessageBoxTitle, MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }           
            }
        }

        public int CheckLogin(string userName, string password)
        {
            splashScreenCheckLogin.ShowWaitForm();
            try
            {
                User user = _userService.GetUsers().FirstOrDefault(t => t.Username == userName && t.Password == password);

                if (user != null)
                {
                    if (user.IsActive)
                    {
                        Program.CurrentUser = user;
                        return 1;
                    }
                    return 2;
                }
                return 3;
            }
            catch (Exception ex)
            {
                _messageError = ex.Message;
                return 4;
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
            btnLogin.Focus();
        }

        private void txtUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                if ((!string.IsNullOrEmpty(txtUsername.Text)) && (!string.IsNullOrEmpty(txtPassword.Text)))
                {
                    btnLogin.Focus();
                    btnLogin.PerformClick();
                }
                else
                {
                    txtPassword.Focus();
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                txtUsername.Text = string.Empty;
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.Focus();
                btnLogin.PerformClick();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                txtPassword.Text = string.Empty;
            }
            else if (e.KeyCode == Keys.Up)
            {
                txtUsername.SelectAll();
                txtUsername.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                btnLogin.Focus();
            }
        }

        private void chkRemember_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.Focus();
                btnLogin.PerformClick();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                chkRemember.Checked = false;
            }
            else if (e.KeyCode == Keys.Up)
            {
                chkRemember.SelectAll();
                chkRemember.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                btnLogin.Focus();
            }
        }

        private void SetColor(TextEdit textEdit)
        {
            textEdit.Properties.Appearance.BorderColor = System.Drawing.Color.Red;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Enter:
                    {
                        btnLogin.Focus();
                        btnLogin.PerformClick();
                        return true;
                    }
                case Keys.Control | Keys.C:
                    {
                        btnConfig.PerformClick();
                        return true;
                    }
                case Keys.Escape:
                    {
                        btnExit.PerformClick();
                        return true;
                    }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}