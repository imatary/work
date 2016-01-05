using System;
using System.Data.Entity;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Stock.Data;
using Stock.GUI.Helpers;
using Stock.GUI.Properties;
using Stock.Services;

namespace Stock.GUI.Partners
{
    public partial class FormUpdateSuppliers : XtraForm
    {
        private readonly string _supplierId;
        private readonly SuppliersService _suppliersService;
        private readonly AreaService _areaService;
        private readonly LogService _logService;
        private readonly EmployeeService _employeeService;
        public FormUpdateSuppliers(string supplierId)
        {
            InitializeComponent();
            _suppliersService = new SuppliersService();
            _areaService = new AreaService();
            _employeeService = new EmployeeService();
            _logService = new LogService();
            _supplierId = supplierId;
            GetSppliersById(supplierId);
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
            _logService.InsertLog(userName, employeeName, itemName, Resources.FormTitleSuppliers, info);
        }

        private void FormUpdateSuppliers_Load(object sender, EventArgs e)
        {
            LoadGirdLookUpArea();
        }

        private void FormUpdateSuppliers_FormClosing(object sender, FormClosingEventArgs e)
        {
            Close();
        }

        private void gridLookUpEdit1_Properties_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                var addArea = new FormAddArea();
                addArea.ShowDialog();
                LoadGirdLookUpArea();
                Refresh();
            }
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
            if (string.IsNullOrEmpty(txtSupplierID.Text))
            {
                XtraMessageBox.Show("Mã Nhà cung cấp không được bỏ trống!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSupplierID.Focus();
            }
            else if (string.IsNullOrEmpty(txtSupplierName.Text))
            {
                XtraMessageBox.Show("Tên Nhà cung cấp không được bỏ trống!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSupplierName.Focus();
            }
            else if (string.IsNullOrEmpty(gridLookUpEdit1.Text))
            {
                XtraMessageBox.Show("Bạn phải chọn một Khu vực cho Nhà cung cấp này!", "THÔNG BÁO", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                gridLookUpEdit1.Focus();
            }
            else
            {
                Supplier supplier = _suppliersService.GetSupplierById(_supplierId);

                if (supplier != null)
                {
                    supplier.SupplierID = txtSupplierID.Text;
                    supplier.AreaID = gridLookUpEdit1.EditValue.ToString();
                    supplier.SupplierName = txtSupplierName.Text;
                    supplier.PhoneNumber = txtPhone.Text;
                    supplier.Mobile = txtMoblie.Text;
                    supplier.Address = txtAddress.Text;
                    supplier.Email = txtEmail.Text;
                    supplier.AccountNumber = txtAccountNumber.Text;
                    supplier.Bank = txtBank.Text;
                    supplier.Fax = txtFax.Text;
                    supplier.Website = txtWebsite.Text;
                    supplier.IsActive = checkActive.Checked;
                    supplier.ModifyDate = DateTime.Now;
                    supplier.UpdateBy = null;

                }
                try
                {
                    _suppliersService.Update(supplier);
                    InsertSysLog(txtSupplierName.Text);
                    XtraMessageBox.Show("Sửa thành công", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnClose_Click(sender, e);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(string.Format("Lỗi {0}", ex.Message), "THÔNG BÁO", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                }

            }
        }

        /// <summary>
        /// Load khu vực
        /// </summary>
        public void LoadGirdLookUpArea()
        {
            var areas = _areaService.GetAreas();
            gridLookUpEdit1.Properties.View.OptionsBehavior.AutoPopulateColumns = false;
            gridLookUpEdit1.Properties.DisplayMember = "AreaName";
            gridLookUpEdit1.Properties.ValueMember = "AreaID";
            gridLookUpEdit1.Properties.View.BestFitColumns();
            gridLookUpEdit1.Properties.PopupFormWidth = 300;
            gridLookUpEdit1.Properties.DataSource = areas;
        }

        /// <summary>
        /// Trả về thông tin Nhà cung cấp theo ID
        /// </summary>
        /// <param name="supplierId"></param>
        private void GetSppliersById(string supplierId)
        {
            Supplier supplier = _suppliersService.GetSupplierById(supplierId);
            if (supplier != null)
            {
                txtSupplierID.Text = supplier.SupplierID;
                gridLookUpEdit1.EditValue = supplier.AreaID;
                txtSupplierName.Text = supplier.SupplierName;
                txtPhone.Text = supplier.PhoneNumber;
                txtMoblie.Text = supplier.Mobile;
                txtAddress.Text = supplier.Address;
                txtEmail.Text = supplier.Email;
                txtAccountNumber.Text = supplier.AccountNumber;
                txtBank.Text = supplier.Bank;
                txtFax.Text = supplier.Fax;
                txtWebsite.Text = supplier.Website;
                checkActive.Checked = supplier.IsActive;
            }
            else
                XtraMessageBox.Show("Vui lòng chọn", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void FormUpdateSuppliers_KeyDown(object sender, KeyEventArgs e)
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