using System;
using System.Linq;
using LeetCode.Solutions;
using Xunit;

namespace CodeTest.LeetCode
{
    public class BinarySearchSolutionTests
    {
        [Theory]
        [InlineData("-1 0 3 5 9 12", 9, 4)]
        [InlineData("-1 0 3 5 9 12", 2, -1)]
        [InlineData("5", 5, 0)]
        [InlineData("1 5", 5, 1)]
        [InlineData("5", -5, -1)]
        public void SearchTest(string numbersArray, int target, int expected)
        {
            var numbers = numbersArray.Split().Select(c => Convert.ToInt32(c)).ToArray();

            var binarySearchSolution = new BinarySearchSolution();

            var result = binarySearchSolution.Search(numbers, target);
            
            Assert.Equal(expected, result);
        }
    }
}