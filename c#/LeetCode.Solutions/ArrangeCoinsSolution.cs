namespace LeetCode.Solutions
{
    public class ArrangeCoinsSolution
    {
        public int ArrangeCoins(int n)
        {
            var row = 1;
            while (true)
            {
                var remain = n - row;
                if (remain < row + 1)
                {
                    break;
                }

                n = remain;
                row++;
            }

            return row;
        }
    }
}