using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using BarcodeShipping.Data;
using BarcodeShipping.Data.Repositories;

namespace BarcodeShipping.GUI
{
    public partial class ExportToExel : Form
    {
        private IRepository _repository;

        public IRepository Repository
        {
            get { return _repository ?? (_repository = new IqcRepository()); }
        }
        public ExportToExel()
        {
            InitializeComponent();
        }

        private void ExportToExel_Load(object sender, EventArgs e)
        {
            dateEditFrom.DateTime = DateTime.Now;
            dateEditTo.DateTime = DateTime.Now;
        }

        private void dateEditFrom_EditValueChanged(object sender, EventArgs e)
        {
            dateEditTo.Focus();
        }
        private void dateEditTo_EditValueChanged(object sender, EventArgs e)
        {
            btnSearch.Focus();
        }

        private void btnExportToExel_Click(object sender, EventArgs e)
        {
            var date = DateTime.Now;
            var saveFileDialog1 = new SaveFileDialog
            {
                FileName = string.Format("{0}-{1}-{2}", date.Day, date.Month, date.Year),
                Filter = "Exel|*.xls",
                Title = "Save exel file",
                OverwritePrompt = true, 
            };
            saveFileDialog1.ShowDialog();
            if (saveFileDialog1.FileName != "")
            {
                gridControlData.ExportToXls(saveFileDialog1.FileName);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            splashScreenManager1.ShowWaitForm();
            DateTime dateFrom = Convert.ToDateTime(dateEditFrom.Text);
            DateTime dateTo = Convert.ToDateTime(dateEditTo.Text);

            var shippings = Repository.GetAll<Shipping>().Where(s => s.DateCheck >= dateFrom.Date && s.DateCheck <= dateTo.Date).OrderBy(s=>s.Model).ToList();
            if (shippings.Count > 0)
            {
                gridControlData.DataSource = shippings;
                splashScreenManager1.CloseWaitForm();
            }
            else
            {
                splashScreenManager1.CloseWaitForm();
                MessageBox.Show("Not found");
            }
            
        }

        private void gridView1_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.Caption == @"#")
            {
                e.DisplayText = (e.ListSourceRowIndex + 1).ToString(CultureInfo.InvariantCulture);
            }
        }
    }
}
