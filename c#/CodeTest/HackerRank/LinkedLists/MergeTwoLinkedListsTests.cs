using HackerRank.Solutions;
using Xunit;

namespace CodeTest.HackerRank.LinkedLists
{
    public class MergeTwoLinkedListsTests
    {
        [Theory]
        [InlineData("1,2,3,4,5,6", "1,2,3,4,5,6", "112233445566")]
        [InlineData("1,3,5,7,8,9", "1,2,3,4,5,6", "112334556789")]
        [InlineData("4,5,10", "1,2,3,4,5,6", "1234455610")]
        [InlineData("4,5,6", "1,2,3", "123456")]
        public void MergeTwoLinkedListsTest(string s1, string s2, string expectedResult)
        {
            var linkedListSolution = new LinkedListSolution();
            var inputData = s1.Split(",");
            var headOne = linkedListSolution.MakeLinkedListFromTail(inputData);
            
            var inputDataS2 = s2.Split(",");
            var headTwo = linkedListSolution.MakeLinkedListFromTail(inputDataS2);

            var newHead = linkedListSolution.MergeTwoLinkedLists(headOne, headTwo);
            var result = string.Empty;
            var temp = newHead;
            while (temp != null)
            {
                result += temp.Data.ToString();
                temp = temp.Next;
            }
            
            Assert.Equal(expectedResult, result);
        }
    }
}