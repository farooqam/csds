using FluentAssertions;
using Xunit;

namespace CsdsLib.Tests
{
    public class TreeNodeShould
    {
        [Fact]
        public void When_Created_Set_Value()
        {
            var node = new TreeNode<int>(10);
            node.Value.Should().Be(10);
        }

        [Fact]
        public void When_Created_Set_Right_And_Left_To_Null()
        {
            var node = new TreeNode<int>(10);
            node.Left.Should().BeNull();
            node.Right.Should().BeNull();
        }
    }
}