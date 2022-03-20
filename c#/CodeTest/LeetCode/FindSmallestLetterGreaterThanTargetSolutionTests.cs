using System.Linq;
using LeetCode.Solutions;
using Xunit;

namespace CodeTest.LeetCode
{
    public class FindSmallestLetterGreaterThanTargetSolutionTests
    {
        [Theory]
        [InlineData("c f j", 'a', 'c')]
        [InlineData("c f j", 'c', 'f')]
        [InlineData("c f j", 'd', 'f')]
        [InlineData("c f j", 'j', 'c')]
        public void NextGreatestLetterTest(string characters, char target, char expected)
        {
            var letters = characters.Split().Select(char.Parse).ToArray();
            
            var findSmallestLetterGreaterThanTargetSolution = new FindSmallestLetterGreaterThanTargetSolution();

            var result = findSmallestLetterGreaterThanTargetSolution.NextGreatestLetter(letters, target);
            
            Assert.Equal(expected, result);
        }
    }
}