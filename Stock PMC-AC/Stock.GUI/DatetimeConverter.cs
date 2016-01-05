using System;
using System.Globalization;

namespace Stock.GUI
{
    public class DatetimeConverter
    {
        public static DateTime? StringToDatetime(string dateValue)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(dateValue))
                {
                    return null;
                }

                if (dateValue.ToLower().IndexOf("am") > 0 | dateValue.ToLower().IndexOf("pm") > 0)
                {
                    return DateTime.ParseExact(dateValue, "dd/MM/yyyy h:mm tt", null);
                }
                return DateTime.ParseExact(dateValue, "dd/MM/yyyy hh:mm:ss", null);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static DateTime? StringToShortDate(string dateValue)
        {
            try
            {
                return DateTime.ParseExact(dateValue, "dd/MM/yyyy", null);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static string DatetimeToString(DateTime? dateValue)
        {
            try
            {
                if ((dateValue == null))
                {
                    return null;
                }

                return dateValue.Value.ToString("dd/MM/yyyy h:mm tt");
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static string DatetimeToShortDateString(DateTime? dateValue)
        {
            try
            {
                if ((dateValue == null))
                {
                    return null;
                }

                return dateValue.Value.ToString("dd/MM/yyyy");
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static string DatetimeToChartLabel(System.DateTime? dateValue)
        {
            try
            {
                if ((dateValue == null))
                {
                    return null;
                }
                dynamic year = dateValue.Value.Year.ToString().Substring(2, 2);
                dynamic month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(dateValue.Value.Month).Substring(0, 3);
                return month + "-" + year;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static bool IsDate(string dateStr)
        {
            if (string.IsNullOrWhiteSpace(dateStr))
            {
                return false;
            }
            if (StringToShortDate(dateStr) == null)
            {
                return false;
            }
            return true;
        } 
    }
}