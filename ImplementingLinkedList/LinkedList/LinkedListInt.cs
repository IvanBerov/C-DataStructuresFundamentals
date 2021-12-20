using System;
using System.Collections;
using System.Collections.Generic;

namespace LinkedList
{
    /// <summary>
    /// Linked list of integers
    /// </summary>
    class LinkedListInt : IEnumerable<int>
    {
        /// <summary>
        /// First node of the list
        /// </summary>
        public ListNode First { get; set; }
        /// <summary>
        /// Last node of the list
        /// </summary>
        public ListNode Last { get; set; }
        /// <summary>
        /// Numbers of nodes of the list
        /// </summary>
        public int Count { get; private set; }
        /// <summary>
        /// Create empty linked list
        /// </summary>
        public LinkedListInt()
        {
            this.Count = 0;
        }
        /// <summary>
        /// Create linked list from collection
        /// </summary>
        /// <param name="collection">Collection of integers to add to the list</param>
        public LinkedListInt(IEnumerable<int> collection)
            : this()
        {
            foreach (var item in collection)
            {
                this.AddLast(item);
            }
        }
        /// <summary>
        /// Adds new node to the end of list
        /// </summary>
        /// <param name="value">value to add</param>
        public void AddLast(int value)
        {
            var newElement = new ListNode(value);

            if (Last == null)
            {
                First = newElement;
                Last = newElement;
            }
            else
            {
                Last.Next = newElement;
                Last = newElement;
            }

            Count++;
        }
        /// <summary>
        /// Adds new element to the beginning of the list
        /// </summary>
        /// <param name="value">value to add</param>
        public void AddFirst(int value)
        {
            var newElement = new ListNode(value);

            if (First == null)
            {
                First = newElement;
                Last = newElement;
            }
            else
            {
                newElement.Next = First; // First became second
                First = newElement;
            }

            Count++;
        }

        /// <summary>
        /// Add new node after given
        /// </summary>
        /// <param name="node">Node to insert after</param>
        /// <param name="value">value to insert</param>
        public void AddAfter(ListNode node, int value)
        {
            if (node == null)
            {
                throw new ArgumentNullException("Node can not be null!");
            }

            var newElement = new ListNode(value);
            newElement.Next = node.Next;
            node.Next = newElement;

            Count++;
        }

        /// <summary>
        /// Add Element before given node
        /// </summary>
        /// <param name="node">node to insert before</param>
        /// <param name="value">value to insert</param>
        public void AddBefore(ListNode node, int value)
        {
            if (node == null)
            {
                throw new ArgumentNullException("Node can not be null!");
            }

            var newElement = new ListNode(value);

            if (node == First)
            {
                newElement.Next = First;
                First = newElement;
            }
            else
            {
                var current = First;

                while (current != null)
                {
                    if (current.Next == node)
                    {
                        newElement.Next = node;
                        current.Next = newElement;
                        break;
                    }

                    current = current.Next;
                }
            }

            Count++;
        }

        /// <summary>
        /// Gets Enumerator for linked list
        /// </summary>
        /// <returns></returns>
        public IEnumerator<int> GetEnumerator()
        {
            ListNode currListNode = First;

            while (currListNode != null)
            {
                yield return currListNode.Value;

                currListNode = currListNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        /// <summary>
        /// Checks if value is in the list
        /// </summary>
        /// <param name="value">value to search for</param>
        /// <returns></returns>
        public bool Contains(int value)
        {
            bool result = false;

            var current = First;

            while (current != null)
            {
                if (current.Value == value)
                {
                    result = true;
                    break;
                }
                current = current.Next;
            }
            return result;
        }

        /// <summary>
        /// Find first node
        /// </summary>
        /// <param name="value">value to search for</param>
        /// <returns></returns>
        public ListNode Find(int value)
        {
            ListNode result = null;

            var current = First;

            while (current != null)
            {
                if (current.Value == value)
                {
                    result = current;
                    break;
                }
                current = current.Next;
            }

            return result;
        }

        /// <summary>
        /// Remove given node
        /// </summary>
        /// <param name="node">node to remove</param>
        public void Remove(ListNode node)
        {
            if (node == null)
            {
                throw new ArgumentException("Node can not be null!");
            }

            if (First == node)
            {
                First = First.Next;
            }
            else
            {
                var current = First;
                while (current != null)
                {
                    if (current.Next == node)
                    {
                        current.Next = node.Next;
                        break;
                    }

                    current = current.Next;
                }
            }

            Count--;
        }

        public void Remove(int value)
        {
            var node = Find(value);

            if (node != null)
            {
                Remove(node);
            }
        }

        public void RemoveFirst()
        {
            if (First != null)
            {
                if (First == Last)
                {
                    Last = null;
                }

                First = First.Next;
                Count--;
            }
        }

        public void RemoveLast()
        {
            if (Last != null)
            {
                if (Last == First)
                {
                    Last = First = null;
                }

                var current = First;

                while (current != null)
                {
                    if (current.Next == Last)
                    {
                        current.Next = null;
                        Last = current;
                    }

                    current = current.Next;
                }

                Count--;
            }
        }

        public void RemoveAll(int value)
        {
            var current = Find(value);

            while(current != null)
            {
                Remove(current);
                current = Find(value);
            }
        }
    }
}

