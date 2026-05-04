using System.Collections.Generic;

namespace HackerRank.Solutions;

public class AnagramStringSolution
{
    public int GetNumberSwapCharacterToMakeAnagramString(string str)
    {
        if (str.Length % 2 != 0) return -1;
        var dictionary = new Dictionary<char, int>();
        for (var i = 0; i < str.Length / 2; i++)
        {
            if (dictionary.ContainsKey(str[i]))
            {
                dictionary[str[i]]++;
                continue;
            }

            dictionary.Add(str[i], 1);
        }

        var count = 0;
        for (var i = str.Length / 2; i < str.Length; i++)
        {
            if (dictionary.ContainsKey(str[i]) && dictionary[str[i]] > 0)
            {
                dictionary[str[i]]--;
                continue;
            }

            count++;
        }

        return count;
    }
}