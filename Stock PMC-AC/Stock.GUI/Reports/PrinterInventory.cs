using System.Collections.Generic;
using DevExpress.XtraReports.UI;
using Stock.Services;

namespace Stock.GUI.Reports
{
    public partial class PrinterInventory : XtraReport
    {
        public PrinterInventory(IEnumerable<InventoryView> inventoryViews)
        {
            InitializeComponent();
            gridControl2.MainView = advBandedGridView3;
            gridControl2.DataSource = inventoryViews;
        }

    }
}
