using LeetCode.Solutions;
using Xunit;

namespace CodeTest.LeetCode
{
    public class ClimbStairsSolutionTests
    {
        [Theory]
        [InlineData(2, 2)]
        [InlineData(3, 3)]
        public void ClimbStairsTest(int n, int expected)
        {
            var climbStairsSolution = new ClimbStairsSolution();

            var result = climbStairsSolution.ClimbStairs(n);
            
            Assert.Equal(expected, result);
        }
    }
}