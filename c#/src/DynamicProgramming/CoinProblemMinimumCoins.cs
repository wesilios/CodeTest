namespace DynamicProgramming;

public class CoinProblemMinimumCoins
{
    private readonly Dictionary<int, int> _memo = new();

    /// <summary>
    /// Given a set of coin value coins ={c1, c2, c3, ..., cn} and a target sum of money T,
    /// find the minimum number of coins required to make up the amount T.
    /// If it's not possible to make up the amount with the given coins, return -1.
    /// </summary>
    /// <param name="coins"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public int FindMinimumCoins(IReadOnlyList<int> coins, int target)
    {
        var result = -1;
        if (target <= 0) return 0;

        if (_memo.TryGetValue(target, out var minimumCoins)) return minimumCoins;

        foreach (var coin in coins)
        {
            var remaining = target - coin;
            if (remaining < 0) continue;
            var subResult = FindMinimumCoins(coins, remaining);
            if (subResult == -1) continue;
            result = result == -1 ? subResult + 1 : Math.Min(result, subResult + 1);
        }

        _memo.Add(target, result);

        return result;
    }

    /// <summary>
    /// Bottom-up dynamic programming approach to find minimum coins
    /// </summary>
    /// <param name="target"></param>
    /// <param name="coins"></param>
    /// <returns></returns>
    public int FindMinimumCoins(int target, IReadOnlyList<int> coins)
    {
        var memo = new Dictionary<int, int>
        {
            { 0, 0 }
        };

        for (var amount = 1; amount < target + 1; amount++)
        {
            foreach (var coin in coins)
            {
                var remaining = amount - coin;
                if (remaining < 0) continue;
                if (!memo.TryGetValue(remaining, out var remainingValue)) continue;

                var candidate = remainingValue + 1;
                if (!memo.TryGetValue(amount, out var currentValue) || candidate < currentValue)
                {
                    memo[amount] = candidate;
                }
            }
        }

        return memo.GetValueOrDefault(target, -1);
    }
}