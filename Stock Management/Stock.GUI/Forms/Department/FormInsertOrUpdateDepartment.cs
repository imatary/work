using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Stock.Data;
using Stock.GUI.Helper;
using Stock.GUI.Properties;
using Stock.Services;

namespace Stock.GUI.Forms
{
    public partial class FormInsertOrUpdateDepartment : XtraForm
    {
        private readonly LogService _logService;
        private readonly DepartmentService _departmentService;
        private Department _department;

        private string _departmentId;

        public FormInsertOrUpdateDepartment(string departmentId)
        {
            InitializeComponent();

            _logService = new LogService();
            _departmentService = new DepartmentService();

            _departmentId = departmentId;
        }

        private void LoadData()
        {
            if (!string.IsNullOrEmpty(_departmentId))
            {
                _department = _departmentService.GetDepartmentById(_departmentId);
                txtDepartmentID.Text = _departmentId;
                txtDepartmentName.Text = _department.DepartmentName;
                txtDescription.Text = _department.Description;
                checkActive.Checked = _department.Active;
            }
            else
            {
                txtDepartmentID.Text = _departmentService.NextId();
            }
        }

        private void FormInsertOrUpdateDepartment_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void FormInsertOrUpdateDepartment_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                dynamic mboxResult = XtraMessageBox.Show(Resources.MessageBoxColseForm,
                    Resources.MessageBoxTitle,
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);
                if (mboxResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else if (mboxResult == DialogResult.Yes)
                {
                    e.Cancel = false;
                    Dispose();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show(Resources.MessageBoxColseForm, Resources.MessageBoxTitle, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Dispose();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtDepartmentID.Text))
            {
                Ultils.TextControlNotNull(txtDepartmentID, "Mã Bộ Phận");
            }
            else if (string.IsNullOrEmpty(txtDepartmentName.Text))
            {
                Ultils.TextControlNotNull(txtDepartmentName, "Tên Bộ Phận");
            }
            else
            {
                if (string.IsNullOrEmpty(_departmentId))
                {
                    _department = new Department()
                    {
                        DepartmentID = txtDepartmentID.Text.Trim(),
                        DepartmentName = txtDepartmentName.Text,
                        Active = checkActive.Checked,
                        CreatedDate = DateTime.Now,
                        CreatedBy = Program.CurrentUser.Username,
                    };
                    try
                    {
                        _departmentService.Add(_department);
                        _logService.InsertLog(Program.CurrentUser.Username, "Thêm", this.Text);
                        MessageBoxHelper.ShowMessageBoxSuccess("Thêm thành công!");
                        ResetControls();
                    }
                    catch (Exception ex)
                    {
                        MessageBoxHelper.ShowMessageBoxError(ex.Message);
                    }

                }
                else
                {
                    _department = _departmentService.GetDepartmentById(_departmentId);
                    if (_departmentId != null)
                    {
                        _department.DepartmentName = txtDepartmentName.Text;
                        _department.Description = txtDescription.Text;
                        _department.Active = checkActive.Checked;
                        _department.ModifyDate = DateTime.Now;
                        _department.ModifyBy = Program.CurrentUser.Username;

                        try
                        {
                            _departmentService.Update(_department);
                            _logService.InsertLog(Program.CurrentUser.Username, "Sửa", this.Text);
                            MessageBoxHelper.ShowMessageBoxSuccess("Sửa thành công!");
                            ResetControls();
                        }
                        catch (Exception ex)
                        {
                            MessageBoxHelper.ShowMessageBoxError(ex.Message);
                        }
                    }

                }
            }
        }

        private void ResetControls()
        {
            _departmentId = null;

            txtDepartmentID.Text = _departmentService.NextId();
            txtDepartmentName.Text = string.Empty;
            txtDescription.Text = string.Empty;
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
                btnSave.PerformClick();
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Control | Keys.S:
                    {
                        btnSave.PerformClick();
                        return true;
                    }
                case Keys.Escape:
                    {
                        btnClose.PerformClick();
                        return true;
                    }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}