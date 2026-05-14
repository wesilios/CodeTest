using DynamicProgramming;

namespace Tests.DynamicProgramming;

public class FibonacciNumberTests
{
    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 1)]
    [InlineData(30, 832040)]
    [InlineData(50, 12586269025)]
    public void FibTest(int n, long expectedResult)
    {
        var fib = new FibonacciNumber();
        Assert.Equal(expectedResult, fib.FindFibonacciNumber(n));
    }

    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 1)]
    [InlineData(30, 832040)]
    [InlineData(50, 12586269025)]
    public void ComputeFibonacciNumberWithBottomUpTest(int n, long expectedResult)
    {
        var fib = new FibonacciNumber();
        Assert.Equal(expectedResult, fib.ComputeFibonacciNumberWithBottomUp(n));
    }
}