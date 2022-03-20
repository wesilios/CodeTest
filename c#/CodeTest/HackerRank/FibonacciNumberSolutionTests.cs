using HackerRank.Solutions;
using Xunit;

namespace CodeTest.HackerRank
{
    public class FibonacciNumberSolutionTests
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(30, 832040)]
        [InlineData(50, 12586269025)]
        public void FibTest(int n, long expectedResult)
        {
            var fib = new FibonacciNumberSolution();
            Assert.Equal(expectedResult, fib.FindFibonacciNumber(n));
        }
    }
}