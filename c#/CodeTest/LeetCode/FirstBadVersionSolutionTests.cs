using LeetCode.Solutions;
using Xunit;

namespace CodeTest.LeetCode
{
    public class FirstBadVersionSolutionTests
    {
        [Theory]
        [InlineData(1000000, 5467, 5467)]
        [InlineData(1000000, 1, 1)]
        [InlineData(5, 4, 4)]
        [InlineData(2126753390, 1702766719, 1702766719)]
        [InlineData(1, 1, 1)]
        [InlineData(2, 2, 2)]
        public void FirstBadVersionTesT(int versions, int badVersion, int expected)
        {
            var firstBadVersionSolution = new FirstBadVersionSolution(badVersion);

            var result = firstBadVersionSolution.FirstBadVersion(versions);

            Assert.Equal(expected, result);
        }
    }
}