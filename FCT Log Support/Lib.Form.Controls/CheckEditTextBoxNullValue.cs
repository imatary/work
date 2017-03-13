using System;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.DXErrorProvider;
using System.Drawing;
using System.Windows.Forms;

namespace Lib.Form.Controls
{
    public static class CheckTextBoxNullValue
    {
        public static bool ValidationTextEditNullValue(BaseEdit control)
        {
            if (string.IsNullOrEmpty(control.Text))
            {
                control.Properties.Appearance.BorderColor = Color.DarkRed;
                control.Focus();
                control.SelectAll();
                return false;
            }

            return true;
        }
        public static bool ValidationTextEditNullValue(TextEdit textEdit)
        {
            if (string.IsNullOrEmpty(textEdit.Text))
            {
                textEdit.Properties.Appearance.BorderColor = Color.DarkRed;
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
                textEdit.Properties.Appearance.BorderColor = Color.DarkRed;
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
        public static void SetColorErrorTextControl(BaseEdit control)
        {
            control.Properties.Appearance.BorderColor = Color.DarkRed;
            control.ResetText();
            control.Focus();
            control.SelectAll();
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
        /// 
        /// </summary>
        /// <param name="control"></param>
        public static void SetColorDefaultTextControl(BaseEdit control)
        {
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

                textEdit.Properties.Appearance.BorderColor = Color.DarkRed;
                textEdit.Focus();

                dxErrorProvider.SetError(textEdit, errorMessage);
                return false;
            }

            return true;
        }

        public static bool ValidationTextEditNullValueWidthErrorProvider(DXErrorProvider errorProvider, TextEdit textEdit, string errorMessage)
        {
            if (string.IsNullOrEmpty(textEdit.Text))
            {
                textEdit.Properties.Appearance.BorderColor = Color.DarkRed;
                textEdit.Focus();

                errorProvider.SetError(textEdit, errorMessage);
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

        public static void ShowTooltipError(BaseEdit control, string toolTipTile, string message)
        {
            control.Properties.Appearance.BorderColor = Color.DarkRed;
            control.Focus();
            control.SelectAll();

            ToolTip buttonToolTip = new ToolTip
            {
                ToolTipTitle = toolTipTile,
                UseFading = true,
                UseAnimation = true,
                IsBalloon = true,
                Active = true,
                ShowAlways = true,
                AutoPopDelay = 5000,
                InitialDelay = 10,
                ReshowDelay = 500
            };


            buttonToolTip.SetToolTip(control, message);
        }

        public static void SetBackColorErrorMessage(LabelControl label, string message)
        {
            label.Text = message;
            label.Refresh();
            label.ResetForeColor();
            label.Appearance.BackColor = Color.DarkRed;
            label.Appearance.ForeColor = Color.White;
        }

        public static void SetColorErrorMessage(LabelControl label, string message)
        {
            label.Text = message;
            label.Refresh();
            label.ResetForeColor();
            label.BackColor = Color.White;
            label.ForeColor = Color.DarkRed;
        }
        /// <summary>
        /// BackColor = Color.Red;
        /// ForeColor = Color.White;
        /// </summary>
        /// <param name="label"></param>
        /// <param name="message"></param>
        public static void SetLabelBackColorErrorMessage(Label label, string message)
        {
            label.Text = message;
            label.Refresh();
            label.ResetForeColor();
            label.BackColor = Color.DarkRed;
            label.ForeColor = Color.White;
        }

        public static void SetColorErrorMessage(Label label, string message)
        {
            label.Text = message;
            label.Refresh();
            label.ResetForeColor();
            label.BackColor = Color.White;
            label.ForeColor = Color.DarkRed;
        }

        public static void SetBackColorSuccessMessage(LabelControl label, string message)
        {
            label.Text = message;
            label.Refresh();
            label.ResetForeColor();
            label.Appearance.BackColor = Color.Green;
            label.Appearance.ForeColor = Color.White;
        }
    }
}
