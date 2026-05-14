using DynamicProgramming;

namespace Tests.DynamicProgramming;

public class MazeProblemTests
{
    [Theory]
    [InlineData(1, 1, 1)] // Smallest possible grid
    [InlineData(1, 5, 1)] // Single row
    [InlineData(5, 1, 1)] // Single column
    [InlineData(2, 2, 2)] // Simple square
    [InlineData(3, 2, 3)] // Simple rectangle
    [InlineData(3, 3, 6)] // 3x3 Grid
    [InlineData(4, 4, 20)] // 4x4 Grid
    [InlineData(10, 3, 55)] // Large rectangle
    [InlineData(10, 10, 48620)] // Stress test/Performance
    public void FindHowManyWaysRabbitCanMoveTest(int n, int m, int expected)
    {
        var mazeProblem = new MazeProblem();
        var result = mazeProblem.FindHowManyWaysRabbitCanMove(n, m);
        Assert.Equal(expected, result);
    }
    
    [Theory]
    [InlineData(1, 1, 1)] // Smallest possible grid
    [InlineData(1, 5, 1)] // Single row
    [InlineData(5, 1, 1)] // Single column
    [InlineData(2, 2, 2)] // Simple square
    [InlineData(3, 2, 3)] // Simple rectangle
    [InlineData(3, 3, 6)] // 3x3 Grid
    [InlineData(4, 4, 20)] // 4x4 Grid
    [InlineData(10, 3, 55)] // Large rectangle
    [InlineData(10, 10, 48620)] // Stress test/Performance
    public void FindHowManyWaysRabbitCanMoveWithDictionaryTest(int n, int m, int expected)
    {
        var mazeProblem = new MazeProblem();
        var result = mazeProblem.FindHowManyWaysRabbitCanMoveWithDictionary(n, m);
        Assert.Equal(expected, result);
    }
    
    [Theory]
    [InlineData(1, 1, 1)] // Smallest possible grid
    [InlineData(1, 5, 1)] // Single row
    [InlineData(5, 1, 1)] // Single column
    [InlineData(2, 2, 2)] // Simple square
    [InlineData(3, 2, 3)] // Simple rectangle
    [InlineData(3, 3, 6)] // 3x3 Grid
    [InlineData(4, 4, 20)] // 4x4 Grid
    [InlineData(10, 3, 55)] // Large rectangle
    [InlineData(10, 10, 48620)] // Stress test/Performance
    public void FindHowManyWaysRabbitCanMoveOptimizedTest(int n, int m, int expected)
    {
        var mazeProblem = new MazeProblem();
        var result = mazeProblem.FindHowManyWaysRabbitCanMoveOptimized(n, m);
        Assert.Equal(expected, result);
    }
}