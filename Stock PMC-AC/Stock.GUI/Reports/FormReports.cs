using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
using Stock.Data;
using Stock.GUI.Helpers;
using Stock.GUI.Models;
using Stock.GUI.Properties;

namespace Stock.GUI.Reports
{
    public partial class FormReports : XtraForm
    {
        private readonly WaitDialogFormHelper _waitDialog = new WaitDialogFormHelper();
        public FormReports()
        {
            InitializeComponent();
            LoadItem();
        }

        private void FormReports_Load(object sender, EventArgs e)
        {
            if (gridControl1.DataSource != null)
            {
                EnableButtonExportExelAndPrinter(true);
            }
            panelControlFindDay.Location = new Point(2);
        }
        public void LoadItem()
        {
            //comboBoxEditTime.Properties.Items.Add("Tùy Chọn");
            comboBoxEditTime.Properties.Items.Add("Hôm nay");
            comboBoxEditTime.Properties.Items.Add("Năm này");
            comboBoxEditTime.Properties.Items.Add("Tháng 1");
            comboBoxEditTime.Properties.Items.Add("Tháng 2");
            comboBoxEditTime.Properties.Items.Add("Tháng 3");
            comboBoxEditTime.Properties.Items.Add("Tháng 4");
            comboBoxEditTime.Properties.Items.Add("Tháng 5");
            comboBoxEditTime.Properties.Items.Add("Tháng 6");
            comboBoxEditTime.Properties.Items.Add("Tháng 7");
            comboBoxEditTime.Properties.Items.Add("Tháng 8");
            comboBoxEditTime.Properties.Items.Add("Tháng 9");
            comboBoxEditTime.Properties.Items.Add("Tháng 10");
            comboBoxEditTime.Properties.Items.Add("Tháng 11");
            comboBoxEditTime.Properties.Items.Add("Tháng 12");
            comboBoxEditTime.SelectedIndex = 1;
        }

        private List<ReportByStockView> _reportViews;
        private List<ReportByProductGroupView> _productGroupViews;

