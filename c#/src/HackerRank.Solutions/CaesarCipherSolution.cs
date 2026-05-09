namespace HackerRank.Solutions;

public class CaesarCipherSolution
{
    /// <summary>
    /// Encrypts a given string using a Caesar cipher algorithm with the specified shift value.
    /// </summary>
    /// <param name="str">The input string to be encrypted, containing alphabetic and non-alphabetic characters.</param>
    /// <param name="k">The shift value, representing the number of positions each letter in the string should be shifted.</param>
    /// <returns>A new string resulting from applying the Caesar cipher on the input string with the given shift value.</returns>
    public string EncryptString(string str, int k)
    {
        const string originalAlphabet = "abcdefghijklmnopqrstuvwxyz";
        var originalAlphabetDictionary = new Dictionary<char, int>();
        var i = 0;
        k = k >= originalAlphabet.Length ? k % originalAlphabet.Length : k;
        foreach (var character in originalAlphabet)
        {
            if (originalAlphabetDictionary.ContainsKey(character)) continue;
            originalAlphabetDictionary.Add(character, i);
            i++;
        }

        var result = string.Empty;
        for (i = 0; i < str.Length; i++)
        {
            if (originalAlphabetDictionary.ContainsKey(str[i]) ||
                originalAlphabetDictionary.ContainsKey(char.ToLower(str[i])))
            {
                var index = originalAlphabetDictionary[char.ToLower(str[i])] + k;
                index = index > originalAlphabet.Length - 1 ? index - originalAlphabet.Length : index;
                if (originalAlphabetDictionary.ContainsKey(str[i]))
                {
                    result += originalAlphabet[index];
                    continue;
                }

                result += char.ToUpper(originalAlphabet[index]);
                continue;
            }

            result += str[i];
        }

        return result;
    }
}