using LeetCode.Solutions;
using Xunit;

namespace CodeTest.LeetCode
{
    public class MoveZeroToTheEndSolutionTests
    {
        [Fact]
        public void MoveZeroTest()
        {
            // Arrange
            var input = new[] { 0, 2, 0, 5, 10, 9 };
            var expectedResult = new[] { 2, 5, 10, 9, 0, 0 };
            var solution = new MoveZeroToTheEndSolution();
            //  Act
            var result = solution.MoveZero(input);
            // Assert
            for (int i = 0; i < input.Length; i++)
            {
                Assert.Equal(expectedResult[i], result[i]);
            }
        }
    }
}