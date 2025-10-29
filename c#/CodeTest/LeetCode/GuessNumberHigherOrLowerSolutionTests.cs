using LeetCode.Solutions;

namespace CodeTest.LeetCode;

public class GuessNumberHigherOrLowerSolutionTests
{
    [Theory]
    [InlineData(10, 6, 6)]
    [InlineData(2126753390, 1702766719, 1702766719)]
    public void GuessNumberTest(int n, int pick, int expected)
    {
        var guessNumberHigherOrLowerSolution = new GuessNumberHigherOrLowerSolution(pick);

        var guess = guessNumberHigherOrLowerSolution.GuessNumber(n);
            
        Assert.Equal(expected, guess);
    }
}