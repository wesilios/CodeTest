using System;
using System.Linq;
using LeetCode.Solutions;

namespace CodeTest.LeetCode;

public class TwoSumInputArrayIsSortedTests
{
    [Theory]
    [InlineData("2 7 11 15", 9, "1 2")]
    [InlineData("2 3 4", 6, "1 3")]
    [InlineData("-1 0", -1, "1 2")]
    [InlineData(
        "12 13 23 28 43 44 59 60 61 68 70 86 88 92 124 125 136 168 173 173 180 199 212 221 227 230 277 282 306 314 316 321 325 328 336 337 363 365 368 370 370 371 375 384 387 394 400 404 414 422 422 427 430 435 457 493 506 527 531 538 541 546 568 583 585 587 650 652 677 691 730 737 740 751 755 764 778 783 785 789 794 803 809 815 847 858 863 863 874 887 896 916 920 926 927 930 933 957 981 997",
        542, "24 32")]
    public void TwoSumTest(string numsArray, int target, string expectedResult)
    {
        var numbers = numsArray.Split().Select(c => Convert.ToInt32(c)).ToArray();

        var expected = expectedResult.Split().Select(c => Convert.ToInt32(c)).ToArray();

        var twoSumInputArrayIsSortedSolution = new TwoSumInputArrayIsSortedSolution();

        var results = twoSumInputArrayIsSortedSolution.TwoSum(numbers, target);

        Assert.Equal(expected.Length, results.Length);
        foreach (var i in expected)
        {
            Assert.Contains(i, results);
        }
    }
}