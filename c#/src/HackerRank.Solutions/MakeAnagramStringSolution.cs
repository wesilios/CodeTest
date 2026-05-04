using System.Collections.Generic;
using System.Linq;

namespace HackerRank.Solutions;

public class MakeAnagramStringSolution
{
    public int GetNumberRemovedCharacterToMakeAnagramString(string s1, string s2)
    {
        var matchCount = 0;
        var dictionary = new Dictionary<char, int>();
        foreach (var character in s1)
        {
            if (dictionary.ContainsKey(character))
            {
                dictionary[character]++;
                continue;
            }

            dictionary.Add(character, 1);
        }

        foreach (var character in s2.Where(character =>
                     dictionary.ContainsKey(character) && dictionary[character] > 0))
        {
            dictionary[character]--;
            matchCount += 2;
        }

        return s1.Length + s2.Length - matchCount;
    }
}