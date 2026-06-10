using LeetCode.Solutions;

namespace Tests.LeetCode;

public class ClimbStairsSolutionTests
{
    [Theory]
    [InlineData(1, 1)]
    [InlineData(2, 2)]
    [InlineData(3, 3)]
    [InlineData(4, 5)]
    [InlineData(5, 8)]
    [InlineData(45, 1836311903)]
    public void ClimbStairsWithMemo_SuccessCases(int n, int expected)
    {
        var climbStairsSolution = new ClimbStairsSolution();

        var result = climbStairsSolution.ClimbStairsWithMemo(n);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    [InlineData(46)]
    public void ClimbStairsWithMemo_ThrowsException_WhenInputIsInvalid(int n)
    {
        var climbStairsSolution = new ClimbStairsSolution();

        Assert.Throws<ArgumentOutOfRangeException>(() => climbStairsSolution.ClimbStairsWithMemo(n));
    }

    [Theory]
    [InlineData(1, 1)]
    [InlineData(2, 2)]
    [InlineData(3, 3)]
    [InlineData(4, 5)]
    [InlineData(5, 8)]
    [InlineData(45, 1836311903)]
    public void ClimbStairsOptimization_SuccessCases(int n, int expected)
    {
        var climbStairsSolution = new ClimbStairsSolution();

        var result = climbStairsSolution.ClimbStairsOptimization(n);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(0)]
    [InlineData(46)]
    public void ClimbStairsOptimization_ThrowsException_WhenInputIsInvalid(int n)
    {
        var climbStairsSolution = new ClimbStairsSolution();

        Assert.Throws<ArgumentOutOfRangeException>(() => climbStairsSolution.ClimbStairsOptimization(n));
    }
}