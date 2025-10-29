namespace HackerRank.Solutions;

public class LongestPalindromicSubstringSolution
{
    public string LongestPalindrome(string str)
    {
        var strLength = str.Length;
        var memoization = new bool[strLength, strLength];
        var li = -1;
        var lj = -1;

        for (var d = 0; d < strLength; d++)
        {
            for (int i = 0, j = d; j < strLength; i++, j++)
            {
                if (d == 0)
                {
                    memoization[i, j] = true;
                }
                else if (d == 1)
                {
                    memoization[i, j] = str[i] == str[j];
                }
                else
                {
                    memoization[i, j] = str[i] == str[j] && memoization[i + 1, j - 1];
                }

                if (!memoization[i, j]) continue;
                li = i;
                lj = j;
            }
        }

        return str.Substring(li, lj - li + 1);
    }
}