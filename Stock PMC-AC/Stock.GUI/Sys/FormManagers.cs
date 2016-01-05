using System;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Stock.Data;
using Stock.GUI.Properties;
using Stock.Services;

namespace Stock.GUI.Sys
{
    public partial class FormManagers : XtraForm
    {
        private readonly ManagersService _managersService;
        private readonly EmployeeService _employeeService;
        private string _employeeId;
        public FormManagers()
        {
            InitializeComponent();
            _managersService = new ManagersService();
            _employeeService = new EmployeeService();
        }

        /// <summary>
        /// Danh sách nhân viên quản lý
        /// </summary>
        private void LoadListManagers()
        {
            gridControl1.DataSource = _managersService.GetManagers();
        }

        private void FormManagers_Load(object sender, EventArgs e)
        {
            LoadListManagers();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemAdd_ItemClick(object sender, ItemClickEventArgs e)
        {
            var add = new FormAddManager();
            add.ShowDialog();
            LoadListManagers();
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
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_employeeId))
            {
                XtraMessageBox.Show("Vui lòng chọn một Nhân Viên cần sửa!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var update = new FormUpdateManager(_employeeId);
                update.ShowDialog();
                LoadListManagers();
                _employeeId = null;
                EnableButtonUpdateAndDelete(false);
            }
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
                XtraMessageBox.Show("Bạn chưa chọn Quản Lý cần sửa!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var update = new FormUpdateManager(_employeeId);
                update.ShowDialog();
                LoadListManagers();
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
            if (!string.IsNullOrEmpty(_employeeId))
            {
                Employee employee = _employeeService.GetEmployeeById(_employeeId);
                if (employee != null)
                {
                    DialogResult result = XtraMessageBox.Show("Bạn có chắc muốn xóa thông tin Quản Lý : " + employee.EmployeeName + " này không?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result == DialogResult.Yes)
                    {
                        try
                        {
                            _employeeService.Delete(_employeeId);
                            LoadListManagers();
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
                XtraMessageBox.Show("Vui lòng chọn một Quản Lý cần xóa!", "THÔNG BÁO", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        /// <summary>
        /// Load lại dữ liệu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItemRefesh_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadListManagers();
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
    }
}