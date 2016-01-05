using Stock.Services;

namespace Stock.GUI.Sys
{
    public partial class FormSysLog : DevExpress.XtraEditors.XtraForm
    {
        private readonly LogService _logService;
        public FormSysLog()
        {
            InitializeComponent();
            _logService=new LogService();
        }

        /// <summary>
        /// Danh sách nhật ký hệ thống
        /// </summary>
        private void LoadSysLog()
        {
            gridControl1.DataSource = _logService.GetLogs();
        }

        private void FormSysLog_Load(object sender, System.EventArgs e)
        {
            LoadSysLog();
        }

        private void barButtonItemRefesh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            LoadSysLog();
        }

        private void barButtonItemPrinter_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void barButtonItemClose_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Close();
        }

        
    }
}