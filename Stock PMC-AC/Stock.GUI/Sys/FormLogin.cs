using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Microsoft.Win32;
using Stock.Data;
using Stock.GUI.Helpers;
using Stock.Services;

namespace Stock.GUI.Sys
{
    public partial class FormLogin : XtraForm
    {
        private readonly WaitDialogFormHelper _waitDialog = new WaitDialogFormHelper();
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
                dynamic mboxResult = XtraMessageBox.Show("Bạn có thực sự muốn thoát khỏi hệ thống không!",
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

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Bạn có thực sự muốn thoát khỏi hệ thống không!", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.ExitThread();
            }
        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            XtraMessageBox.Show("Chức năng đang được phát triển");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsername.Text))
            {
                txtUsername.Properties.Appearance.BorderColor = System.Drawing.Color.Red;
                XtraMessageBox.Show("Tên đăng nhập không được để trống !", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUsername.Focus();
            }
            else if (string.IsNullOrEmpty(txtPassword.Text))
            {
                txtPassword.Properties.Appearance.BorderColor = System.Drawing.Color.Red;
                XtraMessageBox.Show("Mật khẩu không được để trống !", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Focus();
            }
            else
            {
                int res = CheckLogin(txtUsername.Text, txtPassword.Text);
                if (res == 0)
                {
                    XtraMessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng! Vui lòng thử lại", "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    _waitDialog.CloseWait();
                    txtPassword.Properties.Appearance.BorderColor = System.Drawing.Color.Red;
                    txtPassword.SelectAll();
                    txtPassword.Focus();
                }
                else if (res == 1)
                {
                    Hide();
                    SaveRegistry();
                    _waitDialog.CloseWait();
                    var formMain = new FormMain();
                    formMain.Show();
                    //var formMain = new ShowControlsForm();
                    //formMain.Show();
                }
                else
                {
                    XtraMessageBox.Show(string.Format("Thông tin tài khoản: {0} không tồn tại!", txtUsername.Text), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public int CheckLogin(string userName, string password)
        {
            _waitDialog.CreateWaitDialog();
            _waitDialog.SetWaitDialogCaption("Đang kiểm tra thông tin đăng nhập!"); 
            string pass = SecurityHelper.Encrypt(password);

            try
            {
                User user = _userService.GetUsers().FirstOrDefault(t => t.UserName == userName && t.Password == pass);

                if (user != null)
                {
                    Program.CurrentUser = user;
                    user.LastLogin = DateTime.Now;
                    user.Client = MachineHelper.GetMachineInfo();
                    _userService.Update(user);
                    _userService.SaveChanges();
                    return 1;
                }
                return 0;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(string.Format("Lỗi không xác định! \nChi tiết lỗi: \n{0}", ex.Message), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
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
    }
}