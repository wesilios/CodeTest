using System;
using System.Linq;
using LeetCode.Solutions;
using Xunit;

namespace CodeTest.LeetCode
{
    public class SearchInsertPositionTests
    {
        [Theory]
        [InlineData("1 3 5 6", 5, 2)]
        [InlineData("1 3 5 6", 2, 1)]
        [InlineData("1 3 5 6", 7, 4)]
        public void SearchInsertPositionTest(string inputNumbers, int target, int expectedResult)
        {
            var nums = string.IsNullOrEmpty(inputNumbers)
                ? Array.Empty<int>()
                : inputNumbers.Split().Select(x => Convert.ToInt32(x)).ToArray();
            var searchInsertPositionSolution = new SearchInsertPositionSolution();
            var result = searchInsertPositionSolution.SearchInsert(nums, target);
            Assert.Equal(expectedResult, result);
        }
    }
}