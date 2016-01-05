using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Stock.GUI.Helpers;
using Stock.GUI.Properties;
using Stock.Services;

namespace Stock.GUI.Partners
{
    public partial class FormUpdateStock : XtraForm
    {
        private readonly string _stockId;
        private readonly StockService _stockService;
        private readonly EmployeeService _employeeService;
        private readonly LogService _logService;
        public FormUpdateStock(string stockId)
        {
            InitializeComponent();
            _stockService = new StockService();
            _employeeService = new EmployeeService();
            _logService = new LogService();
            _stockId = stockId;
            GetStockById(stockId);
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
            _logService.InsertLog(userName, employeeName, itemName, Resources.FormTitleStock, info);
        }

        /// <summary>
        /// Trả về thông tin Kho Hàng theo ID
        /// </summary>
        /// <param name="stockId"></param>
        private void GetStockById(string stockId)
        {
            Data.Stock stock = _stockService.GetStockById(stockId);
            if (stock != null)
            {
                txtStockID.Text = stock.StockID;
                txtStockName.Text = stock.StockName;
                txtPhone.Text = stock.Telephone;
                txtMobile.Text = stock.Mobile;
                txtAddress.Text = stock.Adress;
                txtEmail.Text = stock.Email;
                txtFax.Text = stock.Fax;
                txtManager.Text = stock.Manager;
                txtDescription.Text = stock.Description;
                txtContact.Text = stock.Contact;
            }
            else
                XtraMessageBox.Show("Vui lòng chọn Kho Hàng cần sửa", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void FormUpdateStock_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtStockID.Text))
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
                XtraMessageBox.Show("Mã Kho Hàng không được bỏ trống!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStockID.Focus();
            }
            else if (string.IsNullOrEmpty(txtStockName.Text))
            {
                XtraMessageBox.Show("Tên Kho Hàng không được bỏ trống!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStockName.Focus();
            }  
            else
            {
                Data.Stock stock = _stockService.GetStockById(_stockId);
                if(stock!=null)
                {
                    stock.StockID = txtStockID.Text;
                    stock.StockName = txtStockName.Text;
                    stock.Contact = txtContact.Text;
                    stock.Adress = txtAddress.Text;
                    stock.Email = txtEmail.Text;
                    stock.Telephone = txtPhone.Text;
                    stock.Mobile = txtMobile.Text;
                    stock.Fax = txtFax.Text;
                    stock.Manager = txtManager.Text;
                    stock.Description = txtDescription.Text;
                    stock.IsActive = checkActive.Checked;
                    stock.ModifyDate = DateTime.Now;
                    stock.UpdateBy = null;
                }
                try
                {
                    _stockService.Update(stock);
                    InsertSysLog(txtStockName.Text);
                    XtraMessageBox.Show("Sửa thành công", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnClose_Click(sender, e);
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
                txtStockID.Text = string.Empty;
            }
        }

        private void txtStockName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down)
            {
                txtContact.Focus();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                txtStockName.Text = string.Empty;
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

        private void FormUpdateStock_KeyDown(object sender, KeyEventArgs e)
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