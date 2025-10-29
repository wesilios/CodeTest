using System;
using System.Linq;

namespace CodeTest.PrefixSums;

public class PassingCars
{
    [Fact]
    public void Test()
    {
        var a = new[] { 0, 1, 0, 1, 1 };
        var carPairs = new[]
        {
            new[] { 0, 1 },
            new[] { 0, 3 },
            new[] { 0, 4 },
            new[] { 2, 3 },
            new[] { 2, 4 }
        };
        Assert.Equal(5, Solution(a, carPairs));
    }

    private int Solution(int[] a, int[][] carPairs)
    {
        var prefix = new PrefixSuffixSum();
        var prefixSum = prefix.PrefixSum(a);
        return carPairs.Sum(carPair =>
            prefix.CountTotal(prefixSum, carPair[0], carPair[1]));
    }
}

internal class PrefixSuffixSum
{
    public int[] PrefixSum(int[] a)
    {
        var result = new int[a.Length +1];
        result[0] = a[0];
        for (var i = 1; i < a.Length + 1; i++)
        {
            result[i] = result[i - 1] + a[i - 1];
        }

        return result;
    }

    public int[] SuffixSum(int[] a)
    {
        var result = new int[a.Length];
        result[^1] = a[^1];
        for (var i = a.Length - 2; i >= 0; i--)
        {
            result[i] = result[i + 1] + a[i +1];
        }

        return result;
    }

    public int CountTotal(int[] prefixSum, int x, int y)
    {
        if (x > y || x < 0 || x > prefixSum.Length - 1)
        {
            throw new InvalidOperationException();
        }

        return prefixSum[y + 1] - prefixSum[x];
    }
}