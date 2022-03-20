using System;
using System.Collections.Generic;

namespace LeetCode.Solutions
{
    public class FindIndicesAfterSortingArraySolution
    {
        public IList<int> TargetIndices(int[] nums, int target)
        {
            Array.Sort(nums);

            var result = new List<int>();

            var start = 0;
            var end = nums.Length - 1;

            while (start <= end)
            {
                if (nums[start] == target && nums[end] == target) break;
                if (nums[start] != target) start++;
                if (nums[end] != target) end--;
            }

            for (var i = start; i <= end; i++)
            {
                result.Add(i);
            }

            return result;
        }
    }
}