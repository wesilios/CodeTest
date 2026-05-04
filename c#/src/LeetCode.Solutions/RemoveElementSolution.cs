using System.Collections.Generic;

namespace LeetCode.Solutions;

public class RemoveElementSolution
{
    public int RemoveElement(List<int> nums, int val)
    {
        var length = 0;
        for (var i = 0; i < nums.Count; i++)
        {
            if (nums[i] == val)
            {
                continue;
            }

            nums[length] = nums[i];
            length++;
        }

        return length;
    }
}