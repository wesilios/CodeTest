using System.Collections.Generic;

namespace LeetCode.Solutions;

public class ArrayRotationSolution
{
    public void RotateLeft<T>(List<T> arr, int d)
    {
        if (d == arr.Count) return;
        Reverse(arr, 0, d - 1);
        Reverse(arr, d, arr.Count - 1);
        Reverse(arr, 0, arr.Count - 1);
    }

    private void Reverse<T>(List<T> arr, int start, int end)
    {
        while (start < end)
        {
            (arr[start], arr[end]) = (arr[end], arr[start]);
            start++;
            end--;
        }
    }
}