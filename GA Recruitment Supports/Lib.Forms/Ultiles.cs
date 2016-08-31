using DevExpress.XtraEditors;
using System;
using System.Globalization;
using System.Threading;

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
            return DateTime.ParseExact(control.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }
        public static DateTime ConvertStringToDateTime(string value)
        {
            return DateTime.ParseExact(value, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ConvertToTitleCase(string s)
        {
            return Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(s.ToLower());
        }

        //private void btnDoichu_Click(object sender, EventArgs e)
        //{
        //    string hoten = this.txtTen.Text.Trim();
        //    if (radioButton1.Checked == true) txtKetqua.Text = hoten.ToLower();
        //    if (radioButton2.Checked == true) txtKetqua.Text = hoten.ToUpper();
        //    if (radioButton3.Checked == true)
        //    {
        //        // Theo: diendan.congdongcviet.com/showthread.php?t=87982
        //        string s = txtTen.Text.Trim();
        //        int i = 0;
        //        s = s.ToLower();
        //        while (i != s.Length)
        //        {
        //            if (s[i] == ' ' && s[i + 1] == ' ')
        //            {
        //                s = s.Remove(i + 1, 1);
        //                i = 0;
        //            }
        //            i++;
        //        }
        //        string p = s[0].ToString();
        //        p = p.ToUpper();
        //        s = s.Remove(0, 1);
        //        s = s.Insert(0, p);
        //        i = 0;
        //        while (i < s.Length)
        //        {
        //            if (s[i] == ' ')
        //            {
        //                p = s[i + 1].ToString();
        //                p = p.ToUpper();
        //                s = s.Remove(i + 1, 1);
        //                s = s.Insert(i + 1, p);
        //            }
        //            i++;
        //        }
        //        txtKetqua.Text = s;
        //    }
        //}
    }
}
