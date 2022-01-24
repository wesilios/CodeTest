using System.Collections.Generic;
using Xunit;

namespace CodeTest.CountingElements
{
    public class MissingIntegerTests
    {
        [Fact]
        public void MissingInteger()
        {
            var a = new[] { 1, 3, 6, 4, 1, 2 };
            var b = new[] { -1, -3 };
            var solution = new Solution();
            Assert.Equal(5, solution.ReturnSolution(a));
            Assert.Equal(1, solution.ReturnSolution(b));
        }

        private class Solution
        {
            public int ReturnSolution(int[] a)
            {
                var result = 1;
                var numberMap = new Dictionary<int, bool>();
                foreach (var t in a)
                {
                    if (t > 0 && !numberMap.ContainsKey(t))
                    {
                        numberMap.Add(t, true);
                    }
                }

                while (numberMap.ContainsKey(result))
                {
                    result++;
                }

                return result;
            }
        }
    }
}