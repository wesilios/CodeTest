using HackerRank.Solutions;
using Xunit;

namespace CodeTest.HackerRank
{
    public class AnagramStringTests
    {
        [Theory]
        [InlineData("aaabbb", 3)]
        [InlineData("ab", 1)]
        [InlineData("abc", -1)]
        [InlineData("mnop", 2)]
        [InlineData("xyyx", 0)]
        [InlineData("xaxbbbxx", 1)]
        [InlineData("fdhlvosfpafhalll", 5)]
        public void AnagramStringTest(string str, int expectedResult)
        {
            var solution = new AnagramStringSolution();
            Assert.Equal(expectedResult, solution.GetNumberSwapCharacterToMakeAnagramString(str));
        }
    }
}