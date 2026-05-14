namespace DynamicProgramming;

public class CoinProblemHowManyWays
{
    /// <summary>
    /// Calculates the number of ways to achieve the target sum using the given set of coins.
    /// Each coin can be used an unlimited number of times.
    /// </summary>
    /// <param name="coins">A list of integers representing the denominations of coins available.</param>
    /// <param name="target">The target sum to achieve using the coins.</param>
    /// <returns>The number of distinct ways the target sum can be achieved.</returns>
    public int FindHowManyWays(IReadOnlyList<int> coins, int target)
    {
        var memo = new Dictionary<int, int>
        {
            { 0, 1 }
        };
        for (var amount = 1; amount <= target; amount++)
        {
            memo.Add(amount, 0);
            
        }
        
        foreach (var coin in coins)
        {
            for (var amount = 1; amount <= target; amount++)
            {
                var remaining = amount - coin;
                if (remaining < 0) continue;
                memo[amount] += memo[remaining];
            }
        }

        return memo[target];
    }
}