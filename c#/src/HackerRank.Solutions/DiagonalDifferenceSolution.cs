namespace HackerRank.Solutions;

public class DiagonalDifferenceSolution
{
    /// <summary>
    /// Calculates the absolute difference between the sums of the diagonals
    /// in a square matrix represented as a list of lists.
    /// </summary>
    /// <param name="arr">A square matrix where each element is a list of integers.</param>
    /// <returns>The absolute difference between the sums of the primary and secondary diagonals.</returns>
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