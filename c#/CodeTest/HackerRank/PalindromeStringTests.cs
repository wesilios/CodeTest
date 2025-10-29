using HackerRank.Solutions;

namespace CodeTest.HackerRank;

public class PalindromeStringTests
{
    [Theory]
    [InlineData("aaab", 3)]
    [InlineData("baa", 0)]
    [InlineData("aaa", -1)]
    [InlineData("lfcwnnwcwfl", 8)]
    public void PalindromeStringTest(string str, int expectedResult)
    {
        var palindromeString = new PalindromeStringSolution();
        Assert.Equal(expectedResult, palindromeString.FindPalindromeIndex(str));
    }
        
    [Theory]
    [InlineData("aaab", "None")]
    [InlineData("baa", "aba")]
    [InlineData("momom", "momom")]
    public void CheckCanArrangeToPalindromeStringTest(string str, string expectedResult)
    {
        var palindromeString = new PalindromeStringSolution();
        Assert.Equal(expectedResult, palindromeString.CheckCanArrangeToPalindromeString(str));
    }
}