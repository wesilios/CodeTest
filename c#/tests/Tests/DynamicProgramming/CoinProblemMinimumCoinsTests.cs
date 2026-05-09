using DynamicProgramming;

namespace Tests.DynamicProgramming;

public class CoinProblemMinimumCoinsTests
{
    [Theory]
    [InlineData("1,2,5,10,20,50", 100, 0)]
    [InlineData("1,4,5", 13, 3)]
    public void FindCoinsTest(string coinString, int amount, int expected)
    {
        var coins = coinString.Split(',').Select(int.Parse).ToList();
        var result = new CoinProblemMinimumCoins().FindCoins(coins, amount);
        Assert.Equal(expected, result);
    }
}