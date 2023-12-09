using LeetCode.Solutions;
using Xunit;

namespace CodeTest.LeetCode;

public class RansomNoteSolutionTests
{
    [Theory]
    [InlineData("aa", "aab", true)]
    [InlineData("aa", "ab", false)]
    [InlineData("aa", "bb", false)]
    public void CheckRansomNoteTest(string ransomNote, string magazine, bool expectedResult)
    {
        // Arrange
        var solution = new RansomNoteSolution();

        // Act
        var result = solution.CheckRansomNote(ransomNote, magazine);

        // Assert
        Assert.Equal(expectedResult, result);
    }
}