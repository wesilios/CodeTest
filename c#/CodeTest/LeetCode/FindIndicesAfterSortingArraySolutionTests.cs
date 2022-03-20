using System;
using System.Linq;
using LeetCode.Solutions;
using Xunit;

namespace CodeTest.LeetCode
{
    public class FindIndicesAfterSortingArraySolutionTests
    {
        [Theory]
        [InlineData("1 2 5 2 3", 2, 2)]
        [InlineData("1 2 5 2 2", 2, 3)]
        [InlineData("1 2 5 2 3", 4, 0)]
        public void TargetIndicesTest(string numberArray, int target, int expectedLength)
        {
            var numbers = numberArray.Split().Select(c => Convert.ToInt32(c)).ToArray();

            var findIndicesAfterSortingArraySolution = new FindIndicesAfterSortingArraySolution();

            var indices = findIndicesAfterSortingArraySolution.TargetIndices(numbers, target);
            
            Assert.Equal(expectedLength, indices.Count);
            
            foreach (var ctx in indices)
            {
                Assert.Equal(target, numbers[ctx]);
            }
        }
    }
}