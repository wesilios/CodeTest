using System;
using System.Linq;
using HackerRank.Solutions;
using LeetCode.Solutions;
using Xunit;

namespace CodeTest.LeetCode
{
    public class RemoveDuplicatedFromSortedListSolutionTests
    {
        [Theory]
        [InlineData("1 1 2 2 3 3", "1 2 3")]
        [InlineData("1", "1")]
        [InlineData("1 1 2 3 4 4 5", "1 2 3 4 5")]
        public void DeleteDuplicatesTest(string input, string expected)
        {
            var linkedListSolution = new LinkedListSolution();
            var inputData = input.Split();
            var head = linkedListSolution.MakeLinkedListFromTail(inputData);

            var removeDuplicatedFromSortedListSolution = new RemoveDuplicatedFromSortedListSolution();

            head = removeDuplicatedFromSortedListSolution.DeleteDuplicates(head);

            var expectResult = expected.Split().Select(c => Convert.ToInt32(c)).ToArray();

            var i = 0;
            var node = head;
            while (i < expectResult.Length)
            {
                Assert.Equal(node.Data, expectResult[i]);
                i++;
                node = node.Next;
            }
        }
    }
}