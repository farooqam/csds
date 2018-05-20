using System.Diagnostics;

namespace CsdsLib
{
    [DebuggerDisplay("Value = {Value}")]

    public class TreeNode<TValue>
    {
        public TreeNode(TValue value)
        {
            Value = value;
            Left = null;
            Right = null;
        }

        public TreeNode<TValue> Left { get; set; }

        public TreeNode<TValue> Right { get; set; }

        public TValue Value { get; }
    }
}