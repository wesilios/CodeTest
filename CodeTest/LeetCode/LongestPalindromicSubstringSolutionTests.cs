using HackerRank.Solutions;
using Xunit;

namespace CodeTest.LeetCode
{
    public class LongestPalindromicSubstringSolutionTests
    {
        [Theory]
        [InlineData("babad", "aba bab")]
        [InlineData("babbab", "babbab")]
        [InlineData("aaab", "aaa")]
        [InlineData("baa", "aa")]
        [InlineData("aaa", "aaa")]
        [InlineData("lfcwnnwcwfl", "cwnnwc")]
        [InlineData("a", "a")]
        [InlineData("ac", "a c")]
        [InlineData("eabcb", "bcb")]
        public void LongestPalindromeTest(string s, string expectedResults)
        {
            var longestPalindromicSubstringSolution = new LongestPalindromicSubstringSolution();

            var result = longestPalindromicSubstringSolution.LongestPalindrome(s);

            var expected = expectedResults.Split();
            
            Assert.Contains(result, expected);
        }
    }
}