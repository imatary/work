using System;
using System.Linq;
using System.Windows.Forms;
using BarcodeShipping.Data;
using BarcodeShipping.Services;

namespace BarcodeShipping.GUI
{
    public partial class FormSearchDate : Form
    {
        private readonly IqcService _iqcService = new IqcService();
        public FormSearchDate()
        {
            InitializeComponent();
        }

        private void btnSearchPCB_Click(object sender, EventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            using (var context=new IQCDataEntities())
            {
                //gridControlData.DataSource = context.Database.SqlQuery<tbl_test_log>("SELECT * FROM [barcode_db].[dbo].[tbl_test_result]").ToList();
            }

            
            splashScreenManager1.CloseWaitForm();

        }
    }
}
