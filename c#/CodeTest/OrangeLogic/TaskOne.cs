using System;

namespace CodeTest.OrangeLogic;

public class TaskOne
{
    [Fact]
    public void TaskOneTest()
    {
        var a = new[] { 1, 0, 1, 0, 1, 1 };
        var b = new[] { 1, 1, 0, 1, 1 };
        var c = new[] { 0, 1, 0 };
        var d = new[] { 1, 0, 1 };
        var e = new[] { 0, 1, 1, 0 };
        var solution = new Solution();
        Assert.Equal(1, solution.ReturnSolution(a));
        Assert.Equal(2, solution.ReturnSolution(b));
        Assert.Equal(0, solution.ReturnSolution(c));
        Assert.Equal(0, solution.ReturnSolution(d));
        Assert.Equal(2, solution.ReturnSolution(e));
    }

    private class Solution
    {
        //Time O(n), Space O(n)
        public int ReturnSolution(int[] a)
        {
            var tempStartWithOne = new int[a.Length];
            tempStartWithOne[0] = 1;
            var tempStartWithZero = new int[a.Length];
            tempStartWithZero[0] = 0;
            for (var i = 1; i < a.Length; i++)
            {
                tempStartWithOne[i] = tempStartWithOne[i - 1] == 0 ? 1 : 0;
                tempStartWithZero[i] = tempStartWithZero[i - 1] == 0 ? 1 : 0;
            }

            var compareWithTempStartWithOne = 0;
            var compareWithTempStartWithZero = 0;
            for (var i = 0; i < a.Length; i++)
            {
                if (tempStartWithOne[i] != a[i]) compareWithTempStartWithOne++;
                if (tempStartWithZero[i] != a[i]) compareWithTempStartWithZero++;
            }

            return Math.Min(compareWithTempStartWithOne, compareWithTempStartWithZero);
        }
    }
}