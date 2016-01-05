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
    public partial class FormStockExport : XtraForm
    {
        private readonly OrderExportService _orderExportService;
        private readonly EmployeeService _employeeService;
        private readonly ProductService _productService;
        private readonly StockService _stockService;
        private readonly UnitService _unitService;
        private readonly OrderExportDetailService _orderExportDetailService;
        private readonly InventoryService _inventoryService;
        private readonly Cart.Order _order = new Cart.Order();
        private ArrayList _arrayList = new ArrayList();
        private string _employeeId;
        private string _employeeName;
        private string _address;
        private string _reason;
        private string _total;
        public FormStockExport()
        {
            InitializeComponent();

            _orderExportService = new OrderExportService();
            _employeeService = new EmployeeService();
            _productService = new ProductService();
            _stockService = new StockService();
            _unitService = new UnitService();
            _orderExportDetailService = new OrderExportDetailService();
            _inventoryService = new InventoryService();
            
            LoadGirdLookUpEmployees();
            LoadGirdLookUpProducts();
            LoadGirdLookUpStocks();
            LoadGirdLookUpUnits();
        }

        /// <summary>
        /// Load Danh sách Nhân Viên
        /// </summary>
        private void LoadGirdLookUpEmployees()
        {
            var employees = _employeeService.GetEmployees();
            try
            {
                gridLookUpEditEmployees.Properties.View.OptionsBehavior.AutoPopulateColumns = false;
                gridLookUpEditEmployees.Properties.DisplayMember = "EmployeeName";
                gridLookUpEditEmployees.Properties.ValueMember = "EmployeeID";
                gridLookUpEditEmployees.Properties.View.BestFitColumns();
                gridLookUpEditEmployees.Properties.PopupFormWidth = 270;
                gridLookUpEditEmployees.Properties.DataSource = employees;
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
            txtOrderExportID.Text = _orderExportService.NextId();
            dateEditExportDate.EditValue = DateTime.Now.ToShortDateString();
            if (gridControlStockExport.DataSource == null)
            {
                EnabledButtonSaveAndPrint(false);
            }
        }

        private void gridLookUpEditEmployees_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                var showAddSupplier = new FormAddSuppliers();
                showAddSupplier.ShowDialog();
                LoadGirdLookUpEmployees();
            }
        }

        private void gridLookUpEditEmployees_EditValueChanged(object sender, EventArgs e)
        {
            string employeeId = gridLookUpEditEmployees.EditValue.ToString();
            Employee employee = _employeeService.GetEmployeeById(employeeId);
            if (employee != null)
            {
                txtEmployeeID.Text = employee.EmployeeID;
                txtPepole.Text = employee.EmployeeName;
                txtPhone.Text = employee.HomeTell;
                txtAddress.Text = employee.Address;

            }
        }

        private void gridLookUpEditProduct_ButtonPressed(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
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
                txtQuantity.Text = product.Quantity.ToString();
                txtPrice.Text = product.Price.ToString();
                txtUnit.EditValue = product.UnitID;
                txtStock.EditValue = product.StockID;
            }
        }

        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            else if (!_inventoryService.CheckQuantity(gridLookUpEditProduct.EditValue.ToString(), Convert.ToInt32(txtQuantity.Text)))
            {
                txtQuantity.Properties.Appearance.BorderColor = System.Drawing.Color.Red;
                XtraMessageBox.Show("Số lượng xuất không được lớn hơn số lượng hàng tồn còn trong kho!", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                txtQuantity.Focus();
            }
            else if (Convert.ToInt32(txtQuantity.Text) <= 0)
            {
                txtQuantity.Properties.Appearance.BorderColor = System.Drawing.Color.Red;
                XtraMessageBox.Show("Nhập số lượng phù hợp!", "Thông báo", MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                txtQuantity.Focus();
            }
            else
            {
                if (txtQuantity.Properties.Appearance.BorderColor == System.Drawing.Color.Red)
                {
                    txtQuantity.Properties.BorderStyle = BorderStyles.HotFlat;
                }
                var list = new ArrayList();
                CreateOrder();
                foreach (var cart in _order.Carts)
                {
                    list.Add(cart);
                }
                gridControlStockExport.DataSource = list;
                _arrayList = list;
                _total = _order.TotalOrder.ToString(CultureInfo.InvariantCulture);
                _employeeId = txtEmployeeID.Text;
                _employeeName = txtPepole.Text;
                _reason = txtRequired.Text;
                _address = txtAddress.Text;
                ResetProductControls();
                EnabledButtonSaveAndPrint(true);
                txtBarcode.ResetText();
                txtBarcode.Focus();
                
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
                _orderExportService.NextId();
                if (Convert.ToInt32(txtQuantity.Text) > 0)
                    _order.InsertItemToCart(
                        gridLookUpEditProduct.EditValue.ToString(),
                        txtProductName.Text,
                        Convert.ToInt32(txtQuantity.Text),
                        Convert.ToInt32(txtPrice.Text), 1,
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
            gridLookUpEditProduct.Text = string.Empty;
            txtProductName.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtUnit.Text = string.Empty;
            txtStock.Text = string.Empty;
        }

        private void ResetSupplierControls()
        {
            gridLookUpEditEmployees.Text = string.Empty;
            txtEmployeeID.Text = string.Empty;
            txtPepole.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtRequired.Text = string.Empty;
            txtNote.Text = string.Empty;
        }

        /// <summary>
        /// Lưu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(gridLookUpEditEmployees.Text))
            {
                gridLookUpEditEmployees.Properties.Appearance.BorderColor = System.Drawing.Color.Red;
                XtraMessageBox.Show("Vui lòng chọn Nhân viên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                gridLookUpEditEmployees.Focus();
            }
            else
            {
                string employeeSelect = gridLookUpEditEmployees.EditValue.ToString();
                string employeeId = null;
                if (!string.IsNullOrEmpty(employeeSelect))
                {
                    employeeId = employeeSelect;
                }
                var orderExport = new OrderExport()
                {
                    OrderExportID = txtOrderExportID.Text,
                    EmployeeID = employeeId,
                    ExportDate = dateEditExportDate.DateTime,
                    Total = Convert.ToInt32(_total),
                    //Price = Convert.ToInt32(_price),
                    IsActive = true,
                };
                try
                {
                    _orderExportService.Add(orderExport);
                    foreach (Cart cart in _order.Carts)
                    {
                        InsertOrderExportDetail(txtOrderExportID.Text, cart.ProductId, cart.Quantity, cart.Price, cart.Total);
                        _inventoryService.InsertOrUpdateInventoryExport(cart.ProductId, cart.Quantity, txtOrderExportID.Text);
                    }
                    if (_order.Carts.Count > 0)
                    {
                        _order.Carts.Clear();
                    }
                    XtraMessageBox.Show("Xuất kho thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    gridControlStockExport.DataSource = null;
                    ResetProductControls();
                    ResetSupplierControls();
                    EnabledButtonSaveAndPrint(false);
                    // Tạo tiếp ID
                    txtOrderExportID.Text = _orderExportService.NextId();

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
        /// Thêm Hóa đơn xuất chi tiết
        /// </summary>
        /// <param name="orderExportId">Mã hóa đơn xuất</param>
        /// <param name="productId">Mã mặt hàng</param>
        /// <param name="quantity">Số lượng nhập</param>
        /// <param name="price">Thành tiền</param>
        /// <param name="total"></param>
        private void InsertOrderExportDetail(string orderExportId, string productId, int quantity, int price, int total)
        {
            var orderExportDetail = new OrderExportDetail()
            {
                OrderExportID = orderExportId,
                ProductID = productId,
                Quantity = quantity,
                Price = price,
                IsActive = true,
                Total = total,
            };
            try
            {
                _orderExportDetailService.Add(orderExportDetail);
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
                if (gridViewStockExport.RowCount > 0)
                {
                    var printerStock = new PrinterStockExport(_arrayList, _employeeName, _reason, _address, double.Parse(_total), txtOrderExportID.Text);
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
                        txtQuantity.Text = product.Quantity.ToString();
                        txtPrice.Text = product.Price.ToString();
                        txtUnit.EditValue = product.UnitID;
                        txtStock.EditValue = product.StockID;
                    }
                    else
                    {
                        XtraMessageBox.Show(string.Format("Không tìm thấy Mặt hàng với Barcode này: {0}", _barcode),
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void navBarItemAddStock_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
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
    }
}