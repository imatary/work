using System;
using System.Linq;
using System.Windows.Forms;
using BarcodeShipping.GUI.Helper;
using BarcodeShipping.Services;

namespace BarcodeShipping.GUI
{
    public partial class FormSearchPCB : Form
    {
        private readonly IqcService _iqcService = new IqcService();
        public FormSearchPCB()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchPCB(txtSearchPCB.Text);
        }

        private void txtSearchPCB_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchPCB(txtSearchPCB.Text);
            }
            if (e.KeyCode == Keys.Tab)
            {
                SearchPCB(txtSearchPCB.Text);
            }
        }

        private void SearchPCB(string productionId)
        {
            if (string.IsNullOrEmpty(txtSearchPCB.Text))
            {
                Ultils.TextControlNotNull(txtSearchPCB, "Production ID");
            }
            else
            {
                splashScreenManager1.ShowWaitForm();
                var checkPcb = _iqcService.GetAllLogs().Where(l => l.ProductionID == productionId);
                if (checkPcb.Any())
                {
                    gridControlData.DataSource = checkPcb;
                    txtSearchPCB.Focus();
                    txtSearchPCB.SelectAll();
                    splashScreenManager1.CloseWaitForm();
                }
                else
                {
                    splashScreenManager1.CloseWaitForm();
                    MessageBoxHelper.ShowMessageBoxWaring($"Không tìm thấy PCB nào với Production ID [{productionId}]");
                    txtSearchPCB.Focus();
                    txtSearchPCB.SelectAll();
                    
                }
            }
        }

        private void FormSearchPCB_Load(object sender, EventArgs e)
        {
            txtSearchPCB.Focus();
        }
    }
}
