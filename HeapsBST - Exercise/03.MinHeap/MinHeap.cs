using System.Xml.Schema;

namespace _03.MinHeap
{
    using System;
    using System.Collections.Generic;

    public class MinHeap<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        private List<T> _elements;

        public MinHeap()
        {
            this._elements = new List<T>();
        }

        public int Size => this._elements.Count;

        public T Dequeue()
        {
           this.ValidateIfEmpty();

           var result = this._elements[0];
           this._elements.RemoveAt(0);

           return result;
        }

        private void ValidateIfEmpty()
        {
            if (this.Size == 0)
            {
                throw new InvalidOperationException();
            }
        }

        public void Add(T element)
        {
            this._elements.Add(element);

            int startIndex = this.Size - 1;

            while (startIndex != 0 && 
                   this._elements[startIndex]
                       .CompareTo(this._elements[startIndex - 1]) == -1)
            {
                var temp = this._elements[startIndex - 1];
                this._elements[startIndex - 1] = this._elements[startIndex];
                this._elements[startIndex] = temp;

                startIndex--;
            }
        }

        public T Peek()
        {
            this.ValidateIfEmpty();
            return this._elements[0];
        }
    }
}
