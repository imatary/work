using DevExpress.Utils;
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
        /// <param name="errorProvider"></param>
        /// <param name="control"></param>
        public static void SetColorDefaultTextControl(DXErrorProvider errorProvider, BaseEdit control)
        {
            errorProvider.ClearErrors();
            control.Properties.Appearance.BorderColor = Color.LightGray;
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

        public static void ShowError(DXErrorProvider errorProvider, BaseEdit control, ToolTipController tipController, string errorMessage)
        {
            control.Properties.Appearance.BorderColor = Color.Red;
            control.Focus();
            control.SelectAll();
            errorProvider.SetError(control, errorMessage);
            ToolTipControllerShowEventArgs args = new ToolTipControllerShowEventArgs();
            args.ToolTipImage = DXErrorProvider.GetErrorIconInternal(ErrorType.Critical);
            args.ToolTip = control.ErrorText;
            args.SelectedControl = control;
            args.SuperTip = null; // here
            tipController.ShowHint(args, control.Parent.PointToScreen(control.Location));
        }

        public static void SetBackColorErrorMessage(LabelControl label, string message)
        {
            label.Text = message;
            label.Refresh();
            label.ResetForeColor();
            label.Appearance.BackColor = Color.Red;
            label.Appearance.ForeColor = Color.Yellow;
        }

        public static void SetBackColorSuccessMessage(LabelControl label, string message)
        {
            label.Text = message;
            label.Refresh();
            label.ResetForeColor();
            label.Appearance.BackColor = Color.Green;
            label.Appearance.ForeColor = Color.Yellow;
        }
    }
}
