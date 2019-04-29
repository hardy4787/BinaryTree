using BinaryTree;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree
{
    public class BinaryTreeNode<TNode> : IComparable<TNode> where TNode : IComparable<TNode>
    {
        public BinaryTreeNode(TNode Value)
        {
            this.Value = Value;
        }
        public TNode Value { get; private set; }
        public BinaryTreeNode<TNode> Left { get; set; }
        public BinaryTreeNode<TNode> Right { get; set; }
        int IComparable<TNode>.CompareTo(TNode Other) {
            return Value.CompareTo(Other);
        }
        public int CompareNode(BinaryTreeNode<TNode> OtherNode)
        {
            return Value.CompareTo(OtherNode.Value);
        }
        public static bool operator >(BinaryTreeNode<TNode> Left, BinaryTreeNode<TNode> Right)
        {
            if (Left.Value.CompareTo(Right.Value) == 1) return true;
            else if (Left.Value.CompareTo(Right.Value) == -1 || Left.Value.CompareTo(Right.Value) == 0) return false;
            else throw new ArgumentException();
        }
        public static bool operator <(BinaryTreeNode<TNode> Left, BinaryTreeNode<TNode> Right)
        {
            return (Right > Left);
        }
    }
}


