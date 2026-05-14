using System.Text;

namespace HackerRank.Solutions;

public class PalindromeStringSolution
{
    /// <summary>
    /// Determines the index of a character in the input string that can be removed to make the string a palindrome.
    /// If the string is already a palindrome, the method returns -1. If no such index exists, the method also returns -1.
    /// </summary>
    /// <param name="str">The input string to be evaluated.</param>
    /// <returns>
    /// An integer representing the zero-based index of the character that can be removed to form a palindrome.
    /// Returns -1 if the input is already a palindrome or if no such index exists.
    /// </returns>
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

    /// <summary>
    /// Determines whether the input string can be rearranged to form a palindrome.
    /// If possible, returns the rearranged palindrome string. If not, returns "None".
    /// </summary>
    /// <param name="str">The input string to be evaluated.</param>
    /// <returns>
    /// A string representing the rearranged palindrome if possible,
    /// or "None" if the string cannot be arranged as a palindrome.
    /// </returns>
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