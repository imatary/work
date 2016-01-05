using System;
using System.Collections.Generic;

namespace Umc
{
    public static class DictionaryMethods
    {
        // Fields
        private const int _MAX_COUNT = 0x3e8;
        private const int _RESERVED_COUNT = 100;

        // Methods
        public static TKey[] GetKeys<TKey, TValue>(this Dictionary<TKey, TValue> dictionary)
        {
            if (dictionary == null)
            {
                throw Error.ArgumentNull("dictionary");
            }
            if (dictionary.Count > 0)
            {
                TKey[] array = new TKey[dictionary.Count];
                dictionary.Keys.CopyTo(array, 0);
                return array;
            }
            return new TKey[0];
        }

        public static TValue[] GetValues<TKey, TValue>(this Dictionary<TKey, TValue> dictionary)
        {
            if (dictionary == null)
            {
                throw Error.ArgumentNull("dictionary");
            }
            if (dictionary.Count > 0)
            {
                TValue[] array = new TValue[dictionary.Count];
                dictionary.Values.CopyTo(array, 0);
                return array;
            }
            return new TValue[0];
        }

        public static TValue LoadValue<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, Func<TValue> valueSelector)
        {
            return dictionary.LoadValue<TKey, TValue>(key, valueSelector, null, true);
        }

        public static TValue LoadValue<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, Func<TValue> valueSelector, Func<TValue, bool> valueValidator)
        {
            return dictionary.LoadValue<TKey, TValue>(key, valueSelector, valueValidator, true);
        }

        public static TValue LoadValue<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, Func<TValue> valueSelector, Func<TValue, bool> valueValidator, bool triming)
        {
            TValue local;
            if (dictionary == null)
            {
                throw Error.ArgumentNull("dictionary");
            }
            if (key.IsNull<TKey>())
            {
                throw Error.ArgumentNull("key");
            }
            if (!dictionary.TryGetValue(key, out local) && (valueSelector != null))
            {
                local = valueSelector();
                if ((valueValidator != null) && !valueValidator(local))
                {
                    return local;
                }
                if (triming && (dictionary.Count >= 0x3e8))
                {
                    TrimCore<TKey, TValue>(dictionary);
                }
                dictionary.Add(key, local);
            }
            return local;
        }

        public static KeyValuePair<TKey, TValue>[] MakeArray<TKey, TValue>(this Dictionary<TKey, TValue> dictionary)
        {
            if (dictionary == null)
            {
                throw Error.ArgumentNull("dictionary");
            }
            if (dictionary.Count > 0)
            {
                KeyValuePair<TKey, TValue>[] array = new KeyValuePair<TKey, TValue>[dictionary.Count];
                dictionary.CopyTo(array, 0);
                return array;
            }
            return new KeyValuePair<TKey, TValue>[0];
        }

        public static IDictionary<TKey, TValue> Trim<TKey, TValue>(this Dictionary<TKey, TValue> dictionary)
        {
            if (dictionary == null)
            {
                throw Error.ArgumentNull("dictionary");
            }
            if (dictionary.Count >= 0x3e8)
            {
                TrimCore<TKey, TValue>(dictionary);
            }
            return dictionary;
        }

        private static void TrimCore<TKey, TValue>(Dictionary<TKey, TValue> dictionary)
        {
            int count = dictionary.Count;
            TKey[] array = new TKey[count];
            dictionary.Keys.CopyTo(array, 0);
            for (int i = 0; i < (count - 100); i++)
            {
                TKey key = array[i];
                dictionary.Remove(key);
            }
        }

        public static bool TryAdd<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, Func<TValue> valueSelector)
        {
            return dictionary.TryAdd<TKey, TValue>(key, valueSelector, null, true);
        }

        public static bool TryAdd<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, Func<TValue> valueSelector, Func<TValue, bool> valueValidator)
        {
            return dictionary.TryAdd<TKey, TValue>(key, valueSelector, valueValidator, true);
        }

        public static bool TryAdd<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, Func<TValue> valueSelector, Func<TValue, bool> valueValidator, bool triming)
        {
            if (dictionary == null)
            {
                throw Error.ArgumentNull("dictionary");
            }
            if (key.IsNull<TKey>())
            {
                throw Error.ArgumentNull("key");
            }
            if (valueSelector == null)
            {
                throw Error.ArgumentNull("valueSelector");
            }
            if (!dictionary.ContainsKey(key))
            {
                TValue arg = valueSelector();
                if ((valueValidator == null) || valueValidator(arg))
                {
                    if (triming && (dictionary.Count >= 0x3e8))
                    {
                        TrimCore<TKey, TValue>(dictionary);
                    }
                    dictionary.Add(key, arg);
                    return true;
                }
            }
            return false;
        }

        public static bool TryRemove<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key)
        {
            if (dictionary == null)
            {
                throw Error.ArgumentNull("dictionary");
            }
            if (key.IsNull<TKey>())
            {
                throw Error.ArgumentNull("key");
            }
            return ((dictionary.Count > 0) && dictionary.Remove(key));
        }

        public static bool TrySetValue<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, TValue value)
        {
            return dictionary.TrySetValue<TKey, TValue>(key, () => value, null);
        }

        public static bool TrySetValue<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, Func<TValue> valueSelector)
        {
            return dictionary.TrySetValue<TKey, TValue>(key, valueSelector, null);
        }

        public static bool TrySetValue<TKey, TValue>(this Dictionary<TKey, TValue> dictionary, TKey key, Func<TValue> valueSelector, Func<TValue, bool> valueValidator)
        {
            if (dictionary == null)
            {
                throw Error.ArgumentNull("dictionary");
            }
            if (key.IsNull<TKey>())
            {
                throw Error.ArgumentNull("key");
            }
            if (valueSelector == null)
            {
                throw Error.ArgumentNull("valueSelector");
            }
            TValue arg = valueSelector();
            if ((valueValidator != null) && !valueValidator(arg))
            {
                return false;
            }
            if (dictionary.ContainsKey(key))
            {
                dictionary[key] = arg;
            }
            else
            {
                dictionary.Add(key, arg);
            }
            return true;
        }
    }


}