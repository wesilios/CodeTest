using LeetCode.Solutions;

namespace CodeTest.LeetCode;

public class LengthOfLastWordSolutionTest
{
    [Theory]
    [InlineData("Hello World", 5)]
    [InlineData("luffy is still joyboy", 6)]
    [InlineData("   fly me   to   the moon  ", 4)]
    [InlineData("", 0)]
    public void LengthOfLastWord(string input, int expected)
    {
        var lengthOfLastWordSolution = new LengthOfLastWordSolution();

        var result = lengthOfLastWordSolution.LengthOfLastWord(input);
            
        Assert.Equal(expected, result);
    }
}