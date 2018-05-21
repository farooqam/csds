using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace CsdsLib.Tests
{
    public class BinarySearchTreeShould
    {
        private readonly BinarySearchTree<int> _tree;

        public BinarySearchTreeShould()
        {
            _tree = new BinarySearchTree<int>();
        }

        [Fact]
        public void When_Created_Set_Root_To_Null()
        {
            _tree.Root.Should().BeNull();
        }

        [Fact]
        public void On_Insert_Set_Root_Node()
        {
            _tree.Insert(10);
            _tree.Root.Value.Should().Be(10);
        }

        [Fact]
        public void Insert_Nodes_Correctly()
        {
            _tree.Insert(7);
            _tree.Insert(3);
            _tree.Insert(11);
            _tree.Insert(1);
            _tree.Insert(5);
            _tree.Insert(10);
            _tree.Insert(15);
            _tree.Insert(4);

            var l1 = _tree.Root;
            l1.Left.Value.Should().Be(3);
            l1.Right.Value.Should().Be(11);

            var l2l = _tree.Root.Left;
            var l2r = _tree.Root.Right;

            l2l.Left.Value.Should().Be(1);
            l2l.Right.Value.Should().Be(5);
            l2l.Right.Left.Value.Should().Be(4);

            l2r.Left.Value.Should().Be(10);
            l2r.Right.Value.Should().Be(15);
        }

        [Fact]
        public void Perform_InOrder_Traversal()
        {
            var values = new[] {7, 3, 11, 1, 5, 10, 15, 4};

            foreach (var value in values)
            {
                _tree.Insert(value);
            }

            var traverseResult = new List<int>();

            _tree.Traverse(TraversalMethod.InOrder, n => traverseResult.Add(n.Value));

            values.OrderBy(v => v).SequenceEqual(traverseResult).Should().BeTrue();
        }

        [Fact]
        public void Perform_PreOrder_Traversal()
        {
            var values = new[] { 7, 3, 11, 1, 5, 10, 15, 4 };

            foreach (var value in values)
            {
                _tree.Insert(value);
            }

            var traverseResult = new List<int>();

            _tree.Traverse(TraversalMethod.PreOrder, n => traverseResult.Add(n.Value));

            traverseResult.SequenceEqual(new [] {7, 1, 3, 4, 5, 10, 11, 15}).Should().BeTrue();
        }

        [Fact]
        public void Perform_PostOrder_Traversal()
        {
            var values = new[] { 7, 3, 11, 1, 5, 10, 15, 4 };

            foreach (var value in values)
            {
                _tree.Insert(value);
            }

            var traverseResult = new List<int>();

            _tree.Traverse(TraversalMethod.PostOrder, n => traverseResult.Add(n.Value));

            traverseResult.SequenceEqual(new[] { 1, 3, 4, 5, 10, 11, 15, 7 }).Should().BeTrue();
        }
    }
}