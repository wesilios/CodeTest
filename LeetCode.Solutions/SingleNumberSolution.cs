using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Solutions
{
    public class SingleNumberSolution
    {
        public int SingleNumber(int[] nums)
        {
            var numsMap = new HashSet<int>();

            foreach (var num in nums)
            {
                if (numsMap.Contains(num))
                {
                    numsMap.Remove(num);
                    continue;
                }
                
                numsMap.Add(num);
            }

            return numsMap.First();
        }
    }
}