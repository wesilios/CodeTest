namespace LeetCode.Solutions
{
    public class MoveZeroToTheEndSolution
    {
        public int[] MoveZero(int[] input)
        {
            var first = 0;
            var second = 0;

            while (second < input.Length)
            {
                if (input[second] != 0)
                {
                    (input[first], input[second]) = (input[second], input[first]);
                    first++;
                }

                second++;

            }

            return input;
        }
    }
}