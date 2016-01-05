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
    public partial class FormAddUnit : XtraForm
    {
        private readonly UnitService _unitService;
        private readonly LogService _logService;
        private readonly EmployeeService _employeeService;

        public FormAddUnit()
        {
            InitializeComponent();
            _unitService = new UnitService();
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
            _logService.InsertLog(userName, employeeName, itemName, Resources.FormTitleUnit, info);
        }

        private void FormAddUnit_FormClosing(object sender, FormClosingEventArgs e)
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
            if (string.IsNullOrEmpty(txtUnitID.Text))
            {
                txtUnitID.Properties.Appearance.BorderColor = System.Drawing.Color.Red;
                XtraMessageBox.Show("Mã Đơn Vị không được để trống !", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUnitID.Focus();
            }
            else if (string.IsNullOrEmpty(txtUnitName.Text))
            {
                txtUnitName.Properties.Appearance.BorderColor = System.Drawing.Color.Red;
                XtraMessageBox.Show("Tên Đơn Vị không được để trống !", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUnitName.Focus();
            }
            else
            {
                if (_unitService.CheckUnitIdExit(txtUnitID.Text))
                {
                    var unit = new Unit()
                    {
                        UnitID = txtUnitID.Text,
                        UnitName = txtUnitName.Text,
                        Description = txtDescription.Text,
                        CreatedDate = DateTime.Now,
                        IsActive = checkActive.Checked,
                        CreatedBy = null
                    };
                    try
                    {
                        _unitService.Add(unit);
                        InsertSysLog(txtUnitName.Text);
                        if (XtraMessageBox.Show("Thêm thành công.\n Bạn có muốn thêm mới Đơn Vị nữa không?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
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
                else
                {
                    txtUnitID.Properties.Appearance.BorderColor = System.Drawing.Color.Red;
                    XtraMessageBox.Show(string.Format("Mã Đơn vị {0} đã tồn tại rồi", txtUnitID.Text), "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUnitID.SelectAll();
                    txtUnitID.Focus();
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
        /// Reset Text
        /// </summary>
        private void ResetControls()
        {
            txtUnitID.Text = "";
            txtUnitName.Text = "";
            txtDescription.Text = "";

            if (txtUnitName.Properties.Appearance.BorderColor == System.Drawing.Color.Red)
            {
                txtUnitName.Properties.Appearance.BorderColor = System.Drawing.Color.LightGray;
            }
            if (txtUnitID.Properties.Appearance.BorderColor == System.Drawing.Color.Red)
            {
                txtUnitID.Properties.Appearance.BorderColor = System.Drawing.Color.LightGray;
            }
        }

        private void FormAddUnit_KeyDown(object sender, KeyEventArgs e)
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