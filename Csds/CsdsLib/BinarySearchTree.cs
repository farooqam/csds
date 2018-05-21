using System;
using System.Diagnostics;

namespace CsdsLib
{
    public class BinarySearchTree<TValue> where TValue : IComparable<TValue>
    {
        [DebuggerDisplay("Root = {Root}")]
        public TreeNode<TValue> Root { get; private set; }

        public void Insert(TValue value)
        {
            var newNode = new TreeNode<TValue>(value);

            if (Root == null)
            {
                Root = newNode;
                return;
            }

            var current = Root;
            TreeNode<TValue> parent = null;
            var result = 0;

            while (current != null)
            {
                result = value.CompareTo(current.Value);

                if (result > 0)
                {
                    parent = current;
                    current = current.Right;
                }
                else if (result < 0)
                {
                    parent = current;
                    current = current.Left;
                }
                else
                {
                    return;
                }
            }

            // At this point current is null and parent refers to the leaf node.
            Debug.Assert(parent != null);
            result = value.CompareTo(parent.Value);
            Debug.Assert(result != 0);

            if (result > 0)
            {
                parent.Right = newNode;
            }
            else if (result < 0)
            {
                parent.Left = newNode;
            }
        }

        public void Traverse(TraversalMethod method, Action<TreeNode<TValue>> onVisitAction)
        {
            if (method == TraversalMethod.InOrder)
            {
                TraverseInOrder(Root, onVisitAction);
            }
            else if (method == TraversalMethod.PreOrder)
            {
                TraversePreOrder(Root, onVisitAction);
            }
            else if (method == TraversalMethod.PostOrder)
            {
                TraversePostOrder(Root, onVisitAction);
            }
        }

        private void TraverseInOrder(TreeNode<TValue> node, Action<TreeNode<TValue>> onVisitAction)
        {
            if (node == null)
            {
                return;
            }

            TraverseInOrder(node.Left, onVisitAction);
            onVisitAction?.Invoke(node);
            TraverseInOrder(node.Right, onVisitAction);
        }

        private void TraversePreOrder(TreeNode<TValue> node, Action<TreeNode<TValue>> onVisitAction)
        {
            if (node == null)
            {
                return;
            }

            onVisitAction?.Invoke(node);
            TraverseInOrder(node.Left, onVisitAction);
            TraverseInOrder(node.Right, onVisitAction);
        }

        private void TraversePostOrder(TreeNode<TValue> node, Action<TreeNode<TValue>> onVisitAction)
        {
            if (node == null)
            {
                return;
            }

            TraverseInOrder(node.Left, onVisitAction);
            TraverseInOrder(node.Right, onVisitAction);
            onVisitAction?.Invoke(node);
        }
    }
}