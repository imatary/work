using System;
using System.Collections.Generic;

namespace Umc
{
    public static class ArrayMethods
    {
        // Methods
        public static T[] Combine<T>(this T[] source, T[] other)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (other == null)
            {
                throw Error.ArgumentNull("other");
            }
            int num = source.Length + other.Length;
            if (num <= 0)
            {
                return new T[0];
            }
            T[] destinationArray = new T[source.Length + other.Length];
            if (source.Length > 0)
            {
                Array.Copy(source, 0, destinationArray, 0, source.Length);
            }
            if (other.Length > 0)
            {
                Array.Copy(other, 0, destinationArray, source.Length, other.Length);
            }
            return destinationArray;
        }

        public static TResult[] ConvertAll<TSource, TResult>(this TSource[] source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Length <= 0)
            {
                return new TResult[0];
            }
            TResult[] array = new TResult[source.Length];
            int index = 0;
            for (int i = 0; i < source.Length; i++)
            {
                TSource local = source[i];
                if (local is TResult)
                {
                    array[index] = (TResult)local;
                    index++;
                }
            }
            if (index < source.Length)
            {
                Array.Resize<TResult>(ref array, index);
            }
            return array;
        }

        public static TResult[] ConvertAll<TSource, TResult>(this TSource[] source, Converter<TSource, TResult> converter)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (converter == null)
            {
                throw Error.ArgumentNull("converter");
            }
            if (source.Length <= 0)
            {
                return new TResult[0];
            }
            TResult[] localArray = new TResult[source.Length];
            for (int i = 0; i < source.Length; i++)
            {
                TSource input = source[i];
                localArray[i] = converter(input);
            }
            return localArray;
        }

        public static TResult[] ConvertAll<TSource, TResult>(this TSource[] source, Predicate<TSource> match, Converter<TSource, TResult> converter)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (match == null)
            {
                throw Error.ArgumentNull("match");
            }
            if (converter == null)
            {
                throw Error.ArgumentNull("converter");
            }
            if (source.Length <= 0)
            {
                return new TResult[0];
            }
            TResult[] array = new TResult[source.Length];
            int index = 0;
            for (int i = 0; i < source.Length; i++)
            {
                TSource local = source[i];
                if (match(local))
                {
                    array[index] = converter(local);
                    index++;
                }
            }
            if (index < source.Length)
            {
                Array.Resize<TResult>(ref array, index);
            }
            return array;
        }

        public static T[] Different<T>(this T[] source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Length <= 0)
            {
                return new T[0];
            }
            Dictionary<T, object> dictionary = new Dictionary<T, object>();
            T[] array = new T[source.Length];
            int index = 0;
            for (int i = 0; i < source.Length; i++)
            {
                T key = source[i];
                if (!dictionary.ContainsKey(key))
                {
                    array[index] = key;
                    dictionary.Add(key, null);
                    index++;
                }
            }
            if (index < source.Length)
            {
                Array.Resize<T>(ref array, index);
            }
            return array;
        }

        public static bool Exists<T>(this T[] source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            return (source.Length > 0);
        }

        public static bool Exists<T>(this T[] source, Predicate<T> match)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (match == null)
            {
                throw Error.ArgumentNull("match");
            }
            if (source.Length > 0)
            {
                for (int i = 0; i < source.Length; i++)
                {
                    T local = source[i];
                    if (match(local))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static T Find<T>(this T[] source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Length <= 0)
            {
                return default(T);
            }
            return source[0];
        }

        public static T Find<T>(this T[] source, Predicate<T> match)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (match == null)
            {
                throw Error.ArgumentNull("match");
            }
            if (source.Length > 0)
            {
                for (int i = 0; i < source.Length; i++)
                {
                    T local = source[i];
                    if (match(local))
                    {
                        return local;
                    }
                }
            }
            return default(T);
        }

        public static T[] FindAll<T>(this T[] source, Predicate<T> match)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (match == null)
            {
                throw Error.ArgumentNull("match");
            }
            if (source.Length <= 0)
            {
                return new T[0];
            }
            T[] array = new T[source.Length];
            int index = 0;
            for (int i = 0; i < source.Length; i++)
            {
                T local = source[i];
                if (match(local))
                {
                    array[index] = local;
                    index++;
                }
            }
            if (index < source.Length)
            {
                Array.Resize<T>(ref array, index);
            }
            return array;
        }

        public static T[] MakeArray<T>(this T[] source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Length > 0)
            {
                T[] destinationArray = new T[source.Length];
                Array.Copy(source, 0, destinationArray, 0, source.Length);
                return destinationArray;
            }
            return new T[0];
        }

        public static Dictionary<TKey, TElement> MakeDictionary<TKey, TElement>(this TElement[] source, Func<TElement, TKey> keySelector)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (keySelector == null)
            {
                throw Error.ArgumentNull("keySelector");
            }
            if (source.Length <= 0)
            {
                return new Dictionary<TKey, TElement>();
            }
            Dictionary<TKey, TElement> dictionary = new Dictionary<TKey, TElement>();
            for (int i = 0; i < source.Length; i++)
            {
                TElement arg = source[i];
                TKey local2 = keySelector(arg);
                if (!local2.IsNull<TKey>() && !dictionary.ContainsKey(local2))
                {
                    dictionary.Add(local2, arg);
                }
            }
            return dictionary;
        }

        public static List<T> MakeList<T>(this T[] source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Length <= 0)
            {
                return new List<T>();
            }
            return new List<T>(source);
        }

        public static T[] SkipWith<T>(this T[] source, int count)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (count < 0)
            {
                throw Error.Argument("invalid skip count!");
            }
            if ((source.Length > 0) && (source.Length > count))
            {
                T[] destinationArray = new T[source.Length - count];
                Array.Copy(source, count, destinationArray, 0, source.Length - count);
                return destinationArray;
            }
            return new T[0];
        }

        public static T[] Sort<T>(this T[] source)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Length > 0)
            {
                Array.Sort<T>(source);
                return source;
            }
            return new T[0];
        }

        public static T[] SortBy<T>(this T[] source, params Comparison<T>[] comparisons)
        {
            Comparison<T> comparison2 = null;
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (source.Length <= 0)
            {
                return new T[0];
            }
            T[] array = new T[source.Length];
            for (int j = 0; j < source.Length; j++)
            {
                array[j] = source[j];
            }
            if ((comparisons != null) && (comparisons.Length > 0))
            {
                if (comparison2 == null)
                {
                    comparison2 = delegate(T t1, T t2)
                    {
                        int num = 0;
                        for (int k = 0; k < comparisons.Length; k++)
                        {
                            Comparison<T> comparison = comparisons[k];
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
                Array.Sort<T>(array, comparison);
            }
            return array;
        }

        public static T[] TakeWith<T>(this T[] source, int count)
        {
            if (source == null)
            {
                throw Error.ArgumentNull("source");
            }
            if (count <= 0)
            {
                throw Error.Argument("invalid take count!");
            }
            if ((count > 0) && (source.Length >= count))
            {
                T[] destinationArray = new T[count];
                Array.Copy(source, 0, destinationArray, 0, count);
                return destinationArray;
            }
            return new T[0];
        }
    }


}