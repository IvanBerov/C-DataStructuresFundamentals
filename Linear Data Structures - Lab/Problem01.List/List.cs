namespace Problem01.List
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class List<T> : IAbstractList<T>
    {
        private const int DEFAULT_CAPACITY = 4;
        private T[] arrayItems;

        public List()
            : this(DEFAULT_CAPACITY)
        {
        }

        public List(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity));
            }

            this.arrayItems = new T[capacity];
        }

        // indexer
        public T this[int index]
        {
            get
            {
                ValidateIndex(index);
                return this.arrayItems[index];
            }
            set
            {
                ValidateIndex(index);
                this.arrayItems[index] = value;
            }
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException(nameof(index));
            }

        }

        public int Count { get; private set; }

        //public void Add(T item)
        //{
        //    if (Count == this.arrayItems.Length)
        //    {
        //        T[] arr = new T[Count * 2];

        //        for (int i = 0; i < Count; i++)
        //        {
        //            arr[i] = this.arrayItems[i];
        //        }

        //        this.arrayItems = arr;
        //    }

        //    this.arrayItems[Count] = item;
        //    Count++;
        //}

        public void Add(T item)
        {
            this.GrowIfNecessary();

            this.arrayItems[this.Count++] = item;
        }

        private void GrowIfNecessary()
        {
            if (this.Count == this.arrayItems.Length)
            {
                this.arrayItems = this.Grow();
            }
        }

        private T[] Grow()
        {
            var newArray = new T[this.Count * 2];

            Array.Copy(this.arrayItems, newArray, this.arrayItems.Length);

            //for (int i = 0; i < this.arrayItems.Length; i++)
            //{
            //    newArray[i] = this.arrayItems[i];
            //}

            //this.arrayItems = newArray;

            return newArray;
        }

        public bool Contains(T item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (item.Equals(this.arrayItems[i]))
                {
                    return true;
                }
            }

            return false;
        }


        public int IndexOf(T item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (item.Equals(this.arrayItems[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, T item)
        {
            this.ValidateIndex(index);
            //if (index < 0 || index >= Count)
            //{
            //    throw new IndexOutOfRangeException(nameof(index));
            //}

            this.GrowIfNecessary();
            //if (Count == this.arrayItems.Length)
            //{
            //    T[] arr = new T[Count * 2];
            //    for (int i = 0; i < Count; i++)
            //    {
            //        arr[i] = this.arrayItems[i];
            //    }
            //    this.arrayItems = arr;
            //}

            for (var i = this.Count; i > index; i--)
            {
                this.arrayItems[i] = this.arrayItems[i - 1];
            }

            this.arrayItems[index] = item;
            this.Count++;
        }

        public bool Remove(T item)
        {
            int index = 0;

            for (int i = 0; i < this.Count; i++)
            {
                if (item.Equals(this.arrayItems[i]))
                {
                    index = i;
                }
            }

            if (index == 0)
            {
                return false;
            }

            for (int i = index; i < this.Count; i++)
            {
                this.arrayItems[i] = this.arrayItems[i + 1];
            }

            this.Count--;
            return true;
        }

        public void RemoveAt(int index)
        {
            this.ValidateIndex(index);

            for (int i = index; i < this.Count - 1; i++)
            {
                this.arrayItems[i] = this.arrayItems[i + 1];
            }

            this.arrayItems[this.Count - 1] = default;

            this.Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (var i = 0; i < this.Count; i++)
            {
                yield return this.arrayItems[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
            => this.GetEnumerator();
    }
}