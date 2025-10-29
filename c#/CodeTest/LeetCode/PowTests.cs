using System;
using LeetCode.Solutions;

namespace CodeTest.LeetCode;

public class PowTests
{
    [Theory]
    [InlineData(2.0, 1)]
    [InlineData(2.0, 0)]
    [InlineData(2.0, 2)]
    [InlineData(-2.0, 2)]
    [InlineData(-2.0, 3)]
    [InlineData(-2.0, 4)]
    [InlineData(2.00000, -2147483648)]
    public void PowTest(double x, int n)
    {
        var powSolution = new PowSolution();
        Assert.Equal(Math.Pow(x, n), powSolution.Pow(x, n));
    }
}