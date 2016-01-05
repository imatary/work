using System;

namespace  Stock.GUI.Helpers
{
    public static class DateEditHelper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateEdit"></param>
        /// <param name="display"></param>
        /// <param name="edit"></param>
        /// <param name="mask"></param>
        public static void ConfigDateEdit(DevExpress.XtraEditors.DateEdit dateEdit, string display, string edit, string mask)
        {
            dateEdit.EditValue = DateTime.Now;
            dateEdit.Properties.DisplayFormat.FormatString = display;
            dateEdit.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            dateEdit.Properties.EditFormat.FormatString = edit;
            dateEdit.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            dateEdit.Properties.EditMask = mask;
        }
    }
}
