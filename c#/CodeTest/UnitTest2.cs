using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace CodeTest
{
    public class UnitTest2
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public UnitTest2(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void Test1()
        {
            var arr = new int[100000];
            var random = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(-1000000, 1000000);
            }

            var startTime = DateTime.Now;
            var result = SolutionTwo(arr);
            var runTime = DateTime.Now - startTime;
            _testOutputHelper.WriteLine($"Result {result} running in: {runTime}");
        }

        [Fact]
        public void Test2()
        {
            var arr = new[] { -1, -3 };

            var startTime = DateTime.Now;
            var result = SolutionTwo(arr);
            var runTime = DateTime.Now - startTime;
            _testOutputHelper.WriteLine($"Result {result} running in: {runTime}");
            Assert.Equal(1, result);
        }

        private int SolutionTwo(int[] a)
        {
            var numberMap = new SortedSet<int>(a);
            numberMap.RemoveWhere(item => item < 1);
            if (numberMap.Count == 1)
            {
                return numberMap.Min + 1;
            }

            var temp = numberMap.Min;
            var missing = 1;
            foreach (var item in numberMap)
            {
                if (item == temp) continue;
                missing = FindInteger(temp, item);
                temp = item;
                if (!numberMap.Contains(missing))
                {
                    break;
                }
            }

            return missing;
        }

        private int FindInteger(int a, int b)
        {
            if (a > b)
            {
                return FindInteger(b, a);
            }

            var result = a + 1;
            if (a == b || b - a == 1)
            {
                result = b + 1;
            }

            return result;
        }
    }
}