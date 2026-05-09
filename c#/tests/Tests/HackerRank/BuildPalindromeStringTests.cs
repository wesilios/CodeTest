using HackerRank.Solutions;

namespace Tests.HackerRank;

public class BuildPalindromeStringTests
{
    [Theory]
    [InlineData("abc", "cba", "abccba")]
    [InlineData("abc", "abc", "bccb")]
    [InlineData("abch", "abc", "bchcb")]
    [InlineData("abch", "jur", "-1")]
    public void BuildPalindromeStringTest(string s1, string s2, string expectedResult)
    {
        var solution = new BuildPalindromeStringSolution();
        Assert.Equal(expectedResult, solution.BuildPalindrome(s1, s2));
    }
}