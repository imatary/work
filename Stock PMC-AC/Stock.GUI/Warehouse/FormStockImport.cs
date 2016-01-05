using System;
using System.Collections;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraReports.UI;
using Stock.Data;
using Stock.GUI.Helpers;
using Stock.GUI.Models;
using Stock.GUI.Partners;
using Stock.GUI.Reports;
using Stock.Services;

namespace Stock.GUI.Warehouse
{
    public partial class FormStockImport : XtraForm
    {
        private readonly OrderImportService _orderImportService;
        private readonly SuppliersService _suppliersService;
        private readonly ProductService _productService;
        private readonly StockService _stockService;
        private readonly UnitService _unitService;
        private readonly OrderImportDetailService _orderImportDetailService;
        private readonly ManagersService _managersService;
        private readonly InventoryService _inventoryService;

        private readonly Cart.Order _order = new Cart.Order();
        private ArrayList _arrayList = new ArrayList();
        private readonly string _employeeId;
        private string _supplierId;
        private string _supplierName;
        private string _total;
        public FormStockImport()
        {
            InitializeComponent();

            _orderImportService = new OrderImportService();
            _suppliersService = new SuppliersService();
            _productService = new ProductService();
            _stockService = new StockService();
            _unitService = new UnitService();
            _orderImportDetailService = new OrderImportDetailService();
            _managersService = new ManagersService();
            _inventoryService = new InventoryService();

            _employeeId = Program.CurrentUser.EmployeeID;
            LoadGirdLookUpSuppliers();
            LoadGirdLookUpEmployees();
            LoadGirdLookUpProducts();
            LoadGirdLookUpStocks();
            LoadGirdLookUpUnits();
        }

