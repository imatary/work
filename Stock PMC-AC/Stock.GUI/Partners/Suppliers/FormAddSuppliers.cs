using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Stock.Data;
using Stock.GUI.Helpers;
using Stock.GUI.Properties;
using Stock.Services;

namespace Stock.GUI.Partners
{
    public partial class FormAddSuppliers : XtraForm
    {

        private readonly SuppliersService _suppliersService;
        private readonly AreaService _areaService;
        private readonly LogService _logService;
        private readonly EmployeeService _employeeService;
        public FormAddSuppliers()
        {
            InitializeComponent();
            _suppliersService = new SuppliersService();
            _areaService = new AreaService();
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
            _logService.InsertLog(userName, employeeName, itemName, Resources.FormTitleSuppliers, info);
        }

        /// <summary>
        /// Tạo ID Kế tiếp
        /// </summary>
        /// <returns></returns>
        private string NextId()
        {
            Supplier suppliers = _suppliersService.GetSuppliers().Last();
            if (suppliers != null)
            {
                string lastId = suppliers.SupplierID.Remove(0, 3);
                string suppliersId;
                if (!string.IsNullOrEmpty(lastId))
                {
                    int nextId = int.Parse(lastId) + 1;
                    suppliersId = string.Format("NCC{0}", nextId.ToString(CultureInfo.InvariantCulture).PadLeft(5, '0'));
                }
                else
                {
                    suppliersId = string.Format("NCC0000{0}", 1);
                }
                txtSupplierName.Focus();
                return suppliersId;
            }
            return string.Format("NCC0000{0}", 1);
        }

        
        /// <summary>
        /// Form Load
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormAddSuppliers_Load(object sender, EventArgs e)
        {
            LoadGirdLookUpArea();   
            
            txtSupplierID.Text = NextId();         
            if (!string.IsNullOrEmpty(txtSupplierID.Text))
            {
                txtSupplierName.Focus();
            }  
        }

        /// <summary>
        /// Đóng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormAddSuppliers_FormClosing(object sender, FormClosingEventArgs e)
        {
            Close();
        }
        /// <summary>
        /// Đóng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSupplierID.Text))
            {
                txtSupplierID.Properties.Appearance.BorderColor = System.Drawing.Color.Red;
                XtraMessageBox.Show("Mã Nhà cung cấp không được bỏ trống!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSupplierID.Focus();
            }
            else if (string.IsNullOrEmpty(txtSupplierName.Text))
            {
                txtSupplierName.Properties.Appearance.BorderColor = System.Drawing.Color.Red;
                XtraMessageBox.Show("Tên Nhà cung cấp không được bỏ trống!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSupplierName.Focus();
            }
            else if (string.IsNullOrEmpty(gridLookUpEdit1.Text))
            {
                gridLookUpEdit1.Properties.Appearance.BorderColor = System.Drawing.Color.Red;
                XtraMessageBox.Show("Bạn phải chọn một Khu vực cho Nhà cung cấp này!", "THÔNG BÁO", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                gridLookUpEdit1.Focus();
            }
            else
            {
                var supplier = new Supplier
                {
                    SupplierID = txtSupplierID.Text,
                    AreaID = gridLookUpEdit1View.GetFocusedRowCellValue("AreaID").ToString(),
                    SupplierName = txtSupplierName.Text,
                    PhoneNumber = txtPhone.Text,
                    Mobile = txtMoblie.Text,
                    Address = txtAddress.Text,
                    Email = txtEmail.Text,
                    AccountNumber = txtAccountNumber.Text,
                    Bank = txtBank.Text,
                    Fax = txtFax.Text,
                    Website = txtWebsite.Text,
                    IsActive = checkActive.Checked,
                    CreatedDate = DateTime.Now,
                    CreatedBy = null,

                };
                try
                {
                    _suppliersService.Add(supplier);
                    InsertSysLog(txtSupplierName.Text);
                    if (XtraMessageBox.Show("Thêm thành công.\n Bạn có muốn thêm mới Nhà cung cấp nữa không?", "HỎI", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
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

        /// <summary>
        /// 
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

        private void gridLookUpEdit1_Properties_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index==1)
            {
                var addArea=new FormAddArea();
                addArea.ShowDialog();
                LoadGirdLookUpArea();
                Refresh();
            }
        }

        private void ResetControls()
        {
            txtSupplierID.Text = NextId();
            txtSupplierName.Focus();
            txtSupplierName.Text = "";
            txtPhone.Text = "";
            txtMoblie.Text = "";
            txtAddress.Text = "";
            txtEmail.Text = "";
            txtAccountNumber.Text = "";
            txtBank.Text = "";
            txtFax.Text = "";
            txtWebsite.Text = "";
            if (txtSupplierName.Properties.Appearance.BorderColor == System.Drawing.Color.Red)
            {
                txtSupplierName.Properties.Appearance.BorderColor = System.Drawing.Color.LightGray;
            }
            if (gridLookUpEdit1.Properties.Appearance.BorderColor == System.Drawing.Color.Red)
            {
                gridLookUpEdit1.Properties.Appearance.BorderColor = System.Drawing.Color.LightGray;
            }
        }

        private void FormAddSuppliers_KeyDown(object sender, KeyEventArgs e)
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