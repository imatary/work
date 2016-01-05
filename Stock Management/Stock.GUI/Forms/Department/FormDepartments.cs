using System;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Stock.GUI.Helper;
using Stock.Services;

namespace Stock.GUI.Forms
{
    public partial class FormDepartments : XtraForm
    {
        private string _departmentId;
        private readonly LogService _logService;
        private readonly DepartmentService _departmentService;
        public FormDepartments()
        {
            InitializeComponent();

            _logService = new LogService();
            _departmentService = new DepartmentService();
        
            InsertSysLog();
            EnableButtonUpdateAndDelete(false);
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
            bbiEditDepartment.Enabled = enable;
            bbiDeleteDepartment.Enabled = enable;
        }

        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            if (e.Clicks == 1)
            {
                _departmentId = (string)((GridView)sender).GetRowCellValue(e.RowHandle, "DepartmentID");
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
                MessageBoxHelper.ShowMessageBoxEditWaringNotSelectId(this.Text);
            }
            else
            {
                var insertOrUpdate = new FormInsertOrUpdateDepartment(_departmentId);
                insertOrUpdate.ShowDialog();
                LoadData();
            }
        }

        private void FormDepartments_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void bbiAddDepartment_ItemClick(object sender, ItemClickEventArgs e)
        {
            var insertOrUpdate = new FormInsertOrUpdateDepartment(null);
            insertOrUpdate.ShowDialog();
            LoadData();
        }

        private void bbiEditDepartment_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (string.IsNullOrEmpty(_departmentId))
            {
                MessageBoxHelper.ShowMessageBoxEditWaringNotSelectId(this.Text);
            }
            else
            {
                var insertOrUpdate = new FormInsertOrUpdateDepartment(_departmentId);
                insertOrUpdate.ShowDialog();
                LoadData();
            }
        }

        private void bbiDeleteDepartment_ItemClick(object sender, ItemClickEventArgs e)
        {
            DialogResult result = XtraMessageBox.Show("Bạn có chắc muốn xóa không?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                foreach (var rowHandle in gridView1.GetSelectedRows())
                {
                    var departmentId = gridView1.GetRowCellValue(rowHandle, "DepartmentID");
                    if (departmentId != null)
                    {
                        var department = _departmentService.GetDepartmentById(departmentId.ToString());
                        if (department != null)
                        {
                            try
                            {
                                _departmentService.Delete(departmentId.ToString());
                            }
                            catch (Exception ex)
                            {
                                MessageBoxHelper.ShowMessageBoxError(ex.Message);
                            }
                        }
                    }
                }
                LoadData();
            }
            else
            {
                EnableButtonUpdateAndDelete(false);
            }
        }

        private void bbiRefeshDepartment_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadData();
        }

        /// <summary>
        /// Load data
        /// </summary>
        private void LoadData()
        {
            gridControlDepartments.DataSource = _departmentService.GetDepartments();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                // Thêm
                case Keys.Control | Keys.N:
                    {
                        bbiAddDepartment.PerformClick();
                        return true;
                    }

                // Sửa
                case Keys.Control | Keys.E:
                    {
                        bbiEditDepartment.PerformClick();
                        return true;
                    }

                // Xóa
                case Keys.Control | Keys.D:
                    {
                        bbiDeleteDepartment.PerformClick();
                        return true;
                    }

                // Refesh
                case Keys.F5:
                    {
                        bbiRefeshDepartment.PerformClick();
                        return true;
                    }

                // IN
                case Keys.Control | Keys.P:
                    {
                        bbiPrinterDepartment.PerformClick();
                        return true;
                    }

                // Thoát
                case Keys.Escape:
                    {
                        bbiColseFormDepartment.PerformClick();
                        return true;
                    }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}