using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Stock.Data;
using Stock.GUI.Helpers;
using Stock.Services;

namespace Stock.GUI.Sys
{
    public partial class FormAddUserLogin : XtraForm
    {
        private readonly ManagersService _managersService;
        private readonly UserService _userService;
        public FormAddUserLogin()
        {
            InitializeComponent();
            _userService = new UserService();
            _managersService=new ManagersService();
            LoadGirdLookUpEmployees();
        }

        /// <summary>
        /// 
        /// </summary>
        public void LoadGirdLookUpEmployees()
        {
            var employees = _managersService.GetEmployeeManagers();
            gridLookUpEdit1.Properties.View.OptionsBehavior.AutoPopulateColumns = false;
            gridLookUpEdit1.Properties.DisplayMember = "EmployeeName";
            gridLookUpEdit1.Properties.ValueMember = "EmployeeID";
            gridLookUpEdit1.Properties.View.BestFitColumns();
            gridLookUpEdit1.Properties.PopupFormWidth = 300;
            gridLookUpEdit1.Properties.DataSource = employees;
        }

        private void gridLookUpEdit1_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                var add = new FormAddManager();
                add.ShowDialog();
                LoadGirdLookUpEmployees();
            }
            
        }

        
        /// <summary>
        /// Lưu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(gridLookUpEdit1.Text))
            {
                XtraMessageBox.Show("Vui lòng chọn một Quản lý!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gridLookUpEdit1.Focus();
            }
            else if (string.IsNullOrEmpty(txtUserName.Text))
            {
                XtraMessageBox.Show("Vui lòng nhập vào tên đăng nhập!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUserName.Focus();
            }
            else if (string.IsNullOrEmpty(txtPassword.Text))
            {
                XtraMessageBox.Show("Vui lòng nhập vào mật khẩu!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPassword.Focus();
            }
            else if (string.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                XtraMessageBox.Show("Vui lòng nhập vào mật khẩu!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtConfirmPassword.Focus();
            }
            else
            {
                if (txtConfirmPassword.Text.Trim() != txtPassword.Text.Trim())
                {
                    XtraMessageBox.Show("Hai mật khẩu không trùng với nhau!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtConfirmPassword.Focus();
                }
                else
                {
                    string password = SecurityHelper.Encrypt(txtPassword.Text);
                    User user = _userService.GetUserByUserName(txtUserName.Text);
                    if (user != null)
                    {
                        user.Password = password;
                        _userService.Update(user);
                        XtraMessageBox.Show("Thay đổi mật thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnClose_Click(sender, e);
                    }
                    else
                    {
                        if (!_userService.CheckUserNameExit(txtUserName.Text))
                        {
                            XtraMessageBox.Show(string.Format("Tên đăng nhập {0} này đã tồn tại!", txtUserName.Text), "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtUserName.Focus();
                            txtUserName.SelectAll();
                        }
                        else
                        {
                            var addUser = new User()
                            {
                                EmployeeID = gridLookUpEdit1.EditValue.ToString(),
                                UserName = txtUserName.Text,
                                Password = password,
                            };
                            _userService.Add(addUser);
                            XtraMessageBox.Show("Tạo thành công!", "Thông Báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnClose_Click(sender, e);
                        }
                    }
                }
            }
        }

        private void EnableControlsTextBox(bool enable)
        {
            txtUserName.Enabled = enable;
            txtPassword.Enabled = enable;
            txtConfirmPassword.Enabled = enable;
        }

        private void gridLookUpEdit1_EditValueChanged(object sender, EventArgs e)
        {
            EnableControlsTextBox(true);
            string employeeId = gridLookUpEdit1.EditValue.ToString();
            User user = _userService.GetUserByEmployeeId(employeeId);
            if (user != null)
            {
                if (XtraMessageBox.Show("Đã tạo rồi.\nBạn có muốn cập nhật lại mật khẩu không?", "HỎI", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    
                    txtUserName.Enabled = false;
                    txtUserName.Text = user.UserName;
         
                    txtPassword.Text = SecurityHelper.Decrypt(user.Password);
                    txtPassword.SelectAll();
                    txtPassword.Focus();

                    txtConfirmPassword.Text = SecurityHelper.Decrypt(user.Password);
                }
                else
                {
                    gridLookUpEdit1.Focus();
                    gridLookUpEdit1.Text = string.Empty;
                    
                    EnableControlsTextBox(false);
                }
            }
            else
            {
                txtUserName.Text = string.Empty;
                txtPassword.Text = string.Empty;
                txtConfirmPassword.Text = string.Empty;
            }
        }

        private void btnClose_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}