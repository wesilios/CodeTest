using HackerRank.Solutions;

namespace CodeTest.HackerRank;

public class BalanceBracketsSolutionTests
{
    [Theory]
    [InlineData("{[()]}", true)]
    [InlineData("[", false)]
    [InlineData("][", false)]
    [InlineData("{[(])}", false)]
    [InlineData("{{[[(())]]}}", true)]
    public void IsBalanced(string str, bool expectedResult)
    {
        var balanceBracket = new BalanceBracketsSolution();
        Assert.Equal(expectedResult, balanceBracket.IsBalance(str));
    }
}