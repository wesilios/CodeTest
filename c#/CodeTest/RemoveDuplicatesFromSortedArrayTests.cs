using System;
using System.Linq;
using HackerRank.Solutions;

namespace CodeTest;

public class RemoveDuplicatesFromSortedArrayTests
{
    [Theory]
    [InlineData("1 1 2", 2)]
    [InlineData("", 0)]
    [InlineData("1", 1)]
    public void RemoveDuplicatesFromSortedArrayTest(string inputNumber, int expectedResult)
    {
        var numbers = string.IsNullOrEmpty(inputNumber)
            ? Array.Empty<int>()
            : inputNumber.Split().Select(x => Convert.ToInt32(x)).ToArray();
        var removeDuplicatesFromSortedArray = new RemoveDuplicatesFromSortedArraySolution();
        var result = removeDuplicatesFromSortedArray.RemoveDuplicatesFromSortedArray(numbers);
        Assert.Equal(expectedResult, result);
    }
}