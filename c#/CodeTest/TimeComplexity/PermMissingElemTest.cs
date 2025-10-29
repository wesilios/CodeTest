using System.Collections.Generic;
using System.Linq;

namespace CodeTest.TimeComplexity;

public class PermMissingElemTest
{
    [Fact]
    public void PermMissingElem()
    {
        var a = new[] { 1, 2, 3, 5, 6 };
        var b = new[] { 1 };
        var d = new[] { 2, 3, 1, 5 };
        var e = new[] { 2, 3 };
        var f = new[] { 2, 1 };
        Assert.Equal(4, SolutionTwo(a));
        Assert.Equal(2, SolutionTwo(b));
        // Assert.Equal(1, Solution());
        Assert.Equal(4, SolutionTwo(d));
        Assert.Equal(1, SolutionTwo(e));
        Assert.Equal(3, SolutionTwo(f));
    }

    private int Solution(int[] a = null)
    {
        if (a == null) return 1;
        var x = a[0];
        var y = 1;
        for (var i = 1; i < a.Length; i++)
        {
            x ^= a[i];
        }

        for (var i = 2; i <= a.Length + 1; i++)
        {
            y ^= i;
        }

        return x ^ y;
    }

    private int SolutionTwo(int[] a)
    {
        var numberMap = new HashSet<int>();
        for (var i = 1; i <= a.Length + 1; i++)
        {
            numberMap.Add(i);
        }

        foreach (var t in a)
        {
            numberMap.Remove(t);
        }

        return numberMap.First();
    }
}