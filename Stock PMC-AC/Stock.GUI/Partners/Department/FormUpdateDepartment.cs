using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Stock.Data;
using Stock.GUI.Helpers;
using Stock.GUI.Properties;
using Stock.Services;

namespace Stock.GUI.Partners
{
    public partial class FormUpdateDepartment : XtraForm
    {
        private readonly string _departmentId;
        private readonly DepartmentService _departmentService;
        private readonly LogService _logService;
        private readonly EmployeeService _employeeService;
        public FormUpdateDepartment(string departmentId)
        {
            InitializeComponent();
            _departmentService = new DepartmentService();
            _departmentId = departmentId;
            GetDepartmentById(departmentId);
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
            string itemName = string.Format(Resources.ActionUpdate, item);
            _logService.InsertLog(userName, employeeName, itemName, Resources.FormTitleDepartment, info);
        }
        private void FormUpdateDepartment_FormClosing(object sender, FormClosingEventArgs e)
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
                XtraMessageBox.Show("Mã Bộ Phận không được để trống !", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDepartmentID.Focus();
            }
            else if (string.IsNullOrEmpty(txtDepartmentName.Text))
            {
                XtraMessageBox.Show("Tên Bộ Phận không được để trống !", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtDepartmentName.Focus();
            }
            else
            {
                Data.Department department = _departmentService.GetDepartmentById(_departmentId);
                if (department != null)
                {
                    department.DepartmentName = txtDepartmentName.Text;
                    department.Description = txtDescription.Text;
                    department.ModifyDate = DateTime.Now;
                    department.UpdateBy = null;
                    department.IsActive = checkActive.Checked;
                }

                try
                {
                    _departmentService.Update(department);
                    InsertSysLog(txtDepartmentName.Text);
                    XtraMessageBox.Show("Sửa thành công", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnClose_Click(sender, e);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(string.Format("Lỗi {0}", ex.Message), "THÔNG BÁO");
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
                txtDepartmentID.Text = _departmentId;
            }
        }

        private void txtDepartmentName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                txtDescription.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                txtDepartmentName.Text = string.Empty;
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
        /// Trả về danh sách bộ phận
        /// </summary>
        /// <param name="departmentId"></param>
        private void GetDepartmentById(string departmentId)
        {
            Data.Department department = _departmentService.GetDepartmentById(departmentId);
            if (department != null)
            {
                txtDepartmentID.Text = department.DepartmentID;
                txtDepartmentName.Text = department.DepartmentName;
                txtDescription.Text = department.Description;
                checkActive.Checked = department.IsActive;
            }
            else
                XtraMessageBox.Show("Vui lòng chọn", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void FormUpdateDepartment_KeyDown(object sender, KeyEventArgs e)
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