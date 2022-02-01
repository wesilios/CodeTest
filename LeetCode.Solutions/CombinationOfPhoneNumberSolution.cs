using System.Collections.Generic;

namespace LeetCode.Solutions
{
    public class CombinationOfPhoneNumberSolution
    {
        private Dictionary<char, string> TelephoneKeyboard => new Dictionary<char, string>
        {
            { '2', "abc" },
            { '3', "def" },
            { '4', "ghi" },
            { '5', "jkl" },
            { '6', "mno" },
            { '7', "pqrs" },
            { '8', "tuv" },
            { '9', "wxyz" },
        };

        public List<string> GetLetterCombination(string digits)
        {
            var combination = new List<string>();
            if (string.IsNullOrEmpty(digits)) return combination;

            GetLetterCombination(digits, combination, string.Empty, 0);
            return combination;
        }

        private void GetLetterCombination(string digits, List<string> combination, string temp, int n)
        {
            if (n == digits.Length)
            {
                combination.Add(temp);
                return;
            }

            var letters = TelephoneKeyboard[digits[n]];
            foreach (var letter in letters)
            {
                GetLetterCombination(digits, combination, temp + letter, n + 1);
            }
        }
    }
}