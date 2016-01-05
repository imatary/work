using System.Collections.Generic;
using DevExpress.XtraReports.UI;
using Stock.GUI.Models;

namespace Stock.GUI.Reports
{
    public partial class PrinterReportByStock : XtraReport
    {
        public PrinterReportByStock(List<ReportByStockView> reportByStockViews )
        {
            InitializeComponent();

            gridControl1.MainView = gridViewStocks;
            gridControl1.DataSource = reportByStockViews;
        }

    }
}
