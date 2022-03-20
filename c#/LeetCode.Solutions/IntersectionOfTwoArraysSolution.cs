using System.Collections.Generic;
using System.Linq;

namespace LeetCode.Solutions
{
    public class IntersectionOfTwoArraysSolution
    {
        public T[] IntersectionNoDuplication<T>(T[] nums1, T[] nums2)
        {
            if (nums2.Length < nums1.Length)
            {
                return IntersectionNoDuplication(nums2, nums1);
            }

            var hashSet = new HashSet<T>(nums2);

            var result = new Dictionary<T, T>();
            foreach (var t in nums1)
            {
                if (hashSet.Contains(t) && !result.ContainsKey(t))
                {
                    result.Add(t, t);
                }
            }

            return result.Values.ToArray();
        }

        public T[] IntersectionDuplication<T>(T[] nums1, T[] nums2)
        {
            if (nums2.Length < nums1.Length)
            {
                return IntersectionDuplication(nums2, nums1);
            }

            var hashSet = new HashSet<int>();

            var result = new List<T>();
            foreach (var t in nums1)
            {
                for (var i = 0; i < nums2.Length; i++)
                {
                    if (!t.Equals(nums2[i]) || hashSet.Contains(i)) continue;
                    result.Add(t);
                    hashSet.Add(i);
                    break;
                }
            }

            return result.ToArray();
        }
    }
}