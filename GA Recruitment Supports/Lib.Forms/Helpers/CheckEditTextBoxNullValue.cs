using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using System.Drawing;

namespace Lib.Forms.Helpers
{
    public static class CheckTextBoxNullValue
    {
        public static bool ValidationTextEditNullValue(TextEdit textEdit)
        {
            if (string.IsNullOrEmpty(textEdit.Text))
            {
                textEdit.Properties.Appearance.BorderColor = Color.Red;
                textEdit.Focus();
                textEdit.SelectAll();
                return false;
            }

            return true;
        }



        public static bool ValidationTextEditNullValueMessage(TextEdit textEdit, string messageTitle)
        {
            if (string.IsNullOrEmpty(textEdit.Text))
            {
                textEdit.Properties.Appearance.BorderColor = Color.Red;
                textEdit.Focus();
                textEdit.SelectAll();
                return false;
            }
            return true;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="textEdit"></param>
        public static void SetColorErrorTextControl(TextEdit textEdit)
        {
            textEdit.Properties.Appearance.BorderColor = Color.Red;
            textEdit.Focus();
            textEdit.SelectAll();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="textEdit"></param>
        public static void SetColorDefaultTextControl(TextEdit textEdit)
        {
            textEdit.Properties.Appearance.BorderColor = Color.LightGray;
        }

        /// <summary>
        /// Not good reset default
        /// </summary>
        /// <param name="textEdit"></param>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        public static bool ValidationTextEditNullValueWidthErrorProvider(TextEdit textEdit, string errorMessage)
        {
            if (string.IsNullOrEmpty(textEdit.Text))
            {
                DXErrorProvider dxErrorProvider = new DXErrorProvider();

                textEdit.Properties.Appearance.BorderColor = Color.Red;
                textEdit.Focus();

                dxErrorProvider.SetError(textEdit, errorMessage);
                return false;
            }

            return true;
        }

        public static void SetBackColorErrorMessage(LabelControl label, string message)
        {
            label.Text = message;
            label.BackColor = Color.Red;
            label.ForeColor = Color.Yellow;
        }

        public static void SetBackColorSuccessMessage(LabelControl label, string message)
        {
            label.Text = message;
            label.BackColor = Color.Green;
            label.ForeColor = Color.Yellow;
        }
    }
}
