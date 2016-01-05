using System;
using System.Collections;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;
using DevExpress.XtraEditors.Controls;
using Stock.Data;
using Stock.GUI.Helper;
using Stock.GUI.Models;
using Stock.Services;

namespace Stock.GUI.Forms
{
    public partial class FormIssue : DevExpress.XtraEditors.XtraForm
    {

        private readonly LogService _logService;
        private readonly IssueService _issueService;
        private readonly ProductService _productService;
        private readonly IssueDetailService _issueDetailService;
        private readonly InventoryService _inventoryService;
        private readonly DepartmentService _departmentService;
        private readonly WeekReportService _weekReportService;

        private readonly Cart.Order _order = new Cart.Order();
        private ArrayList _arrayList = new ArrayList();
        private string _total;
        private string _barcode;

        public FormIssue()
        {
            InitializeComponent();

            _logService = new LogService();
            _issueService = new IssueService();
            _productService = new ProductService();
            _issueDetailService = new IssueDetailService();
            _inventoryService = new InventoryService();
            _departmentService = new DepartmentService();
            _weekReportService = new WeekReportService();
        }

        private void FormFormIssue_Load(object sender, EventArgs e)
        {
            lblReceiptID.Text = _issueService.NextId();
            txtReceiptDate.Text = DateTime.Now.Date.ToString("d");
            txtBarcode.Focus();

            LoadDepartmentForGridLookUp();
            LoadProductForGridLookUp();
            if (gridControlStockImport.DataSource == null)
            {
                EnabledButtonSaveAndPrint(false);
            }
        }

        private void LoadDepartmentForGridLookUp()
        {
            var departments = _departmentService.GetDepartments();
            gridLookUpEditDepartment.Properties.View.OptionsBehavior.AutoPopulateColumns = false;
            gridLookUpEditDepartment.Properties.View.BestFitColumns();
            gridLookUpEditDepartment.Properties.PopupFormWidth = 280;
            gridLookUpEditDepartment.Properties.DataSource = departments;
            gridLookUpEditDepartment.Properties.DisplayMember = "DepartmentName";
            gridLookUpEditDepartment.Properties.ValueMember = "DepartmentID";
        }

        /// <summary>
        /// 
        /// </summary>
        private void LoadProductForGridLookUp()
        {
            var products = _productService.GetProducts();
            gridLookUpEditProduct.Properties.View.OptionsBehavior.AutoPopulateColumns = false;
            gridLookUpEditProduct.Properties.View.BestFitColumns();
            gridLookUpEditProduct.Properties.PopupFormWidth = 406;
            gridLookUpEditProduct.Properties.DataSource = products;
            gridLookUpEditProduct.Properties.DisplayMember = "ProductName";
            gridLookUpEditProduct.Properties.ValueMember = "ProductID";
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

        private void gridLookUpEditProduct_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                var product = new FormInsertOrUpdateProduct(null);
                product.ShowDialog();
                LoadProductForGridLookUp();
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
                txtUnit.Text = product.UnitID;
                txtStock.Text = product.StockID;

                var inventory = _inventoryService.GetInventoryByProductId(product.ProductID);
                if (inventory != null)
                {
                    if (inventory.TotalIn != null)
                    {
                        int totalIn = Convert.ToInt32(inventory.TotalIn);
                        if (totalIn == 0)
                        {
                            lblStatus.Text = "Số lượng còn: " + inventory.TotalIn + "\n\nBan cần nhập thêm hàng!";
                            btnAddToCart.Enabled = false;
                            EnabledButtonSaveAndPrint(false);
                        }
                        else
                        {
                            lblStatus.ForeColor = System.Drawing.Color.Black;
                            lblStatus.Text = "Số lượng còn: " + inventory.TotalIn;
                        }
                    }

                }
                else
                {
                    lblStatus.Text = "Mặt hàng này chưa\nđược nhập vào kho.\nVui lòng nhập kho trước khi xuất!";
                    btnAddToCart.Enabled = false;
                    EnabledButtonSaveAndPrint(false);
                }
            }
            
