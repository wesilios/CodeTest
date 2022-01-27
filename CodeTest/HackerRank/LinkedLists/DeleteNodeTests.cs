using HackerRank.Solutions;
using Xunit;

namespace CodeTest.HackerRank.LinkedLists
{
    public class DeleteNodeTests
    {
        // Write a function to delete a node in a singly-linked list.
        // You will not be given access to the head of the list, instead you will be given access to the node to be deleted directly.
        // It is guaranteed that the node to be deleted is not a tail node in the list.
        [Theory]
        [InlineData("1 2 3 5 4 6 7", 2, "125467")]
        public void DeleteNode(string input, int value, string expectedResult)
        {
            var linkedListSolution = new LinkedListSolution();
            var inputData = input.Split();
            var head = linkedListSolution.MakeLinkedListFromTail(inputData);
            var nodeDelete = head;
            while (value > 0)
            {
                nodeDelete = nodeDelete.Next;
                value--;
            }

            linkedListSolution.DeleteNode(nodeDelete);
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