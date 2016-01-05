using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Stock.GUI.Helpers;
using Stock.GUI.Models;
using Stock.GUI.Properties;
using Stock.Services;

namespace Stock.GUI.Partners
{
    public partial class FormStock : XtraForm
    {
        private readonly StockService _stockSeries;
        private readonly LogService _logService;
        private readonly EmployeeService _employeeService;
        private string _stockId;
        public FormStock()
        {
            InitializeComponent();
            _stockSeries = new StockService();
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

            _logService.InsertLog(userName, employeeName, Resources.ActionPreview, Resources.FormTitleStock, info);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enable"></param>
        private void EnableButtonUpdateAndDelete(bool enable)
        {
            barButtonItemDelete.Enabled = enable;
            barButtonItemUpdate.Enabled = enable;
        }
        /// <summary>
        /// Hiển thị danh sách Kho
        /// </summary>
        private void LoadStocks()
        {
            
                var stocks = _stockSeries.GetStocks().Select(s => new StockView()
                    {
                        StockID = s.StockID,
                        StockName = s.StockName,
                        Contact = s.Contact,
                        Adress = s.Adress,
                        Telephone = s.Telephone,
                        Manager = s.Manager,
                        Description = s.Description,
                        IsActive = s.IsActive,
                    }).ToList();
            gridControl1.DataSource = stocks;

        }

        private void FormStock_Load(object sender, EventArgs e)
        {
            LoadStocks();
        }

        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            if (e.Clicks == 1)
            {
                _stockId = (string) ((GridView) sender).GetRowCellValue(e.RowHandle, "StockID");
                EnableButtonUpdateAndDelete(true);
                if (string.IsNullOrEmpty(_stockId))
                    XtraMessageBox.Show("Vui lòng chọn Kho Hàng cần sửa!", "THÔNG BÁO", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
            }
            else
            {
                EnableButtonUpdateAndDelete(false);
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_stockId))
            {
                XtraMessageBox.Show("Bạn chưa chọn Nhóm Hàng cần sửa!", "THÔNG BÁO");
            }
            else
            {
                var updateStock = new FormUpdateStock(_stockId);
                updateStock.ShowDialog();
                FormStock_Load(sender, e);
                _stockId = null;
                EnableButtonUpdateAndDelete(false);
            }
        }

        /// <summary>
        /// Thêm Stock
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            var addStock = new FormAddStock();
            addStock.ShowDialog();
            LoadStocks();
        }

        /// <summary>
        /// Sửa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemUpdate_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (string.IsNullOrEmpty(_stockId))
            {
                XtraMessageBox.Show("Bạn chưa chọn Kho Hàng cần sửa!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var updateStock = new FormUpdateStock(_stockId);
                updateStock.ShowDialog();
                FormStock_Load(sender, e);
                _stockId = null;
                EnableButtonUpdateAndDelete(false);
            }
        }

        private void barButtonItemDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            DialogResult result = XtraMessageBox.Show("Bạn có chắc muốn xóa không?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                foreach (var rowHandle in gridView1.GetSelectedRows())
                {
                    var stockId = gridView1.GetRowCellValue(rowHandle, "StockID");
                    if (stockId != null)
                    {
                        Data.Stock stock = _stockSeries.GetStockById(stockId.ToString());
                        if (stock != null)
                        {
                            try
                            {
                                _stockSeries.Delete(stockId.ToString());
                            }
                            catch (Exception ex)
                            {
                                XtraMessageBox.Show(string.Format("Lỗi! \n {0}", ex.Message), "THÔNG BÁO",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                LoadStocks();
            }
            else
            {
                EnableButtonUpdateAndDelete(false);
            }

            //if (!string.IsNullOrEmpty(_stockId))
            //{
            //    Data.Stock stock = _stockSeries.GetStockById(_stockId);
            //    if (stock != null)
            //    {
            //        DialogResult result = XtraMessageBox.Show("Bạn có chắc muốn xóa thông tin Kho Hàng : " + stock.StockName + " này không?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            //        if (result == DialogResult.Yes)
            //        {
            //            try
            //            {
            //                _stockSeries.Delete(_stockId);
            //                LoadStocks();

            //                // _stockId == null
            //                EnableButtonUpdateAndDelete(false);
            //            }
            //            catch (Exception ex)
            //            {
            //                XtraMessageBox.Show(string.Format("Lỗi! \n {0}", ex.Message), "THÔNG BÁO",
            //                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            }

            //        }
            //    }

            //}
            //else
            //    XtraMessageBox.Show("Vui lòng chọn một Kho Hàng cần sửa!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void barButtonItemRefesh_ItemClick(object sender, ItemClickEventArgs e)
        {
            //LoadStocks();
            FormStock_Load(sender,e);
        }

        /// <summary>
        /// In Danh Sách
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

        private void FormStock_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    // Add New
                    case Keys.N:
                        barButtonItemAdd.PerformClick();
                        break;

                    //// Import
                    //case Keys.I:
                    //    barButtonItemImport.PerformClick();
                    //    break;

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