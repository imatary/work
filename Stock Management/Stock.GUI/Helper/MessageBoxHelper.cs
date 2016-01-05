using System.Windows.Forms;
using DevExpress.XtraEditors;
using Stock.GUI.Properties;

namespace Stock.GUI.Helper
{
    public class MessageBoxHelper
    {
        public static void ShowMessageBoxError(string title)
        {
            XtraMessageBox.Show(title, Resources.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="title"></param>
        public static void ShowMessageBoxSuccess(string title)
        {
            XtraMessageBox.Show(title, Resources.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowMessageBoxInfo(string title)
        {
            XtraMessageBox.Show(title, Resources.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Show waring chưa chọn id
        /// </summary>
        /// <param name="title"></param>
        public static void ShowMessageBoxEditWaringNotSelectId(string title)
        {
            XtraMessageBox.Show(string.Format("Bạn chưa chọn {0} cần sửa!", title), Resources.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        /// <summary>
        /// Show waring chưa chọn id cần xóa
        /// </summary>
        /// <param name="title"></param>
        public static void ShowMessageBoxDeleteWaringNotSelectId(string title)
        {
            XtraMessageBox.Show(string.Format("Bạn chưa chọn {0} cần xóa!", title), Resources.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Question);
        }
    }
}