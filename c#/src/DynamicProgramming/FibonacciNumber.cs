namespace DynamicProgramming;

public class FibonacciNumber
{
    private readonly Dictionary<int, long> _memoization = new();

    /// <summary>
    /// Computes the nth Fibonacci number using memoization to optimize performance.
    /// </summary>
    /// <param name="n">The position of the Fibonacci number to compute, where n is a non-negative integer.</param>
    /// <returns>The nth Fibonacci number as a long integer.</returns>
    public long FindFibonacciNumber(int n)
    {
        if (_memoization.ContainsKey(n)) return _memoization[n];
        if (n == 0) return 0;
        if (n <= 2) return 1;
        _memoization.Add(n, FindFibonacciNumber(n - 1) + FindFibonacciNumber(n - 2));
        return _memoization[n];
    }

    /// <summary>
    /// Bottom-up Calculates the nth Fibonacci number iteratively using a dictionary for memoization.
    /// </summary>
    /// <param name="n">The position of the Fibonacci number to compute, where n is a non-negative integer.</param>
    /// <returns>The nth Fibonacci number as a long integer.</returns>
    public long ComputeFibonacciNumberWithBottomUp(int n)
    {
        if (n == 0) return 0;
        var memoization = new Dictionary<int, long>();

        for (var i = 1; i <= n + 1; i++)
        {
            long result;
            if (i <= 2)
            {
                result = 1;
            }
            else
            {
                result = memoization[i - 1] + memoization[i - 2];
            }

            memoization.Add(i, result);
        }

        return memoization[n];
    }
}