﻿using System;
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
    public partial class FormEmployees : XtraForm
    {
        private readonly EmployeeService _employeeService;
        private readonly LogService _logService;
        private readonly DepartmentService _departmentService;
        private string _employeeId;
        public FormEmployees()
        {
            InitializeComponent();
            _employeeService = new EmployeeService();
            _logService = new LogService();
            _departmentService = new DepartmentService();
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

            _logService.InsertLog(userName, employeeName, Resources.ActionPreview, Resources.FormTitleEmployee, info);
        }

        /// <summary>
        /// Load Danh Sách Nhân Viên
        /// </summary>
        private void LoadEmployees()
        {
            var employees = _employeeService.GetEmployees()
                .Select(e => new EmployeeView
                {
                    EmployeeID = e.EmployeeID,
                    DepartmentID = e.DepartmentID,
                    DepartmentName = _departmentService.GetDepartmentNameById(e.DepartmentID),
                    EmployeeCode = e.EmployeeCode,
                    EmployeeName = e.EmployeeName,
                    Alias = e.Alias,
                    Sex = e.Sex,
                    Address = e.Address,
                    HomeTell = e.HomeTell,
                    Mobile = e.Mobile,
                    Fax = e.Fax,
                    Email = e.Email,
                    Birthday = e.Birthday,
                    Note = e.Note,
                    IsActive = e.IsActive,
                }).ToList();
            gridControl1.DataSource = employees;
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
        private void FormEmployees_Load(object sender, EventArgs e)
        {
            LoadEmployees();
        }

        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            if (e.Clicks == 1)
            {
                _employeeId = (string)((GridView)sender).GetRowCellValue(e.RowHandle, "EmployeeID");

                if (!string.IsNullOrEmpty(_employeeId))
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
            if (string.IsNullOrEmpty(_employeeId))
            {
                XtraMessageBox.Show("Vui lòng chọn một Nhân Viên cần sửa!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var update = new FormUpdateEmployee(_employeeId);
                update.ShowDialog();
                LoadEmployees();
                _employeeId = null;
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
            var employee = new FormAddEmployee();
            employee.ShowDialog();
            LoadEmployees();
        }

        /// <summary>
        /// Cập nhật
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemUpdate_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (string.IsNullOrEmpty(_employeeId))
            {
                XtraMessageBox.Show("Bạn chưa chọn Nhân Viên cần sửa!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var update = new FormUpdateEmployee(_employeeId);
                update.ShowDialog();
                LoadEmployees();
                _employeeId = null;
                EnableButtonUpdateAndDelete(false);
            }
        }

        /// <summary>
        /// Xóa Nhân Viên
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
                    var employeeId = gridView1.GetRowCellValue(rowHandle, "EmployeeID");
                    if (employeeId != null)
                    {
                        Employee employee = _employeeService.GetEmployeeById(employeeId.ToString());
                        if (employee != null)
                        {
                            try
                            {
                                _employeeService.Delete(employeeId.ToString());
                            }
                            catch (Exception ex)
                            {
                                XtraMessageBox.Show(string.Format("Lỗi! \n {0}", ex.Message), "THÔNG BÁO",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                LoadEmployees();
            }
            else
            {
                EnableButtonUpdateAndDelete(false);
            }

            //if (!string.IsNullOrEmpty(_employeeId))
            //{
            //    Data.Employee employee = _employeeService.GetEmployeeById(_employeeId);
            //    if (employee != null)
            //    {
            //        DialogResult result = XtraMessageBox.Show("Bạn có chắc muốn xóa thông tin Nhân Viên : " + employee.EmployeeName + " này không?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            //        if (result == DialogResult.Yes)
            //        {
            //            try
            //            {
            //                _employeeService.Delete(_employeeId);
            //                LoadEmployees();
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
            //    XtraMessageBox.Show("Vui lòng chọn một Nhân Viên cần xóa!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        /// <summary>
        /// Load lại dữ liệu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemRefesh_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadEmployees();
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
        /// Nhập Nhân viên Từ tập tin Excel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemImportEmploeeFormExcel_ItemClick(object sender, ItemClickEventArgs e)
        {
            var importEmployeeFormExcel = new FormImportEmployeeFormExcel();
            importEmployeeFormExcel.ShowDialog();
            LoadEmployees();
        }

        private void FormEmployees_KeyDown(object sender, KeyEventArgs e)
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
                        barButtonItemImportEmploeeFormExcel.PerformClick();
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