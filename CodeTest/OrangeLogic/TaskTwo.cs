using System;
using Xunit;

namespace CodeTest.OrangeLogic
{
    public class TaskTwo
    {
        [Fact]
        public void Test()
        {
            var a = new[] { 100, 110, 200, 100 };
            var b = new[] { 50, 60, 100, 100 };
            // (Zero (100, 50) , One(200, 100), (100, 100)
            // (100, 70) => Zero (120<= 100 <= 80, 70 <= 50 <= 30)
            // x(90, 70)
            Assert.Equal(1, Solution(a, b, 90, 70));
            Assert.Equal(-1, Solution(a, b, 150, 30));
        }

        private int Solution(int[] a, int[] b, int x, int y)
        {
            const int range = 20;
            if (a.Length != b.Length)
            {
                throw new InvalidOperationException();
            }

            var result = -1;
            for (var i = 0; i < a.Length; i++)
            {
                if (x > a[i] + range || x < a[i] - range)
                {
                    continue;
                }

                if (y > b[i] + range || y < b[i] - range)
                {
                    continue;
                }

                result = i;
            }

            return result;
        }
    }
}