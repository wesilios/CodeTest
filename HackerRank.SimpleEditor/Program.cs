using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRank.SimpleEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            var operations = Convert.ToInt32(Console.ReadLine());
            var stack = new Stack<string>();
            var stringBuilder = new StringBuilder();
            while (operations > 0)
            {
                var operation = Console.ReadLine().Split();
                switch (operation[0])
                {
                    case "1":
                        stack.Push(stringBuilder.ToString());
                        stringBuilder.Append(operation[1]);
                        break;
                    case "2":
                        stack.Push(stringBuilder.ToString());
                        var numberToDeleted = Convert.ToInt32(operation[1]);
                        stringBuilder.Remove(stringBuilder.Length - numberToDeleted, numberToDeleted);
                        break;
                    case "3":
                        Console.WriteLine(stringBuilder[Convert.ToInt32(operation[1]) - 1]);
                        break;
                    case "4":
                        stringBuilder.Clear();
                        stringBuilder.Append(stack.Pop());
                        break;
                }

                operations--;
            }
        }
    }
}