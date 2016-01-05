using System;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Stock.Data;
using Stock.GUI.Helpers;
using Stock.GUI.Properties;
using Stock.Services;

namespace Stock.GUI.Partners
{
    public partial class FormProductGroup : XtraForm
    {
        private readonly ProductGroupService _productGroupService;
        private readonly LogService _logService;
        private readonly EmployeeService _employeeService;
        public string ProductGroupId { get; set; }
        public FormProductGroup()
        {
            InitializeComponent();
            _productGroupService = new ProductGroupService();
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

            _logService.InsertLog(userName, employeeName, Resources.ActionPreview, Resources.FormTitleProductGroup, info);
        }

        /// <summary>
        /// Load danh sách nhóm hàng
        /// </summary>
        private void LoadProductGroups()
        {
            gridControl1.DataSource = _productGroupService.GetProductGroups();
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
        private void FormProductGroup_Load(object sender, EventArgs e)
        {
            LoadProductGroups();
        }

        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            if (e.Clicks == 1)
            {
                ProductGroupId = (string)((GridView)sender).GetRowCellValue(e.RowHandle, "ProductGroupID");
                
                if (!string.IsNullOrEmpty(ProductGroupId))
                {
                    EnableButtonUpdateAndDelete(true);
                }
            } 
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ProductGroupId))
            {
                XtraMessageBox.Show("Bạn chưa chọn Nhóm Hàng cần sửa!", "THÔNG BÁO");
            }
            else
            {
                var updateProductGroup = new FormUpdateProductGroup(ProductGroupId);
                updateProductGroup.ShowDialog();
                LoadProductGroups();
                ProductGroupId = null;
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
            var addProductGroup = new FormAddProductGroup();
            addProductGroup.ShowDialog();
            LoadProductGroups();
        }

        /// <summary>
        /// Sửa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemUpdate_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (string.IsNullOrEmpty(ProductGroupId))
            {
                XtraMessageBox.Show("Bạn chưa chọn Nhóm Hàng cần sửa!", "THÔNG BÁO");
            }
            else
            {
                var update = new FormUpdateProductGroup(ProductGroupId);
                update.ShowDialog();
                LoadProductGroups();
                ProductGroupId = null;
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
            DialogResult result = XtraMessageBox.Show("Bạn có chắc muốn xóa không?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                foreach (var rowHandle in gridView1.GetSelectedRows())
                {
                    var productGroupId = gridView1.GetRowCellValue(rowHandle, "ProductGroupID");
                    if (productGroupId != null)
                    {
                        ProductGroup productGroup = _productGroupService.GetProductGrouprById(productGroupId.ToString());
                        if (productGroup != null)
                        {
                            try
                            {
                                _productGroupService.Delete(productGroupId.ToString());
                            }
                            catch (Exception ex)
                            {
                                XtraMessageBox.Show(string.Format("Lỗi! \n {0}", ex.Message), "THÔNG BÁO",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                LoadProductGroups();
            }
            else
            {
                EnableButtonUpdateAndDelete(false);
            }


            //if (!string.IsNullOrEmpty(ProductGroupId))
            //{
            //    ProductGroup productGroup = _productGroupService.GetProductGrouprById(ProductGroupId);
            //    if (productGroup != null)
            //    {
            //        DialogResult result = XtraMessageBox.Show("Bạn có chắc muốn xóa thông tin Nhóm Hàng : " + productGroup.ProductGroupName +" này không?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            //        if (result == DialogResult.Yes)
            //        {
            //            try
            //            {
            //                _productGroupService.Delete(ProductGroupId);
            //                LoadProductGroups();

            //                // ProductGroupId == null
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
            //    XtraMessageBox.Show("Vui lòng chọn một Nhóm Hàng cần sửa!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        /// <summary>
        /// Load lại dữ liệu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemRefesh_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadProductGroups();
        }

        /// <summary>
        /// In Preview
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemPrint_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridControl1.ShowPrintPreview();
        }

        /// <summary>
        /// Xuất file Exel
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
        /// Nhập thông tin Nhóm Hàng từ file Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            var importProductGroupFormExcel = new FormImportProductGroupFormExcel();
            importProductGroupFormExcel.ShowDialog();
            LoadProductGroups();
        }

        private void FormProductGroup_KeyDown(object sender, KeyEventArgs e)
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
                    //case Keys.I:
                    //    barButtonItemImportF.PerformClick();
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