using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Stock.Data;
using Stock.GUI.Helpers;
using Stock.GUI.Properties;
using Stock.Services;

namespace Stock.GUI.Partners
{
    public partial class FormUpdateEmployee : XtraForm
    {
        private readonly string _employeeId;
        private readonly EmployeeService _employeeService;
        private readonly DepartmentService _departmentService;
        private readonly LogService _logService;
        public FormUpdateEmployee(string employeeId)
        {
            InitializeComponent();
            _employeeService = new EmployeeService();
            _departmentService=new DepartmentService();
            _logService = new LogService();
            _employeeId = employeeId;
            GetEmployeesById(employeeId);
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
            _logService.InsertLog(userName, employeeName, itemName, Resources.FormTitleEmployee, info);
        }

        /// <summary>
        /// Trả về thông tin Nhân viên theo ID
        /// </summary>
        /// <param name="employeeId"></param>
        private void GetEmployeesById(string employeeId)
        {
            Employee employee = _employeeService.GetEmployeeById(employeeId);
            if (employee != null)
            {
                txtEmployeeID.Text = employee.EmployeeID;
                gridLookUpEdit1.EditValue = employee.DepartmentID;
                txtEmployeeName.Text = employee.EmployeeName;
                txtEmployeeCode.Text = employee.EmployeeCode;
                txtPhone.Text = employee.HomeTell;
                txtMoblie.Text = employee.Mobile;
                txtAddress.Text = employee.Address;
                txtEmail.Text = employee.Email;
                txtPosition.Text = employee.Alias;
                if (employee.IsActive != null)
                    checkActive.Checked = (bool)employee.IsActive;
            }
            else
                XtraMessageBox.Show("Vui lòng chọn", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        /// <summary>
        /// 
        /// </summary>
        public void LoadGirdLookUpDepartment()
        {
            var departments = _departmentService.GetDepartments();
                //.Select(d=> new Department()
                //{
                //    DepartmentID = d.DepartmentID,
                //    DepartmentName = d.DepartmentName,
                //    Description = d.Description,
                //}).ToList();
            gridLookUpEdit1.Properties.View.OptionsBehavior.AutoPopulateColumns = false;
            gridLookUpEdit1.Properties.DisplayMember = "DepartmentName";
            gridLookUpEdit1.Properties.ValueMember = "DepartmentID";
            gridLookUpEdit1.Properties.View.BestFitColumns();
            gridLookUpEdit1.Properties.PopupFormWidth = 300;
            gridLookUpEdit1.Properties.DataSource = departments;
        }

        private void FormUpdateEmployee_Load(object sender, EventArgs e)
        {
            LoadGirdLookUpDepartment();
        }

        private void FormUpdateEmployeee_FormClosing(object sender, FormClosingEventArgs e)
        {
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Sửa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmployeeID.Text))
            {
                XtraMessageBox.Show("Mã Nhân Viên không được bỏ trống!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmployeeID.Focus();
            }
            else if (string.IsNullOrEmpty(txtEmployeeCode.Text))
            {
                XtraMessageBox.Show("Mã Code của Nhân viên không được bỏ trống!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmployeeCode.Focus();
            }
            else if (string.IsNullOrEmpty(txtEmployeeName.Text))
            {
                XtraMessageBox.Show("Tên Nhân Viên không được bỏ trống!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtEmployeeName.Focus();
            }
            else if (string.IsNullOrEmpty(gridLookUpEdit1.Text))
            {
                XtraMessageBox.Show("Bạn phải chọn một Bộ Phận cho Nhân viên này!", "THÔNG BÁO", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                gridLookUpEdit1.Focus();
            }
            else
            {
                Employee employee = _employeeService.GetEmployeeById(_employeeId);
                if (employee != null)
                {
                    employee.EmployeeID = txtEmployeeID.Text;
                    employee.EmployeeCode = txtEmployeeCode.Text;
                    employee.DepartmentID = gridLookUpEdit1.EditValue.ToString();
                    employee.EmployeeName = txtEmployeeName.Text;
                    employee.HomeTell = txtPhone.Text;
                    employee.Mobile = txtMoblie.Text;
                    employee.Address = txtAddress.Text;
                    employee.Email = txtEmail.Text;
                    employee.IsActive = checkActive.Checked;
                } 
                try
                {
                    _employeeService.Update(employee);
                    InsertSysLog(txtEmployeeName.Text);
                    XtraMessageBox.Show("Sửa thành công", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnClose_Click(sender, e);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(string.Format("Lỗi {0}", ex.Message), "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void gridLookUpEdit1_Properties_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                var addDepartment = new FormAddDepartment();
                addDepartment.ShowDialog();
                LoadGirdLookUpDepartment();
                Refresh();
            }
        }

        private void FormUpdateEmployee_KeyDown(object sender, KeyEventArgs e)
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