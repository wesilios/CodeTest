using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeTest.TimeComplexity;

public class TapeEquilibriumTests
{
    [Fact]
    public void TapeEquilibrium()
    {
        var a = new[] { 3, 1, 2, 4, 3 };
        Assert.Equal(1, Solution(a));
    }

    private int Solution(int[] a)
    {
        var result = new SortedSet<int>();
        var total = a.Sum();
        var x = 0;
        for (var i = 1; i < a.Length; i++)
        {
            x += a[i - 1];
            result.Add(Math.Abs(x - (total - x)));
        }

        return result.Min;
    }
}