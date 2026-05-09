namespace DynamicProgramming;

public class CoinProblemMinimumCoins
{
    /// <summary>
    /// Given a set of coin value coins ={c1, c2, c3, ..., cn} and a target sum of money T,
    /// find the minimum number of coins required to make up the amount T.
    /// If it's not possible to make up the amount with the given coins, return -1.
    /// </summary>
    /// <param name="coins"></param>
    /// <param name="target"></param>
    /// <returns></returns>
    public int FindCoins(IReadOnlyList<int> coins, int target)
    {
        if (target <= 0) return 0;
        throw new NotImplementedException();
    }
}