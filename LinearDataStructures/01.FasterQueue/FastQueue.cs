namespace Problem01.FasterQueue
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class FastQueue<T> : IAbstractQueue<T>
    {
        private Node<T> _head;
        private Node<T> _tail;

        public int Count { get; private set; }

        public bool Contains(T item)
        {
            var currItem = this._head;

            while (currItem != null)
            {
                if (currItem.Item.Equals(item))
                {
                    return true;
                }

                currItem = currItem.Next;
            }

            return false;
        }

        public T Dequeue()
        {
            this.EmptyOrNot();

            var currElement = this._head.Item;

            this._head = this._head.Next;

            this.Count--;

            return currElement;
        }

        public void Enqueue(T item)
        {
            var newNode = new Node<T>(item)
            {
                Item = item,
                Next = null
            };

            if (this._head == null)
            {
                this._head = newNode;
                this._tail = newNode;
            }
            else
            {
                this._tail.Next = newNode;
                this._tail = newNode;
            }

            this.Count++;
        }

        public T Peek()
        {
            this.EmptyOrNot();

            return this._head.Item;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var currElement = this._head;

            while (currElement != null)
            {
                yield return currElement.Item;
                currElement = currElement.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void EmptyOrNot()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }
        }
    }
}