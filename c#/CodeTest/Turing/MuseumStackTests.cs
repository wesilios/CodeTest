using System.Linq;
using Turing.Solutions;

namespace CodeTest.Turing;

public class MuseumStackTests
{
    [Theory]
    [InlineData("1,2,3", 1)]
    [InlineData("2,2,2,3,3", 2)]
    [InlineData("2,2,2,3,3,5,5", 2)]
    public void RunTest(string input, int expectedResult)
    {
        var k = input.Split(",").Select(int.Parse).ToArray();
        var solution = new MuseumStack();

        var result = solution.Solution(k);

        Assert.Equal(expectedResult, result);
    }
}