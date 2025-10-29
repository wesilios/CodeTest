using System;
using System.Linq;
using LeetCode.Solutions;

namespace CodeTest.LeetCode;

public class SingleNumberSolutionTests
{
    [Theory]
    [InlineData("2 2 1", 1)]
    [InlineData("4 1 2 1 2", 4)]
    public void SingleNumber(string inputs, int expected)
    {
        var nums = inputs.Split().Select(c => Convert.ToInt32(c)).ToArray();
            
        var singleNumberSolution = new SingleNumberSolution();

        var result = singleNumberSolution.SingleNumber(nums);
            
        Assert.Equal(expected, result);
    }
}