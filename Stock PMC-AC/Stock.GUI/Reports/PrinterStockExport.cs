using System.Collections;
using DevExpress.XtraReports.UI;

namespace Stock.GUI.Reports
{
    public partial class PrinterStockExport : XtraReport
    {
        public PrinterStockExport(
            ArrayList list,
            string employeeName,
            string reason,
            string address,
            double total,
            string orderExportId
            )
        {
            InitializeComponent();

            gridControl1.DataSource = list;
            xrLblEmployeeName.Text = employeeName;
            xrLblLyDo.Text = reason;
            xrLblAddressName.Text = address;
            xrLblOrderExportID.Text = orderExportId;
            xrLblTotal.Text = string.Format("{0:0,0} VNĐ", total);
        }

           

    }
}
