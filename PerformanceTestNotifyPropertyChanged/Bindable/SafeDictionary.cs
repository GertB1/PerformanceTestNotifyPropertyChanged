namespace Performance.Test.NotifyPropertyChanged
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;

    /// <summary>
    /// SafeDictionary ensures that only one thread can change the dictionary at a time.
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    [Serializable]
    public class SafeDictionary<TKey, TValue> : ConcurrentDictionary<TKey, TValue>
    {
        public SafeDictionary() : base()
        {
        }

        public SafeDictionary(IEnumerable<KeyValuePair<TKey, TValue>> collection)
            : base(collection)
        {
        }

        public SafeDictionary(IEqualityComparer<TKey> comparer)
            : base(comparer)
        {
        }

        public SafeDictionary(IEnumerable<KeyValuePair<TKey, TValue>> collection, IEqualityComparer<TKey> comparer)
            : base(collection, comparer)
        {
        }

        public SafeDictionary(int concurrencyLevel, int capacity)
            : base(concurrencyLevel, capacity)
        {
        }

        public SafeDictionary(int concurrencyLevel, IEnumerable<KeyValuePair<TKey, TValue>> collection, IEqualityComparer<TKey> comparer)
            : base(concurrencyLevel, collection, comparer)
        {
        }

        public SafeDictionary(int concurrencyLevel, int capacity, IEqualityComparer<TKey> comparer)
            : base(concurrencyLevel, capacity, comparer)
        {
        }

        new public TValue this[TKey key]
        {
            get
            {
                TValue item = default(TValue);
                TryGetValue(key, out item);
                return item;
            }
            set
            {
                AddOrUpdate(key, value, (k, v) => value);
            }
        }

        public TValue Add(TKey key, TValue value)
        {
            return AddOrUpdate(key, value, (k, v) => value);
        }

        public bool Remove(TKey key)
        {
            TValue item = default(TValue);
            return TryRemove(key, out item);
        }

        public SafeDictionary<TKey, TValue> Clone()
        {
            SafeDictionary<TKey, TValue> clone = new SafeDictionary<TKey, TValue>();
            IEnumerator<KeyValuePair<TKey, TValue>> li = this.GetEnumerator();
            while (li.MoveNext())
            {
                clone.AddOrUpdate(li.Current.Key, li.Current.Value, (k, v) => li.Current.Value);
            }
            return clone;
        }
    }
}
