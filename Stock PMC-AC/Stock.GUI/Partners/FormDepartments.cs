using System;
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
    public partial class FormDepartments : XtraForm
    {
        private readonly DepartmentService _departmentService;
        private readonly LogService _logService;
        private readonly EmployeeService _employeeService;
        private string _departmentId;
        public FormDepartments()
        {
            InitializeComponent();
            _departmentService = new DepartmentService();
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

            _logService.InsertLog(userName, employeeName, Resources.ActionPreview, Resources.FormTitleDepartment, info);
        }

        /// <summary>
        /// Load dữ liệu
        /// </summary>
        private void LoadDepartments()
        {
            gridControl1.DataSource = _departmentService.GetDepartments();
        }

        private void EnableButtonUpdateAndDelete(bool enable)
        {
            barButtonItemUpdate.Enabled = enable;
            barButtonItemDelete.Enabled = enable;
        }

        private void FormDepartments_Load(object sender, EventArgs e)
        {
            LoadDepartments();
        }

        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            if (e.Clicks == 1)
            {
                _departmentId = (string) ((GridView) sender).GetRowCellValue(e.RowHandle, "DepartmentID");
                if (!string.IsNullOrEmpty(_departmentId))
                {
                    EnableButtonUpdateAndDelete(true);
                }
            }
            else
            {
                EnableButtonUpdateAndDelete(false);
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_departmentId))
            {
                XtraMessageBox.Show("Bạn chưa chọn Đơn Vị cần sửa!", "THÔNG BÁO");
            }
            else
            {
                var department = new FormUpdateDepartment(_departmentId);
                department.ShowDialog();
                LoadDepartments();
                _departmentId = null;
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
            var department = new FormAddDepartment();
            department.ShowDialog();
            LoadDepartments();
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemUpdate_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (string.IsNullOrEmpty(_departmentId))
            {
                XtraMessageBox.Show("Bạn chưa chọn Bộ Phận cần sửa!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else
            {
                var update = new FormUpdateDepartment(_departmentId);
                update.ShowDialog();
                LoadDepartments();
                _departmentId = null;
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
                    var departmentId = gridView1.GetRowCellValue(rowHandle, "DepartmentID");
                    if (departmentId != null)
                    {
                        Department department = _departmentService.GetDepartmentById(departmentId.ToString());
                        if (department != null)
                        {
                            try
                            {
                                _departmentService.Delete(departmentId.ToString());
                            }
                            catch (Exception ex)
                            {
                                XtraMessageBox.Show(string.Format("Lỗi! \n {0}", ex.Message), "THÔNG BÁO",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                LoadDepartments();
            }
            else
            {
                EnableButtonUpdateAndDelete(false);
            }

            //if (!string.IsNullOrEmpty(_departmentId))
            //{
            //        Data.Department department = _departmentService.GetDepartmentById(_departmentId);
            //        if (department != null)
            //        {
            //            DialogResult result = XtraMessageBox.Show("Bạn có chắc muốn xóa thông tin Bộ Phận : " + department.DepartmentName + " này không?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            //            if (result == DialogResult.Yes)
            //            {
            //                try
            //                {
            //                    _departmentService.Update(department);
            //                    LoadDepartments();
            //                    _departmentId = null;
            //                    EnableButtonUpdateAndDelete(false);
            //                }
            //                catch (Exception ex)
            //                {
            //                    XtraMessageBox.Show(string.Format("Lỗi! \n {0}", ex.Message), "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //                }

            //            }
            //        }
            //}
            //else
            //    XtraMessageBox.Show("Vui lòng chọn một Khu Vực cần sửa!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        /// <summary>
        /// Refesh
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemRefesh_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadDepartments();
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
        /// Export Exel
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
        /// Nhập Bộ Phận từ file Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemImportDepartmentFormExcel_ItemClick(object sender, ItemClickEventArgs e)
        {
            var importDepartment = new FormImportDepartmentFormExel();
            importDepartment.ShowDialog();
            LoadDepartments();
        }

        private void FormDepartments_KeyDown(object sender, KeyEventArgs e)
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
                        barButtonItemImportDepartmentFormExcel.PerformClick();
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