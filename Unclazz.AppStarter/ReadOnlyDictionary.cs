using System;
using System.Collections;
using System.Collections.Generic;

namespace Unclazz.AppStarter
{
    sealed class ReadOnlyDictionary<T,U> : IDictionary<T,U>
    {
        readonly IDictionary<T, U> _dict;
        internal ReadOnlyDictionary(IDictionary<T, U> dict)
        {
            _dict = dict ?? throw new ArgumentNullException(nameof(dict));
        }

        public U this[T key] { get => _dict[key]; set => throw new NotImplementedException(); }

        public ICollection<T> Keys => _dict.Keys;

        public ICollection<U> Values => _dict.Values;

        public int Count => _dict.Count;

        public bool IsReadOnly => true;

        public void Add(T key, U value)
        {
            throw new NotImplementedException();
        }

        public void Add(KeyValuePair<T, U> item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(KeyValuePair<T, U> item)
        {
            return _dict.Contains(item);
        }

        public bool ContainsKey(T key)
        {
            return _dict.ContainsKey(key);
        }

        public void CopyTo(KeyValuePair<T, U>[] array, int arrayIndex)
        {
            _dict.CopyTo(array, arrayIndex);
        }

        public IEnumerator<KeyValuePair<T, U>> GetEnumerator()
        {
            return _dict.GetEnumerator();
        }

        public bool Remove(T key)
        {
            throw new NotImplementedException();
        }

        public bool Remove(KeyValuePair<T, U> item)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(T key, out U value)
        {
            return _dict.TryGetValue(key, out value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _dict.GetEnumerator();
        }
    }
}
