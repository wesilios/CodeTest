using System.Collections.Generic;

namespace HackerRank.Solutions;

public class MinimumBribesSolution
{
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