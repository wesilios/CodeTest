using System.Collections.Generic;

namespace HackerRank.Solutions
{
    public class BalanceBrackets
    {
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

            return true;
        }
    }
}