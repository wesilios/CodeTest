using LeetCode.Solutions;

namespace CodeTest.LeetCode;

public class SqrtSolutionTests
{
    [Theory]
    [InlineData(8, 2)]
    [InlineData(2, 1)]
    [InlineData(1, 1)]
    [InlineData(0, 0)]
    public void SqrtTest(int x, int expectedResult)
    {
        var sqrtSolution = new SqrtSolution();
        Assert.Equal(expectedResult, sqrtSolution.Sqrt(x));
    }
}