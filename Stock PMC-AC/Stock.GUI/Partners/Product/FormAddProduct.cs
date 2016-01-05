using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Stock.Data;
using Stock.GUI.Helpers;
using Stock.GUI.Properties;
using Stock.Services;

namespace Stock.GUI.Partners
{
    public partial class FormAddProduct : XtraForm
    {
        private readonly ProductService _productService;
        private readonly StockService _stockService;
        private readonly ProductGroupService _productGroupService;
        private readonly UnitService _unitService;
        private readonly SuppliersService _suppliersService;
        private readonly ColorService _colorService;
        private readonly EmployeeService _employeeService;
        private readonly LogService _logService;
        public FormAddProduct()
        {
            InitializeComponent();
            _productService = new ProductService();
            _stockService = new StockService();
            _productGroupService = new ProductGroupService();
            _unitService = new UnitService();
            _suppliersService = new SuppliersService();
            _colorService = new ColorService();
            _employeeService = new EmployeeService();
            _logService = new LogService();
            LoadGirdLookUpStock();
            LoadGirdLookUpProductGroup();
            LoadGirdLookUpSuppliers();
            LoadGirdLookUpUnit();
            LoadGirdLookUpColor();
            txtProductID.Text = _productService.NextId();
            txtBarcode.Text = _productService.NextId();
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
            _logService.InsertLog(userName, employeeName, itemName, Resources.FormTitleProduct, info);
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

        /// <summary>
        /// Lưu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(gridLookUpEditStock.Text))
            {
                gridLookUpEditStock.Properties.Appearance.BackColor = System.Drawing.Color.Red;
                XtraMessageBox.Show("Vui lòng chọn một Nhà Cung Cấp!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gridLookUpEditStock.Focus();
            }
            else if (string.IsNullOrEmpty(gridLookUpEditProductGroup.Text))
            {
                gridLookUpEditProductGroup.Properties.Appearance.BackColor = System.Drawing.Color.Red;
                XtraMessageBox.Show("Vui lòng chọn một Nhóm Hàng!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gridLookUpEditProductGroup.Focus();
            }
            else if (string.IsNullOrEmpty(txtProductID.Text))
            {
                txtProductID.Properties.Appearance.BackColor = System.Drawing.Color.Red;
                XtraMessageBox.Show("Mã Hàng Hóa không được bỏ trống!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProductID.Focus();
            }
            else if (string.IsNullOrEmpty(txtProductName.Text))
            {
                txtProductName.Properties.Appearance.BackColor = System.Drawing.Color.Red;
                XtraMessageBox.Show("Tên Hàng Hóa không được bỏ trống!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProductName.Focus();
            }
            else if (string.IsNullOrEmpty(gridLookUpEditSuppliers.Text))
            {
                gridLookUpEditSuppliers.Properties.Appearance.BackColor = System.Drawing.Color.Red;
                XtraMessageBox.Show("Vui lòng chọn một Nhà Cung Cấp!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gridLookUpEditSuppliers.Focus();
            }
            else if (string.IsNullOrEmpty(gridLookUpEditUnit.Text))
            {
                gridLookUpEditUnit.Properties.Appearance.BackColor = System.Drawing.Color.Red;
                XtraMessageBox.Show("Vui lòng chọn một Đơn Vị Tính!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gridLookUpEditUnit.Focus();
            }
            else if (string.IsNullOrEmpty(txtPrice.Text))
            {
                txtPrice.Properties.Appearance.BackColor = System.Drawing.Color.Red;
                XtraMessageBox.Show("Giá không được bỏ trống!", "THÔNG BÁO", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtPrice.Focus();
            }
            else
            {
                var product = new Product()
                {
                    ProductID = txtProductID.Text,
                    ProductName = txtProductName.Text,
                    ProductGroupID = gridLookUpEditProductGroup.EditValue.ToString(),
                    StockID = gridLookUpEditStock.EditValue.ToString(),
                    UnitID = gridLookUpEditUnit.EditValue.ToString(),
                    SupplierID = gridLookUpEditSuppliers.EditValue.ToString(),
                    Origin = txtOrigin.Text,
                    Barcode = string.IsNullOrEmpty(txtBarcode.Text) ? _productService.NextId() : txtBarcode.Text,
                    //Quantity = int.Parse(txtQuantity.Text),
                    Description = txtDescription.Text,
                    IsActive = checkActive.Checked,
                    CreatedDate = DateTime.Now,
                    Price = Convert.ToInt32(txtPrice.Text),
                };
                if (!string.IsNullOrEmpty(gridLookUpEditColor.SelectedText))
                {
                    product.ColorID = Convert.ToInt32(gridLookUpEditColor.EditValue.ToString());
                }
                try
                {
                    _productService.Add(product);
                    InsertSysLog(txtProductName.Text);
                    if (XtraMessageBox.Show("Thêm thành công.\n Bạn có muốn thêm mới Hàng Hóa nữa không?", "HỎI", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
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
                    XtraMessageBox.Show(string.Format("Lỗi {0}", ex.Message), "THÔNG BÁO", MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                }
            }
        }

        /// <summary>
        /// Show form Thêm Kho Hàng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridLookUpEditStock_Properties_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                var showFormAddStock = new FormAddStock();
                showFormAddStock.ShowDialog();
                LoadGirdLookUpStock();
            }
        }

        /// <summary>
        /// Show Form Add Nhóm Hàng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridLookUpEdit1_Properties_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                var showFormAddProductGroup = new FormAddProductGroup();
                showFormAddProductGroup.ShowDialog();
                LoadGirdLookUpProductGroup();
            }
        }

        /// <summary>
        /// Show Form Add Đơn Vị Tính
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridLookUpEditUnit_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                var showFormAddUnit = new FormAddUnit();
                showFormAddUnit.ShowDialog();
                LoadGirdLookUpUnit();
            }
        }

        /// <summary>
        /// Show Form Thêm Nhà Cung Cấp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridLookUpEditSuppliers_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                var showFormAddSupplier = new FormAddSuppliers();
                showFormAddSupplier.ShowDialog();
                LoadGirdLookUpSuppliers();
            }
        }

        /// <summary>
        /// Show Form Thêm Màu Sắc
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridLookUpEditColor_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                var showFormAddColor = new FormAddColor();
                showFormAddColor.ShowDialog();
                LoadGirdLookUpColor();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        private void ResetControls()
        {
            txtProductID.Text = _productService.NextId();
            txtBarcode.Text = _productService.NextId();

            if (gridLookUpEditStock.Properties.Appearance.BorderColor == System.Drawing.Color.Red)
            {
                gridLookUpEditStock.Properties.Appearance.BorderColor = System.Drawing.Color.LightGray;
            }
            if (gridLookUpEditProductGroup.Properties.Appearance.BorderColor == System.Drawing.Color.Red)
            {
                gridLookUpEditProductGroup.Properties.Appearance.BorderColor = System.Drawing.Color.LightGray;
            }
            if (txtProductName.Properties.Appearance.BorderColor == System.Drawing.Color.Red)
            {
                txtProductName.Properties.Appearance.BorderColor = System.Drawing.Color.LightGray;
            }
            if (gridLookUpEditUnit.Properties.Appearance.BorderColor == System.Drawing.Color.Red)
            {
                gridLookUpEditUnit.Properties.Appearance.BorderColor = System.Drawing.Color.LightGray;
            }
            if (gridLookUpEditSuppliers.Properties.Appearance.BorderColor == System.Drawing.Color.Red)
            {
                gridLookUpEditSuppliers.Properties.Appearance.BorderColor = System.Drawing.Color.LightGray;
            }
            if (txtPrice.Properties.Appearance.BorderColor == System.Drawing.Color.Red)
            {
                txtPrice.Properties.Appearance.BorderColor = System.Drawing.Color.LightGray;
            }
        }

        /// <summary>
        /// Load danh sách Kho Hàng
        /// </summary>
        private void LoadGirdLookUpStock()
        {
            var stocks = _stockService.GetStocks();
            gridLookUpEditStock.Properties.View.OptionsBehavior.AutoPopulateColumns = false;
            gridLookUpEditStock.Properties.DisplayMember = "StockName";
            gridLookUpEditStock.Properties.ValueMember = "StockID";
            gridLookUpEditStock.Properties.View.BestFitColumns();
            gridLookUpEditStock.Properties.PopupFormWidth = 300;
            gridLookUpEditStock.Properties.DataSource = stocks;
        }

        /// <summary>
        /// Load danh sách nhóm hàng
        /// </summary>
        private void LoadGirdLookUpProductGroup()
        {
            var stocks = _productGroupService.GetProductGroups();
            gridLookUpEditProductGroup.Properties.View.OptionsBehavior.AutoPopulateColumns = false;
            gridLookUpEditProductGroup.Properties.DisplayMember = "ProductGroupName";
            gridLookUpEditProductGroup.Properties.ValueMember = "ProductGroupID";
            gridLookUpEditProductGroup.Properties.View.BestFitColumns();
            gridLookUpEditProductGroup.Properties.PopupFormWidth = 406;
            gridLookUpEditProductGroup.Properties.DataSource = stocks;
        }


        /// <summary>
        /// Load danh sách Đơn vị tính
        /// </summary>
        private void LoadGirdLookUpUnit()
        {
            var units = _unitService.GetUnits();
            gridLookUpEditUnit.Properties.View.OptionsBehavior.AutoPopulateColumns = false;
            gridLookUpEditUnit.Properties.DisplayMember = "UnitName";
            gridLookUpEditUnit.Properties.ValueMember = "UnitID";
            gridLookUpEditUnit.Properties.View.BestFitColumns();
            gridLookUpEditUnit.Properties.PopupFormWidth = 300;
            gridLookUpEditUnit.Properties.DataSource = units;

        }

        /// <summary>
        /// Load danh sách Nhà Cung Cấp
        /// </summary>
        private void LoadGirdLookUpSuppliers()
        {
            var suppliers = _suppliersService.GetSuppliers();
            gridLookUpEditSuppliers.Properties.View.OptionsBehavior.AutoPopulateColumns = false;
            gridLookUpEditSuppliers.Properties.DisplayMember = "SupplierName";
            gridLookUpEditSuppliers.Properties.ValueMember = "SupplierID";
            gridLookUpEditSuppliers.Properties.View.BestFitColumns();
            gridLookUpEditSuppliers.Properties.PopupFormWidth = 385;
            gridLookUpEditSuppliers.Properties.DataSource = suppliers;

        }
        /// <summary>
        /// Load danh sách màu sắc
        /// </summary>
        private void LoadGirdLookUpColor()
        {
            var colors = _colorService.GetColors();
            gridLookUpEditColor.Properties.View.OptionsBehavior.AutoPopulateColumns = false;
            gridLookUpEditColor.Properties.DisplayMember = "ColorName";
            gridLookUpEditColor.Properties.ValueMember = "ColorID";
            gridLookUpEditColor.Properties.View.BestFitColumns();
            gridLookUpEditColor.Properties.PopupFormWidth = 300;
            gridLookUpEditColor.Properties.DataSource = colors;
        }

        private void FormAddProduct_KeyDown(object sender, KeyEventArgs e)
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

        private void FormAddProduct_Load(object sender, EventArgs e)
        {
            txtProductName.Focus();
        }

        private void txtBarcode_Click(object sender, EventArgs e)
        {
            txtBarcode.SelectAll();
        }

    }
}