using System.Collections.Generic;

namespace CodeTest.CountingElements;

public class PermCheckTests
{
    [Fact]
    public void PermCheck()
    {
        var c = new[] { 4, 1, 1, 1, 3 };
        var b = new[] { 4, 1, 2 };
        var d = new[] { 1, 1, 1 };
        var e = new[] { 1, 1, 2, 3, 2, 3, 4, 5, 6, 7 };
        var f = new[] { 1 };
        var g = new[] { 4, 1, 3, 2 };
        Assert.Equal(0, Solution(b));
        Assert.Equal(0, Solution(c));
        Assert.Equal(0, Solution(d));
        Assert.Equal(0, Solution(e));
        Assert.Equal(1, Solution(f));
        Assert.Equal(1, Solution(g));
    }

    private int Solution(int[] a)
    {
        switch (a.Length)
        {
            case 0:
                return 0;
            case 1 when a[0] == 1:
                return 1;
        }

        var numberMap = new HashSet<int>(a);
        for (var i = 1; i <= a.Length; i++)
        {
            numberMap.Add(i);
        }
            
        foreach(var t in a)
        {
            numberMap.Remove(t);
        }

        return numberMap.Count == 0 ? 1 : 0;
    }
}