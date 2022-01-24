using System.Linq;
using HackerRank.Solutions;
using Xunit;

namespace CodeTest.HackerRank.ArrayTests
{
    public class ArrayRotationSolutionTests
    {
        [Theory]
        [InlineData("1 2 3 4 5 6", 2, "3 4 5 6 1 2")]
        [InlineData("1 2 3 4 5 6", 3, "4 5 6 1 2 3")]
        [InlineData("1 2 3 4 5 6", 6, "1 2 3 4 5 6")]
        public void RotateLeftTest(string input, int d, string expectedResult)
        {
            var arr = input.Split().ToList();
            var arraySolution = new ArrayRotationSolution();
            arraySolution.RotateLeft(arr, d);
            var result = string.Empty;
            for (var i = 0; i < arr.Count; i++)
            {
                if (i != 0)
                {
                    result += " ";
                }

                result += arr[i];
            }
            
            Assert.Equal(expectedResult, result);
        }
    }
}