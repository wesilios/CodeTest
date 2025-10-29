using HackerRank.Solutions;

namespace CodeTest.HackerRank.LinkedLists;

public class PrintReverseListTests
{
    [Theory]
    [InlineData("1,2,3,4,5,6", "654321")]
    public void PrintReverseListTest(string input, string expectedResult)
    {
        var linkedListSolution = new LinkedListSolution();
        var inputData = input.Split(",");
        var head = linkedListSolution.MakeLinkedListFromTail(inputData);

        var result = linkedListSolution.PrintInReverse(head);

        Assert.Equal(expectedResult, result);
    }
}