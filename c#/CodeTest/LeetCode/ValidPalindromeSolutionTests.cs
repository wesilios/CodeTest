using LeetCode.Solutions;

namespace CodeTest.LeetCode;

public class ValidPalindromeSolutionTests
{
    [Theory]
    [InlineData("", true)]
    [InlineData("A man, a plan, a canal: Panama", true)]
    [InlineData("race a car", false)]
    public void IsValidPalindrome(string s, bool expected)
    {
        var validPalindromeSolution = new ValidPalindromeSolution();

        Assert.Equal(expected, validPalindromeSolution.IsValidPalindrome(s));
    }

    [Theory]
    [InlineData("", " ", "")]
    [InlineData("This is a sentence with multiple    spaces", " ", "This is a sentence with multiple spaces")]
    [InlineData("This is a sentence with multiple    spaces", "", "This is a sentence with multiplespaces")]
    [InlineData("This is     a sentence      with multiple    spaces in multiple places", " ",
        "This is a sentence with multiple spaces in multiple places")]
    [InlineData("This is     a sentence      with multiple    spaces in multiple places", "",
        "This isa sentencewith multiplespaces in multiple places")]
    [InlineData("This is a sentence with multiple spaces", " ", "This is a sentence with multiple spaces")]
    [InlineData("This is a sentence with multiple spaces", "", "This is a sentence with multiple spaces")]
    public void TrimDuplicateSpacesBetweenCharacters_SuccessCases(string input, string replacement,
        string expectResult)
    {
        var validPalindromeSolution = new ValidPalindromeSolution();

        var result = validPalindromeSolution.TrimDuplicateSpacesBetweenCharacters(input, replacement);

        Assert.True(string.Equals(result, expectResult));
    }

    [Theory]
    [InlineData("", " ", "")]
    [InlineData("This is !@#$%^&*()?><-,_+=`~[];':\"/\\a sentence", " ", "This is a sentence")]
    [InlineData("This is !@#$%^&*()?><-,_+=`~[];':\"/\\a sentence", "", "Thisisasentence")]
    [InlineData("!@#$%^&*()?><-,_+=`~[];':\"/\\", " ", " ")]
    [InlineData("!@#$%^&*()?><-,_+=`~[];':\"/\\", "", "")]
    public void TrimSpecialCharacters_SuccessCases(string input, string replacement, string expectResult)
    {
        var validPalindromeSolution = new ValidPalindromeSolution();

        var result = validPalindromeSolution.TrimSpecialCharacters(input, replacement);

        Assert.True(string.Equals(result, expectResult));
    }
}