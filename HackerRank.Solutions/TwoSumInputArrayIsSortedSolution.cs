using System;
using System.Collections.Generic;

namespace HackerRank.Solutions
{
    public class TwoSumInputArrayIsSortedSolution
    {
        public int[] TwoSum(int[] numbers, int target)
        {
            var numsMap = new Dictionary<int, int>();
            for (var i = 0; i < numbers.Length; i++)
            {
                var remain = target - numbers[i];
                if (numsMap.ContainsKey(remain))
                {
                    return new[] { numsMap[remain] + 1, i + 1};
                }

                numsMap.TryAdd(numbers[i], i);
            }
            return Array.Empty<int>();
        }
    }
}