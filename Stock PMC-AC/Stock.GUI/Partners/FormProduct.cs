using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Stock.Data;
using Stock.GUI.Helpers;
using Stock.GUI.Models;
using Stock.GUI.Properties;
using Stock.Services;

namespace Stock.GUI.Partners
{
    public partial class FormProduct : XtraForm
    {
        private string _productId;
        private readonly ProductService _productService;
        private readonly LogService _logService;
        private readonly EmployeeService _employeeService;
        private readonly StockService _stockService;
        public FormProduct()
        {
            InitializeComponent();
            _logService = new LogService();
            _employeeService = new EmployeeService();
            _productService = new ProductService();
            _stockService = new StockService();
            LoadGirdLookUpStock();
            InsertSysLog();
        }

        /// <summary>
        // Lưu lại quá trình hoạt động của người dùng trên hệ thống
        /// </summary>
        private void InsertSysLog()
        {
            string userName = Program.CurrentUser.UserName;
            string employeeName = _employeeService.GetEmployeeById(Program.CurrentUser.EmployeeID).EmployeeName;
            string info = MachineHelper.GetMachineInfo();

            _logService.InsertLog(userName, employeeName, Resources.ActionPreview, Resources.FormTitleProduct, info);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="enable"></param>
        private void EnableButtonUpdateAndDelete(bool enable)
        {
            barButtonItemUpdate.Enabled = enable;
            barButtonItemDelete.Enabled = enable;
        }

        /// <summary>
        /// Danh sách Hàng hóa
        /// </summary>
        private void LoadProducts(string stockId)
        {

            var products = _productService.GetProducts()
                    .Select(p => new ProductView()
                    {
                        ProductID = p.ProductID,
                        ProductName = p.ProductName,
                        ProductGroupID = p.ProductGroupID,
                        ProductGroupName = p.ProductGroup.ProductGroupName,
                        StockID = p.StockID,
                        StockName = p.Stock.StockName,
                        UnitID = p.UnitID,
                        UnitName = p.Unit.UnitName,
                        SupplierID = p.SupplierID,
                        SupplierName = p.Supplier.SupplierName,
                        Origin = p.Origin,
                        Quantity = p.Quantity,
                        ExpireDate = p.ExpireDate,
                        Image = p.Image,
                        Description = p.Description,
                        IsActive = p.IsActive,
                        Price = p.Price,
                    }).ToList();

            IEnumerable<ProductView> productViews = !string.IsNullOrEmpty(stockId) ? products.Where(p => p.StockID == stockId) : products;
            gridControl1.DataSource = productViews;
            
        }

        /// <summary>
        /// Load danh sách Kho Hàng
        /// </summary>
        private void LoadGirdLookUpStock()
        {
            var stocks = _stockService.GetStocks();
            var collection = new AutoCompleteStringCollection();
            foreach (var stock in stocks)
            {
                collection.Add(stock.StockName);
            }

            gridLookUpEditStock.MaskBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            gridLookUpEditStock.MaskBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            gridLookUpEditStock.MaskBox.AutoCompleteCustomSource = collection;

            gridLookUpEditStock.Properties.DisplayMember = "StockName";
            gridLookUpEditStock.Properties.ValueMember = "StockID";
            gridLookUpEditStock.Properties.PopupFormWidth = 300;
            gridLookUpEditStock.Properties.DataSource = stocks;
        }

        private void FormProduct_Load(object sender, EventArgs e)
        {
            LoadProducts(null);
        }

        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            if (e.Clicks == 1)
            {
                _productId = (string)((GridView)sender).GetRowCellValue(e.RowHandle, "ProductID");
                if (!string.IsNullOrEmpty(_productId))
                {
                    EnableButtonUpdateAndDelete(true);
                }
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_productId))
            {
                XtraMessageBox.Show("Vui lòng chọn một Nhân Viên cần sửa!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var update = new FormUpdateProduct(_productId);
                update.ShowDialog();
                LoadProducts(null);
                _productId = null;
                EnableButtonUpdateAndDelete(false);
            }
        }

        /// <summary>
        /// Thêm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            var addProduct = new FormAddProduct();
            addProduct.ShowDialog();
            LoadProducts(null);
        }

        private void barButtonItemUpdate_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (string.IsNullOrEmpty(_productId))
            {
                XtraMessageBox.Show("Bạn chưa chọn Hàng Hóa cần sửa!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var update = new FormUpdateProduct(_productId);
                update.ShowDialog();
                LoadProducts(null);
                _productId = null;
                EnableButtonUpdateAndDelete(false);
            }
        }

        /// <summary>
        /// Xóa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(_productId))
            {
                Product product = _productService.GetProductById(_productId);
                if (product != null)
                {
                    DialogResult result = XtraMessageBox.Show("Bạn có chắc muốn xóa thông tin Hàng Hóa : " + product.ProductName + " này không?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            _productService.Delete(product);
                            LoadProducts(null);
                            _productId = null;
                            EnableButtonUpdateAndDelete(false);
                        }
                        catch (Exception ex)
                        {
                            XtraMessageBox.Show(string.Format("Lỗi! \n {0}", ex.Message), "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                }
            }
            else
                XtraMessageBox.Show("Vui lòng chọn một Hàng Hóa cần xóa!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        /// <summary>
        /// Load lại dữ liệu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemRefesh_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadProducts(null);
        }

        /// <summary>
        /// In danh sách
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemPrint_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridControl1.ShowPrintPreview();
        }

        /// <summary>
        /// Xuất ra file Exel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemExportToExel_ItemClick(object sender, ItemClickEventArgs e)
        {
            var saveFileDialog1 = new SaveFileDialog
            {
                Filter = Resources.SaveFileDialogFilterExel,
                Title = Resources.SaveFileDialogTitle
            };
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                gridControl1.ExportToXls(saveFileDialog1.FileName);
            }
        }

        /// <summary>
        /// Nhập từ file excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemImportProductFormExcel_ItemClick(object sender, ItemClickEventArgs e)
        {
            var importProductFormExcel = new FormImportProductFormExcel();
            importProductFormExcel.ShowDialog();
            LoadProducts(null);
        }

        private void gridLookUpEditStock_EditValueChanged(object sender, EventArgs e)
        {
            string stockId = gridLookUpEditStock.EditValue.ToString();
            if (!string.IsNullOrEmpty(stockId))
            {
                LoadProducts(stockId);
            }
            
            
            //XtraMessageBox.Show(stockId);
        }

        private void FormProduct_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    // Add New
                    case Keys.N:
                        barButtonItemAdd.PerformClick();
                        break;

                    // Import
                    case Keys.I:
                        barButtonItemImportProductFormExcel.PerformClick();
                        break;

                    // Update
                    case Keys.U:
                        barButtonItemUpdate.PerformClick();
                        break;

                    // Delete
                    case Keys.D:
                        barButtonItemDelete.PerformClick();
                        break;

                    // Refesh
                    case Keys.F5:
                        barButtonItemRefesh.PerformClick();
                        break;

                    // Printer
                    case Keys.P:
                        barButtonItemPrint.PerformClick();
                        break;

                    // Export
                    case Keys.X:
                        barButtonItemRefesh.PerformClick();
                        break;

                    // Close
                    case Keys.C:
                        barButtonItemClose.PerformClick();
                        break;
                }
            }
        }
    }
}