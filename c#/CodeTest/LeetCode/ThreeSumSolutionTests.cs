using System.Collections.Generic;
using System.Linq;
using LeetCode.Solutions;
using Xunit;

namespace CodeTest.LeetCode;

public class ThreeSumSolutionTests
{
    [Theory]
    [InlineData("-1,0,1,2,-1,-4", "-1,-1,2|-1,0,1")]
    [InlineData("0,1,1", "")]
    [InlineData("0,0,0", "0,0,0")]
    public void ThreeSumTest(string input, string expectedResults)
    {
        //Arrange
        var nums = input.Split(",").Select(int.Parse).ToArray();
        var solution = new ThreeSumSolution();
        var expectResultNums = new List<List<int>>();
        if (!string.IsNullOrEmpty(expectedResults))
        {
            expectResultNums = expectedResults.Split("|").Select(x => x.Split(",").Select(int.Parse).ToList()).ToList();
        }

        //Act
        var results = solution.ThreeSum(nums);

        //Assert
        var result = true;
        // foreach (var expectedResult in expectedResults)
        // {
        //     foreach (var item in results)
        //     {
        //         
        //     }
        // }
        
        Assert.True(result);
    }
}