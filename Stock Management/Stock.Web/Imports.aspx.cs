using System;
using System.Collections;
using System.Data.SqlClient;
using Stock.Data;
using Stock.Services;
using Stock.Web.Models;

namespace Stock.Web
{
    public partial class Imports : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtBarcode.Focus();
            txtBarcode.Attributes.Add("onkeypress", "return handleEnterFocus('" + txtQuantity.ClientID + "', event)");
            txtQuantity.Attributes.Add("onkeypress", "return handleEnterFocus('" + txtPlan.ClientID + "', event)");
            txtPlan.Attributes.Add("onkeypress", "return handleEnterClick('" + btnAddToCart.ClientID + "', event)");
        }

        private readonly LogService _logService = new LogService();
        private readonly ReceiptService _receiptService = new ReceiptService();
        private readonly ProductService _productService = new ProductService();
        private readonly ReceiptDetailService _receiptDetailService = new ReceiptDetailService();
        private readonly InventoryService _inventoryService = new InventoryService();
        private readonly Cart.Order _order = new Cart.Order();
        private ArrayList _arrayList = new ArrayList();
        private readonly ArrayList _list = new ArrayList();
        
//<div class="alert alert-success">
//  <strong>Success!</strong> Indicates a successful or positive action.
//</div>

//<div class="alert alert-info">
//  <strong>Info!</strong> Indicates a neutral informative change or action.
//</div>

//<div class="alert alert-warning">
//  <strong>Warning!</strong> Indicates a warning that might need attention.
//</div>

