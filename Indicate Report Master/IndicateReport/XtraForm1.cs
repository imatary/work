using System;
using System.Windows.Forms;
using IndicateReport.Data;
using IndicateReport.Services;

namespace IndicateReport
{
    public partial class XtraForm1 : DevExpress.XtraEditors.XtraForm
    {
        private readonly ReportMasterService _reportMasterService;
        public XtraForm1()
        {
            InitializeComponent();
            _reportMasterService = new ReportMasterService();
            
        }

        private void XtraForm1_Load(object sender, EventArgs e)
        {
            
            //MessageBox.Show(DateTime.Now.Hour +":"+DateTime.Now.Minute);
            
            
        }
    }
}