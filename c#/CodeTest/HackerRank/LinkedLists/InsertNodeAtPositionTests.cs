using HackerRank.Solutions;

namespace CodeTest.HackerRank.LinkedLists;

public class InsertNodeAtPositionTests
{
    [Theory]
    [InlineData("1,2,3", 2, 4, "1243")]
    [InlineData("1,2,3", 3, 4, "1234")]
    public void InsertNodeAtPositionTest(string input, int position, int data, string expectedResult)
    {
        var linkedListSolution = new LinkedListSolution();
        var inputData = input.Split(",");
        var head = linkedListSolution.MakeLinkedListFromTail(inputData);
        head = linkedListSolution.InsertNodeAtPosition(head, data, position);
        var result = string.Empty;
        var temp = head;
        while (temp != null)
        {
            result += temp.Data;
            temp = temp.Next;
        }

        Assert.Equal(expectedResult, result);
    }
}