using System.Linq;

namespace HackerRank.Solutions;

public class ZigZagSequenceSolution
{
    public int[] FindZigZagSequence(int[] input)
    {
        input = input.OrderBy(c => c).ToArray();
        var length = input.Length;
        var mid = (input.Length + 1) / 2;
        (input[mid - 1], input[length - 1]) = (input[length - 1], input[mid - 1]);
        var start = mid;
        var end = length - 2;
        while (start <= end)
        {
            (input[start], input[end]) = (input[end], input[start]);
            start++;
            end--;
        }

        return input;
    }
}