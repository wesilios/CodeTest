using System;
using System.Collections.Generic;

namespace HackerRank.Solutions
{
    public class GameOfTwoStacksSolution
    {
        public int TwoStacks(int maxSum, IList<int> a, IList<int> b)
        {
            var stack = new Stack<int>();
            var sum = 0;
            foreach (var item in a)
            {
                if (sum + item > maxSum) break;
                sum += item;
                stack.Push(item);
            }

            var count = stack.Count;
            var countB = 0;
            foreach (var item in b)
            {
                sum += item;
                countB++;
                while (sum > maxSum && stack.Count > 0)
                {
                    sum -= stack.Pop();
                }

                if (sum <= maxSum)
                {
                    count = Math.Max(countB + stack.Count, count);
                }
            }

            return count;
        }
    }
}