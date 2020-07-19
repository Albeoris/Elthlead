using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;

namespace Elthlead.Framework
{
    public class OrderedDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private readonly OrderedDictionary _dic = new OrderedDictionary();

        public TValue this[TKey key]
        {
            get => (TValue) _dic[key];
            set => _dic[key] = value;
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            _dic.Add(item.Key, item.Value);
        }

        public void Add(TKey key, TValue value)
        {
            _dic.Add(key, value);
        }

        public void Clear()
        {
            _dic.Clear();
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, Int32 arrayIndex)
        {
            throw new NotSupportedException();
        }

        public Int32 Count => _dic.Count;

        public Boolean IsReadOnly => false;

        public Boolean ContainsKey(TKey key)
        {
            return _dic.Contains(key);
        }

        public Boolean Remove(TKey key)
        {
            _dic.Remove(key);
            return true;
        }

        public Boolean TryGetValue(TKey key, out TValue value)
        {
            if (_dic.Contains(key))
            {
                value = this[key];
                return true;
            }

            value = default;
            return false;
        }

        Boolean ICollection<KeyValuePair<TKey, TValue>>.Contains(KeyValuePair<TKey, TValue> item)
        {
            throw new NotSupportedException();
        }

        Boolean ICollection<KeyValuePair<TKey, TValue>>.Remove(KeyValuePair<TKey, TValue> item)
        {
            throw new NotSupportedException();
        }

        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            foreach (DictionaryEntry entry in _dic)
                yield return new KeyValuePair<TKey, TValue>((TKey) entry.Key, (TValue) entry.Value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        ICollection<TKey> IDictionary<TKey, TValue>.Keys => throw new NotSupportedException("IDictionary<TKey, TValue>.Keys");
        ICollection<TValue> IDictionary<TKey, TValue>.Values => throw new NotSupportedException("IDictionary<TKey, TValue>.Values");

        public IEnumerable<TKey> Keys => this.Select(item => item.Key);
        public IEnumerable<TValue> Values => this.Select(item => item.Value);
    }
}