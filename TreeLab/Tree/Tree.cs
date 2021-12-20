using System.Linq;

namespace Tree
{
    using System;
    using System.Collections.Generic;

    public class Tree<T> : IAbstractTree<T>
    {
        private readonly List<Tree<T>> _children;

        private bool rootCheck;

        public Tree()
        {
        }

        public Tree(T value)
        {
            this.Value = value;
            this.Parent = null;
            this._children = new List<Tree<T>>();
        }

        public Tree(T value, params Tree<T>[] children)
            : this(value)
        {
            foreach (Tree<T> child in children)
            {
                child.Parent = this;
                this._children.Add(child);
            }

            //this._children = children.ToList();

            //children.ToList().ForEach(x=>{this._children.Add(x);});
        }

        public T Value { get; private set; }

        public Tree<T> Parent { get; private set; }

        public IReadOnlyCollection<Tree<T>> Children => this._children.AsReadOnly();

        public ICollection<T> OrderBfs()
        {
            if (rootCheck)
            {
                return new List<T>();
            }

            List<T> result = new List<T>();

            Queue<Tree<T>> trees = new Queue<Tree<T>>();

            trees.Enqueue(this); // root 

            while (trees.Count > 0)
            {
                var subTree = trees.Dequeue();

                result.Add(subTree.Value);

                foreach (var child in subTree.Children)
                {
                    trees.Enqueue(child);
                }
            }

            return result;
        }

        public ICollection<T> OrderDfs()
        {
            if (rootCheck)
            {
                return new List<T>();
            }

            return DFS(this);
        }

        private ICollection<T> DFS(Tree<T> root)
        {
            List<T> result = new List<T>();

            foreach (var child in root.Children)
            {
                result.AddRange(DFS(child));
            }

            result.Add(root.Value);

            return result;
        }

        public void DfsPrint(Tree<T> tree, int level)
        {
            Console.Write(new string(' ', level));

            Console.WriteLine(tree);

            Console.WriteLine();

            foreach (var child in tree.Children)
            {
                DfsPrint(child, level + 3);
            }
        }

        public void AddChild(T parentKey, Tree<T> child)
        {
            var searchedNode = this.FindBfs(parentKey);

            child.Parent = searchedNode;
            searchedNode._children.Add(child);
        }

        private Tree<T> FindBfs(T searchedKey)
        {
            var queue = new Queue<Tree<T>>();
            queue.Enqueue(this);

            while (queue.Count != 0)
            {
                var subTree = queue.Dequeue();
                if (subTree.Value.Equals(searchedKey))
                {
                    return subTree;
                }

                foreach (var child in subTree.Children)
                {
                    queue.Enqueue(child);
                }

            }

            throw new ArgumentNullException();
        }

        public void RemoveNode(T nodeKey)
        {
            var searchedNode = this.FindBfs(nodeKey);

            foreach (var child in searchedNode.Children)
            {
                child.Parent = null;
            }

            searchedNode._children.Clear();

            if (searchedNode.Parent == null)
            {
                this.rootCheck = true;
            }
            else
            {
                var parent = searchedNode.Parent;
                parent._children.Remove(searchedNode);
            }

            searchedNode.Value = default;
        }

        public void Swap(T firstKey, T secondKey)
        {
            var firstSearched = this.FindBfs(firstKey);
            var secondSearched = this.FindBfs(secondKey);

            this.CheckEmpty(firstSearched);
            this.CheckEmpty(secondSearched);

            var parentOne = firstSearched.Parent;
            var parentTwo = secondSearched.Parent;

            if (parentOne == null)
            {
                this.SwapRoot(secondSearched);
                return;
            }

            if (parentTwo == null)
            {
                this.SwapRoot(firstSearched);
                return;
            }

            var indexFirst = parentOne._children.IndexOf(firstSearched);
            var indexSecond = parentTwo._children.IndexOf(secondSearched);

            parentOne._children[indexFirst] = secondSearched;
            parentTwo._children[indexSecond] = firstSearched;
        }

        private void SwapRoot(Tree<T> node)
        {
            this.Value = node.Value;
            this._children.Clear();

            foreach (var child in node.Children)
            {
                this._children.Add(child);
            }
        }

        private void CheckEmpty(Tree<T> node)
        {
            if (node == null)
            {
                throw new ArgumentNullException();
            }
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
