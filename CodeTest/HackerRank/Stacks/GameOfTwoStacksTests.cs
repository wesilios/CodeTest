using System;
using System.Linq;
using HackerRank.Solutions;
using Xunit;

namespace CodeTest.HackerRank.Stacks
{
    public class GameOfTwoStacksTests
    {
        [Theory]
        [InlineData("4 2 4 6 1", "2 1 8 5", 10, 4)]
        [InlineData("1 2 3 4 5", "6 7 8 9", 13, 4)]
        public void TwoStacksTest(string a, string b, int maxSum, int expectedResult)
        {
            var gameOfTwoStacks = new GameOfTwoStacksSolution();
            var listA = a.Split().Select(c => Convert.ToInt32(c)).ToList();
            var listB = b.Split().Select(c => Convert.ToInt32(c)).ToList();
            Assert.Equal(expectedResult, gameOfTwoStacks.TwoStacks(maxSum, listA, listB));
        }
    }
}