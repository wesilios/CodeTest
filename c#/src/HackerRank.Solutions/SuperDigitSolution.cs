namespace HackerRank.Solutions;

public class SuperDigitSolution
{
    /// <summary>
    /// Computes the "super digit" of a number represented as a string, repeated a specified number of times.
    /// The "super digit" is the recursive sum of digits until a single-digit result is obtained.
    /// </summary>
    /// <param name="n">A string representing a number whose super digit needs to be calculated.</param>
    /// <param name="k">The number of times the string representation of the number is concatenated.</param>
    /// <returns>An integer representing the super digit of the number.</returns>
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