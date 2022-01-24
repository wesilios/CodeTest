using System.Linq;
using CodeTest.Library;
using HackerRank.Solutions;
using Xunit;

namespace CodeTest.HackerRank.LinkedLists
{
    public class InsertIntoTailTests
    {
        [Theory]
        [InlineData("1,2,3,4,5,6", "123456")]
        public void InsertIntoTailTest(string input, string expectedResult)
        {
            var linkedListSolution = new LinkedListSolution();
            var inputData = input.Split(",");
            var head = inputData.Aggregate<string, SinglyLinkedListNode<string>>(null,
                linkedListSolution.InsertNodeToTail);

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