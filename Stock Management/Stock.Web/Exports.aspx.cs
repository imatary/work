using System;
using System.Collections;
using System.Data.SqlClient;
using System.Globalization;
using Stock.Data;
using Stock.Services;
using Stock.Web.Models;

namespace Stock.Web
{
    public partial class Exports : System.Web.UI.Page
    {
        private readonly LogService _logService = new LogService();
        private readonly IssueService _issueService = new IssueService();
        private readonly ProductService _productService = new ProductService();
        private readonly IssueDetailService _issueDetailService = new IssueDetailService();
        private readonly InventoryService _inventoryService = new InventoryService();
        private readonly DepartmentService _departmentService = new DepartmentService();
        private readonly WeekReportService _weekReportService = new WeekReportService();

        private readonly Cart.Order _order = new Cart.Order();
        private ArrayList _arrayList = new ArrayList();

        protected void Page_Load(object sender, EventArgs e)
        {
            txtBarcode.Focus();
            txtBarcode.Attributes.Add("onkeypress", "return handleEnterFocus('" + txtQuantity.ClientID + "', event)");
            txtQuantity.Attributes.Add("onkeypress", "return handleEnterClick('" + btnAddToCart.ClientID + "', event)");
        }

        protected void btnAddToCart_OnClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtBarcode.Text))
            {
                Product product = _productService.GetProductByBarcode(txtBarcode.Text);
                if (product != null)
                {
                    if (string.IsNullOrEmpty(txtQuantity.Text))
                    {
                        messageError.InnerText = "Vui lòng nhập vào số lượng nhập!";

                    }
                    else
                    {
                        var list = new ArrayList();
                        if (Convert.ToInt32(txtQuantity.Text) < 1)
                        {
                            messageError.InnerText = "Số lượng phải lớn hơn không!";
                        }
                        else
                        {
                            CreateOrder(product.ProductID, product.ProductName, txtQuantity.Text, product.Price.ToString(), product.UnitID, product.StockID);
                            foreach (var cart in _order.Carts)
                            {
                                list.Add(cart);
                            }
                            GridView1.DataSource = list;
                            GridView1.DataBind();
                            _arrayList = list;
                            //_total = _order.TotalOrder.ToString(CultureInfo.InvariantCulture);
                            //ResetProductControls();
                            //EnabledButtonSaveAndPrint(true);
                            txtBarcode.Text = string.Empty;
                            txtBarcode.Focus();
                        }
                    }
                }

                else
                {
                    messageError.InnerText = "Barcode không tồn tại!";
                }
                
            }
            else
            {
                messageError.InnerText = "Vui lòng nhập barcode!";
            } 
        }

        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Tạo Hóa Đơn
        /// </summary>
        private void CreateOrder(string productId, string productName, string quantityIssue, string price, string unitId, string stockId)
        {
            try
            {
                _issueService.NextId();
                if (Convert.ToInt32(quantityIssue) > 0)
                    _order.InsertItemToCart(productId, productName, Convert.ToInt32(quantityIssue), Convert.ToInt32(price), 1, unitId, stockId);

            }
            catch (SqlException ex)
            {
                messageError.InnerText = ex.Message;
            }
            catch (Exception ex)
            {
                messageError.InnerText = ex.Message;
            }
        }


        /// <summary>
        /// Thêm Hóa đơn nhập chi tiết
        /// </summary>
        /// <param name="issueId">Mã hóa đơn nhập</param>
        /// <param name="productId">Mã mặt hàng</param>
        /// <param name="quantityIssue">Số lượng nhập</param>
        /// <param name="price">Thành tiền</param>
        /// <param name="total"></param>
        /// <param name="departmentId"></param>
        private void InsertIssueDetails(string issueId, string productId, int quantityIssue, int price, int total, string departmentId, string productName)
        {
            //DateTime date = DateTime.Now;
            var date = DateTime.Now.Date;
            var issueDetail = new IssueDetail()
            {
                IssueID = issueId,
                ProductID = productId,
                Quantity = quantityIssue,
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
                    _weekReportService.InsertOrUpdateWeekReport(departmentId, productName, date, quantityIssue);
                }
                catch (SqlException ex)
                {
                    messageError.InnerText = ex.Message;
                }
                catch (Exception ex)
                {
                    messageError.InnerText = ex.Message;
                }

            }
            catch (SqlException ex)
            {
                messageError.InnerText = ex.Message;
            }
            catch (Exception ex)
            {
                messageError.InnerText = ex.Message;
            }
        }


    }
}