using System;
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
    public partial class FormSuppliers : XtraForm
    {
        private readonly SuppliersService _suppliersService;
        private readonly LogService _logService;
        private readonly AreaService _areaService;
        private readonly EmployeeService _employeeService;
        public string SupplierId;
        public FormSuppliers()
        {
            InitializeComponent();
            _suppliersService = new SuppliersService();
            _logService = new LogService();
            _areaService = new AreaService();
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

            _logService.InsertLog(userName, employeeName, Resources.ActionPreview, Resources.FormTitleSuppliers, info);
        }

        /// <summary>
        /// Load danh sách nhà cung cấp
        /// </summary>
        private void LoadSuppliers()
        {
            var suppliers = _suppliersService.GetSuppliers()
                .Select(s => new SuppliersView
                {
                    SupplierID = s.SupplierID,
                    AreaID = s.AreaID,
                    AreaName = _areaService.GetAreaNameById(s.AreaID),
                    SupplierName = s.SupplierName,
                    Representatives = s.Representatives,
                    PhoneNumber = s.PhoneNumber,
                    Mobile = s.Mobile,
                    Address = s.Address,
                    Email = s.Email,
                    AccountNumber = s.AccountNumber,
                    Bank = s.Bank,
                    TaxCode = s.TaxCode,
                    Fax = s.Fax,
                    Website = s.Website,
                    IsActive = s.IsActive,
                }).ToList();
            gridControl1.DataSource = suppliers;
        }

        /// <summary>
        /// Enable Button Xóa và Cập nhật
        /// </summary>
        /// <param name="enable"></param>
        private void EnableButtonUpdateAndDelete(bool enable)
        {
            barButtonItemUpdate.Enabled = enable;
            barButtonItemDelete.Enabled = enable;
        }
        private void FormSuppliers_Load(object sender, EventArgs e)
        {
            LoadSuppliers();
        }

        /// <summary>
        /// Form Thêm Nhà cung cấp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            var suppliers = new FormAddSuppliers();
            suppliers.ShowDialog();
            LoadSuppliers();
        }

        /// <summary>
        /// Form Sửa thông tin nhà cung cấp
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemUpdate_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (string.IsNullOrEmpty(SupplierId))
            {
                XtraMessageBox.Show("Bạn chưa chọn Khu vực cần sửa!", "THÔNG BÁO");
            }
            else
            {
                var updateArea = new FormUpdateSuppliers(SupplierId);
                updateArea.ShowDialog();
                LoadSuppliers();
                SupplierId = null;
                EnableButtonUpdateAndDelete(false);
            }
        }

        /// <summary>
        /// Xóa Record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            DialogResult result = XtraMessageBox.Show("Bạn có chắc muốn xóa không?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                foreach (var rowHandle in gridView1.GetSelectedRows())
                {
                    var supplierId = gridView1.GetRowCellValue(rowHandle, "UnitID");
                    if (supplierId != null)
                    {
                        Supplier supplier = _suppliersService.GetSupplierById(supplierId.ToString());
                        if (supplier != null)
                        {
                            try
                            {
                                _suppliersService.Delete(supplierId.ToString());
                            }
                            catch (Exception ex)
                            {
                                XtraMessageBox.Show(string.Format("Lỗi! \n {0}", ex.Message), "THÔNG BÁO",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                LoadSuppliers();
            }
            else
            {
                EnableButtonUpdateAndDelete(false);
            }

            //if (!string.IsNullOrEmpty(SupplierId))
            //{
            //    Supplier supplier = _suppliersService.GetSupplierById(SupplierId);
            //    if (supplier != null)
            //    {
            //        DialogResult result = XtraMessageBox.Show("Bạn có chắc muốn xóa thông tin Nhà Cung Cấp : " + supplier.SupplierName + " không?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            //        if (result == DialogResult.Yes)
            //        {
            //            try
            //            {
            //                _suppliersService.Delete(SupplierId);
            //                LoadSuppliers();
            //                SupplierId = null;
            //                EnableButtonUpdateAndDelete(false);
            //            }
            //            catch (Exception ex)
            //            {
            //                XtraMessageBox.Show(string.Format("Lỗi! \n {0}", ex.Message), "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //            }

            //        }
            //    }
            //}
            //else
            //    XtraMessageBox.Show("Vui lòng chọn một Khu Vực cần sửa!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Load lại dữ liệu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemRefesh_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadSuppliers();
        }

        /// <summary>
        /// In
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
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            if (e.Clicks == 1)
            {
                SupplierId = (string)((GridView)sender).GetRowCellValue(e.RowHandle, "SupplierID");
                
                if (!string.IsNullOrEmpty(SupplierId))
                {
                    EnableButtonUpdateAndDelete(true);
                }
            }
            else
            {
                EnableButtonUpdateAndDelete(false);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(SupplierId))
            {
                XtraMessageBox.Show("Vui lòng chọn một Nhà Cung Cấp cần sửa!", "THÔNG BÁO");
            }
            else
            {
                var update = new FormUpdateSuppliers(SupplierId);
                update.ShowDialog();
                LoadSuppliers();
                SupplierId = null;
                EnableButtonUpdateAndDelete(false);
            }
        }

        /// <summary>
        /// Nhập thông tin Nhà cung cấp từ file Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemImportSuppliersFormExcel_ItemClick(object sender, ItemClickEventArgs e)
        {
            var importSupplierFormExcel = new FormImportSuppliersFormExcel();
            importSupplierFormExcel.ShowDialog();
            LoadSuppliers();
        }

        private void FormSuppliers_KeyDown(object sender, KeyEventArgs e)
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
                        barButtonItemImportSuppliersFormExcel.PerformClick();
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