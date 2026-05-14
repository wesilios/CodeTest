namespace HackerRank.Solutions;

public class GameOfTwoStacksSolution
{
    /// <summary>
    /// Determines the maximum number of elements that can be removed from two stacks
    /// (a and b) without exceeding the given maximum sum.
    /// </summary>
    /// <param name="maxSum">The maximum allowed sum of the selected elements.</param>
    /// <param name="a">The list of integers representing the first stack.</param>
    /// <param name="b">The list of integers representing the second stack.</param>
    /// <returns>Returns the maximum number of elements that can be removed while ensuring
    /// the cumulative sum is less than or equal to the specified maximum sum.</returns>
    public int TwoStacks(int maxSum, IList<int> a, IList<int> b)
    {
        var stack = new Stack<int>();
        var sum = 0;
        foreach (var item in a)
        {
            if (sum + item > maxSum) break;
            sum += item;
            stack.Push(item);
        }

        var count = stack.Count;
        var countB = 0;
        foreach (var item in b)
        {
            sum += item;
            countB++;
            while (sum > maxSum && stack.Count > 0)
            {
                sum -= stack.Pop();
            }

            if (sum <= maxSum)
            {
                count = Math.Max(countB + stack.Count, count);
            }
        }

        return count;
    }
}