namespace HackerRank.Solutions;

public class BalanceBracketsSolution
{
    /// <summary>
    /// Determines whether the input string has balanced brackets. Balanced brackets
    /// are defined as each opening bracket having a corresponding closing bracket
    /// in the correct order.
    /// </summary>
    /// <param name="str">The input string containing brackets.</param>
    /// <returns>
    /// Returns true if the brackets in the input string are balanced; otherwise, false.
    /// </returns>
    public bool IsBalance(string str)
    {
        var dictionary = new Dictionary<char, char>
        {
            { '}', '{' },
            { ']', '[' },
            { ')', '(' },
        };
        var stack = new Stack<char>();
        foreach (var character in str)
        {
            if (dictionary.ContainsKey(character))
            {
                if (stack.Count == 0 || !dictionary[character].Equals(stack.Peek())) return false;
                stack.Pop();
                continue;
            }

            stack.Push(character);
        }

        return stack.Count == 0;
    }
}