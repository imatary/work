using System.Windows.Forms;
using BarcodeShipping.GUI.Properties;
using DevExpress.XtraEditors;

namespace BarcodeShipping.GUI.Helper
{
    public class MessageBoxHelper
    {
        public static void ShowMessageBoxError(string title)
        {
            MessageBox.Show(title, Resources.MessageBoxErrorMessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        public static void ShowMessageBoxSuccess(string title)
        {
            MessageBox.Show(title, Resources.SuccessMessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowMessageBoxInfo(string title)
        {
            MessageBox.Show(title, Resources.InfoMessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowMessageBoxWaring(string title)
        {
            MessageBox.Show(title, Resources.WaringMessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Show waring chưa chọn id
        /// </summary>
        /// <param name="title"></param>
        public static void ShowMessageBoxEditWaringNotSelectId(string title)
        {
            MessageBox.Show($"Bạn chưa chọn {title} cần sửa!", Resources.WaringMessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        /// <summary>
        /// Show waring chưa chọn id cần xóa
        /// </summary>
        /// <param name="title"></param>
        public static void ShowMessageBoxDeleteWaringNotSelectId(string title)
        {
            MessageBox.Show($"Bạn chưa chọn {title} cần xóa!", Resources.MessageBoxErrorMessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Question);
        }
    }
}