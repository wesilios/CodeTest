using System;
using Libraries;

Console.WriteLine("Queue Using Two Stacks");
Console.WriteLine("Enter the number of queries first.");
Console.WriteLine("Then enter each query:");
Console.WriteLine("1 x  -> enqueue x");
Console.WriteLine("2    -> dequeue front element");
Console.WriteLine("3    -> print front element");
Console.WriteLine();

var queries = Convert.ToInt32(Console.ReadLine());
Console.WriteLine($"Number of queries {queries}");

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