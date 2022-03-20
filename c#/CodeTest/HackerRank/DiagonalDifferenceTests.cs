using System.Collections.Generic;
using HackerRank.Solutions;
using Xunit;

namespace CodeTest.HackerRank
{
    public class DiagonalDifferenceTests
    {
        [Fact]
        public void DiagonalDifferenceTest()
        {
            var arr = new List<List<int>>
            {
                new List<int> { 11, 2, 4 },
                new List<int> { 4, 5, 6 },
                new List<int> { 10, 8, -12 },
            };

            var diagonalDifference = new DiagonalDifferenceSolution();
            const int expectResult = 15;
            

            Assert.Equal(expectResult, diagonalDifference.FindDiagonalDifference(arr));
        }
    }
}