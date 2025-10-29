using LeetCode.Solutions;

namespace CodeTest.LeetCode;

public class RotateLinkedListSolutionTests
{
    [Theory]
    [InlineData("12345", 2, "45123")]
    [InlineData("12345", 4, "23451")]
    [InlineData("12345", 0, "12345")]
    [InlineData("", 0, "")]
    [InlineData("1", 0, "1")]
    [InlineData("12", 2, "12")]
    [InlineData("12", 2000000, "12")]
    [InlineData("12", 1, "21")]
    [InlineData("012", 4, "201")]
    [InlineData("", 1, "")]
    public void RotateRightTest(string input, int cycle, string expectedResult)
    {
        //Arrange
        var head = GetHead(input);
        var solution = new RotateLinkedListSolution();

        //Act
        var newHead = solution.RotateRight(head, cycle);
        var result = string.Empty;
        while (newHead != null)
        {
            result += newHead.Val.ToString();
            newHead = newHead.Next;
        }

        //Assert
        Assert.Equal(expectedResult, result);
    }

    private ListNode GetHead(string input)
    { 
        ListNode head = null;
        for (var i = input.Length - 1; i >= 0; i--)
        {
            var temp = new ListNode(int.Parse(input[i].ToString()), head);
            head = temp;
        }

        return head;
    }
}