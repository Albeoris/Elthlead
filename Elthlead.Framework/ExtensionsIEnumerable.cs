using System;
using System.Collections.Generic;

namespace Elthlead.Framework
{
    public static class ExtensionsIEnumerable
    {
        public static Dictionary<TKey, TValue> ToLastKeyDictionary<TKey, TValue>(this IEnumerable<TValue> list, Func<TValue, TKey> keySelector)
        {
            Dictionary<TKey, TValue> dic = new Dictionary<TKey, TValue>();
            foreach (var item in list)
                dic[keySelector(item)] = item;
            return dic;
        }
    }
}