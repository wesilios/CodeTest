using System.Collections.Generic;

namespace HackerRank.Solutions
{
    public class RomanToIntegerSolution
    {
        private Dictionary<char, int> RomanValues => new Dictionary<char, int>()
        {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 }
        };

        public int RomanToInteger(string s)
        {
            var result = 0;
            for (var index = 0; index < s.Length; index++)
            {
                var character = s[index];
                if (!RomanValues.ContainsKey(character)) continue;
                if (index < s.Length - 1)
                {
                    var nextCharacter = s[index + 1];
                    if (character == 'I' && (nextCharacter == 'V' || nextCharacter == 'X')
                        || character == 'X' && (nextCharacter == 'L' || nextCharacter == 'C')
                        || character == 'C' && (nextCharacter == 'D' || nextCharacter == 'M'))
                    {
                        result -= RomanValues[character];
                        continue;
                    }
                }

                result += RomanValues[character];
            }

            return result;
        }
    }
}