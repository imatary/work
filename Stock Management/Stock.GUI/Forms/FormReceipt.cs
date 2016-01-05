using System;
using System.Collections;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using Stock.Data;
using Stock.GUI.Helper;
using Stock.GUI.Models;
using Stock.Services;

namespace Stock.GUI.Forms
{
    public partial class FormReceipt : XtraForm
    {

        private readonly LogService _logService;
        private readonly ReceiptService _receiptService;
        private readonly ProductService _productService;
        private readonly ReceiptDetailService _receiptDetailService;
        private readonly InventoryService _inventoryService;

        private readonly Cart.Order _order = new Cart.Order();
        private ArrayList _arrayList = new ArrayList();
        private string _total;
        private string _barcode;

        public FormReceipt()
        {
            InitializeComponent();

            _logService = new LogService();
            _receiptService = new ReceiptService();
            _productService = new ProductService();
            _receiptDetailService = new ReceiptDetailService();
            _inventoryService = new InventoryService();
        }

        private void FormReceipt_Load(object sender, EventArgs e)
        {
            lblReceiptID.Text = _receiptService.NextId();
            LoadProductForGridLookUp();
            txtReceiptDate.Text = DateTime.Now.Date.ToString("d");
            txtBarcode.Focus();
            if (gridControlStockImport.DataSource == null)
            {
                EnabledButtonSaveAndPrint(false);
            }
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
            txtPlan.Text = string.Empty;
        }

        /// <summary>
        /// Tạo Hóa Đơn
        /// </summary>
        private void CreateOrder()
        {
            //string productId = gridLookUpEditProduct.EditValue.ToString();
            try
            {
                _receiptService.NextId();
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
        /// <param name="receiptId">Mã hóa đơn nhập</param>
        /// <param name="productId">Mã mặt hàng</param>
        /// <param name="quantity">Số lượng nhập</param>
        /// <param name="price">Thành tiền</param>
        /// <param name="total"></param>
        private void InsertReceiptDetails(string receiptId, string productId, int quantity, int price, int total)
        {
            var receiptDetail = new ReceiptDetail()
            {
                ReceiptID = receiptId,
                ProductID = productId,
                Quantity = quantity,
                Price = price,
                Active = true,
                Total = total,
            };

            try
            {
                _receiptDetailService.Add(receiptDetail);
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




        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(gridLookUpEditProduct.Text))
            {
                Ultils.GridLookUpEditControlNotNull(gridLookUpEditProduct, "một mặt hàng!");
            }
            else if (string.IsNullOrEmpty(txtQuantity.Text))
            {
                Ultils.SetColorErrorTextControl(txtQuantity, "Vui lòng nhập vào số lượng!");
                
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPlan.Text))
            {
                Ultils.TextControlNotNull(txtPlan, "Kế hoạch");
            }
            else
            {
                var receipt = new Receipt()
                {
                    ReceiptID = lblReceiptID.Text,
                    ReceiptDate = DateTime.Now,
                    TotalMoney = Convert.ToInt32(_total),
                    //Price = Convert.ToInt32(_price),
                    Active = true,
                    CreateBy = Program.CurrentUser.Username

                };

                try
                {
                    _receiptService.Add(receipt);
                    _logService.InsertLog(Program.CurrentUser.Username, "Nhập kho", this.Text);
                    foreach (Cart cart in _order.Carts)
                    {
                        InsertReceiptDetails(lblReceiptID.Text, cart.ProductId, cart.Quantity, cart.Price, cart.Total);
                        _inventoryService.InsertOrUpdateReceipt(cart.ProductId, cart.Quantity, lblReceiptID.Text, int.Parse(txtPlan.Text));
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
                    lblReceiptID.Text = _receiptService.NextId();

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
                btnAddToCart.PerformClick();
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
                    }
                    else
                    {
                        Ultils.SetColorErrorTextControl(txtBarcode, "Không tìm thấy mặt hàng nào với barcode này!");
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
                        //btnClose.PerformClick();
                        return true;
                    }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void navBarItemAddStocks_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {

        }

        private void navBarItemAddProduct_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {

        }

        private void navBarItemUnit_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {

        }

        private void navBarItemGroupProduct_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {

        }
        
    }
}