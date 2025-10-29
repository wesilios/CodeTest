namespace LeetCode.Solutions;

public class ValidPerfectSquareSolution
{
    public bool PerfectSquare(int number)
    {
        long low = 0;
        long high = number;

        while (low <= high)
        {
            var mid = low + (high - low) / 2;
            if (mid * mid == number) return true;
                
            if (mid * mid > number)
            {
                high = mid - 1;
                continue;
            }

            low = mid + 1;
        }

        return false;
    }
}