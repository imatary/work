using System.Windows.Forms;
using DevExpress.XtraEditors;
using OQCChecking.Properties;

namespace OQCChecking.Helper
{
    public class Ultils
    {
        public static void TextControlNotNull(TextEdit textEdit, string title)
        {
            textEdit.Properties.Appearance.BorderColor = System.Drawing.Color.Red; 
            MessageBox.Show(string.Format("{0} không được để trống!", title), Resources.MessageBoxErrorMessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            textEdit.Focus();
            textEdit.SelectAll();
        }

        public static void EditTextErrorMessage(TextEdit textEdit, string title)
        {
            textEdit.Properties.Appearance.BorderColor = System.Drawing.Color.Red;
            MessageBox.Show(string.Format("Error! {0}", title), Resources.MessageBoxErrorMessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            textEdit.Focus();
            textEdit.SelectAll();
        }

        public static void GridLookUpEditControlNotNull(GridLookUpEdit gridLookUpEdit, string title)
        {
            gridLookUpEdit.Properties.Appearance.BorderColor = System.Drawing.Color.Red;
            gridLookUpEdit.Focus();
            gridLookUpEdit.SelectAll();
            MessageBox.Show(string.Format("Vui lòng chọn {0}!", title), Resources.MessageBoxErrorMessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }


        public static void GridLookUpEditControlNoExits(GridLookUpEdit gridLookUpEdit, string title)
        {
            gridLookUpEdit.Properties.Appearance.BorderColor = System.Drawing.Color.Red;
            gridLookUpEdit.Focus();
            MessageBox.Show(string.Format("Error!\n{0}!", title), Resources.MessageBoxErrorMessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void GridLookUpEditNoMessage(GridLookUpEdit gridLookUpEdit)
        {
            gridLookUpEdit.Properties.Appearance.BorderColor = System.Drawing.Color.Red;
            gridLookUpEdit.Focus();
        }
        public static void EditTextErrorNoMessage(TextEdit textEdit)
        {
            textEdit.Properties.Appearance.BorderColor = System.Drawing.Color.Red;
            textEdit.Focus();
            textEdit.SelectAll();
        }

        public static void SetColorErrorTextControl(TextEdit textEdit, string title)
        {
            textEdit.Properties.Appearance.BorderColor = System.Drawing.Color.Red;
            textEdit.Focus();
            textEdit.SelectAll();
            MessageBox.Show(title, Resources.MessageBoxErrorMessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void SetColorDefaultTextControl(TextEdit textEdit)
        {
            textEdit.Properties.Appearance.BorderColor = System.Drawing.Color.LightGray;
        }
        public static void SetColorDefaultGridLookUpEdit(GridLookUpEdit gridLookUp)
        {
            gridLookUp.Properties.Appearance.BorderColor = System.Drawing.Color.LightGray;
        }
    }
}