using HackerRank.Solutions;
using Xunit;

namespace CodeTest.HackerRank.LinkedLists
{
    public class DeleteNodeAtPositionTests
    {
        [Theory]
        [InlineData("1,2,3", 2, "12")]
        [InlineData("1,2,3,5", 3, "123")]
        public void DeleteNodeAtPositionTest(string input, int position, string expectedResult)
        {
            var linkedListSolution = new LinkedListSolution();
            var inputData = input.Split(",");
            var head = linkedListSolution.MakeLinkedListFromTail(inputData);
            head = linkedListSolution.DeleteNodeAtPosition(head, position);
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
}