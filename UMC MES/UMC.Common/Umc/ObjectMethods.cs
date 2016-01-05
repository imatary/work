using System;

namespace Umc
{
    public static class ObjectMethods
    {
        // Methods
        public static bool IsEquals<T>(this T obj, T other)
        {
            if (obj is ValueType)
            {
                return obj.Equals(other);
            }
            return (obj == other);
        }

        public static bool IsNull<T>(this T obj)
        {
            if (obj is ValueType)
            {
                return false;
            }
            return (obj == null);
        }
    }


}