using LeetCode.Solutions;
using Xunit;

namespace CodeTest.LeetCode
{
    public class LengthOfLongestSubstringSolutionTest
    {
        [Theory]
        [InlineData("abcabcbb", 3)]
        [InlineData("bbbbb", 1)]
        [InlineData("pwwkew", 3)]
        public void GetLengthOfLongestSubstringTest(string s, int expectedResult)
        {
            var lengthOfLongestSubstringSolution = new LengthOfLongestSubstringSolution();
            Assert.Equal(expectedResult, lengthOfLongestSubstringSolution.GetLengthOfLongestSubstring(s));
        }
    }
}