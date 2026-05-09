namespace HackerRank.Solutions;

public class MinimumBribesSolution
{
    /// <summary>
    /// Calculates the total number of bribes that occurred in the given queue. If the state of the queue is invalid,
    /// where an individual has moved forward by more than two positions, the method returns -1.
    /// </summary>
    /// <param name="queue">A list of integers representing the queue, where each integer corresponds to a person's original position.</param>
    /// <returns>An integer representing the total number of bribes in the queue, or -1 if the queue state is invalid.</returns>
    public int CheckTotalBribes(IList<int> queue)
    {
        var count = 0;
        var index = queue.Count - 1;
        while (index >= 0)
        {
            var originalLocation = queue[index] - 1;
            var difference = originalLocation - index;
            if (difference <= 0)
            {
                index--;
                continue;
            }

            if (difference > 2)
            {
                return -1;
            }

            count += difference;
            var temp = queue[index];
            for (var i = 0; i < difference; i++)
            {
                queue[index + i] = queue[index + i + 1];
            }

            queue[originalLocation] = temp;
        }

        return count;
    }
}