using HackerRank.Solutions;

namespace CodeTest.HackerRank;

public class MakeAnagramStringTests
{
    [Theory]
    [InlineData("abc", "cde", 4)]
    [InlineData("abc", "amnop", 6)]
    public void MakeAnagramStringTest(string s1, string s2, int expectedResult)
    {
        var makeAnagram = new MakeAnagramStringSolution();
        Assert.Equal(expectedResult, makeAnagram.GetNumberRemovedCharacterToMakeAnagramString(s1, s2));
    }
}