namespace LeetCode.Solutions;

public class SqrtSolution
{
    public int Sqrt(int x)
    {
        long low = 0;
        long high = x;
        while (low + 1 < high)
        {
            var mid = low + (high - low) / 2;
            if (mid * mid == x) return (int) mid;
            if (mid * mid > x)
            {
                high = mid;
                continue;
            }

            low = mid;
        }

        return high * high == x ? (int)high : (int)low;
    }
}