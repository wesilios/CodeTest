namespace HackerRank.Solutions
{
    public class PalindromeStringSolution
    {
        public int FindPalindromeIndex(string str)
        {
            var result = -1;
            var left = 0;
            var right = str.Length - 1;
            while (right > left)
            {
                if (str[left] == str[right])
                {
                    left++;
                    right--;
                    continue;
                }

                if (str[left] == str[right - 1] && str[left + 1] == str[right - 2])
                {
                    result = right;
                    right--;
                    continue;
                }

                if (str[left + 1] != str[right] || str[left + 2] != str[right - 1]) continue;
                result = left;
                left++;
            }

            return result;
        }
    }
}