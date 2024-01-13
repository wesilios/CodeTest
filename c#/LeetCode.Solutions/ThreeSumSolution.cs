using System;
using System.Collections.Generic;

namespace LeetCode.Solutions
{
    public class ThreeSumSolution
    {
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            var triplets = new List<IList<int>>();
            if (nums.Length < 3) return triplets;
            Array.Sort(nums);
            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (nums[i] > 0) break;

                if (i > 0 && nums[i] == nums[i - 1]) continue;

                var left = i + 1;
                var right = nums.Length - 1;

                while (left < right)
                {
                    var sum = nums[i] + nums[left] + nums[right];

                    switch (sum)
                    {
                        case 0:
                        {
                            triplets.Add(new List<int> { nums[i], nums[left], nums[right] });
                            while (left < right && nums[left] == nums[left + 1]) left++;
                            while (left < right && nums[right] == nums[right - 1]) right--;
                            left++;
                            right--;
                            break;
                        }
                        case < 0:
                            left++;
                            break;
                        default:
                            right--;
                            break;
                    }
                }
            }

            return triplets;
        }
    }
}