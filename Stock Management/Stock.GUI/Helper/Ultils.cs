using System.Windows.Forms;
using DevExpress.XtraEditors;
using Stock.GUI.Properties;

namespace Stock.GUI.Helper
{
    public class Ultils
    {
        public static void TextControlNotNull(TextEdit textEdit, string title)
        {
            textEdit.Properties.Appearance.BorderColor = System.Drawing.Color.Red;
            textEdit.Focus();
            XtraMessageBox.Show(string.Format("{0} không được bỏ trống!", title), Resources.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);  
        }

        public static void GridLookUpEditControlNotNull(GridLookUpEdit gridLookUpEdit, string title)
        {
            gridLookUpEdit.Properties.Appearance.BorderColor = System.Drawing.Color.Red;
            gridLookUpEdit.Focus();
            XtraMessageBox.Show(string.Format("Vui lòng chọn {0}!", title), Resources.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void SetColorErrorTextControl(TextEdit textEdit, string title)
        {
            textEdit.Properties.Appearance.BorderColor = System.Drawing.Color.Red;
            textEdit.Focus();
            XtraMessageBox.Show(title, Resources.MessageBoxTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void SetColorDefaultTextControl(TextEdit textEdit)
        {
            textEdit.Properties.Appearance.BorderColor = System.Drawing.Color.LightGray;
        }
    }
}