using System;
using LeetCode.Solutions;
using Xunit;

namespace CodeTest.LeetCode
{
    public class StrStrSolutionTests
    {
        [Theory]
        [InlineData("", "")]
        [InlineData("aaaaa", "bba")]
        [InlineData("aaaaa", "a")]
        [InlineData("hello", "ll")]
        [InlineData("heeill", "ll")]
        public void StrStrTest(string haystack, string needle)
        {
            var strStrSolution = new StrStrSolution();

            var result = strStrSolution.StrStr(haystack, needle);

            Assert.Equal(haystack.IndexOf(needle, StringComparison.InvariantCulture), result);
        }
    }
}