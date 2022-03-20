using System.Linq;
using CodeTest.Library;
using HackerRank.Solutions;
using LeetCode.Solutions;
using Xunit;

namespace CodeTest.LeetCode
{
    public class LinkedListCycleSolutionTests
    {
        [Theory]
        [InlineData("3 2 0 -4", 0, true)]
        [InlineData("3 2 0 -4", 1, true)]
        [InlineData("3 2 0 -4", -1, false)]
        [InlineData("1", -1, false)]
        [InlineData("", -1, false)]
        public void HasCycleTest(string listData, int pos, bool expected)
        {
            var linkedListSolution = new LinkedListSolution();
            var inputData = listData.Split();
            var head = inputData.Aggregate<string, SinglyLinkedListNode<string>>(null,
                linkedListSolution.InsertNodeToTail);

            var tail = head;

            while (tail.Next != null)
            {
                tail = tail.Next;
            }

            var tempPos = 0;

            var node = head;
            while (tempPos <= pos)
            {
                if (tempPos == pos)
                {
                    tail.Next = node;
                    break;
                }

                tempPos++;
                node = node.Next;
            }

            var linkedListCycleSolution = new LinkedListCycleSolution();

            var result = linkedListCycleSolution.HasCycle(head);

            Assert.Equal(expected, result);
        }
    }
}