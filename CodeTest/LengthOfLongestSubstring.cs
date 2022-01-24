using System;
using System.Numerics;
using Xunit;

namespace CodeTest
{
    public class LengthOfLongestSubstring
    {
        [Theory]
        [InlineData("abcabcbb", 3)]
        [InlineData("bbbbb", 1)]
        [InlineData("pwwkew", 3)]
        public void Test(string s, int expectedResult)
        {
            var solution = new Solution();
            Assert.Equal(expectedResult, solution.LengthOfLongestSubstring(s));
        }

        private class Solution
        {
            public int LengthOfLongestSubstring(string s)
            {
                var chars = new Vector<int>(-1);
                var left = 0;
                var right = 0;
                var result = 0;
                while (right < s.Length)
                {
                    var r = s[right];
                    var index = chars[r];
                    if (index != -1 && index >= left && index < right)
                    {
                        left = index + 1;
                    }

                    result = Math.Max(result, right - left + 1);
                    // chars[r] = s[right];
                    right++;
                }

                return result;
            }
        }
    }
}