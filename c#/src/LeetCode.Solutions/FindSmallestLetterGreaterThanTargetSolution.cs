namespace LeetCode.Solutions;

public class FindSmallestLetterGreaterThanTargetSolution
{
    public char NextGreatestLetter(char[] letters, char target)
    {
        var low = 0;
        var high = letters.Length - 1;
            
        while (low <= high)
        {
            var middle = low + (high - low) / 2;
            if (letters[middle] > target)
            {
                high = middle - 1;
                continue;
            }

            low = middle + 1;
        }

        return letters[low % letters.Length];
    }
}