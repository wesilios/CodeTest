using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public string CheckCanArrangeToPalindromeString(string str)
        {
            var countChars = new Dictionary<char, int>();

            foreach (var character in str)
            {
                if (countChars.ContainsKey(character))
                {
                    countChars[character]++;
                    continue;
                }
                
                countChars.Add(character, 1);
            }

            var oddChar = string.Empty;
            var palindrome = string.Empty;
            foreach (var (key, value) in countChars)
            {
                if (value % 2 == 0)
                {
                    palindrome += new StringBuilder(1 * value).Insert(0, key.ToString(), value / 2).ToString();
                    continue;
                }

                if (oddChar != string.Empty || key.ToString() == oddChar) return "None";
                oddChar = key.ToString();
                palindrome += new StringBuilder(1 * value).Insert(0, key.ToString(), value / 2).ToString();

            }

            return $"{palindrome}{oddChar}{new string(palindrome.Reverse().ToArray())}";
        }
    }
}