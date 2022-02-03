using LeetCode.Solutions;
using Xunit;

namespace CodeTest.LeetCode
{
    public class ValidPalindromeSolutionTests
    {
        [Theory]
        [InlineData("", true)]
        [InlineData("A man, a plan, a canal: Panama", true)]
        [InlineData("race a car", false)]
        public void IsValidPalindrome(string s, bool expected)
        {
            var validPalindromeSolution = new ValidPalindromeSolution();

            Assert.Equal(expected, validPalindromeSolution.IsValidPalindrome(s));
        }
    }
}