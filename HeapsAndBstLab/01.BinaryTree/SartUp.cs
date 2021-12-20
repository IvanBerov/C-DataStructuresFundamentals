using System;
using System.Collections.Generic;
using System.Text;

namespace _01.BinaryTree
{
    class SartUp
    {
        public static void Main(string[]args)
        {
            BinaryTree<int> root = new BinaryTree<int>(17,
                new BinaryTree<int>(9, new BinaryTree<int>(3, null, null),
                    new BinaryTree<int>(11, null, null)),
                new BinaryTree<int>(25, new BinaryTree<int>(20, null, null),
                    new BinaryTree<int>(31, null, null))
            );
        }
    }
}
