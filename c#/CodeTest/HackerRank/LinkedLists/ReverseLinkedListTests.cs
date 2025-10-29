using HackerRank.Solutions;

namespace CodeTest.HackerRank.LinkedLists;

public class ReverseLinkedListTests
{
    [Theory]
    [InlineData("1,2,3,4,5,6", "654321")]
    public void ReverseLinkedListTest(string input, string expectedResult)
    {
        var linkedListSolution = new LinkedListSolution();
        var inputData = input.Split(",");
        var head = linkedListSolution.MakeLinkedListFromTail(inputData);

        var result = string.Empty;
        var temp = linkedListSolution.ReversedLinkedList(head);
        while (temp != null)
        {
            result += temp.Data;
            temp = temp.Next;
        }

        Assert.Equal(expectedResult, result);
    }
}