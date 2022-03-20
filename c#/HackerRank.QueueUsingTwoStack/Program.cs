using System;
using CodeTest.Library;

namespace HackerRank.QueueUsingTwoStack
{
    class Program
    {
        static void Main(string[] args)
        {
            var queries = Convert.ToInt32(Console.ReadLine());
            var queue = new QueueWithTwoStack<int>();
            for (var i = 0; i < queries; i++)
            {
                var input = Console.ReadLine().Split();
                var dataInput = new int[input.Length];
                for (var j = 0; j < input.Length; j++)
                {
                    dataInput[j] = Convert.ToInt32(input[j]);
                }

                switch (dataInput[0])
                {
                    case 1:
                        queue.Enqueue(dataInput[1]);
                        break;
                    case 2:
                        queue.Dequeue();
                        break;
                    case 3:
                        queue.PrintFront();
                        break;
                }
            }
        }
    }
}