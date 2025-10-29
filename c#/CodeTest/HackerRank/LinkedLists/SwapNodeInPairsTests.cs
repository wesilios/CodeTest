using HackerRank.Solutions;

namespace CodeTest.HackerRank.LinkedLists;

public class SwapNodeInPairsTests
{
    [Theory]
    [InlineData("1 2 3 4 5 6", "214365")]
    [InlineData("1 2 3", "213")]
    public void SwapNodeInPairsTest(string input, string expectedResult)
    {
        var linkedListSolution = new LinkedListSolution();
        var inputData = input.Split();
        var head = linkedListSolution.MakeLinkedListFromTail(inputData);

        var newHead = linkedListSolution.SwapNodeInPairs(head);
        var result = string.Empty;
        var temp = newHead;
        while (temp != null)
        {
            result += temp.Data.ToString();
            temp = temp.Next;
        }
            
        Assert.Equal(expectedResult, result);
    }
}