using HackerRank.Solutions;

namespace Tests.HackerRank;

public class DiagonalDifferenceTests
{
    [Fact]
    public void DiagonalDifferenceTest()
    {
        var arr = new List<List<int>>
        {
            new() { 11, 2, 4 },
            new() { 4, 5, 6 },
            new() { 10, 8, -12 },
        };

        var diagonalDifference = new DiagonalDifferenceSolution();
        const int expectResult = 15;


        Assert.Equal(expectResult, diagonalDifference.FindDiagonalDifference(arr));
    }
}