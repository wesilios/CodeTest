using HackerRank.Solutions;

namespace CodeTest.HackerRank.LinkedLists;

public class RemoveNodeByItsDataValueTests
{
    [Theory]
    [InlineData("1 2 3", 2, "13")]
    [InlineData("1 1 1", 1, "")]
    [InlineData("1 2 3", 1, "23")]
    [InlineData("1 2 2 3 5 4 6 3", 3, "122546")]
    [InlineData("1 2 2 3 5 4 6 3", 2, "135463")]
    public void RemoveNodeByItsDataValueTest(string input, int value, string expectedResult)
    {
        var linkedListSolution = new LinkedListSolution();
        var inputData = input.Split();
        var head = linkedListSolution.MakeLinkedListFromTail(inputData);
        var newHead = linkedListSolution.RemoveNodeByItsDataValue(head, value);
        var result = string.Empty;
        var temp = newHead;
        while (temp != null)
        {
            result += temp.Data;
            temp = temp.Next;
        }

        Assert.Equal(expectedResult, result);
    }
}