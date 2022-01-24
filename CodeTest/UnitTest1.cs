using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CodeTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var a = new[] { 1, 3, 6, 4, 1, 2 };
            var b = new[] { 1, 2, 3 };
            var c = new[] { -1, -2, -3 };
            var d = new[] { 1, 3, 6, 5, 4, 2, 1, 8, 11, 13 };
            var e = new[] { 6, 6, 6, 6, 6, 6, 6, 6 };
            var f = new[] { 6, 6, 6, 6, 6, 6, 6, 4 };
            var g = new[] { 4, 2, 6, 8, 9, 7, 10, 1, 3 };
            var h = new[] { 10, 50, 80, -100, -2000, 2000, 1000, 1, 3, -10, -22, -33, 500, 900 };
            Assert.Equal(5, SolutionTwo(a));
            Assert.Equal(4, SolutionTwo(b));
            Assert.Equal(1, SolutionTwo(c));
            Assert.Equal(7, SolutionTwo(d));
            Assert.Equal(7, SolutionTwo(e));
            Assert.Equal(5, SolutionTwo(f));
            Assert.Equal(5, SolutionTwo(g));
            Assert.Equal(2, SolutionTwo(h));
        }

        private int SolutionOne(int[] a)
        {
            var length = a.Length;
            var sumAllNumbers = length * (length + 1) / 2;
            var sumSquareAllNumber = length * (length + 1) * (2 * length + 1) / 6;

            var biggestNumber = a[0];
            for (var i = 0; i < length; i++)
            {
                if (i > 0 && biggestNumber < a[i])
                {
                    biggestNumber = a[i];
                }

                sumAllNumbers -= a[i];
                sumSquareAllNumber -= a[i] * a[i];
            }

            int result;
            if (sumAllNumbers == 0)
            {
                result = biggestNumber + 1;
                return result < 1 ? 1 : result;
            }

            result = (sumAllNumbers + sumSquareAllNumber / sumAllNumbers) / 2;
            return result < 1 ? 1 : result;
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

        private int SolutionThree(int[] a)
        {
            var numberMap = new Dictionary<int, bool>();
            var i = 0;
            var j = a.Length - 1;
            while (i < j)
            {
                FindInteger(numberMap, a[i], a[i + 1]);
                FindInteger(numberMap, a[j], a[j - 1]);
                i++;
                if (j - i > 1) j--;
            }

            var result = 0;
            i = 0;
            foreach (var (key, value) in numberMap)
            {
                if (value) continue;
                if (i == 0)
                {
                    result = key;
                    i++;
                    continue;
                }

                if (result > key)
                {
                    result = key;
                }
            }

            return result < 1 ? 1 : result;
        }

        private void FindInteger(IDictionary<int, bool> numberMap, int a, int b)
        {
            if (!numberMap.ContainsKey(a))
            {
                numberMap.Add(a, true);
            }
            else
            {
                numberMap[a] = true;
            }

            if (!numberMap.ContainsKey(b))
            {
                numberMap.Add(b, true);
            }
            else
            {
                numberMap[b] = true;
            }

            var temp = FindInteger(a, b);
            if (!numberMap.ContainsKey(temp))
            {
                numberMap.Add(temp, false);
            }
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

        [Theory]
        [InlineData(9, 2)]
        [InlineData(529, 4)]
        [InlineData(20, 1)]
        [InlineData(15, 0)]
        [InlineData(1041, 5)]
        [InlineData(32, 0)]
        public void Test2(int n, int gap)
        {
            var binary = DecimalToBinary(n);
            var result = 0;
            var count = 0;
            for (int i = 0; i < binary.Length - 1; i++)
            {
                if (count == 0 && binary[i] == '1' && binary[i + 1] == '0')
                {
                    count++;
                    continue;
                }

                if (count <= 0 || binary[i] != '0') continue;
                if (binary[i + 1] == '1')
                {
                    result = result > count ? result : count;
                    count = 0;
                    continue;
                }

                count++;
            }

            Assert.Equal(gap, result);
        }

        private string DecimalToBinary(int n)
        {
            var result = string.Empty;
            if (n == 0) return "0";
            while (n > 0)
            {
                if (n % 2 == 0)
                {
                    result += '0';
                }
                else
                {
                    result += '1';
                }

                n /= 2;
            }

            return result;
        }

        [Fact]
        public void Test3()
        {
            var a = new[] { 9, 3, 9, 3, 9, 7, 9 };
            var result = 7;
            Assert.Equal(result, Odd(a));
        }

        private int Odd(int[] a)
        {
            if (a.Length == 1) return a[0];
            var map = new HashSet<int>();
            foreach (var value in a)
            {
                if (!map.Contains(value))
                {
                    map.Add(value);
                }
                else
                {
                    map.Remove(value);
                }
            }

            return map.FirstOrDefault();
        }
    }
}