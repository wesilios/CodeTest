using System.Linq;
using CodeTest.Library;
using Xunit;

namespace CodeTest.Libraries
{
    public class LinkedListTest
    {
        [Theory]
        [InlineData("1,2,3,4,5,6", "123456")]
        public void InsertIntoTailTest(string input, string expectedResult)
        {
            var linkedList = new LinkedList();
            var inputData = input.Split(",");
            var head = inputData.Aggregate<string, SinglyLinkedListNode<string>>(null,
                linkedList.InsertNodeToTail);

            var result = string.Empty;
            var temp = head;
            while (temp != null)
            {
                result += temp.Data;
                temp = temp.Next;
            }

            Assert.Equal(expectedResult, result);
        }
        
        [Theory]
        [InlineData("1,2,3,4,5,6", "123456")]
        public void MakeLinkedListFromTailTest(string input, string expectedResult)
        {
            var linkedList = new LinkedList();
            var inputData = input.Split(",");
            var head = linkedList.MakeLinkedListFromTail(inputData);

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