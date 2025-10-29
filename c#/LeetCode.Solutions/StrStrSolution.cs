namespace LeetCode.Solutions;

public class StrStrSolution
{
    public int StrStr(string haystack, string needle)
    {
        if (string.IsNullOrEmpty(needle)) return 0;
        var indexOf = -1;
        if (haystack.Length < needle.Length) return indexOf;
        var i = 0;
        while (i + needle.Length <= haystack.Length)
        {
            var subString = haystack.Substring(i, needle.Length);
            if (subString.Equals(needle))
            {
                indexOf = i;
                break;
            }

            i++;
        }

        return indexOf;
    }
}