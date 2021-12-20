namespace Problem02.DoublyLinkedList
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class DoublyLinkedList<T> : IAbstractLinkedList<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public int Count { get; private set; }

        public void AddFirst(T item)
        {
            var newNode = new Node<T>(item)
            {
                Item = item,
                Next = this.head
            };

            if (this.head == null)
            {
                this.head = newNode;
                this.tail = newNode;
            }
            else
            {
                this.head = newNode;
            }

            Count++;
        }

        public void AddLast(T item)
        {
            var newNode = new Node<T>(item)
            {
                Item = item,
                Next = null
            };

            if (this.head == null)
            {
                this.head = newNode;
                this.tail = newNode;
            }
            else
            {
                this.tail.Next = newNode;
                this.tail = newNode;
            }

            this.Count++;
        }

        public T GetFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            return this.head.Item;
        }

        public T GetLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            return this.tail.Item;
        }

        public T RemoveFirst()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            var result = this.head.Item;
            this.head = head.Next;
            Count--;

            return result;
        }

        public T RemoveLast()
        {
            if (Count == 0)
            {
                throw new InvalidOperationException();
            }

            var current = this.head;
            var result = this.tail.Item;

            while (current.Next != null)
            {
                if (current.Next.Next == null)
                {
                    current.Next = null;
                    break;
                }
                current = current.Next;
            }

            this.tail = current;
            Count--;

            return result;

        }

        public IEnumerator<T> GetEnumerator()
        {
            var currElement = this.head;

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
    }
}