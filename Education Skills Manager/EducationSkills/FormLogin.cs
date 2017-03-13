using EducationSkills.Data;
using System;
using System.Linq;
using System.Windows.Forms;

namespace EducationSkills
{
    public partial class FormLogin : Form
    {
        private readonly EducationSkillsDbContext context; 
        public FormLogin()
        {
            InitializeComponent();

            context = new EducationSkillsDbContext();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            txtUsername.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if(!ValidationHelper.IsNullOrEmptyControl(txtUsername))
            {
                MessageHelper.ErrorMessageBox("Tên đăng nhập không được bỏ trống!");
            }
            else if (!ValidationHelper.IsNullOrEmptyControl(txtPassword))
            {
                MessageHelper.ErrorMessageBox("Mật khẩu không được bỏ trống!");
            }
            else
            {
                var user = context.PR_AdminEdu.SingleOrDefault(u => u.UserName == txtUsername.Text.Trim() && u.PassWord == txtPassword.Text.Trim());
                if (user != null)
                {
                    Program.CurrentUser = user;
                    new FormMain().Show();
                    this.Hide();
                }
                else
                {
                    MessageHelper.ErrorMessageBox("Tên đăng nhập hoặc mật khẩu không chính xác. Vui lòng kiểm tra lại!");
                    txtUsername.SelectAll();
                    txtUsername.Focus();
                }
            }
        }

        private void txtUsername_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUsername.Text))
            {
                ValidationHelper.SetDefaultControl(txtUsername);
            }
        }

        private void txtPassword_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPassword.Text))
            {
                ValidationHelper.SetDefaultControl(txtPassword);
            }
        }

        private void txtPassword_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtPassword.Text))
                {
                    btnLogin.Focus();
                    btnLogin.PerformClick();
                }
                else
                {
                     if(!ValidationHelper.IsNullOrEmptyControl(txtPassword))

                        MessageHelper.ErrorMessageBox("Mật khẩu không được bỏ trống!");
                        txtPassword.Focus();
                }
            }
        }

        private void txtUsername_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txtUsername.Text))
                {
                    txtPassword.Focus();
                }
                else
                {
                    if (!ValidationHelper.IsNullOrEmptyControl(txtUsername))

                        MessageHelper.ErrorMessageBox("Tên đăng nhập không được bỏ trống!");
                    txtUsername.Focus();
                }
            }
        }
    }
}
