using DevExpress.XtraEditors;
using System;
using System.Globalization;

namespace Lib.Forms
{
    public static class Ultils
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        public static int ConvertStringToInt(BaseEdit control)
        {
            int value = 0;
            if(!int.TryParse(control.Text, out value))
            {
                value = 0;
            }

            return value;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        /// <returns></returns>
        public static DateTime ConvertStringToDateTime(BaseEdit control)
        {
            DateTime value = DateTime.ParseExact(control.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
          
            return value;
        }
    }
}
