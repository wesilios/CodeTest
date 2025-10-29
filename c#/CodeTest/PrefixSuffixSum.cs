using System;

namespace CodeTest;

public class PrefixSuffixSum
{
    [Fact]
    public void PrepareArray()
    {
        var a = new[] { 1, 3, 4, 2, 5, 7, 6 };
        var b = new[] { 2, 3, 7, 5, 1, 3, 9 };
        var prefix = PrefixSum(a);
        var suffix = SuffixSum(a);
        var totalCount = CountTotal(prefix, 3, 5);
        Assert.Equal(25, MushroomMoves(b, 4, 6));
    }

    private int[] PrefixSum(int[] a)
    {
        var result = new int[a.Length];
        result[0] = a[0];
        for (var i = 1; i < a.Length; i++)
        {
            result[i] = result[i - 1] + a[i];
        }

        return result;
    }

    private int[] SuffixSum(int[] a)
    {
        var result = new int[a.Length];
        result[^1] = a[^1];
        for (var i = a.Length - 2; i >= 0; i--)
        {
            result[i] = result[i + 1] + a[i];
        }

        return result;
    }

    private int CountTotal(int[] prefixSum, int x, int y)
    {
        if (x > y) return CountTotal(prefixSum, y, x);
        if (x < 0 || y < 0 || x > prefixSum.Length - 1 || y > prefixSum.Length - 1)
        {
            throw new InvalidOperationException();
        }

        return prefixSum[y + 1] - prefixSum[x];
    }

    private int MushroomMoves(int[] a, int spot, int moves)
    {
        var n = a.Length;
        if (spot < 0 || moves >= n)
        {
            throw new InvalidOperationException();
        }

        var result = 0;
        var prefix = PrefixSum(a);
        for (int i = 0; i < Math.Min(moves, spot) + 1; i++)
        {
            var leftPosition = spot - i;
            var rightPosition = Math.Min(n - 1, Math.Max(spot, spot + moves - 2 * i));
            result = Math.Max(result, CountTotal(prefix, leftPosition, rightPosition));
        }

        for (int i = 0; i < Math.Min(moves + 1, n - spot); i++)
        {
            var rightPosition = spot + i;
            var leftPosition = Math.Max(0, Math.Min(spot, spot - (moves - 2 * i)));
            result = Math.Max(result, CountTotal(prefix, leftPosition, rightPosition));
        }

        return result;
    }
}