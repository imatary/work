using System.Collections.Generic;

namespace Umc
{
    public static class EnumerableMethods
    {
        // Methods
        public static List<T> MakeList<T>(this IEnumerable<T> source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            return new List<T>(source);
        }
    }

 

}