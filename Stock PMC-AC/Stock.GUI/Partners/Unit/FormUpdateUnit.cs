using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Stock.Data;
using Stock.GUI.Helpers;
using Stock.GUI.Properties;
using Stock.Services;

namespace Stock.GUI.Partners
{
    public partial class FormUpdateUnit : XtraForm
    {
        private readonly UnitService _unitService;
        private readonly string _unitId;
        private readonly LogService _logService;
        private readonly EmployeeService _employeeService;
        public FormUpdateUnit(string unitId)
        {
            InitializeComponent();
            _unitService = new UnitService();
            _logService = new LogService();
            _employeeService = new EmployeeService();
            _unitId = unitId;
            GetUnitById(unitId);
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
            _logService.InsertLog(userName, employeeName, itemName, Resources.FormTitleUnit, info);
        }

        private void FormUpdateUnit_FormClosing(object sender, FormClosingEventArgs e)
        {
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Lưu thông tin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUnitName.Text))
            {
                XtraMessageBox.Show("Tên Đơn Vị không được để trống !", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUnitName.Focus();
            }
            else
            {
                Unit unit = _unitService.GetUnitById(_unitId);
                if (unit != null)
                {
                    unit.UnitName = txtUnitName.Text;
                    unit.Description = txtDescription.Text;
                    unit.IsActive = checkActive.Checked;
                    unit.ModifyDate = DateTime.Now;
                    unit.UpdateBy = null;
                }
                try
                {
                    _unitService.Update(unit);
                    InsertSysLog(txtUnitName.Text);
                    XtraMessageBox.Show("Sửa thành công", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnClose_Click(sender, e);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(string.Format("Lỗi {0}", ex.Message), "THÔNG BÁO");
                }
            }
        }

        private void txtUnitID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                txtUnitName.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                txtUnitID.Text = "";
            }
        }

        private void txtUnitName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                txtDescription.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                txtUnitName.Text = string.Empty;
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
                txtUnitName.SelectAll();
                txtUnitName.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                btnSave.Focus();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitid"></param>
        /// <returns></returns>
        private void GetUnitById(string unitid)
        {
            Unit unit = _unitService.GetUnitById(unitid);
            if (unit != null)
            {
                txtUnitID.Text = unit.UnitID;
                txtUnitName.Text = unit.UnitName;
                txtDescription.Text = unit.Description;
                checkActive.Checked = unit.IsActive;
            }
            else
                XtraMessageBox.Show("Vui lòng chọn", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void FormUpdateUnit_KeyDown(object sender, KeyEventArgs e)
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