using System;
using System.Collections;
using System.Collections.Generic;

namespace LinkedList
{
    public class DoublyLinkedList<T> : IEnumerable<T>
    {
        private ListNode<T> head;

        private ListNode<T> tail;

        public T this[int index]    
        {
            get
            {
                T[] arr = this.ToArray();

                if (index < 0 || index >= arr.Length)
                {
                    throw new ArgumentException("Invalid index!", nameof(index));
                }

                return arr[index];
            }
        }

        public int Count { get; private set; }

        public void AddFirst(T element)
        {
            if (this.Count == 0)
            {
                this.head = this.tail = new ListNode<T>(element);
            }
            else
            {
                ListNode<T> newHead = new ListNode<T>(element);
                ListNode<T> oldHead = this.head;

                this.head = newHead;
                oldHead.PreviousNode = newHead;
                newHead.NextNode = oldHead;
            }

            this.Count++;
        }

        public void AddLast(T element)
        {
            if (this.Count == 0)
            {
                this.head = this.tail = new ListNode<T>(element);
            }
            else
            {
                ListNode<T> newTail = new ListNode<T>(element);
                ListNode<T> oldTail = this.tail;

                this.tail = newTail;
                oldTail.NextNode = newTail;
                newTail.PreviousNode = oldTail;
            }

            this.Count++;
        }

        public T RemoveFirst()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("List is empty!");
            }

            T removedElement = this.head.Value;

            if(this.Count == 1)
            {
                this.head = null;
                this.tail = null;
            }
            else
            {
                ListNode<T> newHead = this.head.NextNode;
                newHead.PreviousNode = null;
                this.head = newHead;
            }

            this.Count--;

            return removedElement;
        }

        public T RemoveLast()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("List is empty!");
            }

            T removedElement = this.tail.Value;

            if(this.Count == 1)
            {
                this.head = null;
                this.tail = null;
            }
            else
            {
                ListNode<T> newTail = this.tail.PreviousNode;
                newTail.NextNode = null;
                this.tail = newTail;
            }

            this.Count--;

            return removedElement;
        }

        public void ForEach(Action<T> action)
        {
            ListNode<T> currentElement = this.head;

            while (currentElement != null)
            {
                action(currentElement.Value);
                currentElement = currentElement.NextNode;
            }
        }

        public T[] ToArray()
        {
            T[] array = new T[this.Count];

            int count = 0;

            ListNode<T> currentElement = this.head;

            while (currentElement != null)
            {
                array[count++] = currentElement.Value;

                currentElement = currentElement.NextNode;
            }

            return array;
        }


        public IEnumerator<T> GetEnumerator() //loop logic
        {
            ListNode<T> currNode = this.head;

            while (currNode != null)
            {
                yield return currNode.Value;
                currNode = currNode.NextNode;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
