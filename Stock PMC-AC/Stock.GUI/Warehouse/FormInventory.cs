using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using Stock.Data;
using Stock.GUI.Properties;
using Stock.GUI.Reports;
using Stock.Services;

namespace Stock.GUI.Warehouse
{
    public partial class FormInventory : XtraForm
    {
        private readonly InventoryService _inventoryService;
        public FormInventory()
        {
            InitializeComponent();
            _inventoryService = new InventoryService();
            LoadStockForGirdLookup();
            LoadInventoriesForGridControl(null);
        }

        private void FormInventory_Load(object sender, EventArgs e)
        {
            if (gridControl2.DataSource == null)
            {
                EnableExportExelAndPrinter(false);
            }
            LoadDay();
        }

        private void LoadDay()
        {
            cbThoiGian.Properties.Items.Add("Ngày nay");
            cbThoiGian.Properties.Items.Add("Năm này");
            cbThoiGian.Properties.Items.Add("Tháng 1");
            cbThoiGian.Properties.Items.Add("Tháng 2");
            cbThoiGian.Properties.Items.Add("Tháng 3");
            cbThoiGian.Properties.Items.Add("Tháng 4");
            cbThoiGian.Properties.Items.Add("Tháng 5");
            cbThoiGian.Properties.Items.Add("Tháng 6");
            cbThoiGian.Properties.Items.Add("Tháng 7");
            cbThoiGian.Properties.Items.Add("Tháng 8");
            cbThoiGian.Properties.Items.Add("Tháng 9");
            cbThoiGian.Properties.Items.Add("Tháng 10");
            cbThoiGian.Properties.Items.Add("Tháng 11");
            cbThoiGian.Properties.Items.Add("Tháng 12");
            cbThoiGian.SelectedIndex = 1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enable"></param>
        private void EnableExportExelAndPrinter(bool enable)
        {
            btnExportToExel.Enabled = enable;
            btnPrint.Enabled = enable;
        }

        public void LoadStockForGirdLookup()
        {

            gridLookUpEditStock.Properties.View.OptionsBehavior.AutoPopulateColumns = false;
            gridLookUpEditStock.Properties.DisplayMember = "StockName";
            gridLookUpEditStock.Properties.ValueMember = "StockID";
            gridLookUpEditStock.Properties.View.BestFitColumns();
            gridLookUpEditStock.Properties.PopupFormWidth = 300;
            using (var context=new StockACEntities())
            {
                gridLookUpEditStock.Properties.DataSource = context.Stocks.ToList();
            }
            

            // glKhoHang.Text = "";
        }

        private IEnumerable<InventoryView> _inventoryViews;

        /// <summary>
        /// Load danh sách Kho Hàng 
        /// </summary>
        private void LoadInventoriesForGridControl(string stockId)
        {
            
            //string startDate = dateEditStartDate.Text;
            //string endDate = dateEditEndDate.Text;

            gridControl2.MainView = advBandedGridView3;
            if (stockId != null)
            {
                gridControl2.DataSource = _inventoryService.GetAllInventories().Where(c => c.StockID == stockId);
                _inventoryViews = _inventoryService.GetAllInventories().Where(c => c.StockID == stockId);
            }
            else
            {
               gridControl2.DataSource = _inventoryService.GetAllInventories();
               _inventoryViews = _inventoryService.GetAllInventories();
            }

            
        }

        private void glKhoHang_Properties_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                string stockId = gridLookUpEditStock.EditValue.ToString();
                LoadInventoriesForGridControl(stockId);
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(string.Format("Lỗi! \n {0}", ex.Message), "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// In
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (advBandedGridView3.RowCount > 0)
                {
                    var printerInventory = new PrinterInventory(_inventoryViews);
                    printerInventory.ShowPreviewDialog();
                }
                else
                {
                    XtraMessageBox.Show("Không có bản ghi nào!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(string.Format("Lỗi! \n {0}", ex.Message), "Thông báo lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Xuất file Exel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExportToExel_Click(object sender, EventArgs e)
        {
            var saveFileDialog1 = new SaveFileDialog
            {
                Filter = Resources.SaveFileDialogFilterExel,
                Title = Resources.SaveFileDialogTitle
            };
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                gridControl2.ExportToXls(saveFileDialog1.FileName);
            }
        }
    }
}