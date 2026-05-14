namespace Libraries.Algorithm;

public class PrefixSuffixSum
{
    /// <summary>
    /// Computes the prefix sum array for a given input array.
    /// The prefix sum array is constructed such that each element at index i
    /// contains the sum of all elements from the start of the input array
    /// up to index i.
    /// P[i] = A[0] + A[1] + ... + A[i]
    /// </summary>
    /// <param name="a">
    /// The input array for which the prefix sum array will be computed.
    /// </param>
    /// <returns>
    /// An array containing the prefix sums of the input array.
    /// </returns>
    public int[] PrefixSum(int[] a)
    {
        var result = new int[a.Length];
        result[0] = a[0];
        for (var i = 1; i < a.Length; i++)
        {
            result[i] = result[i - 1] + a[i];
        }

        return result;
    }

    public int[] SuffixSum(int[] a)
    {
        var result = new int[a.Length];
        result[^1] = a[^1];
        for (var i = a.Length - 2; i >= 0; i--)
        {
            result[i] = result[i + 1] + a[i];
        }

        return result;
    }

    public int CountTotal(int[] prefixSum, int x, int y)
    {
        if (x > y) return CountTotal(prefixSum, y, x);
        if (x < 0 || y < 0 || x > prefixSum.Length - 1 || y > prefixSum.Length - 1)
        {
            throw new InvalidOperationException();
        }

        return prefixSum[y + 1] - prefixSum[x];
    }

    public int MushroomMoves(int[] a, int spot, int moves)
    {
        var n = a.Length;
        if (spot < 0 || moves >= n)
        {
            throw new InvalidOperationException();
        }

        var result = 0;
        var prefix = PrefixSum(a);
        for (int i = 0; i < Math.Min(moves, spot) + 1; i++)
        {
            var leftPosition = spot - i;
            var rightPosition = Math.Min(n - 1, Math.Max(spot, spot + moves - 2 * i));
            result = Math.Max(result, CountTotal(prefix, leftPosition, rightPosition));
        }

        for (int i = 0; i < Math.Min(moves + 1, n - spot); i++)
        {
            var rightPosition = spot + i;
            var leftPosition = Math.Max(0, Math.Min(spot, spot - (moves - 2 * i)));
            result = Math.Max(result, CountTotal(prefix, leftPosition, rightPosition));
        }

        return result;
    }
}