//<div class="alert alert-danger">
//  <strong>Danger!</strong> Indicates a dangerous or potentially negative action.
//</div>
        
        /// <summary>
        /// Tạo Hóa Đơn
        /// </summary>
        private void CreateOrder(string productId, string productName, string quantityReceipt, long? price, string unitId, string stockId)
        {
            //string productId = gridLookUpEditProduct.EditValue.ToString();
            try
            {
                _receiptService.NextId();
                if (Convert.ToInt32(quantityReceipt) > 0)
                {
                    _order.InsertItemToCart(productId, productName, Convert.ToInt32(quantityReceipt), Convert.ToInt32(price), 1, unitId, stockId);
                }
                else
                {
                    messagebox.InnerHtml = "<div class='alert alert-danger'>" +
                                           "<strong>Lỗi!</strong> " +
                                           "Số lượng phải lớn hơn 0.</div>";
                }

            }
            catch (SqlException ex)
            {
                messagebox.InnerHtml = string.Format("<div class='alert alert-danger'>" +
                                           "<strong>Lỗi!</strong> {0} .</div>", ex.Message);
            }
            catch (Exception ex)
            {
                messagebox.InnerHtml = string.Format("<div class='alert alert-danger'>" +
                                           "<strong>Lỗi!</strong> {0} .</div>", ex.Message);
            }
        }

        /// <summary>
        /// Thêm Hóa đơn nhập chi tiết
        /// </summary>
        /// <param name="receiptId">Mã hóa đơn nhập</param>
        /// <param name="productId">Mã mặt hàng</param>
        /// <param name="quantityReceipt">Số lượng nhập</param>
        /// <param name="price">Thành tiền</param>
        /// <param name="total"></param>
        private void InsertReceiptDetails(string receiptId, string productId, int quantityReceipt, int price, int total)
        {
            var receiptDetail = new ReceiptDetail()
            {
                ReceiptID = receiptId,
                ProductID = productId,
                Quantity = quantityReceipt,
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
                messagebox.InnerHtml = string.Format("<div class='alert alert-danger'>" +
                                           "<strong>Lỗi!</strong> {0} .</div>", ex.Message);
            }
            catch (Exception ex)
            {
                messagebox.InnerHtml = string.Format("<div class='alert alert-danger'>" +
                                           "<strong>Lỗi!</strong> {0} .</div>", ex.Message);
            }
        }


        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBarcode.Text))
            {
                Product product = _productService.GetProductByBarcode(txtBarcode.Text);
                if (product != null)
                {
                    if (string.IsNullOrEmpty(txtQuantity.Text))
                    {
                        messagebox.InnerHtml = "<div class='alert alert-warning'>" +
                                           "<strong>Lỗi!</strong> " +
                                           "Vui lòng nhập vào số lượng!</div>";
                    }
                    else
                    {
                        var list = new ArrayList();

                        if (Convert.ToInt32(txtQuantity.Text) < 1)
                        {
                            messagebox.InnerHtml = "<div class='alert alert-warning'>" +
                                           "<strong>Lỗi!</strong> " +
                                           "Số lượng phải lớn hơn một!</div>";
                        }
                        else
                        {
                            CreateOrder(product.ProductID, product.ProductName, txtQuantity.Text, product.Price, product.UnitID, product.StockID);
                            foreach (var cart in _order.Carts)
                            {
                                list.Add(cart);
                            }
                            string receiptId = _receiptService.NextId();
                            var receipt = new Receipt()
                            {
                                ReceiptID = receiptId,
                                ReceiptDate = DateTime.Now,
                                TotalMoney = _order.TotalOrder,
                                //Price = Convert.ToInt32(_price),
                                Active = true,
                                CreateBy = "barcode"

                            };

                            try
                            {
                                _receiptService.Add(receipt);
                                _logService.InsertLog("barcode", "Nhập kho", this.Title);
                                foreach (Cart cart in _order.Carts)
                                {
                                    InsertReceiptDetails(receiptId, cart.ProductId, cart.Quantity, cart.Price, cart.Total);
                                    _inventoryService.InsertOrUpdateReceipt(cart.ProductId, cart.Quantity, receiptId, int.Parse(txtPlan.Text));
                                }
                                if (_order.Carts.Count > 0)
                                {
                                    _order.Carts.Clear();
                                }

                                messagebox.InnerHtml = "<div class='alert alert-success'>" +
                                                       "<strong>Nhập hàng thành công!</strong></div>";

                            }
                            catch (SqlException ex)
                            {
                                messagebox.InnerHtml = string.Format("<div class='alert alert-danger'>" +
                                           "<strong>Lỗi!</strong> {0} .</div>", ex.Message);
                            }
                            catch (Exception ex)
                            {
                                messagebox.InnerHtml = string.Format("<div class='alert alert-danger'>" +
                                           "<strong>Lỗi!</strong> {0} .</div>", ex.Message);
                            }

                            txtBarcode.Text = string.Empty;
                            txtBarcode.Focus();
                        }
                    }
                }
                else
                {
                    messagebox.InnerHtml = "<div class='alert alert-danger'>" +
                                           "<strong>Lỗi!</strong> " +
                                           "Barcode không tồn tại!</div>";
                }
            }
            else
            {
                messagebox.InnerHtml = "<div class='alert alert-danger'>" +
                                           "<strong>Lỗi!</strong> " +
                                           "Barcode không được bỏ trống!</div>";
            }
        }

        protected void btnAddToCart_OnClick(object sender, EventArgs e)
        {
            const string path = @"Sounds\";
            var playthewavfile = new System.Media.SoundPlayer(System.Web.HttpContext.Current.Server.MapPath(path));
            playthewavfile.SoundLocation = "NG.wav";
            playthewavfile.Play();

            //if (!string.IsNullOrEmpty(txtBarcode.Text))
            //{
            //    Product product = _productService.GetProductByBarcode(txtBarcode.Text);
            //    if (product != null)
            //    {
            //        if (string.IsNullOrEmpty(txtQuantity.Text))
            //        {
            //            messagebox.InnerHtml = "<div class='alert alert-warning'>" +
            //                               "<strong>Lỗi!</strong> " +
            //                               "Vui lòng nhập vào số lượng!</div>";
            //        }
            //        else
            //        {
            //            if (Convert.ToInt32(txtQuantity.Text) < 1)
            //            {
            //                messagebox.InnerHtml = "<div class='alert alert-warning'>" +
            //                               "<strong>Lỗi!</strong> " +
            //                               "Số lượng phải lớn hơn 0!</div>";
            //            }
            //            else
            //            {
            //                CreateOrder(product.ProductID, product.ProductName, txtQuantity.Text, product.Price, product.UnitID, product.StockID);
            //                foreach (var cart in _order.Carts)
            //                {
            //                    _list.Add(cart);
            //                }

            //                txtBarcode.Text = string.Empty;
            //                txtQuantity.Text = string.Empty;
            //                txtBarcode.Focus();

            //                messagebox.InnerHtml = "<div class='alert alert-success'>" +
            //                                          "<strong>Nhập hàng thành công!</strong></div>";
            //            }
            //        }
            //    }
            //    else
            //    {
            //        messagebox.InnerHtml = "<div class='alert alert-danger'>" +
            //                               "<strong>Lỗi!</strong> " +
            //                               "Barcode không tồn tại!</div>";
            //    }
            //}
            //else
            //{
            //    messagebox.InnerHtml = "<div class='alert alert-danger'>" +
            //                               "<strong>Lỗi!</strong> " +
            //                               "Barcode không được bỏ trống!</div>";
            //}

            //GridView1.DataSource = _list;
            //GridView1.DataBind();
        }
    }
}