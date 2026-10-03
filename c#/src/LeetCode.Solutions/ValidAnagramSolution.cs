namespace LeetCode.Solutions;

public class ValidAnagramSolution
{
    public bool IsAnagram(string s, string t)
    {
        if (s.Length != t.Length) return false;
        var dictionary = new Dictionary<char, int>();
        foreach (var eachChar in s)
        {
            if (!dictionary.TryAdd(eachChar, 1))
            {
                dictionary[eachChar]++;
            }
        }

        foreach (var eachChar in t)
        {
            if (dictionary.ContainsKey(eachChar))
            {
                dictionary[eachChar]--;
                if (dictionary[eachChar] == 0) dictionary.Remove(eachChar);
                continue;
            }

            return false;
        }

        return true;
    }

    public bool IsAnagramWithUniCode(string s, string t)
    {
        if (s.Length != t.Length) return false;
        var dictionary = new Dictionary<char, int>();
        var i = 0;
        while (i < s.Length)
        {
            if (!dictionary.TryAdd(s[i], 1))
            {
                dictionary[s[i]]++;
            }

            i++;
        }

        i = 0;
        while (i < t.Length)
        {
            if (dictionary.ContainsKey(t[i]))
            {
                dictionary[t[i]]--;
                if(dictionary[t[i]] == 0) dictionary.Remove(t[i]);
                i++;
                continue;
            }

            return false;
        }

        return true;
    }
}