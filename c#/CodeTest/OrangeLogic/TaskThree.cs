using System.Collections.Generic;
using System.Linq;

namespace CodeTest.OrangeLogic;

public class TaskThree
{
    [Fact]
    public void Test()
    {
        var a = new[] { 10, 1, 3, 1, 2, 2, 1, 0, 4 };
        var b = new[] { 1, 5, 2, 4, 3, 3 };
        var c = new[] { 9, 9, 9, 9, 9 };
        var d = new[] { 9, 9, 9, 9, 9, 1, 17, 2, 16, 3, 15, 4, 14 };
        // Assert.Equal(3, Solution(a));
        // Assert.Equal(3, Solution(b));
        // Assert.Equal(2, Solution(c));
        Assert.Equal(6, Solution(d));
    }

    private int Solution(int[] a)
    {
        var totalMap = new SortedDictionary<int, int>();
        for (var i = 0; i < a.Length - 1; i++)
        {
            if (a[i] > a[i + 1]) continue;
            var total = a[i] + a[i + 1];
            if (i + 2 < a.Length && total == a[i+1] + a[i + 2])
            {
                i++;
            }
            if (totalMap.ContainsKey(total))
            {
                totalMap[total] += 1;
                continue;
            }

            totalMap.Add(total, 1);
        }

        return totalMap.Last().Value;
    }
}