using System;

namespace Umc
{
    public static class DateTimeRange
    {
        // Fields
        private static readonly DateTime _Max_Value_ = new DateTime(0x270f, 12, 0x1f, 0x17, 0x3b, 0x3b);
        private static readonly DateTime _Min_Value_ = new DateTime(0x76c, 1, 1, 0, 0, 0);

        // Properties
        public static DateTime MaxValue
        {
            get
            {
                return _Max_Value_;
            }
        }

        public static DateTime MinValue
        {
            get
            {
                return _Min_Value_;
            }
        }
    }

 

}