using HackerRank.Solutions;

namespace CodeTest.HackerRank;

public class ZigZagSequenceTests
{
    [Fact]
    public void FindZigZagSequenceTest()
    {
        var input = new[] { 1, 2, 3, 4, 5, 6, 7 };
        var expectResult = new[] { 1, 2, 3, 7, 6, 5, 4 };
        var zigZagSequence = new ZigZagSequenceSolution();
        var result = zigZagSequence.FindZigZagSequence(input);
        for (var i = 0; i < result.Length; i++)
        {
            Assert.Equal(expectResult[i], result[i]);
        }
    }
}