        /// <summary>
        /// Load danh sách Kho Hàng 
        /// </summary>
        private void LoadDataForGridViewReportByStock(DateTime? startDate, DateTime? endDate)
        {
            _waitDialog.CreateWaitDialog();
            _waitDialog.SetWaitDialogCaption("Chương trình đang tải dữ liệu.\n Vui lòng chờ trong giây lát!");
            dockPanelReports.Text = Resources.TitleDockPanelReportByStock;

            using (var context = new StockACEntities())
            {

                var reportByStock = (from inventory in context.Inventories
                                   join product in context.Products on inventory.ProductID equals product.ProductID
                                   join productGroup in context.ProductGroups on product.ProductGroupID equals productGroup.ProductGroupID
                                   join unit in context.Units on product.UnitID equals unit.UnitID
                                   join stock in context.Stocks on product.StockID equals stock.StockID
                                   select new ReportByStockView()
                                   {
                                       ProductGroupName = productGroup.ProductGroupName,
                                       ProductID = product.ProductID,
                                       ProductName = product.ProductName,
                                       Price = (int)product.Price,
                                       InventoryDate = inventory.InventoryDate,
                                       UnitName = unit.UnitName,
                                       StockName = stock.StockName,
                                       Quantity = (int) inventory.QuantityExport,
                                   }).ToList();


                gridControl1.MainView = gridViewStocks;
                
                if (startDate != null && endDate != null)
                {
                    gridControl1.DataSource =
                        reportByStock.Where(inventory => inventory.InventoryDate >= startDate && inventory.InventoryDate <= endDate);
                }
                else
                {
                    gridControl1.DataSource = reportByStock;
                }
                
                if (gridControl1.DataSource != null)
                {
                    EnableButtonExportExelAndPrinter(true);
                }
                _reportViews = reportByStock;
                _waitDialog.CloseWait();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="productGroupId"></param>
        private void LoadDataForGridViewReportByProductGroups(string productGroupId)
        {
            _waitDialog.CreateWaitDialog();
            _waitDialog.SetWaitDialogCaption("Chương trình đang tải dữ liệu.\n Vui lòng chờ trong giây lát!");
            dockPanelReports.Text = Resources.TitleDockPanelReportByProductGroups;
            using (var context = new StockACEntities())
            {

                var reports = (from inventory in context.Inventories
                                     join product in context.Products on inventory.ProductID equals product.ProductID
                                     join productGroup in context.ProductGroups on product.ProductGroupID equals productGroup.ProductGroupID
                                     join unit in context.Units on product.UnitID equals unit.UnitID
                                     join stock in context.Stocks on product.StockID equals stock.StockID
                                     select new ReportByProductGroupView()
                                     {
                                         ProductGroupID = product.ProductGroupID,
                                         ProductGroupName = productGroup.ProductGroupName,
                                         ProductID = product.ProductID,
                                         ProductName = product.ProductName,
                                         Price = (int)product.Price,
                                         InventoryDate = inventory.InventoryDate,
                                         UnitName = unit.UnitName,
                                         StockName = stock.StockName,
                                         Quantity = (int)inventory.QuantityExport,
                                     }).ToList();


                gridControl1.MainView = gridViewProductGroup;

                if (!string.IsNullOrEmpty(productGroupId))
                {
                    gridControl1.DataSource = reports.Where(pro => pro.ProductGroupID == productGroupId);
                }
                else
                {
                    gridControl1.DataSource = reports;
                }

                if (gridControl1.DataSource != null)
                {
                    EnableButtonExportExelAndPrinter(true);
                }
                _productGroupViews = reports;
                _waitDialog.CloseWait();
            }
        }
        private void comboBoxEditTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDays();
        }

        public void LoadDays()
        {
            switch (comboBoxEditTime.SelectedIndex)
            {


                case 0:
                    {
                        dateEditEndDate.Text = DateTime.Now.ToShortDateString();
                        dateEditStartDate.Text = DateTime.Now.ToShortDateString();
                        break;
                    }
                case 1:
                    {
                        dateEditEndDate.Text = "12/31/" + DateTime.Now.Year;
                        dateEditStartDate.Text = "01/01/" + DateTime.Now.Year;
                        break;
                    }
                case 2:
                    {
                        dateEditEndDate.Text = "01/31/" + DateTime.Now.Year;
                        dateEditStartDate.Text = "01/01/" + DateTime.Now.Year;
                        break;
                    }
                case 3:
                    {
                        dateEditEndDate.Text = "02/28/" + DateTime.Now.Year;
                        dateEditStartDate.Text = "02/01/" + DateTime.Now.Year.ToString();
                        break;
                    }
                case 4:
                    {
                        dateEditEndDate.Text = "03/31/" + DateTime.Now.Year;
                        dateEditStartDate.Text = "03/01/" + DateTime.Now.Year;
                        break;
                    }
                case 5:
                    {
                        dateEditEndDate.Text = "04/30/" + DateTime.Now.Year;
                        dateEditStartDate.Text = "04/01/" + DateTime.Now.Year;
                        break;
                    }
                case 6:
                    {
                        dateEditEndDate.Text = "05/31/" + DateTime.Now.Year;
                        dateEditStartDate.Text = "05/01/" + DateTime.Now.Year;
                        break;
                    }
                case 7:
                    {
                        dateEditEndDate.Text = "06/31/" + DateTime.Now.Year;
                        dateEditStartDate.Text = "06/01/" + DateTime.Now.Year;
                        break;
                    }
                case 8:
                    {
                        dateEditEndDate.Text = "07/31/" + DateTime.Now.Year;
                        dateEditStartDate.Text = "07/01/" + DateTime.Now.Year;
                        break;
                    }
                case 9:
                    {
                        dateEditEndDate.Text = "08/31/" + DateTime.Now.Year;
                        dateEditStartDate.Text = "08/01/" + DateTime.Now.Year;
                        break;
                    }
                case 10:
                    {
                        dateEditEndDate.Text = "09/30/" + DateTime.Now.Year;
                        dateEditStartDate.Text = "09/01/" + DateTime.Now.Year;
                        break;
                    }
                case 11:
                    {
                        dateEditEndDate.Text = "10/31/" + DateTime.Now.Year;
                        dateEditStartDate.Text = "10/01/" + DateTime.Now.Year;
                        break;
                    }
                case 12:
                    {
                        dateEditEndDate.Text = "11/30/" + DateTime.Now.Year;
                        dateEditStartDate.Text = "11/01/" + DateTime.Now.Year;
                        break;
                    }
                case 13:
                    {
                        dateEditEndDate.Text = "12/31/" + DateTime.Now.Year;
                        dateEditStartDate.Text = "12/01/" + DateTime.Now.Year;
                        break;
                    }
                case 14:
                    {

                        dateEditEndDate.Text = DateTime.Now.ToShortDateString();
                        dateEditStartDate.Text = DateTime.Now.ToShortDateString();
                        break;
                    }

            }

        }

        /// <summary>
        /// Load danh sách nhóm hàng
        /// </summary>
        private void LoadGirdLookUpProductGroup()
        {
            using (var context = new StockACEntities())
            {
                var stocks = context.ProductGroups.ToList();
                gridLookUpEditProductGroups.Properties.View.OptionsBehavior.AutoPopulateColumns = false;
                gridLookUpEditProductGroups.Properties.DisplayMember = "ProductGroupName";
                gridLookUpEditProductGroups.Properties.ValueMember = "ProductGroupID";
                gridLookUpEditProductGroups.Properties.View.BestFitColumns();
                gridLookUpEditProductGroups.Properties.PopupFormWidth = 406;
                gridLookUpEditProductGroups.Properties.DataSource = stocks;
            }

        }

        /// <summary>
        /// Enable Button Xuất file và In
        /// </summary>
        /// <param name="enable"></param>
        private void EnableButtonExportExelAndPrinter(bool enable)
        {
            btnExportExel.Enabled = enable;
            btnPrinter.Enabled = enable;
        }

        //private void VisibleControlFinds(bool visible)
        //{
        //    comboBoxEditTime.Visible = visible;
        //    dateEditStartDate.Visible = visible;
        //    dateEditEndDate.Visible = visible;
        //    pictureEdit1.Visible = visible;
        //    btnSearch.Visible = visible;
        //}

        //private void VisibleGridLookUpProductGroup(bool visible)
        //{
        //    gridLookUpEditProductGroups.Visible = visible;
        //}
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string startDate = dateEditStartDate.Text;
            string endDate = dateEditEndDate.Text;
            if (!string.IsNullOrEmpty(startDate) && string.IsNullOrEmpty(endDate))
            {
                LoadDataForGridViewReportByStock(DatetimeConverter.StringToShortDate(startDate), DatetimeConverter.StringToShortDate(endDate));
            }        
        }

