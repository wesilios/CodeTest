namespace LeetCode.Solutions;

public class BinarySearchSolution
{
    public int Search(int[] numbers, int target)
    {
        var start = 0;
        var end = numbers.Length - 1;
        const int notFound = -1;

        while (start <= end)
        {
            var middle = (end + start) / 2;
            var value = numbers[middle];
            if (value == target) return middle;
            if (value < target)
            {
                start = middle + 1;
                continue;
            }

            end = middle - 1;
        }

        return notFound;
    }
}