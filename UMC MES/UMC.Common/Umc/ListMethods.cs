using System;
using System.Collections;
using System.Collections.Generic;

namespace Umc
{
    public static class ListMethods
{
    // Methods
    public static List<T> ConvertAll<T>(this IList list)
    {
        if (list == null)
        {
            throw Error.ArgumentNull("list");
        }
        List<T> list2 = new List<T>();
        for (int i = 0; i < list.Count; i++)
        {
            object obj2 = list[i];
            if (obj2 is T)
            {
                list2.Add((T) obj2);
            }
        }
        return list2;
    }

    public static List<T> Different<T>(this List<T> list)
    {
        if (list == null)
        {
            throw Error.ArgumentNull("list");
        }
        Dictionary<T, object> dictionary = new Dictionary<T, object>();
        List<T> list2 = new List<T>();
        for (int i = 0; i < list.Count; i++)
        {
            T key = list[i];
            if (!dictionary.ContainsKey(key))
            {
                dictionary.Add(key, null);
                list2.Add(key);
            }
        }
        return list2;
    }

    public static T Find<T>(this List<T> list)
    {
        if (list == null)
        {
            throw Error.ArgumentNull("list");
        }
        if (list.Count <= 0)
        {
            return default(T);
        }
        return list[0];
    }

    public static Dictionary<TKey, TElement> MakeDictionary<TKey, TElement>(this List<TElement> list, Func<TElement, TKey> keySelector)
    {
        if (list == null)
        {
            throw Error.ArgumentNull("list");
        }
        if (keySelector == null)
        {
            throw Error.ArgumentNull("keySelector");
        }
        if (list.Count <= 0)
        {
            return new Dictionary<TKey, TElement>();
        }
        Dictionary<TKey, TElement> dictionary = new Dictionary<TKey, TElement>();
        for (int i = 0; i < list.Count; i++)
        {
            TElement arg = list[i];
            TKey local2 = keySelector(arg);
            if (!local2.IsNull<TKey>() && !dictionary.ContainsKey(local2))
            {
                dictionary.Add(local2, arg);
            }
        }
        return dictionary;
    }

    public static List<T> MakeList<T>(this List<T> list)
    {
        if (list == null)
        {
            throw Error.ArgumentNull("list");
        }
        if (list.Count > 0)
        {
            return new List<T>(list);
        }
        return new List<T>();
    }

    public static List<T> SkipWith<T>(this List<T> list, int count)
    {
        if (list == null)
        {
            throw Error.ArgumentNull("source");
        }
        if (count < 0)
        {
            throw Error.Argument("invalid skip count!");
        }
        if (list.Count > count)
        {
            return list.GetRange(count, list.Count - count);
        }
        return new List<T>();
    }

    public static List<T> SortBy<T>(this List<T> list, params Comparison<T>[] comparisons)
    {
        Comparison<T> comparison2 = null;
        if (list == null)
        {
            throw Error.ArgumentNull("list");
        }
        if (list.Count <= 0)
        {
            return new List<T>();
        }
        List<T> list2 = new List<T>(list);
        if ((comparisons != null) && (comparisons.Length > 0))
        {
            if (comparison2 == null)
            {
                comparison2 = delegate (T t1, T t2) {
                    int num = 0;
                    for (int j = 0; j < comparisons.Length; j++)
                    {
                        Comparison<T> comparison = comparisons[j];
                        num = comparison(t1, t2);
                        if (num != 0)
                        {
                            return num;
                        }
                    }
                    return num;
                };
            }
            Comparison<T> comparison = comparison2;
            list2.Sort(comparison);
        }
        return list2;
    }

    public static List<T> TakeWith<T>(this List<T> list, int count)
    {
        if (list == null)
        {
            throw Error.ArgumentNull("source");
        }
        if (count <= 0)
        {
            throw Error.Argument("invalid take count!");
        }
        if (count <= 0)
        {
            return new List<T>();
        }
        if (list.Count >= count)
        {
            return list.GetRange(0, count);
        }
        return list;
    }
}

}