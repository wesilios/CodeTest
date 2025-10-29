namespace CodeTest.HackerRank;

public class BuildPalindromeStringTests
{
    [Theory]
    [InlineData("abc", "cba", "abccba")]
    [InlineData("abc", "abc", "bccb")]
    [InlineData("abch", "abc", "bchcb")]
    [InlineData("abch", "jur", "-1")]
    public void BuildPalindromeStringTest(string s1, string s2, string expectedResult)
    {
        Assert.Equal(expectedResult, Solution(s1, s2));
    }

    private string Solution(string s1, string s2)
    {
        var result = "-1";

        return result;
    }
}