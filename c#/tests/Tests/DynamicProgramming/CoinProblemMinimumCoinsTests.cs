using DynamicProgramming;

namespace Tests.DynamicProgramming;

public class CoinProblemMinimumCoinsTests
{
    [Theory]
    [InlineData("1,2,5,10,20,50,100,200,500", 1000, 2)] // Standard large values
    [InlineData("1,4,5", 13, 3)] // Greedy-failing (5+4+4)
    [InlineData("1,3,4", 6, 2)] // Greedy-failing (3+3)
    [InlineData("1,5,10,25", 30, 2)] // Multiple paths, min is 2
    [InlineData("2", 3, -1)] // Impossible case
    [InlineData("5,10,20", 4, -1)] // Target smaller than coins
    [InlineData("1,2,5", 0, 0)] // Target is zero
    [InlineData("1", 100, 100)] // Single small denomination
    public void FindCoinsTest(string coinString, int amount, int expected)
    {
        var coins = coinString.Split(',').Select(int.Parse).ToList();
        var result = new CoinProblemMinimumCoins().FindMinimumCoins(coins, amount);
        Assert.Equal(expected, result);
    }
    
    [Theory]
    [InlineData("1,2,5,10,20,50,100,200,500", 1000, 2)] // Standard large values
    [InlineData("1,4,5", 13, 3)] // Greedy-failing (5+4+4)
    [InlineData("1,3,4", 6, 2)] // Greedy-failing (3+3)
    [InlineData("1,5,10,25", 30, 2)] // Multiple paths, min is 2
    [InlineData("2", 3, -1)] // Impossible case
    [InlineData("5,10,20", 4, -1)] // Target smaller than coins
    [InlineData("1,2,5", 0, 0)] // Target is zero
    [InlineData("1", 100, 100)] // Single small denomination
    public void FindCoinsWithBottomUpTest(string coinString, int amount, int expected)
    {
        var coins = coinString.Split(',').Select(int.Parse).ToList();
        var result = new CoinProblemMinimumCoins().FindMinimumCoins(amount, coins);
        Assert.Equal(expected, result);
    }
}