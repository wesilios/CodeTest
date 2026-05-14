using DynamicProgramming;

namespace Tests.DynamicProgramming;

public class CoinProblemHowManyWaysTests
{
    [Theory]
    [InlineData("1,4,5", 5, 3)] // Standard: 5, 4+1, 1*5
    [InlineData("1,2,5", 5, 4)] // Standard: 5, 2+2+1, 2+1+1+1, 1*5
    [InlineData("1,2", 3, 2)] // Combination check: {1,1,1} and {1,2}
    [InlineData("2", 3, 0)] // Impossible sum
    [InlineData("1,2,5", 0, 1)] // Target zero (Base case)
    [InlineData("10", 10, 1)] // Target equals coin
    [InlineData("5,10,20", 2, 0)] // Target smaller than all coins
    [InlineData("1,2,5,10,20,50,100", 100, 4563)] // Large number of combinations
    [InlineData("3,5,7", 15, 3)] // Non-standard: {5,5,5}, {7,5,3}, {3,3,3,3,3}
    public void FindHowManyWaysTests(string coinString, int amount, int expected)
    {
        var coins = coinString.Split(',').Select(int.Parse).ToList();
        var result = new CoinProblemHowManyWays().FindHowManyWays(coins, amount);
        Assert.Equal(expected, result);
    }
}