using LeetCode.Solutions;

namespace Tests.LeetCode;

public class ValidAnagramSolutionTests
{
    [Theory]
    [InlineData("anagram", "nagaram", true)]
    [InlineData("rat", "car", false)]
    [InlineData("a", "ab", false)]
    [InlineData("ab", "a", false)]
    [InlineData("", "", true)]
    [InlineData("a", "a", true)]
    [InlineData("a", "b", false)]
    [InlineData("listen", "silent", true)]
    [InlineData("triangle", "integral", true)]
    [InlineData("aacc", "ccac", false)]
    [InlineData("aa", "bb", false)]
    [InlineData("Anagram", "nagaram", false)]
    [InlineData("a b c", "c b a", true)]
    public void IsAnagram_AsExpected(string s, string t, bool expected)
    {
        // Arrange
        var solution = new ValidAnagramSolution();

        // Act & Assert
        Assert.Equal(expected, solution.IsAnagram(s, t));
    }
    
    [Theory]
    [InlineData("\tanagram\n", "na\nga\tram", true)]
    [InlineData("\trat", "\tcar", false)]
    [InlineData("a", "ab", false)]
    [InlineData("ab", "a", false)]
    [InlineData("", "", true)]
    [InlineData("a", "a", true)]
    [InlineData("a", "b", false)]
    [InlineData("listen", "silent", true)]
    [InlineData("aacc", "ccac", false)]
    [InlineData("こんにちは", "はちにんこ", true)]
    [InlineData("こんにちは", "さようなら", false)]
    [InlineData("café", "éfac", true)]
    [InlineData("😀😁😂", "😂😀😁", true)]
    [InlineData("😀😁😂", "😀😁😄", false)]
    public void IIsAnagramWithUniCode_AsExpected(string s, string t, bool expected)
    {
        // Arrange
        var solution = new ValidAnagramSolution();

        // Act & Assert
        Assert.Equal(expected, solution.IsAnagramWithUniCode(s, t));
    }
}