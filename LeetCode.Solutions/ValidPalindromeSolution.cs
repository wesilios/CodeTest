using System.Text.RegularExpressions;

namespace LeetCode.Solutions
{
    public class ValidPalindromeSolution
    {
        public bool IsValidPalindrome(string s)
        {
            var str = TrimDuplicateSpacesBetweenCharacters(s, "");
            str = TrimSpecialCharacters(str, "");
            str = str.Trim();
            str = str.ToLowerInvariant();

            var start = 0;
            var end = str.Length - 1;
            while (end > start)
            {
                if (str[start++] != str[end--]) return false;
            }

            return true;
        }

        public string TrimSpecialCharacters(string str, string replacement = " ")
        {
            if (string.IsNullOrEmpty(str)) return str;

            var regEx = new Regex("[^A-Za-z0-9]");
            return Regex.Replace(regEx.Replace(str, replacement), @"\s+", replacement);
        }

        public string TrimDuplicateSpacesBetweenCharacters(string str, string replacement = " ")
        {
            if (string.IsNullOrEmpty(str)) return str;

            var regex = new Regex("[ ]{2,}", RegexOptions.None);
            str = regex.Replace(str, replacement);

            return str;
        }
    }
}