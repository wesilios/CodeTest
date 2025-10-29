using LeetCode.Solutions;

namespace CodeTest.LeetCode;

public class ValidPerfectSquareSolutionTests
{
    [Theory]
    [InlineData(16, true)]
    [InlineData(14, false)]
    [InlineData(1, true)]
    [InlineData(0, true)]
    public void PerfectSquareTest(int x, bool expected)
    {
        var validPerfectSquareSolution = new ValidPerfectSquareSolution();

        var result = validPerfectSquareSolution.PerfectSquare(x);
            
        Assert.Equal(expected, result);
    }
}