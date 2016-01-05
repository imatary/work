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
    public partial class FormUnit : XtraForm
    {
        public string UnitId;
        private readonly UnitService _unitService;
        private readonly LogService _logService;
        private readonly EmployeeService _employeeService;
        public FormUnit()
        {
            InitializeComponent();
            _unitService = new UnitService();
            _logService=new LogService();
            _employeeService = new EmployeeService();
            InsertSysLog();
        }

        private void FormUnit_Load(object sender, EventArgs e)
        {
            LoadUnits();
        }

        /// <summary>
        // Lưu lại quá trình hoạt động của người dùng trên hệ thống
        /// </summary>
        private void InsertSysLog()
        {
            string userName = Program.CurrentUser.UserName;
            string employeeName = _employeeService.GetEmployeeById(Program.CurrentUser.EmployeeID).EmployeeName;
            string info = MachineHelper.GetMachineInfo();

            _logService.InsertLog(userName, employeeName, Resources.ActionPreview, Resources.FormTitleUnit, info);
        }

        /// <summary>
        /// Danh sách đơn vị
        /// </summary>
        private void LoadUnits()
        {
            gridControl1.DataSource = _unitService.GetUnits();
        }

        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            if (e.Clicks == 1)
            {
                UnitId = (string)((GridView)sender).GetRowCellValue(e.RowHandle, "UnitID");
                EnableButtonUpdateAndDelete(true);
                if (string.IsNullOrEmpty(UnitId))
                    XtraMessageBox.Show("Vui lòng chọn một Đơn Vị cần sửa!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                EnableButtonUpdateAndDelete(false);
            }
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(UnitId))
            {
                XtraMessageBox.Show("Bạn chưa chọn Đơn Vị cần sửa!", "THÔNG BÁO");
            }
            else
            {
                var updateUnit = new FormUpdateUnit(UnitId);
                updateUnit.ShowDialog();
                LoadUnits();
            }
        }

        private void barButtonItemAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            var unit = new FormAddUnit();
            unit.ShowDialog();
            LoadUnits();
        }

        private void barButtonItemUpdate_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (string.IsNullOrEmpty(UnitId))
            {
                XtraMessageBox.Show("Bạn chưa chọn Đơn Vị cần sửa!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else
            {
                var update = new FormUpdateUnit(UnitId);
                update.ShowDialog();
                LoadUnits();
            }
        }

        /// <summary>
        /// Xóa đơn vị
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
                    var unitId = gridView1.GetRowCellValue(rowHandle, "UnitID");
                    if (unitId != null)
                    {
                        Unit unit = _unitService.GetUnitById(unitId.ToString());
                        if (unit != null)
                        {
                            try
                            {
                                _unitService.Delete(unitId.ToString());
                            }
                            catch (Exception ex)
                            {
                                XtraMessageBox.Show(string.Format("Lỗi! \n {0}", ex.Message), "THÔNG BÁO",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                LoadUnits();
            }
            else
            {
                EnableButtonUpdateAndDelete(false);
            }

            //if (!string.IsNullOrEmpty(UnitId))
            //{
            //    Unit unit = _unitService.GetUnitById(UnitId);
            //    if (unit != null)
            //    {
            //        DialogResult result = XtraMessageBox.Show("Bạn có chắc muốn xóa thông tin Đơn Vị Tính : " + unit.UnitName + " không?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            //        if (result == DialogResult.Yes)
            //        {
            //            try
            //            {
            //                _unitService.Delete(UnitId);
            //                LoadUnits();
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
            LoadUnits();
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

        private void EnableButtonUpdateAndDelete(bool enable)
        {
            barButtonItemUpdate.Enabled = enable;
            barButtonItemDelete.Enabled = enable;
        }

        private void FormUnit_KeyDown(object sender, KeyEventArgs e)
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
                    //    barButtonItemImportAreaFormExel.PerformClick();
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