        /// <summary>
        /// Load danh sách Nhà Cung Cấp
        /// </summary>
        private void LoadGirdLookUpSuppliers()
        {
            var suppliers = _suppliersService.GetSuppliers();
            try
            {
                gridLookUpEditSuppliers.Properties.View.OptionsBehavior.AutoPopulateColumns = false;
                gridLookUpEditSuppliers.Properties.DisplayMember = "SupplierName";
                gridLookUpEditSuppliers.Properties.ValueMember = "SupplierID";
                gridLookUpEditSuppliers.Properties.View.BestFitColumns();
                gridLookUpEditSuppliers.Properties.PopupFormWidth = 270;
                gridLookUpEditSuppliers.Properties.DataSource = suppliers;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(string.Format("Lỗi! \n {0}", ex.Message), "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }   
        }

        /// <summary>
        /// Load Danh sách Nhân Viên
        /// </summary>
        private void LoadGirdLookUpEmployees()
        {
            var employees = _managersService.GetEmployeeManagers();
            try
            {
                gridLookUpEditEmployee.Properties.View.OptionsBehavior.AutoPopulateColumns = false;
                gridLookUpEditEmployee.Properties.DisplayMember = "EmployeeName";
                gridLookUpEditEmployee.Properties.ValueMember = "EmployeeID";
                gridLookUpEditEmployee.Properties.View.BestFitColumns();
                gridLookUpEditEmployee.Properties.PopupFormWidth = 270;
                gridLookUpEditEmployee.Properties.DataSource = employees;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(string.Format("Lỗi! \n {0}", ex.Message), "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        /// <summary>
        /// Load danh sách Mặt Hàng
        /// </summary>
        private void LoadGirdLookUpProducts()
        {
            var products = _productService.GetProducts();
            try
            {
                gridLookUpEditProduct.Properties.View.OptionsBehavior.AutoPopulateColumns = false;
                gridLookUpEditProduct.Properties.DisplayMember = "ProductName";
                gridLookUpEditProduct.Properties.ValueMember = "ProductID";
                gridLookUpEditProduct.Properties.View.BestFitColumns();
                gridLookUpEditProduct.Properties.PopupFormWidth = 270;
                gridLookUpEditProduct.Properties.DataSource = products;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(string.Format("Lỗi! \n {0}", ex.Message), "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Load danh sách Kho Hàng
        /// </summary>
        private void LoadGirdLookUpStocks()
        {
            var stocks = _stockService.GetStocks();
            try
            {
                txtStock.Properties.View.OptionsBehavior.AutoPopulateColumns = false;
                txtStock.Properties.DisplayMember = "StockName";
                txtStock.Properties.ValueMember = "StockID";
                txtStock.Properties.View.BestFitColumns();
                txtStock.Properties.PopupFormWidth = 270;
                txtStock.Properties.DataSource = stocks;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(string.Format("Lỗi! \n {0}", ex.Message), "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        /// <summary>
        /// Load danh sách Đơn Vị
        /// </summary>
        private void LoadGirdLookUpUnits()
        {
            var units = _unitService.GetUnits();
            try
            {
                txtUnit.Properties.View.OptionsBehavior.AutoPopulateColumns = false;
                txtUnit.Properties.DisplayMember = "UnitName";
                txtUnit.Properties.ValueMember = "UnitID";
                txtUnit.Properties.View.BestFitColumns();
                txtUnit.Properties.PopupFormWidth = 270;
                txtUnit.Properties.DataSource = units;
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(string.Format("Lỗi! \n {0}", ex.Message), "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enable"></param>
        public void EnabledButtonSaveAndPrint(bool enable)
        {
            btnPrinter.Enabled = enable;
            btnSave.Enabled = enable;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormStockImport_Load(object sender, EventArgs e)
        {
            //GetOrderImports(DateTime.Now);
            txtOrderImportID.Text = _orderImportService.NextId();
            dateEditImportDate.EditValue = DateTime.Now.ToShortDateString();
            gridLookUpEditEmployee.EditValue = _employeeId;
            if (gridControlStockImport.DataSource == null)
            {
                EnabledButtonSaveAndPrint(false);
            }
        }

        private void gridLookUpEditSuppliers_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                var showAddSupplier = new FormAddSuppliers();
                showAddSupplier.ShowDialog();
                LoadGirdLookUpSuppliers();
            }
        }
        private void gridLookUpEditSuppliers_EditValueChanged(object sender, EventArgs e)
        {
            string supplierId = gridLookUpEditSuppliers.EditValue.ToString();
            Supplier supplier = _suppliersService.GetSupplierById(supplierId);
            if (supplier != null)
            {
                txtSupplierID.Text = supplier.SupplierID;
                txtPepole.Text = supplier.Representatives;
                txtPhone.Text = supplier.PhoneNumber;
                txtAddress.Text = supplier.Address;
            }

            gridLookUpEditSuppliers.Properties.Appearance.BorderColor = System.Drawing.Color.White;
            
        }

        private void gridLookUpEditProduct_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                var showAddProduct = new FormAddProduct();
                showAddProduct.ShowDialog();
                LoadGirdLookUpProducts();
            }
        }

        private void gridLookUpEditProduct_EditValueChanged(object sender, EventArgs e)
        {
            string productId = gridLookUpEditProduct.EditValue.ToString();
            Product product = _productService.GetProductById(productId);
            if (product != null)
            {
                txtProductName.Text = product.ProductName;
                //txtQuantity.Text = product.Quantity.ToString();
                txtPrice.Text = product.Price.ToString();
                txtUnit.EditValue = product.UnitID;
                txtStock.EditValue = product.StockID;
            }
            gridLookUpEditProduct.Properties.Appearance.BorderColor = System.Drawing.Color.White;
            gridLookUpEditProduct.Properties.BorderStyle = BorderStyles.HotFlat;
            txtQuantity.Focus();
        }
        
        private void btnPreview_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(gridLookUpEditProduct.Text))
            {
                gridLookUpEditProduct.Properties.Appearance.BorderColor = System.Drawing.Color.Red;
                XtraMessageBox.Show("Vui lòng chọn Mặt hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gridLookUpEditProduct.Focus();
            }
            else if (string.IsNullOrEmpty(txtQuantity.Text))
            {
                txtQuantity.Properties.Appearance.BorderColor = System.Drawing.Color.Red;
                XtraMessageBox.Show("Vui lòng nhập vào số lượng!", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtQuantity.Focus();
            }
            else
            {
                var list = new ArrayList();
                if (Convert.ToInt32(txtQuantity.Text) <= 0)
                {
                    txtQuantity.Properties.Appearance.BorderColor = System.Drawing.Color.Red;
                    XtraMessageBox.Show("Nhập số lượng phù hợp!", "Thông báo", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    txtQuantity.Focus();
                }
                else
                {
                    CreateOrder();
                    foreach (var cart in _order.Carts)
                    {
                        list.Add(cart);
                    }
                    gridControlStockImport.DataSource = list;
                    _arrayList = list;
                    _total = _order.TotalOrder.ToString(CultureInfo.InvariantCulture);
                    _supplierId = txtSupplierID.Text;
                    _supplierName = txtSupplierID.Text;
                    ResetProductControls();
                    EnabledButtonSaveAndPrint(true);
                    txtBarcode.ResetText();
                    txtBarcode.Focus();
                }
            }
        }

        /// <summary>
        /// Tạo Hóa Đơn
        /// </summary>
        private void CreateOrder()
        {
            //string productId = gridLookUpEditProduct.EditValue.ToString();
            try
            {
                _orderImportService.NextId();
                if (Convert.ToInt32(txtQuantity.Text) > 0)
                    _order.InsertItemToCart(
                        gridLookUpEditProduct.EditValue.ToString(), 
                        txtProductName.Text,
                        Convert.ToInt32(txtQuantity.Text), 
                        Convert.ToInt32(txtPrice.Text), 
                        1,
                        txtUnit.EditValue.ToString(), 
                        txtStock.EditValue.ToString()
                        );

            }
            catch (SqlException ex)
            {
                XtraMessageBox.Show(string.Format("Lỗi SQL Server! \n {0}", ex.Message), "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(string.Format("Lỗi! \n {0}", ex.Message), "Thông Báo Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Reset Controls
        /// </summary>
        private void ResetProductControls()
        {
            gridLookUpEditProduct.Text=string.Empty;
            txtProductName.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtUnit.Text = string.Empty;
            txtStock.Text = string.Empty;
        }

        private void ResetSupplierControls()
        {
            gridLookUpEditSuppliers.Text = string.Empty;
            txtSupplierID.Text = string.Empty;
            txtPepole.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtRequired.Text = string.Empty;
            txtNote.Text = string.Empty;
            gridLookUpEditEmployee.Text = string.Empty;
        }

        /// <summary>
        /// Lưu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(gridLookUpEditSuppliers.Text))
            {
                gridLookUpEditSuppliers.Properties.Appearance.BorderColor = System.Drawing.Color.Red;
                XtraMessageBox.Show("Vui lòng chọn Nhà cung cấp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gridLookUpEditSuppliers.Focus();
            }
            else if (string.IsNullOrEmpty(gridLookUpEditEmployee.Text))
            {
                gridLookUpEditEmployee.Properties.Appearance.BorderColor = System.Drawing.Color.Red;
                XtraMessageBox.Show("Vui lòng chọn Nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gridLookUpEditEmployee.Focus();
            }
            else
            {
                var orderImport = new OrderImport()
                {
                    OrderImportID = txtOrderImportID.Text,
                    SupplierID = gridLookUpEditSuppliers.EditValue.ToString(),
                    EmployeeID =  _employeeId,
                    ImportDate = dateEditImportDate.DateTime,
                    TotalMoney = Convert.ToInt32(_total),
                    //Price = Convert.ToInt32(_price),
                    IsActive = true,
                };

                try
                {
                    _orderImportService.Add(orderImport);
                    foreach (Cart cart in _order.Carts)
                    {
                        InsertOrderImportDetail(txtOrderImportID.Text, cart.ProductId, cart.Quantity, cart.Price, cart.Total);
                        _inventoryService.InsertOrUpdateInventoryImport(cart.ProductId, cart.Quantity, txtOrderImportID.Text);
                    }
                    if (_order.Carts.Count > 0)
                    {
                        _order.Carts.Clear();
                    }
                    
                    
                    XtraMessageBox.Show("Nhập hàng thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    gridControlStockImport.DataSource = null;
                    ResetProductControls();
                    ResetSupplierControls();
                    EnabledButtonSaveAndPrint(false);
                    // Tạo tiếp ID
                    txtOrderImportID.Text = _orderImportService.NextId();
                    gridLookUpEditEmployee.EditValue = _employeeId;

                }
                catch (SqlException ex)
                {
                    XtraMessageBox.Show(string.Format("Lỗi! \n {0}", ex.Message), "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(string.Format("Lỗi! \n {0}", ex.Message), "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Thêm Hóa đơn nhập chi tiết
        /// </summary>
        /// <param name="orderImportId">Mã hóa đơn nhập</param>
        /// <param name="productId">Mã mặt hàng</param>
        /// <param name="quantity">Số lượng nhập</param>
        /// <param name="price">Thành tiền</param>
        /// <param name="total"></param>
        private void InsertOrderImportDetail(string orderImportId, string productId, int quantity, int price, int total)
        {
            var orderImportDetail = new OrderImportDetail()
            {
                OrderImportID = orderImportId,
                ProductID = productId,
                Quantity = quantity,
                Price = price,
                IsActive = true,
                Total = total,
            };
            
            try
            {
                _orderImportDetailService.Add(orderImportDetail);
            }
            catch (SqlException ex)
            {
                XtraMessageBox.Show(string.Format("Lỗi! \n {0}", ex.Message), "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(string.Format("Lỗi! \n {0}", ex.Message), "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// In Hóa đơn
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridViewStockImport.RowCount > 0)
                {
                    var printerStock = new PrinterStockImport(_arrayList, _supplierId, _supplierId, double.Parse(_total),
                        txtOrderImportID.Text);
                    printerStock.ShowPreviewDialog();
                }
                else
                {
                    XtraMessageBox.Show("Không có bản ghi nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(string.Format("Lỗi! \n {0}", ex.Message), "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string _barcode;
        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                try
                {
                    _barcode = txtBarcode.Text;
                    Product product = _productService.GetProductByBarcode(_barcode);
                    if (product != null)
                    {
                        gridLookUpEditProduct.EditValue = product.ProductID;
                        txtProductName.Text = product.ProductName;
                        txtQuantity.EditValue = product.Quantity.ToString();
                        txtPrice.Text = product.Price.ToString();
                        txtUnit.EditValue = product.UnitID;
                        txtStock.EditValue = product.StockID;
                    }
                    else
                    {
                        XtraMessageBox.Show(string.Format("Không tìm thấy Mặt hàng với Barcode này: {0}", _barcode),
                            "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtBarcode.Focus();
                    }

                    btnPreview.Focus();
                    //btnPreview.PerformClick();
                    txtBarcode.ResetText();
                    _barcode = null;
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(string.Format("Lỗi!" +
                                                      "\n Chi tiết lỗi: {0}", ex.Message),
                                "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
        private readonly WaitDialogFormHelper _waitDialog = new WaitDialogFormHelper();
        
        private void navBarItemAddStock_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //_waitDialog.CreateWaitDialog();
            //_waitDialog.SetWaitDialogCaption("Chương trình đang tải dữ liệu.\n Vui lòng chờ trong giây lát!");
            
            
            //_waitDialog.CloseWait();
        }

        private void navBarItemAddProduct_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            _waitDialog.CreateWaitDialog();
            _waitDialog.SetWaitDialogCaption("Chương trình đang tải dữ liệu.\n Vui lòng chờ trong giây lát!");
            var addProduct = new FormAddProduct();
            _waitDialog.CloseWait();
            addProduct.ShowDialog();
            
        }

        private void navBarItemAddSuppliers_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            _waitDialog.CreateWaitDialog();
            _waitDialog.SetWaitDialogCaption("Chương trình đang tải dữ liệu.\n Vui lòng chờ trong giây lát!");
            var addSupplier = new FormAddSuppliers();
            _waitDialog.CloseWait();
            addSupplier.ShowDialog();
        }

        private void navBarItemAddStocks_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            _waitDialog.CreateWaitDialog();
            _waitDialog.SetWaitDialogCaption("Chương trình đang tải dữ liệu.\n Vui lòng chờ trong giây lát!");
            var addStock = new FormAddStock();
            _waitDialog.CloseWait();
            addStock.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void txtQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtQuantity.Properties.Appearance.BorderColor = System.Drawing.Color.White;
                txtQuantity.Properties.BorderStyle = BorderStyles.HotFlat; 
                btnPreview.Focus();
                btnPreview.PerformClick();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                txtQuantity.Text = string.Empty;
            }
            else if (e.KeyCode == Keys.Up)
            {
                txtQuantity.SelectAll();
                txtQuantity.Focus();
            }
            else if (e.KeyCode == Keys.Down)
            {
                txtQuantity.Properties.Appearance.BorderColor = System.Drawing.Color.White;
                txtQuantity.Properties.BorderStyle = BorderStyles.HotFlat; 
                btnPreview.Focus();
            }

        }
    }
}