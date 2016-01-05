using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Stock.GUI.Properties;
using Stock.Services;

namespace Stock.GUI.Forms
{
    public partial class FormReports : DevExpress.XtraEditors.XtraForm
    {
        private readonly WeekReportService _weekReportService;
        private readonly DepartmentService _departmentService;
        private readonly InventoryService _inventoryService;
        public FormReports()
        {
            
            InitializeComponent();

            _weekReportService = new WeekReportService();
            _departmentService = new DepartmentService();
            _inventoryService = new InventoryService();
        }

        /// <summary>
        /// Enable Button Xuất file và In
        /// </summary>
        /// <param name="enable"></param>
        private void EnableButtonExportExelAndPrinter(bool enable)
        {
            btnSearch.Enabled = enable;
            btnExportExel.Enabled = enable;
            btnPrinter.Enabled = enable;
        }

        private void LoadDepartmentForGridLookUp()
        {
            var departments = _departmentService.GetDepartments();
            gridLookUpEditDepartment.Properties.View.OptionsBehavior.AutoPopulateColumns = false;
            gridLookUpEditDepartment.Properties.View.BestFitColumns();
            gridLookUpEditDepartment.Properties.PopupFormWidth = 220;
            gridLookUpEditDepartment.Properties.DataSource = departments;
            gridLookUpEditDepartment.Properties.DisplayMember = "DepartmentName";
            gridLookUpEditDepartment.Properties.ValueMember = "DepartmentID";
        }

        private void FormReports_Load(object sender, EventArgs e)
        {
            LoadDepartmentForGridLookUp();
            LoadDataForGridViewReportTotals(null);


            EnableButtonExportExelAndPrinter(false);

            gridLookUpEditDepartment.Enabled = false;
            dateEditReportDate.Enabled = false;
            toolStripTextBox1.Enabled = false;
            toolStripTextBox2.Enabled = false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reportDate"></param>
        private void LoadDataForGridViewWeekReports(string reportDate)
        {
            dockPanelReports.Text = "Báo Cáo Tuần";
            splashScreenManager1.ShowWaitForm();
            var weekReports = _weekReportService.GetWeekReports(reportDate);
            if (weekReports != null)
            {
                EnableButtonExportExelAndPrinter(true);

                gridLookUpEditDepartment.Enabled = false;
                dateEditReportDate.Enabled = true;
                toolStripTextBox1.Enabled = true;
                toolStripTextBox2.Enabled = true;

                gridControl1.MainView = gridvWeekReports;
                gridControl1.DataSource = weekReports;
            }
            else
            {
                gridControl1.MainView = gridvWeekReports;
                gridControl1.DataSource = null;
            }
            
            splashScreenManager1.CloseWaitForm();
            
            
        }


        private void LoadDataForGridViewReportTotals(string reportDate)
        {
            dockPanelReports.Text = "BÁO CÁO TỔNG HỢP NHẬP XUẤT TỒN";
            splashScreenManager1.ShowWaitForm();
            List<ReportTotalView> reportTotals=null;
            if (reportDate != null)
            {
                reportTotals = _inventoryService.GetReportTotals().Where(r => r.SearchByDate == reportDate).ToList();
            }
            else
            {
                reportTotals = _inventoryService.GetReportTotals();
            }
            if (reportTotals == null)
            {
                EnableButtonExportExelAndPrinter(false);
            }

            EnableButtonExportExelAndPrinter(true);

            gridLookUpEditDepartment.Enabled = false;
            dateEditReportDate.Enabled = true;
            toolStripTextBox1.Enabled = true;
            toolStripTextBox2.Enabled = true;


            gridControl1.MainView = gridvTotal;
            if (reportTotals != null && reportTotals.Count > 0)
            {
                gridControl1.DataSource = reportTotals;
            }
            else
            {
                gridControl1.DataSource = null;
            }
            splashScreenManager1.CloseWaitForm();
        }

        private void LoadDataForGridViewReportByDepartment(string department)
        {
            dockPanelReports.Text = "BÁO CÁO NHẬP XUẤT TỒN THEO BỘ PHẬN";
            splashScreenManager1.ShowWaitForm();
            List<ReportByDepartment> reportByDepartments = null;
            if (department != null)
            {
                reportByDepartments = _inventoryService.GetReportsByDepartments().Where(r => r.DepartmentID == department).ToList();
            }
            else
            {
                reportByDepartments = _inventoryService.GetReportsByDepartments();
            }
            if (reportByDepartments==null)
            {
                EnableButtonExportExelAndPrinter(false);
            }
            EnableButtonExportExelAndPrinter(true);
            gridLookUpEditDepartment.Enabled = true;
            dateEditReportDate.Enabled = true;
            toolStripTextBox1.Enabled = true;
            toolStripTextBox2.Enabled = true;

            gridControl1.MainView = gridvReportByDepartment;

            gridControl1.DataSource = reportByDepartments;
            splashScreenManager1.CloseWaitForm();
        }

        

        private void btnExportExel_Click(object sender, EventArgs e)
        {
            var saveFileDialog1 = new SaveFileDialog
            {
                Filter = Resources.SaveFileExcelFilter,
                Title = Resources.SaveFileExelTitle
            };
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                gridControl1.ExportToXls(saveFileDialog1.FileName);
            }
        }

        private void btnPrinter_Click(object sender, EventArgs e)
        {
            gridControl1.ShowPrintPreview();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string reportDate;
            if (gridLookUpEditDepartment.Enabled)
            {

                MessageBox.Show("Show Select");
            }
            else
            {
                reportDate = dateEditReportDate.DateTime.ToString("MM-yyyy");

                if (!string.IsNullOrEmpty(reportDate))
                {
                    if (gridControl1.MainView == gridvWeekReports)
                    {
                        LoadDataForGridViewWeekReports(reportDate);
                    }
                    else if (gridControl1.MainView == gridvTotal)
                    {
                        LoadDataForGridViewReportTotals(reportDate);
                    }
                }
            }
            


        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void navBarItemWeekReports_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            LoadDataForGridViewWeekReports(null);
        }
        private void navBarItemTotal_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            LoadDataForGridViewReportTotals(null);
        }

        private void navBarItemDepartment_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            LoadDataForGridViewReportByDepartment(null);
        }
    }
}