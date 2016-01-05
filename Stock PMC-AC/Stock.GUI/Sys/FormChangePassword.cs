using System.Windows.Forms;
using DevExpress.XtraEditors;
using Stock.Data;
using Stock.GUI.Helpers;
using Stock.Services;

namespace Stock.GUI.Sys
{
    public partial class FormChangePassword : XtraForm
    {
        private readonly UserService _userService;

        public FormChangePassword()
        {
            InitializeComponent();
            _userService = new UserService();
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCurrentPassword.Text))
            {
                txtCurrentPassword.Properties.Appearance.BorderColor = System.Drawing.Color.Red;
                XtraMessageBox.Show("Mật khẩu hiện tại không được để trống!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCurrentPassword.Focus();
            }
            else if (string.IsNullOrEmpty(txtNewPassword.Text))
            {
                txtNewPassword.Properties.Appearance.BorderColor = System.Drawing.Color.Red;
                XtraMessageBox.Show("Mật khẩu mới không được để trống!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNewPassword.Focus();
            }
            else if (string.IsNullOrEmpty(txtConfirmNewPassword.Text))
            {
                txtConfirmNewPassword.Properties.Appearance.BorderColor = System.Drawing.Color.Red;
                XtraMessageBox.Show("Nhập lại mật khẩu mới của bạn!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmNewPassword.Focus();
            }
            else if (txtConfirmNewPassword.Text.Trim() != txtNewPassword.Text.Trim())
            {
                txtConfirmNewPassword.Properties.Appearance.BorderColor = System.Drawing.Color.Red;
                XtraMessageBox.Show("Mật khẩu mới không trùng khớp!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmNewPassword.Focus();
                txtConfirmNewPassword.SelectAll();
            }
            else
            {
                string userName = Program.CurrentUser.UserName;
                string pasword = SecurityHelper.Encrypt(txtCurrentPassword.Text);
                if (!_userService.CheckPassword(userName, pasword))
                {
                    txtCurrentPassword.Properties.Appearance.BorderColor = System.Drawing.Color.Red;
                    XtraMessageBox.Show("Mật khẩu hiện tại không chính xác!", "Thông Báo", MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    txtCurrentPassword.Focus();
                    txtCurrentPassword.SelectAll();
                }
                else
                {
                    User user = _userService.GetUserByUserName(userName);
                    user.Password = pasword;
                    _userService.Update(user);
                    XtraMessageBox.Show("Thay đổi mật khẩu thành công", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnClose.PerformClick();
                }
            }
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void txtCurrentPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                txtNewPassword.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                txtCurrentPassword.Text = string.Empty;
            }
        }

        private void txtNewPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                txtConfirmNewPassword.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                txtNewPassword.Text = string.Empty;
            }
        }

        private void txtConfirmNewPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave.Focus();
                btnSave.PerformClick();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                txtConfirmNewPassword.Text = string.Empty;
            }
            else if (e.KeyCode == Keys.Up)
            {
                txtNewPassword.SelectAll();
                txtNewPassword.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                btnSave.Focus();
            }
        }
    }
}