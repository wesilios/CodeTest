using LeetCode.Solutions;

namespace CodeTest.LeetCode;

public class CommonCharactersSolutionTests
{
    [Theory]
    [InlineData("bella label roller", "e l l")]
    [InlineData("cool lock cook", "c o")]
    public void CommonCharsTest(string wordsString, string expectedResult)
    {
        var words = wordsString.Split();
        var expected = expectedResult.Split();

        var commonCharactersSolution = new CommonCharactersSolution();

        var result = commonCharactersSolution.CommonChars(words);

        Assert.Equal(expected.Length, result.Count);

        foreach (var i in expected)
        {
            Assert.Contains(i, result);
        }
    }
}