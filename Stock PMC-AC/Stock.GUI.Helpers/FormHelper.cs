using System.Windows.Forms;

namespace  Stock.GUI.Helpers
{
    public static class FormHelper
    {
        /// <summary>
        /// Open window form
        /// </summary>
        /// <param name="frm">XtraForm</param>
        public static void OpenWindowForm(DevExpress.XtraEditors.XtraForm frm)
        {
            frm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.WindowState = FormWindowState.Normal;
            frm.ShowDialog();
        }
    }
}
