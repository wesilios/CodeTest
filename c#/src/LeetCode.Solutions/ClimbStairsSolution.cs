namespace LeetCode.Solutions;

public class ClimbStairsSolution
{
    /// <summary>
    /// Calculates the number of distinct ways to climb a staircase with a given number of steps,
    /// following the rule that you can take either 1 step or 2 steps at a time.
    /// </summary>
    /// <param name="n">The total number of steps in the staircase. Must be between 1 and 45, inclusive.</param>
    /// <returns>The number of distinct ways to climb the staircase.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the value of <paramref name="n"/> is less than 1 or greater than 45.</exception>
    public int ClimbStairsWithMemo(int n)
    {
        if (n <= 0 || n > 45)
        {
            throw new ArgumentOutOfRangeException(nameof(n), "n must be between 1 and 45.");
        }

        var memo = new Dictionary<int, int>()
        {
            { 1, 1 },
            { 2, 2 }
        };

        for (var i = 3; i <= n; i++)
        {
            memo.Add(i, memo[i - 1] + memo[i - 2]);
        }

        return memo[n];
    }

    /// <summary>
    /// Calculates the number of distinct ways to climb a staircase with a given number of steps,
    /// following the rule that you can take either 1 step or 2 steps at a time using an optimized approach.
    /// </summary>
    /// <param name="n">The total number of steps in the staircase. Must be between 1 and 45, inclusive.</param>
    /// <returns>The number of distinct ways to climb the staircase.</returns>
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the value of <paramref name="n"/> is less than 1 or greater than 45.</exception>
    public int ClimbStairsOptimization(int n)
    {
        switch (n)
        {
            case <= 0:
            case > 45:
                throw new ArgumentOutOfRangeException(nameof(n), "n must be between 1 and 45.");
            case 1:
                return 1;
            case 2:
                return 2;
        }

        var first = 1;
        var second = 2;
        var current = 0;
        
        for (var i = 3; i <= n; i++)
        {
            current = first + second;
            first = second;
            second = current;
        }

        return current;
    }
}