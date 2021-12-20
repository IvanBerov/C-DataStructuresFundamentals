namespace Problem03.ReversedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class ReversedList<T> : IAbstractList<T>
    {
        private const int DefaultCapacity = 4;

        private T[] _items;

        public ReversedList()
            : this(DefaultCapacity) { }

        public ReversedList(int capacity)
        {
            if (capacity < 0)
                throw new ArgumentOutOfRangeException(nameof(capacity));

            this._items = new T[capacity];
            this.Capacity = capacity;
        }

        public int Capacity { get; private set; }

        public T this[int index]
        {
            get
            {
                this.ValidateIndex(this.Count - index -1);
                return this._items[this.Count - index - 1];
            }
            set
            {
                this.ValidateIndex(index);
                this._items[index] = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            this.Grow();
            this._items[this.Count++] = item;
        }

        // O(n)
        private void Grow()
        {
            if (this.Count == this.Capacity)
            {
                var newSize = this.Capacity * 2;
                var newArray = new T[newSize];

                for (int i = 0; i < this.Count; i++)
                {
                    newArray[i] = this._items[i];
                }

                this._items = newArray;
                this.Capacity = newSize;
            }
        }

        public bool Contains(T item)
        {
            return this.IndexOf(item) >= 0;
        }

        public int IndexOf(T item)
        {
            for (var i = 0; i < this.Count; i++)
            {
                if ((item == null && this._items[i] == null) || this._items[i].Equals(item))
                {
                    return this.Count - i - 1;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            this.ValidateIndex(index);
            this.Grow();

            for (int i = this.Count; i > this.Count - index; i--)
            {
                this._items[i] = this._items[i - 1];
            }

            this._items[this.Count - index] = item;
            this.Count++;
        }

        public bool Remove(T item)
        {
            int index = 0;

            for (int i = 0; i < this.Count; i++)
            {
                if (item.Equals(this._items[i]))
                {
                    index = i;
                }
            }

            if (index == 0)
            {
                return false;
            }

            for (int i = index; i < this.Count - 1; i++)
            {
                this._items[i] = this._items[i + 1];
            }

            this.Count--;
            return true;
        }

        public void RemoveAt(int index)
        {
            this.ValidateIndex(index);

            for (int i = this.Count - index - 1; i < this.Count; i++)
            {
                this._items[i] = this._items[i + 1];
            }

            this.Count--;
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException();
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Count - 1; i >= 0; i--)
            {
                yield return this._items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}