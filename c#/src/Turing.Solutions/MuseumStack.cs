namespace Turing.Solutions;

public class MuseumStack
{
    public int Solution(int[] k)
    {
        var dictionary = new Dictionary<int, int>();
        foreach (var item in k)
        {
            if (dictionary.TryAdd(item, 1)) continue;
            dictionary[item]++;
        }

        var count = -1;
        foreach (var (key, value) in dictionary)
        {
            var temp = 0;
            if (dictionary.TryGetValue(key - 1, out var before))
            {
                temp += before;
            }

            if (dictionary.TryGetValue(key + 1, out var after))
            {
                temp += after;
            }

            if (temp > 0 && (temp < count || count == -1))
            {
                count = temp;
            }
        }

        return count;
    }
}