using FluentAssertions;
using Xunit;

namespace CsdsLib.Tests
{
    public class StringExtensionsTests
    {
        [Theory]
        [InlineData("foo", "oof")]
        [InlineData("", null)]
        [InlineData(" ", null)]
        [InlineData("bubba gump", "pmug abbub")]
        [InlineData("A man, a plan, a canal: Panama.", ".amanaP :lanac a ,nalp a ,nam A")]
        public void Reverse_Reverses_String(string original, string reversed)
        {
            original.Reverse().Should().Be(reversed);
        }

        [Theory]
        [InlineData("", false)]
        [InlineData(" ", false)]
        [InlineData("a", true)]
        [InlineData("foof foof.", true)]
        [InlineData("bubba gump", true)]
        [InlineData("A man, a plan, a cat, a ham, a yak, a yam, a hat, a canal-Panama!", true)]

        public void IsPalindrome_Tests(string s, bool isPalindrome)
        {
            s.IsPalindrome().Should().Be(isPalindrome);
        }
    }
}