using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Stock.Data;
using Stock.GUI.Helper;
using Stock.GUI.Models;
using Stock.GUI.Properties;
using Stock.Services;

namespace Stock.GUI.Forms
{
    public partial class FormProducts : XtraForm
    {
        private string _productId;
        private readonly ProductService _productService;
        private readonly LogService _logService;
        //private readonly DepartmentService _departmentService;
        private readonly StockService _stockService;
        private readonly ProductGroupService _productGroupService;
        private readonly UnitService _unitService;

        public FormProducts()
        {
            InitializeComponent();

            _logService = new LogService();
            //_departmentService = new DepartmentService();
            _productService = new ProductService();
            _stockService = new StockService();
            _productGroupService = new ProductGroupService();
            _unitService = new UnitService();

            InsertSysLog();
        }

        /// <summary>
        /// Log History
        /// </summary>
        private void InsertSysLog()
        {
            string userName = Program.CurrentUser.Username;

            _logService.InsertLog(userName, this.Text, this.Text);
        }

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
                        ProductGroupName = _productGroupService.GetProductGroupNameById(p.ProductGroupID),
                        StockID = p.StockID,
                        StockName = _stockService.GetStockNameById(p.StockID),
                        UnitID = p.UnitID,
                        UnitName = _unitService.GetUnitNameById(p.UnitID),
                        SupplierName = p.Supplier,
                        Origin = p.Origin,
                        Quantity = p.Quantiry,
                        ExpireDate = p.ExpireDate,
                        Image = p.ProductImage,
                        Description = p.Description,
                        IsActive = p.Active,
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
            LoadGirdLookUpStock();
            LoadProducts(null);
        }

        private void gridLookUpEditStock_EditValueChanged(object sender, EventArgs e)
        {
            string stockId = gridLookUpEditStock.EditValue.ToString();
            if (!string.IsNullOrEmpty(stockId))
            {
                LoadProducts(stockId);
            }
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
                MessageBoxHelper.ShowMessageBoxEditWaringNotSelectId("Hàng hóa");
            }
            else
            {
                var update = new FormInsertOrUpdateProduct(_productId);
                update.ShowDialog();
                LoadProducts(null);
                _productId = null;
                EnableButtonUpdateAndDelete(false);
            }
        }

        private void barButtonItemAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            var importProductFormExcel = new FormInsertOrUpdateProduct(null);
            importProductFormExcel.ShowDialog();
            LoadProducts(null);
        }

        private void barButtonItemImportProductFormExcel_ItemClick(object sender, ItemClickEventArgs e)
        {
            //var importProductFormExcel = new FormInsertOrUpdateProduct();
            //importProductFormExcel.ShowDialog();
            LoadProducts(null);
        }

        private void barButtonItemUpdate_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (string.IsNullOrEmpty(_productId))
            {
                MessageBoxHelper.ShowMessageBoxEditWaringNotSelectId("Hàng hóa");
            }
            else
            {
                var update = new FormInsertOrUpdateProduct(_productId);
                update.ShowDialog();
                LoadProducts(null);
                _productId = null;
                EnableButtonUpdateAndDelete(false);
            }
        }

        private void barButtonItemDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!string.IsNullOrEmpty(_productId))
            {
                Product product = _productService.GetProductById(_productId);
                if (product != null)
                {
                    DialogResult result = XtraMessageBox.Show("Bạn có chắc muốn xóa: " + product.ProductName + "?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
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
                            MessageBoxHelper.ShowMessageBoxError(ex.Message);
                        }

                    }
                }
            }
            else
                MessageBoxHelper.ShowMessageBoxDeleteWaringNotSelectId("Hàng Hóa");

        }

        private void barButtonItemRefesh_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadProducts(null);
        }

        private void barButtonItemPrint_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridControl1.ShowPrintPreview();
        }

        private void barButtonItemExportToExel_ItemClick(object sender, ItemClickEventArgs e)
        {
            var saveFileDialog1 = new SaveFileDialog
            {
                Filter = Resources.SaveFileExcelFilter,
                Title = Resources.SaveFileExelTitle
            };
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                gridControl1.ExportToXls(saveFileDialog1.FileName);
            }
        }
    }
}