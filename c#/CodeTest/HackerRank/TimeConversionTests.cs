using HackerRank.Solutions;
using Xunit;

namespace CodeTest.HackerRank
{
    public class TimeConversionTests
    {
        [Theory]
        [InlineData("07:00:00PM", "19:00:00")]
        [InlineData("12:00:00AM", "00:00:00")]
        public void TimeConversionTest(string s, string expectedResult)
        {
            var timeConversion = new TimeConversionSolution();
            Assert.Equal(expectedResult, timeConversion.ConvertTime(s));
        }
    }
}