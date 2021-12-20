namespace LinkedList
{   
    /// <summary>
    /// Node in my linked list 
    /// </summary>
    class ListNode
    {
        /// <summary>
        /// Pointer to next element
        /// </summary>
        public ListNode Next { get; set; }

        /// <summary>
        /// Value of current node 
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Create new node
        /// </summary>
        /// <param name="value">Node value</param>
        public ListNode(int value)
        {
            this.Value = value;
        }
    }
}
