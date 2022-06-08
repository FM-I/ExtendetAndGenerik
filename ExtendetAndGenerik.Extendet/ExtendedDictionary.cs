using System.Collections;

namespace ExtendetAndGenerik.Extendet
{
    public class ExtendedDictionary<T, U, V> : IEnumerable<Entry<T, U, V>>
    {
        private Entry<T, U, V>[] _entries = new Entry<T, U, V>[4];

        public int Count { get; private set; }

        public (U, V) this[T key]
        {
            get
            {
                return Get(key);
            }
            set
            {
                Add(key, value.Item1, value.Item2);
            }
        }

        public void Add(T key, U valueOne, V valueTwo)
        {
            if (Count == _entries.Length)
                Refill();

            var index = GetIndex(key);

            _entries[index] = new() { Key = key, ValueOne = valueOne, ValueTwo = valueTwo };

            ++Count;
        }

        private void Refill()
        {
            var entries = new Entry<T, U, V>[_entries.Length * 2];


            foreach (var entry in _entries)
            {
                var hash = entry.Key.GetHashCode();

                var index = hash % entries.Length;

                entries[index] = entry;
            }

            _entries = entries;
        }

        public (U, V) Get(T key)
        {
            var index = GetIndex(key);

            return (_entries[index].ValueOne, _entries[index].ValueTwo);
        }

        public bool TryGet(T key, out (U, V) entry)
        {
            entry = (default(U), default(V));

            try
            {
                var index = GetIndex(key);

                entry = (_entries[index].ValueOne, _entries[index].ValueTwo);

                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool TryGetValue(U valueOne, V valueTwo, out Entry<T,U,V> entry)
        {

            entry = null;

            foreach (var _entry in _entries)
            {
                if (_entry != null
                    && _entry.ValueOne.Equals(valueOne)
                    && _entry.ValueTwo.Equals(valueTwo))
                {
                    entry = _entry;
                    return true;
                }
            }


            return false;
        }

        public void Remove(T key)
        {
            var index = GetIndex(key);

            var entry = _entries[index];

            if (entry != null && _entries[index].Key.Equals(key))
                _entries[index] = null;
        }

        public IEnumerator<Entry<T, U, V>> GetEnumerator()
        {
            for (int i = 0; i < _entries.Length; i++)
            {
                if (_entries != null)
                    yield return _entries[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private int GetIndex(T Key)
        {
            var hash = Key.GetHashCode();

            var index = hash % _entries.Length;

            return index;
        }
    }

    public sealed class Entry<T, U, V>
    {
        public T Key { get; set; } 
        public U ValueOne { get; set; }
        public V ValueTwo { get; set; }

        public override string ToString()
        {
            return $"{Key}: {ValueOne}, {ValueTwo}";
        }
    }
}
