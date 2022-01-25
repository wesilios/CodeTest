namespace HackerRank.Solutions
{
    public class PowSolution
    {
        public double Pow(double x, int n)
        {
            if (n == 0 || x.Equals(1.0000)) return 1.0;
            if (n == 1) return x;

            if (n == int.MinValue && x > 0)
            {
                return 0.00000;
            }
            
            var tempN = n;
            if (tempN < 0) tempN *= -1;

            var pow = 1.0;
            
            while (tempN > 0)
            {
                if (tempN % 2 == 0)
                {
                    x *= x;
                    tempN /= 2;
                    continue;
                }

                pow *= x;
                tempN--;
            }
            
            if (n < 0)
            {
                return 1.0 / pow;
            }

            return pow;
        }
    }
}