using System;
using System.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Stock.Data;
using Stock.GUI.Helper;
using Stock.Services;

namespace Stock.GUI.Forms
{
    public partial class FormProductGroups : XtraForm
    {
        private string _productGroupId;
        private readonly LogService _logService;
        private readonly ProductGroupService _productGroupService;
        public FormProductGroups()
        {
            InitializeComponent();

            _logService = new LogService();
            _productGroupService = new ProductGroupService();

            InsertSysLog();
        }

        /// <summary>
        /// System History
        /// </summary>
        private void InsertSysLog()
        {
            string userName = Program.CurrentUser.Username;

            _logService.InsertLog(userName, this.Text, this.Text);
        }

        /// <summary>
        /// Load
        /// </summary>
        private void LoadData()
        {
            gridControlProductGroups.DataSource = _productGroupService.GetProductGroups();
        }

        private void FormProductGroups_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enable"></param>
        private void EnableButtonUpdateAndDelete(bool enable)
        {
            bbiEditProductGroup.Enabled = enable;
            bbiDeleteProductGroup.Enabled = enable;
        }

        private void gridView1_RowClick(object sender, RowClickEventArgs e)
        {
            if (e.Clicks == 1)
            {
                _productGroupId = (string)((GridView)sender).GetRowCellValue(e.RowHandle, "ProductGroupID");
                if (!string.IsNullOrEmpty(_productGroupId))
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
            if (string.IsNullOrEmpty(_productGroupId))
            {
                MessageBoxHelper.ShowMessageBoxEditWaringNotSelectId(this.Text);
            }
            else
            {
                var insertOrUpdate = new FormInsertOrUpdateProductGroup(_productGroupId);
                insertOrUpdate.ShowDialog();
                LoadData();
            }
        }

        /// <summary>
        /// Thêm
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbiAddProductGroup_ItemClick(object sender, ItemClickEventArgs e)
        {
            var insertOrUpdate = new FormInsertOrUpdateProductGroup(null);
            insertOrUpdate.ShowDialog();
            LoadData();
        }

        /// <summary>
        /// Sửa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbiEditProductGroup_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (string.IsNullOrEmpty(_productGroupId))
            {
                MessageBoxHelper.ShowMessageBoxEditWaringNotSelectId(this.Text);
            }
            else
            {
                var insertOrUpdate = new FormInsertOrUpdateProductGroup(_productGroupId);
                insertOrUpdate.ShowDialog();
                LoadData();
            }
        }

        private void bbiDeleteProductGroup_ItemClick(object sender, ItemClickEventArgs e)
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

        private void bbiRefeshProductGroup_ItemClick(object sender, ItemClickEventArgs e)
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
                        bbiAddProductGroup.PerformClick();
                        return true;
                    }

                // Sửa
                case Keys.Control | Keys.E:
                    {
                        bbiEditProductGroup.PerformClick();
                        return true;
                    }

                // Xóa
                case Keys.Control | Keys.D:
                    {
                        bbiDeleteProductGroup.PerformClick();
                        return true;
                    }

                // Refesh
                case Keys.F5:
                    {
                        bbiRefeshProductGroup.PerformClick();
                        return true;
                    }

                // IN
                case Keys.Control | Keys.P:
                    {
                        bbiPrinterProductGroup.PerformClick();
                        return true;
                    }

                // Thoát
                case Keys.Escape:
                    {
                        bbiColseFormProductGroup.PerformClick();
                        return true;
                    }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}