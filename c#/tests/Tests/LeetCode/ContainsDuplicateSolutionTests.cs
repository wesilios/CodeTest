using LeetCode.Solutions;

namespace Tests.LeetCode;

public class ContainsDuplicateSolutionTests
{
    [Theory]
    [InlineData("1 2 3 1", true)]
    [InlineData("1 2 3 4", false)]
    [InlineData("1 1 1 3 3 4 3 2 4 2", true)]
    [InlineData("", false)]
    [InlineData("1", false)]
    [InlineData("1 1", true)]
    [InlineData("1 2", false)]
    [InlineData("-1 -1", true)]
    [InlineData("-1 -2 -3", false)]
    [InlineData("-1 2 3 -1", true)]
    public void ContainsDuplicateTest(string inputNumbers, bool expectedResult)
    {
        // Arrange
        var nums = string.IsNullOrWhiteSpace(inputNumbers)
            ? Array.Empty<int>()
            : inputNumbers.Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

        var solution = new ContainsDuplicateSolution();

        // Act
        var result = solution.ContainsDuplicate(nums);

        // Assert
        Assert.Equal(expectedResult, result);
    }
}