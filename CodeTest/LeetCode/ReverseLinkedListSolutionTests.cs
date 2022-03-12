using CodeTest.Library;
using LeetCode.Solutions;
using Xunit;

namespace CodeTest.LeetCode
{
    public class ReverseLinkedListSolutionTests
    {
        [Theory]
        [InlineData("1,2,3,4,5,6", "654321")]
        public void ReverseLinkedListTest(string input, string expectedResult)
        {
            var linkedList = new LinkedList();
            var inputData = input.Split(",");
            var head = linkedList.MakeLinkedListFromTail(inputData);

            var result = string.Empty;
            var reverseLinkedListSolution = new ReverseLinkedListSolution();
            var temp = reverseLinkedListSolution.ReverseLinkedList(head);
            while (temp != null)
            {
                result += temp.Data;
                temp = temp.Next;
            }

            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData("1,2,3,4,5,6,7,8,9", 2, 1, "123456789")]
        [InlineData("1,2,3,4,5,6,7,8,9", 0, 1, "123456789")]
        [InlineData("1,2,3,4,5,6,7,8,9", 1, 0, "123456789")]
        [InlineData("1,2,3,4,5,6,7,8,9", 1, 1, "123456789")]
        [InlineData("1,2,3,4,5,6,7,8,9", 2, 2, "123456789")]
        [InlineData("1,2,3,4,5,6,7,8,9", 1, 4, "432156789")]
        [InlineData("1,2,3,4,5,6,7,8,9", 1, 9, "987654321")]
        [InlineData("1,2,3,4,5,6,7,8,9", 2, 7, "176543289")]
        public void ReversedLinkedListInBetweenTest(string input, int left, int right, string expectedResult)
        {
            var linkedList = new LinkedList();
            var inputData = input.Split(",");
            var head = linkedList.MakeLinkedListFromTail(inputData);

            var result = string.Empty;
            var reverseLinkedListSolution = new ReverseLinkedListSolution();
            var temp = reverseLinkedListSolution.ReverseLinkedListInBetween(head, left, right);
            while (temp != null)
            {
                result += temp.Data;
                temp = temp.Next;
            }

            Assert.Equal(expectedResult, result);
        }
    }
}