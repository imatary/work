using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Stock.GUI.Helpers;
using Stock.GUI.Properties;
using Stock.Services;

namespace Stock.GUI.Partners
{
    public partial class FormAddDepartment : XtraForm
    {
        private readonly DepartmentService _departmentService;
        private readonly LogService _logService;
        private readonly EmployeeService _employeeService;
        public FormAddDepartment()
        {
            InitializeComponent();
            _departmentService = new DepartmentService();
            txtDepartmentID.Text = _departmentService.NextId();
            _logService = new LogService();
            _employeeService = new EmployeeService();
        }

        /// <summary>
        // Lưu lại quá trình hoạt động của người dùng trên hệ thống
        /// </summary>
        private void InsertSysLog(string item)
        {
            string userName = Program.CurrentUser.UserName;
            string employeeName = _employeeService.GetEmployeeById(Program.CurrentUser.EmployeeID).EmployeeName;
            string info = MachineHelper.GetMachineInfo();
            string itemName = string.Format(Resources.ActionAdd, item);
            _logService.InsertLog(userName, employeeName, itemName, Resources.FormTitleDepartment, info);
        }

        private void FormAddDepartment_FormClosing(object sender, FormClosingEventArgs e)
        {
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Lưu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDepartmentID.Text))
            {
                txtDepartmentID.Properties.Appearance.BorderColor = System.Drawing.Color.Red;
                XtraMessageBox.Show("Mã Bộ Phận không được để trống !", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDepartmentID.Focus();
            }
            else if (string.IsNullOrEmpty(txtDepartmentName.Text))
            {
                txtDepartmentName.Properties.Appearance.BorderColor = System.Drawing.Color.Red;
                XtraMessageBox.Show("Tên Bộ Phận không được để trống !", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDepartmentName.Focus();
            }
            else
            {
                var department = new Data.Department()
                {
                    DepartmentID = txtDepartmentID.Text,
                    DepartmentName = txtDepartmentName.Text,
                    Description = txtDescription.Text,
                    CreatedDate = DateTime.Now,
                    CreatedBy = null,
                    IsActive = checkActive.Checked
                };
                try
                {
                    _departmentService.Add(department);
                    InsertSysLog(txtDepartmentName.Text);
                    if (XtraMessageBox.Show("Thêm thành công.\n Bạn có muốn thêm mới Bộ Phận nữa không?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        ResetControls();
                    }
                    else
                    {
                        DialogResult = DialogResult.No;
                    }
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(string.Format("Lỗi {0}", ex.Message), "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtDepartmentID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                txtDepartmentName.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                txtDepartmentID.Text = _departmentService.NextId();
            }
        }

        private void txtDepartmentName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                btnSave.Focus();
                btnSave.PerformClick();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                txtDepartmentName.Text = string.Empty;
            }
            else if (e.KeyCode == Keys.Tab)
            {
                txtDescription.Focus();
            }
        }

        private void txtDescription_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave.Focus();
                btnSave.PerformClick();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                txtDescription.Text = string.Empty;
            }
            else if (e.KeyCode == Keys.Up)
            {
                txtDepartmentName.SelectAll();
                txtDepartmentName.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                btnSave.Focus();
            }
        }

        /// <summary>
        /// Reset Text
        /// </summary>
        private void ResetControls()
        {
            txtDepartmentID.Text = _departmentService.NextId();
            txtDepartmentName.Text = "";
            txtDescription.Text = "";

            if (txtDepartmentName.Properties.Appearance.BorderColor == System.Drawing.Color.Red)
            {
                txtDepartmentName.Properties.Appearance.BorderColor = System.Drawing.Color.LightGray;
            }
        }

        private void FormAddDepartment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.S:
                        btnSave.PerformClick();
                        break;
                }
            }

            // Đóng form
            if ((Keys)e.KeyValue == Keys.Escape)
                btnClose.PerformClick();
        }
    }
}