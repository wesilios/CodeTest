using System;
using System.Collections.Generic;

namespace HackerRank.Solutions;

public class DiagonalDifferenceSolution
{
    public int FindDiagonalDifference(List<List<int>> arr)
    {
        var leftDiagonal = 0;
        var rightDiagonal = 0;
        var i = 0;
        var j = arr.Count - 1;
        while (i < arr.Count && j >= 0)
        {
            rightDiagonal += arr[j][i];
            leftDiagonal += arr[i][i];
            i++;
            j--;
        }

        var abs = leftDiagonal - rightDiagonal;
        return Math.Abs(abs);
    }
}