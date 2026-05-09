namespace HackerRank.Solutions;

public class MakeAnagramStringSolution
{
    /// <summary>
    /// Calculates the minimum number of characters that need to be removed
    /// from two strings to make them anagrams of each other.
    /// </summary>
    /// <param name="s1">The first input string.</param>
    /// <param name="s2">The second input string.</param>
    /// <returns>The total number of character deletions required to make the two strings anagrams.</returns>
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