namespace HackerRank.Solutions;

public class ZigZagSequenceSolution
{
    /// <summary>
    /// Rearranges the input array into a zig-zag sequence where the smallest elements
    /// are on the left, the largest elements are in the middle, and the remaining elements
    /// are in descending order on the right.
    /// </summary>
    /// <param name="input">
    /// An array of integers to be rearranged into a zig-zag sequence.
    /// The array should have at least one element and must be sortable.
    /// </param>
    /// <returns>
    /// A new integer array representing the zig-zag sequence prepared from the input array.
    /// </returns>
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