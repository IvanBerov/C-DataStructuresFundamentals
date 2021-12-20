using System.Collections.Generic;

namespace _02.MaxHeap
{
    using System;

    public class MaxHeap<T> : IAbstractHeap<T>
        where T : IComparable<T>
    {
        private List<T> _elements;

        public MaxHeap()
        {
            this._elements = new List<T>();
        }

        public int Size => this._elements.Count;

        public void Add(T element)
        {
            this._elements.Add(element);
            this.HeapIfyUp();
        }

        private void HeapIfyUp()
        {
            int indexOfElement = this._elements.Count - 1;
            int parentIndex = this.GetParentIndex(indexOfElement);

            while (this.IndexValidator(indexOfElement) && this.IsGreaterThan(indexOfElement, parentIndex))
            {
                this.Swap(indexOfElement, parentIndex);

                indexOfElement = parentIndex;
                parentIndex = this.GetParentIndex(indexOfElement);
            }
        }

        private void Swap(int indexOfElement, int parenIndex)
        {
            var temp = this._elements[indexOfElement];
            this._elements[indexOfElement] = this._elements[parenIndex];
            this._elements[parenIndex] = temp;
        }

        private bool IndexValidator(int index)
        {
            return index > 0;
        }

        private int GetParentIndex(int childIndex)
        {
            return (childIndex - 1) / 2;
        }

        private bool IsGreaterThan(int childIndex, int parentIndex)
        {
            return this._elements[childIndex].CompareTo(this._elements[parentIndex]) > 0;
        }

        public T Peek()
        {
            return this._elements[0];
        }
    }
}
