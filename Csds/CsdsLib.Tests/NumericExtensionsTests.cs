using FluentAssertions;
using Xunit;

namespace CsdsLib.Tests
{
    public class NumericExtensionsTests
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(2, 1)]
        [InlineData(3, 2)]
        [InlineData(4, 3)]
        [InlineData(5, 5)]
        [InlineData(6, 8)]
        [InlineData(7, 13)]
        [InlineData(8, 21)]
        [InlineData(9, 34)]
        [InlineData(10, 55)]
        public void Fibbonacci_Tests(int n, int expected)
        {
            n.Fibbonacci().Should().Be(expected);
        }
    }
}