using HackerRank.Solutions;
using Xunit;

namespace CodeTest.HackerRank
{
    public class BalanceBracketsTests
    {
        [Theory]
        [InlineData("{[()]}", true)]
        [InlineData("{[(])}", false)]
        [InlineData("{{[[(())]]}}", true)]
        public void IsBalanced(string str, bool expectedResult)
        {
            var balanceBracket = new BalanceBrackets();
            Assert.Equal(expectedResult, balanceBracket.IsBalance(str));
        }
    }
}