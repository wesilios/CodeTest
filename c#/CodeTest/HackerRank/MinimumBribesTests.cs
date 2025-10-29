using System;
using System.Linq;
using HackerRank.Solutions;

namespace CodeTest.HackerRank;

public class MinimumBribesTests
{
    [Theory]
    [InlineData("21534", 3)]
    [InlineData("25134", -1)]
    [InlineData("12537864", 7)]
    public void MinimumBribesTest(string queue, int expectedResult)
    {
        var queueNumber = queue.Select(c => Convert.ToInt32(c.ToString())).ToList();
        var minimumBribe = new MinimumBribesSolution();
        Assert.Equal(expectedResult, minimumBribe.CheckTotalBribes(queueNumber));
    }
}