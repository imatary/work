using System;
using System.Globalization;
using System.Text;

namespace Umc
{
    public static class StringMethods
    {
        // Fields
        private static readonly string[,] _Escaple_Strings_ = new string[,] { { @"\r", "\r" }, { @"\n", "\n" }, { @"\t", "\t" } };

        // Methods
        public static TResult ConvertTo<TResult>(this string value, Func<string, TResult> converter)
        {
            return value.ConvertTo<TResult>(converter, default(TResult));
        }

        public static TResult ConvertTo<TResult>(this string value, Func<string, TResult> converter, TResult defaultValue)
        {
            if (!string.IsNullOrEmpty(value) && (converter != null))
            {
                return converter(value);
            }
            return defaultValue;
        }

        public static bool ConvertToBoolean(this string value)
        {
            return value.ConvertToBoolean(bool.TrueString);
        }

        public static bool ConvertToBoolean(this string value, string trueString)
        {
            return (value == trueString);
        }

        public static byte ConvertToByte(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return 0;
            }
            return byte.Parse(value, CultureInfo.InvariantCulture);
        }

        public static char ConvertToChar(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return '\0';
            }
            return value[0];
        }

        public static DateTime ConvertToDateTime(this string value)
        {
            return value.ConvertToDateTime(DateTimeRange.MinValue);
        }

        public static DateTime ConvertToDateTime(this string value, DateTime defaultValue)
        {
            if (string.IsNullOrEmpty(value))
            {
                return defaultValue;
            }
            return DateTime.Parse(value, CultureInfo.InvariantCulture);
        }

        public static decimal ConvertToDecimal(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return 0M;
            }
            return decimal.Parse(value, CultureInfo.InvariantCulture);
        }

        public static double ConvertToDouble(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return 0.0;
            }
            return double.Parse(value, CultureInfo.InvariantCulture);
        }

        public static TEnum ConvertToEnum<TEnum>(this string value)
        {
            return value.ConvertToEnum<TEnum>(default(TEnum));
        }

        public static object ConvertToEnum(this string value, Type enumType)
        {
            if (enumType == null)
            {
                throw Error.ArgumentNull("enumType");
            }
            if (!typeof(Enum).IsAssignableFrom(enumType))
            {
                throw Error.Argument("invalid enum type!");
            }
            if (string.IsNullOrEmpty(value))
            {
                return 0;
            }
            return Enum.Parse(enumType, value, true);
        }

        public static TEnum ConvertToEnum<TEnum>(this string value, TEnum defaultValue)
        {
            if (!typeof(Enum).IsAssignableFrom(typeof(TEnum)))
            {
                throw Error.Argument("invalid enum type!");
            }
            if (!string.IsNullOrEmpty(value))
            {
                return (TEnum)Enum.Parse(typeof(TEnum), value, true);
            }
            return defaultValue;
        }

        public static Guid ConvertToGuid(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return Guid.Empty;
            }
            return new Guid(value);
        }

        public static short ConvertToInt16(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return 0;
            }
            return short.Parse(value, CultureInfo.InvariantCulture);
        }

        public static int ConvertToInt32(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return 0;
            }
            return int.Parse(value, CultureInfo.InvariantCulture);
        }

        public static long ConvertToInt64(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return 0L;
            }
            return long.Parse(value, CultureInfo.InvariantCulture);
        }

        public static object ConvertToObject(this string value, Type type)
        {
            return value.ConvertToObject(type, bool.TrueString);
        }

        public static object ConvertToObject(this string value, Type type, string trueString)
        {
            if (type == null)
            {
                throw Error.ArgumentNull("type");
            }
            if (typeof(Guid) == type)
            {
                return value.ConvertToGuid();
            }
            if (typeof(Enum).IsAssignableFrom(type))
            {
                return value.ConvertToEnum(type);
            }
            switch (Type.GetTypeCode(type))
            {
                case TypeCode.Boolean:
                    return value.ConvertToBoolean(trueString);

                case TypeCode.Char:
                    return value.ConvertToChar();

                case TypeCode.SByte:
                    return value.ConvertToSByte();

                case TypeCode.Byte:
                    return value.ConvertToByte();

                case TypeCode.Int16:
                    return value.ConvertToInt16();

                case TypeCode.UInt16:
                    return value.ConvertToUInt16();

                case TypeCode.Int32:
                    return value.ConvertToInt32();

                case TypeCode.UInt32:
                    return value.ConvertToUInt32();

                case TypeCode.Int64:
                    return value.ConvertToInt64();

                case TypeCode.UInt64:
                    return value.ConvertToUInt64();

                case TypeCode.Single:
                    return value.ConvertToSingle();

                case TypeCode.Double:
                    return value.ConvertToDouble();

                case TypeCode.Decimal:
                    return value.ConvertToDecimal();

                case TypeCode.DateTime:
                    return value.ConvertToDateTime();

                case TypeCode.String:
                    return value;
            }
            return null;
        }

        internal static sbyte ConvertToSByte(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return 0;
            }
            return sbyte.Parse(value, CultureInfo.InvariantCulture);
        }

        public static float ConvertToSingle(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return 0f;
            }
            return float.Parse(value, CultureInfo.InvariantCulture);
        }

        public static string ConvertToString(this object obj)
        {
            return obj.ConvertToString(bool.TrueString, bool.FalseString);
        }

        public static string ConvertToString(this object obj, string trueString, string falseString)
        {
            if (obj == null)
            {
                return string.Empty;
            }
            TypeCode typeCode = Type.GetTypeCode(obj.GetType());
            if (typeCode != TypeCode.Boolean)
            {
                if (typeCode == TypeCode.String)
                {
                    return (string)obj;
                }
                return obj.ToString();
            }
            if (!((bool)obj))
            {
                return falseString;
            }
            return trueString;
        }

        internal static ushort ConvertToUInt16(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return 0;
            }
            return ushort.Parse(value, CultureInfo.InvariantCulture);
        }

        internal static uint ConvertToUInt32(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return 0;
            }
            return uint.Parse(value, CultureInfo.InvariantCulture);
        }

        internal static ulong ConvertToUInt64(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return 0L;
            }
            return ulong.Parse(value, CultureInfo.InvariantCulture);
        }

        public static string Decrypt(this string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                byte[] bytes = Convert.FromBase64String(value);
                return Encoding.Unicode.GetString(bytes, 0, bytes.Length);
            }
            return string.Empty;
        }

        public static string Encrypt(this string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                return Convert.ToBase64String(Encoding.Unicode.GetBytes(value));
            }
            return string.Empty;
        }

        public static string FormatToString(this DateTime value, string format)
        {
            return value.FormatToString(format, DateTimeRange.MinValue);
        }

        public static string FormatToString(this decimal value, string format)
        {
            if (string.IsNullOrEmpty(format))
            {
                return value.ToString(CultureInfo.InvariantCulture);
            }
            return value.ToString(format, CultureInfo.InvariantCulture);
        }

        public static string FormatToString(this double value, string format)
        {
            if (string.IsNullOrEmpty(format))
            {
                return value.ToString(CultureInfo.InvariantCulture);
            }
            return value.ToString(format, CultureInfo.InvariantCulture);
        }

        public static string FormatToString(this short value, string format)
        {
            if (string.IsNullOrEmpty(format))
            {
                return value.ToString(CultureInfo.InvariantCulture);
            }
            return value.ToString(format, CultureInfo.InvariantCulture);
        }

        public static string FormatToString(this int value, string format)
        {
            if (string.IsNullOrEmpty(format))
            {
                return value.ToString(CultureInfo.InvariantCulture);
            }
            return value.ToString(format, CultureInfo.InvariantCulture);
        }

        public static string FormatToString(this long value, string format)
        {
            if (string.IsNullOrEmpty(format))
            {
                return value.ToString(CultureInfo.InvariantCulture);
            }
            return value.ToString(format, CultureInfo.InvariantCulture);
        }

        public static string FormatToString(this object obj, string format)
        {
            if (obj == null)
            {
                return string.Empty;
            }
            if (string.IsNullOrEmpty(format))
            {
                return obj.ToString();
            }
            return string.Format(format, obj);
        }

        public static string FormatToString(this float value, string format)
        {
            if (string.IsNullOrEmpty(format))
            {
                return value.ToString(CultureInfo.InvariantCulture);
            }
            return value.ToString(format, CultureInfo.InvariantCulture);
        }

        public static string FormatToString(this string value, params object[] args)
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }
            if ((args != null) && (args.Length > 0))
            {
                try
                {
                    return string.Format(value, args);
                }
                catch
                {
                }
            }
            return value;
        }

        internal static string FormatToString(this ushort value, string format)
        {
            if (string.IsNullOrEmpty(format))
            {
                return value.ToString(CultureInfo.InvariantCulture);
            }
            return value.ToString(format, CultureInfo.InvariantCulture);
        }

        internal static string FormatToString(this uint value, string format)
        {
            if (string.IsNullOrEmpty(format))
            {
                return value.ToString(CultureInfo.InvariantCulture);
            }
            return value.ToString(format, CultureInfo.InvariantCulture);
        }

        internal static string FormatToString(this ulong value, string format)
        {
            if (string.IsNullOrEmpty(format))
            {
                return value.ToString(CultureInfo.InvariantCulture);
            }
            return value.ToString(format, CultureInfo.InvariantCulture);
        }

        public static string FormatToString(this DateTime value, string format, DateTime minValue)
        {
            if (value <= minValue)
            {
                return string.Empty;
            }
            if (string.IsNullOrEmpty(format))
            {
                return value.ToString(CultureInfo.InvariantCulture);
            }
            return value.ToString(format, CultureInfo.InvariantCulture);
        }

        public static string Left(this string value, int count)
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }
            if (value.Length <= count)
            {
                return value;
            }
            return value.Substring(0, count);
        }

        public static bool Like(string value, string pattern)
        {
            if (string.IsNullOrEmpty(value) || string.IsNullOrEmpty(pattern))
            {
                return false;
            }
            pattern = pattern.Trim();
            string str = value.ToUpper();
            string str2 = pattern.ToUpper().TrimStart(new char[] { '%' }).TrimEnd(new char[] { '%' });
            if (pattern.StartsWith("%") && pattern.EndsWith("%"))
            {
                return str.Contains(str2);
            }
            if (pattern.StartsWith("%"))
            {
                return str.EndsWith(str2);
            }
            return str.StartsWith(str2);
        }

        public static string RemoveLeadZero(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }
            if (!value.ToCharArray().Exists<char>(t => !char.IsDigit(t)))
            {
                return long.Parse(value).ToString(CultureInfo.InvariantCulture);
            }
            return value;
        }

        public static string ReplaceEscapleChars(this string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }
            StringBuilder builder = new StringBuilder(value);
            for (int i = 0; i < _Escaple_Strings_.GetLength(0); i++)
            {
                builder.Replace(_Escaple_Strings_[i, 0], _Escaple_Strings_[i, 1]);
            }
            return builder.ToString();
        }

        public static string Right(this string value, int count)
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }
            if (value.Length <= count)
            {
                return value;
            }
            return value.Substring(value.Length - count, count);
        }

        public static string TrimEnd(this string value, int count)
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }
            if (value.Length <= count)
            {
                return value;
            }
            return value.Substring(0, value.Length - count);
        }

        public static string TrimStart(this string value, int count)
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }
            if (value.Length <= count)
            {
                return value;
            }
            return value.Substring(count, value.Length - count);
        }
    }
}