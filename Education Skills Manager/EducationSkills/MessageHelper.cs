using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EducationSkills
{
    public static class MessageHelper
    {
        /// <summary>
        /// Error message
        /// </summary>
        /// <param name="message"></param>
        public static void ErrorMessageBox(string message)
        {
            MessageBox.Show(message, "Error info!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Success message
        /// </summary>
        /// <param name="message"></param>
        public static void SuccessMessageBox(string message)
        {
            MessageBox.Show(message, "Success!", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
