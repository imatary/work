using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Stock.Data;
using Stock.GUI.Helpers;
using Stock.GUI.Partners;
using Stock.GUI.Properties;
using Stock.Services;

namespace Stock.GUI.Sys
{
    public partial class FormAddManager : XtraForm
    {
        private readonly EmployeeService _employeeService;
        private readonly DepartmentService _departmentService;
        private readonly LogService _logService;
        public FormAddManager()
        {
            InitializeComponent();
            _employeeService = new EmployeeService();
            _departmentService = new DepartmentService();
            _logService = new LogService();
        }

        /// <summary>
        /// 
        /// </summary>
        public void LoadGirdLookUpDepartment()
        {
            var departments = _departmentService.GetDepartments();
            gridLookUpEdit1.Properties.View.OptionsBehavior.AutoPopulateColumns = false;
            gridLookUpEdit1.Properties.DisplayMember = "DepartmentName";
            gridLookUpEdit1.Properties.ValueMember = "DepartmentID";
            gridLookUpEdit1.Properties.View.BestFitColumns();
            gridLookUpEdit1.Properties.PopupFormWidth = 300;
            gridLookUpEdit1.Properties.DataSource = departments;
        }

        /// <summary>
        /// Tạo ID kế tiếp
        /// </summary>
        /// <returns></returns>
        private string NextId()
        {
            var employees = _employeeService.GetEmployees().Last();
            if (employees != null)
            {
                string lastId = employees.EmployeeID.Remove(0, 3);
                string employeesId;
                if (!string.IsNullOrEmpty(lastId))
                {
                    int nextId = int.Parse(lastId) + 1;
                    employeesId = string.Format("NV{0}", nextId.ToString(CultureInfo.InvariantCulture).PadLeft(5, '0'));
                }
                else
                {
                    employeesId = string.Format("NV0000{0}", 1);
                }
                txtEmployeeName.Focus();
                return employeesId;
            }
            return string.Format("NV0000{0}", 1);
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
            _logService.InsertLog(userName, employeeName, itemName, Resources.FormTitleEmployee, info);
        }

        private void FormAddManager_Load(object sender, EventArgs e)
        {
            LoadGirdLookUpDepartment();

            txtEmployeeID.Text = NextId();
            if (!string.IsNullOrEmpty(txtEmployeeID.Text))
            {
                txtEmployeeName.Focus();
            } 
        }

        private void FormAddManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }


        /// <summary>
        /// Thêm
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
                XtraMessageBox.Show("Bạn phải chọn một Bộ Phận cho Nhân viên này!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gridLookUpEdit1.Focus();
            }
            else
            {
                var employee = new Employee()
                {
                    EmployeeID = txtEmployeeID.Text,
                    EmployeeCode = txtEmployeeCode.Text,
                    DepartmentID = gridLookUpEdit1.EditValue.ToString(),
                    EmployeeName = txtEmployeeName.Text,
                    HomeTell = txtPhone.Text,
                    Mobile = txtMoblie.Text,
                    Address = txtAddress.Text,
                    Email = txtEmail.Text,
                    IsActive = checkActive.Checked,
                    IsManagerStock = true,
                };
                try
                {
                    _employeeService.Add(employee);
                    InsertSysLog(txtEmployeeName.Text);
                    if (XtraMessageBox.Show("Thêm thành công.\n Bạn có muốn thêm mới Nhân Viên nữa không?", "HỎI", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
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

        private void gridLookUpEdit1_Properties_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                var department = new FormAddDepartment();
                department.ShowDialog();
                LoadGirdLookUpDepartment();
            }
            
        }

        private void ResetControls()
        {
            txtEmployeeID.Text = NextId();
            txtEmployeeName.Text = "";
            txtEmployeeCode.Text = "";
            txtPhone.Text = "";
            txtMoblie.Text = "";
            txtAddress.Text = "";
            txtEmail.Text = "";
            txtPosition.Text = "";
        }
    }
}