            txtQuantity.Focus();
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

            txtEmployeeCode.Text = string.Empty;
            txtEmployeeName.Text = string.Empty;
            gridLookUpEditDepartment.EditValue = null;
        }

        /// <summary>
        /// Tạo Hóa Đơn
        /// </summary>
        private void CreateOrder()
        {
            //string productId = gridLookUpEditProduct.EditValue.ToString();
            try
            {
                _issueService.NextId();
                if (Convert.ToInt32(txtQuantity.EditValue) > 0)
                    _order.InsertItemToCart(
                        gridLookUpEditProduct.EditValue.ToString(),
                        txtProductName.Text,
                        Convert.ToInt32(txtQuantity.EditValue),
                        Convert.ToInt32(txtPrice.EditValue),
                        1,
                        txtUnit.EditValue.ToString(),
                        txtStock.EditValue.ToString()
                        );

            }
            catch (SqlException ex)
            {
                MessageBoxHelper.ShowMessageBoxError(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBoxHelper.ShowMessageBoxError(ex.Message);
            }
        }

        /// <summary>
        /// Thêm Hóa đơn nhập chi tiết
        /// </summary>
        /// <param name="issueId">Mã hóa đơn nhập</param>
        /// <param name="productId">Mã mặt hàng</param>
        /// <param name="quantity">Số lượng nhập</param>
        /// <param name="price">Thành tiền</param>
        /// <param name="total"></param>
        /// <param name="departmentId"></param>
        private void InsertIssueDetails(string issueId, string productId, int quantity, int price, int total, string departmentId)
        {
            //DateTime date = DateTime.Now;
            var date = DateTime.Parse(txtReceiptDate.Text);
            var issueDetail = new IssueDetail()
            {
                IssueID = issueId,
                ProductID = productId,
                Quantity = quantity,
                Price = price,
                Active = true,
                CreatedDate = date,
                DepartmentID = departmentId,
                Total = total,
            };

            try
            {
                _issueDetailService.Add(issueDetail);
                try
                {
                    _weekReportService.InsertOrUpdateWeekReport(departmentId, gridLookUpEditDepartment.Text, date, quantity);
                }
                catch (SqlException ex)
                {
                    MessageBoxHelper.ShowMessageBoxError(ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBoxHelper.ShowMessageBoxError(ex.Message);
                }
                
            }
            catch (SqlException ex)
            {
                MessageBoxHelper.ShowMessageBoxError(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBoxHelper.ShowMessageBoxError(ex.Message);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(gridLookUpEditProduct.Text))
            {
                Ultils.GridLookUpEditControlNotNull(gridLookUpEditProduct, "một mặt hàng!");
            }
            else if (string.IsNullOrEmpty(txtQuantity.Text))
            {
                Ultils.SetColorErrorTextControl(txtQuantity, "Vui lòng nhập vào số lượng xuất!");
                
            }
            else
            {
                var list = new ArrayList();
                if (Convert.ToInt32(txtQuantity.EditValue) < 1)
                {
                    Ultils.SetColorErrorTextControl(txtQuantity, "Số lượng phải lớn hơn không!");
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
                    ResetProductControls();
                    EnabledButtonSaveAndPrint(true);
                    txtBarcode.ResetText();
                    txtBarcode.Focus();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmployeeCode.Text))
            {
                Ultils.SetColorErrorTextControl(txtEmployeeCode, "Vui lòng nhập vào Code của nhân viên");
            }
            else if (string.IsNullOrEmpty(txtEmployeeName.Text))
            {
                Ultils.SetColorErrorTextControl(txtEmployeeName, "Vui lòng nhập vào tên người yêu cầu!");
            }
            else if (string.IsNullOrEmpty(gridLookUpEditDepartment.Text))
            {
                Ultils.GridLookUpEditControlNotNull(gridLookUpEditDepartment, "một Bộ phận");
            }
            
            else
            {
                var issue = new Issue()
                {
                    IssueID = lblReceiptID.Text,
                    IssueDate = DateTime.Now,
                    Total = Convert.ToInt32(_total),
                    //Price = Convert.ToInt32(_price),
                    Active = true,
                    CreatedBy = Program.CurrentUser.Username,
                    EmployeeCode = txtEmployeeCode.Text,
                    EmployeeRequest = txtEmployeeName.Text,
                    DepartmentID = gridLookUpEditDepartment.EditValue.ToString()

                };

                try
                {
                    _issueService.Add(issue);
                    _logService.InsertLog(Program.CurrentUser.Username, "Xuất kho", this.Text);
                    foreach (Cart cart in _order.Carts)
                    {
                        InsertIssueDetails(lblReceiptID.Text, cart.ProductId, cart.Quantity, cart.Price, cart.Total, gridLookUpEditDepartment.EditValue.ToString());
                        _inventoryService.InsertOrUpdateIssue(cart.ProductId, cart.Quantity, lblReceiptID.Text);
                    }
                    if (_order.Carts.Count > 0)
                    {
                        _order.Carts.Clear();
                    }

                    MessageBoxHelper.ShowMessageBoxInfo("Nhập hàng thành công!");
                    gridControlStockImport.DataSource = null;
                    ResetProductControls();
                    EnabledButtonSaveAndPrint(false);
                    // Tạo tiếp ID
                    lblReceiptID.Text = _issueService.NextId();

                }
                catch (SqlException ex)
                {
                    MessageBoxHelper.ShowMessageBoxError(ex.Message);
                }
                catch (Exception ex)
                {
                    MessageBoxHelper.ShowMessageBoxError(ex.Message);
                }
            }
        }

        private void txtQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                if (!string.IsNullOrEmpty(gridLookUpEditProduct.Text))
                {
                    var inventory = _inventoryService.GetInventoryByProductId(gridLookUpEditProduct.EditValue.ToString());
                    if (inventory != null)
                    {
                        int totalIn = 0;
                        int quantityCurrent = Convert.ToInt32(txtQuantity.EditValue.ToString());
                        if (inventory.TotalIn != null)
                        {
                            totalIn = (int) inventory.TotalIn;
                            if (quantityCurrent > totalIn)
                            {
                                lblStatus.Text = "Số lượng nhập lớn\nhơn số lượng tồn.\nBạn hãy nhập thêm hàng!";

                                btnAddToCart.Enabled = false;
                                EnabledButtonSaveAndPrint(false);
                            }
                            else
                            {
                                btnAddToCart.PerformClick();
                            }
                        }

                    }
                }
                
                
            }
        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {
            //var textbox = sender as TextBox;
            //if (textbox != null)
            //{
            //    int quantity = int.Parse(textbox.Text);
            //    if (quantity > 0)
            //    {
            //        btnAddToCart.Enabled = true;
            //        btnAddToCart.Focus();
            //    }
            //    else
            //    {
            //        btnAddToCart.Enabled = false;
            //    }
            //}
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {

                try
                {
                    _barcode = txtBarcode.Text;
                    Product product = _productService.GetProductByBarcode(_barcode);
                    if (product != null)
                    {
                        gridLookUpEditProduct.EditValue = product.ProductID;
                        txtProductName.Text = product.ProductName;
                        //txtQuantity.EditValue = product.Quantity.ToString();
                        txtPrice.Text = product.Price.ToString();
                        txtUnit.EditValue = product.UnitID;
                        txtStock.EditValue = product.StockID;

                        var inventory = _inventoryService.GetInventoryByProductId(product.ProductID);
                        if (inventory != null)
                        {
                            if (inventory.TotalIn != null)
                            {
                                int totalIn = Convert.ToInt32(inventory.TotalIn);
                                if (totalIn == 0)
                                {
                                    lblStatus.Text = "Số lượng còn: " + inventory.TotalIn +
                                                     "\n\nBan cần nhập thêm hàng!";
                                    btnAddToCart.Enabled = false;
                                    EnabledButtonSaveAndPrint(false);
                                }
                                else
                                {
                                    lblStatus.ForeColor = System.Drawing.Color.Black;
                                    lblStatus.Text = "Số lượng còn: " + inventory.TotalIn;
                                }
                            }

                        }
                        else
                        {
                            lblStatus.Text = "Mặt hàng này chưa\nđược nhập vào kho!";
                            btnAddToCart.Enabled = false;
                            EnabledButtonSaveAndPrint(false);
                        }
                    }
                    else
                    {
                        Ultils.SetColorErrorTextControl(txtBarcode, "Barcode không tồn tại!");
                    }
                    txtBarcode.ResetText();
                    _barcode = null;
                }
                catch (Exception ex)
                {
                    MessageBoxHelper.ShowMessageBoxError(ex.Message);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrinter_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridViewStockImport.RowCount > 0)
                {
                    //var printerStock = new PrinterStockImport(_arrayList, _supplierId, _supplierId, double.Parse(_total),
                    //    txtOrderImportID.Text);
                    //printerStock.ShowPreviewDialog();
                }
                else
                {
                    MessageBoxHelper.ShowMessageBoxError("Không có bản ghi nào!");
                }
            }
            catch (Exception ex)
            {
                MessageBoxHelper.ShowMessageBoxError(ex.Message);
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Control | Keys.S:
                    {
                        btnSave.PerformClick();
                        return true;
                    }
                case Keys.Control | Keys.P:
                    {
                        btnPrinter.PerformClick();
                        return true;
                    }

                case Keys.Control | Keys.E:
                    {
                        btnExportExel.PerformClick();
                        return true;
                    }
                case Keys.Escape:
                    {
                        this.Close();
                        return true;
                    }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void gridLookUpEditDepartment_ButtonPressed(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Index == 1)
            {
                var department = new FormInsertOrUpdateDepartment(null);
                department.ShowDialog();
                LoadDepartmentForGridLookUp();
            }
        }


        private void txtEmployeeCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down || e.KeyCode == Keys.Tab)
            {
                if (string.IsNullOrEmpty(txtEmployeeCode.Text) ||
                    string.IsNullOrEmpty(txtEmployeeName.Text) ||
                    string.IsNullOrEmpty(gridLookUpEditDepartment.Text))
                {
                    txtEmployeeCode.Focus();
                }
                else
                {
                    btnSave.PerformClick();
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                txtEmployeeCode.Text = string.Empty;
            }
            else if (e.KeyCode == Keys.Up)
            {
                txtEmployeeCode.SelectAll();
                txtEmployeeCode.Focus();
            }
        }

        private void txtEmployeeName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down || e.KeyCode == Keys.Tab)
            {
                if (string.IsNullOrEmpty(txtEmployeeCode.Text) ||
                    string.IsNullOrEmpty(txtEmployeeName.Text) ||
                    string.IsNullOrEmpty(gridLookUpEditDepartment.Text))
                {
                    txtEmployeeName.Focus();
                }
                else
                {
                    btnSave.PerformClick();
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                txtEmployeeName.Text = string.Empty;
            }
            else if (e.KeyCode == Keys.Up)
            {
                txtEmployeeName.SelectAll();
                txtEmployeeName.Focus();
            }
        }

        private void gridLookUpEditDepartment_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Down || e.KeyCode == Keys.Tab)
            {
                if (string.IsNullOrEmpty(txtEmployeeCode.Text) ||
                    string.IsNullOrEmpty(txtEmployeeName.Text) ||
                    string.IsNullOrEmpty(gridLookUpEditDepartment.Text))
                {
                    gridLookUpEditDepartment.Focus();
                }
                else
                {
                    btnSave.PerformClick();
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                gridLookUpEditDepartment.EditValue = string.Empty;
            }
            else if (e.KeyCode == Keys.Up)
            {
                gridLookUpEditDepartment.Focus();
            }
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void navBarItemAddProduct_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {

        }

        private void navBarItemAddStocks_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var stock = new FormInsertOrUpdateStock(null);
            stock.ShowDialog();
        }

        private void navBarItemUnit_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            var unit = new FormInsertOrUpdateUnit(null);
            unit.ShowDialog();
        }

        private void navBarItemGroupProduct_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {

        }
    }
}