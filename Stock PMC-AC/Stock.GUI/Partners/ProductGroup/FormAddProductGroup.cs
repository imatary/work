using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Stock.Data;
using Stock.GUI.Helpers;
using Stock.GUI.Properties;
using Stock.Services;

namespace Stock.GUI.Partners
{
    public partial class FormAddProductGroup : XtraForm
    {
        private readonly ProductGroupService _productGroupService;
        private readonly LogService _logService;
        private readonly EmployeeService _employeeService;
        public FormAddProductGroup()
        {
            InitializeComponent();
            _productGroupService = new ProductGroupService();
            _employeeService = new EmployeeService();
            _logService = new LogService();
            txtProductGroupID.Text = _productGroupService.NextId();
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
            _logService.InsertLog(userName, employeeName, itemName, Resources.FormTitleProductGroup, info);
        }

        private void FormAddProductGroup_FormClosing(object sender, FormClosingEventArgs e)
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
            if (string.IsNullOrEmpty(txtProductGroupID.Text))
            {
                txtProductGroupID.Properties.Appearance.BorderColor = System.Drawing.Color.Red;
                XtraMessageBox.Show("Mã Nhóm hàng không được để trống !", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProductGroupID.Focus();
            }
            else if (string.IsNullOrEmpty(txtProductGroupName.Text))
            {
                txtProductGroupName.Properties.Appearance.BorderColor = System.Drawing.Color.Red;
                XtraMessageBox.Show("Tên Nhóm Hàng không được để trống !", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProductGroupName.Focus();
            }
            else
            {
                var productGroup = new ProductGroup()
                {
                    ProductGroupID = txtProductGroupID.Text,
                    ProductGroupName = txtProductGroupName.Text,
                    Description = txtDescription.Text,
                    IsActive = checkActive.Checked,
                    CreatedBy = null,
                    CreatedDate = DateTime.Now
                };
                try
                {
                    _productGroupService.Add(productGroup);
                    InsertSysLog(txtProductGroupName.Text);
                    if (XtraMessageBox.Show("Thêm thành công.\n Bạn có muốn thêm mới Nhóm Hàng nữa không?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
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

        private void txtProductGroupID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                txtProductGroupName.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                txtProductGroupID.Text = _productGroupService.NextId();
            }
        }

        private void txtProductGroupName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                txtProductGroupName.SelectAll();
                txtProductGroupName.Focus();
            }
            else if (e.KeyCode == Keys.Tab)
            {
                txtProductGroupName.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                txtProductGroupName.Text = string.Empty;
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
                txtProductGroupName.SelectAll();
                txtProductGroupName.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                btnSave.Focus();
            }
        }

        
        private void ResetControls()
        {
            txtProductGroupID.Text = _productGroupService.NextId();
            txtProductGroupName.Text = "";
            txtDescription.Text = "";
            checkActive.Checked = true;
            if (txtProductGroupID.Properties.Appearance.BorderColor == System.Drawing.Color.Red)
            {
                txtProductGroupID.Properties.Appearance.BorderColor = System.Drawing.Color.LightGray;
            }
            if (txtProductGroupName.Properties.Appearance.BorderColor == System.Drawing.Color.Red)
            {
                txtProductGroupName.Properties.Appearance.BorderColor = System.Drawing.Color.LightGray;
            }
        }

        private void FormAddProductGroup_KeyDown(object sender, KeyEventArgs e)
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