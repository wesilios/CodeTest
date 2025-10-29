using System;

namespace LeetCode.Solutions;

public class LengthOfLongestSubstringSolution
{
    public int GetLengthOfLongestSubstring(string s)
    {
        var chars = new int[256];
        Array.Fill(chars, -1);

        var left = 0;
        var right = 0;
        var result = 0;
        while (right < s.Length)
        {
            var r = s[right];
            var index = chars[r];
            if (index != -1 && index >= left && index < right)
            {
                left = index + 1;
            }

            result = Math.Max(result, right - left + 1);
            chars[r] = right;
            right++;
        }

        return result;
    }
}