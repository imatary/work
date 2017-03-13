using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EducationSkills
{
    public static class ValidationHelper
    {
        public static bool IsNullOrEmptyControl(BaseEdit control)
        {
            if (string.IsNullOrEmpty(control.Text))
            {
                control.Properties.Appearance.BorderColor = Color.DarkRed;
                control.Focus();

                return false;
            }


            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        public static void SetDefaultControl(BaseEdit control)
        {
            control.Properties.Appearance.BorderColor = Color.LightGray;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        /// <param name="message"></param>
        public static void IsExitsValueMessageBox(BaseEdit control, string message)
        {
            control.Properties.Appearance.BorderColor = Color.DarkRed;
            control.SelectAll();
            MessageBox.Show(message, "Error info!", MessageBoxButtons.OK, MessageBoxIcon.Error);

            control.Focus();
        }

    }
}
