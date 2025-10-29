using System;
using System.Collections.Generic;
using System.Linq;
using LeetCode.Solutions;

namespace CodeTest.LeetCode;

public class ThreeSumSolutionTests
{
    private readonly ThreeSumSolution _solution = new();

    [Theory]
    [InlineData("-1,0,1,2,-1,-4", "-1,-1,2|-1,0,1")]
    [InlineData("0,1,1", "")]
    [InlineData("0,0,0", "0,0,0")]
    public void ThreeSum_ReturnsExpectedTriplets(string numsStr, string expectedStr)
    {
        // Arrange
        var nums = numsStr.Split(',', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        var expected = ParseExpected(expectedStr);

        // Act
        var result = _solution.ThreeSum(nums);

        // Sort inner lists for comparison consistency
        var sortedResult = result
            .Select(t => t.OrderBy(x => x).ToList())
            .OrderBy(t => string.Join(",", t))
            .ToList();

        var sortedExpected = expected
            .Select(t => t.OrderBy(x => x).ToList())
            .OrderBy(t => string.Join(",", t))
            .ToList();

        // Assert
        Assert.Equal(sortedExpected.Count, sortedResult.Count);

        for (int i = 0; i < sortedExpected.Count; i++)
        {
            Assert.Equal(sortedExpected[i], sortedResult[i]);
        }
    }

    private static List<List<int>> ParseExpected(string expectedStr)
    {
        if (string.IsNullOrWhiteSpace(expectedStr))
            return new List<List<int>>();

        return expectedStr.Split('|', StringSplitOptions.RemoveEmptyEntries)
            .Select(t => t.Split(',', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList())
            .ToList();
    }
}