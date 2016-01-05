using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using Stock.GUI.Helper;
using Stock.Services;

namespace Stock.GUI.Forms
{
    public partial class FormStocks : XtraForm
    {
        private string _stockId;
        private readonly StockService _stockService;
        private readonly LogService _logService;
        public FormStocks()
        {
            InitializeComponent();

            _stockService = new StockService();
            _logService = new LogService();
            InsertSysLog();

            EnableButtonUpdateAndDelete(false);
        }

        private void bbiAddStock_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var insertOrUpdate = new FormInsertOrUpdateStock(null);
            insertOrUpdate.ShowDialog();
            LoadData();
        }

        private void FormStocks_Load(object sender, System.EventArgs e)
        {
            LoadData();
        }

        /// <summary>
        /// Load
        /// </summary>
        private void LoadData()
        {
            gridControlStocks.DataSource = _stockService.GetStocks();
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
                _stockId = (string)((GridView)sender).GetRowCellValue(e.RowHandle, "StockID");
                if (!string.IsNullOrEmpty(_stockId))
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
            if (string.IsNullOrEmpty(_stockId))
            {
                MessageBoxHelper.ShowMessageBoxEditWaringNotSelectId(this.Text);
            }
            else
            {
                var insertOrUpdate = new FormInsertOrUpdateStock(_stockId);
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
            bbiEditStock.Enabled = enable;
            bbiDeleteStock.Enabled = enable;
        }

        /// <summary>
        /// Edit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbiEditStock_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (string.IsNullOrEmpty(_stockId))
            {
                MessageBoxHelper.ShowMessageBoxEditWaringNotSelectId(this.Text);
            }
            else
            {
                var insertOrUpdate = new FormInsertOrUpdateStock(_stockId);
                insertOrUpdate.ShowDialog();
                LoadData();
            }
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bbiDeleteStock_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult result = XtraMessageBox.Show("Bạn có chắc muốn xóa không?", "THÔNG BÁO", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                foreach (var rowHandle in gridView1.GetSelectedRows())
                {
                    var stockId = gridView1.GetRowCellValue(rowHandle, "StockID");
                    if (stockId != null)
                    {
                        Data.Stock stock = _stockService.GetStockById(stockId.ToString());
                        if (stock != null)
                        {
                            try
                            {
                                _stockService.Delete(stockId.ToString());
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
        private void bbiRefeshStock_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
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
                        bbiAddStock.PerformClick();
                        return true;
                    }
                    
                    // Sửa
                case Keys.Control | Keys.E:
                    {
                        bbiEditStock.PerformClick();
                        return true;
                    }

                    // Xóa
                case Keys.Control | Keys.D:
                    {
                        bbiDeleteStock.PerformClick();
                        return true;
                    }

                    // Refesh
                case Keys.F5:
                    {
                        bbiRefeshStock.PerformClick();
                        return true;
                    }

                    // IN
                case Keys.Control | Keys.P:
                    {
                        bbiPrinterStock.PerformClick();
                        return true;
                    }

                    // Thoát
                case Keys.Escape:
                    {
                        bbiColseFormStock.PerformClick();
                        return true;
                    }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}