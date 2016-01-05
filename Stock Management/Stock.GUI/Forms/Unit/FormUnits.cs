using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Stock.Data;
using Stock.GUI.Helper;
using Stock.Services;

namespace Stock.GUI.Forms
{
    public partial class FormUnits : XtraForm
    {
        private string _unitId;
        private readonly UnitService _unitService;
        private readonly LogService _logService;
        public FormUnits()
        {
            InitializeComponent();

            _unitService = new UnitService();
            _logService = new LogService();
            InsertSysLog();

            EnableButtonUpdateAndDelete(false);
        }

        private void bbiAddUnit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var insertOrUpdate = new FormInsertOrUpdateUnit(null);
            insertOrUpdate.ShowDialog();
            LoadData();
        }

        private void FormUnits_Load(object sender, System.EventArgs e)
        {
            LoadData();
        }

        /// <summary>
        /// Load
        /// </summary>
        private void LoadData()
        {
            gridControlUnits.DataSource = _unitService.GetUnits();
        }

        /// <summary>
        /// Log History
        /// </summary>
        private void InsertSysLog()
        {
            string userName = Program.CurrentUser.Username;

            _logService.InsertLog(userName, this.Text, this.Text);
        }

        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            if (e.Clicks == 1)
            {
                _unitId = (string)((GridView)sender).GetRowCellValue(e.RowHandle, "UnitID");
                if (!string.IsNullOrEmpty(_unitId))
                {
                    EnableButtonUpdateAndDelete(true);
                }
            }
            else
            {
                EnableButtonUpdateAndDelete(false);
            }
        }

        private void gridView1_DoubleClick(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(_unitId))
            {
                MessageBoxHelper.ShowMessageBoxEditWaringNotSelectId(this.Text);
            }
            else
            {
                var insertOrUpdate = new FormInsertOrUpdateUnit(_unitId);
                insertOrUpdate.ShowDialog();
                LoadData();
            }
        }

        /// <summary>
        /// Enable Button
        /// </summary>
        /// <param name="enable"></param>
        private void EnableButtonUpdateAndDelete(bool enable)
        {
            bbiEditUnit.Enabled = enable;
            bbiDeleteUnit.Enabled = enable;
        }

        /// <summary>
        /// Edit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbiEditUnit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (string.IsNullOrEmpty(_unitId))
            {
                MessageBoxHelper.ShowMessageBoxEditWaringNotSelectId(this.Text);
            }
            else
            {
                var insertOrUpdate = new FormInsertOrUpdateUnit(_unitId);
                insertOrUpdate.ShowDialog();
                LoadData();
            }
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbiDeleteUnit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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


        /// <summary>
        /// Refesh
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbiRefeshUnit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadData();
        }


        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                    // Thêm
                case Keys.Control | Keys.N:
                    {
                        bbiAddUnit.PerformClick();
                        return true;
                    }
                    
                    // Sửa
                case Keys.Control | Keys.E:
                    {
                        bbiEditUnit.PerformClick();
                        return true;
                    }

                    // Xóa
                case Keys.Control | Keys.D:
                    {
                        bbiDeleteUnit.PerformClick();
                        return true;
                    }

                    // Refesh
                case Keys.F5:
                    {
                        bbiRefeshUnit.PerformClick();
                        return true;
                    }

                    // IN
                case Keys.Control | Keys.P:
                    {
                        bbiPrinterUnit.PerformClick();
                        return true;
                    }

                    // Thoát
                case Keys.Escape:
                    {
                        bbiColseFormUnit.PerformClick();
                        return true;
                    }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        
    }
}