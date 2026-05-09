namespace HackerRank.Solutions;

public class GridChallengeSolution
{
    /// <summary>
    /// Validates if the provided grid of strings is valid based on the rules
    /// that each row is sorted in ascending order, and columns also remain
    /// in ascending sorted order after rows are sorted.
    /// </summary>
    /// <param name="grid">A collection of strings representing the grid.</param>
    /// <returns>True if the grid is valid, otherwise false.</returns>
    public bool IsValidGrid(IEnumerable<string> grid)
    {
        var gridOrdered = grid.Select(OrderString).ToList();
        var dictionaryString = new Dictionary<int, string>();
        foreach (var t in gridOrdered)
        {
            var j = 0;
            while (j < t.Length)
            {
                if (dictionaryString.ContainsKey(j))
                {
                    dictionaryString[j] += t[j];
                    j++;
                    continue;
                }

                dictionaryString.Add(j, new string(new[] { t[j] }));
                j++;
            }
        }

        foreach (var item in dictionaryString)
        {
            if (item.Value.Equals(OrderString(item.Value))) continue;
            return false;
        }

        return true;
    }

    private string OrderString(string str)
    {
        return new string(str.OrderBy(c => c).ToArray());
    }
}