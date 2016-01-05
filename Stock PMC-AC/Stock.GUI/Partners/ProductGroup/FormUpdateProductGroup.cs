using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Stock.Data;
using Stock.GUI.Helpers;
using Stock.GUI.Properties;
using Stock.Services;

namespace Stock.GUI.Partners
{
    public partial class FormUpdateProductGroup : XtraForm
    {
        private readonly string _productGroupId;
        private readonly ProductGroupService _productGroupService;
        private readonly LogService _logService;
        private readonly EmployeeService _employeeService;
        public FormUpdateProductGroup(string productGroupId)
        {
            InitializeComponent();
            _productGroupService = new ProductGroupService();
            _employeeService = new EmployeeService();
            _logService = new LogService();
            _productGroupId = productGroupId;
            GetProductGroupById(productGroupId);
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
            _logService.InsertLog(userName, employeeName, itemName, Resources.FormTitleProductGroup, info);
        }

        private void FormUpdateProductGroup_FormClosing(object sender, FormClosingEventArgs e)
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
                XtraMessageBox.Show("Mã Nhóm hàng không được để trống !", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProductGroupID.Focus();
            }
            else if (string.IsNullOrEmpty(txtProductGroupName.Text))
            {
                XtraMessageBox.Show("Tên Nhóm Hàng không được để trống !", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtProductGroupName.Focus();
            }
            else
            {
                ProductGroup productGroup = _productGroupService.GetProductGrouprById(_productGroupId);
                if (productGroup != null)
                {
                    productGroup.ProductGroupName = txtProductGroupName.Text;
                    productGroup.Description = txtDescription.Text;
                    productGroup.IsActive = checkActive.Checked;
                    productGroup.ModifyDate = DateTime.Now;
                    productGroup.UpdateBy = null;
                }
                try
                {
                    _productGroupService.Update(productGroup);
                    InsertSysLog(txtProductGroupName.Text);
                    XtraMessageBox.Show("Sửa thành công", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnClose_Click(sender, e);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(string.Format("Lỗi {0}", ex.Message), "THÔNG BÁO");
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
                txtProductGroupID.Text = string.Empty;
            }
        }

        private void txtProductGroupName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                txtDescription.Focus();
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

        /// <summary>
        /// Lấy về thông tin Nhóm Hàng theo ID
        /// </summary>
        /// <param name="productGroupId"></param>
        private void GetProductGroupById(string productGroupId)
        {
            ProductGroup productGroup = _productGroupService.GetProductGrouprById(productGroupId);
            if (productGroup != null)
            {
                txtProductGroupID.Text = productGroup.ProductGroupID;
                txtProductGroupName.Text = productGroup.ProductGroupName;
                txtDescription.Text = productGroup.Description;
                checkActive.Checked = productGroup.IsActive;
            }
            else
                XtraMessageBox.Show("Vui lòng chọn", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void FormUpdateProductGroup_KeyDown(object sender, KeyEventArgs e)
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