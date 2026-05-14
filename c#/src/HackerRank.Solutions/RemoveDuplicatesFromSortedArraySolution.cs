namespace HackerRank.Solutions;

public class RemoveDuplicatesFromSortedArraySolution
{
    /// <summary>
    /// Removes duplicate elements from a sorted array in-place and returns the new length of the modified array.
    /// The method ensures that each unique element appears only once while maintaining the original order of elements.
    /// </summary>
    /// <param name="numbers">A sorted array of integers from which duplicates need to be removed.</param>
    /// <returns>The length of the array containing only unique elements after duplicate removal.</returns>
    public int RemoveDuplicatesFromSortedArray(int[] numbers)
    {
        if (numbers.Length == 0 || numbers.Length == 1) return numbers.Length;
        var result = 1;
        var firstValue = numbers[0];
        for (var i = 1; i < numbers.Length; i++)
        {
            if (numbers[i] == firstValue) continue;
            firstValue = numbers[i];
            numbers[result] = numbers[i];
            result++;
        }

        return result;
    }
}