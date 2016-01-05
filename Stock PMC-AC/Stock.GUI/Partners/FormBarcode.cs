using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using Stock.Data;
using Stock.GUI.Helpers;
using Stock.GUI.Models;
using Stock.GUI.Properties;
using Stock.Services;

namespace Stock.GUI.Partners
{
    public partial class FormBarcode : DevExpress.XtraEditors.XtraForm
    {
        private readonly ProductService _productService;
        private readonly LogService _logService;
        private readonly EmployeeService _employeeService;

        public FormBarcode()
        {
            InitializeComponent();

            _productService=new ProductService();
            _logService = new LogService();
            _employeeService = new EmployeeService();
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

            _logService.InsertLog(userName, employeeName, Resources.ActionPreview, Resources.BarcodeTile, info);
        }

        /// <summary>
        /// Danh sách Hàng hóa
        /// </summary>
        private void LoadProducts()
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

            gridControl1.DataSource = products;

        }

        private void FormBarcode_Load(object sender, EventArgs e)
        {
            LoadProducts();
        }

        /// <summary>
        /// In Barcode
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemPrinterBarcode_ItemClick(object sender, ItemClickEventArgs e)
        {
            var products = new List<Product>(); 
            foreach (var rowHandle in gridView1.GetSelectedRows())
            {
                var productId = gridView1.GetRowCellValue(rowHandle, "ProductID");
                Product product = _productService.GetProductById(productId.ToString());
                products.Add(product);
            }

            using (var report = new ReportBarcode())
            {
                report.DataSource = products;
                report.Landscape = true;
                var tool = new ReportPrintTool(report);
                tool.PreviewForm.FormClosing += new FormClosingEventHandler(ReportCartonLabels_FormClosing);


                //_waitDialog.CloseWait();
                report.ShowPreviewDialog();
            }



            //var rows = new DataRow[gridView1.SelectedRowsCount];

            //for (int i = 0; i < gridView1.SelectedRowsCount; i++)
            //{
            //    //rows[i] = gridView1.GetDataRow(gridView1.GetSelectedRows()[i]);
            //    XtraMessageBox.Show(i);
            //}
            ////gridView1.BeginSort();

            ////try
            ////{

            ////    foreach (DataRow row in rows)

            ////        row.GetFocusedRowCellValue("ProductID")

            ////}

            ////finally
            ////{

            ////    gridView1.EndSort();

            ////}
        }

        private void ReportCartonLabels_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (XtraMessageBox.Show("Bạn có thực sự muốn thoát?", "XÓA DỮ LIỆU", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //{
            //    this.Close();
            //}
        }

        private void barButtonItemRefesh_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadProducts();
        }
    }
}