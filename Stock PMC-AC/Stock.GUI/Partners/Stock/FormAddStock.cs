using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Stock.GUI.Helpers;
using Stock.GUI.Properties;
using Stock.Services;

namespace Stock.GUI.Partners
{
    public partial class FormAddStock : XtraForm
    {
        private readonly StockService _stockService;
        private readonly EmployeeService _employeeService;
        private readonly LogService _logService;
        public FormAddStock()
        {
            InitializeComponent();
            _stockService = new StockService();
            _employeeService = new EmployeeService();
            _logService = new LogService();
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
            _logService.InsertLog(userName, employeeName, itemName, Resources.FormTitleStock, info);
        }

        /// <summary>
        /// 
        /// </summary>
        private void ResetControls()
        {
            txtStockID.Text = _stockService.NextId();
            txtStockName.Text = "";
            txtPhone.Text = "";
            txtMobile.Text = "";
            txtAddress.Text = "";
            txtEmail.Text = "";
            txtFax.Text = "";
            txtManager.Text = "";
            txtDescription.Text = "";

            if (txtStockID.Properties.Appearance.BorderColor == System.Drawing.Color.Red)
            {
                txtStockID.Properties.Appearance.BorderColor = System.Drawing.Color.LightGray;
            }
            if (txtStockName.Properties.Appearance.BorderColor == System.Drawing.Color.Red)
            {
                txtStockName.Properties.Appearance.BorderColor = System.Drawing.Color.LightGray;
            }
        }

        private void FormAddStock_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtStockID.Text = _stockService.NextId()))
            {
                txtStockName.Focus();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtStockID.Text))
            {
                txtStockID.Properties.Appearance.BorderColor = System.Drawing.Color.Red;
                XtraMessageBox.Show("Mã Kho Hàng không được bỏ trống!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStockID.Focus();
            }
            else if (string.IsNullOrEmpty(txtStockName.Text))
            {
                txtStockName.Properties.Appearance.BorderColor = System.Drawing.Color.Red;
                XtraMessageBox.Show("Tên Kho Hàng không được bỏ trống!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStockName.Focus();
            }
            else if (!_stockService.CheckStockNameExit(txtStockName.Text))
            {
                txtStockName.Properties.Appearance.BorderColor = System.Drawing.Color.Red;
                XtraMessageBox.Show("Tên Kho Hàng này đã tồn tại rồi!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStockName.Focus();
            }
            else
            {
                var stock = new Data.Stock()
                {
                    StockID = txtStockID.Text,
                    StockName = txtStockName.Text,
                    Contact = txtContact.Text,
                    Adress = txtAddress.Text,
                    Email = txtEmail.Text,
                    Telephone = txtPhone.Text,
                    Mobile = txtMobile.Text,
                    Fax = txtFax.Text,
                    Manager = txtManager.Text,
                    Description = txtDescription.Text,
                    IsActive = checkActive.Checked,
                    CreatedDate = DateTime.Now,
                    CreatedBy = null,

                };
                try
                {
                    _stockService.Add(stock);
                    InsertSysLog(txtStockName.Text);
                    if (XtraMessageBox.Show("Thêm thành công.\n Bạn có muốn thêm mới Kho Hàng nữa không?", "HỎI", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
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

        private void txtStockID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                txtStockName.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                txtStockID.Text = _stockService.NextId();
            }
        }

        private void txtStockName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                if (txtStockName.Properties.Appearance.BorderColor == System.Drawing.Color.Red)
                {
                    txtStockName.Properties.Appearance.BorderColor = System.Drawing.Color.LightGray;
                }
                btnSave.Focus();
                btnSave.PerformClick();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                txtStockName.Text = string.Empty;
            }
            else if (e.KeyCode == Keys.Tab)
            {
                if (txtStockName.Properties.Appearance.BorderColor == System.Drawing.Color.Red)
                {
                    txtStockName.Properties.Appearance.BorderColor = System.Drawing.Color.LightGray;
                }
                txtContact.Focus();
            }
        }

        private void txtContact_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                txtAddress.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                txtContact.Text = string.Empty;
            }
        }

        private void txtAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                txtPhone.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                txtAddress.Text = string.Empty;
            }
        }

        private void txtPhone_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                txtMobile.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                txtPhone.Text = string.Empty;
            }
        }

        private void txtMobile_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                txtFax.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                txtMobile.Text = string.Empty;
            }
        }

        private void txtFax_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                txtEmail.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                txtFax.Text = string.Empty;
            }
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                txtManager.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                txtEmail.Text = string.Empty;
            }
        }

        private void txtManager_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                txtDescription.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                txtManager.Text = string.Empty;
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
                txtStockName.SelectAll();
                txtStockName.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                btnSave.Focus();
            }
        }

        private void FormAddStock_KeyDown(object sender, KeyEventArgs e)
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