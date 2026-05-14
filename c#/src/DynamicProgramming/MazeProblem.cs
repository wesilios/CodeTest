namespace DynamicProgramming;

public class MazeProblem
{
    /// <summary>
    /// Calculates the number of unique ways a rabbit can move from the top-left corner to the bottom-right corner
    /// in an NxM grid, considering it can only move right or down.
    /// </summary>
    /// <param name="n">The number of rows in the grid.</param>
    /// <param name="m">The number of columns in the grid.</param>
    /// <returns>The total number of unique paths to reach the bottom-right corner of the grid.</returns>
    public int FindHowManyWaysRabbitCanMove(int n, int m)
    {
        if (n <= 0 || m <= 0) return 0;

        var memo = new int[n, m];

        for (var i = 0; i < n; i++)
        {
            memo[i, 0] = 1;
        }

        for (var j = 0; j < m; j++)
        {
            memo[0, j] = 1;
        }

        for (var i = 1; i < n; i++)
        {
            for (var j = 1; j < m; j++)
            {
                memo[i, j] = memo[i - 1, j] + memo[i, j - 1];
            }
        }

        return memo[n - 1, m - 1];
    }

    /// <summary>
    /// Calculates the number of unique ways a rabbit can move from the top-left corner to the bottom-right corner
    /// in an NxM grid, considering it can only move right or down.
    /// </summary>
    /// <param name="n">The number of rows in the grid.</param>
    /// <param name="m">The number of columns in the grid.</param>
    /// <returns>The total number of unique paths to reach the bottom-right corner of the grid.</returns>
    public int FindHowManyWaysRabbitCanMoveWithDictionary(int n, int m)
    {
        if (n <= 0 || m <= 0) return 0;

        var memo = new Dictionary<string, int>();

        for (var i = 1; i < n; i++)
        {
            for (var j = 1; j < m; j++)
            {
                memo.TryAdd($"{i}x{j}",
                    memo.GetValueOrDefault($"{i - 1}x{j}", 1) + memo.GetValueOrDefault($"{i}x{j - 1}", 1));
            }
        }

        var key = $"{(n - 1 < 1 ? 1 : n - 1)}x{(m - 1 < 1 ? 1 : m - 1)}";

        return memo.GetValueOrDefault(key, 1);
    }

    /// <summary>
    /// Calculates the number of unique ways a rabbit can move from the top-left corner to the bottom-right corner
    /// in an NxM grid, considering it can only move right or down. This method uses an optimized approach
    /// to minimize space complexity compared to traditional methods.
    /// </summary>
    /// <param name="n">The number of rows in the grid.</param>
    /// <param name="m">The number of columns in the grid.</param>
    /// <returns>The total number of unique paths to reach the bottom-right corner of the grid.</returns>
    public int FindHowManyWaysRabbitCanMoveOptimized(int n, int m)
    {
        if (n <= 0 || m <= 0) return 0;

        var memo = new int[m];

        Array.Fill(memo, 1);

        for (var i = 1; i < n; i++)
        {
            for (var j = 1; j < m; j++)
            {
                memo[j] += memo[j - 1];
            }
        }

        return memo[m - 1];
    }
}