namespace Problem02.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class Stack<T> : IAbstractStack<T>
    {
        private Node<T> _top;

        public Stack()
        {
            this.Count = 0;
        }

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            var current = this._top;

            while (current != null)
            {
                if (current.Element.Equals(item))
                {
                    return true;
                }

                current = current.Next;
            }

            return false;
        }

        public T Peek()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return this._top.Element;
        }

        public T Pop()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            var topItem = this._top.Element;
            var newTop = this._top.Next;

            this._top.Next = null;
            this._top = newTop;
            this.Count--;

            return topItem;
        }

        public void Push(T item)
        {
            var newNode = new Node<T>(item)
            {
                Element = item,
                Next = this._top
            };

            this._top = newNode;
            this.Count++;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = this._top;

            while (current != null)
            {
                yield return current.Element;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() 
            => this.GetEnumerator();
    }
}