using System;
using System.Collections.Generic;

namespace LeetCode.Solutions
{
    public class CommonCharactersSolution
    {
        public IList<string> CommonChars(string[] words)
        {
            const int asciiLength = 26;
            var wordsLength = words.Length;

            var dictionary = new int[asciiLength];

            for (var i = 0; i < wordsLength; i++)
            {
                var word = words[i];

                var tempDictionary = i == 0 ? dictionary : new int[asciiLength];

                foreach (var ctx in word)
                {
                    tempDictionary[ctx - 'a']++;
                }

                for (var j = 0; j < asciiLength; j++)
                {
                    dictionary[j] = Math.Min(tempDictionary[j], dictionary[j]);
                }
            }

            var commonChars = new List<string>();

            for (var i = 0; i < dictionary.Length; i++)
            {
                var current = (char)(i + 'a');
                var times = dictionary[i];
                while (times-- > 0)
                {
                    commonChars.Add(current.ToString());
                }
            }

            return commonChars;
        }
    }
}