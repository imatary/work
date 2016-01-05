using System;

namespace  Stock.GUI.Helpers
{
    public static class DateTimeHelper
    {
        /// <summary>
        /// Convert milliseconds to string
        /// </summary>
        /// <param name="milliseconds">Milliseconds</param>
        /// <param name="format">Format string</param>
        /// <returns></returns>
        public static string MilliSecondsToString(double milliseconds, string format)
        {
            TimeSpan t = TimeSpan.FromMilliseconds(milliseconds);

            return t.ToString(format);
        }

        /// <summary>
        /// Get start date of the specified month of a specified datetime value
        /// </summary>
        /// <param name="date">Specified datetime value</param>
        /// <returns></returns>
        public static DateTime GetStartDateOfMonth(DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
        }
    }
}