        private void btnExportExel_Click(object sender, EventArgs e)
        {
            try
            {
                var saveFileDialog1 = new SaveFileDialog
                {
                    Filter = Resources.SaveFileDialogFilterExel,
                    Title = Resources.SaveFileDialogTitle
                };
                saveFileDialog1.ShowDialog();
                if (saveFileDialog1.FileName != "")
                {gridControl1.ExportToXls(saveFileDialog1.FileName);
                }
            }
            catch (Exception ex)
            {
                XtraMessageBox.Show(string.Format("{0}", ex.Message), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrinter_Click(object sender, EventArgs e)
        {
            if (gridControl1.MainView == gridViewStocks)
            {
                try
                {
                    var printerReportByStock = new PrinterReportByStock(_reportViews);
                    printerReportByStock.ShowPreviewDialog();
                }
                catch (Exception ex)
                {
                    XtraMessageBox.Show(string.Format("{0}", ex.Message), "Lỗi!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }


        }


        /// <summary>
        /// Bảng kê theo Kho Hàng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void navBarItemStocks_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //VisibleControlFinds(true);
            //VisibleGridLookUpProductGroup(false);
            panelControlFindDay.Location = new Point(2);
            panelControlFindDay.Visible = true;
            panelControlGridLookUpEditProductGroup.Visible = false;
            LoadDataForGridViewReportByStock(null, null);

        }

        /// <summary>
        /// Bảng kê theo Nhóm Hàng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void navBarItemProductGroups_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            panelControlFindDay.Visible = false;
            panelControlGridLookUpEditProductGroup.Visible = true;
            //VisibleControlFinds(false);
            LoadGirdLookUpProductGroup();
            //VisibleGridLookUpProductGroup(true);
            LoadDataForGridViewReportByProductGroups(null);
        }

        private void gridLookUpEditProductGroups_EditValueChanged(object sender, EventArgs e)
        {
            
            string productGroupId = gridLookUpEditProductGroups.EditValue.ToString();
            LoadDataForGridViewReportByProductGroups(productGroupId);
        }

        private void navBarItemEmployee_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {

        }
    }
}