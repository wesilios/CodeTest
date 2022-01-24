using System;
using System.Linq;

namespace HackerRank.Solutions
{
    public class SuperDigitSolution
    {
        public int FindSuperDigit(string n, int k)
        {
            if (k > 1 || n.Length > 1)
            {
                long sum = n.Sum(character => Convert.ToInt32(character.ToString()));
                return FindSuperDigit((sum * k).ToString(), 1);
            }

            return Convert.ToInt32(n) * k;
        }
    }
}