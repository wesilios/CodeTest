using System.Collections.Generic;

namespace HackerRank.Solutions;

public class FibonacciNumberSolution
{
    private readonly Dictionary<int, long> _memoization = new Dictionary<int, long>();

    public long FindFibonacciNumber(int n)
    {
        if (_memoization.ContainsKey(n)) return _memoization[n];
        if (n == 0) return 0;
        if (n == 1) return 1;
        if (n == 2) return 1;
        _memoization.Add(n, FindFibonacciNumber(n - 1) + FindFibonacciNumber(n - 2));
        return _memoization[n];
    }
}