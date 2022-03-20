namespace HackerRank.Solutions
{
    public class RemoveDuplicatesFromSortedArraySolution
    {
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
}