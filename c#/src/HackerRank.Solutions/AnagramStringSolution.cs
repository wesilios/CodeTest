namespace HackerRank.Solutions;

/// <summary>
/// Provides a solution for the HackerRank anagram string problem.
/// Determines the minimum number of character changes needed to make the two halves
/// of a string anagrams of each other.
/// </summary>
public class AnagramStringSolution
{
    /// <summary>
    /// Returns the minimum number of character changes needed to make the two halves
    /// of the input string anagrams of each other.
    /// </summary>
    /// <param name="str">The string to check.</param>
    /// <returns>
    /// The required number of changes, or <c>-1</c> if the string length is odd.
    /// </returns>
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