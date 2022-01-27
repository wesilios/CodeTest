using System;
using System.Linq;
using HackerRank.Solutions;
using Xunit;

namespace CodeTest.HackerRank
{
    public class RemoveElementSolutionTests
    {
        [Theory]
        [InlineData("1 2 2 3 4 5", 2, 4, "1 3 4 5")]
        public void RemoveElementTest(string numsArray, int val, int actualLength, string expectedNumsArray)
        {
            var nums = numsArray.Split().Select(c => Convert.ToInt32(c)).ToList();
            var expectedNums = expectedNumsArray.Split().Select(c => Convert.ToInt32(c)).ToList();
            var removeElementSolution = new RemoveElementSolution();
            var k = removeElementSolution.RemoveElement(nums, val);
            Assert.Equal(actualLength, k);
            for (var i = 0; i < actualLength; i++)
            {
                Assert.Equal(expectedNums[i], nums[i]);
            }
        }
    }
}