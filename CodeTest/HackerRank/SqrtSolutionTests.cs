using HackerRank.Solutions;
using Xunit;

namespace CodeTest.HackerRank
{
    public class SqrtSolutionTests
    {
        [Theory]
        [InlineData(8, 2)]
        [InlineData(2, 1)]
        public void SqrtTest(int x, int expectedResult)
        {
            var sqrtSolution = new SqrtSolution();
            Assert.Equal(expectedResult, sqrtSolution.Sqrt(x));
        }
    }
}