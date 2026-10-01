namespace LeetCode.Solutions;

public class ContainsDuplicateSolution
{
    public bool ContainsDuplicate(int[] nums)
    {
        var hashSet = new HashSet<int>();
        foreach (var num in nums)
        {
            if (hashSet.Contains(num)) return true;
            hashSet.Add(num);
        }

        return false;
    }
}