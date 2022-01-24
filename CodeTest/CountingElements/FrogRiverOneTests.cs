using System.Collections.Generic;
using Xunit;

namespace CodeTest.CountingElements
{
    public class FrogRiverOneTests
    {
        [Fact]
        public void FrogRiverOneTest()
        {
            var a = new[] { 1, 3, 1, 4, 2, 3, 5, 4 };
            var b = new[] { 1, 3, 1, 5, 2, 3, 5, 4 };
            var c = new[] { 1, 3, 1, 5, 2, 3, 5, 4 };
            var d = new[] { 2, 2, 2, 2, 2, 2 };
            var e = new[] { 2, 1, 2, 2, 2, 2 };
            var f = new[] { 1, 2, 2, 2, 2, 2 };
            Assert.Equal(6, Solution(5, a));
            Assert.Equal(7, Solution(5, b));
            Assert.Equal(-1, Solution(6, c));
            Assert.Equal(-1, Solution(2, d));
            Assert.Equal(1, Solution(2, e));
            Assert.Equal(1, Solution(2, f));
        }

        private int Solution(int x, int[] a)
        {
            var numberMap = new HashSet<int>();
            for (var i = 1; i <= x; i++)
            {
                numberMap.Add(i);
            }

            for (var i = 0; i < a.Length; i++)
            {
                if (!numberMap.Contains(a[i])) continue;
                numberMap.Remove(a[i]);
                if (numberMap.Count == 0)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}