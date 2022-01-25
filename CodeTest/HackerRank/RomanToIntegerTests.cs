using HackerRank.Solutions;
using Xunit;

namespace CodeTest.HackerRank
{
    public class RomanToIntegerTests
    {
        [Theory]
        [InlineData("III", 3)]
        [InlineData("IX", 9)]
        [InlineData("LVIII", 58)]
        [InlineData("MCMXCIV", 1994)]
        public void RomanToIntegerTest(string s, int expectedResult)
        {
            var romanToInteger = new RomanToIntegerSolution();
            Assert.Equal(expectedResult, romanToInteger.RomanToInteger(s));
        }
    }
}