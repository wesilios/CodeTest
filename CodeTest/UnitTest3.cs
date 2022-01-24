using System;
using System.Collections.Generic;
using Xunit;

namespace CodeTest
{
    public class UnitTest3
    {
        [Theory]
        [InlineData(10, "1")]
        [InlineData(2, "2")]
        [InlineData(4, "4")]
        [InlineData(8, "8")]
        [InlineData(9, "9")]
        [InlineData(54321, "12345")]
        [InlineData(10011, "11001")]
        [InlineData(1001, "1001")]
        [InlineData(1, "1")]
        public void Test(int n, string expected)
        {
            var solution = new Solution();
            // solution.ReturnSolution(n);
            // solution.NewSolution(n);
            Assert.Equal(expected, solution.NewSolution(n));
        }

        private class Solution
        {
            public void ReturnSolution(int n)
            {
                var enablePrint = n % 10;
                while (n > 0)
                {
                    if (enablePrint == 0 && n % 10 != 0)
                    {
                        enablePrint = 1;
                    }
                    else if (enablePrint == 1)
                    {
                        Console.Write(n % 10);
                    }

                    n /= 10;
                }
            }

            public string NewSolution(int n)
            {
                var result = string.Empty;
                var enablePrint = n % 10;
                while (n > 0)
                {
                    if (enablePrint == 0 && n % 10 != 0)
                    {
                        enablePrint = 1;
                    }

                    if (enablePrint != 0)
                    {
                        result += n % 10;
                    }

                    n /= 10;
                }

                return result;
            }
        }

        [Theory]
        [InlineData(268, 5, 5268)]
        [InlineData(670, 5, 6750)]
        [InlineData(678, 5, 6785)]
        [InlineData(0, 5, 50)]
        [InlineData(1, 5, 51)]
        [InlineData(5, 5, 55)]
        [InlineData(6, 5, 65)]
        [InlineData(-126, 5, -1256)]
        [InlineData(-123, 5, -1235)]
        [InlineData(-999, 5, -5999)]
        [InlineData(999, 5, 9995)]
        public void TaskTwo(int n, int newDigit, int expected)
        {
            var solution = new AddNumber();
            Assert.Equal(expected, solution.NewMaximum(n, newDigit));
        }

        private class AddNumber
        {
            public int NewMaximum(int n, int newDigit)
            {
                const int decimalNumber = 10;
                var abs = Math.Abs(n);
                var digit = abs == 0 ? 1 : (int)Math.Floor(Math.Log10(abs) + 1);
                var numberMap = new SortedSet<int>();
                for (var j = 0; j < digit + 1; j++)
                {
                    if (j == 0)
                    {
                        numberMap.Add(abs * decimalNumber + newDigit);
                        continue;
                    }

                    var remain = abs % Math.Pow(decimalNumber, j);

                    var result = (abs - remain) * Math.Pow(decimalNumber, 1)
                                 + newDigit * Math.Pow(decimalNumber, j)
                                 + remain;

                    numberMap.Add((int)result);
                }

                return n < 0 ? -numberMap.Min : numberMap.Max;
            }
        }

        [Fact]
        public void ArrayManipulationTest()
        {
            const int n = 10;
            var queries = new List<List<int>>
            {
                new List<int> {2, 6, 8},
                new List<int> {3, 5, 7},
                new List<int> {1, 8, 1},
                new List<int> {5, 9, 15}
            };
            long max = 31;
            Assert.Equal(max, ArrayManipulation(n, queries));
        }
        
        private long ArrayManipulation(int n, List<List<int>> queries)
        {
            var arr = new long[n +1];
            foreach(var query in queries){
                arr[query[0] - 1] += query[2];
                arr[query[1]] -= query[2];
            }
            
            long sum = 0;
            long max = 0;
            for (var i = 0; i < n; i++) {
                sum += arr[i];
                max = Math.Max(max, sum);
            }
        
            return max;
        }
    }
}