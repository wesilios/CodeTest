using System.Collections.Generic;
using HackerRank.Solutions;
using Xunit;

namespace CodeTest.HackerRank
{
    public class GridChallengeTests
    {
        [Fact]
        public void GridChallengeTest()
        {
            var grid = new List<string> { "mpxz", "abcd", "wlmf" };
            const bool expectedResult = false;
            var gridChallenge = new GridChallengeSolution();
            Assert.Equal(expectedResult, gridChallenge.IsValidGrid(grid));
        }
    }
}