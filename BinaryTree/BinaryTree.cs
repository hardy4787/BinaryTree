using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tree;

namespace BinaryTree
{
    public class BinaryTree<T> : IEnumerable<T> where T : IComparable<T>
    {
        public event EventTree Added;

        public delegate void EventTree(object sender, TreeEventArgs<T> e);

        private BinaryTreeNode<T> _root;

        public BinaryTree(T head)
        {
            if (head == null) throw new NullReferenceException();
            _root = new BinaryTreeNode<T>(head);
            if (_root != null)
                Count++;
        }

        public int Count { get; private set; }

        public void Add(T value)
        {
            if (_root == null) _root = new BinaryTreeNode<T>(value);
            else
                Add(_root, new BinaryTreeNode<T>(value));
            Count++;
            Added?.Invoke(this, new TreeEventArgs<T>(value, "An item has been added."));
        }

        private void Add(BinaryTreeNode<T> parent, BinaryTreeNode<T> child)
        {
            if (parent > child)
                if (parent.Left == null)
                {
                    parent.Left = child;
                }
                else
                    Add(parent.Left, child);
            else
                if (parent.Right == null)
            {
                parent.Right = child;
            }
            else
                Add(parent.Right, child);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return InOrderTraversal();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public IEnumerator<T> InOrderTraversal()
        {
            if (_root != null)
            {
                Stack<BinaryTreeNode<T>> stack = new Stack<BinaryTreeNode<T>>();
                BinaryTreeNode<T> current = _root;
                bool goLeftNext = true;
                stack.Push(current);
                while (stack.Count > 0)
                {
                    if (goLeftNext)
                    {
                        while (current.Left != null)
                        {
                            stack.Push(current);
                            current = current.Left;
                        }
                    }
                    yield return current.Value;
                    if (current.Right != null)
                    {
                        current = current.Right;
                        goLeftNext = true;
                    }
                    else
                    {
                        current = stack.Pop();
                        goLeftNext = false;
                    }
                }
            }
        }
        public IEnumerable<T> PreOrderTraversal()
        {
            if (_root != null)
            {
                Stack<BinaryTreeNode<T>> stack = new Stack<BinaryTreeNode<T>>();
                BinaryTreeNode<T> current = _root;
                bool goLeftNext = true;
                stack.Push(current);
                while (stack.Count > 0)
                {
                    if (goLeftNext)
                    {
                        while (current.Left != null)
                        {
                            yield return current.Value;
                            stack.Push(current);
                            current = current.Left;
                        }
                        yield return current.Value;
                    }
                    if (current.Right != null)
                    {
                        current = current.Right;
                        goLeftNext = true;
                    }
                    else
                    {
                        current = stack.Pop();
                        goLeftNext = false;
                    }
                }
            }
        }
    }
}
