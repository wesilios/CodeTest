using LeetCode.Solutions;
using Xunit;

namespace CodeTest.LeetCode
{
    public class ArrangeCoinsSolutionTests
    {
        [Theory]
        [InlineData(5, 2)]
        [InlineData(8, 3)]
        [InlineData(2126753390, 65218)]
        public void ArrangeCoinsTest(int coins, int expected)
        {
            var arrangeCoinsSolution = new ArrangeCoinsSolution();

            Assert.Equal(expected, arrangeCoinsSolution.ArrangeCoins(coins));
        }
    }
}