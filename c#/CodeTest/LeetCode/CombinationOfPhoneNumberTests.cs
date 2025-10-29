using LeetCode.Solutions;

namespace CodeTest.LeetCode;

public class CombinationOfPhoneNumberTests
{
    [Theory]
    [InlineData("23", "ad ae af bd be bf cd ce cf")]
    public void LetterCombinationTest(string phoneNumber, string combinationExpected)
    {
        var combinationOfPhoneNumber = new CombinationOfPhoneNumberSolution();
        var combination = combinationOfPhoneNumber
            .GetLetterCombination(phoneNumber);
        foreach (var ctx in combinationExpected.Split())
        {
            Assert.Contains(ctx, combination);
        }
    }
}