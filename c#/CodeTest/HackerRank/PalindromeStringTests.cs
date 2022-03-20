using HackerRank.Solutions;
using Xunit;

namespace CodeTest.HackerRank
{
    public class PalindromeStringTests
    {
        [Theory]
        [InlineData("aaab", 3)]
        [InlineData("baa", 0)]
        [InlineData("aaa", -1)]
        [InlineData("lfcwnnwcwfl", 8)]
        public void PalindromeStringTest(string str, int expectedResult)
        {
            var palindromeString = new PalindromeStringSolution();
            Assert.Equal(expectedResult, palindromeString.FindPalindromeIndex(str));
        }
    }
}