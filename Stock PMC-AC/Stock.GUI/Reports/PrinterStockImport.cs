using System.Collections;
using System.Globalization;
using DevExpress.XtraReports.UI;

namespace Stock.GUI.Reports
{
    public partial class PrinterStockImport : XtraReport
    {
        public PrinterStockImport(
            ArrayList list,
            string supplierId,
            string supplierName,
            double total,
            string orderImportId)
        {
            InitializeComponent();
            gridControl1.DataSource = list;
            xrLblSupplierID.Text = supplierId;
            xrLblSupplierName.Text = supplierName;
            xrLblOrderImportID.Text = orderImportId;
            xrLblTotal.Text = string.Format("{0:0,0} VNĐ", total);
        }

    }
}
