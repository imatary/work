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
    public partial class FormUpdateProduct : XtraForm
    {
        private readonly ProductService _productService;
        private readonly StockService _stockService;
        private readonly ProductGroupService _productGroupService;
        private readonly UnitService _unitService;
        private readonly SuppliersService _suppliersService;
        private readonly ColorService _colorService;
        private readonly EmployeeService _employeeService;
        private readonly LogService _logService;
        private readonly string _productId;
        public FormUpdateProduct(string productId)
        {
            InitializeComponent();
            _productId = productId;
            _productService = new ProductService();
            _stockService = new StockService();
            _productGroupService = new ProductGroupService();
            _unitService = new UnitService();
            _suppliersService = new SuppliersService();
            _colorService = new ColorService();
            _employeeService = new EmployeeService();
            _logService = new LogService();
            GetProductById(productId);
            LoadGirdLookUpStock();
            LoadGirdLookUpProductGroup();
            LoadGirdLookUpSuppliers();
            LoadGirdLookUpUnit();
            LoadGirdLookUpColor();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productId"></param>
        private void GetProductById(string productId)
        {
            Product product = _productService.GetProductById(productId);
            if (product != null)
            {
                txtProductID.Text = product.ProductID;
                txtProductName.Text = product.ProductName;
                gridLookUpEditProductGroup.EditValue = product.ProductGroupID;
                gridLookUpEditStock.EditValue = product.StockID;
                gridLookUpEditUnit.EditValue = product.UnitID;
                gridLookUpEditColor.EditValue = product.ColorID;
                gridLookUpEditSuppliers.EditValue = product.SupplierID;
                txtBarcode.Text = product.Barcode;
                txtOrigin.Text = product.Origin;
                //txtQuantity.Text = product.Quantity.ToString();
                txtDescription.Text = product.Description;
                txtPrice.Text = product.Price.ToString();
                if (product.IsActive != null)
                    checkActive.Checked = (bool)product.IsActive;
            }
            else
                XtraMessageBox.Show("Vui lòng chọn", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                XtraMessageBox.Show("Vui lòng chọn một Nhà Cung Cấp!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gridLookUpEditStock.Focus();
            }
            else if (string.IsNullOrEmpty(gridLookUpEditProductGroup.Text))
            {
                XtraMessageBox.Show("Vui lòng chọn một Nhóm Hàng!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gridLookUpEditProductGroup.Focus();
            }
            else if (string.IsNullOrEmpty(txtProductID.Text))
            {
                XtraMessageBox.Show("Mã Hàng Hóa không được bỏ trống!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProductID.Focus();
            }
            else if (string.IsNullOrEmpty(txtProductName.Text))
            {
                XtraMessageBox.Show("Tên Hàng Hóa không được bỏ trống!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtProductName.Focus();
            }
            else if (string.IsNullOrEmpty(gridLookUpEditSuppliers.Text))
            {
                XtraMessageBox.Show("Vui lòng chọn một Nhà Cung Cấp!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gridLookUpEditSuppliers.Focus();
            }
            else if (string.IsNullOrEmpty(gridLookUpEditUnit.Text))
            {
                XtraMessageBox.Show("Vui lòng chọn một Đơn Vị Tính!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gridLookUpEditUnit.Focus();
            }
            else if (string.IsNullOrEmpty(txtPrice.Text))
            {
                XtraMessageBox.Show("Giá không được bỏ trống!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPrice.Focus();
            }
            else
            {


                Product product = _productService.GetProductById(_productId);
                if (product != null)
                {
                    product.ProductName = txtProductName.Text;
                    product.ProductGroupID = gridLookUpEditProductGroup.EditValue.ToString();
                    product.StockID = gridLookUpEditStock.EditValue.ToString();
                    product.UnitID = gridLookUpEditUnit.EditValue.ToString();
                    product.SupplierID = gridLookUpEditSuppliers.EditValue.ToString();
                    product.Barcode = txtBarcode.Text;
                    product.Origin = txtOrigin.Text;
                    //product.Quantity = int.Parse(txtQuantity.Text);
                    product.Description = txtDescription.Text;
                    product.IsActive = checkActive.Checked;
                    product.ModifyDate = DateTime.Now;
                    product.UpdateBy = null;
                    product.Price = int.Parse(txtPrice.Text);
                    if (!string.IsNullOrEmpty(gridLookUpEditColor.SelectedText))
                    {
                        product.ColorID = Convert.ToInt32(gridLookUpEditColor.EditValue.ToString());
                    }
                }
                try
                {
                    _productService.Update(product);
                    InsertSysLog(txtProductName.Text);
                    XtraMessageBox.Show("Sửa thành công", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnClose_Click(sender, e);

                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(string.Format("Lỗi {0}", ex.Message), "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        /// <summary>
        /// Show form Thêm Kho Hàng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridLookUpEditStock_Properties_ButtonPressed(object sender, ButtonPressedEventArgs e)
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
        private void gridLookUpEdit1_Properties_ButtonPressed(object sender, ButtonPressedEventArgs e)
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
        private void gridLookUpEditUnit_ButtonPressed(object sender, ButtonPressedEventArgs e)
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
        private void gridLookUpEditSuppliers_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                var showFormAddSupplier = new FormAddSuppliers();
                showFormAddSupplier.ShowDialog();
                LoadGirdLookUpStock();
            }
        }

        /// <summary>
        /// Show Form Thêm Màu Sắc
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridLookUpEditColor_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                var showFormAddColor = new FormAddColor();
                showFormAddColor.ShowDialog();
                LoadGirdLookUpColor();
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

        private void FormUpdateProduct_KeyDown(object sender, KeyEventArgs e)
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