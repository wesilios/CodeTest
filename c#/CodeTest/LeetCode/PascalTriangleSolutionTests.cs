using System;
using System.Linq;
using LeetCode.Solutions;
using Xunit;

namespace CodeTest.LeetCode
{
    public class PascalTriangleSolutionTests
    {
        [Theory]
        [InlineData(5, "1 1-1 1-2-1 1-3-3-1 1-4-6-4-1")]
        [InlineData(2, "1 1-1")]
        [InlineData(1, "1")]
        public void GenerateTest(int n, string expectedResult)
        {
            var expected = expectedResult.Split().Select(c => c.Split('-').Select(x => Convert.ToInt32(x)).ToList())
                .ToList();

            var pascalTriangleSolution = new PascalTriangleSolution();

            var result = pascalTriangleSolution.Generate(n);

            for (var index = 0; index < expected.Count; index++)
            {
                var row = expected[index];
                for (var i = 0; i < row.Count; i++)
                {
                    Assert.Equal(expected[index][i], result[index][i]);
                }
            }
        }
    }
}