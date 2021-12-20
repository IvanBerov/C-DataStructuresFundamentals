namespace Problem04.SinglyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class SinglyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> _head;
        private Node<T> _tail;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            var newNode = new Node<T>(item)
            {
                Element = item,
                Next = this._head
            };

            if (this._head == null)
            {
                this._head = newNode;
                this._tail = newNode;
            }
            else
            {
                this._head = newNode;
            }

            this.Count++;
        }

        public void AddLast(T item)
        {
            var newNode = new Node<T>(item)
            {
                Element = item,
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

        public T GetFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return this._head.Element;
        }

        public T GetLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            return this._tail.Element;
        }

        public T RemoveFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            var result = this._head.Element;

            this._head = _head.Next;
            this.Count--;

            return result;
        }

        public T RemoveLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException();
            }

            var current = this._head;
            var result = this._tail.Element;

            while (current.Next != null)
            {
                if (current.Next.Next == null)
                {
                    current.Next = null;
                    break;
                }

                current = current.Next;
            }

            this._tail = current;
            this.Count--;

            return result;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = this._head;
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