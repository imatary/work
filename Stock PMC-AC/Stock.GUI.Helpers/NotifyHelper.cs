using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Stock.GUI.Helpers
{
    public static class NotifyHelper
    {
        public static DialogResult ShowInsertError()
        {
            return XtraMessageBox.Show(Properties.Settings.Default.InsertErrorText, Properties.Settings.Default.InsertErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static DialogResult ShowUpdateError()
        {
            return XtraMessageBox.Show(Properties.Settings.Default.UpdateErrorText, Properties.Settings.Default.UpdateErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static DialogResult ShowDeleteError()
        {
            return XtraMessageBox.Show(Properties.Settings.Default.DeleteErrorText, Properties.Settings.Default.DeleteErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static DialogResult ShowDeleteConfirm()
        {
            return XtraMessageBox.Show(Properties.Settings.Default.DeleteConfirmText, Properties.Settings.Default.DeleteErrorCaption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        public static DialogResult ShowPrintError()
        {
            return XtraMessageBox.Show(Properties.Settings.Default.PrintErrorText, Properties.Settings.Default.PringErrorCaption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static DialogResult ShowError(string error, string caption)
        {
            return XtraMessageBox.Show(error, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static DialogResult ShowInfo(string info, string caption)
        {
            return XtraMessageBox.Show(info, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static DialogResult ShowWarning(string warning, string caption)
        {
            return XtraMessageBox.Show(warning, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
